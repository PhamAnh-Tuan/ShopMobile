using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonDatHang
    {
        public KhachHang Khach { get; set; }
        public double TongTien { get; set; }
        public List<ChiTietDonHang> LCTDonHang { get; set; }
    }
}
