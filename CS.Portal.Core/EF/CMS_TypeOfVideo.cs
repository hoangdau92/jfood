//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CS.Portal.Core.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class CMS_TypeOfVideo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CMS_TypeOfVideo()
        {
            this.CMS_Videos = new HashSet<CMS_Videos>();
        }
    
        public short ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMS_Videos> CMS_Videos { get; set; }
    }
}
