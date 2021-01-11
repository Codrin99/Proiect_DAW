using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Proiect.Models
{
    public class Recenzie
    {
        public int RecenzieId { get; set; }
        [MinLength(10, ErrorMessage = "Recenzia trebuie sa aiba minim 10 caracatere")]
        public string Descriere { get; set; }
        [Range(0,10)]
        public int Rating { get; set; }
        public int ProdusId { get; set; }
        public Produs Produs  { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}