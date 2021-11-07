using System.Collections.Generic;
using mvc.Models;
using System.Data;
using System.Data.SqlClient;

namespace mvc.DAO
{
    public class SanphamDAO
    {
        Datahelper dh = new Datahelper();
        public List<Sanpham> GetSanpham()
        {
            DataTable dt = dh.GetDataTable("Select*from SanPham");
            return ToList(dt);
        }
        public Sanpham GetSanPhamCT(string masp)
        {
            DataTable dt = dh.GetDataTable("Select*from SanPham where MaSP='"+masp+"'");
            Sanpham sp = new Sanpham();
            if (dt.Rows.Count < 0)
            {
                return null;
            }
            else
            {
                DataRow dr = dt.Rows[0];
                Sanpham s = new Sanpham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                   dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                return s;
            }
        }

        public List<Sanpham> ToList(DataTable dt)
        {
            List<Sanpham> l = new List<Sanpham>();
            foreach (DataRow dr in dt.Rows)
            {
                Sanpham s = new Sanpham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                l.Add(s);
            }
            return l;
        }
        public List<Sanpham>LaySPTheoLoai(string maloai)
        {
            DataTable dt = dh.GetDataTable("select *from SanPham where MaLoai='" + maloai + "'");
            return ToList(dt);
        }
        public SanPhamList GetSanPhams(string maloai, int pageIndex, int pageSize, string
productName)
        {
            SanPhamList spl = new SanPhamList();
            List<Sanpham> l = new List<Sanpham>();
            SqlDataReader dr = dh.StoreReaders("LaySanPhamGiaLoai", maloai, pageIndex,
           pageSize, productName);
            while (dr.Read()) //Lấy về các sản phẩm của trang.
            {
                Sanpham s = new Sanpham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                l.Add(s);
            }
            spl.Sanphams = l;
            dr.NextResult();
            while (dr.Read())
                spl.totalCount = dr["totalCount"].ToString();
            return spl;
        }
        public List<Sanpham> GetProductCategory(string proID)
        {
            string sqlselect;
            if (proID != "")
            {
                sqlselect = "select*from SanPham where MaLoai ='" + proID + "'";

            }
            else
                sqlselect = "select*from SanPham";
            DataTable dt = dh.GetDataTable(sqlselect);
            return ToList(dt);
            
        }
    }
 
}
