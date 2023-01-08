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
                from_date.Text = row["NgayBatDau"].ToString();
                end_date.Text = row["NgayKetThuc"].ToString();
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
      
        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            string noiDung = tbNoiDung.Text;
            string tiLe = tbTiLe.Text;
            string ngayBD = from_date.Text;
            string ngayKT = end_date.Text;
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