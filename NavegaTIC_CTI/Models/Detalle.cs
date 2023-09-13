using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Detalle
    {
        
        public int IdSubcategoria { get; set; }
        public int DetalleId { get; set; }
        [DisplayName("Detalle")]
        public string DetalleName { get; set; }
        [DisplayName("Campaña")]
        public string Campaña { get; set; }
        public int pri { get; set; }
        [DisplayName("Subcategoria")]
        public string SubcategoriaName { get; set; }
    }
}