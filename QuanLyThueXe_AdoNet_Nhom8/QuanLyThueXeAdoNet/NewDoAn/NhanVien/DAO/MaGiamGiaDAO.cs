using System.Data;

namespace NewDoAn
{
    class MaGiamGiaDAO
    {
        DBConnection dBC = new DBConnection();

        public DataTable LayDanhSach()
        {
            string sql = string.Format("select *from MaGiamGia order by HSD ASC");
            return dBC.LayDanhSach(sql);
        }

        public void ThemMaGiamGia(string str1, string str2, string str3)
        {
            string sql = string.Format("insert into MaGiamGia(Code,HSD,ChiTietGiam) values " +
                "('{0}','{1}','{2}')", str1, str2, str3);
            dBC.ThucThi(sql, 1);
        }

        public void XoaMaGiamGiaHetHan(string str)
        {
            string sql = string.Format("delete from MaGiamGia where HSD = '{0}'", str);
            dBC.ThucThi(sql, 0);
        }
    }
}
