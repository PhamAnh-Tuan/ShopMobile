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
    }
}
