//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaTecnica2020.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClienteSalon
    {
        public int idSalon { get; set; }
        public int idCliente { get; set; }
        public System.DateTime FechaEvento { get; set; }
        public int CantidadPersonas { get; set; }
        public string Motivo { get; set; }
        public string Observaciones { get; set; }
        public bool Estado { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Salon Salon { get; set; }
    }
}
