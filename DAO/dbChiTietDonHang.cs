using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class dbChiTietDonHang
    {
        public void  LuuChiTietDonHang(List<ChiTietDonHang> lct)
        {
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("MaChiTietDonHang");
            DataColumn c2 = new DataColumn("MaCauHinh");
            DataColumn c3 = new DataColumn("SoLuong");
            DataColumn c4 = new DataColumn("DonGia");
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            for(int i = 0; i < lct.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[1] = lct[i].MaChiTietDonHang;
                dr[1] = lct[i].MaCauHinh;
                dr[1] = lct[i].SoLuong;
                dr[1] = lct[i].DonGia;
                dt.Rows.Add(dr);
            }           
        }
    }
}
