using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Infrastructure.Connections.Interfaces
{
    public interface IDataReadConnection<T>
    {
        T LoadData();
    }

    public interface IDataWriteConnection<T>
    {
        void WriteData(IList<T> values,string path, string delimiter);
    }
}
