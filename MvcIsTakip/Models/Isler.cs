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
    
    public partial class Isler
    {
        public int IsID { get; set; }
        public string IsAd { get; set; }
        public string IsAciklama { get; set; }
        public Nullable<System.DateTime> IsTarih { get; set; }
        public Nullable<int> IsPersonelID { get; set; }
        public Nullable<System.DateTime> IletilenTarih { get; set; }
        public Nullable<System.DateTime> YapilanTarih { get; set; }
        public string IsDurum { get; set; }
    
        public virtual TBL_Personel TBL_Personel { get; set; }
    }
}