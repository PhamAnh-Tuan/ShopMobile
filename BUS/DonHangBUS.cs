using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;
using System.Data.SqlClient;
namespace BUS
{
    public class DonHangBUS
    {
        DataSet ds;
        dbDonHang _db = new dbDonHang();
        public DonHangList Get_Paging_DonHangChuaXacThuc(int pageindex,int pagesize)
        {
            DonHangList _dblist = new DonHangList();
            _dblist = _db.Get_Paging_DonHangChuaXacThuc(pageindex, pagesize);
            return _dblist;
        }
        public DonHangList Get_Paging_DonHangDaXacThuc(int pageindex, int pagesize)
        {
            DonHangList _dblist = new DonHangList();
            _dblist = _db.Get_Paging_DonHangDaXacThuc(pageindex, pagesize);
            return _dblist;
        }
        public DonHangList Get_Paging_DonHangDaGiao(int pageindex, int pagesize)
        {
            DonHangList _dblist = new DonHangList();
            _dblist = _db.Get_Paging_DonHangDaGiao(pageindex, pagesize);
            return _dblist;
        }
        public string Comfirm_ThisOrder(string value)
        {
            string res = string.Empty;
            try
            {
                _db.Comfirm_ThisOrder(value);
                res = "Đã xác thực";
            }
            catch
            {
                res = "Xác thực thất bại";
            }
            return res;
        }
        public List<ChiTietDonHang> View_Details(string value)
        {
            ds = _db.View_Details(value);
            List<ChiTietDonHang> l = new List<ChiTietDonHang>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                l.Add(new ChiTietDonHang
                {
                    MaChiTietDonHang=Convert.ToInt32(dr["MaChiTietDonHang"].ToString()),
                    MaCauHinh = Convert.ToInt32(dr["MaDienThoai"].ToString()),
                    SoLuong = Convert.ToInt32(dr["SoLuong"].ToString()),
                    DonGia = Convert.ToInt32(dr["DonGia"].ToString()),
                });
            }
            return l;
        }
    }
}
