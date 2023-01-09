using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.KhachHang
{
    public partial class ucDatHang : System.Web.UI.UserControl
    {
        string idtk = "";
        DuLieu.GioHang dbGioHang;
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

            DataTable tbCuaHang = dbGioHang.LayDanhSachCuaHangDuocChon(idtk);
            dlCuaHang.DataSource = tbCuaHang;
            dlCuaHang.DataBind();
            int i = 0;
            foreach(DataListItem listCH in dlCuaHang.Items)
            {
                string maCH = tbCuaHang.Rows[i++]["ID"].ToString();
                DataList dlSanPham = listCH.FindControl("dlSanPham") as DataList;
                DataTable tbSanPham = dbGioHang.LayDanhSachSanPhamCuaHang(idtk, maCH);
                dlSanPham.DataSource = tbSanPham;
                dlSanPham.DataBind();
            }
        }
    }
}