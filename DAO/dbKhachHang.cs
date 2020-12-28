using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DAO
{
    public class dbKhachHang
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da;
        SqlParameter oblogin;
        SqlCommand com;
        DataSet ds;
        SqlDataReader dr;
        public int Client_Login(KhachHang kh)
        {
            com = new SqlCommand("sp_Client_login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserName",kh.TaiKhoanDangNhap);
            com.Parameters.AddWithValue("@PassWord", kh.MatKhau);
            oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.Direction = ParameterDirection.Output;
            oblogin.SqlDbType = SqlDbType.Bit;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }
        public void Register(KhachHang kh)
        {
            com = new SqlCommand("REGISTRATION", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TenKhachHang", kh.TenKhachHang);
            com.Parameters.AddWithValue("@TaiKhoanDangNhap", kh.TaiKhoanDangNhap);
            com.Parameters.AddWithValue("@MatKhau", kh.MatKhau);
            com.Parameters.AddWithValue("@Email", kh.Email);
            com.Parameters.AddWithValue("@GioiTinh", kh.GioiTinh);
            com.Parameters.AddWithValue("@SDT", kh.SDT);
            com.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public KhachHang Get_Info(string TK)
        {
            com = new SqlCommand("GET_INFO", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TaiKhoanDangNhap", TK);
            con.Open();
            dr = com.ExecuteReader();
            KhachHang kh = new KhachHang();
            while (dr.Read())
            {
                kh.MaKhachHang = Convert.ToInt32(dr["MaKhachHang"].ToString());
                kh.TenKhachHang = dr["TenKhachHang"].ToString();
                kh.TaiKhoanDangNhap = dr["TaiKhoanDangNhap"].ToString();
                kh.MatKhau = dr["MatKhau"].ToString();
                kh.Email = dr["Email"].ToString();
                kh.GioiTinh = dr["GioiTinh"].ToString();
                kh.SDT = dr["SDT"].ToString();
                kh.DiaChi = dr["DiaChi"].ToString();
            }
            return kh;
        }
    }
}
