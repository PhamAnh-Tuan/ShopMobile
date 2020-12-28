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
    public class dbTinTuc
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds;
        SqlCommand com;
        SqlDataReader dr;
        public DataSet get_TinTuc()
        {
            com = new SqlCommand("sp_getTinTuc", con);
            com.CommandType = CommandType.StoredProcedure;
            da =new SqlDataAdapter(com);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public TinTuc view_TinTuc(int ma)
        {
            con.Open();
            com = new SqlCommand("view_TinTuc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaTinTuc", ma);
            
            dr = com.ExecuteReader();
            TinTuc t=new TinTuc();
            while (dr.Read())
            {
                t.MaTinTuc = Convert.ToInt32(dr["MaTinTuc"].ToString());
                t.TieuDe = dr["TieuDe"].ToString();
                t.Anh = dr["Anh"].ToString();
                t.NoiDung = dr["NoiDung"].ToString();
                t.NgayDang = dr["NgayDang"].ToString();
            }
            return t;
        }
        TinTucList splist = new TinTucList();

        public TinTucList Get_Paging_TinTuc(int pagesize, int pageindex)
        {

            SqlCommand com = new SqlCommand("SP_PAGE_TinTuc", con);

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Pageindex", pageindex);


            com.Parameters.AddWithValue("@Pagesize", pagesize);

            con.Open();

            SqlDataReader dr = com.ExecuteReader();
            List<TinTuc> list = new List<TinTuc>();

            while (dr.Read())
            {
                TinTuc rs = new TinTuc();
                rs.MaTinTuc = int.Parse(dr["MaTinTuc"].ToString());
                rs.TieuDe = (dr["TieuDe"]).ToString();
                rs.NoiDung = dr["NoiDung"].ToString();
                rs.Anh = dr["Anh"].ToString();
                rs.NgayDang = dr["NgayDang"].ToString();
                list.Add(rs);

            }

            dr.NextResult();

            while (dr.Read())
            {
                splist.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            splist.listnew = list;
            return splist;
        }
        public void Add_News(TinTuc tt)
        {
            SqlCommand com = new SqlCommand("ADD_NEWS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TieuDe", tt.TieuDe);
            com.Parameters.AddWithValue("@Anh", tt.Anh);
            com.Parameters.AddWithValue("@NoiDung", tt.NoiDung);
            com.Parameters.AddWithValue("@NgayDang", tt.NgayDang);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Update_News(TinTuc tt)
        {
            SqlCommand com = new SqlCommand("UPDATE_NEWS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaTinTuc", tt.MaTinTuc);
            com.Parameters.AddWithValue("@TieuDe", tt.TieuDe);
            com.Parameters.AddWithValue("@Anh", tt.Anh);
            com.Parameters.AddWithValue("@NoiDung", tt.NoiDung);
            com.Parameters.AddWithValue("@NgayDang", tt.NgayDang);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public void Delete_News(int id)
        {
            SqlCommand com = new SqlCommand("DELETE_NEWS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaTinTuc", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Get_News_byid(int id)
        {
            SqlCommand com = new SqlCommand("SP_News_ID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaTinTuc", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
