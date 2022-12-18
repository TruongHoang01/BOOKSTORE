using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.KhachHang
{
    public partial class ucGioHang : System.Web.UI.UserControl
    {
        string idtk = "";
        DuLieu.GioHang dbGioHang;
        DataTable tbCuaHang;
        DataTable tbSanPham;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbGioHang = new DuLieu.GioHang();
            if(Session["idtk"] != null)
            {
                idtk = Session["idtk"].ToString();
            }
            LoadGiaoDien();
        }
        public void LoadGiaoDien()
        {
            DataTable tbCuaHang = dbGioHang.LayDanhSachCuaHang(idtk);
            dlCuaHang.DataSource = tbCuaHang;
            dlCuaHang.DataBind();
            int i = 0;
            foreach(DataListItem dlItem in dlCuaHang.Items)
            {
                DataList dlSanPham = dlItem.FindControl("dlSanPham") as DataList;
                dlSanPham.DataSource = dbGioHang.LayDanhSachGioHang(tbCuaHang.Rows[i]["ID"].ToString());
                dlSanPham.DataBind();
                i++;
            }
        }
    }
}