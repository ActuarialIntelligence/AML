using System.Collections.Generic;

namespace AML.Domain
{
    public class DJListPair
    {
        public IList<DJListRow> dJListRowsTemp { get; set; }
        public IList<DJListRow> dJListRowsPerm { get; set; }
    }
}
