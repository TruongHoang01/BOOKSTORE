using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.QuanTriVien.TaiKhoan
{
    public partial class ucThemMoiTaiKhoan : System.Web.UI.UserControl
    {
        string thaoTac = "";
        DuLieu.TaiKhoan knTaiKhoan;
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            knTaiKhoan = new DuLieu.TaiKhoan();
            if (Request.QueryString["thaotac"] != null)
            {
                thaoTac = Request.QueryString["thaotac"].ToString();
            }
            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"].ToString();
            }
            if (!IsPostBack)
            {
                loadDanhSachQuyen();
                if (thaoTac == "CapNhat")
                {
                    loadDuLieuCapNhat();
                    divCapNhat.Visible = divNgayTao.Visible = true;
                    btnThem.Text = "Cập nhật";
                    lbThem.Text = "CẬP NHẬT TÀI KHOẢN";
                }
                else
                {
                    divCapNhat.Visible = divNgayTao.Visible = false;
                }
            }
        }
        public string validateTaiKhoan(string email, string sdt, string hoten, string matkhau, string diachi)
        {
            string strValid = "";
            if (email == "" && sdt == "" && hoten == "" && matkhau == "" && diachi == "")
                strValid = "Chưa nhập thông tin!";
            else if (email == "")
                strValid = "Email không được bỏ trống!";
            else if (sdt == "")
                strValid = "Số điện thoại không được để trống!";
            else if (hoten == "")
                strValid = "Họ tên không được để trống!";
            else if (matkhau == "")
                strValid = "Mật khẩu không được để trống!";
            else if (diachi == "")
                strValid = "Địa chỉ không được để trống!";
            return strValid;
        }
        public void loadDuLieuCapNhat()
        {
            DataTable tb = knTaiKhoan.LayTaiKhoanTheoID(id);
            if (tb.Rows.Count > 0)
            {
                DataRow row = tb.Rows[0];
                tbEmail.Text = row["Email"].ToString();
                tbSDT.Text = row["SDT"].ToString();
                tbDiaChi.Text = row["DiaChi"].ToString();
                tbHoTen.Text = row["HoTen"].ToString();
                tbMatKhau.Text = row["MatKhau"].ToString();
                if (row["GioiTinh"].ToString() == "Nam")
                {
                    rbNam.Selected = true;
                }
                else
                {
                    rbNu.Selected = true;
                }
                ddlQuyen.SelectedValue = row["MaQuyen"].ToString();
                tbNgayTao.Text = row["NgayTao"].ToString();
                tbNgayCapNhat.Text = row["NgayCapNhat"].ToString();
                imgAnhDaiDien.ImageUrl = "../../../Image/" + row["AnhDaiDien"].ToString();
            }
        }
        public void loadDanhSachQuyen()
        {
            DuLieu.Quyen knQuyen = new DuLieu.Quyen();
            ddlQuyen.Items.Clear();
            DataTable tb = knQuyen.layDanhSachQuyen();
            foreach (DataRow row in tb.Rows)
            {
                ddlQuyen.Items.Add(new ListItem(row["TenQuyen"].ToString(), row["ID"].ToString()));
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string sdt = tbSDT.Text;
            string hoTen = tbHoTen.Text;
            string gioiTinh = rbNam.Selected == true ? "Nam" : "Nữ";
            string diaChi = tbDiaChi.Text;
            string quyen = ddlQuyen.SelectedValue;
            string matKhau = tbMatKhau.Text;
            string ngayCapNhat = DateTime.Today.ToString();
            string ngayTao = DateTime.Today.ToString();
            if (thaoTac == "CapNhat")
            {
                string tenAnhDaiDien = lbAnhDaiDienCu.Text;
                if (flAnhDaiDien.FileContent.Length > 0)
                {
                    if (flAnhDaiDien.FileName.EndsWith(".jpeg") || flAnhDaiDien.FileName.EndsWith(".jpg") || flAnhDaiDien.FileName.EndsWith(".png") || flAnhDaiDien.FileName.EndsWith(".gif"))
                    {
                        flAnhDaiDien.SaveAs(Server.MapPath("Image/") + flAnhDaiDien.FileName);
                        tenAnhDaiDien = flAnhDaiDien.FileName;
                    }
                }
                if (knTaiKhoan.CapNhatTaiKhoan(id, email, sdt, matKhau, hoTen, gioiTinh, diaChi, ngayCapNhat, tenAnhDaiDien, quyen))
                {
                    thongBao(1, "Thành công", "Tài khoản đã được cập nhật");
                }
                else
                {
                    thongBao(2, "Thất bại", "Thông tin không hợp lệ");
                }
            }
            else
            {
                string tenAnhDaiDien = "";
                string tenanh = flAnhDaiDien.FileName;
                if (flAnhDaiDien.FileContent.Length > 0)
                {
                    if (flAnhDaiDien.FileName.EndsWith(".jpeg") || flAnhDaiDien.FileName.EndsWith(".jpg") || flAnhDaiDien.FileName.EndsWith(".png") || flAnhDaiDien.FileName.EndsWith(".gif"))
                    {
                        flAnhDaiDien.SaveAs(Server.MapPath("Image/") + flAnhDaiDien.FileName);
                        tenAnhDaiDien = flAnhDaiDien.FileName;
                    }
                }
                else
                {
                    if (rbNam.Selected == true)
                    {
                        tenAnhDaiDien = "anhdaidiennam.jpg";
                    }
                    else
                    {
                        tenAnhDaiDien = "anhdaidiennu.jpg";
                    }
                }
                if (knTaiKhoan.ThemMoiTaiKhoan(email, sdt, matKhau, hoTen, gioiTinh, diaChi, ngayTao, ngayCapNhat, tenAnhDaiDien, quyen))
                {
                    thongBao(1, "Thành công", "Bạn đã thêm mới một tài khoản!");
                }
                else
                {
                    thongBao(2, "Thất bại", "Đã có lỗi xãy ra!");
                }
            }

        }
       
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx?modul=TaiKhoan");
        }
 
        protected void rdGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbNam.Selected == true)
            {
                imgAnhDaiDien.ImageUrl = "../../../Image/anhdaidiennam.jpg";
            }
            else
            {
                imgAnhDaiDien.ImageUrl = "../../../Image/anhdaidiennu.jpg";
            }
        }
        protected void btnClick_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
            Response.Redirect("Admin.aspx?modul=TaiKhoan");
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
                case 3:
                    imgThongBao.ImageUrl = "../../../Image/warning.jpeg";
                    break;
            }
            chuDeThongBao.InnerText = chuDe;
            noiDungThongBao.InnerText = noiDung;
            ThongBao.Visible = true;
        }
    }
}