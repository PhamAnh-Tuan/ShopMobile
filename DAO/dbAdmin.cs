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
    public class dbAdmin
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da;
        SqlParameter oblogin;
        SqlCommand com;
        DataSet ds;
        public int Admin_Login(Admin ad)
        {
            com = new SqlCommand("sp_Admin_login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserName", ad.TaiKhoan);
            com.Parameters.AddWithValue("@PassWord", ad.MatKhau);
            oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.Direction = ParameterDirection.Output;
            oblogin.SqlDbType = SqlDbType.Bit;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }
    }
}
