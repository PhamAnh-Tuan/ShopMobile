using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BUS
{
    public class DatHangBUS
    {
        public void DatHang(KhachHang k,DonHang d,List<ChiTietDonHang> lct)
        {
            string mdh = Guid.NewGuid().ToString();
            d.MaDonHang = mdh;
            for(int i = 0; i < lct.Count; i++)
            {
                lct[i].MaDonHang = mdh;
            }
        }
    }
}
