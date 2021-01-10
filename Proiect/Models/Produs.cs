using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class Produs
    {
        public int ProdusId { get; set; }
        public string Denumire{ get; set; }
        public float Pret { get; set; }
        public Factura Factura { get; set; }
        public ICollection<Recenzie> Recenzie { get; set; }
        public virtual ICollection<Magazin> Magazine { get; set; }
    }
}