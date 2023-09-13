using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class Caso
    {
        public string CasoId { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Canal { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public string CargoId { get; set; }
        public string CostoId { get; set; }
        public string CategotyId { get; set; }
        public string SubCategoryyId { get; set; }
        public string DescriptionId { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string NombreAgente { get; set; }
        public string Sedes { get; set; }
        public string Asignadoa { get; set; }
        public int Categoria { get; set; }
        public int Subcategoria { get; set; }
        public string Detalle { get; set; }
        public string Detalle2 { get; set; }
        public string Escalamiento { get; set; }
        public string Escaladoa { get; set; }
        public DateTime? Fescalamiento { get; set; }
        public string Rescalamiento { get; set; }
        public string Soluciones { get; set; }
        public string Estados { get; set; }
        public DateTime? Fsolucion { get; set; }
        public string ubicacion { get; set; }
        public string asuntomail { get; set; }
        public string Correos { get; set; }
        public string bodymail { get; set; }
        public string clock { get; set; }
        public string Sede { get; set; }
        public int Ans { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Opcion_Precionada { get; set; }
        public string Id_LlamadaIVR { get; set; }
        public string Transferida { get; set; }
        public string Transferidade { get; set; }


    }
}