using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class AsignadoA
    {
       
        public int AsignadoAId { get; set; }
        [DisplayName("Nombre del Asignado")]
        public string AsignadoAName { get; set; }
    }
}