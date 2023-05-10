namespace api.Entities
{
    public class Partner
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Mjesto { get; set; }
        public int BrojPoste { get; set; }
        public int Mb { get; set; }
        public int Pdv { get; set; }
        public string BankaJedan { get; set; }
        public string BankaDva { get; set; }
        public string BankaTri { get; set; }
        public string Swift { get; set; }
        public string Tip { get; set; }
        public string Drzava { get; set; }
    }
}