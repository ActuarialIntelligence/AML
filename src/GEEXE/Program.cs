using System.Configuration;
using AML.IOC;
using AML.Common;

namespace GEEXE
{
    class Program
    {

        static void Main(string[] args)
        {
            var readDirectory = ConfigurationManager.AppSettings["Directory"];
            var writeDirectory = ConfigurationManager.AppSettings["WriteDirectory"];
            var directory = ConfigurationManager.AppSettings["Directory"];
            var sourceFilePerson = FileMatch.GetFullFileName(readDirectory,ConfigurationManager.AppSettings["GESOURCEFILEPERSON"]);
            var worksheetNamePerson = ConfigurationManager.AppSettings["PersonWorkSheetName"];
            var sourceFileEntity = FileMatch.GetFullFileName(readDirectory, ConfigurationManager.AppSettings["GESOURCEFILEENTITY"]);
            var worksheetNameEntity = ConfigurationManager.AppSettings["EntityWorkSheetName"];
            var headings = ConfigurationManager.AppSettings["Headings"];
            DependencyResolution.ConstructContainer();
            var serializer = DependencyResolution.GetGESerializer(readDirectory+sourceFilePerson, worksheetNamePerson, readDirectory+sourceFileEntity, worksheetNameEntity);
            var serializedResult = serializer.Serialize();

            var personWorksheetName = ConfigurationManager.AppSettings["PersonWorksheetName"];

            var in_customer_ge = ConfigurationManager.AppSettings["in_customer_ge"];
            var in_customer_ge_ext = ConfigurationManager.AppSettings["in_customer_ge_ext"];
            var GERelationship = ConfigurationManager.AppSettings["GERelationship"];
            var UnUsed = ConfigurationManager.AppSettings["UnUsed"];

            var writer = DependencyResolution.GetFICOFileWriter(writeDirectory+in_customer_ge,
                    writeDirectory+in_customer_ge_ext, headings);
            writer.Write(serializedResult.OutputAndExtension,"");
            var relationWriter = DependencyResolution.GetGERelationshipWriter(writeDirectory+GERelationship,
                    UnUsed, "INSTITUTE|CUSTNO|REL_CUSTNO|REL_TYPE|REL_SHARE|REL_FLAG1|REL_FLAG2|REL_FLAG3|REL_COMMENT|PROCESSFLAG");
            relationWriter.Write(serializedResult.RelationshipList,"|");
        }
    }
}
