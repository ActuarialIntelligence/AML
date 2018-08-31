using System.Configuration;
using AML.IOC;
using AML.Common;

namespace ConvertExcelToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            var readDirectory = ConfigurationManager.AppSettings["Directory"];
            var writeDirectory = ConfigurationManager.AppSettings["WriteDirectory"];

            var personSourceFile = FileMatch.GetFullFileName(readDirectory, ConfigurationManager.AppSettings["GESOURCEFILEPERSON"]);
            var personWorksheetName = ConfigurationManager.AppSettings["PersonWorksheetName"];

            var entitySourceFile = FileMatch.GetFullFileName(readDirectory, ConfigurationManager.AppSettings["GESOURCEFILEENTITY"]);
            var entityWorksheetName = ConfigurationManager.AppSettings["EntityWorksheetName"];

            var headings = ConfigurationManager.AppSettings["Headings"];
            DependencyResolution.ConstructContainer();
            var reader =  DependencyResolution.GetGEFileReader();

            var personResult = reader.GetData(readDirectory+personSourceFile, personWorksheetName,4);
            var entityResult = reader.GetData(readDirectory+entitySourceFile, entityWorksheetName,2);


            var serializer = DependencyResolution.GetFICOSerializer();
            var serializedResult = serializer.Serialize(personResult, entityResult);

            var LibFin_Customer = ConfigurationManager.AppSettings["LibFin_Customer"];
            var LibFin_Ext = ConfigurationManager.AppSettings["LibFin_Ext"];
            var LibFinRelationship = ConfigurationManager.AppSettings["LibFinRelationship"];
            var UnUsed = ConfigurationManager.AppSettings["UnUsed"];


            var writer = DependencyResolution.GetFICOFileWriter(writeDirectory+LibFin_Customer,
                writeDirectory+LibFin_Ext, headings);
            writer.Write(serializedResult.OutputAndExtension,"");

            var relationWriter = DependencyResolution.GetGERelationshipWriter(writeDirectory+LibFinRelationship,
                    UnUsed, "INSTITUTE|CUSTNO|REL_CUSTNO|REL_TYPE|REL_SHARE|REL_FLAG1|REL_FLAG2|REL_FLAG3|REL_COMMENT|PROCESSFLAG");
            relationWriter.Write(serializedResult.RelationshipList, "|");
        }
    }
}
