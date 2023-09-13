using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Subcategoria
    {
        
        public int IdCategoria { get; set; }
        public int SubcategoriaId { get; set; }
        [DisplayName("Subcategoria")]
        public string SubcategoriaName { get; set; }
        public int pri { get; set; }
        [DisplayName("Categoria")]
        public string CategoriaName { get; set; }
    }
}