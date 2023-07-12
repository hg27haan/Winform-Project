namespace NewDoAn.NhanVien.Class
{
    class MaGiamGia
    {
        private string code, hsd, chiTiet;

        public MaGiamGia()
        {
        }

        public MaGiamGia(string code, string hsd, string chiTiet)
        {
            this.code = code;
            this.hsd = hsd;
            this.chiTiet = chiTiet;
        }

        public string Code { get => code; set => code = value; }
        public string Hsd { get => hsd; set => hsd = value; }
        public string ChiTiet { get => chiTiet; set => chiTiet = value; }
    }
}
