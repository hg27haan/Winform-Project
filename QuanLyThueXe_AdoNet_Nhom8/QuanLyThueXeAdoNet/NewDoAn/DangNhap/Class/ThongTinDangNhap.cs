using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDoAn
{
    internal class ThongTinDangNhap
    {
        private ThongTinCaNhan tTCN;
        private string tenDangNhap, matKhau;

        public ThongTinDangNhap()
        {
        }

        public ThongTinDangNhap(ThongTinCaNhan ttcn, string tenDangNhap, string matKhau)
        {
            this.tTCN = ttcn;
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
        }

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        internal ThongTinCaNhan TTCN { get => tTCN; set => tTCN = value; }
    }
}
