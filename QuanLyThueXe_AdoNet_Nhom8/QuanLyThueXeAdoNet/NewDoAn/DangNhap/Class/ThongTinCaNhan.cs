namespace NewDoAn
{
    internal class ThongTinCaNhan
    {
        private string hoVaTen, cMND, sDT, diaChi;

        public ThongTinCaNhan()
        {
        }

        public ThongTinCaNhan(string hoVaTen)
        {
            this.hoVaTen = hoVaTen;
        }

        public ThongTinCaNhan(string hoVaTen, string cMND, string sDT, string diaChi)
        {
            this.hoVaTen = hoVaTen;
            this.cMND = cMND;
            this.sDT = sDT;
            this.diaChi = diaChi;
        }

        public string HoVaTen { get => hoVaTen; set => hoVaTen = value; }
        public string CMND { get => cMND; set => cMND = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
