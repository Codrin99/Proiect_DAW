using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class Magazin
    {
        public int MagazinId { get; set; }
        public string DenumireMagazin { get; set; }
        public virtual ICollection<Produs> Produse { get; set; }
    }
}