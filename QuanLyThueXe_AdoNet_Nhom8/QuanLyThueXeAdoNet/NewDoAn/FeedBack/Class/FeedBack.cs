namespace NewDoAn
{
    internal class FeedBack
    {
        private ThongTinCaNhan tTCN;
        private ThongTinXe tTX;
        private float danhGia;
        private string noiDung;

        public FeedBack()
        {
        }

        public FeedBack(ThongTinXe tTX)
        {
            this.tTX = tTX;
        }

        public float DanhGia { get => danhGia; set => danhGia = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        internal ThongTinCaNhan TTCN { get => tTCN; set => tTCN = value; }
        internal ThongTinXe TTX { get => tTX; set => tTX = value; }
    }
}
