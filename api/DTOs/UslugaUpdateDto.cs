using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class UslugaUpdateDto
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijenadeviza { get; set; }
        public decimal Cijenakm { get; set; }
        public decimal Rabat { get; set; }
        public decimal Pdv { get; set; }
        public int Brojracuna { get; set; }
    }
}