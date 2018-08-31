using System.Collections.Generic;

namespace AML.Domain
{
    public class FieldNameInputValuePairObject
    {
        public string CustNo { get; set; }
        public IList<FieldNameInputValuePair> FieldNameInputValuePairList { get; set; }
    }
}
