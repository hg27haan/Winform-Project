using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDoAn
{
    internal class TaiKhoanDAO
    {
        SuaDoAnEntityDFContext db = new SuaDoAnEntityDFContext();

        public bool KiemTraCMNDVaTaiKhoanTrung(int i, string str)
        {
            try
            {
                if (i == 0)
                {
                    return db.DanhSachCacTaiKhoanKhachHangs.Any(tk => tk.CMNDKhachHang == str);
                }    
                return db.DanhSachCacTaiKhoanKhachHangs.Any(tk => tk.TenDangNhap == str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void DangKyTaiKhoan(DanhSachCacTaiKhoanKhachHang dSCTKKH)
        {
            try
            {
                var dK = dSCTKKH;
                db.DanhSachCacTaiKhoanKhachHangs.Add(dK);
                db.SaveChanges();
                MessageBox.Show("Đăng ký tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ThucThiDangNhapKhachHang(string str1, string str2, ref string hoVaTen, ref string cmnd,
            ref string soDienThoai, ref string diaChi)
        {
            if (KiemTraCMNDVaTaiKhoanTrung(1,str1) == true)
            {
                var kH = from tKKH in db.DanhSachCacTaiKhoanKhachHangs
                         where tKKH.TenDangNhap == str1 && tKKH.MatKhau == str2
                         select new
                         {
                             tKKH.HoVaTenKhachHang,
                             tKKH.CMNDKhachHang,
                             tKKH.SoDienThoaiKhachHang,
                             tKKH.DiaChiKhachHang
                         };
                if (kH.Count() > 0)
                {
                    hoVaTen = kH.First().HoVaTenKhachHang;
                    cmnd = kH.First().CMNDKhachHang;
                    soDienThoai = kH.First().SoDienThoaiKhachHang;
                    diaChi = kH.First().DiaChiKhachHang;
                }
                return true;
            }
            return false;
        }

        public bool KiemTraTaiKhoanNhanVien(string str)
        {
            return db.DanhSachCacTaiKhoanNhanViens.Any(tk => tk.TenDangNhap == str);
        }

        public bool ThucThiDangNhapNhanVien(string str1, string str2, ref string loaiTaiKhoan)
        {
            if (KiemTraTaiKhoanNhanVien(str1) == true)
            {
                var nV = from tKNV in db.DanhSachCacTaiKhoanNhanViens
                         where tKNV.TenDangNhap == str1 && tKNV.MatKhau == str2
                         select new
                         {
                             tKNV.LoaiTaiKhoan
                         };
                if (nV.Count() > 0)
                {
                    loaiTaiKhoan = nV.First().LoaiTaiKhoan;
                }
                return true;
            }
            return false;
        }

        public void LayDanhSachTaiKhoanKhachHang(ref DataGridView gv)
        {
            var tKKH = from tk in db.DanhSachCacTaiKhoanKhachHangs
                       select tk;
            gv.DataSource = tKKH.ToList();
        }

        public void SuaThongTinDangNhapKhach(string str1, string str2, string str3, string str4, string str5, string str6)
        {
            var dn = db.DanhSachCacTaiKhoanKhachHangs.FirstOrDefault(tk => tk.TenDangNhap == str5);
            if (dn != null)
            {
                dn.HoVaTenKhachHang = str1;
                dn.CMNDKhachHang = str2;
                dn.SoDienThoaiKhachHang = str3;
                dn.DiaChiKhachHang = str4;
                dn.MatKhau = str6;
                db.SaveChanges();
                MessageBox.Show("Thực thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void XoaTaiKhoanKhachHang(string str)
        {
            var dn = db.DanhSachCacTaiKhoanKhachHangs.FirstOrDefault(tk => tk.TenDangNhap == str);
            if (dn != null)
            {
                db.DanhSachCacTaiKhoanKhachHangs.Remove(dn);
                db.SaveChanges();
                MessageBox.Show("Thực thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void LoadDanhSachTKNhanVien(ref DataGridView gv)
        {
            var d = from tk in db.DanhSachCacTaiKhoanNhanViens
                    select new
                    {
                        tk.TenDangNhap,
                        tk.MatKhau
                    };
            gv.DataSource = d.ToList();
        }

        public void SuaTaiKhoanNV(string str1, string str2)
        {
            var dn = db.DanhSachCacTaiKhoanNhanViens.FirstOrDefault(tk => tk.TenDangNhap == str1);
            if (dn != null)
            {
                dn.MatKhau = str2;
                db.SaveChanges();
                MessageBox.Show("Thực thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void XoaTaiKhoanNV(string str)
        {
            var d = db.DanhSachCacTaiKhoanNhanViens.FirstOrDefault(tk => tk.TenDangNhap == str);
            if (d != null)
            {
                db.DanhSachCacTaiKhoanNhanViens.Remove(d);
                db.SaveChanges();
                MessageBox.Show("Thực thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThemTaiKhoanNV(string str1, string str2)
        {
            var d = new DanhSachCacTaiKhoanNhanVien(str1, str2);
            db.DanhSachCacTaiKhoanNhanViens.Add(d);
            db.SaveChanges();
            MessageBox.Show("Thực thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
