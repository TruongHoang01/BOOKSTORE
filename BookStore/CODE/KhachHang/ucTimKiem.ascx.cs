using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.KhachHang
{
    public partial class ucTimKiem : System.Web.UI.UserControl
    {
        DuLieu.SanPham dbSanPham;
        DuLieu.GioHang dbGioHang;
        string thaotac = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            dbSanPham = new DuLieu.SanPham();
            dbGioHang = new DuLieu.GioHang();
            if (Request.QueryString["thaotac"] != null)
            {
                thaotac = Request.QueryString["thaotac"].ToString();
            }
            if (!IsPostBack)
            {
                LoadDanhSachTimKiem();
            }
         
        }
        public void LoadDanhSachTimKiem()
        {
            if(Session["tukhoa"] != null)
            {
                string tuKhoa = Session["tukhoa"].ToString();
                Session.Remove("tukhoa");
                lbtitle.Text = "Danh sách sản phẩm liên quan đến \"" + tuKhoa + "\"";
                DataTable tbsanpham = dbSanPham.TimKiem(tuKhoa);
                dlSanPham.DataSource = tbsanpham;
                dlSanPham.DataBind();
                int i = 0;
                foreach(DataListItem item in dlSanPham.Items)
                {
                    if (tbsanpham.Rows[i++]["MaKM"].ToString() == "0")
                    {
                        item.FindControl("lbkm").Visible = false;
                        item.FindControl("lbGiaBia").Visible = false;
                    }    
                }
            }
            else if(thaotac != "")
            {
                string prefix = thaotac.Substring(0, 2);
                string id = thaotac.Substring(2, thaotac.Length-2);
                DataTable tbSanPham = new DataTable();
                switch (prefix)
                {
                    case "dm": 
                        tbSanPham = dbSanPham.LaySanPhamTheoDanhMuc(id);
                        break;
                    case "cd": 
                        tbSanPham = dbSanPham.LaySanPhamTheoChuDe(id);
                        break;
                    case "xb":
                        tbSanPham = dbSanPham.LaySanPhamTheoNhaXuatBan(id);
                        break;
                    case "tg":
                        tbSanPham = dbSanPham.LaySanPhamTheoTacGia(id);
                        break;
                }
                dlSanPham.DataSource = tbSanPham;
                dlSanPham.DataBind();
                int i = 0;
                foreach (DataListItem item in dlSanPham.Items)
                {
                    if (tbSanPham.Rows[i++]["MaKM"].ToString() == "0")
                    {
                        item.FindControl("lbkm").Visible = false;
                        item.FindControl("lbGiaBia").Visible = false;
                    }
                }
            }
        
        }

        protected void imgButton_Click(object sender, ImageClickEventArgs e)
        {
            string id = ((ImageButton)sender).CommandArgument;
            Response.Redirect("TrangChu.aspx?modul=ChiTiet&id=" + id);
        }

        protected void themVaoGioHang_Click(object sender, EventArgs e)
        {
            if (Session["idtk"] != null)
            {
                dbGioHang = new DuLieu.GioHang();
                string idSP = ((LinkButton)sender).CommandArgument;
                string soLuong = "1";
                string idtk = Session["idtk"].ToString();
                bool check = dbGioHang.ThemVaoGioHang(idtk, idSP, soLuong);
                if (check)
                    thongBao(1, "Thành công", "Đã thêm vào giỏ hàng");
            }
            else
            {
                thongBao(3, "Chú ý", "Vui lòng đăng nhập tài khoản");
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

        protected void linkTenSP_Click(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;
            Response.Redirect("TrangChu.aspx?modul=ChiTiet&id=" + id);
        }
    }

}