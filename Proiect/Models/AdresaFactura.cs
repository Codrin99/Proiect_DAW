using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class AdresaFactura
    {

        public string Strada { get; set; }
        public string Numar { get; set; }
        public string Oras { get; set; }
        public string Judet { get; set; }
        public string Tara { get; set; }
        [ForeignKey("Factura")]
        public int AdresaFacturaId { get; set; }
        public Factura Factura { get; set; }
    }
}