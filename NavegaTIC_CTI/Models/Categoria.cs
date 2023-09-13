using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [DisplayName("Nombre de la Categoría")]
        public string CategoriaName { get; set; }
    }
}