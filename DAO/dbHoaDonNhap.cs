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
    public class dbHoaDonNhap
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataReader dr;
        SqlCommand com;
        HoaDonNhapList _dblist = new HoaDonNhapList();
        public HoaDonNhapList Get_Paging_HoaDonNhap(int pageindex, int pagesize)
        {
            com = new SqlCommand("sp_page_HoaDonNhap", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Pageindex", pageindex);
            com.Parameters.AddWithValue("@Pagesize", pagesize);

            con.Open();
            dr = com.ExecuteReader();
            List<HoaDonNhap> list = new List<HoaDonNhap>();
            while (dr.Read())
            {
                HoaDonNhap _db = new HoaDonNhap();
                _db.MaHoaDonNhap = int.Parse(dr["MaHoaDonNhap"].ToString());
                _db.MaNCC = int.Parse(dr["MaNCC"].ToString());
                _db.TongTien = int.Parse(dr["TongTien"].ToString());
                _db.NgayNhap = dr["NgayNhap"].ToString();
                list.Add(_db);
            }
            dr.NextResult();
            while (dr.Read())
            {
                _dblist.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            _dblist.listbill = list;
            return _dblist;
        }
        public void Add_Bill(HoaDonNhap hd)
        {
            com = new SqlCommand("ADD_BILL", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaNCC", hd.MaNCC);
            com.Parameters.AddWithValue("@TongTien", hd.TongTien);
            com.Parameters.AddWithValue("@NgayNhap", hd.NgayNhap);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Get_HoaDonNhap()
        {
            SqlCommand com = new SqlCommand("SP_GETDATA_HoaDonNhap", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
