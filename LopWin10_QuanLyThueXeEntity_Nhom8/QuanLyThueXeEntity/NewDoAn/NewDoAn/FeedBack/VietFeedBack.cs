using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace NewDoAn
{
    public partial class VietFeedBack : MaterialForm
    {
        FeedBack fB = new FeedBack();
        FeedBackDAO fBDAO = new FeedBackDAO();
        ThongTinXeDAO tTXDAO = new ThongTinXeDAO();

        public VietFeedBack()
        {
            InitializeComponent();

        }

        public VietFeedBack(string str1, string str2, string str3, string str4, string str5) : this()
        {
            this.fB = new FeedBack(str1, str2, str3, str4, str5);
        }
        private void VietFeedBack_Load(object sender, EventArgs e)
        {
            lblAnhChi.Text = "Anh/Chị: " + fB.TenKhachHang;
            lblLoaiXe.Text = "Loại Xe: " + fB.LoaiXe;
            lblHangXe.Text = "Hãng Xe: " + fB.HangXe;
            lblMaXe.Text = "Mã Xe: " + fB.MaXe;
            lblTenXe.Text = "Tên Xe: " + fB.TenXe;
        }

        private void rtbNoiDung_TextChanged(object sender, EventArgs e)
        {
            lblSoKyTu.Text = "Số ký tự: " + rtbNoiDung.Text.Length + " /1000";
        }

        private void btnGuiFeedBack_Click(object sender, EventArgs e)
        {
            string inputDanhGia = txtDanhGia.Text;
            float number;
            if (float.TryParse(inputDanhGia, out number))
            {
                if (number > 5)
                {
                    MessageBox.Show("Điểm đánh giá tối đa là 5* . Vui lòng kiểm tra lại", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (rtbNoiDung.Text == "")
                    {
                        MessageBox.Show("Vui lòng không để trống phần nhận xét", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        fB.DanhGia = number;
                        fB.NoiDung = rtbNoiDung.Text;
                        fB.ID = fBDAO.LayIDFeedBack();
                        fBDAO.ThemFeedBack(fB);
                        double diemDanhGiaGoc = 0;

                        tTXDAO.LayDiemDanhGia(fB.MaXe, ref diemDanhGiaGoc);
                        double diemDanhGiaMoi = Math.Round((fB.DanhGia + diemDanhGiaGoc) / 2, 2);
                        tTXDAO.CapNhatDanhGia(fB.MaXe, diemDanhGiaMoi);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Kiểm tra lại phần Đánh Giá cho điểm", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
