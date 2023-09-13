using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class InforMail
    {
        public string Asunto { get; set; }
        public string ContenidoMsj { get; set; }
        public List<string> Destinatarios { get; set; } = new List<string>();
    }
}