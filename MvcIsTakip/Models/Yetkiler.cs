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
    
    public partial class Yetkiler
    {
        public int YetkiID { get; set; }
        public Nullable<int> YetkiTurID { get; set; }
        public Nullable<int> PersonelID { get; set; }
        public Nullable<int> BirimID { get; set; }
    
        public virtual Birimler Birimler { get; set; }
        public virtual TBL_Personel TBL_Personel { get; set; }
        public virtual YetkiTurler YetkiTurler { get; set; }
    }
}
