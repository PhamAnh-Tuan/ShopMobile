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
    public class dbCTHoaDonNhap
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand com;
        DataSet ds;
        
        CTHoaDonNhapList splist = new CTHoaDonNhapList();
        public CTHoaDonNhapList Get_Paging_CTHoaDonNhap(int pageindex, int pagesize)
        {
            com = new SqlCommand("sp_page_CTHoaDonNhap", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Pageindex", pageindex);
            com.Parameters.AddWithValue("@Pagesize", pagesize);

            con.Open();
            dr = com.ExecuteReader();
            List<CTHoaDonNhap> list = new List<CTHoaDonNhap>();
            while (dr.Read())
            {
                CTHoaDonNhap ct = new CTHoaDonNhap();

                ct.MaCTHoaDonNhap = int.Parse(dr["MaCTHoaDonNhap"].ToString());
                ct.MaHoaDonNhap = int.Parse(dr["MaHoaDonNhap"].ToString());
                ct.MaCauHinh = int.Parse(dr["MaCauHinh"].ToString());
                ct.SoLuong = int.Parse(dr["SoLuong"].ToString());
                ct.DonGia = int.Parse(dr["DonGia"].ToString());
                list.Add(ct);
            }
            dr.NextResult();
            while (dr.Read())
            {
                splist.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            splist.listBill_Details = list;
            return splist;
        }
        public void Add_BillDetails(CTHoaDonNhap ct)
        {
            SqlCommand com = new SqlCommand("ADD_BILL_DETAILS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaHoaDonNhap", ct.MaHoaDonNhap);
            com.Parameters.AddWithValue("@MaCauHinh", ct.MaCauHinh);
            com.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
            com.Parameters.AddWithValue("@DonGia", ct.DonGia);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet GET_BillDetails_ID(int MaCTHoaDonNhap)
        {
            com = new SqlCommand("GET_BILLDETAILS_ID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaCTHoaDonNhap", MaCTHoaDonNhap);
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void Update_BillDetails(CTHoaDonNhap ct)
        {
            SqlCommand com = new SqlCommand("UPDATE_BILL_DETAILS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaCTHoaDonNhap", ct.MaCTHoaDonNhap);
            com.Parameters.AddWithValue("@MaHoaDonNhap", ct.MaHoaDonNhap);
            com.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
            com.Parameters.AddWithValue("@DonGia", ct.DonGia);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public void Delete_BillDetails(int MaCTHoaDonNhap)
        {
            SqlCommand com = new SqlCommand("DELETE_BILL_DETAILS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaCTHoaDonNhap", MaCTHoaDonNhap);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
