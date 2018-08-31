namespace AML.Infrastructure.Readers.Interfaces
{
    public interface IDataReader<P>
    {
        P GetData();
    }

    public interface IKeyParametricDataReader<P>
    {
        P GetData(string keyValue);
    }

    public interface IDataReaderWorksheetParametreic<P>
    {
        P GetData(string sourceFileEntry, string worksheetNameEntry,int custIndex);
    }
    public interface IDataReaderDoubleWorksheetParametreic<P>
    {
        P GetData(string sourceFileEntryA, string worksheetNameEntryA, int custIndexA,
            string sourceFileEntryB, string worksheetNameEntryB, int custIndexB);
    }


}
