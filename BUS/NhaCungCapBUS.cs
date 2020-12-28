using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;
using System.Data.SqlClient;
namespace BUS
{
    public class NhaCungCapBUS
    {
        dbNhaCungCap _db = new dbNhaCungCap();
        DataSet ds;
        public NhaCungCapList Get_Paging_Supplier(int pagesize, int pageindex)
        {
            return _db.Get_Paging_Supplier(pagesize, pageindex);
        }
        public string Add_Supplier(NhaCungCap ncc)
        {
            string result = string.Empty;
            try
            {
                _db.Add_Supplier(ncc);
                result = "Data inserted Sucessfuly";
            }
            catch (Exception)
            {
                result = "Failed";

            }
            return result;
        }
        public NhaCungCap Get_SUPPLIER_ByID(int ID)
        {
            return _db.Get_SUPPLIER_ByID(ID);
        }
        public string Update_Supplier(NhaCungCap ncc)
        {
            string res = string.Empty;
            try
            {
                _db.Update_Supplier(ncc);
                res = "Updated";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return res;
        }

        public string Delete_Supplier(int id)
        {
            string res = string.Empty;
            try
            {
                _db.Delete_Supplier(id);
                res = "data deleted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return res;
        }
        public List<NhaCungCap> Get_NCC()
        {
            ds = _db.Get_NCC();
            List<NhaCungCap> l = new List<NhaCungCap>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                l.Add(new NhaCungCap
                {
                    MaNCC = Convert.ToInt32(dr["MaNCC"].ToString()),
                    TenNCC = dr["TenNCC"].ToString(),
                    DiaChi= dr["DiaChi"].ToString(),
                    SDT= dr["SDT"].ToString(),
                    Email= dr["Email"].ToString()
                });
            }
            return l;
        }
    }
}
