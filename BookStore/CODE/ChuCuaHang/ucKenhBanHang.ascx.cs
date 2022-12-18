using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.ChuCuaHang
{
    public partial class ucKenhBanHang : System.Web.UI.UserControl
    {
        string modulChinh = "";
        string thaoTac = "";
       
        DuLieu.CuaHang dbCuaHang;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbCuaHang = new DuLieu.CuaHang();
            if(Session["idtk"] != null)
            {
                String idKH = Session["idtk"].ToString();
                DataTable tbCuaHang = dbCuaHang.LayIDCuaHang(idKH);
                Session["idch"] = tbCuaHang.Rows[0]["ID"].ToString();
            }
            if(Request.QueryString["modul"] != null)
            {
                modulChinh = Request.QueryString["modul"].ToString();
            }
            if (Request.QueryString["thaotac"] != null)
            {
                thaoTac = Request.QueryString["thaotac"].ToString();
            }
            switch (modulChinh)
            {
                case "DonHang":
                    if (thaoTac == "chitiet")
                        plKenhBanHang.Controls.Add(LoadControl("DonHang/ucDuyetDonHang.ascx"));
                    else
                        plKenhBanHang.Controls.Add(LoadControl("DonHang/ucDonHang.ascx"));
                    break;
                case "SanPham":
                    if (thaoTac == "DanhSach")
                        plKenhBanHang.Controls.Add(LoadControl("SanPham/ucSanPham.ascx"));
                    else
                        plKenhBanHang.Controls.Add(LoadControl("SanPham/ucThemMoiCapNhatSanPham.ascx"));
                    break;
                case "KhuyenMai":
                    if (thaoTac == "DanhSach")
                        plKenhBanHang.Controls.Add(LoadControl("KhuyenMai/ucKhuyenMai.ascx"));
                    else
                        plKenhBanHang.Controls.Add(LoadControl("KhuyenMai/ucThemMoiCapNhatKhuyenMai.ascx"));
                    break;
                case "YeuCau":
                    plKenhBanHang.Controls.Add(LoadControl("YeuCau/ucGuiYeuCau.ascx"));
                    break;
                case "ThongKe":
                    plKenhBanHang.Controls.Add(LoadControl("ThongKeBaoCao/ucThongKeBaoCao.ascx"));
                    break;

            }
        }
    }
}