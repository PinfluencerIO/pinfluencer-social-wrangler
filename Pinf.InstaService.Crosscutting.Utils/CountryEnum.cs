using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pinf.InstaService.Crosscutting.Utils
{
    [ JsonConverter( typeof( StringEnumConverter ) ) ]
    public enum CountryEnum
    {
        [ Country( "Afghanistan" ) ] AF = 1,
        [ Country( "Åland Islands" ) ] AX = 2,
        [ Country( "Albania" ) ] AL = 3,
        [ Country( "Algeria" ) ] DZ = 4,
        [ Country( "American Samoa" ) ] AS = 5,
        [ Country( "Andorra" ) ] AD = 6,
        [ Country( "Angola" ) ] AO = 7,
        [ Country( "Anguilla" ) ] AI = 8,
        [ Country( "Antarctica" ) ] AQ = 9,

        [ Country( "Antigua and Barbuda" ) ]
        AG = 10,
        [ Country( "Argentina" ) ] AR = 11,
        [ Country( "Armenia" ) ] AM = 12,
        [ Country( "Aruba" ) ] AW = 13,
        [ Country( "Australia" ) ] AU = 14,
        [ Country( "Austria" ) ] AT = 15,
        [ Country( "Azerbaijan" ) ] AZ = 16,
        [ Country( "Bahamas" ) ] BS = 17,
        [ Country( "Bahrain" ) ] BH = 18,
        [ Country( "Bangladesh" ) ] BD = 19,
        [ Country( "Barbados" ) ] BB = 20,
        [ Country( "Belarus" ) ] BY = 21,
        [ Country( "Belgium" ) ] BE = 22,
        [ Country( "Belize" ) ] BZ = 23,
        [ Country( "Benin" ) ] BJ = 24,
        [ Country( "Bermuda" ) ] BM = 25,
        [ Country( "Bhutan" ) ] BT = 26,

        [ Country( "Bolivia" ) ]
        BO = 27,

        [ Country( "Bonaire, Sint Eustatius and Saba" ) ]
        BQ = 28,

        [ Country( "Bosnia and Herzegovina" ) ]
        BA = 29,
        [ Country( "Botswana" ) ] BW = 30,
        [ Country( "Bouvet Island" ) ] BV = 31,
        [ Country( "Brazil" ) ] BR = 32,

        [ Country( "British Indian Ocean Territory" ) ]
        IO = 33,
        [ Country( "Brunei Darussalam" ) ] BN = 34,
        [ Country( "Bulgaria" ) ] BG = 35,
        [ Country( "Burkina Faso" ) ] BF = 36,
        [ Country( "Burundi" ) ] BI = 37,
        [ Country( "Cabo Verde" ) ] CV = 38,
        [ Country( "Cambodia" ) ] KH = 39,
        [ Country( "Cameroon" ) ] CM = 40,
        [ Country( "Canada" ) ] CA = 41,
        [ Country( "Cayman Islands" ) ] KY = 42,

        [ Country( "Central African Republic" ) ]
        CF = 43,
        [ Country( "Chad" ) ] TD = 44,
        [ Country( "Chile" ) ] CL = 45,
        [ Country( "China" ) ] CN = 46,
        [ Country( "Christmas Island" ) ] CX = 47,

        [ Country( "Cocos (Keeling) Islands" ) ]
        CC = 48,
        [ Country( "Colombia" ) ] CO = 49,
        [ Country( "Comoros" ) ] KM = 50,
        [ Country( "Congo" ) ] CG = 51,

        [ Country( "Democratic Republic of the Congo" ) ]
        CD = 52,
        [ Country( "Cook Islands" ) ] CK = 53,
        [ Country( "Costa Rica" ) ] CR = 54,
        [ Country( "Côte d'Ivoire" ) ] CI = 55,
        [ Country( "Croatia" ) ] HR = 56,
        [ Country( "Cuba" ) ] CU = 57,
        [ Country( "Curaçao" ) ] CW = 58,
        [ Country( "Cyprus" ) ] CY = 59,
        [ Country( "Czechia" ) ] CZ = 60,
        [ Country( "Denmark" ) ] DK = 61,
        [ Country( "Djibouti" ) ] DJ = 62,
        [ Country( "Dominica" ) ] DM = 63,

        [ Country( "Dominican Republic" ) ]
        DO = 64,
        [ Country( "Ecuador" ) ] EC = 65,
        [ Country( "Egypt" ) ] EG = 66,
        [ Country( "El Salvador" ) ] SV = 67,
        [ Country( "Equatorial Guinea" ) ] GQ = 68,
        [ Country( "Eritrea" ) ] ER = 69,
        [ Country( "Estonia" ) ] EE = 70,
        [ Country( "Ethiopia" ) ] ET = 71,

        [ Country( "Falkland Islands (Malvinas)" ) ]
        FK = 72,
        [ Country( "Faroe Islands" ) ] FO = 73,
        [ Country( "Fiji" ) ] FJ = 74,
        [ Country( "Finland" ) ] FI = 75,
        [ Country( "France" ) ] FR = 76,
        [ Country( "French Guiana" ) ] GF = 77,
        [ Country( "French Polynesia" ) ] PF = 78,

        [ Country( "French Southern Territories" ) ]
        TF = 79,
        [ Country( "Gabon" ) ] GA = 80,
        [ Country( "Gambia" ) ] GM = 81,
        [ Country( "Georgia" ) ] GE = 82,
        [ Country( "Germany" ) ] DE = 83,
        [ Country( "Ghana" ) ] GH = 84,
        [ Country( "Gibraltar" ) ] GI = 85,
        [ Country( "Greece" ) ] GR = 86,
        [ Country( "Greenland" ) ] GL = 87,
        [ Country( "Grenada" ) ] GD = 88,
        [ Country( "Guadeloupe" ) ] GP = 89,
        [ Country( "Guam" ) ] GU = 90,
        [ Country( "Guatemala" ) ] GT = 91,
        [ Country( "Guernsey" ) ] GG = 92,
        [ Country( "Guinea" ) ] GN = 93,
        [ Country( "Guinea-Bissau" ) ] GW = 94,
        [ Country( "Guyana" ) ] GY = 95,
        [ Country( "Haiti" ) ] HT = 96,

        [ Country( "Heard Island and McDonald Islands" ) ]
        HM = 97,
        [ Country( "Holy See" ) ] VA = 98,
        [ Country( "Honduras" ) ] HN = 99,
        [ Country( "Hong Kong" ) ] HK = 100,
        [ Country( "Hungary" ) ] HU = 101,
        [ Country( "Iceland" ) ] IS = 102,
        [ Country( "India" ) ] IN = 103,
        [ Country( "Indonesia" ) ] ID = 104,

        [ Country( "Iran" ) ]
        IR = 105,
        [ Country( "Iraq" ) ] IQ = 106,
        [ Country( "Ireland" ) ] IE = 107,
        [ Country( "Isle of Man" ) ] IM = 108,
        [ Country( "Israel" ) ] IL = 109,
        [ Country( "Italy" ) ] IT = 110,
        [ Country( "Jamaica" ) ] JM = 111,
        [ Country( "Japan" ) ] JP = 112,
        [ Country( "Jersey" ) ] JE = 113,
        [ Country( "Jordan" ) ] JO = 114,
        [ Country( "Kazakhstan" ) ] KZ = 115,
        [ Country( "Kenya" ) ] KE = 116,
        [ Country( "Kiribati" ) ] KI = 117,

        [ Country( "North Korea" ) ]
        KP = 118,

        [ Country( "South Korea" ) ]
        KR = 119,
        [ Country( "Kuwait" ) ] KW = 120,
        [ Country( "Kyrgyzstan" ) ] KG = 121,

        [ Country( "Lao People's Democratic Republic" ) ]
        LA = 122,
        [ Country( "Latvia" ) ] LV = 123,
        [ Country( "Lebanon" ) ] LB = 124,
        [ Country( "Lesotho" ) ] LS = 125,
        [ Country( "Liberia" ) ] LR = 126,
        [ Country( "Libya" ) ] LY = 127,
        [ Country( "Liechtenstein" ) ] LI = 128,
        [ Country( "Lithuania" ) ] LT = 129,
        [ Country( "Luxembourg" ) ] LU = 130,
        [ Country( "Macao" ) ] MO = 131,

        [ Country( "Macedonia" ) ]
        MK = 132,
        [ Country( "Madagascar" ) ] MG = 133,
        [ Country( "Malawi" ) ] MW = 134,
        [ Country( "Malaysia" ) ] MY = 135,
        [ Country( "Maldives" ) ] MV = 136,
        [ Country( "Mali" ) ] ML = 137,
        [ Country( "Malta" ) ] MT = 138,
        [ Country( "Marshall Islands" ) ] MH = 139,
        [ Country( "Martinique" ) ] MQ = 140,
        [ Country( "Mauritania" ) ] MR = 141,
        [ Country( "Mauritius" ) ] MU = 142,
        [ Country( "Mayotte" ) ] YT = 143,
        [ Country( "Mexico" ) ] MX = 144,

        [ Country( "Micronesia" ) ]
        FM = 145,

        [ Country( "Moldova" ) ]
        MD = 146,
        [ Country( "Monaco" ) ] MC = 147,
        [ Country( "Mongolia" ) ] MN = 148,
        [ Country( "Montenegro" ) ] ME = 149,
        [ Country( "Montserrat" ) ] MS = 150,
        [ Country( "Morocco" ) ] MA = 151,
        [ Country( "Mozambique" ) ] MZ = 152,
        [ Country( "Myanmar" ) ] MM = 153,
        [ Country( "Namibia" ) ] NA = 154,
        [ Country( "Nauru" ) ] NR = 155,
        [ Country( "Nepal" ) ] NP = 156,
        [ Country( "Netherlands" ) ] NL = 157,
        [ Country( "New Caledonia" ) ] NC = 158,
        [ Country( "New Zealand" ) ] NZ = 159,
        [ Country( "Nicaragua" ) ] NI = 160,
        [ Country( "Niger" ) ] NE = 161,
        [ Country( "Nigeria" ) ] NG = 162,
        [ Country( "Niue" ) ] NU = 163,
        [ Country( "Norfolk Island" ) ] NF = 164,

        [ Country( "Northern Mariana Islands" ) ]
        MP = 165,
        [ Country( "Norway" ) ] NO = 166,
        [ Country( "Oman" ) ] OM = 167,
        [ Country( "Pakistan" ) ] PK = 168,
        [ Country( "Palau" ) ] PW = 169,

        [ Country( "Palestine" ) ]
        PS = 170,
        [ Country( "Panama" ) ] PA = 171,
        [ Country( "Papua New Guinea" ) ] PG = 172,
        [ Country( "Paraguay" ) ] PY = 173,
        [ Country( "Peru" ) ] PE = 174,
        [ Country( "Philippines" ) ] PH = 175,
        [ Country( "Pitcairn" ) ] PN = 176,
        [ Country( "Poland" ) ] PL = 177,
        [ Country( "Portugal" ) ] PT = 178,
        [ Country( "Puerto Rico" ) ] PR = 179,
        [ Country( "Qatar" ) ] QA = 180,
        [ Country( "Réunion" ) ] RE = 181,
        [ Country( "Romania" ) ] RO = 182,

        [ Country( "Russian Federation" ) ]
        RU = 183,
        [ Country( "Rwanda" ) ] RW = 184,
        [ Country( "Saint Barthélemy" ) ] BL = 185,

        [ Country( "Saint Helena, Ascension and Tristan da Cunha" ) ]
        SH = 186,

        [ Country( "Saint Kitts and Nevis" ) ]
        KN = 187,
        [ Country( "Saint Lucia" ) ] LC = 188,

        [ Country( "Saint Martin" ) ]
        MF = 189,

        [ Country( "Saint Pierre and Miquelon" ) ]
        PM = 190,

        [ Country( "Saint Vincent and the Grenadines" ) ]
        VC = 191,
        [ Country( "Samoa" ) ] WS = 192,
        [ Country( "San Marino" ) ] SM = 193,

        [ Country( "Sao Tome and Principe" ) ]
        ST = 194,
        [ Country( "Saudi Arabia" ) ] SA = 195,
        [ Country( "Senegal" ) ] SN = 196,
        [ Country( "Serbia" ) ] RS = 197,
        [ Country( "Seychelles" ) ] SC = 198,
        [ Country( "Sierra Leone" ) ] SL = 199,
        [ Country( "Singapore" ) ] SG = 200,

        [ Country( "Sint Maarten" ) ]
        SX = 201,
        [ Country( "Slovakia" ) ] SK = 202,
        [ Country( "Slovenia" ) ] SI = 203,
        [ Country( "Solomon Islands" ) ] SB = 204,
        [ Country( "Somalia" ) ] SO = 205,
        [ Country( "South Africa" ) ] ZA = 206,

        [ Country( "South Georgia and the South Sandwich Islands" ) ]
        GS = 207,
        [ Country( "South Sudan" ) ] SS = 208,
        [ Country( "Spain" ) ] ES = 209,
        [ Country( "Sri Lanka" ) ] LK = 210,
        [ Country( "Sudan" ) ] SD = 211,
        [ Country( "Suriname" ) ] SR = 212,

        [ Country( "Svalbard and Jan Mayen" ) ]
        SJ = 213,
        [ Country( "Swaziland" ) ] SZ = 214,
        [ Country( "Sweden" ) ] SE = 215,
        [ Country( "Switzerland" ) ] CH = 216,

        [ Country( "Syrian Arab Republic" ) ]
        SY = 217,

        [ Country( "Taiwan" ) ]
        TW = 218,
        [ Country( "Tajikistan" ) ] TJ = 219,

        [ Country( "Tanzania" ) ]
        TZ = 220,
        [ Country( "Thailand" ) ] TH = 221,
        [ Country( "Timor-Leste" ) ] TL = 222,
        [ Country( "Togo" ) ] TG = 223,
        [ Country( "Tokelau" ) ] TK = 224,
        [ Country( "Tonga" ) ] TO = 225,

        [ Country( "Trinidad and Tobago" ) ]
        TT = 226,
        [ Country( "Tunisia" ) ] TN = 227,
        [ Country( "Turkey" ) ] TR = 228,
        [ Country( "Turkmenistan" ) ] TM = 229,

        [ Country( "Turks and Caicos Islands" ) ]
        TC = 230,
        [ Country( "Tuvalu" ) ] TV = 231,
        [ Country( "Uganda" ) ] UG = 232,
        [ Country( "Ukraine" ) ] UA = 233,

        [ Country( "United Arab Emirates" ) ]
        AE = 234,

        [ Country( "United Kingdom" ) ]
        GB = 235,

        [ Country( "United States" ) ]
        US = 236,

        [ Country( "United States Minor Outlying Islands" ) ]
        UM = 237,
        [ Country( "Uruguay" ) ] UY = 238,
        [ Country( "Uzbekistan" ) ] UZ = 239,
        [ Country( "Vanuatu" ) ] VU = 240,

        [ Country( "Venezuela" ) ]
        VE = 241,
        [ Country( "Viet Nam" ) ] VN = 242,

        [ Country( "Virgin Islands" ) ]
        VG = 243,

        [ Country( "Virgin Islands" ) ]
        VI = 244,
        [ Country( "Wallis and Futuna" ) ] WF = 245,
        [ Country( "Western Sahara" ) ] EH = 246,
        [ Country( "Yemen" ) ] YE = 247,
        [ Country( "Zambia" ) ] ZM = 248,
        [ Country( "Zimbabwe" ) ] ZW = 249
    }
}