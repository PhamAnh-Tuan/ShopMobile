using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace BUS
{
    public class TinTucBUS
    {
        DataSet ds;
        dbTinTuc _db = new dbTinTuc();
        public List<TinTuc> get_TinTuc()
        {
            ds = _db.get_TinTuc();
            List<TinTuc> l = new List<TinTuc>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                l.Add(new TinTuc
                {
                    MaTinTuc = int.Parse(dr["MaTinTuc"].ToString()),
                    TieuDe = dr["TieuDe"].ToString(),
                    Anh = dr["Anh"].ToString(),
                    NoiDung=Tools.ChuanHoaXau(dr["NoiDung"].ToString()),
                    NgayDang=dr["NgayDang"].ToString(),
                });                          
            }
            return l;
        }
        public TinTuc view_TinTuc(int ma)
        {
            return _db.view_TinTuc(ma);
        }
        //Admin
        public List<TinTuc> Get_News_byid(int id)
        {
            DataSet ds = _db.Get_News_byid(id);
            List<TinTuc> list = new List<TinTuc>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new TinTuc
                {
                    MaTinTuc = Convert.ToInt32(dr["MaTinTuc"]),
                    TieuDe = dr["TieuDe"].ToString(),
                    Anh = dr["Anh"].ToString(),
                    NoiDung = dr["NoiDung"].ToString(),
                    NgayDang = dr["NgayDang"].ToString()
                });
            }
            return list;
        }
        public TinTucList Get_Paging_TinTuc(int pageindex, int pagesize)
        {
            TinTucList rslist = new TinTucList();
            rslist = _db.Get_Paging_TinTuc(pagesize, pageindex);
            return rslist;
        }
        public string Add_News(TinTuc tt)
        {
            string result = string.Empty;
            try
            {
                _db.Add_News(tt);
                result = "Data inserted Sucessfuly";
            }
            catch (Exception)
            {
                result = "Failed";

            }
            return result;
        }
        public string Update_News(TinTuc tt)
        {
            string res = string.Empty;
            try
            {
                _db.Update_News(tt);
                res = "Updated";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return res;
        }
        public string Delete_News(int id)
        {
            string res = string.Empty;
            try
            {
                _db.Delete_News(id);
                res = "data deleted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return res;
        }
    }
}
