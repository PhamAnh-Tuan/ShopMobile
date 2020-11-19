using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class dbDonHang
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand com;
        DataSet ds;
        DonHangList dhlist = new DonHangList();
        public DonHangList Get_Paging_DonHangChuaXacThuc(int pageindex, int pagesize)
        {
            com = new SqlCommand("sp_page_DonHangChuaXacThuc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Pageindex", pageindex);
            com.Parameters.AddWithValue("@Pagesize", pagesize);

            con.Open();
            dr = com.ExecuteReader();
            List<DonHang> list = new List<DonHang>();
            while (dr.Read())
            {
                DonHang dh = new DonHang();
                dh.MaDonHang = int.Parse(dr["MaDonHang"].ToString());
                dh.MaKhachHang = int.Parse(dr["MaKhachHang"].ToString());
                dh.NgayTao = dr["NgayTao"].ToString();
                dh.TrangThaiDonHang = dr["TrangThaiDonHang"].ToString();
                dh.TongTien = int.Parse(dr["TongTien"].ToString());
                list.Add(dh);
            }
            dr.NextResult();
            while (dr.Read())
            {
                dhlist.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            dhlist.listdonhang = list;
            return dhlist;
        }
        public DonHangList Get_Paging_DonHangDaXacThuc(int pageindex, int pagesize)
        {
            com = new SqlCommand("sp_page_DonHangDaXacThuc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Pageindex", pageindex);
            com.Parameters.AddWithValue("@Pagesize", pagesize);

            con.Open();
            dr = com.ExecuteReader();
            List<DonHang> list = new List<DonHang>();
            while (dr.Read())
            {
                DonHang dh = new DonHang();
                dh.MaDonHang = int.Parse(dr["MaDonHang"].ToString());
                dh.MaKhachHang = int.Parse(dr["MaKhachHang"].ToString());
                dh.NgayTao = dr["NgayTao"].ToString();
                dh.TrangThaiDonHang = dr["TrangThaiDonHang"].ToString();
                dh.TongTien = int.Parse(dr["TongTien"].ToString());
                list.Add(dh);
            }
            dr.NextResult();
            while (dr.Read())
            {
                dhlist.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            dhlist.listdonhang = list;
            return dhlist;
        }
        public DonHangList Get_Paging_DonHangDaGiao(int pageindex, int pagesize)
        {
            com = new SqlCommand("sp_page_DonHangDaGiao", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Pageindex", pageindex);
            com.Parameters.AddWithValue("@Pagesize", pagesize);

            con.Open();
            dr = com.ExecuteReader();
            List<DonHang> list = new List<DonHang>();
            while (dr.Read())
            {
                DonHang dh = new DonHang();
                dh.MaDonHang = int.Parse(dr["MaDonHang"].ToString());
                dh.MaKhachHang = int.Parse(dr["MaKhachHang"].ToString());
                dh.NgayTao = dr["NgayTao"].ToString();
                dh.TrangThaiDonHang = dr["TrangThaiDonHang"].ToString();
                dh.TongTien = int.Parse(dr["TongTien"].ToString());
                list.Add(dh);
            }
            dr.NextResult();
            while (dr.Read())
            {
                dhlist.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            dhlist.listdonhang = list;
            return dhlist;
        }
    }
}
