using System;
using System.ComponentModel.DataAnnotations;
using api.Entities;

namespace api.DTOs
{
    public class ZaglavljeRacunaDto
    {
        public int Id { get; set; }
        [Required]
        public int Brojracuna { get; set; }
        [Required]
        public DateTime Datumisporuke { get; set; }
        [Required]
        public DateTime Datumdokumenta { get; set; }
        [Required]
        public DateTime Datumdospijeca { get; set; }
        public string Opis { get; set; }
        [Required]
        public string Mjestoizdavanja { get; set; }
        [Required]
        public DateTime Datumizdavanja { get; set; }
        public int Fiskalnibroj { get; set; }
        public string Status { get; set; }
        public double Tecaj { get; set; }
        [Required]
        public int Partnerid { get; set;}
        public string Napomena { get; set; }
    }
}