using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using DTO;

namespace BUS
{
    public class LoaiDTBUS
    {
        dbLoaiDT dblayer = new dbLoaiDT();
        dbDienThoai dbDT = new dbDienThoai();
        DataSet ds;
        //Admin
        public List<LoaiDT> Get_LoaiDTbyid(int id)
        {
            DataSet ds = dblayer.Get_LoaiDT_byid(id);
            List<LoaiDT> list = new List<LoaiDT>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new LoaiDT
                {
                    MaLoai = Convert.ToInt32(dr["MaLoai"]),
                    TenLoai = dr["TenLoai"].ToString(),
                    XuatXu = dr["XuatXu"].ToString()
                });
            }
            return list;
        }
        public LoaiDTList get_data(int pageindex, int pagesize)
        {
            LoaiDTList rslist = new LoaiDTList();
            rslist = dblayer.Get_Paging_data(pagesize, pageindex);
            return rslist;
        }
        public string Add_TypePhone(LoaiDT dt)
        {
            string result = string.Empty;
            try
            {
                dblayer.Add_TypePhone(dt);
                result = "Data inserted Sucessfuly";
            }
            catch (Exception)
            {
                result = "Failed";

            }
            return result;
        }
        public string Update_TypePhone(LoaiDT dt)
        {
            string res = string.Empty;
            try
            {
                dblayer.Update_TypePhone(dt);
                res = "Updated";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return res;
        }
        public string Delete_TypePhone(int id)
        {
            string res = string.Empty;
            try
            {
                dblayer.Delete_TypePhone(id);
                res = "data deleted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return res;
        }
        //Client
        public List<LoaiDT> Get_LoaiDT()
        {
            ds = dblayer.Get_LoaiDT();
            List<LoaiDT> l = new List<LoaiDT>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                l.Add(new LoaiDT
                {
                    MaLoai = Convert.ToInt32(dr["MaLoai"]),
                    TenLoai = dr["TenLoai"].ToString(),
                    XuatXu = dr["XuatXu"].ToString(),
                });
            }
            return l;
        }
    }
}
