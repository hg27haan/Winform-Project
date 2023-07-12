namespace NewDoAn
{
    internal class DoanhThuDAO
    {
        DBConnection dBC = new DBConnection();

        public void ThemVaoDoanhThuThang(string str1, string str2)
        {
            string sql1 = string.Format("insert into DoanhThuThang(Ngay,TongTien) values ('{0}',{1})", str1, str2);
            dBC.ThucThi(sql1, 1);
            string sql2 = string.Format("delete from DoanhThuThucTe");
            dBC.ThucThi(sql2, 0);
        }

        public void ThemVaoDoanhThuNam(string str1, string str2)
        {
            string sql1 = string.Format("insert into DoanhThuNam(Thang,TongTien) values ('{0}',{1})", str1, str2);
            dBC.ThucThi(sql1, 1);
            string sql2 = string.Format("delete from DoanhThuThang");
            dBC.ThucThi(sql2, 0);
        }

        public void XoaDoanhThunam()
        {
            string sql = string.Format("delete from DoanhThuNam");
            dBC.ThucThi(sql, 0);
        }
    }
}
