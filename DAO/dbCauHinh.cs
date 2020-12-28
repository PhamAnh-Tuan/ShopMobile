using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DTO;
namespace DAO
{
    public class dbCauHinh
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand com;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader dr;
        public CauHinhList Get_Paging_Confi(int pagesize, int pageindex)
        {

            SqlCommand com = new SqlCommand("sp_page_CauHinh", con);

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Pageindex", pageindex);


            com.Parameters.AddWithValue("@Pagesize", pagesize);

            con.Open();

            SqlDataReader dr = com.ExecuteReader();
            CauHinhList listconfi = new CauHinhList();
            List<CauHinh> list = new List<CauHinh>();
            CauHinh ch;
            while (dr.Read())
            {
                ch = new CauHinh();
                ch.MaCauHinh = Convert.ToInt32(dr["MaCauHinh"].ToString());
                ch.Ram = Convert.ToInt32(dr["Ram"].ToString());
                ch.BoNhoTrong = Convert.ToInt32(dr["BoNhoTrong"].ToString());
                ch.Gia = Convert.ToInt32(dr["Gia"].ToString());
                ch.SoLuong = Convert.ToInt32(dr["SoLuong"].ToString());
                ch.MaDienThoai = Convert.ToInt32(dr["MaDienThoai"].ToString());
                list.Add(ch);
            }

            dr.NextResult();

            while (dr.Read())
            {
                listconfi.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            listconfi.listconfiguration = list;
            return listconfi;
        }
        public void Add_Configuration(CauHinh ch)
        {
            SqlCommand com = new SqlCommand("ADD_CONFIGURATION", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Ram", ch.Ram);
            com.Parameters.AddWithValue("@BoNhoTrong", ch.BoNhoTrong);
            com.Parameters.AddWithValue("@Gia", ch.Gia);
            com.Parameters.AddWithValue("@SoLuong", ch.SoLuong);
            com.Parameters.AddWithValue("@MaDienThoai", ch.MaDienThoai);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public CauHinh Get_Configuration_ByID(int ID)
        {
            SqlCommand com = new SqlCommand("SP_CONFIGURATION_ID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaCauHinh", ID);
            con.Open();
            dr = com.ExecuteReader();
            CauHinh ch = new CauHinh();
            while (dr.Read())
            {
                ch.MaCauHinh = Convert.ToInt32(dr["MaCauHinh"].ToString());
                ch.Ram = Convert.ToInt32(dr["Ram"].ToString());
                ch.BoNhoTrong = Convert.ToInt32(dr["BoNhoTrong"].ToString());
                ch.Gia = Convert.ToInt32(dr["Gia"].ToString());
                ch.SoLuong = Convert.ToInt32(dr["SoLuong"].ToString());
            }
            return ch;
        }
        public void Update_Configuration(CauHinh ch)
        {
            SqlCommand com = new SqlCommand("UPDATE_CONFIGURATION", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaCauHinh", ch.MaCauHinh);
            com.Parameters.AddWithValue("@Ram", ch.Ram);
            com.Parameters.AddWithValue("@BoNhoTrong", ch.BoNhoTrong);
            com.Parameters.AddWithValue("@Gia", ch.Gia);
            com.Parameters.AddWithValue("@SoLuong", ch.SoLuong);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public void Delete_Configuration(int MaCauHinh)
        {
            SqlCommand com = new SqlCommand("DELETE_CONFIGURATION", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaCauHinh", MaCauHinh);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Get_CauHinh()
        {
            SqlCommand com = new SqlCommand("SP_GETDATA_CauHinh", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
