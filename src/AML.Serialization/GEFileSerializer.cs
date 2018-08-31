using AML.Common;
using AML.Domain;
using AML.Infrastructure.Readers.Interfaces;
using AML.Serialization.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AML.Serialization
{
    public class GEFileSerializer : ISerialize<InputlistPair>
    {
        private static List<string> personKeys;
        private static List<string> entityKeys;
        private static List<string> relationshipKeys;
        string sourceFilePerson;
        string worksheetNamePerson;
        string sourceFileEntity;
        string worksheetNameEntity;
        private readonly IDataReaderWorksheetParametreic<IList<DJListRow>> reader;
        public GEFileSerializer(IDataReaderWorksheetParametreic<IList<DJListRow>> reader, string sourceFilePerson,
        string worksheetNamePerson,
        string sourceFileEntity,
        string worksheetNameEntity)
        {
            this.reader = reader;
            personKeys = new List<string>();
            entityKeys = new List<string>();
            relationshipKeys = new List<string>();
            this.sourceFilePerson = sourceFilePerson;
            this.worksheetNamePerson = worksheetNamePerson;
            this.sourceFileEntity = sourceFileEntity;
            this.worksheetNameEntity = worksheetNameEntity;
        }

        public InputlistPair Serialize()
        {
            var serializedObject = new List<FieldNameInputValuePairObject>();

            var personData = reader.GetData(sourceFilePerson, worksheetNamePerson,6);
            var entityData = reader.GetData(sourceFileEntity, worksheetNameEntity,0);
            var matchedResults = MatchCompanyAndPerson(personData, entityData);
            
            SerializePersons(serializedObject, personData);
            SerializeEntities(serializedObject, entityData);
            List<FieldNameInputValuePairObject> pairingObjects = CreateRelationshipFile(matchedResults);
            var serializedPair = new InputlistPair();
            serializedPair.OutputAndExtension = serializedObject.OrderBy(s=>s.CustNo).ToList();
            serializedPair.RelationshipList = pairingObjects.OrderBy(s => s.CustNo).ToList();
            return serializedPair;
        }

        private static List<FieldNameInputValuePairObject> CreateRelationshipFile(MatchedDJListObject matchedResults)
        {
            var cnt = 0;
            var pairingObjects = new List<FieldNameInputValuePairObject>();
            foreach (var resultPair in matchedResults.PersonList)
            {
                var per = matchedResults.PersonList[cnt].Row[0].Trim();
                var perb = matchedResults.EntityList[cnt];
                var per2 = matchedResults.EntityList[cnt].Row[0].Trim();
                var val = relationshipKeys.Contains(matchedResults.PersonList[cnt].Row[6].Trim());
                var val2 = personKeys.Contains(matchedResults.PersonList[cnt].Row[6].Trim());
                var val3 = entityKeys.Contains(matchedResults.EntityList[cnt].Row[0].Trim());


                if (!relationshipKeys.Contains(matchedResults.PersonList[cnt].Row[6].Trim()) 
                    && personKeys.Contains(matchedResults.PersonList[cnt].Row[6].Trim())
                    && entityKeys.Contains(matchedResults.EntityList[cnt].Row[0].Trim()))
                {
                    if (matchedResults.PersonList[cnt].Row[6].Any(char.IsDigit) 
                        && matchedResults.EntityList[cnt].Row[0].Any(char.IsDigit))
                    {
                        relationshipKeys.Add(matchedResults.PersonList[cnt].Row[6].Trim());
                        var pairList = new List<FieldNameInputValuePair>();
                        var pair0 = new FieldNameInputValuePair("INSTITUTE", "GE00", "");
                        var pair1 = new FieldNameInputValuePair("CUSTNO", matchedResults.PersonList[cnt].Row[6], "");
                        var pair2 = new FieldNameInputValuePair("REL_CUSTNO", matchedResults.EntityList[cnt].Row[0], "");
                        var pair3 = new FieldNameInputValuePair("REL_TYPE", "" + "DI", "");
                        var pair4 = new FieldNameInputValuePair("REL_SHARE", "0.0", "");
                        var pair5 = new FieldNameInputValuePair("REL_FLAG1", "", "");
                        var pair6 = new FieldNameInputValuePair("REL_FLAG2", "", "");
                        var pair7 = new FieldNameInputValuePair("REL_FLAG3", "", "");
                        var pair8 = new FieldNameInputValuePair("REL_COMMENT", "", "");
                        var pair9 = new FieldNameInputValuePair("PROCESSFLAG", "", "");
                        pairList.Add(pair0);
                        pairList.Add(pair1);
                        pairList.Add(pair2);
                        pairList.Add(pair3);
                        pairList.Add(pair4);
                        pairList.Add(pair5);
                        pairList.Add(pair6);
                        pairList.Add(pair7);
                        pairList.Add(pair8);
                        pairList.Add(pair9);
                        var serializedPairObject = new FieldNameInputValuePairObject();
                        serializedPairObject.FieldNameInputValuePairList = pairList;
                        serializedPairObject.CustNo = matchedResults.PersonList[cnt].Row[6];
                        pairingObjects.Add(serializedPairObject);
                    }
                }
                cnt++;
            }

            return pairingObjects;
        }

        private static void SerializeEntities(List<FieldNameInputValuePairObject> serializedObject, IList<DJListRow> djRows)
        {
            Encoding enc = new UTF8Encoding(true, true);
            foreach (var value in djRows)
            {
                if (value.Row[0].Any(char.IsDigit))
                {
                    if (!entityKeys.Contains(value.Row[0].Trim()) && value.Row[1] != "N/A" && !string.IsNullOrEmpty(value.Row[1]))
                    {
                        entityKeys.Add(value.Row[0].Trim());
                        var pairList = new List<FieldNameInputValuePair>();

                        var rowVal1 = value.Row[1].Count() > 32 ? value.Row[1].Substring(0, 32) : value.Row[1];
                        var rowVal0 = value.Row[0].Count() > 16 ? value.Row[0].Substring(0, 16) : value.Row[0];

                        var rowVal5 = value.Row[5].Count() > 32 ? value.Row[5].Substring(0, 32) : value.Row[5];

                        var rowValExt5 = value.Row[5].Count() > 32 ? value.Row[5].Substring(32, value.Row[5].Count() - 32) : "";
                        var rowValExt1 = value.Row[1].Count() > 32 ? value.Row[1].Substring(32, value.Row[1].Count() - 32) : "";
                        var rowValExt0 = value.Row[0].Count() > 16 ? value.Row[0].Substring(16, value.Row[0].Count() - 32) : "";

                        var rowVal7 = value.Row[7].Count() > 8 ? value.Row[7].Substring(0, 8) : value.Row[7];
                        var rowValExt7 = value.Row[7].Count() > 8 ? value.Row[7].Substring(8, value.Row[7].Count() - 8) : "";

                        var pair1 = new FieldNameInputValuePair("LASTNAME_COMPANYNAME", rowVal1, rowValExt1);
                        var pair2 = new FieldNameInputValuePair("FIRST_NAME", "", "");
                        var pair3 = new FieldNameInputValuePair("CUSTNO", rowVal0, rowVal0);
                        var pair4 = new FieldNameInputValuePair("CUSTCONTACT", "", "");

                        pairList.Add(pair1);
                        pairList.Add(pair2);
                        pairList.Add(pair3);
                        pairList.Add(pair4);

                        pairList.Add(new FieldNameInputValuePair("INSTITUTE", enc.GetString(enc.GetBytes("GE00")), enc.GetString(enc.GetBytes("GE00"))));
                        var serializedPairObject = new FieldNameInputValuePairObject();
                        serializedPairObject.FieldNameInputValuePairList = pairList;
                        serializedPairObject.CustNo = rowVal0;
                        serializedObject.Add(serializedPairObject);
                    }
                }
            }
        }

        private static void SerializePersons(List<FieldNameInputValuePairObject> serializedObject, IList<DJListRow> djRows)
        {
            Encoding enc = new UTF8Encoding(true, true);
            foreach (var value in djRows)
            {
                if (value.Row[6].Any(char.IsDigit))
                {
                    if (!personKeys.Contains(value.Row[6].Trim()) && value.Row[5]!="N/A" && !string.IsNullOrEmpty(value.Row[5]))
                    {
                        personKeys.Add(value.Row[6].Trim());
                        var pairList = new List<FieldNameInputValuePair>();
                        var rowVal5 = value.Row[5].Count() > 32 ? value.Row[5].Substring(0, 32) : value.Row[5];
                        var rowVal1 = value.Row[1].Count() > 32 ? value.Row[1].Substring(0, 32) : value.Row[1];
                        var rowVal0 = value.Row[0].Count() > 32 ? value.Row[0].Substring(0, 32) : value.Row[0];
                        var rowVal6 = value.Row[6].Count() > 16 ? value.Row[6].Substring(0, 16) : value.Row[6];

                        var rowValExt5 = value.Row[5].Count() > 32 ? value.Row[5].Substring(32, value.Row[5].Count() - 32) : "";
                        var rowValExt1 = value.Row[1].Count() > 32 ? value.Row[1].Substring(32, value.Row[1].Count() - 32) : "";
                        var rowValExt0 = value.Row[0].Count() > 32 ? value.Row[0].Substring(32, value.Row[0].Count() - 32) : "";
                        var rowValExt6 = value.Row[6].Count() > 16 ? value.Row[6].Substring(16, value.Row[6].Count() - 16) : "";

                        var rowVal7 = value.Row[7].Count() > 8 ? value.Row[7].Substring(0, 8) : value.Row[7];
                        var rowValExt7 = value.Row[7].Count() > 8 ? value.Row[7].Substring(8, value.Row[7].Count() - 8) : "";

                        var rowVal8 = CountryCodes.GetCountryCode(value.Row[8]);
                        var rowValExt8 = "";

                        var rowVal10 = value.Row[10].Count() > 1 ? value.Row[10].Substring(0, 1) : value.Row[10];
                        var rowValExt10 = value.Row[10].Count() > 1 ? value.Row[10].Substring(1, value.Row[10].Count() - 1) : "";

                        var rowVal11 = value.Row[11].Replace(".", string.Empty).Replace(",", string.Empty).Replace("\\", string.Empty).Replace("/", string.Empty).Count() > 8
                            ? value.Row[11].Replace(".", string.Empty).Replace(",", string.Empty).Replace("\\", string.Empty).Replace("/", string.Empty).Substring(0, 8)
                            : value.Row[11].Replace(".", string.Empty).Replace(",", string.Empty).Replace("\\", string.Empty).Replace("/", string.Empty);
                        var dateRowVal11 = rowVal11.Count()<8?"" : rowVal11.Substring(4, 4) + rowVal11.Substring(2, 2) + rowVal11.Substring(0, 2);
                        var rowValExt11 = dateRowVal11.Count() > 8 ? dateRowVal11.Substring(8, dateRowVal11.Count() - 8) : "";

                        var pair1 = new FieldNameInputValuePair("LASTNAME_COMPANYNAME", enc.GetString(enc.GetBytes(rowVal5)), enc.GetString(enc.GetBytes(rowValExt5)));
                        var pair2 = new FieldNameInputValuePair("FIRST_NAME", enc.GetString(enc.GetBytes(rowVal1)), enc.GetString(enc.GetBytes(rowValExt1)));
                        var pair3 = new FieldNameInputValuePair("CUSTNO", rowVal6, rowVal6);

                        var pair4 = new FieldNameInputValuePair("CUSTCONTACT", "", "");
                        var pair5 = new FieldNameInputValuePair("H_COUNTRY", rowVal8, rowValExt8);
                        var pair6 = new FieldNameInputValuePair("BIRTHDATE", dateRowVal11, rowValExt11);
                        var pair7 = new FieldNameInputValuePair("GENDER", enc.GetString(enc.GetBytes(rowVal10)), enc.GetString(enc.GetBytes(rowValExt10)));

                        pairList.Add(pair1);
                        pairList.Add(pair2);
                        pairList.Add(pair3);
                        pairList.Add(pair4);
                        pairList.Add(pair5);
                        pairList.Add(pair6);
                        pairList.Add(pair7);

                        pairList.Add(new FieldNameInputValuePair("INSTITUTE", enc.GetString(enc.GetBytes("GE00")), enc.GetString(enc.GetBytes("GE00"))));
                        var serializedPairObject = new FieldNameInputValuePairObject();
                        serializedPairObject.FieldNameInputValuePairList = pairList;
                        serializedPairObject.CustNo = rowVal6;
                        serializedObject.Add(serializedPairObject);
                    }
                }
            }
        }

        private static MatchedDJListObject MatchCompanyAndPerson(IList<DJListRow> personData, IList<DJListRow> entityData)
        {
            var PersonList = new List<DJListRow>();
            var EntityList = new List<DJListRow>();
            var allUnmatched = new List<string>();
            foreach (var personRow in personData)
            {
                var regNumberField = personRow.Row[0];
                if (!string.IsNullOrEmpty(regNumberField))
                {
                    var regNumberFieldEntity = entityData.FirstOrDefault(d => d.Row[0].Trim() == regNumberField.Trim());
                    PersonList.Add(personRow);
                    var test1 = regNumberFieldEntity;
                    var test = test1;
                    
                    if(test==null)
                    {
                        allUnmatched.Add(regNumberField);
                    }
                    EntityList.Add(regNumberFieldEntity);
                }
            }
            
            var matchedList = new MatchedDJListObject(PersonList, EntityList);
            return matchedList;
        }
        private static string ReturnNumberOfEmptySpaces(int i)
        {
            var ret = "";
            for(int j =0;j<i;j++)
            {
                ret += " ";
            }
            return ret;
        }
    }
}
