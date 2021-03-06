//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WhareHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class LOGIN
    {
        [Required(ErrorMessage = "Ingrese el ID del Usuario")]
        [Range(1, 9999, ErrorMessage = "El rango de id es de maximo 4 digitos")]
        public short IDUSER { get; set; }
        [Required(ErrorMessage = "Ingrese el Nombre De Usuario")]
        [MaxLength(length: 30, ErrorMessage = "Maximo 30 caracteres")]
        [MinLength(length: 1)]
        public string USERNAME { get; set; }
        [Required(ErrorMessage = "Ingrese Contraseña")]
        [MaxLength(length: 30, ErrorMessage = "Maximo 30 caracteres")]
        [MinLength(length: 1)]
        public string PASSWORDUSER { get; set; }
        [Required(ErrorMessage = "Ingrese Rol(Admin-Normal)")]
        [MaxLength(length: 30, ErrorMessage = "Maximo 30 caracteres")]
        [MinLength(length: 1)]
        public string ROL { get; set; }
    }
}



