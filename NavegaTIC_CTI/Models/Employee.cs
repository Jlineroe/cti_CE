using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Employee
    {
    
        public string Identificacion { get; set; }
       
        public string CargoId { get; set; }
        public string CostoId { get; set; }
        public int CategotyId { get; set; }
        public int SubCategoryyId { get; set; }
        public int DescriptionId { get; set; }
        public string Email { get; set; }
    }
}