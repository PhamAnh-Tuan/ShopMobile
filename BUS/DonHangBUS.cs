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
        dbDonHang _db = new dbDonHang();
        public DonHangList Get_Paging_DonHangChuaXacThuc(int pageindex,int pagesize)
        {
            DonHangList dhlist = new DonHangList();
            dhlist = _db.Get_Paging_DonHangChuaXacThuc(pageindex, pagesize);
            return dhlist;
        }
        public DonHangList Get_Paging_DonHangDaXacThuc(int pageindex, int pagesize)
        {
            DonHangList dhlist = new DonHangList();
            dhlist = _db.Get_Paging_DonHangDaXacThuc(pageindex, pagesize);
            return dhlist;
        }
        public DonHangList Get_Paging_DonHangDaGiao(int pageindex, int pagesize)
        {
            DonHangList dhlist = new DonHangList();
            dhlist = _db.Get_Paging_DonHangDaGiao(pageindex, pagesize);
            return dhlist;
        }
    }
}
