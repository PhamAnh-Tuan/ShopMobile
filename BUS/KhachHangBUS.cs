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
        dbKhachHang dblayer = new dbKhachHang();
        public KhachHang Client_Login(KhachHang kh)
        {
            string result = Convert.ToString(dblayer.Client_Login(kh));
            if (result == "1")
            {
                return kh;
            }
            else
            {
                return null;
            }
        }
    }
}
