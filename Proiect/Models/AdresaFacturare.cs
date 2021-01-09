using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class AdresaFacturare
    {
        public int AdresaFacturareId { get; set; }
        public string Judet { get; set; }
        public string Oras { get; set; }
        public string Strada { get; set; }
        public int Numarul { get; set; }
        public string Bloc { get; set; }
        public int Etaj { get; set; }
        public int Apartament { get; set; }
        public virtual Factura Factura { get; set; }
    }
}