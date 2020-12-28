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
        DonHangList _dblist = new DonHangList();
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
                DonHang _db = new DonHang();
                _db.MaDonHang = dr["MaDonHang"].ToString();
                _db.MaKhachHang = int.Parse(dr["MaKhachHang"].ToString());
                _db.NgayTao = dr["NgayTao"].ToString();
                _db.TrangThaiDonHang = dr["TrangThaiDonHang"].ToString();
                _db.TongTien = int.Parse(dr["TongTien"].ToString());
                list.Add(_db);
            }
            dr.NextResult();
            while (dr.Read())
            {
                _dblist.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            _dblist.listdonhang = list;
            return _dblist;
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
                DonHang _db = new DonHang();
                _db.MaDonHang = dr["MaDonHang"].ToString();
                _db.MaKhachHang = int.Parse(dr["MaKhachHang"].ToString());
                _db.NgayTao = dr["NgayTao"].ToString();
                _db.TrangThaiDonHang = dr["TrangThaiDonHang"].ToString();
                _db.TongTien = int.Parse(dr["TongTien"].ToString());
                list.Add(_db);
            }
            dr.NextResult();
            while (dr.Read())
            {
                _dblist.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            _dblist.listdonhang = list;
            return _dblist;
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
                DonHang _db = new DonHang();
                _db.MaDonHang = dr["MaDonHang"].ToString();
                _db.MaKhachHang = int.Parse(dr["MaKhachHang"].ToString());
                _db.NgayTao = dr["NgayTao"].ToString();
                _db.TrangThaiDonHang = dr["TrangThaiDonHang"].ToString();
                _db.TongTien = int.Parse(dr["TongTien"].ToString());
                list.Add(_db);
            }
            dr.NextResult();
            while (dr.Read())
            {
                _dblist.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            _dblist.listdonhang = list;
            return _dblist;
        }
        public void Comfirm_ThisOrder(string value)
        {
            com = new SqlCommand("ComfirmThisOrder", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaDonHang", value);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void ComfirmShipping(string value)
        {
            com = new SqlCommand("ComfirmShipping", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaDonHang", value);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void UnThisOrder(string value)
        {
            com = new SqlCommand("UnThisOrder", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaDonHang", value);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void ConfirmChange(string value)
        {
            com = new SqlCommand("ConfirmChange", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaDonHang", value);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet View_Details(string value)
        {
            com = new SqlCommand("view_details", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaDonHang", value);
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void Add_DonHang(DonHang ch)
        {
            SqlCommand com = new SqlCommand("ADD_DonHang", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaDonHang", ch.MaDonHang);
            com.Parameters.AddWithValue("@MaKhachHang", ch.MaKhachHang);
            com.Parameters.AddWithValue("@NgayTao", ch.NgayTao);
            com.Parameters.AddWithValue("@TrangThaiDonHang", ch.TrangThaiDonHang);
            com.Parameters.AddWithValue("@TongTien", ch.TongTien);
            com.Parameters.AddWithValue("@TenKhachHang", ch.TenKhachHang);
            com.Parameters.AddWithValue("@DiaChi", ch.DiaChi);
            com.Parameters.AddWithValue("@SDT", ch.SDT);
            com.Parameters.AddWithValue("@GhiChu", ch.GhiChu);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Add_ChiTietDonHang(ChiTietDonHang ch)
        {
            SqlCommand com = new SqlCommand("ADD_ChiTietDonHang", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaDonHang", ch.MaDonHang);
            com.Parameters.AddWithValue("@MaCauHinh", ch.MaCauHinh);
            com.Parameters.AddWithValue("@SoLuong", ch.SoLuong);
            com.Parameters.AddWithValue("@DonGia", ch.DonGia);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
