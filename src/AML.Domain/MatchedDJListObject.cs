using System.Collections.Generic;

namespace AML.Domain
{
    public class MatchedDJListObject
    {
        public IList<DJListRow> PersonList { get; private set; }
        public IList<DJListRow> EntityList { get; private set; }
        public MatchedDJListObject(IList<DJListRow> person, IList<DJListRow> entity )
        {
            PersonList = person;
            EntityList = entity;
        }
        
    }
}
