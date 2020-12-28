using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GioHang
    {
        public int MaKhachHang { get; set; }
        public string MaGioHang { get; set; }
        public string MaChiTietGioHang { get; set; }
        public string HinhAnh { get; set; }
        public int MaCauHinh { get; set; }
        public int MaDienThoai { get; set; }
        public string TenDienThoai { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
    }
}
