using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.KhachHang
{
    public partial class ucTrangChu : System.Web.UI.UserControl
    {
        DuLieu.dbDanhMuc knDanhMuc;
        DuLieu.ChuDe knChuDe;
        DuLieu.NhaXuatBan knNhaXuatBan;
        DuLieu.TacGia knTacGia;
        string modul = "";
        public void Page_Load(object sender, EventArgs e)
        {
            knDanhMuc = new DuLieu.dbDanhMuc();
            knChuDe = new DuLieu.ChuDe();
            knNhaXuatBan = new DuLieu.NhaXuatBan();
            knTacGia = new DuLieu.TacGia();
            loadDanhMuc();
            loadChuDe();
            loadNhaXuatBan();
            loadTacGia();
            if (Request.QueryString["modul"] != null)
            {
                modul = Request.QueryString["modul"].ToString();
            }
            switch (modul)
            {
                case "TimKiem":
                    plTranhChu.Controls.Add(LoadControl("ucTimKiem.ascx"));
                    break;
                default:
                    plTranhChu.Controls.Add(LoadControl("ucTrangChinh.ascx"));
                    break;
            }
        }
        public void loadDanhMuc()
        {
            DataTable tb = knDanhMuc.layDanhSachDuLieu();
            dlDanhMuc1.DataSource = tb;
            dlDanhMuc1.DataBind();

        }
        public void loadChuDe()
        {
            DataTable tb = knChuDe.LayDanhSachChuDe();
            dlChuDe.DataSource = tb;
            dlChuDe.DataBind();
        }
        public void loadNhaXuatBan()
        {
            DataTable tb = knNhaXuatBan.layDanhSachNXB();
            dlNhaXuatBan.DataSource = tb;
            dlNhaXuatBan.DataBind();
        }
        public void loadTacGia()
        {
            DataTable tb = knTacGia.layDanhSachTacGia();
            dlTacGia.DataSource = tb;
            dlTacGia.DataBind();
        }
        protected void danhMuc_Click(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;
            Response.Redirect("TrangChu.aspx?modul=TimKiem&thaotac=dm" + id);
        }
       
        protected void tacGia_Click(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;
            Response.Redirect("TrangChu.aspx?modul=TimKiem&thaotac=tg" + id);
        }
        protected void chuDe_Click(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;
            Response.Redirect("TrangChu.aspx?modul=TimKiem&thaotac=cd" + id);
        }
        protected void nhaXuatBan_Click(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;
            Response.Redirect("TrangChu.aspx?modul=TimKiem&thaotac=xb" + id);
        }
    }
}