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
    
    public partial class CMS_News
    {
        public int ID { get; set; }
        public string TITLE { get; set; }
        public string EXCERPT { get; set; }
        public string CONTENTS { get; set; }
        public string PICTURE { get; set; }
        public Nullable<int> ID_USERCREATE { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public Nullable<short> ID_CATEGORIES { get; set; }
        public Nullable<short> ID_NEWS_STATUS { get; set; }
        public Nullable<int> NUMBEROFVIEW { get; set; }
        public Nullable<int> ID_USERMODIFY { get; set; }
        public Nullable<System.DateTime> EDITDATE { get; set; }
        public Nullable<short> ISFOCUS { get; set; }
    
        public virtual CMS_Categories CMS_Categories { get; set; }
        public virtual CSF_Users CSF_Users { get; set; }
    }
}