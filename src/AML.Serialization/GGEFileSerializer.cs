using AML.Domain;
using AML.Infrastructure.Readers.Interfaces;
using AML.Serialization.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AML.Serialization
{
    public class GGEFileSerializer : ISerialize<InputlistPair>
    {
        private readonly IDataReaderWorksheetParametreic<DJListPair> ggeReader;
        private readonly IDataReaderDoubleWorksheetParametreic<DJListPair> ggeReaderDouble;
        bool doubleOverload = false;
        //private static List<string> tempKeys;
        private static List<string> permKeys;
        string sourcePerm, sourceTemp, sourceTempworksheetName, sourcePermworksheetName;
        public GGEFileSerializer(IDataReaderWorksheetParametreic<DJListPair> ggeReader,
            string sourcePerm, string sourceTemp, string sourceTempworksheetName)
        {
            this.ggeReader = ggeReader;
            this.sourcePerm = sourcePerm;
            this.sourceTemp = sourceTemp;
            this.sourceTempworksheetName = sourceTempworksheetName;
            //tempKeys = new List<string>();
            permKeys = new List<string>();
        }

        public GGEFileSerializer(IDataReaderDoubleWorksheetParametreic<DJListPair> ggeReader,
    string sourceTemp, string worksheetNameTemp, 
            string sourcePerm, string worksheetNamePerm)
        {
            this.ggeReaderDouble = ggeReader;
            this.sourcePerm = sourcePerm;
            this.sourceTemp = sourceTemp;
            this.sourceTempworksheetName = worksheetNameTemp;
            this.sourcePermworksheetName = worksheetNamePerm;
            permKeys = new List<string>();
            doubleOverload = true;
        }

        public InputlistPair Serialize()
        {
            if (doubleOverload)
            {
                var serializedObject = new List<FieldNameInputValuePairObject>();
                var ggeResults = ggeReaderDouble.GetData(sourceTemp, sourceTempworksheetName, 
                    0, sourcePerm, sourcePermworksheetName, 0);
                var tempEmployees = ggeResults.dJListRowsTemp;
                var permEmployees = ggeResults.dJListRowsPerm;
                SerializeTemp(serializedObject, tempEmployees);
                SerializePerm(serializedObject, permEmployees);
                var serializedPair = new InputlistPair();
                serializedPair.OutputAndExtension = serializedObject.OrderBy(s => s.CustNo).ToList();
                serializedPair.RelationshipList = new List<FieldNameInputValuePairObject>();
                return serializedPair;
            }
            else
            {
                var serializedObject = new List<FieldNameInputValuePairObject>();
                var ggeResults = ggeReader.GetData(sourceTemp, sourceTempworksheetName, 0);
                var tempEmployees = ggeResults.dJListRowsTemp;
                var permEmployees = ggeResults.dJListRowsPerm;
                SerializeTemp(serializedObject, tempEmployees);
                SerializePerm(serializedObject, permEmployees);
                var serializedPair = new InputlistPair();
                serializedPair.OutputAndExtension = serializedObject.OrderBy(s => s.CustNo).ToList();
                serializedPair.RelationshipList = new List<FieldNameInputValuePairObject>();
                return serializedPair;
            }
        }

        private void SerializeTemp(List<FieldNameInputValuePairObject> serializedObject, IList<DJListRow> djRows)
        {
            foreach(var value in djRows)
            {
                if (value.Row[0].Any(char.IsDigit))
                {
                    if ((!permKeys.Contains(value.Row[0].Trim())) && value.Row[5] != "N/A" && !string.IsNullOrEmpty(value.Row[5]))
                    {
                        permKeys.Add(value.Row[0].Trim());
                        var pairList = new List<FieldNameInputValuePair>();
                        var idOrPassport = string.IsNullOrEmpty(value.Row[4]) ? value.Row[5] : value.Row[4];
                        
                        var rowVal0 = value.Row[0].Count() > 16 ? value.Row[0].Substring(0, 16) : value.Row[0];

                      

                        var rowVal4 = idOrPassport.Count() > 16 ? idOrPassport.Substring(0, 16) : idOrPassport;
                        var rowVal1 = value.Row[1].Count() > 32 ? value.Row[1].Substring(0, 32) : value.Row[1];
                        var rowVal2 = value.Row[2].Count() > 32 ? value.Row[2].Substring(0, 32) : value.Row[2];

                        var country = string.IsNullOrEmpty(value.Row[6])?"RSA": value.Row[6];
                        var rowVal6 = country.Count() > 3 ? country.Substring(0, 3) : country;

                        var rowValExt4 = rowVal4.Count() > 16 ? rowVal4.Substring(16, rowVal4.Count() - 16) : "";
                        var rowValExt1 = value.Row[1].Count() > 32 ? value.Row[1].Substring(32, value.Row[1].Count() - 32) : "";
                        var rowValExt2 = value.Row[2].Count() > 32 ? value.Row[2].Substring(32, value.Row[2].Count() - 32) : "";
                        var rowValExt6 = country.Count() > 3 ? country.Substring(3, country.Count() - 3) : "";


                        var rowVal3 = value.Row[3].Replace(".", string.Empty).Replace(",", string.Empty).Replace("\\", string.Empty).Replace("/", string.Empty).Count() > 8
                            ? value.Row[3].Replace(".", string.Empty).Replace(",", string.Empty).Replace("\\", string.Empty).Replace("/", string.Empty).Substring(0, 8)
                            : value.Row[3].Replace(".", string.Empty).Replace(",", string.Empty).Replace("\\", string.Empty).Replace("/", string.Empty);
                       
                        var rowValExt3 = rowVal3.Count() > 8 ? rowVal3.Substring(8, rowVal3.Count() - 8) : "";

                        var pair1 = new FieldNameInputValuePair("LASTNAME_COMPANYNAME", rowVal2, rowValExt2);
                        var pair2 = new FieldNameInputValuePair("FIRST_NAME", rowVal1, rowValExt1);
                        var pair3 = new FieldNameInputValuePair("CUSTNO", rowVal0, rowVal0);//EMPLNO
                        var pair4 = new FieldNameInputValuePair("PASS_NO", rowVal4, rowVal4);
                        var pair5 = new FieldNameInputValuePair("BIRTH_COUNTRY", rowVal6, rowValExt6);
                        var pair6 = new FieldNameInputValuePair("BIRTHDATE", rowVal3, rowValExt3);
                        var pair7 = new FieldNameInputValuePair("EMPLNO", rowVal0, rowVal0);//TOWN

                        pairList.Add(pair1);
                        pairList.Add(pair2);
                        pairList.Add(pair3);
                        pairList.Add(pair4);
                        pairList.Add(pair5);
                        pairList.Add(pair6);
                        pairList.Add(pair7);

                        pairList.Add(new FieldNameInputValuePair("INSTITUTE", "GGE0", "GGE0"));
                        var serializedPairObject = new FieldNameInputValuePairObject();
                        serializedPairObject.FieldNameInputValuePairList = pairList;
                        serializedPairObject.CustNo = rowVal0;
                        serializedObject.Add(serializedPairObject);
                    }
                }
            }
        }

        private void SerializePerm(List<FieldNameInputValuePairObject> serializedObject, IList<DJListRow> djRows)
        {
            foreach (var value in djRows)
            {
                if (value.Row[0].Any(char.IsDigit))
                {
                    if (!permKeys.Contains(value.Row[0].Trim()) && value.Row[2] != "N/A" && !string.IsNullOrEmpty(value.Row[2]))
                    {
                        permKeys.Add(value.Row[0].Trim());
                        var pairList = new List<FieldNameInputValuePair>();
                        var rowVal0 = value.Row[0].Count() > 16 ? value.Row[0].Substring(0, 16) : value.Row[0];

                        

                        var rowVal2 = value.Row[2].Count() > 32 ? value.Row[2].Substring(0, 32) : value.Row[2];
                        var rowVal1 = value.Row[1].Count() > 32 ? value.Row[1].Substring(0, 32) : value.Row[1];
                        var rowVal3 = value.Row[3].Count() > 16 ? value.Row[3].Substring(0, 16) : value.Row[3];

                        var rowValExt2 = value.Row[2].Count() > 32 ? value.Row[2].Substring(32, value.Row[2].Count() - 32) : "";
                        var rowValExt1 = value.Row[1].Count() > 32 ? value.Row[1].Substring(32, value.Row[1].Count() - 32) : "";
                        var rowValExt0 = value.Row[0].Count() > 32 ? value.Row[0].Substring(32, value.Row[0].Count() - 32) : "";
                        var rowValExt3 = value.Row[3].Count() > 16 ? value.Row[3].Substring(16, value.Row[3].Count() - 16) : "";

                        var rowVal7 = value.Row[7].Count() > 7 ? value.Row[7].Substring(0, 7) : value.Row[7];
                        var rowValExt7 = value.Row[7].Count() > 7 ? value.Row[7].Substring(7, value.Row[7].Count() - 7) : "";

                        var rowVal6 = value.Row[6].Count() > 28 ? value.Row[6].Substring(0, 28) : value.Row[6];
                        var rowValExt6 = value.Row[6].Count() > 28 ? value.Row[6].Substring(28, value.Row[6].Count() - 28) : "";

                        var rowVal5 = value.Row[5].Count() > 1 ? value.Row[5].Substring(0, 1) : value.Row[5];
                        var rowValExt5 = value.Row[5].Count() > 1 ? value.Row[5].Substring(1, value.Row[5].Count() - 1) : "";

                        var rowVal4 = value.Row[4].Replace(".", string.Empty).Replace(",", string.Empty).Replace("\\", string.Empty).Replace("/", string.Empty).Count() > 8
                            ? value.Row[4].Replace(".", string.Empty).Replace(",", string.Empty).Replace("\\", string.Empty).Replace("/", string.Empty).Substring(0, 8)
                            : value.Row[4].Replace(".", string.Empty).Replace(",", string.Empty).Replace("\\", string.Empty).Replace("/", string.Empty);
                        
                        var rowValExt4 = rowVal4.Count() > 8 ? rowVal4.Substring(8, rowVal4.Count() - 8) : "";

                        var pair1 = new FieldNameInputValuePair("LASTNAME_COMPANYNAME", rowVal2, rowValExt2);
                        var pair2 = new FieldNameInputValuePair("FIRST_NAME", rowVal1, rowValExt1);
                        var pair3 = new FieldNameInputValuePair("CUSTNO", rowVal0, rowVal0);
                        var pair4 = new FieldNameInputValuePair("PASS_NO", rowVal3, rowVal3);
                        var pair5 = new FieldNameInputValuePair("ZIP", rowVal7, rowValExt7);
                        var pair6 = new FieldNameInputValuePair("BIRTHDATE", rowVal4, rowValExt4);
                        var pair7 = new FieldNameInputValuePair("GENDER", rowVal5, rowValExt5);
                        var pair8 = new FieldNameInputValuePair("EMPLNO", rowVal0, rowVal0);

                        var pairTown = new FieldNameInputValuePair("TOWN", rowVal6, rowValExt6);

                        pairList.Add(pair1);
                        pairList.Add(pair2);
                        pairList.Add(pair3);
                        pairList.Add(pair4);
                        pairList.Add(pair5);
                        pairList.Add(pair6);
                        pairList.Add(pair7);
                        pairList.Add(pair8);
                        pairList.Add(pairTown);

                        pairList.Add(new FieldNameInputValuePair("INSTITUTE", "GGE0", "GGE0"));
                        var serializedPairObject = new FieldNameInputValuePairObject();
                        serializedPairObject.FieldNameInputValuePairList = pairList;
                        serializedPairObject.CustNo = rowVal0;
                        serializedObject.Add(serializedPairObject);
                    }
                }
            }
        }
    }
}
