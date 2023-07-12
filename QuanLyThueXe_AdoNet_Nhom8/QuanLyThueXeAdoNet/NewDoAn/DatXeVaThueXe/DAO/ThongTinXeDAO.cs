using System.Data;

namespace NewDoAn
{
    internal class ThongTinXeDAO
    {
        DBConnection dBC = new DBConnection();

        public DataTable LocDanhSachDatXe(string str1, string str2, int i1, int i2, string str3, string str4)
        {
            string sql = string.Format("select LoaiXe,HangXe,MaXe,TenXe,GiaThue,SoChuyen,DanhGia from DanhSachXeHienTai where " +
                "LoaiXe = N'{0}' and HangXe = '{1}' and GiaThue >= {2} and GiaThue <= {3} and MaXe not in " +
                "(select MaXe from ChiTietDatThue where NgayThue <= '{5}' and NgayTra >= '{4}')", str1, str2, i1, i2, str3, str4);
            return dBC.LayDanhSach(sql);
        }

        public DataTable LocDanhSachThueXe(string str1, string str2, int i1, int i2)
        {
            string sql = string.Format("select LoaiXe,HangXe,MaXe,TenXe,GiaThue,SoChuyen,DanhGia from DanhSachXeHienTai where " +
                "LoaiXe = N'{0}' and HangXe = '{1}' and GiaThue >= {2} and GiaThue <= {3} and SoLuongConLai > 0", str1, str2, i1, i2);
            return dBC.LayDanhSach(sql);
        }

        public void CapNhatSoLuongXeDuocDat(string str)
        {
            string sql = string.Format("update DanhSachXeHienTai set SoLuongConLai = 0 where MaXe in " +
                "(select MaXe from ChiTietDatThue where NgayThue = '{0}')", str);
            dBC.ThucThi(sql, 0);
        }

        public void CapNhatSoLuongXe(string maXe, int i)
        {
            if (i == 0)
            {
                string sql = string.Format("update DanhSachXeHienTai set SoLuongConLai = 0 where MaXe='{0}'", maXe);
                dBC.ThucThi(sql, 0);
            }
            else if (i == 1)
            {
                string sql = string.Format("update DanhSachXeHienTai set SoLuongConLai = 1 where MaXe='{0}'", maXe);
                dBC.ThucThi(sql, 0);
            }
        }

        public void CapNhatDanhGiaVaSoChuyen(string str1, string str2, string maXe)
        {
            string sql = string.Format("update DanhSachXeHienTai set {0}={1} where MaXe='{2}'", str1, str2, maXe);
            dBC.ThucThi(sql, 0);
        }

        public DataTable TrendingThueXe()
        {
            string sql = string.Format("select *from DanhSachXeHienTai order by SoChuyen desc,DanhGia desc");
            return dBC.LayDanhSach(sql);
        }

        public void CapNhatThongTinXe(string str1, string str2, string str3, string str4, int i5, int i6, int i7, float f8)
        {
            string sql = string.Format("update DanhSachXeHienTai set LoaiXe=N'{0}',HangXe=N'{1}',TenXe=N'{2}',SoLuongConLai ={3}," +
                "GiaThue={4},SoChuyen={5},DanhGia={6} where MaXe='{7}'", str1, str2, str4, i5, i6, i7, f8, str3);
            dBC.ThucThi(sql, 1);
        }

        public void XoaXeKhoiHeThong(string str)
        {
            string sql = string.Format("delete from DanhSachXeHienTai where MaXe ='{0}'", str);
            dBC.ThucThi(sql, 1);
        }

        public void ThemXeVaoHeThong(string str1, string str2, string str3, string str4, int i)
        {
            string sql = string.Format("insert into DanhSachXeHienTai(LoaiXe,HangXe,MaXe,TenXe,SoLuongConLai,GiaThue,SoChuyen,DanhGia) " +
                "values (N'{0}',N'{1}','{2}',N'{3}',{4},{5},{6},{7})", str1, str2, str3, str4, 1.ToString(), i.ToString(),
                1.ToString(), 5.ToString());
            dBC.ThucThi(sql, 1);

        }
    }
}
