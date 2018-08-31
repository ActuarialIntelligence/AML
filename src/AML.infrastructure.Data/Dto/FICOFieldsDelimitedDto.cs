using FileHelpers;
namespace AML.infrastructure.Data.Dto
{
    [DelimitedRecord("|")]
    public class FICOFieldsDelimitedDto
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string INSTITUTE;[FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string CUSTNO;[FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string FIRST_NAME; [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string LASTNAME_COMPANYNAME; [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string STREET;[FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string ZIP;[FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string TOWN;[FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string CUST_TYPE;
    }
}
