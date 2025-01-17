﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Proiect.Models
{
    public class Magazin
    {
        public int MagazinId { get; set; }
        [Required]
        public string DenumireMagazin { get; set; }
        [Required]
        public string Oras { get; set; }
        public int ProdusId { get; set; }
        public virtual ICollection<Produs> Produse { get; set; }
    }
}