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
        DuLieu.TaiKhoan dbTaiKhoan;
        DuLieu.DonHang dbDonHang;
        DuLieu.ChiTietDonHang dbChiTietDonHang;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbGioHang = new DuLieu.GioHang();
            dbTaiKhoan = new DuLieu.TaiKhoan();
            dbDonHang = new DuLieu.DonHang();
            dbChiTietDonHang = new DuLieu.ChiTietDonHang();
            if(Session["idtk"] != null)
            {
                idtk = Session["idtk"].ToString();
            }
            LoadGiaoDien();
        }
        public void LoadGiaoDien()
        {
            DataTable tbTaiKhoan = dbTaiKhoan.LayTaiKhoanTheoID(idtk);
            if(tbTaiKhoan.Rows.Count > 0)
            {
                tbTenNguoiNhan.Text = tbTaiKhoan.Rows[0]["HoTen"].ToString();
                tbSDT.Text = tbTaiKhoan.Rows[0]["SDT"].ToString();
                tbDiaChi.Text = tbTaiKhoan.Rows[0]["DiaChi"].ToString();
            }
            DataTable tbCuaHang = dbGioHang.LayDanhSachCuaHangDuocChon(idtk);
            dlCuaHang.DataSource = tbCuaHang;
            dlCuaHang.DataBind();
            int i = 0;
            foreach(DataListItem listCH in dlCuaHang.Items)
            {
                string maCH = tbCuaHang.Rows[i++]["ID"].ToString();
                DataList dlSanPham = listCH.FindControl("dlSanPham") as DataList;
                DataTable tbSanPham = dbGioHang.LayDanhSachSanPhamCuaHang(idtk, maCH);
                int tongtien = dbGioHang.TongTienDonHang(maCH);
                Label lbtongtien = listCH.FindControl("lbtongtien") as Label;
                lbtongtien.Text = tongtien.ToString() + "đ";
                dlSanPham.DataSource = tbSanPham;
                dlSanPham.DataBind();
            }
        }

        protected void btnDatHang_Click(object sender, EventArgs e)
        {
           
            DataTable tbCuaHang = dbGioHang.LayDanhSachCuaHangDuocChon(idtk);
            string hoTen = tbTenNguoiNhan.Text;
            string sdt = tbSDT.Text;
            string diaChi = tbDiaChi.Text;
            string ngayTao = DateTime.Now.ToString("MM/dd/yyyy");
            
            int i = 0;
            foreach (DataRow rowCH in tbCuaHang.Rows)
            {
                Random rnd = new Random();
                string iddh = rnd.Next(1000000,10000000).ToString();
                string maCH = tbCuaHang.Rows[i]["ID"].ToString();
                string ghiChu = (dlCuaHang.Items[i].FindControl("tbGhiChu") as TextBox).Text;
                dbDonHang.ThemMoiDonHang(iddh, idtk, maCH, hoTen, sdt, diaChi, ngayTao, ghiChu);
                  
                DataTable tbSanPham = dbGioHang.LayDanhSachSanPhamCuaHang(idtk, maCH);
                foreach(DataRow rowSP in tbSanPham.Rows)
                {
                    string maSP = rowSP["ID"].ToString();
                    dbGioHang.XoaKhoiGioHang(maSP, idtk);
                    string soLuong = rowSP["SoLuong"].ToString();
                    string giaBan = rowSP["GiaKM"].ToString();
                    dbChiTietDonHang.ThemMoiChiTiet(iddh, maSP, soLuong, giaBan);
                }
                i++;
            }
            thongBao(1, "Thành công", "Bạn đã đặt hàng thành công!");

        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
            Response.Redirect("TrangChu.aspx");
        }
        public void thongBao(int trangThai, string chuDe, string noiDung)
        {
            switch (trangThai)
            {
                case 1:
                    imgThongBao.ImageUrl = "~/Image/success.png";
                    break;
                case 2:
                    imgThongBao.ImageUrl = "~/Image/error.jpeg";
                    break;
                case 3:
                    imgThongBao.ImageUrl = "~/Image/warning.jpeg";
                    break;
            }
            chuDeThongBao.InnerText = chuDe;
            noiDungThongBao.InnerText = noiDung;
            ThongBao.Visible = true;
        }
    }
}