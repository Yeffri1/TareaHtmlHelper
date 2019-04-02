using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace htmlHelper.Models
{
    public class Cliente
    {
        [Display(Name = "Cedula:"), Required(ErrorMessage = "La cedula es requerido", AllowEmptyStrings = false),
  StringLength(11, ErrorMessage = "El Cedula no puede ser mayor a 50 caracteres")]
        [Remote("CedulaValida", "Home",  ErrorMessage = "Esta cedula no es valuda.", HttpMethod = "get")]
        public string Cedula { get; set; }

        [Display(Name = "Nombre:"), Required(ErrorMessage = "El nombre es requerido", AllowEmptyStrings = false),
         StringLength(50, ErrorMessage = "El nombre no puede ser mayor a 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debes ingresar apellido", AllowEmptyStrings = false), Display(Description = "Apellido:", Name = "Apellido:"), StringLength(50, ErrorMessage = "Debe ser menor a 50 caracteres")]
        public string Apellido { get; set; }

        [DataType(DataType.PhoneNumber), Phone(ErrorMessage = "Debes ingresar un telefono")]
        public string Telefono { get; set; }
        [EmailAddress(ErrorMessage = "Debes ser un correo electronico"), Display(Name = "Correo:", Description = "Correo:"),
            DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        public int Genero { get; set; }

        [Range(15, 200)]
        public int Edad { get; set; }
        public int EstadoCivil { get; set; }

        public bool Voleibol { get; set; }
        public bool Baloncesto { get; set; }
        public bool Pelota { get; set; }
        public bool Natacion { get; set; }
        [Display(Name = "Estado Civil:",Description = "Estado Civil:")]
        public string EstadoCivil_Text { get; set; }
        public string GeneroText { get; set; }


        internal string GetEstadoText(int estado)
        {
            string r = string.Empty;
            switch (estado)
            {
                case 0: r = "Union Libre"; break;
                case 1: r = "Soltero"; break;
                case 2: r = "Casado"; break;
                case 3: r = "Viudo"; break;
                default: r = ""; break;
            }
            return r;
        }
        internal string GetGeneroText(int genero)
        {
            string r = string.Empty;
            switch (genero)
            {
                case 1: r = "Masculino"; break;
                case 2: r = "Femenino"; break;
                default: r = ""; break;
            }
            return r;
        }
    }
   
}