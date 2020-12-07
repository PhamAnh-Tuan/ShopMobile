using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class NhaCungCapBUS
    {
        dbNhaCungCap _db = new dbNhaCungCap();
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
    }
}
