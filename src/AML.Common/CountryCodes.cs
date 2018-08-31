using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AML.Common
{
    public static class CountryCodes
    {
        public static string GetCountryCode(string country)
        {
            var countries = GetCountryPairs();
            var tmp = country.Trim().ToUpper();
            var code = "";
            foreach(var cntry in countries)
            {
                if(Regex.IsMatch(country,cntry.Name))
                {
                    code = cntry.Code;
                    break;
                }
            }
            return code;
        }
        private static List<CountryPair> GetCountryPairs()
        {
            var dictionary = new List<CountryPair>();
            dictionary.Add(new CountryPair("0", "UNKNOWN"));
            dictionary.Add(new CountryPair("AD", "ANDORRA"));
            dictionary.Add(new CountryPair("AE", "UNITED ARAB EMIRATES"));
            dictionary.Add(new CountryPair("AF", "AFGHANISTAN"));
            dictionary.Add(new CountryPair("AG", "ANTIGUA AND BARBUDA"));
            dictionary.Add(new CountryPair("AI", "ANGUILLA"));
            dictionary.Add(new CountryPair("AL", "ALBANIA"));
            dictionary.Add(new CountryPair("AM", "ARMENIA"));
            dictionary.Add(new CountryPair("AN", "NETHERLANDS ANTILLES"));
            dictionary.Add(new CountryPair("AO", "ANGOLA"));
            dictionary.Add(new CountryPair("AQ", "ANTARCTICA"));
            dictionary.Add(new CountryPair("AR", "ARGENTINA"));
            dictionary.Add(new CountryPair("AS", "AMERICAN SAMOA"));
            dictionary.Add(new CountryPair("AT", "AUSTRIA"));
            dictionary.Add(new CountryPair("AU", "AUSTRALIA"));
            dictionary.Add(new CountryPair("AW", "ARUBA"));
            dictionary.Add(new CountryPair("AX", "ELAND ISLANDS"));
            dictionary.Add(new CountryPair("AZ", "AZERBAIJAN"));
            dictionary.Add(new CountryPair("BA", "BOSNIA AND HERZEGOVINA"));
            dictionary.Add(new CountryPair("BB", "BARBADOS"));
            dictionary.Add(new CountryPair("BD", "BANGLADESH"));
            dictionary.Add(new CountryPair("BE", "BELGIUM"));
            dictionary.Add(new CountryPair("BF", "BURKINA FASO"));
            dictionary.Add(new CountryPair("BG", "BULGARIA"));
            dictionary.Add(new CountryPair("BH", "BAHRAIN"));
            dictionary.Add(new CountryPair("BI", "BURUNDI"));
            dictionary.Add(new CountryPair("BJ", "BENIN"));
            dictionary.Add(new CountryPair("BM", "BERMUDA"));
            dictionary.Add(new CountryPair("BN", "BRUNEI DARUSSALAM"));
            dictionary.Add(new CountryPair("BO", "BOLIVIA"));
            dictionary.Add(new CountryPair("BR", "BRAZIL"));
            dictionary.Add(new CountryPair("BS", "BAHAMAS"));
            dictionary.Add(new CountryPair("BT", "BHUTAN"));
            dictionary.Add(new CountryPair("BV", "BOUVET ISLAND"));
            dictionary.Add(new CountryPair("BW", "BOTSWANA"));
            dictionary.Add(new CountryPair("BY", "BELARUS"));
            dictionary.Add(new CountryPair("BZ", "BELIZE"));
            dictionary.Add(new CountryPair("CA", "CANADA"));
            dictionary.Add(new CountryPair("CC", "COCOS (KEELING) ISLANDS"));
            dictionary.Add(new CountryPair("CD", "CONGO, THE DEMOCRATIC REPUBLIC OF THE"));
            dictionary.Add(new CountryPair("CF", "CENTRAL AFRICAN REPUBLIC"));
            dictionary.Add(new CountryPair("CG", "CONGO"));
            dictionary.Add(new CountryPair("CH", "SWITZERLAND"));
            dictionary.Add(new CountryPair("CI", "CTTE D'IVOIRE"));
            dictionary.Add(new CountryPair("CK", "COOK ISLANDS"));
            dictionary.Add(new CountryPair("CL", "CHILE"));
            dictionary.Add(new CountryPair("CM", "CAMEROON"));
            dictionary.Add(new CountryPair("CN", "CHINA"));
            dictionary.Add(new CountryPair("CO", "COLOMBIA"));
            dictionary.Add(new CountryPair("CR", "COSTA RICA"));
            dictionary.Add(new CountryPair("CS", "SERBIA AND MONTENEGRO"));
            dictionary.Add(new CountryPair("CU", "CUBA"));
            dictionary.Add(new CountryPair("CV", "CAPE VERDE"));
            dictionary.Add(new CountryPair("CX", "CHRISTMAS ISLAND"));
            dictionary.Add(new CountryPair("CY", "CYPRUS"));
            dictionary.Add(new CountryPair("CZ", "CZECH REPUBLIC"));
            dictionary.Add(new CountryPair("DE", "GERMANY"));
            dictionary.Add(new CountryPair("DJ", "DJIBOUTI"));
            dictionary.Add(new CountryPair("DK", "DENMARK"));
            dictionary.Add(new CountryPair("DM", "DOMINICA"));
            dictionary.Add(new CountryPair("DO", "DOMINICAN REPUBLIC"));
            dictionary.Add(new CountryPair("DZ", "ALGERIA"));
            dictionary.Add(new CountryPair("EC", "ECUADOR"));
            dictionary.Add(new CountryPair("EE", "ESTONIA"));
            dictionary.Add(new CountryPair("EG", "EGYPT"));
            dictionary.Add(new CountryPair("JM", "JAMAICA"));
            dictionary.Add(new CountryPair("JO", "JORDAN"));
            dictionary.Add(new CountryPair("JP", "JAPAN"));
            dictionary.Add(new CountryPair("KE", "KENYA"));
            dictionary.Add(new CountryPair("KG", "KYRGYZSTAN"));
            dictionary.Add(new CountryPair("KH", "CAMBODIA"));
            dictionary.Add(new CountryPair("KI", "KIRIBATI"));
            dictionary.Add(new CountryPair("KM", "COMOROS"));
            dictionary.Add(new CountryPair("KN", "SAINT KITTS AND NEVIS"));
            dictionary.Add(new CountryPair("KP", "KOREA, DEMOCRATIC PEOPLE'S REPUBLIC OF"));
            dictionary.Add(new CountryPair("KR", "KOREA, REPUBLIC OF"));
            dictionary.Add(new CountryPair("KW", "KUWAIT"));
            dictionary.Add(new CountryPair("KY", "CAYMAN ISLANDS"));
            dictionary.Add(new CountryPair("KZ", "KAZAKHSTAN"));
            dictionary.Add(new CountryPair("LA", "LAO PEOPLE'S DEMOCRATIC REPUBLIC"));
            dictionary.Add(new CountryPair("LB", "LEBANON"));
            dictionary.Add(new CountryPair("LC", "SAINT LUCIA"));
            dictionary.Add(new CountryPair("LI", "LIECHTENSTEIN"));
            dictionary.Add(new CountryPair("LK", "SRI LANKA"));
            dictionary.Add(new CountryPair("LR", "LIBERIA"));
            dictionary.Add(new CountryPair("LS", "LESOTHO"));
            dictionary.Add(new CountryPair("LT", "LITHUANIA"));
            dictionary.Add(new CountryPair("LU", "LUXEMBOURG"));
            dictionary.Add(new CountryPair("LV", "LATVIA"));
            dictionary.Add(new CountryPair("LY", "LIBYAN ARAB JAMAHIRIYA"));
            dictionary.Add(new CountryPair("MA", "MOROCCO"));
            dictionary.Add(new CountryPair("MC", "MONACO"));
            dictionary.Add(new CountryPair("MD", "MOLDOVA, REPUBLIC OF"));
            dictionary.Add(new CountryPair("MG", "MADAGASCAR"));
            dictionary.Add(new CountryPair("MH", "MARSHALL ISLANDS"));
            dictionary.Add(new CountryPair("MK", "MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF"));
            dictionary.Add(new CountryPair("ML", "MALI"));
            dictionary.Add(new CountryPair("MM", "MYANMAR"));
            dictionary.Add(new CountryPair("MN", "MONGOLIA"));
            dictionary.Add(new CountryPair("MO", "MACAO"));
            dictionary.Add(new CountryPair("MP", "NORTHERN MARIANA ISLANDS"));
            dictionary.Add(new CountryPair("MQ", "MARTINIQUE"));
            dictionary.Add(new CountryPair("MR", "MAURITANIA"));
            dictionary.Add(new CountryPair("MS", "MONTSERRAT"));
            dictionary.Add(new CountryPair("MT", "MALTA"));
            dictionary.Add(new CountryPair("MU", "MAURITIUS"));
            dictionary.Add(new CountryPair("MV", "MALDIVES"));
            dictionary.Add(new CountryPair("MW", "MALAWI"));
            dictionary.Add(new CountryPair("MX", "MEXICO"));
            dictionary.Add(new CountryPair("MY", "MALAYSIA"));
            dictionary.Add(new CountryPair("MZ", "MOZAMBIQUE"));
            dictionary.Add(new CountryPair("EH", "WESTERN SAHARA"));
            dictionary.Add(new CountryPair("ER", "ERITREA"));
            dictionary.Add(new CountryPair("ES", "SPAIN"));
            dictionary.Add(new CountryPair("ET", "ETHIOPIA"));
            dictionary.Add(new CountryPair("FI", "FINLAND"));
            dictionary.Add(new CountryPair("FJ", "FIJI"));
            dictionary.Add(new CountryPair("FK", "FALKLAND ISLANDS (MALVINAS)"));
            dictionary.Add(new CountryPair("FM", "MICRONESIA, FEDERATED STATES OF"));
            dictionary.Add(new CountryPair("FO", "FAROE ISLANDS"));
            dictionary.Add(new CountryPair("FR", "FRANCE"));
            dictionary.Add(new CountryPair("GA", "GABON"));
            dictionary.Add(new CountryPair("GB", "UNITED KINGDOM"));
            dictionary.Add(new CountryPair("GD", "GRENADA"));
            dictionary.Add(new CountryPair("GE", "GEORGIA"));
            dictionary.Add(new CountryPair("GF", "FRENCH GUIANA"));
            dictionary.Add(new CountryPair("GH", "GHANA"));
            dictionary.Add(new CountryPair("GI", "GIBRALTAR"));
            dictionary.Add(new CountryPair("GL", "GREENLAND"));
            dictionary.Add(new CountryPair("GM", "GAMBIA"));
            dictionary.Add(new CountryPair("GN", "GUINEA"));
            dictionary.Add(new CountryPair("GP", "GUADELOUPE"));
            dictionary.Add(new CountryPair("GQ", "EQUATORIAL GUINEA"));
            dictionary.Add(new CountryPair("GR", "GREECE"));
            dictionary.Add(new CountryPair("GS", "SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS"));
            dictionary.Add(new CountryPair("GT", "GUATEMALA"));
            dictionary.Add(new CountryPair("GU", "GUAM"));
            dictionary.Add(new CountryPair("GW", "GUINEA-BISSAU"));
            dictionary.Add(new CountryPair("GY", "GUYANA"));
            dictionary.Add(new CountryPair("HK", "HONG KONG"));
            dictionary.Add(new CountryPair("HM", "HEARD ISLAND AND MCDONALD ISLANDS"));
            dictionary.Add(new CountryPair("HN", "HONDURAS"));
            dictionary.Add(new CountryPair("HR", "CROATIA"));
            dictionary.Add(new CountryPair("HT", "HAITI"));
            dictionary.Add(new CountryPair("HU", "HUNGARY"));
            dictionary.Add(new CountryPair("ID", "INDONESIA"));
            dictionary.Add(new CountryPair("IE", "IRELAND"));
            dictionary.Add(new CountryPair("IL", "ISRAEL"));
            dictionary.Add(new CountryPair("IN", "INDIA"));
            dictionary.Add(new CountryPair("IO", "BRITISH INDIAN OCEAN TERRITORY"));
            dictionary.Add(new CountryPair("IQ", "IRAQ"));
            dictionary.Add(new CountryPair("IR", "IRAN, ISLAMIC REPUBLIC OF"));
            dictionary.Add(new CountryPair("IS", "ICELAND"));
            dictionary.Add(new CountryPair("IT", "ITALY"));
            dictionary.Add(new CountryPair("NE", "NIGER"));
            dictionary.Add(new CountryPair("NF", "NORFOLK ISLAND"));
            dictionary.Add(new CountryPair("NG", "NIGERIA"));
            dictionary.Add(new CountryPair("NI", "NICARAGUA"));
            dictionary.Add(new CountryPair("NL", "NETHERLANDS"));
            dictionary.Add(new CountryPair("NO", "NORWAY"));
            dictionary.Add(new CountryPair("NP", "NEPAL"));
            dictionary.Add(new CountryPair("NR", "NAURU"));
            dictionary.Add(new CountryPair("NU", "NIUE"));
            dictionary.Add(new CountryPair("NZ", "NEW ZEALAND"));
            dictionary.Add(new CountryPair("OM", "OMAN"));
            dictionary.Add(new CountryPair("PA", "PANAMA"));
            dictionary.Add(new CountryPair("PE", "PERU"));
            dictionary.Add(new CountryPair("PF", "FRENCH POLYNESIA"));
            dictionary.Add(new CountryPair("PG", "PAPUA NEW GUINEA"));
            dictionary.Add(new CountryPair("PH", "PHILIPPINES"));
            dictionary.Add(new CountryPair("PK", "PAKISTAN"));
            dictionary.Add(new CountryPair("PL", "POLAND"));
            dictionary.Add(new CountryPair("PM", "SAINT PIERRE AND MIQUELON"));
            dictionary.Add(new CountryPair("PN", "PITCAIRN"));
            dictionary.Add(new CountryPair("PR", "PUERTO RICO"));
            dictionary.Add(new CountryPair("PS", "PALESTINIAN TERRITORY, OCCUPIED"));
            dictionary.Add(new CountryPair("PT", "PORTUGAL"));
            dictionary.Add(new CountryPair("PW", "PALAU"));
            dictionary.Add(new CountryPair("PY", "PARAGUAY"));
            dictionary.Add(new CountryPair("QA", "QATAR"));
            dictionary.Add(new CountryPair("RE", "RIUNION"));
            dictionary.Add(new CountryPair("RO", "ROMANIA"));
            dictionary.Add(new CountryPair("RU", "RUSSIAN FEDERATION"));
            dictionary.Add(new CountryPair("RW", "RWANDA"));
            dictionary.Add(new CountryPair("SA", "SAUDI ARABIA"));
            dictionary.Add(new CountryPair("SB", "SOLOMON ISLANDS"));
            dictionary.Add(new CountryPair("SC", "SEYCHELLES"));
            dictionary.Add(new CountryPair("SD", "SUDAN"));
            dictionary.Add(new CountryPair("SE", "SWEDEN"));
            dictionary.Add(new CountryPair("SG", "SINGAPORE"));
            dictionary.Add(new CountryPair("SH", "SAINT HELENA"));
            dictionary.Add(new CountryPair("SI", "SLOVENIA"));
            dictionary.Add(new CountryPair("SJ", "SVALBARD AND JAN MAYEN"));
            dictionary.Add(new CountryPair("SK", "SLOVAKIA"));
            dictionary.Add(new CountryPair("SL", "SIERRA LEONE"));
            dictionary.Add(new CountryPair("SM", "SAN MARINO"));
            dictionary.Add(new CountryPair("SN", "SENEGAL"));
            dictionary.Add(new CountryPair("SO", "SOMALIA"));
            dictionary.Add(new CountryPair("SR", "SURINAME"));
            dictionary.Add(new CountryPair("ST", "SAO TOME AND PRINCIPE"));
            dictionary.Add(new CountryPair("NA", "NAMIBIA"));
            dictionary.Add(new CountryPair("NC", "NEW CALEDONIA"));
            dictionary.Add(new CountryPair("SV", "EL SALVADOR"));
            dictionary.Add(new CountryPair("SY", "SYRIAN ARAB REPUBLIC"));
            dictionary.Add(new CountryPair("SZ", "SWAZILAND"));
            dictionary.Add(new CountryPair("TC", "TURKS AND CAICOS ISLANDS"));
            dictionary.Add(new CountryPair("TD", "CHAD"));
            dictionary.Add(new CountryPair("TF", "FRENCH SOUTHERN TERRITORIES"));
            dictionary.Add(new CountryPair("TG", "TOGO"));
            dictionary.Add(new CountryPair("TH", "THAILAND"));
            dictionary.Add(new CountryPair("TJ", "TAJIKISTAN"));
            dictionary.Add(new CountryPair("TK", "TOKELAU"));
            dictionary.Add(new CountryPair("TL", "TIMOR-LESTE"));
            dictionary.Add(new CountryPair("TM", "TURKMENISTAN"));
            dictionary.Add(new CountryPair("TN", "TUNISIA"));
            dictionary.Add(new CountryPair("TO", "TONGA"));
            dictionary.Add(new CountryPair("TR", "TURKEY"));
            dictionary.Add(new CountryPair("TT", "TRINIDAD AND TOBAGO"));
            dictionary.Add(new CountryPair("TV", "TUVALU"));
            dictionary.Add(new CountryPair("TW", "TAIWAN, PROVINCE OF CHINA"));
            dictionary.Add(new CountryPair("TZ", "TANZANIA, UNITED REPUBLIC OF"));
            dictionary.Add(new CountryPair("UA", "UKRAINE"));
            dictionary.Add(new CountryPair("UG", "UGANDA"));
            dictionary.Add(new CountryPair("UM", "UNITED STATES MINOR OUTLYING ISLANDS"));
            dictionary.Add(new CountryPair("US", "UNITED STATES"));
            dictionary.Add(new CountryPair("UY", "URUGUAY"));
            dictionary.Add(new CountryPair("UZ", "UZBEKISTAN"));
            dictionary.Add(new CountryPair("VA", "HOLY SEE (VATICAN CITY STATE)"));
            dictionary.Add(new CountryPair("VC", "SAINT VINCENT AND THE GRENADINES"));
            dictionary.Add(new CountryPair("VE", "VENEZUELA"));
            dictionary.Add(new CountryPair("VG", "VIRGIN ISLANDS, BRITISH"));
            dictionary.Add(new CountryPair("VI", "VIRGIN ISLANDS, U.S."));
            dictionary.Add(new CountryPair("VN", "VIET NAM"));
            dictionary.Add(new CountryPair("VU", "VANUATU"));
            dictionary.Add(new CountryPair("WF", "WALLIS AND FUTUNA"));
            dictionary.Add(new CountryPair("WS", "SAMOA"));
            dictionary.Add(new CountryPair("YE", "YEMEN"));
            dictionary.Add(new CountryPair("YT", "MAYOTTE"));
            dictionary.Add(new CountryPair("ZA", "SOUTH AFRICA"));
            dictionary.Add(new CountryPair("ZM", "ZAMBIA"));
            dictionary.Add(new CountryPair("ZW", "ZIMBABWE"));
            return dictionary;
        }
    }
    internal class CountryPair
    {
        public CountryPair(string Code,
                           string Name)
        {
            this.Name = Name;
            this.Code = Code;
        }
        public string Name { get; private set; } 
        public string Code { get; private set; }
    }
}
