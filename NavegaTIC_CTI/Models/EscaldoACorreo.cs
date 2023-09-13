using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class EscaladoACorreo
    {
        
        public int IdEscaladoA { get; set; }
        public int IdEscaladoACorreo { get; set; }
        [DisplayName("Escalado A")]
        public string NameEscaladoA { get; set; }
        public int pri { get; set; }
        [DisplayName("Correo")]
        public string NameEscaladoACorreo { get; set; }
    }
}