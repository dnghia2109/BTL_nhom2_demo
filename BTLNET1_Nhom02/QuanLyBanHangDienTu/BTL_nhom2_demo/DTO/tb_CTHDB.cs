//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTL_nhom2_demo.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_CTHDB
    {
        public string ma_hdb { get; set; }
        public int ma_hang { get; set; }
        public Nullable<double> so_luong { get; set; }
        public Nullable<double> don_gia { get; set; }
        public Nullable<double> giam_gia { get; set; }
        public Nullable<double> thanh_tien { get; set; }
    
        public virtual tb_Hanghoa tb_Hanghoa { get; set; }
        public virtual tb_HDB tb_HDB { get; set; }
    }
}
