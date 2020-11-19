using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAO;
using System.Web.Mvc;

namespace BUS
{
    public class DienThoaiBUS
    {
        dbDienThoai dbDT = new dbDienThoai(); 
        DataSet ds;
        public List<DienThoai> Get_DienThoai10()
        {
            ds = dbDT.Get_DienThoai10();
            List<DienThoai> l = new List<DienThoai>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                l.Add(new DienThoai
                {
                    MaDienThoai = Convert.ToInt32(dr["MaDienThoai"]),
                    TenDienThoai = dr["TenDienThoai"].ToString(),
                    //MaLoai = Convert.ToInt32(dr["MaLoai"].ToString()),
                    HinhAnh = dr["HinhAnh"].ToString(),
                    KichThuocManHinh = dr["KichThuocManHinh"].ToString(),
                    DoPhanGiai = dr["DoPhanGiai"].ToString(),
                    HeDieuHanh = dr["HeDieuHanh"].ToString(),
                    ChipXuLy = dr["ChipXuLy"].ToString(),
                    CameraSau = dr["CameraSau"].ToString(),
                    CameraTruoc = dr["CameraTruoc"].ToString(),
                    DungLuongPin = dr["DungLuongPin"].ToString(),
                    TheSim = dr["TheSim"].ToString(),
                    Ram = Convert.ToInt32(dr["Ram"].ToString()),
                    BoNhoTrong = Convert.ToInt32(dr["BoNhoTrong"].ToString()),
                    Gia = Convert.ToInt32(dr["Gia"].ToString()),
                });
            }
            return l;
        }
        public List<DienThoai> Get_DienThoai_byMaLoai(string maloai)
        {
            ds = dbDT.Get_DienThoai_byMaLoai(maloai);
            List<DienThoai> l = new List<DienThoai>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                l.Add(new DienThoai
                {
                    MaDienThoai = Convert.ToInt32(dr["MaDienThoai"]),
                    TenDienThoai = dr["TenDienThoai"].ToString(),
                    MaLoai = Convert.ToInt32(dr["MaLoai"].ToString()),
                    HinhAnh = dr["HinhAnh"].ToString(),
                    KichThuocManHinh = dr["KichThuocManHinh"].ToString(),
                    DoPhanGiai = dr["DoPhanGiai"].ToString(),
                    HeDieuHanh = dr["HeDieuHanh"].ToString(),
                    ChipXuLy = dr["ChipXuLy"].ToString(),
                    CameraSau = dr["CameraSau"].ToString(),
                    CameraTruoc = dr["CameraTruoc"].ToString(),
                    DungLuongPin = dr["DungLuongPin"].ToString(),
                    TheSim = dr["TheSim"].ToString(),
                    Ram = int.Parse(dr["Ram"].ToString()),
                    BoNhoTrong = int.Parse(dr["BoNhoTrong"].ToString()),
                    Gia = int.Parse(dr["TheSim"].ToString()),
                });
            }
            return l;
        }
        public List<DienThoai> Get_DienThoai_byid(int id)
        {
            ds = dbDT.Get_DienThoai_byid(id);
            List<DienThoai> list = new List<DienThoai>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new DienThoai
                {
                    MaDienThoai = Convert.ToInt32(dr["MaDienThoai"]),
                    TenDienThoai = dr["TenDienThoai"].ToString(),
                    MaLoai = Convert.ToInt32(dr["MaLoai"].ToString()),
                    HinhAnh = dr["HinhAnh"].ToString(),
                    KichThuocManHinh = dr["KichThuocManHinh"].ToString(),
                    DoPhanGiai = dr["DoPhanGiai"].ToString(),
                    HeDieuHanh = dr["HeDieuHanh"].ToString(),
                    ChipXuLy = dr["ChipXuLy"].ToString(),
                    CameraSau = dr["CameraSau"].ToString(),
                    CameraTruoc = dr["CameraTruoc"].ToString(),
                    DungLuongPin = dr["DungLuongPin"].ToString(),
                    TheSim = dr["TheSim"].ToString(),
                });
            }
            return list;
        }
        public string Add_Phone(DienThoai dt)
        {
            string result = string.Empty;
            try
            {
                dbDT.Add_Phone(dt);
                result = "Data inserted Sucessfuly";
            }
            catch (Exception)
            {
                result = "Failed";

            }
            return result;
        }
        public string Update_Phone(DienThoai dt)
        {
            string res = string.Empty;
            try
            {
                dbDT.Update_Phone(dt);
                res = "Updated";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return res;
        }
        public string Delete_Phone(int id)
        {
            string res = string.Empty;
            try
            {
                dbDT.Delete_Phone(id);
                res = "data deleted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return res;
        }
        //Admin
        public DienThoaiList Get_Paging_DienThoai(int pageindex,int pagesize)
        {
            DienThoaiList rslist = new DienThoaiList();
            rslist = dbDT.Get_Paging_DienThoai(pageindex, pagesize);
            return rslist;
        }
    }
}
