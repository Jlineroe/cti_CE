using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Estado
    {
        public int EstadoId { get; set; }
        [DisplayName("Estado")]
        public string EstadoName { get; set; }
    }
}