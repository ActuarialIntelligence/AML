using FileHelpers;

namespace AML.infrastructure.Data.Dto
{
    [DelimitedRecord(",")]
    [IgnoreFirst]
    public class StringArrayDto
    {
        public string[] Row;
    }
}
