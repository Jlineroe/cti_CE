using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class WorkOrder
    {
        public long IdWorkOrder { get; set; }
        public long IdWorkOrderReference { get; set; }
        public string Semaphore { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DateSAP { get; set; }
        public string DateModification { get; set; }
        public string DateLog { get; set; }
        /*QUEMON PARA PQR BOG*/
        public long PQR { get; set; }
        public long Cuenta { get; set; }
        public string X_COORDINATE { get; set; }
        public string NUMERO { get; set; }
        public int DiasPQR { get; set; }

        /*CAMPOS PQR AIRE*/
        public string FechaCorreo { get; set; }
        public string FechaCorreoVIP { get; set; }
        public int IdSubCategory { get; set; }
        public int IdCategory { get; set; }
        public int Group { get; set; }
        public string NameCategory { get; set; }
        public string NameSubCategory { get; set; }
        /* negacion de linea 08.2021    */


    }
}