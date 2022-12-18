using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.KhachHang
{
    public partial class ucTaiKhoan : System.Web.UI.UserControl
    {
        string modul = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["modulphu"] != null)
            {
                modul = Request.QueryString["modulphu"].ToString();
            }
            switch (modul)
            {
                case "TaiKhoan":
                    plTaiKhoan.Controls.Add(LoadControl("ucCapNhatTaiKhoan.ascx"));
                    break;
                case "DonHang":
                    plTaiKhoan.Controls.Add(LoadControl("ucDonHang.ascx"));
                    break;
            }
        }

        protected void linkTaiKhoan_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrangChu.aspx?modul=TaiKhoan&modulphu=TaiKhoan");
        }

        protected void linkDonHang_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrangChu.aspx?modul=TaiKhoan&modulphu=DonHang");
        }
    }
}