using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.QuanTriVien.TaiKhoan
{
    public partial class ucTaiKhoan : System.Web.UI.UserControl
    {
        string thaoTac = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["thaotac"] != null)
            {
                thaoTac = Request.QueryString["thaotac"].ToString();
            }
            switch (thaoTac)
            {
                case "ThemMoi":
                    plTaiKhoan.Controls.Add(LoadControl("ucThemMoiTaiKhoan.ascx"));
                    break;
                case "CapNhat":
                    plTaiKhoan.Controls.Add(LoadControl("ucThemMoiTaiKhoan.ascx"));
                    break;
                default:
                    plTaiKhoan.Controls.Add(LoadControl("ucDanhSachTaiKhoan.ascx"));
                    break;
            }
        }
    }
}