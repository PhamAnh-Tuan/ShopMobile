using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;
namespace BUS
{
    public class HoaDonNhapBUS
    {
        DataSet ds;
        dbHoaDonNhap _db = new dbHoaDonNhap();
        public HoaDonNhapList Get_Paging_HoaDonNhap(int pageindex, int pagesize)
        {
            return _db.Get_Paging_HoaDonNhap(pageindex, pagesize);
        }
        public string Add_Bill(HoaDonNhap hd)
        {
            string res = string.Empty;
            try
            {
                _db.Add_Bill(hd);
                res = "Data inserted Sucessfuly";
            }
            catch (Exception)
            {
                res = "Failed";

            }
            return res;
        }
        public List<HoaDonNhap> Get_HoaDonNhap()
        {
            ds = _db.Get_HoaDonNhap();
            List<HoaDonNhap> l = new List<HoaDonNhap>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                l.Add(new HoaDonNhap
                {
                    MaHoaDonNhap = Convert.ToInt32(dr["MaHoaDonNhap"].ToString()),
                    MaNCC = Convert.ToInt32(dr["MaNCC"].ToString()),
                    TongTien = Convert.ToInt32(dr["TongTien"].ToString()),
                    NgayNhap = dr["NgayNhap"].ToString()
                });
            }
            return l;
        }
    }
}
