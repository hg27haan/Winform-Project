using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace NewDoAn
{
    class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        Util u = new Util();

        public DBConnection()
        {
        }

        public DataTable LayDanhSach(string sql)
        {
            DataTable dtTbl = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(sql, conn);
                sqlAdpt.Fill(dtTbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dtTbl;
        }

        public void ThucThi(string sql, int i)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    if (i == 1)
                    {
                        MessageBox.Show("Thực hiện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void LayGiaThue(string maXe, ref int giaThue)
        {
            try
            {
                conn.Open();
                string sql = string.Format("select *from DanhSachXeHienTai");
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (u.SoSanhChuoiPhanBiet(sdr["MaXe"].ToString(), maXe) == true)
                    {
                        giaThue = Convert.ToInt32(sdr["GiaThue"].ToString());
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public bool ThucThiDangNhapKhach(string sql, string str1, string str2, ref string hoVaTen, ref string cmnd,
            ref string soDienThoai, ref string diaChi)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (u.SoSanhChuoiPhanBiet(sdr["TenDangNhap"].ToString(), str1) == true &&
                        u.SoSanhChuoiPhanBiet(sdr["MatKhau"].ToString(), str2) == true)
                    {
                        hoVaTen = sdr["HoVaTenKhachHang"].ToString();
                        cmnd = sdr["CMNDKhachHang"].ToString();
                        soDienThoai = sdr["SoDienThoaiKhachHang"].ToString();
                        diaChi = sdr["DiaChiKhachHang"].ToString();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool ThucThiDangNhapNhanVien(string sql, string str1, string str2, ref string str3)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (u.SoSanhChuoiPhanBiet(sdr["TenDangNhap"].ToString(), str1) == true &&
                        u.SoSanhChuoiPhanBiet(sdr["MatKhau"].ToString(), str2) == true)
                    {
                        str3 = sdr["LoaiTaiKhoan"].ToString();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool ThucThiKiemTraTaiKhoanTrung(string sql, string str1, string str2)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (u.SoSanhChuoiPhanBiet(sdr["CMNDKhachHang"].ToString(), str1) == true ||
                        u.SoSanhChuoiPhanBiet(sdr["TenDangNhap"].ToString(), str2) == true)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public void LayDiemDanhGiaSoChuyen(string maXe, string str, ref float i1)
        {
            try
            {
                conn.Open();
                string sql = string.Format("select *from DanhSachXeHienTai");
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (u.SoSanhChuoiPhanBiet(sdr["MaXe"].ToString(), maXe) == true)
                    {
                        if (str == "DanhGia")
                        {
                            i1 = float.Parse(sdr["DanhGia"].ToString());
                        }
                        else
                        {
                            i1 = float.Parse(sdr["SoChuyen"].ToString());
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void LayDataBaseDoanhThuThangNam(string str, ref List<string> lstNgayThang, ref List<string> lstTongTien)
        {
            try
            {
                conn.Open();
                string sql = string.Format("select *from {0}", str);
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (str == "DoanhThuThang")
                    {
                        lstNgayThang.Add(sdr["Ngay"].ToString());
                    }
                    else
                    {
                        lstNgayThang.Add(sdr["Thang"].ToString());
                    }
                    lstTongTien.Add(sdr["TongTien"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void TinhDoanhThuThang(ref string result)
        {
            try
            {
                int i = 0;
                conn.Open();
                string sql = string.Format("select *from DoanhThuThang");
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    i = i + int.Parse(sdr["TongTien"].ToString());
                }
                result = i.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public bool KiemTraKhachHangDatThueXe(string str, ThongTinCaNhan tTCN)
        {
            try
            {
                conn.Open();
                string sql = string.Format("select *from {0}", str);
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (u.SoSanhChuoiPhanBiet(tTCN.HoVaTen, sdr["TenKhachHang"].ToString()) == true &&
                        u.SoSanhChuoiPhanBiet(tTCN.CMND, sdr["CMND"].ToString()) == true &&
                        u.SoSanhChuoiPhanBiet(tTCN.SDT, sdr["SDT"].ToString()) == true &&
                        u.SoSanhChuoiPhanBiet(tTCN.DiaChi, sdr["DiaChi"].ToString()) == true)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool KiemTraKhachHangConDatThue(ThongTinCaNhan tTCN)
        {
            try
            {
                if (KiemTraKhachHangDatThueXe("DoanhThuDatXe", tTCN) == true || KiemTraKhachHangDatThueXe("DoanhThuThueXe", tTCN) == true)
                {
                    return true;
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool KiemTraMaXe(string str1, string str2)
        {
            try
            {
                conn.Open();
                string sql = string.Format("select *from {0}",str1);
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (u.SoSanhChuoiPhanBiet(str2, sdr["MaXe"].ToString()) == true)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool KiemTraMaGiamGia(string str)
        {
            try
            {
                conn.Open();
                string sql = string.Format("select *from MaGiamGia");
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (u.SoSanhChuoiPhanBiet(str, sdr["Code"].ToString()) == true)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public void ChiTietGiam(string str1, ref int i)
        {
            try
            {
                conn.Open();
                string sql = string.Format("select *from MaGiamGia");
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (u.SoSanhChuoiPhanBiet(str1, sdr["Code"].ToString()) == true)
                    {
                        i = int.Parse(sdr["ChiTietGiam"].ToString());
                        break;
                    }
                    i = 0;
                }
                if (i == 0)
                {
                    MessageBox.Show("Mã giảm giá đã hết hạn hoặc không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
