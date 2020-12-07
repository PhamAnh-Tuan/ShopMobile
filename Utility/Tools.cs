using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Tools
    {
        public static string ChuanHoaXau(string xau)
        {
            string[] a = xau.Split(new string[] { " " }, StringSplitOptions.None);
            if (a.Length < 30) return xau;
            string tam = "";
            for (int i = 0; i < 30; i++)
                tam += a[i] + " ";
            tam += "...";
            return tam;
        }
    }
}
