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
    public class dbDienThoai
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand com;
        DataSet ds;
        public DataSet Search_Product(string keyword)
        {
            com = new SqlCommand("SEARCH_PRODUCT", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@KeyWord", keyword);
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Get_DienThoai()
        {
            com = new SqlCommand("SP_GETDATA_DienThoai", con);
            com.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Get_DienThoai_byMaLoai(int maloai)
        {
            com = new SqlCommand("sp_getdata_DienThoai_byMaLoai", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaLoai", maloai);
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Get_DienThoai_Data()
        {
            com = new SqlCommand("getdata_DienThoai", con);
            com.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        DienThoaiList splist = new DienThoaiList();
        public DienThoaiList Get_Paging_DienThoai(int pageindex, int pagesize)
        {
            com = new SqlCommand("sp_page_DienThoai", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Pageindex", pageindex);
            com.Parameters.AddWithValue("@Pagesize", pagesize);

            con.Open();
            dr = com.ExecuteReader();
            List<DienThoai> list = new List<DienThoai>();
            while (dr.Read())
            {
                DienThoai dt = new DienThoai();

                dt.MaDienThoai = int.Parse(dr["MaDienThoai"].ToString());
                dt.TenDienThoai = dr["TenDienThoai"].ToString();
                dt.MaLoai = Convert.ToInt32(dr["MaLoai"].ToString());
                dt.HinhAnh = dr["HinhAnh"].ToString();
                dt.KichThuocManHinh = dr["KichThuocManHinh"].ToString();
                dt.DoPhanGiai = dr["DoPhanGiai"].ToString();
                dt.HeDieuHanh = dr["HeDieuHanh"].ToString();
                dt.ChipXuLy = dr["ChipXuLy"].ToString();
                dt.CameraSau = dr["CameraSau"].ToString();
                dt.CameraTruoc = dr["CameraTruoc"].ToString();
                dt.DungLuongPin = dr["DungLuongPin"].ToString();
                dt.TheSim = dr["TheSim"].ToString();
                list.Add(dt);
            }
            dr.NextResult();
            while (dr.Read())
            {
                splist.totalcount = Convert.ToInt32(dr["totalcount"]);
            }
            splist.listphone = list;
            return splist;
        }
        public void Add_Phone(DienThoai dt)
        {
            SqlCommand com = new SqlCommand("sp_Phone_add", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TenDienThoai", dt.TenDienThoai);
            com.Parameters.AddWithValue("@MaLoai", dt.MaLoai);
            com.Parameters.AddWithValue("@HinhAnh", dt.HinhAnh);
            com.Parameters.AddWithValue("@KichThuocManHinh", dt.KichThuocManHinh);
            com.Parameters.AddWithValue("@DoPhanGiai", dt.DoPhanGiai);
            com.Parameters.AddWithValue("@HeDieuHanh", dt.HeDieuHanh);
            com.Parameters.AddWithValue("@ChipXuLy", dt.ChipXuLy);
            com.Parameters.AddWithValue("@CameraSau", dt.CameraSau);
            com.Parameters.AddWithValue("@CameraTruoc", dt.CameraTruoc);
            com.Parameters.AddWithValue("@DungLuongPin", dt.DungLuongPin);
            com.Parameters.AddWithValue("@TheSim", dt.TheSim);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Update_Phone(DienThoai dt)
        {
            SqlCommand com = new SqlCommand("sp_Phone_update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaDienThoai", dt.MaDienThoai);
            com.Parameters.AddWithValue("@TenDienThoai", dt.TenDienThoai);
            com.Parameters.AddWithValue("@HinhAnh", dt.HinhAnh);
            com.Parameters.AddWithValue("@KichThuocManHinh", dt.KichThuocManHinh);
            com.Parameters.AddWithValue("@DoPhanGiai", dt.DoPhanGiai);
            com.Parameters.AddWithValue("@HeDieuHanh", dt.HeDieuHanh);
            com.Parameters.AddWithValue("@ChipXuLy", dt.ChipXuLy);
            com.Parameters.AddWithValue("@CameraSau", dt.CameraSau);
            com.Parameters.AddWithValue("@CameraTruoc", dt.CameraTruoc);
            com.Parameters.AddWithValue("@DungLuongPin", dt.DungLuongPin);
            com.Parameters.AddWithValue("@TheSim", dt.TheSim);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public void Delete_Phone(int MaDienThoai)
        {
            SqlCommand com = new SqlCommand("sp_Phone_delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaDienThoai", MaDienThoai);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Get_DienThoai_byid(int id)
        {
            SqlCommand com = new SqlCommand("sp_DienThoai_id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaDienThoai", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DienThoai get_chitiet(int ma)
        {
            com = new SqlCommand("get_chitiet", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaDienThoai", ma);
            con.Open();
            dr = com.ExecuteReader();
            DienThoai dt = new DienThoai();
            while (dr.Read())
            {
                dt.MaDienThoai = int.Parse(dr["MaDienThoai"].ToString());
                dt.TenDienThoai = dr["TenDienThoai"].ToString();
                dt.MaLoai = Convert.ToInt32(dr["MaLoai"].ToString());
                dt.HinhAnh = dr["HinhAnh"].ToString();
                dt.KichThuocManHinh = dr["KichThuocManHinh"].ToString();
                dt.DoPhanGiai = dr["DoPhanGiai"].ToString();
                dt.HeDieuHanh = dr["HeDieuHanh"].ToString();
                dt.ChipXuLy = dr["ChipXuLy"].ToString();
                dt.CameraSau = dr["CameraSau"].ToString();
                dt.CameraTruoc = dr["CameraTruoc"].ToString();
                dt.DungLuongPin = dr["DungLuongPin"].ToString();
                dt.TheSim = dr["TheSim"].ToString();
                dt.Ram = Convert.ToInt32(dr["Ram"].ToString());
                dt.BoNhoTrong = Convert.ToInt32(dr["BoNhoTrong"].ToString());
                dt.Gia = Convert.ToInt32(dr["Gia"].ToString());
            }
            return dt;
        }
        public List<string> ListName(string keyword)
        {
            com = new SqlCommand("get_ListName", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Ten", keyword);
            con.Open();
            dr = com.ExecuteReader();
            List<string> name = new List<string>();
            while (dr.Read())
            {
                string word = dr["TenDienThoai"].ToString();
                name.Add(word);
            }
            return name;
        }
    }
}
