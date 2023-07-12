using System;
using System.Data;

namespace NewDoAn
{
    internal class ThongTinBillDAO
    {
        DBConnection dBC = new DBConnection();

        public void ThemVaoChiTietDatThue(string str1, string str2, string str3)
        {
            string sql = string.Format("insert into ChiTietDatThue(MaXe, NgayThue, NgayTra) values " +
                "('{0}','{1}','{2}')", str1, str2, str3);
            dBC.ThucThi(sql, 0);
        }

        public void XoaKhoiChiTietDatThue(string str1, string str2, string str3)
        {
            string sql = string.Format("delete from ChiTietDatThue where MaXe = '{0}' and NgayThue = '{1}' and " +
                "NgayTra ='{2}'", str1, str2, str3);
            dBC.ThucThi(sql, 0);
        }

        public void ThemVaoDoanhThu(string str, ThongTinBill tTB)
        {
            string sql = string.Format("insert into {0}(TenKhachHang,CMND,SDT,DiaChi,LoaiXe,HangXe,MaXe,TenXe,NgayThue,NgayTra," +
                "DiaDiemDon,VatDeLai,TienThueTaiXe,TongTien) values (N'{1}','{2}','{3}',N'{4}',N'{5}',N'{6}','{7}',N'{8}','{9}','{10}'," +
                "N'{11}',N'{12}',{13},{14})", str, tTB.TTCN.HoVaTen, tTB.TTCN.CMND, tTB.TTCN.SDT, tTB.TTCN.DiaChi, tTB.TTX.LoaiXe,
                tTB.TTX.HangXe, tTB.TTX.MaXe, tTB.TTX.TenXe, tTB.NgayThue, tTB.NgayTra, tTB.DiaDiemDon, tTB.VatGiuLai,
                tTB.PhiTaiXe.ToString(), tTB.TongTien.ToString());
            dBC.ThucThi(sql, 1);
        }

        public DataTable LocDanhSachBill(string str, ThongTinCaNhan tTCN, string str1, string str2, string str3)
        {
            string sql = string.Format("select *from {0} where TenKhachhang=N'{1}' and CMND='{2}' and SDT='{3}' and" +
                " DiaChi=N'{4}' and LoaiXe=N'{5}' and HangXe=N'{6}' and NgayThue='{7}'", str, tTCN.HoVaTen, tTCN.CMND, tTCN.SDT, tTCN.DiaChi,
                str2, str3, str1);
            return dBC.LayDanhSach(sql);
        }

        public void XoaKhoiDoanhThu(string str, ThongTinBill tTB)
        {
            string sql = string.Format("delete from {0} where TenKhachHang=N'{1}' and CMND='{2}' and SDT='{3}' and DiaChi=N'{4}' " +
                "and MaXe='{5}' and NgayThue='{6}' and NgayTra='{7}' and TienThueTaiXe={8}", str, tTB.TTCN.HoVaTen, tTB.TTCN.CMND,
                tTB.TTCN.SDT, tTB.TTCN.DiaChi, tTB.TTX.MaXe, tTB.NgayThue, tTB.NgayTra, tTB.PhiTaiXe.ToString());
            dBC.ThucThi(sql, 0);

        }

        public void ThemVaoDoanhThuThucTe(ThongTinBill tTB, string str, int tongCong)
        {
            string sql = string.Format("insert into DoanhThuThucte(TenKhachHang,CMND,SDT,NgayThanhToan,TongTien) values " +
                "(N'{0}','{1}','{2}','{3}',{4})", tTB.TTCN.HoVaTen, tTB.TTCN.CMND, tTB.TTCN.SDT, str, tongCong.ToString());
            dBC.ThucThi(sql, 1);
        }

        public DataTable LocDanhSachXePhaiTraHomNay(DateTime dT)
        {
            string sql = string.Format("select TenKhachHang,CMND,SDT,DiaChi,LoaiXe,HangXe,MaXe,TenXe " +
                "from DoanhThuDatXe where NgayTra like '{0}' union select TenKhachHang,CMND,SDT,DiaChi,LoaiXe,HangXe," +
                "MaXe,TenXe from DoanhThuThueXe where NgayTra like '{0}'", dT.ToString("dd/MM/yyyy"));
            return dBC.LayDanhSach(sql);
        }

        public DataTable LayDoanhThuHomNay(DateTime dT)
        {
            string sql = string.Format("select TenKhachHang,CMND,SDT,TongTien from DoanhThuThucTe where NgayThanhToan " +
                "='{0}'", dT.ToString("dd/MM/yyyy"));
            return dBC.LayDanhSach(sql);
        }

        public DataTable KiemTraXeDatThue(string str1, string str2)
        {
            string sql = string.Format("select LoaiXe,HangXe,MaXe,TenXe,NgayThue,NgayTra,DiaDiemDon from DoanhThuDatXe where " +
                "TenKhachHang=N'{0}' and CMND='{1}' union select LoaiXe,HangXe,MaXe,TenXe,NgayThue,NgayTra,DiaDiemDon from " +
                "DoanhThuThueXe where TenKhachHang=N'{0}' and CMND='{1}'", str1, str2);
            return dBC.LayDanhSach(sql);
        }
    }
}
