using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BookStore.CODE.ChuCuaHang.KhuyenMai
{
    public partial class ucThemMoiCapNhatKhuyenMai : System.Web.UI.UserControl
    {
        DuLieu.SanPham dbSanPham;
        DuLieu.KhuyenMai dbKhuyenMai;
        string idKM = "";
        string idCH = "";
        string thaoTac = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idch"] != null)
            {
                idCH = Session["idch"].ToString();
            }
            dbSanPham = new DuLieu.SanPham();
            dbKhuyenMai = new DuLieu.KhuyenMai();
            calendar1.SelectedDate = DateTime.Today;
            if (Request.QueryString["thaotac"] != null)
            {
                thaoTac = Request.QueryString["thaotac"].ToString();
            }
            if (Request.QueryString["id"] != null)
            {
                idKM = Request.QueryString["id"].ToString();
            }
            if (!IsPostBack)
            {
                LoadCBLSanPham();
            }
           
        }
        protected void LoadCBLSanPham()
        {
           
            if(thaoTac == "CapNhat")
            {
                DataTable tbSanPham = dbSanPham.LayDanhSachSanPham(idCH, "0");
                cblSanPham.Items.Clear();
                foreach (DataRow row1 in tbSanPham.Rows)
                {
                    cblSanPham.Items.Add(new ListItem(row1["TenSach"].ToString(), row1["ID"].ToString()));
                }
                DataTable tbSanPhamKM = dbKhuyenMai.LaySanPhamCuaDotKhuyenMai(idKM, idCH);
                foreach (DataRow rowSP in tbSanPhamKM.Rows)
                {
                    cblSanPham.Items.FindByValue(rowSP["ID"].ToString()).Selected = true;
                }
                lbtitle.Text = "CẬP NHẬT KHUYẾN MÃI";
                DataTable tbKhuyenMai = dbKhuyenMai.LayKhuyenMaiTheoID(idKM);
                DataRow row = tbKhuyenMai.Rows[0];
                tbNoiDung.Text = row["NoiDung"].ToString();
                tbTiLe.Text = row["TiLe"].ToString();
                calendar1.SelectedDate = DateTime.Parse(row["NgayBatDau"].ToString());
                calendar2.SelectedDate = DateTime.Parse(row["NgayKetThuc"].ToString());
                lbcalendar1.Text = calendar1.SelectedDate.ToString("dd-MM-yyyy");
                lbcalendar2.Text = calendar2.SelectedDate.ToString("dd-MM-yyyy");
                btnThemMoi.Text = "Cập nhật";
                btnDatLai.Text = "Hủy";

                
            }
            else
            {
                DataTable tbSanPham = dbSanPham.LayDanhSachCheckBoxList(idCH);
                cblSanPham.Items.Clear();
                foreach (DataRow row in tbSanPham.Rows)
                {
                    cblSanPham.Items.Add(new ListItem(row["TenSach"].ToString(), row["id"].ToString()));
                }
            }
        }
        protected void btnCalendar1_Click(object sender, EventArgs e)
        {
            divcaledar1.Visible = true;
            divcaledar2.Visible = false;
        }

        protected void btnCalendar2_Click(object sender, EventArgs e)
        {
            divcaledar2.Visible = true;
        }

        protected void calendar1_SelectionChanged(object sender, EventArgs e)
        {
          
            DateTime dt = calendar1.SelectedDate;
            lbcalendar1.Text = dt.ToString("dd-MM-yyyy");
            divcaledar1.Visible = false;
        }

        protected void calendar2_SelectionChanged(object sender, EventArgs e)
        {

            DateTime dt = calendar2.SelectedDate;
            lbcalendar2.Text = dt.ToString("dd-MM-yyyy");
            divcaledar2.Visible = false;
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            string noiDung = tbNoiDung.Text;
            string tiLe = tbTiLe.Text;
            string ngayBD = calendar1.SelectedDate.ToString();
            string ngayKT = calendar2.SelectedDate.ToString();
            if (thaoTac == "ThemMoi")
            {
                if(dbKhuyenMai.ThemKhuyenMai(noiDung, tiLe, ngayBD, ngayKT, idCH))
                {
                    thongBao(1, "Thành công!", "Đã thêm thành công!");
                }
            }
            else
            {
                if (dbKhuyenMai.CapNhatKhuyenMai(idKM, noiDung, tiLe, ngayBD, ngayKT))
                {
                    foreach (ListItem item in cblSanPham.Items)
                    {
                        if (item.Selected == true)
                        {
                            dbSanPham.CapNhatKhuyenMai(item.Value, idKM);
                        }
                        else
                        {
                            dbSanPham.CapNhatKhuyenMai(item.Value, "0");
                        }
                    }
                    thongBao(1, "Thành công!", "Cập nhật thành công!");
                }
            }
        }

        protected void btnDatLai_Click(object sender, EventArgs e)
        {

        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
            Response.Redirect("KenhBanHang.aspx?modul=KhuyenMai&thaotac=DanhSach");
        }
        public void thongBao(int trangThai, string chuDe, string noiDung)
        {
            switch (trangThai)
            {
                case 1:
                    imgThongBao.ImageUrl = "../../../Image/success.png";
                    break;
                case 2:
                    imgThongBao.ImageUrl = "../../../Image/error.jpeg";
                    break;
            }
            chuDeThongBao.InnerText = chuDe;
            noiDungThongBao.InnerText = noiDung;
            ThongBao.Visible = true;
        }
    }
}