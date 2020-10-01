namespace IWantMyName.DomainDns
{
    public class RecordType
    {
        private RecordType(string value) { Value = value; }

        public string Value { get; set; }

        public static RecordType A   { get { return new RecordType("A"); } }
        public static RecordType AAAA   { get { return new RecordType("AAAA"); } }
        public static RecordType CAA    { get { return new RecordType("CAA"); } }
        public static RecordType CNAME { get { return new RecordType("CNAME"); } }
        public static RecordType MX   { get { return new RecordType("MX"); } }
        public static RecordType NAPTR   { get { return new RecordType("NAPTR"); } }
        public static RecordType NS   { get { return new RecordType("NS"); } }
        public static RecordType SRV   { get { return new RecordType("SRV"); } }
        public static RecordType TXT   { get { return new RecordType("TXT"); } }
    }
}