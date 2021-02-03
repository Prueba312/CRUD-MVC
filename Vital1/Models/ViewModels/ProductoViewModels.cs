using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vital1.Models.ViewModels
{
    public class ProductoViewModels
    {
        public int Prod_Id { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 2)]
        [Display(Name = "Nombre de producto")]
        public string Prod_Desk { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Rango exedente de campo")]
        /*[StringLength(10, ErrorMessage = "El número de caracteres de {0} debe ser al menos {1}.", MinimumLength = 2)]*/
        [Display(Name = "Cantidad de producto")]
        public int Prod_Cant { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Rango exedente de campo")]
        /*[StringLength(10, ErrorMessage = "El número de caracteres de {0} debe ser al menos {1}.", MinimumLength = 2)]*/
        [Display(Name = "Cantidad de producto a agregar")]
        public int Hist_Cant { get; set; }


    }

};