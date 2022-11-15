using System;
using System.Collections.Generic;

#nullable disable

namespace DevoirPA.Entities
{
    public partial class Bureau
    {
        public int Numero { get; set; }
        public string Nom { get; set; }
        public int? Capacite { get; set; }
        public string Numeroelecteur { get; set; }
    }
}
