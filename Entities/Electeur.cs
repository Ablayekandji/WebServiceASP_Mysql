using System;
using System.Collections.Generic;

#nullable disable

namespace DevoirPA.Entities
{
    public partial class Electeur
    {
        public string Numero { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Lieu { get; set; }
        public DateTime Ladate { get; set; }
    }
}
