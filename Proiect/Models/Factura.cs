using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class Factura
    {
        public int FacturaId { get; set; }
        [Required]
        public string Valoare { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string NumeClient { get; set; }
        public int ProdusId { get; set; }
        public ICollection<Produs> Produse { get; set; }


    }
}