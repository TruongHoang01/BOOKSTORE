using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.ChuCuaHang.KhuyenMai
{
    public partial class ucKhuyenMai : System.Web.UI.UserControl
    {
        string idCH = "";
        string tinhTrang = "";
        DuLieu.KhuyenMai dbKhuyenMai;
        DuLieu.SanPham dbSanPham;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idch"] != null)
            {
                idCH = Session["idch"].ToString();
            }
            dbSanPham = new DuLieu.SanPham();
            dbKhuyenMai = new DuLieu.KhuyenMai();
            if(Request.QueryString["tinhtrang"] != null)
            {
                tinhTrang = Request.QueryString["tinhtrang"].ToString();
            }
            if(!IsPostBack)
                LoadDanhSachKhuyenMai();
        }
        public void LoadDanhSachKhuyenMai()
        {
            DataTable tbKhuyenMai = dbKhuyenMai.LayDanhSachKhuyenMai(idCH, tinhTrang);
            grKhuyenMai.DataSource = tbKhuyenMai;
            grKhuyenMai.DataBind();

            if(tinhTrang == "1")
            {
                foreach(GridViewRow grRow in grKhuyenMai.Rows)
                {
                    ImageButton imgKT = grRow.FindControl("btnXoa") as ImageButton;
                    imgKT.Visible = false;
                }
            }
        }

        protected void btnCapNhat_Click(object sender, ImageClickEventArgs e)
        {
            string id = ((ImageButton)sender).CommandArgument;
            Response.Redirect("KenhBanHang.aspx?modul=KhuyenMai&thaotac=CapNhat&id=" + id);

        }

        protected void btnXoa_Click(object sender, ImageClickEventArgs e)
        {
            Session["idkmxoa"] = ((ImageButton)sender).CommandArgument;
            btnCancel.Visible = true;
            thongBao(3, "Cảnh báo", "Kết thúc đợt khuyến mãi?");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
            if(Session["idkmxoa"] != null)
            {
                string idXoa = Session["idkmxoa"].ToString();
                Session.Remove("idkmxoa");
                if (dbKhuyenMai.XoaKhuyenMai(idXoa))
                {
                    dbKhuyenMai.CapNhatKhuyenMaiDaXoa(idXoa);
                    thongBao(1, "Thành công", "Đã kết thúc đợt khuyến mãi!");
                    LoadDanhSachKhuyenMai();
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
    }
}