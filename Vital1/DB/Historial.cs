//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vital1.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Historial
    {
        public int Hist_ID { get; set; }
        public int Hist_Cant { get; set; }
        public int Prod_Id { get; set; }
        public Nullable<System.DateTime> Hist_Fecha { get; set; }
    
        public virtual Producto Producto { get; set; }
    }
}
