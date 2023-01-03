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

        protected void cbkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach(DataListItem row in dlCuaHang.Items)
            {
                CheckBox cbCuaHang = row.FindControl("cbkSelectAllStore") as CheckBox;
              
                if(((CheckBox)sender).Checked == true)
                    cbCuaHang.Checked = true;
                else
                    cbCuaHang.Checked = false;
                cbkSelectAllStore_CheckedChanged(cbCuaHang, e);
            }
        }

        protected void cbkSelectAllStore_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbk = (CheckBox)sender;
            DataListItem dlCuaHang = ((CheckBox)sender).Parent as DataListItem;
            DataList dlSP = dlCuaHang.FindControl("dlSanPham") as DataList;
            foreach(DataListItem rowsp in dlSP.Items)
            {
                CheckBox cbkSanPham = rowsp.FindControl("cbkSanPham") as CheckBox;
                if (cbk.Checked == true)
                    cbkSanPham.Checked = true;
                else
                    cbkSanPham.Checked = false;
            }
        }

        protected void btnTruSL_Click(object sender, EventArgs e)
        {
            DataListItem dlSanPham = ((Button)sender).Parent as DataListItem;
            TextBox tbSL = dlSanPham.FindControl("textSL")as TextBox;
            if(tbSL.Text != "1")
            {
                int count = Int32.Parse(tbSL.Text) - 1;
                tbSL.Text = count +"";
            }
        }

        protected void btnCongSL_Click(object sender, EventArgs e)
        {
             
            DataListItem dlSanPham = ((Button)sender).Parent as DataListItem;
            TextBox tbSL = dlSanPham.FindControl("textSL") as TextBox;
            if (tbSL.Text != "10")
            {
                int count = Int32.Parse(tbSL.Text) + 1;
                tbSL.Text = count + "";
            }
        }
    }
}