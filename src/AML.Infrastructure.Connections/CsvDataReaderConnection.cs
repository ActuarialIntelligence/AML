using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AML.Infrastructure.Connections.Interfaces;
using System.Configuration;

namespace AML.Infrastructure.Connections
{
    public class CsvDataReaderConnection<T> : IDataReadConnection<IList<T>> where T : class
    {
        private readonly FileHelperEngine<T> engine;
        private string path;
        public CsvDataReaderConnection(string path)
        {
            engine = new FileHelperEngine<T>(Encoding.UTF8);
            this.path = path;
        }



        public virtual IList<T> LoadData()
        {
            StreamWriter sr = new StreamWriter(ConfigurationManager.AppSettings["logFileLocation"], append: true);
            try
            {
                Console.WriteLine("LoadingData CsvDataReaderConnection");
                using (var fileStream = new FileStream(path
                    , FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var streamReader = new StreamReader(fileStream))
                {
                    return engine.ReadStream(streamReader).ToList();
                }
                sr.Close();
            }
            catch(Exception e)
            {
                sr.WriteLine("Failed for reason Connection: " + DateTime.Now + e);
                sr.Close();
                return null;
            }
        }

    }
}
