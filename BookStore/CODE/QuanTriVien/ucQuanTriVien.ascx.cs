using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.QuanTriVien
{
    public partial class ucQuanTriVien : System.Web.UI.UserControl
    {
        string modul = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["modul"] != null)
            {
                modul = Request.QueryString["modul"].ToString();
            }
            switch (modul)
            {
                case "DanhMuc":
                    plQuanTriVien.Controls.Add(LoadControl("SanPham/ucDanhMuc.ascx"));
                    break;
                case "ChuDe":
                    plQuanTriVien.Controls.Add(LoadControl("SanPham/ucChuDe.ascx"));
                    break;
                case "TacGia":
                    plQuanTriVien.Controls.Add(LoadControl("SanPham/ucTacGia.ascx"));
                    break;
                case "NhaXuatBan":
                    plQuanTriVien.Controls.Add(LoadControl("SanPham/ucNhaXuatBan.ascx"));
                    break;
                case "TaiKhoan":
                    plQuanTriVien.Controls.Add(LoadControl("TaiKhoan/ucTaiKhoan.ascx"));
                    break;
                case "Thue":
                    plQuanTriVien.Controls.Add(LoadControl("QuanLyThue/ucThue.ascx"));
                    break;
                case "ThongKeBaoCao":
                    plQuanTriVien.Controls.Add(LoadControl("ThongKeBaoCao/ucThongKeBaoCao.ascx"));
                    break;
                default:
                    plQuanTriVien.Controls.Add(LoadControl("YeuCau/ucYeuCau.ascx"));
                    break;
            }
        }
    }
}