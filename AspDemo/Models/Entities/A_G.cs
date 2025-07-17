namespace AspDemo.Models.Entities
{
    public class A_G
    {
        public string Chromosome { get; set; } = string.Empty;
        public long Position { get; set; }
        public string Minor_allele { get; set; } = string.Empty;
        public string Major_allele { get; set; } = string.Empty;
        public string Annotation { get; set; } = string.Empty;
        public string Ensemble_ID { get; set; } = string.Empty;
        public string Gene_name { get; set; } = string.Empty;
        public double Frequency_of_A1 { get; set; }
        public double Beta { get; set; }
        public double Standard_error { get; set; }
        public double P_value { get; set; }
        public string Trait { get; set; } = string.Empty;
    }
}
