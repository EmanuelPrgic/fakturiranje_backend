using System;

namespace api.Entities
{
    public class ZaglavljeRacuna
    {
        public int Id { get; set; }

        public int BrojRacuna { get; set; }

        public DateTime DatumIsporuke { get; set; } = DateTime.UtcNow;

        public DateTime DatumDokumenta { get; set; } = DateTime.UtcNow;

        public DateTime DatumDospijeca { get; set; } = DateTime.UtcNow;

        public string Opis { get; set; }

        public string MjestoIzdavanja { get; set; }

        public DateTime DatumIzdavanja { get; set; } = DateTime.UtcNow;

        public int FiskalniBroj { get; set; }

        public int KupacId { get; set; }

        public int Tecaj { get; set; }

        public string Napomena { get; set; }

        public int UkupanIznos { get; set; }

        public string Status { get; set; }

        public StavkeRacuna StavkeRacuna { get; set; }
    }
}