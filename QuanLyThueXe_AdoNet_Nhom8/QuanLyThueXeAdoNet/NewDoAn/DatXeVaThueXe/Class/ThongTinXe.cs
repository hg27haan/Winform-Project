using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDoAn
{
    internal class ThongTinXe
    {
        private string loaiXe, hangXe, maXe, tenXe;
        private int soLuongConLai, giaThue, soChuyen;
        private float danhGia;

        public ThongTinXe()
        {
        }

        public ThongTinXe(string loaiXe, string hangXe, string maXe, string tenXe)
        {
            this.loaiXe = loaiXe;
            this.hangXe = hangXe;
            this.maXe = maXe;
            this.tenXe = tenXe;
        }

        public ThongTinXe(string loaiXe, string hangXe, string maXe, string tenXe, int giaThue) : this(loaiXe, hangXe, maXe, tenXe)
        {
            GiaThue = giaThue;
        }

        public ThongTinXe(string loaiXe, string hangXe, string maXe, string tenXe, int giaThue, int soChuyen, float danhGia) : this(loaiXe, hangXe, maXe, tenXe, giaThue)
        {
            SoChuyen = soChuyen;
            DanhGia = danhGia;
        }

        public string LoaiXe { get => loaiXe; set => loaiXe = value; }
        public string HangXe { get => hangXe; set => hangXe = value; }
        public string MaXe { get => maXe; set => maXe = value; }
        public string TenXe { get => tenXe; set => tenXe = value; }
        public int SoLuongConLai { get => soLuongConLai; set => soLuongConLai = value; }
        public int GiaThue { get => giaThue; set => giaThue = value; }
        public int SoChuyen { get => soChuyen; set => soChuyen = value; }
        public float DanhGia { get => danhGia; set => danhGia = value; }
    }
}
