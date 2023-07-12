using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace NewDoAn
{
    public partial class FormHuyDatVaTraXe : MaterialForm
    {
        Util u = new Util();
        DanhSachCacTaiKhoanKhachHang dSCTKKH = new DanhSachCacTaiKhoanKhachHang();
        ThongTinXeDAO tTXDAO = new ThongTinXeDAO();
        DoanhThuDAO dTDAO = new DoanhThuDAO();
        DanhSachXeHienTai dSXHT = new DanhSachXeHienTai();
        DoanhThuDatXe dTDX = new DoanhThuDatXe();
        DoanhThuThueXe dTTX = new DoanhThuThueXe();
        DoanhThuThucTe dTTT = new DoanhThuThucTe();

        private string loaiXe = "";
        private string hangXe = "";
        private string maXe = "";
        private string tenXe = "";
        private string ngayThue = "";
        private string ngayTra = "";
        private string diaDiemDon = "";
        private string vatDeLai = "";
        private string tienThueTaiXe = "";
        private string tongTien = "";
        private int giaThue = 0;

        private int datThue;

        public FormHuyDatVaTraXe()
        {
            InitializeComponent();
        }

        public FormHuyDatVaTraXe(string str1, string str2, string str3, string str4) : this()
        {
            this.dSCTKKH = new DanhSachCacTaiKhoanKhachHang(str1, str2, str3, str4);
        }

        private void FormHuyDatVaTraXe_Load(object sender, EventArgs e)
        {
            lblChaoKhachHang.Text = "Xin chào, " + dSCTKKH.HoVaTenKhachHang;
        }

        private void btnDatThueXe_Click(object sender, EventArgs e)
        {
            Form FrmDatXeVaThueXe = new FormDatXeVaThueXe(dSCTKKH.HoVaTenKhachHang, dSCTKKH.CMNDKhachHang, dSCTKKH.SoDienThoaiKhachHang,
                dSCTKKH.DiaChiKhachHang);
            FrmDatXeVaThueXe.Show();
            this.Refresh();
            this.Hide();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Form FrmDangNhap = new FormDangNhap(1);
            FrmDangNhap.Show();
            this.Refresh();
            this.Hide();
        }

        private void LayKetQuaChon(ComboBox comboBox, ref string str)
        {
            if (comboBox.SelectedItem != null)
            {
                str = comboBox.SelectedItem.ToString();
            }
        }

        private void ThucHienChucNangLocBill(string str)
        {
            LayKetQuaChon(cbbLoaiXe, ref loaiXe);
            LayKetQuaChon(cbbHangXe, ref hangXe);

            LayDanhSachVaDoiTenHeader();
        }

        private void ptbDatXe_Click(object sender, EventArgs e)
        {
            datThue = 0;
            ThucHienChucNangLocBill("DoanhThuDatXe");
        }

        private void ptbLocBillThueXe_Click(object sender, EventArgs e)
        {
            datThue = 1;
            ThucHienChucNangLocBill("DoanhThuThueXe");
        }

        private void LayDanhSachVaDoiTenHeader()
        {
            dTDAO.LocDanhSachBill(ref gvLichSuDatThueXe, datThue, dSCTKKH.HoVaTenKhachHang, dSCTKKH.CMNDKhachHang,
                dSCTKKH.SoDienThoaiKhachHang, dSCTKKH.DiaChiKhachHang, loaiXe, hangXe, dtpNgayThueXe.Value.ToString("dd/MM/yyyy"));

            gvLichSuDatThueXe.Columns[0].HeaderText = "Họ và Tên";
            gvLichSuDatThueXe.Columns[1].HeaderText = "CMND";
            gvLichSuDatThueXe.Columns[2].HeaderText = "SĐT";
            gvLichSuDatThueXe.Columns[3].HeaderText = "Địa Chỉ";
            gvLichSuDatThueXe.Columns[4].HeaderText = "Loại Xe";
            gvLichSuDatThueXe.Columns[5].HeaderText = "Hãng Xe";
            gvLichSuDatThueXe.Columns[6].HeaderText = "Mã Xe";
            gvLichSuDatThueXe.Columns[7].HeaderText = "Tên Xe";
            gvLichSuDatThueXe.Columns[8].HeaderText = "Ngày Thuê";
            gvLichSuDatThueXe.Columns[9].HeaderText = "Ngày Trả";
            gvLichSuDatThueXe.Columns[10].HeaderText = "Địa Điểm Đón";
            gvLichSuDatThueXe.Columns[11].HeaderText = "Vật Để Lại";
            gvLichSuDatThueXe.Columns[12].HeaderText = "Tiền Thuê Tài Xế (k)";
            gvLichSuDatThueXe.Columns[13].HeaderText = "Tổng Tiền (k)";
        }

        private void gvLichSuDatThueXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            if (numrow >= 0)
            {
                loaiXe = gvLichSuDatThueXe.Rows[numrow].Cells[4].Value.ToString();
                hangXe = gvLichSuDatThueXe.Rows[numrow].Cells[5].Value.ToString();
                maXe = gvLichSuDatThueXe.Rows[numrow].Cells[6].Value.ToString();
                tenXe = gvLichSuDatThueXe.Rows[numrow].Cells[7].Value.ToString();
                ngayThue = gvLichSuDatThueXe.Rows[numrow].Cells[8].Value.ToString();
                ngayTra = gvLichSuDatThueXe.Rows[numrow].Cells[9].Value.ToString();
                diaDiemDon = gvLichSuDatThueXe.Rows[numrow].Cells[10].Value.ToString();
                vatDeLai = gvLichSuDatThueXe.Rows[numrow].Cells[11].Value.ToString();
                tienThueTaiXe = gvLichSuDatThueXe.Rows[numrow].Cells[12].Value.ToString();
                tongTien = gvLichSuDatThueXe.Rows[numrow].Cells[13].Value.ToString();

                tTXDAO.LayGiaThue(maXe, ref giaThue);
                dSXHT = new DanhSachXeHienTai(loaiXe, hangXe, maXe, tenXe, giaThue);
                string result = "";
                if (datThue == 0)
                {
                    dTDX = new DoanhThuDatXe(dSCTKKH.HoVaTenKhachHang, dSCTKKH.CMNDKhachHang, dSCTKKH.SoDienThoaiKhachHang,
                        dSCTKKH.DiaChiKhachHang, loaiXe, hangXe, maXe, tenXe, ngayThue, ngayTra, diaDiemDon,
                        vatDeLai, int.Parse(tienThueTaiXe), int.Parse(tongTien));

                    u.XemLaiThongTinBill(loaiXe, hangXe, maXe, tenXe, ngayThue, ngayTra, diaDiemDon,
                        vatDeLai, int.Parse(tienThueTaiXe), int.Parse(tongTien), ref result);
                }   
                else
                {
                    dTTX = new DoanhThuThueXe(dSCTKKH.HoVaTenKhachHang, dSCTKKH.CMNDKhachHang, dSCTKKH.SoDienThoaiKhachHang,
                        dSCTKKH.DiaChiKhachHang, loaiXe, hangXe, maXe, tenXe, ngayThue, ngayTra, diaDiemDon,
                        vatDeLai, int.Parse(tienThueTaiXe), int.Parse(tongTien));

                    u.XemLaiThongTinBill(loaiXe, hangXe, maXe, tenXe, ngayThue, ngayTra, diaDiemDon,
                        vatDeLai, int.Parse(tienThueTaiXe), int.Parse(tongTien), ref result);
                }    
                rtbKiemTraThongTin.Text = result;

                if (datThue == 0)
                {
                    string tempNgayThue = ngayThue;
                    u.ConvertChuoi(ref tempNgayThue);
                    DateTime dayNgayThue = Convert.ToDateTime(tempNgayThue);
                    if (dayNgayThue >= DateTime.Now.Date)
                    {

                        btnXacNhanHuyDatXe.Enabled = true;
                    }
                    else
                    {
                        btnXacNhanTraXe.Enabled = true;
                    }
                }
                else
                {
                    btnXacNhanTraXe.Enabled = true;
                }
            }
        }

        private void btnXacNhanHuyDatXe_Click(object sender, EventArgs e)
        {
            if (gvLichSuDatThueXe.SelectedRows.Count > 0)
            {
                int tongCong = u.PhiHuyTraXeSom(Convert.ToInt32(tongTien));
                DialogResult dlr = MessageBox.Show("Bạn xác nhận hủy đặt xe chứ? Phí hủy sẽ bằng 50% tiền đã thanh toán là: " +
                    tongCong.ToString() + " k", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dlr == DialogResult.OK)
                {
                    ThucHienChucNangButton("DoanhThuDatXe", tongCong);
                    rtbKiemTraThongTin.Text = "";
                    btnXacNhanHuyDatXe.Enabled = false;
                    LayDanhSachVaDoiTenHeader();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn xác nhận hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TraXeTruocNgay(DateTime dayNgayThue, DateTime dayNgayDuDinhTra)
        {
            int kCNgayDuDinh = u.KhoangCachNgay(dayNgayThue.Date.ToString("yyyy/MM/dd"), dayNgayDuDinhTra.Date.ToString("yyyy/MM/dd"));
            int soTien1NgayThue = Convert.ToInt32(tongTien) / kCNgayDuDinh;

            int kCThucTe = u.KhoangCachNgay(dayNgayThue.Date.ToString("yyyy/MM/dd"), DateTime.Now.Date.ToString("yyyy/MM/dd"));
            int soTienThucTe = soTien1NgayThue * kCThucTe;

            DialogResult dlr = MessageBox.Show("Bạn đã thuê xe được " + kCThucTe.ToString() + " ngày. Trả xe sớm sẽ chỉ lấy phí thực tế là: " +
                soTienThucTe.ToString() + "k. Đồng ý trả xe?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                if (datThue == 0)
                {
                    ThucHienChucNangButton("DoanhThuDatXe", soTienThucTe);
                }
                else
                {
                    ThucHienChucNangButton("DoanhThuThueXe", soTienThucTe);
                }
                if (kCThucTe != 0)
                {
                    CapNhatSoChuyenVaMoFeedBack();
                }
                TraXeThanhCong();
            }
        }

        private void TraXeDungNgay()
        {
            DialogResult dlr = MessageBox.Show("Xác nhận trả xe?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                ThucHienChucNangButton("DoanhThuThueXe", Convert.ToInt32(tongTien));
                CapNhatSoChuyenVaMoFeedBack();
            }
        }

        private void TraXeThanhCong()
        {
            rtbKiemTraThongTin.Text = "";
            btnXacNhanTraXe.Enabled = false;
            LayDanhSachVaDoiTenHeader();
        }
            
        private void CapNhatSoChuyenVaMoFeedBack()
        {
            TraXeThanhCong();

            int soChuyen = 0;
            tTXDAO.LaySoChuyenXe(maXe,ref soChuyen);
            int soChuyenMoi = soChuyen + 1;
            tTXDAO.CapNhatSoChuyen(maXe, soChuyenMoi);
            VietFeedBack(dSCTKKH, dSXHT);
        }

        private void btnXacNhanTraXe_Click(object sender, EventArgs e)
        {
            if (gvLichSuDatThueXe.SelectedRows.Count > 0)
            {
                DateTime dayNgayThue = u.ConvertLayDateNgay(ngayThue);
                DateTime dayNgayTra = u.ConvertLayDateNgay(ngayTra);

                if (DateTime.Now.Date < Convert.ToDateTime(dayNgayTra.Date.ToString("yyyy/MM/dd")))
                {
                    TraXeTruocNgay(dayNgayThue, dayNgayTra);
                }
                else if (DateTime.Now.Date == Convert.ToDateTime(dayNgayTra.Date.ToString("yyyy/MM/dd")))
                {
                    TraXeDungNgay();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn xác nhận hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ThucHienChucNangButton(string str, int i)
        {
            if (datThue == 0)
            {
                dTDAO.XoaKhoiDoanhThuDatXe(dTDX);
            }
            else
            {
                dTDAO.XoaKhoiDoanhThuThueXe(dTTX);
            }

            DateTime dayNgayThue = u.ConvertLayDateNgay(ngayThue);
            if (DateTime.Now.Date >= dayNgayThue)
            {
                tTXDAO.CapNhatSoLuongXe(maXe, 1);
            }
            dTDAO.XoaKhoiChiTietDatThue(maXe, ngayThue, ngayTra);
            int temp = dTDAO.LaySoLuongIDDoanhThu("thucte");
            dTTT = new DoanhThuThucTe(temp, dSCTKKH.HoVaTenKhachHang, dSCTKKH.CMNDKhachHang, dSCTKKH.SoDienThoaiKhachHang,
                DateTime.Now.Date.ToString("dd/MM/yyyy"), i);
            dTDAO.ThemVaoDoanhThuThucTe(dTTT);
            LayDanhSachVaDoiTenHeader();
        }

        private void VietFeedBack(DanhSachCacTaiKhoanKhachHang dSCTKKH, DanhSachXeHienTai dSXHT)
        {
            DialogResult dlr = MessageBox.Show("Cảm ơn bạn đã sử dụng dịch vụ ở chúng tôi. Nếu có vấn đề gì cần góp ý, xin mời bạn " +
                "viết lại FeedBack!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                Form FrmVietFeedBack = new VietFeedBack(dSCTKKH.HoVaTenKhachHang, dSXHT.LoaiXe, dSXHT.HangXe, dSXHT.MaXe, dSXHT.TenXe);
                FrmVietFeedBack.Show();
            }
        }
    }
}
