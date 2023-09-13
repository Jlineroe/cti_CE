using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Campana
    {
        public int CampanaId { get; set; }
        [DisplayName("Nombre de la campaña")]
        public string CampanaName { get; set; }
    }
}