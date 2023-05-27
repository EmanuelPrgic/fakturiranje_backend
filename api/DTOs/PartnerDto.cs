using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class PartnerDto
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Mjesto { get; set; }
        [Required]
        public int Brojposte { get; set; }
        [Required]
        public int Mb { get; set; }
        [Required]
        public int Pdv { get; set; }
        [Required]
        public string Bankajedan { get; set; }
        public string Bankadva { get; set; }
        public string Bankatri { get; set; }
        public string Swift { get; set; }
        [Required]
        public string Tip { get; set; }
        [Required]
        public string Drzava { get; set; }
    }
}