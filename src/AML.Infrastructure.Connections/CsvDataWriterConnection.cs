using AML.Infrastructure.Connections.Interfaces;
using FileHelpers;
using System.Collections.Generic;
using System.Text;

namespace AML.Infrastructure.Connections
{
    public class CsvDataWriterConnection<T> : IDataWriteConnection<T> where T : class
    {
        private readonly FileHelperEngine<T> engine;
        private string headerText;
        public CsvDataWriterConnection(string headerText)
        {
            engine = new FileHelperEngine<T>(Encoding.UTF8);
            this.headerText = headerText;
        }

        public virtual void WriteData(IList<T> values, string path, string delimiter)
        {
            //engine.HeaderText = headerText;
            engine.WriteFile(path, values);
        }
    }
}
