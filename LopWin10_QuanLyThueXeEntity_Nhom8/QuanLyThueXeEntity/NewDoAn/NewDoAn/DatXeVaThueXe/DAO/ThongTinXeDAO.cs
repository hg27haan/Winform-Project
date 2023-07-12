using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDoAn
{
    internal class ThongTinXeDAO
    {
        SuaDoAnEntityDFContext db = new SuaDoAnEntityDFContext();
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public void CapNhatSoLuongXeDuocDat(string str)
        {
            var xeDuocDat = from xE in db.DanhSachXeHienTais
                            join ctdt in db.ChiTietDatThues on xE.MaXe equals ctdt.MaXe
                            where ctdt.NgayThue == str
                            select xE;
            foreach (var xE in xeDuocDat)
            {
                xE.SoLuongConLai = 0;
            }
            db.SaveChanges();
        }

        public void LocDanhSachDatXe(ref DataGridView gv, string str1, string str2, int i1, int i2, string str3, string str4)
        {
            try
            {
                string sql = string.Format("select LoaiXe,HangXe,MaXe,TenXe,GiaThue,SoChuyen,DanhGia from DanhSachXeHienTai where " +
                "LoaiXe = N'{0}' and HangXe = '{1}' and GiaThue >= {2} and GiaThue <= {3} and MaXe not in " +
                "(select MaXe from ChiTietDatThue where NgayThue <= '{5}' and NgayTra >= '{4}')", str1, str2, i1, i2, str3, str4);

                DataTable dtTbl = new DataTable();
                conn.Open();
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(sql, conn);
                sqlAdpt.Fill(dtTbl);

                gv.DataSource = dtTbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void LocDanhSachThueXe(ref DataGridView gv, string str1, string str2, int i1, int i2)
        {
            var result = from ds in db.DanhSachXeHienTais
                         where ds.LoaiXe == str1 && ds.HangXe == str2 && ds.GiaThue >= i1 && ds.GiaThue <= i2 && ds.SoLuongConLai > 0
                         select new
                         {
                             ds.LoaiXe,
                             ds.HangXe,
                             ds.MaXe,
                             ds.TenXe,
                             ds.GiaThue,
                             ds.SoChuyen,
                             ds.DanhGia
                         };
            gv.DataSource = result.ToList();
        }

        public void CapNhatSoLuongXe(string maXe, int i)
        {
            var xe = db.DanhSachXeHienTais.FirstOrDefault(x => x.MaXe == maXe);
            if (xe != null)
            {
                xe.SoLuongConLai = i;
                db.SaveChanges();
            }
        }

        public void LayGiaThue(string str, ref int i1)
        {
            var x = from xE in db.DanhSachXeHienTais
                    where xE.MaXe == str
                    select new
                    {
                        xE.GiaThue
                    };
            if (x.Count() > 0)
            {
                i1 = x.First().GiaThue;
            }
        }

        public void LaySoChuyenXe(string str, ref int i)
        {
            var x = from xE in db.DanhSachXeHienTais
                    where xE.MaXe == str
                    select new
                    {
                        xE.SoChuyen
                    };
            if (x.Count() > 0)
            {
                i = x.First().SoChuyen;
            }
        }

        public void CapNhatSoChuyen(string str, int i)
        {
            var x = db.DanhSachXeHienTais.FirstOrDefault(m => m.MaXe == str);
            if (x != null)
            {
                x.SoChuyen = i;
                db.SaveChanges();
            }
        }

        public void LayDiemDanhGia(string str, ref double i)
        {
            var x = from xE in db.DanhSachXeHienTais
                    where xE.MaXe == str
                    select new
                    {
                        xE.DanhGia
                    };
            if (x.Count() > 0)
            {
                i = x.First().DanhGia;
            }
        }

        public void CapNhatDanhGia(string str, double i)
        {
            var x = db.DanhSachXeHienTais.FirstOrDefault(m => m.MaXe == str);
            if (x != null)
            {
                x.DanhGia = i;
                db.SaveChanges();
            }
        }

        public void TrendingThueXe(ref DataGridView gv)
        {
            var d = from x in db.DanhSachXeHienTais
                    orderby x.SoChuyen descending, x.DanhGia descending
                    select x;
            gv.DataSource = d.ToList();
        }

        public bool KiemTraXeConDatThue(string str)
        {
            var kt = from xe in db.ChiTietDatThues
                     where xe.MaXe == str
                     select xe;
            if (kt.Count() > 0)
            {
                return true;
            }    
            return false;
        }

        public void CapNhatThongTinXe(string str1, string str2, string str3, string str4, int i1, int i2, int i3, double d)
        {
            var b = db.DanhSachXeHienTais.FirstOrDefault(x => x.MaXe == str3);
            if (b != null)
            {
                b.LoaiXe = str1;
                b.HangXe = str2;
                b.TenXe = str4;
                b.SoLuongConLai = i1;
                b.GiaThue = i2;
                b.SoChuyen = i3;
                b.DanhGia = d;
                db.SaveChanges();
                MessageBox.Show("Thực thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void XoaXeKhoiHeThong(string str)
        {
            var d = db.DanhSachXeHienTais.FirstOrDefault(x => x.MaXe == str);
            if (d != null)
            {
                db.DanhSachXeHienTais.Remove(d);
                db.SaveChanges();
                MessageBox.Show("Thực thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool KiemTraMaXe(string str)
        {
            return db.DanhSachXeHienTais.Any(x => x.MaXe == str);
        }

        public void ThemXeVaoHeThong(string str1, string str2, string str3, string str4, int i)
        {
            var d = new DanhSachXeHienTai(str1, str2, str3, str3, i);
            db.DanhSachXeHienTais.Add(d);
            db.SaveChanges();
            MessageBox.Show("Thực thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
