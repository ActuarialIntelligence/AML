using FileHelpers;

namespace AML.infrastructure.Data.Dto
{

    [FixedLengthRecord(FixedMode.ExactLength)]
    public class FICOFieldsWriteDto
    {
        [FieldFixedLength(4)]
        public string INSTITUTE;
        [FieldFixedLength(16)]
        public string CUSTNO;
        [FieldFixedLength(32)]
        public string FIRST_NAME;
        [FieldFixedLength(32)]
        public string LASTNAME_COMPANYNAME;
        [FieldFixedLength(32)]
        public string STREET;
        [FieldFixedLength(7)]
        public string ZIP;
        [FieldFixedLength(28)]
        public string TOWN;
        [FieldFixedLength(3)]
        public string H_COUNTRY;
        [FieldFixedLength(3)]
        public string S_COUNTRY;
        [FieldFixedLength(8)]
        public string CUSY;
        [FieldFixedLength(12)]
        public string FK_CSMNO;
        [FieldFixedLength(32)]
        public string PROFESSION;
        [FieldFixedLength(32)]
        public string BRANCH;
        [FieldFixedLength(8)]
        public string BIRTHDATE;
        [FieldFixedLength(8)]
        public string CUSTCONTACT;
        [FieldFixedLength(1)]
        public string EXEMPTIONFLAG;
        [FieldFixedLength(11)]
        public string EXEMPTIONAMOUNT;
        [FieldFixedLength(1)]
        public string ASYLSYN;
        [FieldFixedLength(17)]
        public string SALARY;
        [FieldFixedLength(8)]
        public string SALARYDATE;
        [FieldFixedLength(3)]
        public string NAT_COUNTRY;
        [FieldFixedLength(17)]
        public string TOT_WEALTH;
        [FieldFixedLength(3)]
        public string PROP_WEALTH;//______________________________________________________________
        [FieldFixedLength(10)]
        public string BRANCH_OFFICE;//______________________________________________________________
        [FieldFixedLength(1)]
        public string CUST_TYPE;
        [FieldFixedLength(1)]
        public string CUST_FLAG_01;
        [FieldFixedLength(1)]
        public string CUST_FLAG_02;
        [FieldFixedLength(1)]
        public string CUST_FLAG_03;
        [FieldFixedLength(1)]
        public string CUST_FLAG_04;
        [FieldFixedLength(1)]
        public string CUST_FLAG_05;
        [FieldFixedLength(1)]
        public string CUST_FLAG_06;
        [FieldFixedLength(1)]
        public string CUST_FLAG_07;
        [FieldFixedLength(1)]
        public string CUST_FLAG_08;
        [FieldFixedLength(1)]
        public string CUST_FLAG_09;
        [FieldFixedLength(1)]
        public string CUST_FLAG_10;
        [FieldFixedLength(1)]
        public string CUST_FLAG_11;
        [FieldFixedLength(1)]
        public string CUST_FLAG_12;
        [FieldFixedLength(1)]
        public string CUST_FLAG_13;
        [FieldFixedLength(1)]
        public string CUST_FLAG_14;
        [FieldFixedLength(1)]
        public string CUST_FLAG_15;
        [FieldFixedLength(1)]
        public string CUST_FLAG_16;
        [FieldFixedLength(1)]
        public string CUST_FLAG_17;
        [FieldFixedLength(1)]
        public string CUST_FLAG_18;
        [FieldFixedLength(1)]
        public string CUST_FLAG_19;
        [FieldFixedLength(1)]
        public string CUST_FLAG_20;
        [FieldFixedLength(1)]
        public string CUST_FLAG_21;
        [FieldFixedLength(1)]
        public string CUST_FLAG_22;
        [FieldFixedLength(1)]
        public string CUST_FLAG_23;
        [FieldFixedLength(1)]
        public string CUST_FLAG_24;
        [FieldFixedLength(16)]
        public string EMPLNO;//______________________________________________________________
        [FieldFixedLength(17)]
        public string PASS_NO;
        [FieldFixedLength(3)]
        public string BIRTH_COUNTRY;
        [FieldFixedLength(32)]
        public string BIRTH_PLACE;
        [FieldFixedLength(1)]
        public string BORROWEYN;
        [FieldFixedLength(1)]
        public string DIRECT_DEBITYN;
        [FieldFixedLength(1)]
        public string GENDER;
        [FieldFixedLength(10)]
        public string RISK_CLASS;
    }
}
