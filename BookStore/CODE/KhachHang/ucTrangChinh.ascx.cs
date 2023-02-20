using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.KhachHang
{
    public partial class ucTranhChinh : System.Web.UI.UserControl
    {
        DuLieu.SanPham dbSanPham;
        DuLieu.GioHang dbGioHang;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbGioHang = new DuLieu.GioHang();
            dbSanPham = new DuLieu.SanPham();
            if (!IsPostBack)
            {
                LoadTatCaCacDanhMucSanPham();
            }
        }
        public void LoadTatCaCacDanhMucSanPham()
        {
            DataTable tb = dbSanPham.LayDanhSachKhuyenMai();
            dlGiamGia.DataSource = tb;
            dlGiamGia.DataBind();

            DataTable tbDanhChoBan = dbSanPham.DanhChoBan();
            dlDanhChoBan.DataSource = tbDanhChoBan;
            dlDanhChoBan.DataBind();
            int i = 0;
            foreach(DataListItem item in dlDanhChoBan.Items)
            {
                if (tbDanhChoBan.Rows[i++]["MaKM"].ToString() == "0")
                {
                    item.FindControl("lbkm").Visible = false;
                    item.FindControl("lbGiaBia1").Visible = false;
                }
                  
            }
            DataTable tbBanChay = dbSanPham.DanhSachBanChay();
            dlBanChay.DataSource = tbBanChay;
            dlBanChay.DataBind();
            i = 0;
            foreach (DataListItem item in dlBanChay.Items)
            {
                if (tbBanChay.Rows[i++]["MaKM"].ToString() == "0")
                {
                    item.FindControl("lbkm1").Visible = false;
                    item.FindControl("lbGiaBia").Visible = false;
                }
            }
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
        protected void imgHinhAnhSP_Click(object sender, ImageClickEventArgs e)
        {
            string id = ((ImageButton)sender).CommandArgument;
            Response.Redirect("TrangChu.aspx?modul=ChiTiet&id=" + id);
        }

        protected void btnThemVaoGioHang_Click(object sender, EventArgs e)
        {
            if (Session["idtk"] != null)
            {
                dbGioHang = new DuLieu.GioHang();
                string idSP = ((LinkButton)sender).CommandArgument;
                string soLuong = "1";
                string idtk = Session["idtk"].ToString();
                bool check;
                if(dbGioHang.KiemTraGioHang(idtk, idSP))
                {
                    check = dbGioHang.CapNhatSoLuong(idtk, idSP, soLuong);
                }
                else
                {
                    check = dbGioHang.ThemVaoGioHang(idtk, idSP, soLuong);
                }
                if(check)
                    thongBao(1, "Thành công", "Đã thêm vào giỏ hàng");
                else
                {
                    thongBao(3, "Chú ý", "Thêm vào không thành công");
                }
            }
            else
            {
                thongBao(3, "Chú ý", "Vui lòng đăng nhập tài khoản");
            }
        }

        protected void linkTenSP_Click1(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;
            Response.Redirect("TrangChu.aspx?modul=ChiTiet&id=" + id);
        }
    }
}