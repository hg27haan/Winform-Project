using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace NewDoAn
{
    public partial class VietFeedBack : MaterialForm
    {
        FeedBack fB = new FeedBack();
        FeedBackDAO fBDAO = new FeedBackDAO();
        DBConnection dBC = new DBConnection();
        ThongTinXeDAO tTXDAO = new ThongTinXeDAO();

        public VietFeedBack()
        {
            InitializeComponent();

        }

        public VietFeedBack(string str1, string str2, string str3, string str4, string str5) : this()
        {
            this.fB.TTCN = new ThongTinCaNhan(str1);
            this.fB.TTX = new ThongTinXe(str2, str3, str4, str5);
        }
        private void VietFeedBack_Load(object sender, EventArgs e)
        {
            lblAnhChi.Text = "Anh/Chị: " + fB.TTCN.HoVaTen;
            lblLoaiXe.Text = "Loại Xe: " + fB.TTX.LoaiXe;
            lblHangXe.Text = "Hãng Xe: " + fB.TTX.HangXe;
            lblMaXe.Text = "Mã Xe: " + fB.TTX.MaXe;
            lblTenXe.Text = "Tên Xe: " + fB.TTX.TenXe;
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
                        fBDAO.ThemFeedBack(fB);
                        float diemDanhGiaGoc = 0;
                        string str = "DanhGia";

                        dBC.LayDiemDanhGiaSoChuyen(fB.TTX.MaXe, str, ref diemDanhGiaGoc);
                        float diemDanhGiaMoi = (float)(fB.DanhGia + diemDanhGiaGoc) / 2;
                        double danhGiaNew = Math.Round(Convert.ToDouble(diemDanhGiaMoi), 1);
                        tTXDAO.CapNhatDanhGiaVaSoChuyen("DanhGia", danhGiaNew.ToString(), fB.TTX.MaXe);
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
