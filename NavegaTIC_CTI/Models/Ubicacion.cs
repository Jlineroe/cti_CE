using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Ubicacion
    {
        
        public int IdSede { get; set; }
        public int UbicacionId { get; set; }
        [DisplayName("Ubicacion")]
        public string UbicacionName { get; set; }
        public int pri { get; set; }
        [DisplayName("Sede")]
        public string SedeName { get; set; }
    }
}