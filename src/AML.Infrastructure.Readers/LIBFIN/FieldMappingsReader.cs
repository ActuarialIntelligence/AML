using AML.Infrastructure.Readers.Interfaces;
using System.Configuration;

namespace AML.Infrastructure.Readers
{
    public class FieldMappingsReader : IKeyParametricDataReader<string>
    {
        public FieldMappingsReader()
        {

        }

        public string GetData(string keyValue)
        {
            var temp = ConfigurationManager.AppSettings[keyValue] == null ? ""
                : ConfigurationManager.AppSettings[keyValue].ToString();
            return temp;
        }
    }
}
