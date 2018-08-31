using AML.Domain;
using AML.infrastructure.Data.Dto;
using AML.Infrastructure.Connections.Interfaces;
using AML.Infrastructure.Readers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AML.Infrastructure.Readers.GGE
{
    public class GGEReader : IDataReaderWorksheetParametreic<DJListPair>
    {
        private readonly IDataReadConnection<IList<StringArrayDto>> con;
        private readonly IDataReaderWorksheetParametreic<IList<DJListRow>> reader;
        public GGEReader(IDataReadConnection<IList<StringArrayDto>> con, IDataReaderWorksheetParametreic<IList<DJListRow>> reader)
        {
            this.con = con;
            this.reader = reader;
        }

        public DJListPair GetData(string sourceFileEntry, string worksheetNameEntry, int custIndex)
        {
            var csvData = PopulateDJListObjectWithListValues(custIndex);
            var tempStaffResults = reader.GetData(sourceFileEntry, worksheetNameEntry, custIndex);
            var pair = new DJListPair();
            pair.dJListRowsPerm = csvData;
            pair.dJListRowsTemp = tempStaffResults;
            return pair;
        }

        private List<DJListRow> PopulateDJListObjectWithListValues(int custIndex)
        {
            var result = con.LoadData();
            var djList = new List<DJListRow>();

            foreach (var row in result)
            {
                var rows = new List<string>();
                var colCount = row.Row.Count();
                var cnt = 0;
                while (cnt < colCount)
                {
                    var temp = row.Row[cnt].ToString();

                    rows.Add(temp);
                    cnt++;
                }
                var column = new DJListRow(rows, "", rows.Count());
                column.SpaceAndSlashRemoveFormatRowValueAtIndex(custIndex);
                djList.Add(column);
            }

            return djList;
        }
    }
}
