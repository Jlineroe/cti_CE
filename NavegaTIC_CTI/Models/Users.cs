using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Users
    {
        public long IdMasterUsers { get; set; } = 0;
        public long PkEmpleado { get; set; }
        public string Identificacion { get; set; }
        public string FullName { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; } = "";
        public string EmailCorporativo { get; set; }
        public string Winuser { get; set; }
        public string CentroCosto { get; set; }
       
        public bool State { get; set; }
    }
}