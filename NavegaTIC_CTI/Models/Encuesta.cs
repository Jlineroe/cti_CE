using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Encuesta
    {
        
        public int IdCTiCE { get; set; }
       
        [DisplayName("1.¿Consideras que se brindó solución a tu solicitud?")]
        public string RespuestaEncuesta { get; set; }
        public int IdEncuesta { get; set; }
        [DisplayName("2. Por favor dejanos un comentario sobre tu experiencia")]
        public string CometarioEncuesta { get; set; }
    }
}