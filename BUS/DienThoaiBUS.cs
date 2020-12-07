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
        dbDienThoai _db = new dbDienThoai();
        DataSet ds;
        public List<DienThoai> Get_DienThoai10()
        {
            ds = _db.Get_DienThoai10();
            List<DienThoai> l = new List<DienThoai>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                l.Add(new DienThoai
                {
                    MaDienThoai = Convert.ToInt32(dr["MaDienThoai"]),
                    TenDienThoai = dr["TenDienThoai"].ToString(),
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
        public List<DienThoai> Get_DienThoai_byMaLoai(int maloai)
        {
            ds = _db.Get_DienThoai_byMaLoai(maloai);
            List<DienThoai> l = new List<DienThoai>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                l.Add(new DienThoai
                {
                    MaDienThoai = Convert.ToInt32(dr["MaDienThoai"].ToString()),
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
                    Ram = Convert.ToInt32(dr["Ram"].ToString()),
                    BoNhoTrong = Convert.ToInt32(dr["BoNhoTrong"].ToString()),
                    Gia = Convert.ToInt32(dr["Gia"].ToString()),
                });
            }
            return l;
        }
        public List<DienThoai> Get_DienThoai_byid(int id)
        {
            ds = _db.Get_DienThoai_byid(id);
            List<DienThoai> list = new List<DienThoai>();
            foreach (DataRow dr in ds.Tables[0].Rows)
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
        public List<string> ListName(string keyword)
        {
            List<string> listname = new List<string>();
            listname = _db.ListName(keyword);
            return listname;
        }
        public DienThoai get_chitiet(int ma)
        {
            DienThoai dt = new DienThoai();
            dt = _db.get_chitiet(ma);
            return dt;
        }
        public List<DienThoai> Search_Product(string keyword)
        {
            ds = _db.Search_Product(keyword);
            List<DienThoai> list = new List<DienThoai>();
            foreach (DataRow dr in ds.Tables[0].Rows)
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
                    Ram=Convert.ToInt32(dr["Ram"].ToString()),
                    BoNhoTrong=Convert.ToInt32(dr["BoNhoTrong"].ToString()),
                    Gia=Convert.ToInt32(dr["Gia"].ToString()),
                });
            }
            return list;
        }
            //Admin
            public DienThoaiList Get_Paging_DienThoai(int pageindex, int pagesize)
        {
            DienThoaiList rslist = new DienThoaiList();
            rslist = _db.Get_Paging_DienThoai(pageindex, pagesize);
            return rslist;
        }
        public string Add_Phone(DienThoai dt)
        {
            string result = string.Empty;
            try
            {
                _db.Add_Phone(dt);
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
                _db.Update_Phone(dt);
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
                _db.Delete_Phone(id);
                res = "data deleted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return res;
        }

    }
}
