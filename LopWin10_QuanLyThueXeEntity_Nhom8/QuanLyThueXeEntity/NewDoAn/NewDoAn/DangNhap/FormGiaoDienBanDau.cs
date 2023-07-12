using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace NewDoAn
{
    public partial class FormGiaoDienBanDau : MaterialForm
    {
        public FormGiaoDienBanDau()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Pink100, Primary.BlueGrey900, Primary.Green100,
                Accent.LightGreen700, TextShade.WHITE);
        }

        private void ptbNhanVien_Click(object sender, EventArgs e)
        {
            Form FrmDangNhap = new FormDangNhap(0);
            FrmDangNhap.Show();
        }

        private void ptBKhachHang_Click(object sender, EventArgs e)
        {
            Form FrmDangNhap = new FormDangNhap(1);
            FrmDangNhap.Show();
        }
    }
}
