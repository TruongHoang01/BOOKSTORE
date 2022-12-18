using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.ChuCuaHang
{
    public partial class ucSanPham : System.Web.UI.UserControl
    {
        string idKH = "";
        string idCH = "";
        string tinhTrang = "";
        DuLieu.SanPham dbSanPham;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idch"] != null)
            {
                idCH = Session["idch"].ToString();
            }
            dbSanPham = new DuLieu.SanPham();
            if(Request.QueryString["tinhtrang"] != null)
            {
                tinhTrang = Request.QueryString["tinhtrang"].ToString();
            }
            //if(Session["idkh"] != null)
            //{
            //    idKH = Session["idkh"].ToString();
            //    idCH = dbCuaHang.LayIDCuaHang(idKH).Rows[0]["ID_KH"].ToString();
            //}
            LoadDanhSachSanPhamCuaHang();
        }
        public void LoadDanhSachSanPhamCuaHang()
        {
            DataTable tbSanPham = dbSanPham.LayDanhSachSanPham(idCH, tinhTrang);
            grSanPham.DataSource = tbSanPham;
            grSanPham.DataBind();
         
        }

        protected void btnCapNhat_Click(object sender, ImageClickEventArgs e)
        {
            string idSach = ((ImageButton)sender).CommandArgument;
            Response.Redirect("KenhBanHang.aspx?modul=SanPham&thaotac=capnhat&id=" + idSach);
        }

        protected void btnXoa_Click(object sender, ImageClickEventArgs e)
        {
            Session["idspxoa"] = ((ImageButton)sender).CommandArgument;
            btnCancel.Visible = true;
            thongBao(3, "Cảnh báo", "Xóa sản phẩm?");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
            if (Session["idspxoa"] != null)
            {
                string idXoa = Session["idspxoa"].ToString();
                Session.Remove("idspxoa");
                if (dbSanPham.XoaSach(idXoa))
                {
                    thongBao(1, "Thành công", "Đã xóa sách!");
                    LoadDanhSachSanPhamCuaHang();
                    btnCancel.Visible = false;
                }
            }

        }
        public void thongBao(int trangThai, string chuDe, string noiDung)
        {
            switch (trangThai)
            {
                case 1:
                    imgThongBao.ImageUrl = "../../../Image/success.png";
                    break;
                case 2:
                    imgThongBao.ImageUrl = "../../../Image/error.jpeg";
                    break;
                case 3:
                    imgThongBao.ImageUrl = "../../../Image/warning.jpeg";
                    break;
            }
            chuDeThongBao.InnerText = chuDe;
            noiDungThongBao.InnerText = noiDung;
            ThongBao.Visible = true;
        }

        protected void grSanPham_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grSanPham.PageIndex = e.NewPageIndex;
            LoadDanhSachSanPhamCuaHang();
        }
    }
}