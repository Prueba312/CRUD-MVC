using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vital1.Models.ViewModels
{
    public class ListaProductoViewModels
    {
        public int Prod_Id { get; set; }
        public string Prod_Desk { get; set; }
        public int Prod_Cant { get; set; }
        public bool Prod_estado { get; set; }
        public int Cant_total { get; set; }
        public DateTime? Fecha { get; set; }

    }
}