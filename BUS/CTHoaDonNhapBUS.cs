using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAO;
namespace BUS
{
    public class CTHoaDonNhapBUS
    {
        dbCTHoaDonNhap _db = new dbCTHoaDonNhap();
        DataSet ds;

        public CTHoaDonNhapList Get_Paging_CTHoaDonNhap(int pageindex, int pagesize)
        {
            return _db.Get_Paging_CTHoaDonNhap(pageindex, pagesize);
        }
        public string Add_BillDetails(CTHoaDonNhap ct)
        {
            string result = string.Empty;
            try
            {
                _db.Add_BillDetails(ct);
                result = "Data inserted Sucessfuly";
            }
            catch (Exception)
            {
                result = "Failed";

            }
            return result;
        }
        public List<CTHoaDonNhap> GET_BillDetails_ID(int maloai)
        {
            ds = _db.GET_BillDetails_ID(maloai);
            List<CTHoaDonNhap> l = new List<CTHoaDonNhap>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                l.Add(new CTHoaDonNhap
                {
                    MaCTHoaDonNhap = Convert.ToInt32(dr["MaCTHoaDonNhap"].ToString()),
                    MaHoaDonNhap = Convert.ToInt32(dr["MaHoaDonNhap"].ToString()),
                    MaCauHinh = Convert.ToInt32(dr["MaCauHinh"].ToString()),
                    SoLuong = Convert.ToInt32(dr["SoLuong"].ToString()),
                    DonGia = Convert.ToInt32(dr["DonGia"].ToString()),
                });
            }
            return l;
        }
        public string Update_BillDetails(CTHoaDonNhap ct)
        {
            string res = string.Empty;
            try
            {
                _db.Update_BillDetails(ct);
                res = "Updated";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return res;
        }
        public string Delete_BillDetails(int id)
        {
            string res = string.Empty;
            try
            {
                _db.Delete_BillDetails(id);
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
