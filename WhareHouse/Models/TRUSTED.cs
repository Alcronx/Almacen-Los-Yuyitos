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
    
    public partial class TRUSTED
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRUSTED()
        {
            this.TICKET = new HashSet<TICKET>();
        }
    
        public long IDTRUSTED { get; set; }
        public string STATE { get; set; }
        public System.DateTime TRUSTDATE { get; set; }
        public System.DateTime TIMELIMITTRUST { get; set; }
        public string STATETRUSTED { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET> TICKET { get; set; }
    }
}
