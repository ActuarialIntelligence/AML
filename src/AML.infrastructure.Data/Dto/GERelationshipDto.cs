using FileHelpers;

namespace AML.infrastructure.Data.Dto
{
    [DelimitedRecord("|")]
    [IgnoreEmptyLines()]
    public class GERelationshipDto
    {
        public string INSTITUTE { get; set; }
        public string CUSTNO { get; set; }
        public string REL_CUSTNO { get; set; }
        public string REL_TYPE { get; set; }
        public string REL_SHARE { get; set; }
        public string REL_FLAG1 { get; set; }
        public string REL_FLAG2 { get; set; }
        public string REL_FLAG3 { get; set; }
        public string REL_COMMENT { get; set; }
        public string PROCESSFLAG { get; set; }
    }

}
