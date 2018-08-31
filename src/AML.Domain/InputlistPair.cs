using System.Collections.Generic;

namespace AML.Domain
{
    public class InputlistPair
    {
        public IList<FieldNameInputValuePairObject> OutputAndExtension { get; set; }
        public IList<FieldNameInputValuePairObject> RelationshipList { get; set; }
    }
}
