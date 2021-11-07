using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc.Models
{
    public class Sanpham
    {

        public string MaSP { get; set; }
        public string TenSp { get; set; }
        public string Maloai { get; set; }
        public string DonVi { get; set; }
        public string Mota { get; set; }
        public string Anh { get; set; }
        public string AnhTo { get; set; }
        public Sanpham(string masp, string tensp,string maloai,string donvi,string mota, string anh,string anhto)
        {
            this.MaSP = masp;
            this.TenSp = tensp;
            this.Maloai = maloai;
            this.DonVi = donvi;
            this.Mota = mota;
            this.Anh = anh;
            this.AnhTo = anhto;
        }

        public Sanpham()
        {
        }
    }
}