using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace NewDoAn
{
    public partial class FormDangKyTaiKhoan : MaterialForm
    {
        DanhSachCacTaiKhoanKhachHang dSCTKKH = new DanhSachCacTaiKhoanKhachHang();
        TaiKhoanDAO tKDAO = new TaiKhoanDAO();
        Util u = new Util();

        public FormDangKyTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnHienMK_Click(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;
        }

        private void btnHienXNLMK_Click(object sender, EventArgs e)
        {
            txtXacNhanLaiMatKhau.UseSystemPasswordChar = false;
        }

        private void btnAnMK_Click(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnAnXNLMK_Click(object sender, EventArgs e)
        {
            txtXacNhanLaiMatKhau.UseSystemPasswordChar = true;
        }

        private void btnXacNhanDangKy_Click(object sender, EventArgs e)
        {
            if (tKDAO.KiemTraCMNDVaTaiKhoanTrung(0, txtCMND.Text) == true ||
                tKDAO.KiemTraCMNDVaTaiKhoanTrung(1, txtTenDangNhap.Text) == true)
            {
                MessageBox.Show("CMND hoặc Tên đăng nhập đã được sử dụng! Vui lòng đăng ký tên khác", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool flag = false;
                if (u.SoSanhChuoiPhanBiet(txtMatKhau.Text, txtXacNhanLaiMatKhau.Text) == true)
                {
                    dSCTKKH = new DanhSachCacTaiKhoanKhachHang(txtHoVaTen.Text, txtCMND.Text, txtSDT.Text, txtDiaChi.Text,
                        txtTenDangNhap.Text, txtMatKhau.Text);
                    tKDAO.DangKyTaiKhoan(dSCTKKH);
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Xác nhận lại mật khẩu không đúng! Vui lòng kiểm tra lại", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (flag == true)
                {
                    Form FrmDangNhap = new FormDangNhap(1);
                    FrmDangNhap.Show();
                    this.Close();
                }
            }
        }
    }
}
