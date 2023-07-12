namespace NewDoAn
{
    internal class ThongTinBill
    {
        private ThongTinCaNhan tTCN;
        private ThongTinXe tTX;
        private string phiTaiXe, diaDiemDon, ngayThue, ngayTra, vatGiuLai, tongTien;

        public ThongTinBill()
        {
        }

        public ThongTinBill(ThongTinCaNhan tTCN, ThongTinXe tTX, string phiTaiXe, string diaDiemDon, string ngayThue, string ngayTra,
            string vatGiuLai, string tongTien)
        {
            this.tTCN = tTCN;
            this.tTX = tTX;
            this.phiTaiXe = phiTaiXe;
            this.diaDiemDon = diaDiemDon;
            this.ngayThue = ngayThue;
            this.ngayTra = ngayTra;
            this.vatGiuLai = vatGiuLai;
            this.tongTien = tongTien;
        }

        public string PhiTaiXe { get => phiTaiXe; set => phiTaiXe = value; }
        public string DiaDiemDon { get => diaDiemDon; set => diaDiemDon = value; }
        public string NgayThue { get => ngayThue; set => ngayThue = value; }
        public string NgayTra { get => ngayTra; set => ngayTra = value; }
        public string VatGiuLai { get => vatGiuLai; set => vatGiuLai = value; }
        public string TongTien { get => tongTien; set => tongTien = value; }
        internal ThongTinCaNhan TTCN { get => tTCN; set => tTCN = value; }
        internal ThongTinXe TTX { get => tTX; set => tTX = value; }
    }
}
