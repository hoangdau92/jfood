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
    
    public partial class CMS_Magazines
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<int> Number { get; set; }
        public Nullable<int> NumberOfRelease { get; set; }
        public int FieldID { get; set; }
        public Nullable<int> Years { get; set; }
        public string Cover { get; set; }
        public string FileName { get; set; }
        public string Issuer { get; set; }
    }
}
