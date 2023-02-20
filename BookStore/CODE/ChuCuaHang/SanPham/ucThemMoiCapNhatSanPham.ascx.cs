using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.ChuCuaHang.SanPham
{
    public partial class ucThemMoiCapNhatSanPham : System.Web.UI.UserControl
    {
        string thaoTac = "";
        string idSach = "";
        string idCH = "";
        DuLieu.SanPham dbSanPham;
        DuLieu.dbDanhMuc dbDanhMuc;
        DuLieu.ChuDe dbChuDe;
        DuLieu.KhuyenMai dbKhuyenMai;
        DuLieu.TacGia dbTacGia;
        DuLieu.NhaXuatBan dbNXB;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idch"] != null)
            {
                idCH = Session["idch"].ToString();
            }
            dbDanhMuc = new DuLieu.dbDanhMuc();
            dbChuDe = new DuLieu.ChuDe();
            dbKhuyenMai = new DuLieu.KhuyenMai();
            dbTacGia = new DuLieu.TacGia();
            dbNXB = new DuLieu.NhaXuatBan();
            dbSanPham = new DuLieu.SanPham();
            if(Request.QueryString["thaotac"] != null)
            {
                thaoTac = Request.QueryString["thaotac"].ToString();
            }
            if (Request.QueryString["id"] != null)
            {
                idSach = Request.QueryString["id"].ToString();
            }
            LoadGiaoDienCapNhat();
        }
        public void LoadTatCaDropDownList()
        {
            ddlDanhMuc.Items.Clear();
            ddlDanhMuc.Items.Add(new ListItem("Chọn danh mục", "0"));
            ddlNXB.Items.Clear();
            ddlNXB.Items.Add(new ListItem("Chọn nhà xuất bản", "0"));
            ddlTacGia.Items.Clear();
            ddlTacGia.Items.Add(new ListItem("Chọn tác giả", "0"));
            ddlKM.Items.Clear();
            ddlKM.Items.Add(new ListItem("Chọn khuyến mãi", "0"));

            DataTable tbDanhMuc = dbDanhMuc.layDanhSachDuLieu();
            DataTable tbNXB = dbNXB.layDanhSachNXB();
            DataTable tbTacGia = dbTacGia.layDanhSachTacGia();
            DataTable tbKhuyenMai = dbKhuyenMai.LayDanhSachKhuyenMai(idCH, "0");

            foreach(DataRow row in tbDanhMuc.Rows)
            {
                ddlDanhMuc.Items.Add(new ListItem(row["TenDM"].ToString(), row["ID"].ToString()));
            }
            foreach (DataRow row in tbNXB.Rows)
            {
                ddlNXB.Items.Add(new ListItem(row["TenNXB"].ToString(), row["ID"].ToString()));
            }
            foreach (DataRow row in tbTacGia.Rows)
            {
                ddlTacGia.Items.Add(new ListItem(row["TenTG"].ToString(), row["ID"].ToString()));
            }
            foreach (DataRow row in tbKhuyenMai.Rows)
            {
                ddlKM.Items.Add(new ListItem(row["NoiDung"].ToString(), row["ID"].ToString()));
            }

        }
        public void LoadGiaoDienCapNhat()
        {
            LoadTatCaDropDownList();
            if (thaoTac == "capnhat")
            {
                title.Text = "CẬP NHẬT SÁCH";
                ngaytao.Visible = ngaycapnhat.Visible = true;
                DataTable tbSach = dbSanPham.LaySachTheoID(idSach);
                DataRow row = tbSach.Rows[0];
                tbTenSach.Text = row["TenSach"].ToString();
                ddlTacGia.SelectedValue = row["MaTG"].ToString();
                ddlDanhMuc.SelectedValue = row["MaDM"].ToString();
                ddlNXB.SelectedValue = row["MaNXB"].ToString();
                tbNamXuatBan.Text = row["NamXuatBan"].ToString();
                ddlKM.SelectedValue = row["MaKM"].ToString();
                tbSoTrang.Text = row["SoTrang"].ToString();
                tbKichThuoc.Text = row["KichThuoc"].ToString();
                tbTrongLuong.Text = row["TrongLuong"].ToString();
                tbSoLuong.Text = row["SoLuong"].ToString();
                tbGiaBia.Text = row["GiaBia"].ToString();
                tbDaBan.Text = row["DaBan"].ToString();
                DateTime ngayTao = DateTime.Parse(row["NgayTao"].ToString());
                tbNgayTao.Text = ngayTao.ToString("dd-MM-yyyy");
                DateTime ngayCapNhat = DateTime.Parse(row["NgayCapNhat"].ToString());
                tbNgayCapNhat.Text = ngayCapNhat.ToString("dd-MM-yyyy");
                imgAnhDaiDien.ImageUrl = "../../../Image/product/" + row["HinhAnh"].ToString();
                lbAnhDaiDienCu.Text = row["HinhAnh"].ToString(); 
                btnDatLai.Text = "Quay lại";
                btnThemMoi.Text = "Cập nhật";
                tbDaBan.Visible = true;
            }
            else
            {
                title.Text = "THÊM MỚI SÁCH";
                ngaytao.Visible = ngaycapnhat.Visible = false;
                btnDatLai.Text = "Đặt lại";
                btnThemMoi.Text = "Thêm mới";
                tbDaBan.Visible = false;
            }
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            string tenSach = tbTenSach.Text;
            string hinhAnh = "";
            string maTG = ddlTacGia.SelectedValue;
            string maDM = ddlDanhMuc.SelectedValue;
            string maNXB = ddlNXB.SelectedValue;
            string namXB = tbNamXuatBan.Text;
            string maKM = ddlKM.SelectedValue;
            string soTrang = tbSoTrang.Text;
            string kichThuoc = tbKichThuoc.Text;
            string trongLuong = tbTrongLuong.Text;
            string soLuong = tbSoLuong.Text;
            string giaBia = tbGiaBia.Text;
            string daBan = tbDaBan.Text;
            string ngayCapNhat = DateTime.Today.ToString("MM-dd-yyyy");
            if(btnThemMoi.Text == "Thêm mới")
            {
                string ngayTao = DateTime.Today.ToString("MM-dd-yyyy");
                if (flAnhDaiDien.FileContent.Length > 0)
                {
                    if (flAnhDaiDien.FileName.EndsWith(".jpeg") || flAnhDaiDien.FileName.EndsWith(".jpg") || flAnhDaiDien.FileName.EndsWith(".png") || flAnhDaiDien.FileName.EndsWith(".gif"))
                    {
                        flAnhDaiDien.SaveAs(Server.MapPath("Image/product/") + flAnhDaiDien.FileName);
                        hinhAnh = flAnhDaiDien.FileName;
                    }
                }
                else
                {
                    lbThongBaoAnhDaiDien.Text = "Chưa chọn ảnh sản phẩm.";
                    return;
                }
                if (dbSanPham.ThemMoiSach(tenSach, hinhAnh, maTG, maDM, maNXB, namXB, idCH, maKM, soTrang, kichThuoc, trongLuong, soLuong, giaBia,  ngayTao, ngayCapNhat))
                {
                    thongBao(1, "Thành công", "Thêm mới thành công!");
                    Response.Redirect("KenhBanHang.aspx?modul=SanPham&thaotac=DanhSach&tinhtrang=0");
                }
                else
                {
                    thongBao(2, "Lỗi", "Thêm mới thất bại!");
                }
            }
            else
            {
                hinhAnh = lbAnhDaiDienCu.Text;
                if (flAnhDaiDien.FileContent.Length > 0)
                {
                    if (flAnhDaiDien.FileName.EndsWith(".jpeg") || flAnhDaiDien.FileName.EndsWith(".jpg") || flAnhDaiDien.FileName.EndsWith(".png") || flAnhDaiDien.FileName.EndsWith(".PNG") || flAnhDaiDien.FileName.EndsWith(".gif"))
                    {
                        flAnhDaiDien.SaveAs(Server.MapPath("Image/product/") + flAnhDaiDien.FileName);
                        hinhAnh = flAnhDaiDien.FileName;
                    }
                }
                if (dbSanPham.CapNhatSach(idSach, tenSach, hinhAnh, maTG, maDM, maNXB, namXB, maKM, soTrang, kichThuoc, trongLuong, soLuong, giaBia, daBan,  ngayCapNhat))
                {
                    thongBao(1, "Thành công", "Cập nhật thành công!");
                    Response.Redirect("KenhBanHang.aspx?modul=SanPham&thaotac=DanhSach&tinhtrang=0");
                }
                else
                {
                    thongBao(2, "Lỗi", "Cập nhật thất bại!");
                }
            }
        }

        protected void btnDatLai_Click(object sender, EventArgs e)
        {
            if(btnDatLai.Text == "Đặt lại")
            {
                tbTenSach.Text = "";
                ddlTacGia.SelectedValue = "0";
                ddlDanhMuc.SelectedValue = "0";
                ddlNXB.SelectedValue = "0";
                tbNamXuatBan.Text = "";
                ddlKM.SelectedValue = "0";
                tbSoTrang.Text = "";
                tbKichThuoc.Text = "";
                tbTrongLuong.Text = "";
                tbSoLuong.Text = "";
                tbGiaBia.Text = "";
            }
            else
            {
                Response.Redirect("KenhBanHang.aspx?modul=SanPham&thaotac=DanhSach&tinhtrang=0");
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
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