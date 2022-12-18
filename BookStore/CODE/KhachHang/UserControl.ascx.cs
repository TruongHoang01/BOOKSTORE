using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.KhachHang
{
    public partial class UserControl : System.Web.UI.UserControl
    {
        string modul = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["modul"] != null)
            {
                modul = Request.QueryString["modul"].ToString();
            }
            switch (modul)
            {
                case "TaiKhoan":
                    string modulphu = "";
                    if(Request.QueryString["modulphu"] != null)
                    {
                        modulphu = Request.QueryString["modulphu"].ToString();
                    }
                    plUserControl.Controls.Add(LoadControl("ucTaiKhoan.ascx"));
                    break;
                case "ChiTiet":
                    plUserControl.Controls.Add(LoadControl("ucChiTiet.ascx"));
                    break;
                case "GioHang":
                    plUserControl.Controls.Add(LoadControl("ucGioHang.ascx"));
                    break;
                case "DangKyBanHang":
                    plUserControl.Controls.Add(LoadControl("ucDangKyBanHang.ascx"));
                    break;
                default:
                    plUserControl.Controls.Add(LoadControl("ucTrangChu.ascx"));
                    break;
            }

        }

    }
 
}