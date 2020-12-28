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
    public class dbGioHang
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da;
        SqlParameter oblogin;
        SqlCommand com;
        DataSet ds;
        SqlDataReader dr;
        public DataSet Get_Cart(int MaKhach)
        {
            com = new SqlCommand("Get_GioHang", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaKhachHang", MaKhach);
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void Cart_ASC(string MaCT)
        {
            com = new SqlCommand("COUNT_ASC", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaChiTietGioHang", MaCT);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            
        }
        public void Cart_DESC(string MaCT)
        {
            com = new SqlCommand("COUNT_DESC", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaChiTietGioHang", MaCT);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Add_To_Cart(int MaKhachHang,int MaCauHinh,int DonGia,int SoLuong)
        {
            com = new SqlCommand("Add_To_Cart", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaKhachHang", MaKhachHang);
            com.Parameters.AddWithValue("@MaCauHinh", MaCauHinh);
            com.Parameters.AddWithValue("@DonGia", DonGia);
            com.Parameters.AddWithValue("@SoLuong", SoLuong);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            //SqlParameter[] parm = new SqlParameter[]
            //{
            //    new SqlParameter("@MaKhachHang",SqlDbType.Int),
            //    new SqlParameter("@MaCauHinh",SqlDbType.Int),
            //    new SqlParameter("@DonGia",SqlDbType.Int),
            //    new SqlParameter("@SoLuong",SqlDbType.Int)
            //};
            //parm[0].Value = MaKhachHang;
            //parm[1].Value = MaCauHinh;
            //parm[2].Value = DonGia;
            //parm[3].Value = SoLuong;
            //DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "Add_To_Cart", parm);
        }
        public void DELETE_PRODUCTCART(string MaCT)
        {
            com = new SqlCommand("DELETE_PRODUCT_CART", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaChiTietGioHang", MaCT);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
