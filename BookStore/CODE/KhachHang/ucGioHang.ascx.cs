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

        protected void Page_Load(object sender, EventArgs e)
        {
            dbGioHang = new DuLieu.GioHang();
            if(Session["idtk"] != null)
            {
                idtk = Session["idtk"].ToString();
                dbGioHang.CapNhatSanPhamChuaDuocMua(idtk);
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
            CapNhatChiPhi();
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
            CapNhatChiPhi();
        }
        public void CapNhatChiPhi()
        {
            int count = 0;
            int sumGiamGia = 0;
            int sumTamTinh = 0;
            foreach (DataListItem rowCH in dlCuaHang.Items)
            {
                DataList listSP = rowCH.FindControl("dlSanPham") as DataList;
                foreach (DataListItem rowSP in listSP.Items)
                {
                    CheckBox cbkSP = rowSP.FindControl("cbkSanPham") as CheckBox;
                    if (cbkSP.Checked == true)
                    {
                        Label giaGoc = rowSP.FindControl("lbGiaGoc") as Label;
                        Label giaKM = rowSP.FindControl("lbGiaKM") as Label;
                        TextBox tbSl = rowSP.FindControl("tbsoluong") as TextBox;
                        sumTamTinh += (Convert.ToInt32(giaGoc.Text)*Convert.ToInt32(tbSl.Text));
                        sumGiamGia += (Convert.ToInt32(giaGoc.Text) - Convert.ToInt32(giaKM.Text))* Convert.ToInt32(tbSl.Text);
                        count++;
                    }
                }
            }
            lbCount.Text = count + "";
            lbTamTinh.Text = sumTamTinh + "";
            lbKM.Text = sumGiamGia + "";
            int thanhTien = (sumTamTinh - sumGiamGia);
            lbThanhTien.Text = thanhTien + "";

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
        protected void btnTangSL_Click(object sender, EventArgs e)
        {
            DataListItem dlSanPham = ((Button)sender).Parent as DataListItem;
            TextBox tbSL = dlSanPham.FindControl("tbsoluong") as TextBox;
            if (tbSL.Text != "10")
            {
                string idsp = (dlSanPham.FindControl("hfID") as HiddenField).Value;
                int count = Int32.Parse(tbSL.Text) + 1;
                tbSL.Text = count + "";
                if (dbGioHang.CapNhatSoLuong(idtk, idsp, "1"))
                {
                    LoadGiaoDien();
                }
            }
        }
        protected void btnGiamSL_Click(object sender, EventArgs e)
        {
            DataListItem dlSanPham = ((Button)sender).Parent as DataListItem;
            TextBox tbSL = dlSanPham.FindControl("tbsoluong") as TextBox;
            if (tbSL.Text != "1")
            {
                string idsp = (dlSanPham.FindControl("hfID") as HiddenField).Value;
                int count = Int32.Parse(tbSL.Text) - 1;
                tbSL.Text = count + "";
                if (dbGioHang.CapNhatSoLuong(idtk, idsp, "-1"))
                {
                    LoadGiaoDien();
                }
            }
        }
        protected void btnMuaHang_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach(DataListItem rowCH in dlCuaHang.Items)
            {
                DataList listSP = rowCH.FindControl("dlSanPham") as DataList;
                foreach (DataListItem rowSP in listSP.Items)
                {
                    CheckBox cbkSP = rowSP.FindControl("cbkSanPham") as CheckBox;
                    if(cbkSP.Checked == true) {
                        HiddenField hfID = rowSP.FindControl("hfID") as HiddenField;
                        string idsp = hfID.Value;
                        dbGioHang.CapNhatSanPhamDuocChon(idtk, idsp);
                        count++;
                    }
                }
                
            }
            if(count != 0)
            {
                Response.Redirect("TrangChu.aspx?modul=DatHang");
            }
            else
            {
                lbThongBao.Text = "Chưa chọn sản phẩm!";
            }
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            string idsp = ((ImageButton)sender).CommandArgument;
            string idtk = Session["idtk"].ToString();
            if(dbGioHang.XoaKhoiGioHang(idsp, idtk))
            {
                LoadGiaoDien();
            }
        }

        protected void cbkSanPham_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatChiPhi();
        }
    }
}