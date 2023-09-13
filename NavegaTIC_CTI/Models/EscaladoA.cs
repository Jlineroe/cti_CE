using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class EscaladoA
    {
        public int EscaladoAId { get; set; }
        [DisplayName("Escalado A")]
        public string EscaladoAName { get; set; }
    }
}