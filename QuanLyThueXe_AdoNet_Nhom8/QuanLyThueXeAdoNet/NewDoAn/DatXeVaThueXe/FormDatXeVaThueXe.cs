using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace NewDoAn
{
    public partial class FormDatXeVaThueXe : MaterialForm
    {
        Util u = new Util();
        DBConnection dBC = new DBConnection();
        ThongTinCaNhan tTCN = new ThongTinCaNhan();
        ThongTinXe tTX = new ThongTinXe();
        ThongTinXeDAO tTXDAO = new ThongTinXeDAO();
        FeedBack fB = new FeedBack();
        FeedBackDAO fBDAO = new FeedBackDAO();
        ThongTinBill tTB = new ThongTinBill();
        ThongTinBillDAO tTBDAO = new ThongTinBillDAO();
        MaGiamGiaDAO mGGDAO = new MaGiamGiaDAO();

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
            this.tTCN = new ThongTinCaNhan(str1, str2, str3, str4);
        }

        private void HienThilblNgayGio()
        {
            lblHienThiNgayGio.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        }

        private void FormDatXeVaThueXe_Load(object sender, EventArgs e)
        {
            HienThilblNgayGio();
            lblChaoKhachHang.Text = "Xin chào, " + tTCN.HoVaTen;

            mGGDAO.XoaMaGiamGiaHetHan(DateTime.Now.Date.ToString("dd/MM/yyyy"));
            tTXDAO.CapNhatSoLuongXeDuocDat(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void timerHienThi_Tick(object sender, EventArgs e)
        {
            HienThilblNgayGio();
        }

        private void btnHuyDatVaTraXe_Click(object sender, EventArgs e)
        {
            Form FrmHuyTraXe = new FormHuyDatVaTraXe(tTCN.HoVaTen, tTCN.CMND, tTCN.SDT, tTCN.DiaChi);
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
                gvDanhSachXeDaLoc.DataSource = tTXDAO.LocDanhSachDatXe(loaiXe, hangXe, Min, Max, dtpNgayThueXe.Value.ToString("dd/MM/yyyy"),
                    dtpNgayTraXe.Value.ToString("dd/MM/yyyy"));
            }
            else
            {
                gvDanhSachXeDaLoc.DataSource = tTXDAO.LocDanhSachThueXe(loaiXe, hangXe, Min, Max);
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
            gvFeedBack.DataSource = fBDAO.CacFeedBack(fB);

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

        private void CheckNgayDatThueVaTra()
        {
            errNgayTra.SetError(dtpNgayTraXe, "Ngày Trả Xe phải sau ngày Đặt/Thuê Xe");
            lblSoNgayThue.Text = "... ngày";
            btnDatXe.Enabled = false;
            btnThueXe.Enabled = false;
            TongTien(tTX, ref tongTien);
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
                ngayDatThue = dtpNgayThueXe.Value.ToString("yyyy/MM/dd");
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
                float danhGia = float.Parse(gvDanhSachXeDaLoc.Rows[numrow].Cells[6].Value.ToString());

                tTX = new ThongTinXe(loaiXe, hangXe, maXe, tenXe, giaThue, soChuyenDi, danhGia);

                lblLoaiXe.Text = tTX.LoaiXe;
                lblHangXe.Text = tTX.HangXe;
                lblMaXe.Text = tTX.MaXe;
                lblTenXe.Text = tTX.TenXe;
                lblGiaThue.Text = tTX.GiaThue.ToString() + " k";
                lblSoChuyen.Text = tTX.SoChuyen.ToString() + " chuyến";
                lblDanhGia.Text = tTX.DanhGia.ToString() + "*";

                lblTienThueNgay.Text = tTX.GiaThue.ToString() + " k / ngày";

                fB = new FeedBack(tTX);
                LayDanhSachVaDoiTenHeaderFeedBack();

                btnDatXe.Visible = true;
                btnThueXe.Visible = true;

                TongTien(tTX, ref tongTien);
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
                string selectedValue = cbbKieuDatThueXe.SelectedItem.ToString();
                if (cbbKieuDatThueXe.SelectedItem.ToString() == "Xe tự lái")
                {
                    txtDiaDiemDon.Enabled = false;
                    phiTaiXe = "0";
                    lblPhiTaiXe.Text = phiTaiXe + " k / ngày";
                    diaDiemDon = "Sảnh";
                    TongTien(tTX, ref tongTien);
                }
                else
                {
                    txtDiaDiemDon.Enabled = true;
                    phiTaiXe = "200";
                    lblPhiTaiXe.Text = phiTaiXe + " k / ngày";
                    diaDiemDon = txtDiaDiemDon.Text;
                    TongTien(tTX, ref tongTien);
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
            dBC.ChiTietGiam(txtMaGiamGia.Text, ref giamGia);
            TongTien(tTX, ref tongTien);
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
            TongTien(tTX, ref tongTien);
        }

        private void TongTien(ThongTinXe tTX, ref int i)
        {
            if (tTX.TenXe == null)
            {
                lblTongTien.Text = "... k";
            }
            else
            {
                khoangCach = u.KhoangCachNgay(dtpNgayThueXe.Value.ToString("yyyy/MM/dd"), dtpNgayTraXe.Value.ToString("yyyy/MM/dd"));
                int tienThueTaiXe = Convert.ToInt32(phiTaiXe);
                i = u.ThanhToan(tTX.GiaThue, tienThueTaiXe, khoangCach) -
                    (((u.ThanhToan(tTX.GiaThue, tienThueTaiXe, khoangCach)) * giamGia) / 100);
                if (btnDatXe.Enabled == false && btnThueXe.Enabled == false && tTX.TenXe == null)
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
            tTB = new ThongTinBill(tTCN, tTX, phiTaiXe, diaDiemDon, ngayDatThue, ngayTra, vatGiuLai, tongTien.ToString());

            if (tTX.MaXe != null && kieuDatThue != "" && diaDiemDon != "" && vatGiuLai != "")
            {
                tTBDAO.ThemVaoDoanhThu(str, tTB);
                tTBDAO.ThemVaoChiTietDatThue(tTB.TTX.MaXe, tTB.NgayThue, tTB.NgayTra);
                if (datthue == 0)
                {
                    tTXDAO.CapNhatSoLuongXe(tTX.MaXe, 0);
                }
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
            tTX = new ThongTinXe();
        }
    }
}
