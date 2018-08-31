using FileHelpers;

namespace AML.infrastructure.Data.Dto
{
    [DelimitedRecord("|")]
    public class GERelationshipFieldQuotedDto
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string INSTITUTE;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string CUSTNO;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string REL_CUSTNO;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string REL_TYPE;
        public string REL_SHARE;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string REL_FLAG1;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string REL_FLAG2;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string REL_FLAG3;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string REL_COMMENT;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string PROCESSFLAG;
    }
}
