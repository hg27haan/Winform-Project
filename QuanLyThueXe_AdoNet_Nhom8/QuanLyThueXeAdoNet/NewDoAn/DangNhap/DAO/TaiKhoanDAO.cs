using System.Data;

namespace NewDoAn
{
    internal class TaiKhoanDAO
    {
        DBConnection dBC = new DBConnection();

        public TaiKhoanDAO()
        {
        }

        public void DangKyTaiKhoan(ThongTinDangNhap tTDN)
        {
            string sql = string.Format("insert into DanhSachCacTaiKhoanKhachHang(HoVaTenKhachHang,CMNDKhachHang," +
                "SoDienThoaiKhachHang,DiaChiKhachHang,TenDangNhap,MatKhau) values " +
                "(N'{0}','{1}','{2}',N'{3}','{4}','{5}')", tTDN.TTCN.HoVaTen, tTDN.TTCN.CMND, tTDN.TTCN.SDT, tTDN.TTCN.DiaChi,
                tTDN.TenDangNhap, tTDN.MatKhau);
            dBC.ThucThi(sql, 1);
        }

        public bool ThucThiDangNhapKhachHang(string str1, string str2, ref string hoVaTen, ref string cmnd,
            ref string soDienThoai, ref string diaChi)
        {
            string sql = string.Format("select *from DanhSachCacTaiKhoanKhachHang");
            if (dBC.ThucThiDangNhapKhach(sql, str1, str2, ref hoVaTen, ref cmnd, ref soDienThoai, ref diaChi) == true)
            {
                return true;
            }
            return false;
        }

        public bool ThucThiDangNhapNhanVien(string str1, string str2, ref string str3)
        {
            string sql = string.Format("select *from DanhSachCacTaiKhoanNhanVien");
            if (dBC.ThucThiDangNhapNhanVien(sql, str1, str2, ref str3) == true)
            {
                return true;
            }
            return false;
        }

        public bool KiemTraTaiKhoanTrungNhau(string str1, string str2)
        {
            string sql = string.Format("select *from DanhSachCacTaiKhoanKhachHang");
            if (dBC.ThucThiKiemTraTaiKhoanTrung(sql, str1, str2) == true)
            {
                return true;
            }
            return false;
        }

        public DataTable LayDanhSachTaiKhoanKhachHang()
        {
            string sql = string.Format("select *from DanhSachCacTaiKhoanKhachHang");
            return dBC.LayDanhSach(sql);
        }

        public void SuaThongTinDangNhap(string str1, string str2, string str3, string str4, string str5, string str6)
        {
            string sql = string.Format("update DanhSachCacTaiKhoanKhachHang set HoVaTenKhachHang=N'{0}'," +
                "CMNDKhachHang='{1}',SoDienThoaiKhachHang='{2}',DiaChiKhachhang=N'{3}',MatKhau='{4}' where " +
                "TenDangNhap='{5}'", str1, str2, str3, str4, str6, str5);
            dBC.ThucThi(sql, 1);
        }

        public void XoaTaiKhoanKhachHang(string str)
        {
            string sql = string.Format("delete from DanhSachCacTaiKhoanKhachHang where TenDangNhap='{0}'", str);
            dBC.ThucThi(sql, 1);
        }

        public DataTable LoadDanhSachTKNhanVien()
        {
            string sql = string.Format("select TenDangNhap, MatKhau from DanhSachCacTaiKhoanNhanVien where LoaiTaiKhoan = 'nv'");
            return dBC.LayDanhSach(sql);
        }

        public void SuaTaiKhoanNV(string str1, string str2)
        {
            string sql = string.Format("update DanhSachCacTaiKhoanNhanVien set MatKhau=N'{0}' where TenDangNhap=N'{1}' and " +
                "LoaiTaiKhoan='nv'", str2, str1);
            dBC.ThucThi(sql, 1);
        }

        public void XoaTaiKhoanNV(string str1)
        {
            string sql = string.Format("delete from DanhSachCacTaiKhoanNhanVien where TenDangNhap=N'{1}' and " +
                "LoaiTaiKhoan='nv'", str1);
            dBC.ThucThi(sql, 1);
        }

        public void ThemTaiKhoanNV(string str1, string str2)
        {
            string sql = string.Format("insert into DanhSachCacTaiKhoanNhanVien(TenDangNhap,MatKhau,LoaiTaiKhoan) values " +
                "(N'{0}',N'{1}','nv')", str1, str2);
            dBC.ThucThi(sql, 1);
        }
    }
}
