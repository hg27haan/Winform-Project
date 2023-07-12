using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace NewDoAn
{
    public partial class FormDatXeVaThueXe : MaterialForm
    {
        DanhSachCacTaiKhoanKhachHang dSCTKKH = new DanhSachCacTaiKhoanKhachHang();
        ThongTinXeDAO tTXDAO = new ThongTinXeDAO();
        DanhSachXeHienTai dSXHT = new DanhSachXeHienTai();
        FeedBack fB = new FeedBack();
        FeedBackDAO fBDAO = new FeedBackDAO();
        MaGiamGiaDAO mGGDAO = new MaGiamGiaDAO();
        DoanhThuDatXe dTDX = new DoanhThuDatXe();
        DoanhThuThueXe dTTX = new DoanhThuThueXe();
        DoanhThuDAO dTDAO = new DoanhThuDAO();
        ChiTietDatThue cTDT = new ChiTietDatThue();
        Util u = new Util();

        private string loaiXe = "";
        private string hangXe = "";
        private int Min = 0;
        private int Max = 0;
        private string diaDiemDon = "Sảnh";
        private string vatGiuLai = "";
        private string phiTaiXe = "0";
        private string ngayDatThue = "";
        private string ngayTra = "";
        private int khoangCach = 0;
        private int tongTien = 0;
        private int giamGia = 0;
        private int datthue = 0;
        private int checkLocNgayDatThue = 0;
        private int checkLocNgayTra = 0;
        private string kieuDatThue = "";

        public FormDatXeVaThueXe()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.LightBlue400,
                Accent.LightBlue400, TextShade.WHITE);
        }

        public FormDatXeVaThueXe(string str1, string str2, string str3, string str4) : this()
        {
            this.dSCTKKH = new DanhSachCacTaiKhoanKhachHang(str1, str2, str3, str4);
        }

        private void HienThilblNgayGio()
        {
            lblHienThiNgayGio.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        }

        private void FormDatXeVaThueXe_Load(object sender, EventArgs e)
        {
            HienThilblNgayGio();
            lblChaoKhachHang.Text = "Xin chào, " + dSCTKKH.HoVaTenKhachHang;

            mGGDAO.XoaMaGiamGiaHetHan(DateTime.Now.Date.ToString("dd/MM/yyyy"));
            tTXDAO.CapNhatSoLuongXeDuocDat(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void timerHienThi_Tick(object sender, EventArgs e)
        {
            HienThilblNgayGio();
        }

        private void btnHuyDatVaTraXe_Click(object sender, EventArgs e)
        {
            Form FrmHuyTraXe = new FormHuyDatVaTraXe(dSCTKKH.HoVaTenKhachHang, dSCTKKH.CMNDKhachHang, dSCTKKH.SoDienThoaiKhachHang, 
                dSCTKKH.DiaChiKhachHang);
            FrmHuyTraXe.Show();
            this.Hide();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Form FrmDangNhap = new FormDangNhap(1);
            FrmDangNhap.Show();
            this.Hide();
        }

        private void LayDanhSachVaDoiTenHeaderLocXe()
        {
            if (dtpNgayThueXe.Value > DateTime.Now.Date)
            {
                tTXDAO.LocDanhSachDatXe(ref gvDanhSachXeDaLoc, loaiXe, hangXe, Min, Max, dtpNgayThueXe.Value.ToString("dd/MM/yyyy"),
                    dtpNgayTraXe.Value.ToString("dd/MM/yyyy"));
            }
            else
            {
                tTXDAO.LocDanhSachThueXe(ref gvDanhSachXeDaLoc, loaiXe, hangXe, Min, Max);
            }

            gvDanhSachXeDaLoc.Columns[0].HeaderText = "Loại Xe";
            gvDanhSachXeDaLoc.Columns[1].HeaderText = "Hãng Xe";
            gvDanhSachXeDaLoc.Columns[2].HeaderText = "Mã Xe";
            gvDanhSachXeDaLoc.Columns[3].HeaderText = "Tên Xe";
            gvDanhSachXeDaLoc.Columns[4].HeaderText = "Giá Thuê (k)";
            gvDanhSachXeDaLoc.Columns[5].HeaderText = "Số Chuyến";
            gvDanhSachXeDaLoc.Columns[6].HeaderText = "Đánh Giá (*)";
        }

        private void LayDanhSachVaDoiTenHeaderFeedBack()
        {
            fBDAO.CacFeedBack(ref gvFeedBack, fB);

            gvFeedBack.Columns[0].HeaderText = "Tên Khách Hàng";
            gvFeedBack.Columns[1].HeaderText = "Đánh Giá";
            gvFeedBack.Columns[2].HeaderText = "Nội Dung";
        }

        private void LayKetQuaChon(ComboBox comboBox, ref string str)
        {
            if (comboBox.SelectedItem != null)
            {
                str = comboBox.SelectedItem.ToString();
            }
        }

        private void HienThiDatThue(int i)
        {
            if (i == 1)
            {
                errNgayDatThue.SetError(dtpNgayThueXe, "Ngày Đặt/Thuê Xe phải từ hôm nay " + DateTime.Now.Date.ToString("dd/MM/yyyy") +
                    " trở đi");
                btnDatXe.Enabled = false;
                btnThueXe.Enabled = false;
            }
            else if (i == 2)
            {
                btnDatXe.Enabled = true;
                btnThueXe.Enabled = false;
            }
            else if (i == 3)
            {
                btnDatXe.Enabled = false;
                btnThueXe.Enabled = true;
            }
            TongTien(dSXHT, ref tongTien);
        }

        private void CheckNgayDatThueVaTra()
        {
            errNgayTra.SetError(dtpNgayTraXe, "Ngày Trả Xe phải sau ngày Đặt/Thuê Xe");
            lblSoNgayThue.Text = "... ngày";
            btnDatXe.Enabled = false;
            btnThueXe.Enabled = false;
            TongTien(dSXHT, ref tongTien);
        }

        private void dtpNgayThueXe_ValueChanged(object sender, EventArgs e)
        {
            errNgayDatThue.SetError(dtpNgayThueXe, null);
            errNgayTra.SetError(dtpNgayTraXe, null);

            DateTime dayNgayDatThue = Convert.ToDateTime(dtpNgayThueXe.Value.ToString("yyyy/MM/dd"));

            if (dtpNgayThueXe.Value >= dtpNgayTraXe.Value)
            {
                CheckNgayDatThueVaTra();
            }
            else
            {
                HienThiDatThue(u.KiemTraNgayLonBe(dayNgayDatThue, DateTime.Now));
            }
            ngayDatThue = dtpNgayThueXe.Value.ToString("yyyy/MM/dd");
            txtNgayDatThue.Text = dtpNgayThueXe.Value.ToString("dd/MM/yyyy");

            checkLocNgayDatThue++;
        }

        private void dtpNgayTraXe_ValueChanged(object sender, EventArgs e)
        {
            errNgayTra.SetError(dtpNgayTraXe, null);
            errNgayDatThue.SetError(dtpNgayThueXe, null);

            if (dtpNgayTraXe.Value <= dtpNgayThueXe.Value)
            {
                CheckNgayDatThueVaTra();
            }
            else
            {
                ngayTra = dtpNgayTraXe.Value.ToString("yyyy/MM/dd");
                txtNgayTraXe.Text = dtpNgayTraXe.Value.ToString("dd/MM/yyyy");
                int kC = u.KhoangCachNgay(ngayDatThue, ngayTra);
                lblSoNgayThue.Text = kC.ToString() + " ngày";

                HienThiDatThue(u.KiemTraNgayLonBe(dtpNgayThueXe.Value, DateTime.Now));
            }

            checkLocNgayTra++;
        }

        private void ptbLocXe_Click(object sender, EventArgs e)
        {
            LayKetQuaChon(cbbLoaiXe, ref loaiXe);
            LayKetQuaChon(cbbHangXe, ref hangXe);
            string resultChonGiaTien = "";
            LayKetQuaChon(cbbGiaTien, ref resultChonGiaTien);

            if (checkLocNgayDatThue == 0 || checkLocNgayTra == 0 || loaiXe == "" || hangXe == "" || resultChonGiaTien == "" ||
                dtpNgayThueXe.Value.Date < DateTime.Now.Date || dtpNgayThueXe.Value.Date == dtpNgayTraXe.Value.Date ||
                dtpNgayThueXe.Value.Date > dtpNgayTraXe.Value.Date)
            {
                MessageBox.Show("Bạn chưa chọn đủ thông tin để lọc xe, vui lòng kiểm tra lại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                u.KhoangGiaTien(resultChonGiaTien, ref Min, ref Max);
                LayDanhSachVaDoiTenHeaderLocXe();
            }
        }

        private void gvDanhSachXeDaLoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            if (numrow >= 0)
            {
                loaiXe = gvDanhSachXeDaLoc.Rows[numrow].Cells[0].Value.ToString();
                hangXe = gvDanhSachXeDaLoc.Rows[numrow].Cells[1].Value.ToString();
                string maXe = gvDanhSachXeDaLoc.Rows[numrow].Cells[2].Value.ToString();
                string tenXe = gvDanhSachXeDaLoc.Rows[numrow].Cells[3].Value.ToString();
                int giaThue = Convert.ToInt32(gvDanhSachXeDaLoc.Rows[numrow].Cells[4].Value.ToString());
                int soChuyenDi = Convert.ToInt32(gvDanhSachXeDaLoc.Rows[numrow].Cells[5].Value.ToString());
                double danhGia = double.Parse(gvDanhSachXeDaLoc.Rows[numrow].Cells[6].Value.ToString());

                dSXHT = new DanhSachXeHienTai(loaiXe, hangXe, maXe, tenXe, giaThue, soChuyenDi, danhGia);

                lblLoaiXe.Text = dSXHT.LoaiXe;
                lblHangXe.Text = dSXHT.HangXe;
                lblMaXe.Text = dSXHT.MaXe;
                lblTenXe.Text = dSXHT.TenXe;
                lblGiaThue.Text = dSXHT.GiaThue.ToString() + " k";
                lblSoChuyen.Text = dSXHT.SoChuyen.ToString() + " chuyến";
                lblDanhGia.Text = dSXHT.DanhGia.ToString() + "*";

                lblTienThueNgay.Text = dSXHT.GiaThue.ToString() + " k / ngày";

                fB = new FeedBack(dSXHT.MaXe);
                LayDanhSachVaDoiTenHeaderFeedBack();

                btnDatXe.Visible = true;
                btnThueXe.Visible = true;

                TongTien(dSXHT, ref tongTien);
            }
        }

        private void gvFeedBack_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            if (numrow >= 0)
            {
                string hoVaTen = gvFeedBack.Rows[numrow].Cells[0].Value.ToString();
                string danhGia = gvFeedBack.Rows[numrow].Cells[1].Value.ToString();
                string noiDung = gvFeedBack.Rows[numrow].Cells[2].Value.ToString();

                rtbHienThiFeedBackChon.Text = u.XuatFeedBack(hoVaTen, danhGia, noiDung);
            }
        }   

        private void cbbKieuDatThueXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayKetQuaChon(cbbKieuDatThueXe, ref kieuDatThue);
            if (cbbKieuDatThueXe.SelectedItem != null)
            {
                if (cbbKieuDatThueXe.SelectedItem.ToString() == "Xe tự lái")
                {
                    txtDiaDiemDon.Enabled = false;
                    phiTaiXe = "0";
                    lblPhiTaiXe.Text = phiTaiXe + " k / ngày";
                    diaDiemDon = "Sảnh";
                    TongTien(dSXHT, ref tongTien);
                }
                else
                {
                    txtDiaDiemDon.Enabled = true;
                    phiTaiXe = "200";
                    lblPhiTaiXe.Text = phiTaiXe + " k / ngày";
                    diaDiemDon = txtDiaDiemDon.Text;
                    TongTien(dSXHT, ref tongTien);
                }
            }
        }

        private void cbbHopDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayKetQuaChon(cbbHopDong, ref vatGiuLai);
        }

        private void txtDiaDiemDon_TextChanged(object sender, EventArgs e)
        {
            diaDiemDon = txtDiaDiemDon.Text;
        }

        private void btnApDungMaGiamGia_Click(object sender, EventArgs e)
        {
            mGGDAO.ChiTietGiam(txtMaGiamGia.Text, ref giamGia);
            TongTien(dSXHT, ref tongTien);
        }

        private void TongTien(DanhSachXeHienTai dSXHT, ref int i)
        {
            if (dSXHT.TenXe == null)
            {
                lblTongTien.Text = "... k";
            }
            else
            {
                khoangCach = u.KhoangCachNgay(dtpNgayThueXe.Value.ToString("yyyy/MM/dd"), dtpNgayTraXe.Value.ToString("yyyy/MM/dd"));
                int tienThueTaiXe = Convert.ToInt32(phiTaiXe);
                i = u.ThanhToan(dSXHT.GiaThue, tienThueTaiXe, khoangCach) -
                    (((u.ThanhToan(dSXHT.GiaThue, tienThueTaiXe, khoangCach)) * giamGia) / 100);
                if (btnDatXe.Enabled == false && btnThueXe.Enabled == false && dSXHT.TenXe == null)
                {
                    lblSoNgayThue.Text = "0 ngày";
                    lblTongTien.Text = "... nghìn";
                }
                else
                {
                    lblTongTien.Text = i.ToString("N0", CultureInfo.CreateSpecificCulture("vi-VN")) + " k";
                    lblHienThiTietKiem.Text = "Đã giảm " + giamGia + " %";
                }
            }
        }

        private void btnDatXe_Click(object sender, EventArgs e)
        {
            datthue = 1;
            ThucHienChucNang("DoanhThuDatXe");
        }

        private void btnThueXe_Click(object sender, EventArgs e)
        {
            datthue = 0;
            ThucHienChucNang("DoanhThuThueXe");
        }

        private void ThucHienChucNang(string str)
        {
            ngayDatThue = dtpNgayThueXe.Value.ToString("dd/MM/yyyy");
            ngayTra = dtpNgayTraXe.Value.ToString("dd/MM/yyyy");

            if (dSXHT.MaXe != null && kieuDatThue != "" && diaDiemDon != "" && vatGiuLai != "")
            {
                if (datthue == 1)
                {
                    int temp = dTDAO.LaySoLuongIDDoanhThu("datxe");
                    dTDX = new DoanhThuDatXe(temp, dSCTKKH.HoVaTenKhachHang, dSCTKKH.CMNDKhachHang, dSCTKKH.SoDienThoaiKhachHang,
                        dSCTKKH.DiaChiKhachHang, dSXHT.LoaiXe, dSXHT.HangXe, dSXHT.MaXe, dSXHT.TenXe, ngayDatThue, ngayTra, diaDiemDon,
                        vatGiuLai, int.Parse(phiTaiXe), tongTien);
                    dTDAO.ThemVaoDoanhThuDatXe(dTDX);
                }
                else if (datthue == 0)
                {
                    int temp = dTDAO.LaySoLuongIDDoanhThu("thuexe");
                    dTTX = new DoanhThuThueXe(temp, dSCTKKH.HoVaTenKhachHang, dSCTKKH.CMNDKhachHang, dSCTKKH.SoDienThoaiKhachHang,
                        dSCTKKH.DiaChiKhachHang, dSXHT.LoaiXe, dSXHT.HangXe, dSXHT.MaXe, dSXHT.TenXe, ngayDatThue, ngayTra, diaDiemDon,
                        vatGiuLai, int.Parse(phiTaiXe), tongTien);
                    dTDAO.ThemVaoDoanhThuThueXe(dTTX);
                    tTXDAO.CapNhatSoLuongXe(dSXHT.MaXe, 0);
                }

                int i = dTDAO.LaySoLuongIDDoanhThu("datthue");
                cTDT = new ChiTietDatThue(i, dSXHT.MaXe, ngayDatThue, ngayTra);
                dTDAO.ThemVaoChiTietDatThue(cTDT);
                Resest();
            }
            else
            {
                MessageBox.Show("Kiểm tra lại các thông tin cần thiết để tạo bill", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HuyChecked(ComboBox cbb)
        {
            cbb.SelectedIndex = -1;
        }

        private void Resest()
        {
            gvDanhSachXeDaLoc.DataSource = null;
            gvFeedBack.DataSource = null;

            HuyChecked(cbbKieuDatThueXe);
            HuyChecked(cbbHopDong);

            checkLocNgayDatThue = 0;
            checkLocNgayTra = 0;

            txtDiaDiemDon.Text = "";
            rtbHienThiFeedBackChon.Text = "";
            lblTienThueNgay.Text = "0 nghìn / ngày";
            lblSoNgayThue.Text = "0 ngày";
            lblPhiTaiXe.Text = "0 nghìn / ngày";
            lblTongTien.Text = "... nghìn";
            lblLoaiXe.Text = "...";
            lblHangXe.Text = "...";
            lblMaXe.Text = "...";
            lblTenXe.Text = "...";
            lblGiaThue.Text = "...";
            lblSoChuyen.Text = "...";
            lblDanhGia.Text = "...";
            dSXHT = new DanhSachXeHienTai();
        }
    }
}
