using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewDoAn
{
    public partial class FormDangNhap : MaterialForm
    {
        TaiKhoanDAO tKDAO = new TaiKhoanDAO();
        ThongTinCaNhan tTCN = new ThongTinCaNhan();

        private int nhanVienHayKhachHang;
        private string loaiTaiKhoan = "";

        public FormDangNhap(int i)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Pink100, Primary.BlueGrey900, Primary.Green100,
                Accent.LightGreen700, TextShade.WHITE);
            txtTenDangNhap.ForeColor = Color.LightGray;
            txtTenDangNhap.Text = "Username";
            txtMatKhau.ForeColor = Color.LightGray;
            txtMatKhau.Text = "Password";
            nhanVienHayKhachHang = i;
            if (nhanVienHayKhachHang == 0)
            {
                label2.Visible = false;
                materialCard1.Visible = false;
                label4.Visible= false;
            }
            else
            {
                lblDangKyTaiKhoan.Visible = true;
            }

        }

        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                txtTenDangNhap.Text = "Username";
                txtTenDangNhap.ForeColor = Color.LightGray;
            }
        }

        private void txtTenDangNhap_Enter(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "Username")
            {
                txtTenDangNhap.Text = "";
                txtTenDangNhap.ForeColor = Color.Black;
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                txtMatKhau.Text = "Password";
                txtMatKhau.ForeColor = Color.LightGray;
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Password")
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.Black;
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void ptbLogin_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (nhanVienHayKhachHang == 1)
            {
                string hoVaTen = "";
                string cmnd = "";
                string sdt = "";
                string diaChi = "";
                if (tKDAO.ThucThiDangNhapKhachHang(txtTenDangNhap.Text, txtMatKhau.Text, ref hoVaTen, ref cmnd, ref sdt, ref diaChi) == true)
                {
                    flag = true;
                    tTCN = new ThongTinCaNhan(hoVaTen, cmnd, sdt, diaChi);
                }
            }
            else
            {
                string lTK = "";
                if (tKDAO.ThucThiDangNhapNhanVien(txtTenDangNhap.Text, txtMatKhau.Text, ref lTK) == true)
                {
                    flag = true;
                    loaiTaiKhoan = lTK;
                }
            }
            if (flag == true)
            {
                if (nhanVienHayKhachHang == 1)
                {
                    Form FrmDatXeVaThueXe = new FormDatXeVaThueXe(tTCN.HoVaTen, tTCN.CMND, tTCN.SDT, tTCN.DiaChi);
                    FrmDatXeVaThueXe.Show();
                }
                else
                {
                    Form FrmNhanVien = new FormNhanVien(loaiTaiKhoan);
                    FrmNhanVien.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai Tài Khoản hoặc Mật Khẩu, vui lòng nhập lại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ptbLogin_Click(sender, EventArgs.Empty);
            }
        }

        private void lblDangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            Form FrmDangKyTaiKhoanKhach = new FormDangKyTaiKhoan();
            FrmDangKyTaiKhoanKhach.Show();
            this.Close();

        }
    }
}
