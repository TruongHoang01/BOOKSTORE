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
    public partial class ucDangKyBanhang : System.Web.UI.UserControl
    {
        DuLieu.TaiKhoan dbTaiKhoan;
        DuLieu.CuaHang dbCuaHang;
        string idKH = "";
        static String otp = "";
        static String tenCuaHang = "";
        static String diaChi = "";
        static String email = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["idtk"] != null)
                idKH = Session["idtk"].ToString();
            dbCuaHang = new DuLieu.CuaHang();
            dbTaiKhoan = new DuLieu.TaiKhoan();
            LoadGiaoDien();
            if(Session["captcha"] == null)
                Session["captcha"] = GetCaptCha();
            lbCapCha.Text = Session["captcha"].ToString();


        }
        public void LoadGiaoDien()
        {
            DataTable tb = dbTaiKhoan.LayTaiKhoanTheoID(idKH);
            tbEmail.Text = tb.Rows[0]["Email"].ToString();
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            string lbCap = Session["captcha"].ToString() ;
            email = tbEmail.Text;
            tenCuaHang = tbTenCuaHang.Text;
            diaChi = tbDiaChi.Text ;
            string captCha = tbCaptcha.Text;
            if(lbCap == captCha)
            {
                DivXacNhanEmail.Visible = true;
                SendEmail();
            }
            Session.Remove("captcha");
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
            Response.Redirect("KenhBanHang.aspx?modul=SanPham&thaotac=DanhSach");
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

        protected void btnXacNhanOTP_Click(object sender, EventArgs e)
        {
            if (otp == tbOtp.Text)
            {
                if (dbCuaHang.TaoCuaHang(idKH, tenCuaHang, diaChi))
                {
                    thongBao(1, "Thành công", "Đăng ký thàng công!");

                }
                else
                {
                    thongBao(2, "Thất bại", "Đã có lỗi xãy ra!");
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
        private void SendEmail()
        {
            Random ran = new Random();
            otp = ran.Next(100000, 1000000).ToString();
            String msg = "Mã otp xác nhận đăng ký cửa hàng của bạn là: " + otp;
            SendMail.sendMail(email, "BookStore", msg);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}