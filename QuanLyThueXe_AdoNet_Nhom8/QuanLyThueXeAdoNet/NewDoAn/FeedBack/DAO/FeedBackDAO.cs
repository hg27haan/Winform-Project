using System.Data;

namespace NewDoAn
{
    internal class FeedBackDAO
    {
        DBConnection dBC = new DBConnection();
        FeedBack fB = new FeedBack();

        public void ThemFeedBack(FeedBack fB)
        {
            string sql = string.Format("insert into FeedBack(TenKhachHang,LoaiXe,HangXe,MaXe,TenXe,DanhGia,NoiDung) values " +
                "(N'{0}',N'{1}',N'{2}','{3}',N'{4}',{5},N'{6}')", fB.TTCN.HoVaTen, fB.TTX.LoaiXe, fB.TTX.HangXe, fB.TTX.MaXe, fB.TTX.TenXe,
                fB.DanhGia, fB.NoiDung);
            dBC.ThucThi(sql, 1);
        }

        public DataTable CacFeedBack(FeedBack fB)
        {
            string sql = string.Format("select TenKhachHang, DanhGia, NoiDung from FeedBack where LoaiXe=N'{0}' and HangXe=N'{1}' and " +
                "MaXe='{2}' and TenXe=N'{3}'", fB.TTX.LoaiXe, fB.TTX.HangXe, fB.TTX.MaXe, fB.TTX.TenXe);
            return dBC.LayDanhSach(sql);
        }
    }
}
