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
        public CauHinhList Get_Paging_Confi(int pagesize,int pageindex)
        {
            return _db.Get_Paging_Confi(pagesize, pageindex);
        }
    }
}
