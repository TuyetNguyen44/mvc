using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc.Models;
using mvc.DAO;

namespace mvc.Buss
{
    public class SanPhamBUS
    {
        SanphamDAO pd = new SanphamDAO();
        public List<Sanpham> GetSanPhams()
        {
            return pd.GetSanpham();

        }
        public List<Sanpham> LaySPTheoLoai(string maloai)
        {
            return pd.LaySPTheoLoai(maloai);
        }
        public SanPhamList GetSanPham(string maloai, int pageIndex, int pagesize, string productname)
        {
           return pd.GetSanPhams( maloai,pageIndex, pagesize, productname);
        }
        public List<Sanpham> GetProductCategory( string proID)
        {
            return pd.GetProductCategory(proID);
        }
        public Sanpham GetSanPhamCT(string masp)
        {
            return pd.GetSanPhamCT(masp);
        }


    }
}
