using AML.Common;
using AML.Domain;
using AML.IOC;
using System;
using System.Configuration;
using System.IO;

namespace GGEEXE
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sr = new StreamWriter(ConfigurationManager.AppSettings["logFileLocation"], append: true);
            //try
            //{
                var readDirectory = ConfigurationManager.AppSettings["Directory"];
                sr.WriteLine("Completed reading all config values." + readDirectory);
                var writeDirectory = ConfigurationManager.AppSettings["WriteDirectory"];
                sr.WriteLine("Completed reading all config values." + writeDirectory);
                var sourceTemp = FileMatch.GetFullFileName(readDirectory, ConfigurationManager.AppSettings["GGETEMP"]);
                sr.WriteLine("Completed reading all config values." + sourceTemp);
                var sourceTempworksheetName = ConfigurationManager.AppSettings["TempSheetName"];
                sr.WriteLine("Completed reading all config values." + sourceTempworksheetName);
                var sourcePerm = FileMatch.GetFullFileName(readDirectory, ConfigurationManager.AppSettings["GGEPERM"]);
                sr.WriteLine("Completed reading all config values." + sourcePerm);
                var sourcePermworksheetName = ConfigurationManager.AppSettings["PermSheetName"];
                sr.WriteLine("Completed reading all config values." + sourcePermworksheetName);
                InputlistPair serializedResult = new InputlistPair();
                Console.WriteLine("Completed reading all config values." + DateTime.Now);

                sr.WriteLine("Completed reading all config values.");
                if (args[0] == "0")
                {
                    Console.WriteLine("Text file version.");
                    sr.WriteLine("Text file version." + DateTime.Now);
                    var ggeSerializer = DependencyResolution.GetGGESerializer(readDirectory + sourcePerm, readDirectory + sourceTemp, sourceTempworksheetName);
                    serializedResult = ggeSerializer.Serialize();
                }
                else
                {
                    Console.WriteLine("Excel Version.");
                    sr.WriteLine("Excel Version." + DateTime.Now);
                    var ggeSerializer = DependencyResolution.GetGGESerializer(readDirectory + sourcePerm, sourcePermworksheetName, readDirectory + sourceTemp, sourceTempworksheetName);
                    serializedResult = ggeSerializer.Serialize();
                }

                var GGE_Customer = ConfigurationManager.AppSettings["GGE_Customer"];
                var GGE_ext = ConfigurationManager.AppSettings["GGE_ext"];

                var writer = DependencyResolution.GetFICOFileWriter(writeDirectory + GGE_Customer,
                        writeDirectory + GGE_ext, "");
                writer.Write(serializedResult.OutputAndExtension, "");
                sr.Close();
            //}
            //catch(Exception e)
            //{
            //    sr.WriteLine("Failed for reason: " + DateTime.Now + e );
            //    sr.Close();
            //}
        }
    }
}
