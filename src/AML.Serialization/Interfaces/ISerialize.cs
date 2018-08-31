using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Serialization.Interfaces
{
    public interface IPairSerialize<U, P>
    {
        P Serialize(U inputObject1, U inputObject2);
    }
    public interface ISerialize<U,P>
    {
        P Serialize(U inputObject);
    }
    public interface ISerialize<P>
    {
        P Serialize();
    }
}
