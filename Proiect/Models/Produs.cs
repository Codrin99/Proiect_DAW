using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proiect.Models
{
    public class Produs
    {
        public Produs()
        {
            this.Magazine = new HashSet<Magazin>();
        }
        public int ProdusId { get; set; }
        [Required]
        public string Denumire { get; set; }
        [Validare]
        public string Pret { get; set; }
        public Factura Factura { get; set; }
        public ICollection<Recenzie> Recenzie { get; set; }
        public int MagazinId { get; set; }
        public virtual ICollection<Magazin> Magazine { get; set; }
    }
}