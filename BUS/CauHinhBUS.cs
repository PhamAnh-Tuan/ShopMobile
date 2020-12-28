using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace BUS
{
    public class CauHinhBUS
    {
        dbCauHinh _db = new dbCauHinh();
        DataSet ds;
        public CauHinhList Get_Paging_Confi(int pagesize,int pageindex)
        {
            return _db.Get_Paging_Confi(pagesize, pageindex);
        }
        public string Add_Configuration(CauHinh ch)
        {
            string result = string.Empty;
            try
            {
                _db.Add_Configuration(ch);
                result = "Data inserted Sucessfuly";
            }
            catch (Exception)
            {
                result = "Failed";

            }
            return result;
        }
        public string Update_Configuration(CauHinh ch)
        {
            string res = string.Empty;
            try
            {
                _db.Update_Configuration(ch);
                res = "Updated";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return res;
        }
        public string Delete_Configuration(int MaCauHinh)
        {
            string res = string.Empty;
            try
            {
                _db.Delete_Configuration(MaCauHinh);
                res = "data deleted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return res;
        }
        public CauHinh Get_Configuration_ByID(int ID)
        {
            return _db.Get_Configuration_ByID(ID);          
        }
        public List<CauHinh> Get_CauHinh()
        {
            ds = _db.Get_CauHinh();
            List<CauHinh> l = new List<CauHinh>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                l.Add(new CauHinh
                {
                    MaCauHinh = Convert.ToInt32(dr["MaCauHinh"].ToString()),
                    MaDienThoai = Convert.ToInt32(dr["MaDienThoai"].ToString()),
                    Ram = Convert.ToInt32(dr["Ram"].ToString()),
                    BoNhoTrong = Convert.ToInt32(dr["BoNhoTrong"].ToString()),
                    Gia = Convert.ToInt32(dr["Gia"].ToString())
                });
            }
            return l;
        }
    }
}
