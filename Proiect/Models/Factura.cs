using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public float Valoare { get; set; }
        public string NumeClient { get; set; }
        public ICollection<Produs> Produse { get; set; }


    }
}