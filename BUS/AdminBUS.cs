using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAO;
namespace BUS
{
    public class AdminBUS
    {
        dbAdmin _db = new dbAdmin();
        public Admin Admin_Login(Admin ad)
        {
            string result = Convert.ToString(_db.Admin_Login(ad));
            if (result == "1")
            {
                return ad;
            }
            else
            {
                return null;
            }
        }
    }
}
