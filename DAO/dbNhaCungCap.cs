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
    public class dbNhaCungCap
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        NhaCungCapList suplist = new NhaCungCapList();
        public NhaCungCapList Get_Paging_Supplier(int pagesize, int pageindex)
        {

            SqlCommand com = new SqlCommand("sp_page_NCC", con);

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Pageindex", pageindex);


            com.Parameters.AddWithValue("@Pagesize", pagesize);

            con.Open();

            SqlDataReader dr = com.ExecuteReader();
            List<NhaCungCap> list = new List<NhaCungCap>();

            while (dr.Read())
            {
                NhaCungCap rs = new NhaCungCap();
                rs.MaNCC = Convert.ToInt32(dr["MaNCC"].ToString());
                rs.TenNCC = (dr["TenNCC"]).ToString();
                rs.DiaChi = dr["DiaChi"].ToString();
                rs.SDT = dr["SDT"].ToString();
                rs.Email = dr["Email"].ToString();
                list.Add(rs);
            }

            dr.NextResult();

            while (dr.Read())
            {
                suplist.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            suplist.listsupplier = list;
            return suplist;
        }
        public void Add_Supplier(NhaCungCap ncc)
        {
            SqlCommand com = new SqlCommand("ADD_SUPPLIER", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
            com.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
            com.Parameters.AddWithValue("@SDT", ncc.SDT);
            com.Parameters.AddWithValue("@Email", ncc.Email);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Delete_Supplier(int MaNCC)
        {
            SqlCommand com = new SqlCommand("DELETE_SUPPLIER", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaNCC", MaNCC);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
