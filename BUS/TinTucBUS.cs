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
    }
}
