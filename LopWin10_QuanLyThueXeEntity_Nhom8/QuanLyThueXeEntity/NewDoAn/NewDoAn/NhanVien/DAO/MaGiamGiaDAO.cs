using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDoAn
{
    internal class MaGiamGiaDAO
    {
        SuaDoAnEntityDFContext db = new SuaDoAnEntityDFContext();

        public void ChiTietGiam(string str, ref int i)
        {
            var g = from v in db.MaGiamGias
                    where v.Code == str
                    select new
                    {
                        v.ChiTietGiam
                    };
            if (g.Count() > 0)
            {
                i = int.Parse(g.First().ChiTietGiam);
            }
        }

        public void XoaMaGiamGiaHetHan(string str)
        {
            var v = db.MaGiamGias.FirstOrDefault(m => m.HSD == str);
            if (v != null)
            {
                db.MaGiamGias.Remove(v);
                db.SaveChanges();
            }
        }

        public void LayDanhSach(ref DataGridView gv)
        {
            var d = from m in db.MaGiamGias
                    orderby m.HSD ascending
                    select m;
            gv.DataSource = d.ToList();
        }

        public bool KiemTraMaGiamGia(string str)
        {
            return db.MaGiamGias.Any(m => m.Code == str);
        }

        public void ThemMaGiamGia(string str1, string str2, string str3)
        {
            var d = new MaGiamGia(str1, str2, str3);
            db.MaGiamGias.Add(d);
            db.SaveChanges();
            MessageBox.Show("Thực thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
