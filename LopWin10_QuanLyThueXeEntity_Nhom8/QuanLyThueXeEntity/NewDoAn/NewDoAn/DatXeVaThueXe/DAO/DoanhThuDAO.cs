using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDoAn
{
    internal class DoanhThuDAO
    {
        SuaDoAnEntityDFContext db = new SuaDoAnEntityDFContext();

        public int LaySoLuongIDDoanhThu(string str)
        {
            if (str == "datxe")
            {
                var t = from id in db.DoanhThuDatXes
                        select id;
                return t.Count();
            }
            else if (str == "thuexe")
            {
                var t = from id in db.DoanhThuThueXes
                        select id;
                return t.Count();
            }
            else if (str == "datthue")
            {
                var t = from id in db.ChiTietDatThues
                        select id;
                return t.Count();
            } 
            else
            {
                var t = from id in db.DoanhThuThucTes
                        select id;
                return t.Count();
            }    
        }

        public void ThemVaoDoanhThuDatXe(DoanhThuDatXe dTDX)
        {
            var dt = dTDX;
            db.DoanhThuDatXes.Add(dt);
            db.SaveChanges();
            MessageBox.Show("Thực hiện đặt xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ThemVaoDoanhThuThueXe(DoanhThuThueXe dTTX)
        {
            var dt = dTTX;
            db.DoanhThuThueXes.Add(dt);
            db.SaveChanges();
            MessageBox.Show("Thực hiện thuê xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ThemVaoChiTietDatThue(ChiTietDatThue cTDT)
        {
            var chiTietDatThue = cTDT;
            db.ChiTietDatThues.Add(chiTietDatThue);
            db.SaveChanges();
        }

        public void LocDanhSachBill(ref DataGridView gv, int i, string str1, string str2, string str3, string str4, string str5, 
            string str6, string str7)
        {
            if (i == 0)
            {
                var dt = from xE in db.DoanhThuDatXes
                         where xE.TenKhachHang == str1 && xE.CMND == str2 && xE.SDT == str3 && xE.DiaChi == str4 &&
                         xE.LoaiXe == str5 && xE.HangXe == str6 && xE.NgayThue == str7
                         select new
                         {
                             xE.TenKhachHang, xE.CMND, xE.SDT, xE.DiaChi, xE.LoaiXe, xE.HangXe, xE.MaXe, xE.TenXe,
                             xE.NgayThue, xE.NgayTra, xE.DiaDiemDon, xE.VatDeLai, xE.TienThueTaiXe, xE.TongTien
                         };
                gv.DataSource = dt.ToList();
            }
            else
            {
                var dt = from xE in db.DoanhThuThueXes
                         where xE.TenKhachHang == str1 && xE.CMND == str2 && xE.SDT == str3 && xE.DiaChi == str4 &&
                         xE.LoaiXe == str5 && xE.HangXe == str6 && xE.NgayThue == str7
                         select new
                         {
                             xE.TenKhachHang, xE.CMND, xE.SDT, xE.DiaChi, xE.LoaiXe, xE.HangXe, xE.MaXe, xE.TenXe,
                             xE.NgayThue, xE.NgayTra, xE.DiaDiemDon, xE.VatDeLai, xE.TienThueTaiXe, xE.TongTien
                         };
                gv.DataSource = dt.ToList();
            }    
        }

        public void XoaKhoiDoanhThuDatXe(DoanhThuDatXe dTDX)
        {
            var dx = db.DoanhThuDatXes.FirstOrDefault(dtdx => dtdx.TenKhachHang == dTDX.TenKhachHang && dtdx.CMND == dTDX.CMND &&
            dtdx.SDT == dTDX.SDT && dtdx.DiaChi == dTDX.DiaChi && dtdx.MaXe == dTDX.MaXe && dtdx.NgayThue == dTDX.NgayThue &&
            dtdx.NgayTra == dTDX.NgayTra && dtdx.TienThueTaiXe == dTDX.TienThueTaiXe);
            if (dx != null)
            {
                db.DoanhThuDatXes.Remove(dx);
                db.SaveChanges();
            }
        }

        public void XoaKhoiDoanhThuThueXe(DoanhThuThueXe dTTX)
        {
            var tx = db.DoanhThuThueXes.FirstOrDefault(dttx => dttx.TenKhachHang == dTTX.TenKhachHang && dttx.CMND == dTTX.CMND &&
            dttx.SDT == dTTX.SDT && dttx.DiaChi == dTTX.DiaChi && dttx.MaXe == dTTX.MaXe && dttx.NgayThue == dTTX.NgayThue &&
            dttx.NgayTra == dTTX.NgayTra && dttx.TienThueTaiXe == dTTX.TienThueTaiXe);
            if (tx != null)
            {
                db.DoanhThuThueXes.Remove(tx);
                db.SaveChanges();
            }
        }

        public void XoaKhoiChiTietDatThue(string str1, string str2, string str3)
        {
            var dt = db.ChiTietDatThues.FirstOrDefault(ctdt => ctdt.MaXe == str1 && ctdt.NgayThue == str2 && ctdt.NgayTra == str3);
            if (dt != null)
            {
                db.ChiTietDatThues.Remove(dt);
                db.SaveChanges();
            }    
        }

        public void ThemVaoDoanhThuThucTe(DoanhThuThucTe dTTT)
        {
            var tt = dTTT;
            db.DoanhThuThucTes.Add(tt);
            db.SaveChanges();
            MessageBox.Show("Thực hiện thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool KiemTraKhachConDatXe(DanhSachCacTaiKhoanKhachHang dSCTKKH)
        {
            var kt = from kh in db.DoanhThuDatXes
                     where kh.TenKhachHang == dSCTKKH.HoVaTenKhachHang && kh.CMND == dSCTKKH.CMNDKhachHang &&
                     kh.SDT == dSCTKKH.SoDienThoaiKhachHang && kh.DiaChi == dSCTKKH.DiaChiKhachHang
                     select kh;
            if (kt.Count() > 0)
            {
                return true;
            }
            return false;
        }

        private bool KiemTraKhachConThueXe(DanhSachCacTaiKhoanKhachHang dSCTKKH)
        {
            var kt = from kh in db.DoanhThuThueXes
                     where kh.TenKhachHang == dSCTKKH.HoVaTenKhachHang && kh.CMND == dSCTKKH.CMNDKhachHang &&
                     kh.SDT == dSCTKKH.SoDienThoaiKhachHang && kh.DiaChi == dSCTKKH.DiaChiKhachHang
                     select kh;
            if (kt.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool KiemTraKhachConDatThueXe(DanhSachCacTaiKhoanKhachHang dSCTKKH)
        {
            if (KiemTraKhachConDatXe(dSCTKKH) == true || KiemTraKhachConThueXe(dSCTKKH) == true)
            {
                return true;
            }
            return false;
        }

        public void KiemTraXeDatThue(ref DataGridView gv, string str1, string str2)
        {
            var dt = (from xE in db.DoanhThuDatXes
                      where xE.TenKhachHang == str1 && xE.CMND == str2
                      select new { xE.LoaiXe, xE.HangXe, xE.MaXe, xE.TenXe, xE.NgayThue, xE.NgayTra, xE.DiaDiemDon }).
                      Concat(from Xe in db.DoanhThuThueXes
                             where Xe.TenKhachHang == str1 && Xe.CMND == str2
                             select new { Xe.LoaiXe, Xe.HangXe, Xe.MaXe, Xe.TenXe, Xe.NgayThue, Xe.NgayTra, Xe.DiaDiemDon });
            gv.DataSource = dt.ToList();
        }

        public void LocDanhSachXePhaiTraHomNay(ref DataGridView gv, string str)
        {
            var dt = (from xE in db.DoanhThuDatXes
                      where xE.NgayTra == str
                      select new { xE.TenKhachHang, xE.CMND, xE.SDT, xE.DiaChi, xE.LoaiXe, xE.HangXe, xE.MaXe, xE.TenXe }).
                      Concat(from Xe in db.DoanhThuThueXes
                             where Xe.NgayTra == str
                             select new { Xe.TenKhachHang, Xe.CMND, Xe.SDT, Xe.DiaChi, Xe.LoaiXe, Xe.HangXe, Xe.MaXe, Xe.TenXe });
            gv.DataSource = dt.ToList();
        }

        public void LayDoanhThuHomNay(ref DataGridView gv, string str)
        {
            var dt = from d in db.DoanhThuThucTes
                     where d.NgayThanhToan == str
                     select new
                     {
                         d.TenKhachHang,
                         d.CMND,
                         d.SDT,
                         d.TongTien
                     };
            gv.DataSource = dt.ToList();
        }

        public void ThemVaoDoanhThuThang(string str, int i)
        {
            var dt = new DoanhThuThang(str, i);
            db.DoanhThuThangs.Add(dt);
            db.SaveChanges();
            MessageBox.Show("Thực thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LayDataBaseDoanhThuThang(ref List<string> lst1, ref List<int> lst2)
        {
            var doanhThu = from dt in db.DoanhThuThangs
                           select dt;

            foreach (var item in doanhThu)
            {
                lst1.Add(item.Ngay.ToString());
                lst2.Add(item.TongTien);
            }
        }

        public void TinhDoanhThuThang(ref int i)
        {
            i = db.DoanhThuThangs.Sum(dt => dt.TongTien);
        }

        public void ThemVaoDoanhThuNam(string str, int i)
        {
            var dt = new DoanhThuNam(str, i);
            db.DoanhThuNams.Add(dt);
            db.SaveChanges();
            MessageBox.Show("Thực thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LayDataBaseDoanhThuNam(ref List<string> lst1, ref List<int> lst2)
        {
            var doanhThu = from dt in db.DoanhThuNams
                           select dt;

            foreach (var item in doanhThu)
            {
                lst1.Add(item.Thang.ToString());
                lst2.Add(item.TongTien);
            }
        }

        public void XoaDoanhThuNam()
        {
            var query = from item in db.DoanhThuNams select item;
            db.DoanhThuNams.RemoveRange(query);
            db.SaveChanges();
            MessageBox.Show("Thực thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
