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
    }
}
