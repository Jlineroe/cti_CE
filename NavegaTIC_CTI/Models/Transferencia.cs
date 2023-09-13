using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Transferencia
    {
        public int TransferenciaId { get; set; }
        [DisplayName("Nombre de la Transferencia")]
        public string TransferenciaName { get; set; }
    }
}