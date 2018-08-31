namespace AML.Infrastructure.Writers.Interfaces
{
    public interface IDataWrite<P>
    {
        void Write(P values, string delimiter);
    }
}
