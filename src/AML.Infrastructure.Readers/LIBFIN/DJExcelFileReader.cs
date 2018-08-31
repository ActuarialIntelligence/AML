using AML.Domain;
using AML.Infrastructure.Readers.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace AML.Infrastructure.Readers
{
    public class DJExcelFileReader: IDataReader<IList<DJListRow>>,IDataReaderWorksheetParametreic<IList<DJListRow>>
    {
        string sourceFile;
        string worksheetName;
        public DJExcelFileReader(string sourceFile, string worksheetName)
        {
            this.sourceFile = sourceFile;
            this.worksheetName = worksheetName;
        }

        public DJExcelFileReader()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<DJListRow> GetData()
        {

                Console.WriteLine("Loading Excel Data DJExcelFileReader 1");
                
                var provider = ConfigurationManager.AppSettings["Provider"];
                var extendedProperties = @";Extended Properties=""Excel 12.0;CharacterSet=65001"";";//ConfigurationManager.AppSettings["Extended Properties"];
                string strConn = provider + "Data Source=" + sourceFile + extendedProperties; // The connection string should be populated via another domain object that makes use of config manager.

                var conn = new OleDbConnection(strConn);
                conn.Open();
                var cmd = new OleDbCommand("SELECT * FROM [" + worksheetName + "$]", conn);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();
                
                List<DJListRow> djList = PopulateDJListObjectWithListValues(reader, worksheetName, 0);
                conn.Close();
                
                return djList;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static List<DJListRow> PopulateDJListObjectWithListValues(OleDbDataReader reader,string worksheetName, int custIndex)
        {
            var colCount = reader.FieldCount;
            var djList = new List<DJListRow>();

            while (reader.Read())
            {
                var row = new List<string>();
                var cnt = 0;
                while (cnt < colCount)
                {
                    var temp = reader[cnt].ToString();
                    
                    row.Add(temp);
                    cnt++;
                }
                var column = new DJListRow(row, worksheetName, row.Count());
                column.SpaceAndSlashRemoveFormatRowValueAtIndex(custIndex);
                djList.Add(column);
            }

            return djList;
        }

        public IList<DJListRow> GetData(string sourceFileEntry, string worksheetNameEntry, int custIndex)
        {

                Console.WriteLine("Loading Excel Data DJExcelFileReader 2");
               
                var provider = ConfigurationManager.AppSettings["Provider"];
                var extendedProperties = ConfigurationManager.AppSettings["Extended Properties"];
                string strConn = provider + "Data Source=" + sourceFileEntry + extendedProperties; // The connection string should be populated via another domain object that makes use of config manager.

                var conn = new OleDbConnection(strConn);
                conn.Open();


                var tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var ct = tables.Rows.Count;


                var cmd = new OleDbCommand("SELECT * FROM [" + worksheetNameEntry + "$]", conn);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();
               
                List<DJListRow> djList = PopulateDJListObjectWithListValues(reader, worksheetNameEntry, custIndex);
                conn.Close();
                
                return djList;

        }
    }
}
