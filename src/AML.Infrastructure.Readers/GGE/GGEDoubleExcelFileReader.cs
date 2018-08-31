using AML.Domain;
using AML.Infrastructure.Readers.Interfaces;
using System.Collections.Generic;

namespace AML.Infrastructure.Readers.GGE
{
    public class GGEDoubleExcelFileReader : IDataReaderDoubleWorksheetParametreic<DJListPair>
    {
        private readonly IDataReaderWorksheetParametreic<IList<DJListRow>> readerA;
        private readonly IDataReaderWorksheetParametreic<IList<DJListRow>> readerB;
        public GGEDoubleExcelFileReader(IDataReaderWorksheetParametreic<IList<DJListRow>> readerA, IDataReaderWorksheetParametreic<IList<DJListRow>> readerB)
        {
            this.readerA = readerA;
            this.readerB = readerB;
        }

        public DJListPair GetData(string sourceFileEntryA, string worksheetNameEntryA, int custIndexA,
            string sourceFileEntryB, string worksheetNameEntryB, int custIndexB)
        {
            var permStaffResults = readerA.GetData(sourceFileEntryA, worksheetNameEntryA, custIndexA);
            var tempStaffResults = readerB.GetData(sourceFileEntryB, worksheetNameEntryB, custIndexB);
            var pair = new DJListPair();
            pair.dJListRowsPerm = permStaffResults;
            pair.dJListRowsTemp = tempStaffResults;
            return pair;
        }
    }
}
