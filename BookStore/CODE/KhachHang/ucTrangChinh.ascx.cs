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
        protected void Page_Load(object sender, EventArgs e)
        {
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

     

        protected void linkTenSP_Click(object sender, EventArgs e)
        {
            String id = ((LinkButton)sender).CommandArgument;
            Response.Redirect("TrangChu.aspx?modul=ChiTiet&id=" + id);
        }

        protected void imgHinhAnhSP_Click(object sender, ImageClickEventArgs e)
        {
            String id = ((ImageButton)sender).CommandArgument;
            Response.Redirect("TrangChu.aspx?modul=ChiTiet&id=" + id);
        }
    }
}