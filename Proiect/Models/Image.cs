using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string Denumire { get; set; }

        [Required]
        public byte[] Data { get; set; }
        [Required]
        public string Path { get; set; }

        public int ProdusId { get; set; }
        public Produs Produs { get; set; }
    }
}