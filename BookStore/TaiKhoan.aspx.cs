using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string modul = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["modulphu"] != null)
            {
                modul = Request.QueryString["modulphu"].ToString();
            }
            switch (modul)
            {
                case "TaiKhoan":
                    plTaiKhoan.Controls.Add(LoadControl("CODE/KhachHang/ucCapNhatTaiKhoan.ascx"));
                    break;
                default:
                    plTaiKhoan.Controls.Add(LoadControl("CODE/KhachHang/ucDonHangCaNhan.ascx"));
                    break;
            }
        }
        protected void linkTaiKhoan_Click(object sender, EventArgs e)
        {
            Response.Redirect("TaiKhoan.aspx?modul=TaiKhoan&modulphu=TaiKhoan");
        }

        protected void linkDonHang_Click(object sender, EventArgs e)
        {
            Response.Redirect("TaiKhoan.aspx?modul=TaiKhoan&modulphu=DonHang");
        }
    }
}