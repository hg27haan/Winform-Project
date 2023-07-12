using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDoAn
{
    internal class FeedBackDAO
    {
        SuaDoAnEntityDFContext db = new SuaDoAnEntityDFContext();

        public void CacFeedBack(ref DataGridView gv, FeedBack fB)
        {
            var f = from feedBack in db.FeedBacks
                    where feedBack.MaXe == fB.MaXe
                    select new
                    {
                        feedBack.TenKhachHang,
                        feedBack.DanhGia,
                        feedBack.NoiDung
                    };
            gv.DataSource = f.ToList();
        }

        public int LayIDFeedBack()
        {
            var t = from fb in db.FeedBacks
                    select fb;
            return t.Count();
        }

        public void ThemFeedBack(FeedBack fB)
        {
            var f = fB;
            db.FeedBacks.Add(f);
            db.SaveChanges();
            MessageBox.Show("Góp ý thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
