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
        [MinLength(10, ErrorMessage ="Textul trebuie sa contina minim 10 caractere")]
        public string Descriere { get; set; }
        [Range(0,10,ErrorMessage ="Nota trebuie sa fie intre 0 si 10")]
        public string Rating { get; set; }
        public int ProdusId { get; set; }
        public Produs Produs  { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}