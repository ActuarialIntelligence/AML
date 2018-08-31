using AML.Domain;
using AML.Serialization.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AML.Serialization
{
    public class LibFinFICOFileSerializer : IPairSerialize<IList<DJListRow>, InputlistPair>
    {
        private static List<string> personKeys;
        private static List<string> entityKeys;
        private static List<string> relationshipKeys;
        public InputlistPair Serialize(IList<DJListRow> personList, IList<DJListRow> entityList)
        {
            var serializedObject = new List<FieldNameInputValuePairObject>();
            Encoding enc = new UTF8Encoding(true, true);
            personKeys = new List<string>();
            entityKeys = new List<string>();
            relationshipKeys = new List<string>();
            SerializePerson(personList, serializedObject);
            SerializeEntity(entityList, serializedObject);
            List<FieldNameInputValuePairObject> pairingObjects = CreateRelationshipList(personList, entityList);

            var serializedOutput = new InputlistPair();
            serializedOutput.OutputAndExtension = serializedObject.OrderBy(s=> enc.GetString(enc.GetBytes(s.CustNo))).ToList();
            serializedOutput.RelationshipList = pairingObjects.OrderBy(s => enc.GetString(enc.GetBytes(s.CustNo))).ToList();
            return serializedOutput;
        }

        private static List<FieldNameInputValuePairObject> CreateRelationshipList(IList<DJListRow> personList, IList<DJListRow> entityList)
        {
            var pairingObjects = new List<FieldNameInputValuePairObject>();
            Encoding enc = new UTF8Encoding(true, true);
            foreach (var person in personList)
            {
                var matchCIF = entityList.FirstOrDefault(f => f.Row[1] == person.Row[1]) == null ? "" :
                            entityList.FirstOrDefault(f => f.Row[1] == person.Row[1]).Row[2];
               
                if (!relationshipKeys.Contains(person.Row[4].Trim()) 
                    && personKeys.Contains(person.Row[4].Trim())
                    && entityKeys.Contains(matchCIF.Trim()))
                {
                        relationshipKeys.Add(person.Row[4].Trim());
                        
                        var pairList = new List<FieldNameInputValuePair>();

                        var pair0 = new FieldNameInputValuePair("INSTITUTE", "LBFN", "");
                        var pair1 = new FieldNameInputValuePair("CUSTNO", person.Row[4], "");
                        var pair2 = new FieldNameInputValuePair("REL_CUSTNO", "" + matchCIF, "");
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
                        serializedPairObject.CustNo = enc.GetString(enc.GetBytes(person.Row[4].ToUpper()));
                        pairingObjects.Add(serializedPairObject);
                    
                }
            }

            return pairingObjects.OrderBy(s=>s.CustNo).ToList();
        }

        private static void SerializeEntity(IList<DJListRow> EntityList, List<FieldNameInputValuePairObject> serializedObject)
        {
            Encoding enc = new UTF8Encoding(true, true);
            foreach (var value in EntityList)
            {
                if (value.Row[2].Any(char.IsDigit))
                {
                    if (!entityKeys.Contains(value.Row[2].Trim()) && value.Row[0] != "N/A" && !string.IsNullOrEmpty(value.Row[0]))
                    {
                        entityKeys.Add(value.Row[2].Trim());
                        var pairList = new List<FieldNameInputValuePair>();
                        var columnCount = value.ColumnCount;
                        var sheetName = value.ExcelSheetName;

                        var rowVal0 = value.Row[0].Count() > 32 ? value.Row[0].Substring(0, 32) : value.Row[0];
                        var rowVal2 = value.Row[2].Count() > 16 ? value.Row[2].Substring(0, 16) : value.Row[2];

                        var rowValExt0 = value.Row[0].Count() > 32 ? value.Row[0].Substring(32, value.Row[0].Count() - 32) : "";
                        var rowValExt2 = value.Row[2].Count() > 16 ? value.Row[2].Substring(16, value.Row[2].Count() - 16) : "";



                        var pair1 = new FieldNameInputValuePair("LASTNAME_COMPANYNAME", enc.GetString(enc.GetBytes(rowVal0)), enc.GetString(enc.GetBytes(rowValExt0)));
                        var pair2 = new FieldNameInputValuePair("FIRST_NAME", enc.GetString(enc.GetBytes("")), enc.GetString(enc.GetBytes("")));
                        var pair3 = new FieldNameInputValuePair("CUSTNO", rowVal2, rowVal2);
                        pairList.Add(pair1);
                        pairList.Add(pair2);
                        pairList.Add(pair3);

                        pairList.Add(new FieldNameInputValuePair("INSTITUTE", enc.GetString(enc.GetBytes("LBFN")), enc.GetString(enc.GetBytes("LBFN"))));
                        var serializedPairObject = new FieldNameInputValuePairObject();
                        serializedPairObject.FieldNameInputValuePairList = pairList;
                        serializedPairObject.CustNo = enc.GetString(enc.GetBytes(rowVal2.ToUpper()));
                        serializedObject.Add(serializedPairObject);
                    }
                }
            }
        }

        private static void SerializePerson(IList<DJListRow> PersonList, List<FieldNameInputValuePairObject> serializedObject)
        {
            Encoding enc = new UTF8Encoding(true, true);
            foreach (var value in PersonList)
            {
                if (value.Row[4].Any(char.IsDigit))
                {
                    if (!personKeys.Contains(value.Row[4].Trim()) && value.Row[2] != "N/A" && !string.IsNullOrEmpty(value.Row[2]))
                    {
                        personKeys.Add(value.Row[4].Trim());
                        var pairList = new List<FieldNameInputValuePair>();
                        var columnCount = value.ColumnCount;
                        var sheetName = value.ExcelSheetName;
                        var rowVal4 = value.Row[4].Count() > 16 ? value.Row[4].Substring(0, 16) : value.Row[4];
                        var rowVal1 = value.Row[1].Count() > 32 ? value.Row[1].Substring(0, 32) : value.Row[1];
                        var rowVal2 = value.Row[2].Count() > 32 ? value.Row[2].Substring(0, 32) : value.Row[2];
                        var rowVal3 = value.Row[3].Count() > 32 ? value.Row[3].Substring(0, 32) : value.Row[3];

                        var rowValExt4 = value.Row[4].Count() > 16 ? value.Row[4].Substring(16, value.Row[4].Count() - 16) : "";
                        var rowValExt1 = value.Row[1].Count() > 32 ? value.Row[1].Substring(32, value.Row[1].Count() - 32) : "";
                        var rowValExt2 = value.Row[2].Count() > 32 ? value.Row[2].Substring(32, value.Row[2].Count() - 32) : "";
                        var rowValExt3 = value.Row[3].Count() > 32 ? value.Row[3].Substring(32, value.Row[3].Count() - 32) : "";

                        var pair1 = new FieldNameInputValuePair("LASTNAME_COMPANYNAME", enc.GetString(enc.GetBytes(rowVal2)), enc.GetString(enc.GetBytes(rowValExt2)));
                        var pair2 = new FieldNameInputValuePair("FIRST_NAME", enc.GetString(enc.GetBytes(rowVal3)), enc.GetString(enc.GetBytes(rowValExt3)));
                        var pair3 = new FieldNameInputValuePair("CUSTNO", rowVal4, rowVal4);
                        pairList.Add(pair1);
                        pairList.Add(pair2);
                        pairList.Add(pair3);

                        pairList.Add(new FieldNameInputValuePair("INSTITUTE", enc.GetString(enc.GetBytes("LBFN")), enc.GetString(enc.GetBytes("LBFN"))));
                        var serializedPairObject = new FieldNameInputValuePairObject();
                        serializedPairObject.FieldNameInputValuePairList = pairList;
                        serializedPairObject.CustNo = enc.GetString(enc.GetBytes(rowVal4.ToUpper()));
                        serializedObject.Add(serializedPairObject);
                    }
                }
            }
        }

        private static string ReturnNumberOfEmptySpaces(int i)
        {
            var ret = "";
            for (int j = 0; j < i; j++)
            {
                ret += " ";
            }
            return ret;
        }
    }
}
