using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class dbLoaiDT
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public DataSet Get_LoaiDT()
        {
            SqlCommand com = new SqlCommand("sp_getdata_LoaiDT", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        LoaiDTList splist = new LoaiDTList();

        public LoaiDTList Get_Paging_data(int pagesize, int pageindex)
        {

            SqlCommand com = new SqlCommand("Sp_Get_data", con);

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Pageindex", pageindex);


            com.Parameters.AddWithValue("@Pagesize", pagesize);

            con.Open();

            SqlDataReader dr = com.ExecuteReader();
            List<LoaiDT> list = new List<LoaiDT>();

            while (dr.Read())
            {
                LoaiDT rs = new LoaiDT();
                rs.MaLoai = int.Parse(dr["MaLoai"].ToString());
                rs.TenLoai = (dr["TenLoai"]).ToString();
                rs.XuatXu = dr["XuatXu"].ToString();

                list.Add(rs);

            }

            dr.NextResult();

            while (dr.Read())
            {
                splist.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            splist.registerdata = list;
            return splist;
        }
        public void Add_TypePhone(LoaiDT dt)
        {
            SqlCommand com = new SqlCommand("AddTypePhone", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TenLoai", dt.TenLoai);
            com.Parameters.AddWithValue("@XuatXu", dt.XuatXu);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Update_TypePhone(LoaiDT dt)
        {
            SqlCommand com = new SqlCommand("sp_TypePhone_update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaLoai", dt.MaLoai);
            com.Parameters.AddWithValue("@TenLoai", dt.TenLoai);
            com.Parameters.AddWithValue("@XuatXu", dt.XuatXu);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public void Delete_TypePhone(int MaLoai)
        {
            SqlCommand com = new SqlCommand("sp_TypePhone_delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaLoai", MaLoai);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Get_LoaiDT_byid(int id)
        {
            SqlCommand com = new SqlCommand("sp_LoaiDT_id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaLoai", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
