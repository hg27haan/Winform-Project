using iTextSharp.text.pdf;
using iTextSharp.text;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Paragraph = iTextSharp.text.Paragraph;

namespace NewDoAn
{
    public partial class FormNhanVien : MaterialForm
    {
        TaiKhoanDAO tKDAO = new TaiKhoanDAO();
        DoanhThuDAO dTDAO = new DoanhThuDAO();
        ThongTinXeDAO tTXDAO = new ThongTinXeDAO();
        MaGiamGiaDAO mGGDAO = new MaGiamGiaDAO();
        DanhSachCacTaiKhoanKhachHang dSCTKKH = new DanhSachCacTaiKhoanKhachHang();

        private string loaiTaiKhoan = "";
        private string hoVaTen = "";
        private string cMND = "";
        private string sDT = "";
        private string diaChi = "";
        private string tenDangNhap = "";
        private string matKhau = "";
        private string tongTien = "";

        private string suaLoaiXe = "";
        private string suaHangXe = "";
        private string suaMaXe = "";
        private string suaTenXe = "";
        private string suaSoLuongConLai = "";
        private string suaGiaThue = "";
        private string suaSoChuyen = "";
        private string suaDanhGia = "";
        private string taiKhoanNV = "";
        private string matKhauNV = "";

        public FormNhanVien()
        {
            InitializeComponent();
        }

        public FormNhanVien(string loaiTaiKhoan) : this()
        {
            this.loaiTaiKhoan = loaiTaiKhoan;
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            if (loaiTaiKhoan == "nv")
            {
                materialTabControl1.TabPages.Remove(tpDoanhThuThang);
                materialTabControl1.TabPages.Remove(tpBieuDoThongKe);
                materialTabControl1.TabPages.Remove(tpThemXe);
                materialTabControl1.TabPages.Remove(tpMaGiamGia);
                materialTabControl1.TabPages.Remove(tpTaiKhoanNhanVien);
            }
            LoadTrendingThueXe();
            mGGDAO.XoaMaGiamGiaHetHan(DateTime.Now.Date.ToString("dd/MM/yyyy"));
            tTXDAO.CapNhatSoLuongXeDuocDat(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private bool KiemTraNgayCuoiThangSau5h30()
        {
            DateTime now = DateTime.Now;
            int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
            bool isLastDayOfMonth = now.Day == daysInMonth;
            if (isLastDayOfMonth == true && DateTime.Now > DateTime.Today.AddHours(17).AddMinutes(30))
            {
                return true;
            }    
            return false;
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedIndex == 0)
            {
                LoadTrendingThueXe();
            }
            if (materialTabControl1.SelectedIndex == 1)
            {
                LoadVaDoiTenDanhSachTaiKhoanKhachHang();
            }
            if (materialTabControl1.SelectedIndex == 2)
            {
                DanhSachKiemTraXeDatThue();
            }
            if (materialTabControl1.SelectedIndex == 3)
            {
                lblHienThiNgayXePhaiTra.Text = DateTime.Now.ToString("dd/MM/yyyy");
                LoadVaDoiTenDanhSachXePhaiTraHomNay();
            }
            if (materialTabControl1.SelectedIndex == 4)
            {
                if (DateTime.Now > DateTime.Today.AddHours(17).AddMinutes(30))
                {
                    btnXuatRaPDF.Enabled = true;
                }    
                lblHienThiNgayDoanhThu.Text = DateTime.Now.ToString("dd/MM/yyyy");
                LoadVaDoiTenDanhSachDoanhThuHomNay();
                lblTongDoanhThu.Text = "Tổng doanh thu: " + TinhTongTienHienTai(gvDoanhThuHomNay, ref tongTien);
            }
            if (materialTabControl1.SelectedIndex == 5)
            {
                if (KiemTraNgayCuoiThangSau5h30() == true)
                {
                    btnTongKetVaXuatRaJPG.Enabled = true;
                }
                lblHienLaThang.Text = DateTime.Now.ToString("MM/yyyy");
                LoadBieuDoDoanhThuThang();
            }
            if (materialTabControl1.SelectedIndex == 6)
            {
                DateTime now = DateTime.Now;
                int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
                bool isLastDayOfMonth = now.Day == daysInMonth;

                if (DateTime.Now.Month == 12 && KiemTraNgayCuoiThangSau5h30() == true)
                {
                    btnDoanhThuNamJPG.Enabled = true;
                }
                LoadBieuDoDoanhThuNam();
            }
            if (materialTabControl1.SelectedIndex == 8)
            {
                lblNgayMaGiamGia.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                LoadVaDoiTenMaGiamGia();
            }
            if (materialTabControl1.SelectedIndex == 9)
            {
                LoadVaDoiTenTKNhanVien();
            }
        }

        private void LoadTrendingThueXe()
        {
            gvTrending.DataSource = null;
            tTXDAO.TrendingThueXe(ref gvTrending);

            gvTrending.Columns[0].HeaderText = "Loại Xe";
            gvTrending.Columns[1].HeaderText = "Hãng Xe";
            gvTrending.Columns[2].HeaderText = "Mã Xe";
            gvTrending.Columns[3].HeaderText = "Tên Xe";
            gvTrending.Columns[4].HeaderText = "Số Lượng Còn Lại";
            gvTrending.Columns[5].HeaderText = "Giá Thuê";
            gvTrending.Columns[6].HeaderText = "Số Chuyến";
            gvTrending.Columns[7].HeaderText = "Đánh Giá";
        }

        private void gvTrending_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txtSuaLoaiXe.Text = gvTrending.Rows[numrow].Cells[0].Value.ToString();
                txtSuaHangXe.Text = gvTrending.Rows[numrow].Cells[1].Value.ToString();
                txtSuaMaXe.Text = gvTrending.Rows[numrow].Cells[2].Value.ToString();
                txtSuaTenXe.Text = gvTrending.Rows[numrow].Cells[3].Value.ToString();
                txtSuaSoLuongConLai.Text = gvTrending.Rows[numrow].Cells[4].Value.ToString();
                txtSuaGiaThue.Text = gvTrending.Rows[numrow].Cells[5].Value.ToString();
                txtSuaSoChuyen.Text = gvTrending.Rows[numrow].Cells[6].Value.ToString();
                txtSuaDanhGia.Text = gvTrending.Rows[numrow].Cells[7].Value.ToString();

                suaLoaiXe = txtSuaLoaiXe.Text;
                suaHangXe = txtSuaHangXe.Text;
                suaMaXe = txtSuaMaXe.Text;
                suaTenXe = txtSuaTenXe.Text;
                suaSoLuongConLai = txtSuaSoLuongConLai.Text;
                suaGiaThue = txtSuaGiaThue.Text;
                suaSoChuyen = txtSuaSoChuyen.Text;
                suaDanhGia = txtSuaDanhGia.Text;
            }
        }

        private void btnChinhSuaThongTinXe_Click(object sender, EventArgs e)
        {
            if (tTXDAO.KiemTraXeConDatThue(suaMaXe) == true)
            {
                MessageBox.Show("Xe này vẫn còn đang được Đặt/Thuê nên không thể chỉnh sửa, phải đợi khi xe không trong trạng thái " +
                    "Đặt/Thuê mới thực hiện được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtSuaLoaiXe.Text != suaLoaiXe || txtSuaHangXe.Text != suaHangXe || txtSuaTenXe.Text != suaTenXe ||
                txtSuaSoLuongConLai.Text != suaSoLuongConLai || txtSuaGiaThue.Text != suaGiaThue ||
                txtSuaSoChuyen.Text != suaSoChuyen || txtSuaDanhGia.Text != suaDanhGia)
                {
                    string inputSoLuongConLai = txtSuaSoLuongConLai.Text;
                    string inputGiaThue = txtSuaGiaThue.Text;
                    string inputSoChuyen = txtSuaSoChuyen.Text;
                    string inputDanhGia = txtSuaDanhGia.Text;
                    int SoLuongConLai, GiaThue, SoChuyen;
                    float DanhGia;
                    if (int.TryParse(inputSoLuongConLai, out SoLuongConLai) && int.TryParse(inputGiaThue, out GiaThue) &&
                        int.TryParse(inputSoChuyen, out SoChuyen) && float.TryParse(inputDanhGia, out DanhGia))
                    {
                        tTXDAO.CapNhatThongTinXe(txtSuaLoaiXe.Text, txtSuaHangXe.Text, txtSuaMaXe.Text, txtSuaTenXe.Text, SoLuongConLai,
                            GiaThue, SoChuyen, DanhGia);
                        LoadTrendingThueXe();

                        ResestAllTextBox();
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra lại phần Số Lượng Còn Lại/Giá Thuê/Số Chuyến/Đánh Giá", "Thông báo lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Các thông tin chưa được thay đổi nên không thực hiện được chức năng này", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnLoaiBoXe_Click(object sender, EventArgs e)
        {
            if (tTXDAO.KiemTraXeConDatThue(suaMaXe) == true)
            {
                MessageBox.Show("Xe này vẫn còn đang được Đặt/Thuê nên không thể chỉnh sửa, phải đợi khi xe không trong trạng thái " +
                    "Đặt/Thuê mới thực hiện được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn loại bỏ xe này khỏi hệ thống?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    tTXDAO.XoaXeKhoiHeThong(suaMaXe);
                    LoadTrendingThueXe();

                    ResestAllTextBox();
                }
            }    
        }

        private void LoadVaDoiTenDanhSachTaiKhoanKhachHang()
        {
            gvDanhSachTaiKhoanKhachHang.DataSource = null;
            tKDAO.LayDanhSachTaiKhoanKhachHang(ref gvDanhSachTaiKhoanKhachHang);

            gvDanhSachTaiKhoanKhachHang.Columns[0].HeaderText = "Họ và Tên";
            gvDanhSachTaiKhoanKhachHang.Columns[1].HeaderText = "CMND";
            gvDanhSachTaiKhoanKhachHang.Columns[2].HeaderText = "SĐT";
            gvDanhSachTaiKhoanKhachHang.Columns[3].HeaderText = "Địa Chỉ";
            gvDanhSachTaiKhoanKhachHang.Columns[4].HeaderText = "Tên Đăng Nhập";
            gvDanhSachTaiKhoanKhachHang.Columns[5].HeaderText = "Mật Khẩu";
        }

        private void gvDanhSachTaiKhoanKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txtHoVaTen.Text = gvDanhSachTaiKhoanKhachHang.Rows[numrow].Cells[0].Value.ToString();
                txtCMND.Text = gvDanhSachTaiKhoanKhachHang.Rows[numrow].Cells[1].Value.ToString();
                txtSDT.Text = gvDanhSachTaiKhoanKhachHang.Rows[numrow].Cells[2].Value.ToString();
                txtDiaChi.Text = gvDanhSachTaiKhoanKhachHang.Rows[numrow].Cells[3].Value.ToString();
                txtTenDangNhap.Text = gvDanhSachTaiKhoanKhachHang.Rows[numrow].Cells[4].Value.ToString();
                txtMatKhau.Text = gvDanhSachTaiKhoanKhachHang.Rows[numrow].Cells[5].Value.ToString();

                hoVaTen = txtHoVaTen.Text;
                cMND = txtCMND.Text;
                sDT = txtSDT.Text;
                diaChi = txtDiaChi.Text;
                tenDangNhap = txtTenDangNhap.Text;
                matKhau = txtMatKhau.Text;

                dSCTKKH = new DanhSachCacTaiKhoanKhachHang(hoVaTen, cMND, sDT, diaChi);
            }
        }

        private void btnSuaThongTIn_Click(object sender, EventArgs e)
        {
            if (dTDAO.KiemTraKhachConDatThueXe(dSCTKKH) == true)
            {
                MessageBox.Show("Khách hàng này còn đang Đặt/Thuê xe nên không thể thực hiện được, phải đợi khách Hủy/Trả xe đang Đặt/Thuê " +
                    "mới có thể chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtHoVaTen.Text != hoVaTen || txtCMND.Text != cMND || txtSDT.Text != sDT || txtDiaChi.Text != diaChi
                || txtMatKhau.Text != matKhau)
                {
                    tKDAO.SuaThongTinDangNhapKhach(txtHoVaTen.Text, txtCMND.Text, txtSDT.Text, txtDiaChi.Text, tenDangNhap,
                        txtMatKhau.Text);
                    LoadVaDoiTenDanhSachTaiKhoanKhachHang();

                    ResestAllTextBox();
                }
                else
                {
                    MessageBox.Show("Các thông tin của khách hàng " + hoVaTen + " chưa được thay đổi nên không thể thực hiện",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (dTDAO.KiemTraKhachConDatThueXe(dSCTKKH) == true)
            {
                MessageBox.Show("Khách hàng này còn đang Đặt/Thuê xe nên không thể thực hiện được, phải đợi khách Hủy/Trả xe đang Đặt/Thuê " +
                    "mới có thể chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tKDAO.XoaTaiKhoanKhachHang(txtTenDangNhap.Text);
                LoadVaDoiTenDanhSachTaiKhoanKhachHang();

                ResestAllTextBox();
            }    
        }

        private void DanhSachKiemTraXeDatThue()
        {
            gvKiemTraXeDatThue.DataSource = null;
            dTDAO.KiemTraXeDatThue(ref gvKiemTraXeDatThue, txtTenKhachHang.Text, txtCMNDKhachHang.Text);

            gvKiemTraXeDatThue.Columns[0].HeaderText = "Loại Xe";
            gvKiemTraXeDatThue.Columns[1].HeaderText = "Hãng Xe";
            gvKiemTraXeDatThue.Columns[2].HeaderText = "Mã Xe";
            gvKiemTraXeDatThue.Columns[3].HeaderText = "Tên Xe";
            gvKiemTraXeDatThue.Columns[4].HeaderText = "Ngày Thuê";
            gvKiemTraXeDatThue.Columns[5].HeaderText = "Ngày Trả";
            gvKiemTraXeDatThue.Columns[6].HeaderText = "Địa Điểm Đón";
        }

        private void btnKiemTraTrongDanhSach_Click(object sender, EventArgs e)
        {
            DanhSachKiemTraXeDatThue();
        }

        private void LoadVaDoiTenDanhSachXePhaiTraHomNay()
        {
            gvDanhSachXeTraHomNay.DataSource = null;
            dTDAO.LocDanhSachXePhaiTraHomNay(ref gvDanhSachXeTraHomNay, DateTime.Now.Date.ToString("dd/MM/yyyy"));

            gvDanhSachXeTraHomNay.Columns[0].HeaderText = "Họ và Tên";
            gvDanhSachXeTraHomNay.Columns[1].HeaderText = "CMND";
            gvDanhSachXeTraHomNay.Columns[2].HeaderText = "SĐT";
            gvDanhSachXeTraHomNay.Columns[3].HeaderText = "Địa Chỉ";
            gvDanhSachXeTraHomNay.Columns[4].HeaderText = "Loại Xe";
            gvDanhSachXeTraHomNay.Columns[5].HeaderText = "Hãng Xe";
            gvDanhSachXeTraHomNay.Columns[6].HeaderText = "Mã Xe";
            gvDanhSachXeTraHomNay.Columns[7].HeaderText = "Tên Xe";
        }

        private void LoadVaDoiTenDanhSachDoanhThuHomNay()
        {
            gvDoanhThuHomNay.DataSource = null;
            dTDAO.LayDoanhThuHomNay(ref gvDoanhThuHomNay, DateTime.Now.Date.ToString("dd/MM/yyyy"));

            gvDoanhThuHomNay.Columns[0].HeaderText = "Họ và Tên";
            gvDoanhThuHomNay.Columns[1].HeaderText = "CMND";
            gvDoanhThuHomNay.Columns[2].HeaderText = "SĐT";
            gvDoanhThuHomNay.Columns[3].HeaderText = "Tổng Tiền (k)";
        }

        private string TinhTongTienHienTai(DataGridView gv, ref string tongTien)
        {
            int result = 0;
            foreach (DataGridViewRow row in gv.Rows)
            {
                if (!row.IsNewRow)
                {
                    result += int.Parse(row.Cells[3].Value.ToString());
                }
            }
            tongTien = result.ToString();
            return result.ToString("N0", CultureInfo.CreateSpecificCulture("vi-VN")) + " k";
        }

        private void btnTongKetCuoiCa_Click(object sender, EventArgs e)
        {
            dTDAO.ThemVaoDoanhThuThang(DateTime.Now.Date.ToString("dd/MM/yyyy"), int.Parse(tongTien));
            btnTongKetCuoiCa.Enabled = false;
        }

        private void btnXuatRaPDF_Click(object sender, EventArgs e)
        {
            if (gvDoanhThuHomNay.DataSource == null)
            {
                MessageBox.Show("Dữ liệu đang bị rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                BaseFont baseFont = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12);

                Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                try
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PdfWriter.GetInstance(doc, new FileStream(saveFileDialog1.FileName, FileMode.Create));

                        doc.Open();

                        PdfPTable pdfTable = new PdfPTable(gvDoanhThuHomNay.ColumnCount);
                        pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 100;
                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                        foreach (DataGridViewColumn column in gvDoanhThuHomNay.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
                            cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                            pdfTable.AddCell(cell);
                        }

                        foreach (DataGridViewRow row in gvDoanhThuHomNay.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), font));
                                }
                            }
                        }

                        string ngay = "Doanh thu ngày: " + DateTime.Now.Date.ToString("dd/MM/yyyy") + "\n";
                        ngay += "Total: " + int.Parse(tongTien).ToString("N0",
                            CultureInfo.CreateSpecificCulture("vi-VN")) + " k\n\n";
                        doc.Add(new Paragraph(ngay));

                        doc.Add(pdfTable);

                        doc.Close();

                        MessageBox.Show("Tệp PDF đã được lưu thành công!", "Thông báo");

                        btnTongKetCuoiCa.Enabled = true;
                        btnXuatRaPDF.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }    
        }

        private void ResestBieuDo(Chart c)
        {
            foreach (Series series in c.Series)
            {
                series.Points.Clear();
            }
        }

        private void LoadBieuDoDoanhThuThang()
        {
            ResestBieuDo(chartDBC);

            List<string> lstNgay = new List<string>();
            List<int> lstDoanhThu = new List<int>();
            dTDAO.LayDataBaseDoanhThuThang(ref lstNgay, ref lstDoanhThu);

            for (int i = 0; i < lstNgay.Count; i++)
            {
                chartDBC.Series["DoanhThuThang"].Points.AddXY(lstNgay[i], lstDoanhThu[i]);
                chartDBC.Series["DoanhThuThang"].Points[i].Label = lstDoanhThu[i].ToString("N0",
                    CultureInfo.CreateSpecificCulture("vi-VN"));
                chartDBC.Series["DoanhThuThang"].Points[i].Color = Color.SteelBlue;
                chartDBC.Series["DoanhThuThang"].Points[i].AxisLabel = lstNgay[i];
                chartDBC.Titles["Title1"].Text = "Doanh thu tháng " + DateTime.Now.Date.ToString("MM/yyyy");
            }
        }

        private void LuuJPG(Chart c)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPEG Image|*.jpg";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                Bitmap bmp = new Bitmap(c.Width, c.Height);
                c.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));

                bmp.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);

                MessageBox.Show("Lưu ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTongKetVaXuatRaJPG_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Chắc chắn muốn xuất ra file ảnh thống kê doanh thu tháng qua?\n " +
            "Xuất xong sẽ xóa toàn bộ dữ liệu trong tháng?", "Cảnh báo", MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                LuuJPG(chartDBC);
                int doanhThuMotThang = 0;
                dTDAO.TinhDoanhThuThang(ref doanhThuMotThang);
                dTDAO.ThemVaoDoanhThuNam(DateTime.Now.Date.ToString("MM/yyyy"), doanhThuMotThang);
                btnTongKetVaXuatRaJPG.Enabled = false;
            }
        }

        private void LoadBieuDoDoanhThuNam()
        {
            ResestBieuDo(chartDoanhThuNam);

            List<string> lstThang = new List<string>();
            List<int> lstDoanhThu = new List<int>();
            dTDAO.LayDataBaseDoanhThuNam(ref lstThang, ref lstDoanhThu);

            for (int i = 0; i < lstThang.Count; i++)
            {
                chartDoanhThuNam.Series["DoanhThuNam"].Points.AddXY(lstThang[i], lstDoanhThu[i]);
                chartDoanhThuNam.Series["DoanhThuNam"].Points[i].Label = lstDoanhThu[i].ToString("N0",
                    CultureInfo.CreateSpecificCulture("vi-VN"));
                chartDoanhThuNam.Series["DoanhThuNam"].Points[i].Color = Color.SteelBlue;
                chartDoanhThuNam.Series["DoanhThuNam"].Points[i].AxisLabel = lstThang[i];
                chartDoanhThuNam.Titles["Title1"].Text = "Doanh thu năm " + DateTime.Now.Date.ToString("yyyy");
            }
        }

        private void btnDoanhThuNamJPG_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Chắc chắn muốn xuất ra file ảnh thống kê năm qua?\n Xuất xong sẽ xóa " +
                "toàn bộ dữ liệu trong năm?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                LuuJPG(chartDoanhThuNam);
                dTDAO.XoaDoanhThuNam();
                btnDoanhThuNamJPG.Enabled = false;
            }
        }

        private void btnXacNhanThem_Click(object sender, EventArgs e)
        {
            if (cboLoaiXe.Text == "" || cboHangXe.Text == "" || txtThemMaXe.Text == "" || txtThemTenXe.Text == "" ||
                txtThemGiaThue.Text == "")
            {
                MessageBox.Show("Thông tin Xe không được để trống, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                if (tTXDAO.KiemTraMaXe(txtThemMaXe.Text) == false)
                {
                    string inputthemGiaThue = txtThemGiaThue.Text;
                    int GiaThue;
                    if (int.TryParse(inputthemGiaThue, out GiaThue))
                    {
                        tTXDAO.ThemXeVaoHeThong(cboLoaiXe.Text, cboHangXe.Text, txtThemMaXe.Text, txtThemTenXe.Text, GiaThue);
                        ResestAllTextBox();
                    }
                }
                else
                {
                    MessageBox.Show("Mã Xe đã bị trùng, vui lòng đổi Mã Xe khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtThemMaXe.Text = "";
                }
            }
        }

        private void LoadVaDoiTenMaGiamGia()
        {
            gvMaGiamGia.DataSource = null;
            mGGDAO.LayDanhSach(ref gvMaGiamGia);

            gvMaGiamGia.Columns[0].HeaderText = "Code";
            gvMaGiamGia.Columns[1].HeaderText = "Hạn Sử Dụng";
            gvMaGiamGia.Columns[2].HeaderText = "Chi Tiết Giảm (%)";
        }

        private void btnThemMaGiamGia_Click(object sender, EventArgs e)
        {
            if (txtCode.Text != "" && txtChiTietGiam.Text != "")
            {
                if (mGGDAO.KiemTraMaGiamGia(txtCode.Text) == true)
                {
                    MessageBox.Show("Đã tồn tại Mã Giảm Giá này, hãy thử tạo Mã Giảm Giá khác", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (dtpHSD.Value.Date > DateTime.Now.Date)
                    {
                        string inputChiTietGiam = txtChiTietGiam.Text;
                        int ChiTietGiam;
                        if (int.TryParse(inputChiTietGiam, out ChiTietGiam))
                        {
                            mGGDAO.ThemMaGiamGia(txtCode.Text, dtpHSD.Value.ToString("dd/MM/yyyy"), txtChiTietGiam.Text);

                            LoadVaDoiTenMaGiamGia();

                            ResestAllTextBox();
                        }
                        else
                        {
                            MessageBox.Show("Kiểm tra lại ở phần Chi Tiết Giảm", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra lại mục Hạn Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Các thông tin cần thiết không được để trống", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadVaDoiTenTKNhanVien()
        {
            gvTaiKhoanNhanVien.DataSource = null;
            tKDAO.LoadDanhSachTKNhanVien(ref gvTaiKhoanNhanVien);

            gvTaiKhoanNhanVien.Columns[0].HeaderText = "Tên Tài Khoản";
            gvTaiKhoanNhanVien.Columns[1].HeaderText = "Mật Khẩu";
        }

        private void gvTaiKhoanNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txtTaiKhoanNV.Text = gvTaiKhoanNhanVien.Rows[numrow].Cells[0].Value.ToString();
                txtMatKhauNV.Text = gvTaiKhoanNhanVien.Rows[numrow].Cells[1].Value.ToString();

                taiKhoanNV = txtTaiKhoanNV.Text;
                matKhauNV = txtMatKhauNV.Text;
            }
        }

        private void btnChinhSuaNV_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoanNV.Text != taiKhoanNV || txtMatKhauNV.Text != matKhauNV)
            {
                tKDAO.SuaTaiKhoanNV(txtTaiKhoanNV.Text, txtMatKhauNV.Text);
                LoadVaDoiTenTKNhanVien();
                ResestAllTextBox();
            }
            else
            {
                MessageBox.Show("Các thông tin chưa được thay đổi nên không thực hiện được chức năng này", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            tKDAO.XoaTaiKhoanNV(txtTaiKhoanNV.Text);
            LoadVaDoiTenTKNhanVien();

            ResestAllTextBox();
        }

        private void btnThemTKNV_Click(object sender, EventArgs e)
        {
            tKDAO.ThemTaiKhoanNV(txtTaiKhoanNV.Text, txtMatKhauNV.Text);
            LoadVaDoiTenTKNhanVien();

            ResestAllTextBox();
        }

        private void ResestAllTextBox()
        {
            txtChiTietGiam.Text = "";
            txtCMND.Text = "";
            txtCMNDKhachHang.Text = "";
            txtCode.Text = "";
            txtDiaChi.Text = "";
            txtHoVaTen.Text = "";
            txtMatKhau.Text = "";
            txtMatKhauNV.Text = "";
            txtSDT.Text = "";
            txtSuaDanhGia.Text = "";
            txtSuaGiaThue.Text = "";
            txtSuaHangXe.Text = "";
            txtSuaLoaiXe.Text = "";
            txtSuaMaXe.Text = "";
            txtSuaSoChuyen.Text = "";
            txtSuaSoLuongConLai.Text = "";
            txtSuaTenXe.Text = "";
            txtTaiKhoanNV.Text = "";
            txtTenDangNhap.Text = "";
            txtTenKhachHang.Text = "";
            txtThemGiaThue.Text = "";
            txtThemMaXe.Text = "";
            txtThemMKNV.Text = "";
            txtThemTenXe.Text = "";
            txtThemTKNV.Text = "";
            txtXacNhanMKNV.Text = "";
        }
    }
}
