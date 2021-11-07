using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc.Models;
using mvc.DAO;
namespace mvc.Buss
{
    public class CategoryBUS
    {
        CategoryDAO pd = new CategoryDAO();
        public List<LoaiSP> GetCategory()
        {
            return pd.GetCategory();
        }
        public List<LoaiSP> GetLoaiSP()
        {
            return pd.GetLoaiSP();
        }
    }
}