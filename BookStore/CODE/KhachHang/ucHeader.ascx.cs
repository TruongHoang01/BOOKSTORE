using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.KhachHang
{
    public partial class ucHeader : System.Web.UI.UserControl
    {
    
        CODE.DuLieu.TaiKhoan knTaiKhoan;
        static String taiKhoan = "";
        static String matKhau = "";
        static string otp = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            knTaiKhoan = new CODE.DuLieu.TaiKhoan();
            LoadGiaoDien();
        }

        private void LoadGiaoDien()
        {
            if(Session["taikhoan"] == null)
            {
                divhiden.Visible = true;
                lbName.Visible = false;
            }
            else
            {
                string taiKhoan = Session["taikhoan"].ToString();
                DataTable tb = knTaiKhoan.TimKiemTaiKhoan(taiKhoan);
                Session["idtk"] = tb.Rows[0]["ID"].ToString();
                lbName.Text = "Tài khoản <br>"+tb.Rows[0]["Hoten"].ToString();
                lbName.Visible = true;
                divhiden.Visible = false;
            }
        }

        public void thongBao(int trangThai, string chuDe, string noiDung)
        {
            switch (trangThai)
            {
                case 1:
                    imgThongBao.ImageUrl = "../../Image/success.png";
                    break;
                case 2:
                    imgThongBao.ImageUrl = "../../Image/error.jpeg";
                    break;
                case 3:
                    imgThongBao.ImageUrl = "../../Image/warning.jpeg";
                    break;
            }
            chuDeThongBao.InnerText = chuDe;
            noiDungThongBao.InnerText = noiDung;
            ThongBao.Visible = true;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
        }

        protected void imgClose_Click(object sender, ImageClickEventArgs e)
        {
            modelDangNhapDangKy.Visible = false;
            DivXacNhanEmail.Visible = false;
        }

        protected void btnCheckLog_Click(object sender, EventArgs e)
        {
            //taiKhoan = tbTaiKhoan.Text;
            //matKhau = tbMatKhau.Text;
            taiKhoan = "caohuuhieu";
            matKhau = "1234";
            string captCha = tbCaptCha.Text;
            string captChaLB = lbCapCha.Text;
            captCha = captChaLB;
            lbThongBao.Visible = true;
            if (captCha != captChaLB)
                lbThongBao.Text = "Mã captcha không trùng khớp!";
            else if (btnCheckLog.Text == "Đăng nhập")
            {
                if (knTaiKhoan.TimKiemTaiKhoan(taiKhoan).Rows.Count > 0)
                {
                    if (knTaiKhoan.KiemTraDangNhap(taiKhoan, matKhau) > 0)
                    {
                        modelDangNhapDangKy.Visible = false;
                        Session["taikhoan"] = taiKhoan;
                        thongBao(1, "Thành công", "Đăng nhập thành công!");
                    }
                    else
                        lbThongBao.Text = "Mật khẩu không chính xác!";
                }
                else
                    lbThongBao.Text = "Tài khoản không tồn tại!";
                tbCaptCha.Text = GetCaptCha();
            }
            else
            {
                DataTable tb = knTaiKhoan.TimKiemTaiKhoan(taiKhoan);
                if (tb.Rows.Count > 0)
                    lbThongBao.Text = "Tài khoản này đã tồn tại. Vui lòng chọn đăng nhập!";
                else
                {
                    modelDangNhapDangKy.Visible = false;
                    DivXacNhanEmail.Visible = true;
                    SendEmail();
                }
                tbCaptCha.Text = GetCaptCha();
            }
        }

        private void SendEmail()
        {
            Random ran = new Random();
            otp = ran.Next(100000, 1000000).ToString();
            String msg = "Mã otp xác nhận đăng ký tài khoản của bạn là: " + otp;
            SendMail.sendMail(taiKhoan, "BookStore", msg);
        }

        public void giaoDienDangKy()
        {
            lbFormTitle.Text = "Đăng ký";
            btnCheckLog.Text = "Đăng ký";
            lbFormQuestion.Text = "Bạn đã có tài khoản?";
            btnChuyeNDoi.Text = "Đăng nhập";
            lbThongBao.Visible = false;
            lbCapCha.Text = GetCaptCha();
        }
        public void giaoDienDangNhap()
        {
            lbFormTitle.Text = "Đăng nhập";
            btnCheckLog.Text = "Đăng nhập";
            lbFormQuestion.Text = "Bạn chưa có tài khoản?";
            btnChuyeNDoi.Text = "Đăng ký";
            lbThongBao.Visible = false;
            lbCapCha.Text = GetCaptCha();

        }
        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            giaoDienDangKy();
            modelDangNhapDangKy.Visible = true;
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            giaoDienDangNhap();
            modelDangNhapDangKy.Visible = true;
        }

        protected void btnChuyeNDoi_Click(object sender, EventArgs e)
        {
            if (btnCheckLog.Text == "Đăng nhập")
            {
                giaoDienDangKy();
            }
            else
            {
                giaoDienDangNhap();
            }
        }
        private string GetCaptCha()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < 4; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Session["idtk"] == null)
            {
                thongBao(3, "Chú ý", "Vui lòng đăng nhập tài khoản!");
            }
            else
            {
                String id = Session["idtk"].ToString();
                bool check = knTaiKhoan.SoHuuCuaHang(Session["idtk"].ToString());
                if(check == true)
                    thongBao(3, "Chú ý", "Bạn đã sở hữu một cửa hàng!");
                else
                    Response.Redirect("TrangChu.aspx?modul=DangKyBanHang");
            }
        }

        protected void btnKenhNguoiBan_Click(object sender, EventArgs e)
        {
            if (Session["idtk"] == null)
            {
                thongBao(3, "Chú ý", "Vui lòng đăng nhập tài khoản!");
            }
            else
            {
                String id = Session["idtk"].ToString();
                bool check = knTaiKhoan.SoHuuCuaHang(Session["idtk"].ToString());
                if (check == true)
                    Response.Redirect("KenhBanHang.aspx?modul=SanPham&thaotac=DanhSach");
                else
                    thongBao(3, "Chú ý", "Bạn chưa đăng ký bán hàng!");
            }
        
        }

        protected void imglogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("TrangChu.aspx");
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            Session["tukhoa"] = tukhoa.Text;
            Response.Redirect("TrangChu.aspx?modul=TimKiem");
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {

        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session.Clear();
            lbName.Visible = false;
            divhiden.Visible = true;
        }

        protected void btnXacNhan_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnXacNhanOTP_Click(object sender, EventArgs e)
        {
            if(otp == tbOtp.Text)
            {
                string ngayTao = DateTime.Today.ToString();
                if (knTaiKhoan.DangKyTaiKhoan(taiKhoan, matKhau, ngayTao))
                {
                    DivXacNhanEmail.Visible = false;
                    thongBao(1, "Thành công", "Đã xác minh tài khoản. Vui lòng đăng nhập!");
                    giaoDienDangNhap();
                }
            }
            else
            {
                lbThongBaoXacNhanEmail.Visible = true;
            }
         
        }

        protected void btnguilaima_Click(object sender, EventArgs e)
        {

        }

        protected void btnBaoLoi_Click(object sender, EventArgs e)
        {

        }

        protected void linkDonHang_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrangChu.aspx?modul=TaiKhoan&modulphu=DonHang");
        }

        protected void linkTaiKhoan_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrangChu.aspx?modul=TaiKhoan&modulphu=TaiKhoan");
        }

        protected void linkGioHang_Click(object sender, EventArgs e)
        {
            if (Session["idtk"] == null)
                btnDangNhap_Click(sender, e);
            else
                Response.Redirect("TrangChu.aspx?modul=GioHang");
        }
    }
}