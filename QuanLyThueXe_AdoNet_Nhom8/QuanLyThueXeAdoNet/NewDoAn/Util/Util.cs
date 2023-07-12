using System;
using System.Globalization;

namespace NewDoAn
{
    internal class Util
    {
        public Util()
        {
        }

        public void KhoangGiaTien(string str, ref int i1, ref int i2)
        {
            string[] tachStr = str.Split('-');
            i1 = Convert.ToInt32(tachStr[0]);
            i2 = Convert.ToInt32(tachStr[1]);
        }

        public string XuatFeedBack(string hoVaTen, string danhGia, string noiDung)
        {
            string result = "";
            result += "\nAnh/Chị: " + hoVaTen + "\n";
            result += "Đánh giá: " + danhGia.ToString() + "* / 5*\n************\n";
            result += "Nội dung:\n" + noiDung + "\n";
            return result;
        }

        public bool SoSanhChuoiPhanBiet(string str1, string str2)
        {
            if (string.Compare(str1, str2, false) == 0)
            {
                return true;
            }
            return false;
        }

        public int KhoangCachNgay(string str1, string str2)
        {
            DateTime day1 = Convert.ToDateTime(str1);
            DateTime day2 = Convert.ToDateTime(str2);
            TimeSpan kC = day2 - day1;
            return kC.Days;
        }

        public int KiemTraNgayLonBe(DateTime day1, DateTime day2)
        {
            if (day1.Date < day2.Date || day1.Month < day2.Month || day1.Year < day2.Year)
            {
                return 1;
            }
            else if (day1.Date > day2.Date || day1.Month > day2.Month || day1.Year > day2.Year)
            {
                return 2;
            }
            else if (day1.Date == day2.Date || day1.Month == day2.Month || day1.Year == day2.Year)
            {
                return 3;
            }
            return 0;
        }

        public void XemLaiThongTinBill(ThongTinBill tTB, ref string result)
        {
            result += "Loại Xe:\t" + tTB.TTX.LoaiXe + "\n";
            result += "Hãng Xe:\t" + tTB.TTX.HangXe + "\n";
            result += "Mã Xe:\t" + tTB.TTX.MaXe + "\n";
            result += "Tên Xe:\t" + tTB.TTX.TenXe + "\n";
            result += "Ngày Thuê:\t" + tTB.NgayThue + "\n";
            result += "Ngày Trả:\t" + tTB.NgayTra + "\n";
            result += "Địa Điểm Đón:\t" + tTB.DiaDiemDon + "\n";
            result += "Vật Để Lại:\t" + tTB.VatGiuLai + "\n";
            result += "Tiền Thuê Tài Xế:\t" + tTB.PhiTaiXe + " k\n";
            result += "Tổng Tiền:\t" + int.Parse(tTB.TongTien).ToString("N0",
                CultureInfo.CreateSpecificCulture("vi-VN")) + " k";
        }

        public int ThanhToan(int i1, int i2, int kC)
        {
            return (int)(i1 * kC) + (i2 * kC) + (67 * 2 * kC);
        }

        public int PhiHuyTraXeSom(int i)
        {
            return i * 50 / 100;
        }

        public void ConvertChuoi(ref string str)
        {
            string[] chuoi1 = str.Split('/');
            str = chuoi1[1] + "/" + chuoi1[0] + "/" + chuoi1[2];
        }

        public DateTime ConvertLayDateNgay(string str)
        {
            string temp = str;
            ConvertChuoi(ref temp);
            return Convert.ToDateTime(temp);
        }
    }
}
