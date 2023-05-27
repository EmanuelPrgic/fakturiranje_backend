using System;
using System.Collections;
using System.Collections.Generic;
using api.Controllers;

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

        public double Tecaj { get; set; } = 1.95583;

        public string Napomena { get; set; }

        public int UkupanIznos { get; set; }

        public string Status { get; set; } = "Kreireana";

        public int PartnerId { get; set; }

        public Partner Partner { get; set;} = null!;
    }
}