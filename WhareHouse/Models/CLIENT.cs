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

    public partial class CLIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENT()
        {
            this.TICKET = new HashSet<TICKET>();
        }

        [Required(ErrorMessage = "Ingrese el ID del Cliente")]
        public short IDCLIENT { get; set; }
        [Required(ErrorMessage = "Ingrese Rut del cliente")]
        [MaxLength(length: 10, ErrorMessage = "Maximo 10 caracteres, sin guion")]
        [MinLength(length: 8, ErrorMessage = "Minimo 8 caracteres, sin guion")]
        public string CLIENTRUT { get; set; }
        [Required(ErrorMessage = "Ingrese el Primer nombre del cliente.")]
        [MaxLength(length: 30, ErrorMessage = "Maximo 30 caracteres")]
        [MinLength(length: 1)]
        public string NAME1 { get; set; }
        [MaxLength(length: 30, ErrorMessage = "Maximo 30 caracteres")]
        public string NAME2 { get; set; }
        [Required(ErrorMessage = "Ingrese el Apellido Paterno del cliente.")]
        [MaxLength(length: 30, ErrorMessage = "Maximo 30 caracteres")]
        [MinLength(length: 1)]
        public string LASTNAME1 { get; set; }
        [MaxLength(length: 30, ErrorMessage = "Maximo 30 caracteres")]
        public string LASTNAME2 { get; set; }
        [Required(ErrorMessage = "Ingrese el numero de Celular del cliente")]
        [Range(10000000000, 99999999999, ErrorMessage = "Ingrese el numero con el codigo de area")]
        public long CELLPHONE { get; set; }
        [Required(ErrorMessage = "Ingrese si puede fiar")]
        [MaxLength(length: 1)]
        [MinLength(length: 1)]
        public string BLACKLIST { get; set; }
        [Required(ErrorMessage = "Ingrese fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}"),]
        public System.DateTime BIRTHDATE { get; set; }
        public string STATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET> TICKET { get; set; }
    }
}
















