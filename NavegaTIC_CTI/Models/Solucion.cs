using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Solucion
    {
        public int SolucionId { get; set; }
        [DisplayName("Solución")]
        public string SolucionName { get; set; }
    }
}