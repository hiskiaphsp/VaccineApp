//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class vaccine_records
    {
        public int id { get; set; }
        public Nullable<int> community_id { get; set; }
        public Nullable<int> hospital_id { get; set; }
        public Nullable<int> vaccine_id { get; set; }
        public Nullable<System.DateTime> vaccine_date { get; set; }
        public Nullable<int> dose_number { get; set; }
        public string administration_type { get; set; }
        public string nurse_name { get; set; }
    }
}