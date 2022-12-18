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
        protected void Page_Load(object sender, EventArgs e)
        {
            dbSanPham = new DuLieu.SanPham();
            LoadDanhSachTimKiem();
        }
        public void LoadDanhSachTimKiem()
        {
            if(Session["tukhoa"] != null)
            {
                string tuKhoa = Session["tukhoa"].ToString();
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
        
        }
    }

}