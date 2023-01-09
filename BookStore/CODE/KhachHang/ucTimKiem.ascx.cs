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
        string thaotac = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            dbSanPham = new DuLieu.SanPham();
            if (Request.QueryString["thaotac"] != null)
            {
                thaotac = Request.QueryString["thaotac"].ToString();
            }
            LoadDanhSachTimKiem();
         
        }
        public void LoadDanhSachTimKiem()
        {
            if(Session["tukhoa"] != null)
            {
                string tuKhoa = Session["tukhoa"].ToString();
                Session.Remove("tukhoa");
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
            else if(thaotac != "")
            {
                string prefix = thaotac.Substring(0, 2);
                string id = thaotac.Substring(2, thaotac.Length-2);
                DataTable tbSanPham = new DataTable();
                switch (prefix)
                {
                    case "dm": 
                        tbSanPham = dbSanPham.LaySanPhamTheoDanhMuc(id);
                        break;
                    case "cd": 
                        tbSanPham = dbSanPham.LaySanPhamTheoChuDe(id);
                        break;
                    case "xb":
                        tbSanPham = dbSanPham.LaySanPhamTheoNhaXuatBan(id);
                        break;
                    case "tg":
                        tbSanPham = dbSanPham.LaySanPhamTheoTacGia(id);
                        break;
                }
                dlSanPham.DataSource = tbSanPham;
                dlSanPham.DataBind();
            }
        
        }
    }

}