using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
        string login = "";
 
    
        protected void Page_Load(object sender, EventArgs e)
        {
            knTaiKhoan = new CODE.DuLieu.TaiKhoan();
            LoadGiaoDien();
        }
        private void LoadGiaoDien()
        {
            if(Session["idtk"] == null)
            {
                divhiden.Visible = true;
                lbName.Visible = false;
            }
            else
            {
                string id = Session["idtk"].ToString();
                DataTable tb = knTaiKhoan.LayTaiKhoanTheoID(id);
                lbName.Text = "Tài khoản <br>"+tb.Rows[0]["Hoten"].ToString();
                lbName.Visible = true;
                divhiden.Visible = false;
            }
        }
        protected void btnCheckLog_Click(object sender, EventArgs e)
        {
            taiKhoan = tbTaiKhoan.Text;
            DataTable tb = knTaiKhoan.TimKiemTaiKhoan(taiKhoan);
            if(tb.Rows.Count > 0)
            {
                modelDangNhapDangKy.Visible = false;
                Session["idtk"] = tb.Rows[0]["ID"].ToString();
            }
            Thread.Sleep(1000);
            Page_Load(sender, e);
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Session["idtk"] != null && !knTaiKhoan.SoHuuCuaHang(Session["idtk"].ToString()))
                Response.Redirect("TrangChu.aspx?modul=DangKyBanHang");
            else
                thongBao(3, "Chú ý", "Bạn đã sở hữu một cửa hàng");
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
        }
        public void thongBao(int trangThai, string chuDe, string noiDung)
        {
            switch (trangThai)
            {
                case 1:
                    imgThongBao.ImageUrl = "~/Image/success.png";
                    break;
                case 2:
                    imgThongBao.ImageUrl = "~/Image/error.jpeg";
                    break;
                case 3:
                    imgThongBao.ImageUrl = "~/Image/warning.jpeg";
                    break;
            }
            chuDeThongBao.InnerText = chuDe;
            noiDungThongBao.InnerText = noiDung;
            ThongBao.Visible = true;
        }
        protected void btnKenhNguoiBan_Click(object sender, EventArgs e)
        {
            if (Session["idtk"] != null && knTaiKhoan.SoHuuCuaHang(Session["idtk"].ToString()))
                Response.Redirect("KenhBanHang.aspx?modul=SanPham&thaotac=DanhSach");
            else
                thongBao(3, "Chú ý", "Bạn chưa sở hữu cửa hàng");
           
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
        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session.Clear();
            lbName.Visible = false;
            divhiden.Visible = true;
            Response.Redirect("TrangChu.aspx");
        }
        protected void linkDonHang_Click(object sender, EventArgs e)
        {
            Response.Redirect("TaiKhoan.aspx?modul=TaiKhoan&modulphu=DonHang");
        }

        protected void linkTaiKhoan_Click(object sender, EventArgs e)
        {
            Response.Redirect("TaiKhoan.aspx?modul=TaiKhoan&modulphu=TaiKhoan");
        }

        protected void linkGioHang_Click(object sender, EventArgs e)
        {
            if(Session["idtk"] != null)
                Response.Redirect("TrangChu.aspx?modul=GioHang");
        }
    }
}