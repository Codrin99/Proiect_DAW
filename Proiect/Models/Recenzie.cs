using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class Recenzie
    {
        public int RecenzieId { get; set; }
        public string Descriere { get; set; }
        public int Rating { get; set; }
        public int ProdusId { get; set; }
        public Produs Produs  { get; set; }
    }
}