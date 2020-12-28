using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace BUS
{
    public class GioHangBUS
    {
        DataSet ds;
        dbGioHang _db = new dbGioHang();
        public List<GioHang> Get_Cart(int MaKhach)
        {
            ds = _db.Get_Cart(MaKhach);
            List<GioHang> l = new List<GioHang>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                l.Add(new GioHang
                {
                    MaChiTietGioHang = dr["MaChiTietGioHang"].ToString(),
                    MaCauHinh = Convert.ToInt32(dr["MaCauHinh"]),
                    MaDienThoai = Convert.ToInt32(dr["MaDienThoai"]),
                    TenDienThoai = dr["TenDienThoai"].ToString(),
                    HinhAnh = dr["HinhAnh"].ToString(),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),
                    DonGia = Convert.ToInt32(dr["DonGia"]),
                }) ;
            }
            return l;
        }
        public void Cart_ASC(string MaCT)
        {
            _db.Cart_ASC(MaCT);

        }
        public void Cart_DESC(string MaCT)
        {
            _db.Cart_DESC(MaCT);
        }
        public void Add_To_Cart(int MaKhachHang, int MaCauHinh, int DonGia, int SoLuong)
        {
            _db.Add_To_Cart(MaKhachHang,MaCauHinh,DonGia,SoLuong);
        }
        public void DELETE_PRODUCTCART(string MaCT)
        {
            _db.DELETE_PRODUCTCART(MaCT);
        }
    }
}
