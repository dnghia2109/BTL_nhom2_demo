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
    
    public partial class tb_Nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Nhanvien()
        {
            this.tb_HDB = new HashSet<tb_HDB>();
            this.tb_HDN = new HashSet<tb_HDN>();
        }
    
        public int ma_nv { get; set; }
        public string ten_nv { get; set; }
        public string gioi_tinh { get; set; }
        public Nullable<System.DateTime> ngay_sinh { get; set; }
        public string dien_thoai { get; set; }
        public string dia_chi { get; set; }
        public Nullable<int> ma_ca { get; set; }
        public Nullable<int> ma_cv { get; set; }
    
        public virtual tb_Calam tb_Calam { get; set; }
        public virtual tb_Congviec tb_Congviec { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_HDB> tb_HDB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_HDN> tb_HDN { get; set; }
    }
}
