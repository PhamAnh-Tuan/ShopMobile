using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace BUS
{
    public class KhachHangBUS
    {
        dbKhachHang _db = new dbKhachHang();
        public KhachHang Client_Login(KhachHang kh)
        {
            string result = Convert.ToString(_db.Client_Login(kh));
            if (result == "1")
            {
                return kh;
            }
            else
            {
                return null;
            }
        }
        public void Register(KhachHang kh)
        {
            _db.Register(kh);                
        }
        public KhachHang Get_Info(string TK)
        {
            return _db.Get_Info(TK);
        }
    }
}
