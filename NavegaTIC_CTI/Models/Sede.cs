using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Sede
    {
       public int SedeId { get; set; }
        [DisplayName("Nombre de la sede")]
        public string SedeName { get; set; }

    }
}