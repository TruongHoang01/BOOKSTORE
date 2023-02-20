using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.KhachHang
{
    public partial class ucCapNhatTaiKhoan : System.Web.UI.UserControl
    {
        DuLieu.TaiKhoan dbTaiKhoan;

        string idtk = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            dbTaiKhoan = new DuLieu.TaiKhoan();
            if (Session["idtk"] != null)
                idtk = Session["idtk"].ToString();
            if (!IsPostBack)
                LoadGiaoDien();
        }

        private void LoadGiaoDien()
        {
            DataTable tbTaiKhoan = dbTaiKhoan.LayTaiKhoanTheoID(idtk);
            tbTen.Text = tbTaiKhoan.Rows[0]["HoTen"].ToString();
            tbEmail.Text = tbTaiKhoan.Rows[0]["Email"].ToString();
            tbSDT.Text = tbTaiKhoan.Rows[0]["SDT"].ToString();
            rdGioiTinh.SelectedValue = tbTaiKhoan.Rows[0]["GioiTinh"].ToString() == "Nam" ? "0" : "1";
            tbDiaChi.Text = tbTaiKhoan.Rows[0]["DiaChi"].ToString();
            imgAnhDaiDien.ImageUrl = "../../Image/" + tbTaiKhoan.Rows[0]["AnhDaiDien"].ToString();
            lbAnhDaiDienCu.Text = tbTaiKhoan.Rows[0]["AnhDaiDien"].ToString();
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string hoTen = tbTen.Text;
            string sdt = tbSDT.Text;
            string gioiTinh = rdGioiTinh.SelectedValue == "0" ? "Nam" : "Nữ";
            string diaChi = tbDiaChi.Text;
            string tenAnhDaiDien = lbAnhDaiDienCu.Text;
            string ngayCapNhat = DateTime.Today.ToString("MM/dd/yyyy");
            if (flAnhDaiDien.FileContent.Length > 0)
            {
                if (flAnhDaiDien.FileName.EndsWith(".jpeg") || flAnhDaiDien.FileName.EndsWith(".jpg") || flAnhDaiDien.FileName.EndsWith(".png") || flAnhDaiDien.FileName.EndsWith(".gif"))
                {
                    flAnhDaiDien.SaveAs(Server.MapPath("Image/") + flAnhDaiDien.FileName);
                    tenAnhDaiDien = flAnhDaiDien.FileName;
                }
            }
            if (dbTaiKhoan.CapNhatTaiKhoan(idtk, sdt, hoTen, gioiTinh, diaChi, ngayCapNhat, tenAnhDaiDien))
            {
                thongBao(1, "Thành công", "Tài khoản đã được cập nhật");
                LoadGiaoDien();
            }
            else
            {
                thongBao(2, "Thất bại", "Thông tin không hợp lệ");
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            LoadGiaoDien();
        }
        protected void btnClick_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
        }
        public void thongBao(int trangThai, string chuDe, string noiDung)
        {
            switch (trangThai)
            {
                case 1:
                    imgThongBao.ImageUrl = "../../Image/success.png";
                    break;
                case 2:
                    imgThongBao.ImageUrl = "../../Image/error.jpeg";
                    break;
                case 3:
                    imgThongBao.ImageUrl = "../../Image/warning.jpeg";
                    break;
            }
            chuDeThongBao.InnerText = chuDe;
            noiDungThongBao.InnerText = noiDung;
            ThongBao.Visible = true;
        }
    }
}