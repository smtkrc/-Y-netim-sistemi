//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcIsTakip.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class YetkiTurler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public YetkiTurler()
        {
            this.Yetkiler = new HashSet<Yetkiler>();
        }
    
        public int YetkiTurID { get; set; }
        public string YetkiTurAd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yetkiler> Yetkiler { get; set; }
    }
}