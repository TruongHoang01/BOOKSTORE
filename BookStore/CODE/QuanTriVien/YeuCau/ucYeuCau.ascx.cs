using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.QuanTriVien.YeuCau
{
    public partial class ucYeuCau : System.Web.UI.UserControl
    {
        DuLieu.YeuCau knYeuCau;
        protected void Page_Load(object sender, EventArgs e)
        {
            model.Visible = false;
            knYeuCau = new DuLieu.YeuCau();
            loadDanhSachYeuCau();
        }

        public void loadDanhSachYeuCau()
        {
            DataTable tb = knYeuCau.layTatCaDanhSachYeuCau();
            grYeuCau.DataSource = tb;
            grYeuCau.DataBind();
        }
        protected void imgChiTiet_Click(object sender, ImageClickEventArgs e)
        {
            string id = ((ImageButton)sender).CommandArgument;
            DataTable tb = knYeuCau.layYeuCauTheoID(id);
            DataRow row = tb.Rows[0];
            tbMaYC.Text = row["ID"].ToString();
            tbIDKH.Text  = row["ID_KH"].ToString();
            tbChuDe.Text = row["ChuDe"].ToString();
            tbNoiDung.Text = row["NoiDung"].ToString();
            tbNgayTao.Text = row["NgayTao"].ToString();
            tbTrangThai.Text = row["TinhTrang"].ToString();
            model.Visible = true;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            model.Visible = false;
        }

        protected void btnPhanHoi_Click(object sender, EventArgs e)
        {
            string id = tbMaYC.Text;
            knYeuCau.duyetYeuCau(id);
            loadDanhSachYeuCau();
        }
    }
}