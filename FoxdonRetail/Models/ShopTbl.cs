//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoxdonRetail.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShopTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShopTbl()
        {
            this.ProductTbls = new HashSet<ProductTbl>();
        }
    
        public long ShopID { get; set; }
        public string ShopName { get; set; }
        public string ShopPlace { get; set; }
        public string ShopCity { get; set; }
        public string GSTIN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductTbl> ProductTbls { get; set; }
    }
}
