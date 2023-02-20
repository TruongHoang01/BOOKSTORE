
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.KhachHang
{
    public partial class ucChiTiet : System.Web.UI.UserControl
    {
        string idSP = "";
        DuLieu.SanPham dbSanPham;
        DuLieu.GioHang dbGioHang;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbSanPham = new DuLieu.SanPham();
            if (Request.QueryString["id"] != null)
            {
                idSP = Request.QueryString["id"].ToString();
            }
            if (!IsPostBack)
            {
                LoadGiaoDien();
            }


        }
        public void LoadGiaoDien()
        {
            DataTable tbSanPham = this.dbSanPham.layChiTietSanPham(idSP);
            DataRow row = tbSanPham.Rows[0];
            string strLiteral = "";
            strLiteral +=
                @"<div class='DivAnhSP'>
                    <img src = '../../Image/product/" + row["HinhAnh"].ToString() + @"'/>
                    </div >
                    <div class='ChiTiet'>
                        <h1 class='TenSanPham'>
                            <span>" + row["TenSach"].ToString() + @"</span></h1>
                        <p class='TacGia'>  
                             <span>" + row["TenTG"].ToString() + @"</span>
                        </p>
                        <p class='GiaBan'>
                             <span>" + row["GiaKM"].ToString() + @"đ</span>
                        </p>
                        <p class='TietKiem'>Tiết kiệm:    <span>" + row["TietKiem"].ToString() + "đ(" + row["TiLe"].ToString() + @"%)</span>
                        </p>
                        <p>Giá gốc:  <span>" + row["GiaBia"].ToString() + @"đ</span></p>
                        <p class='TinhTrang'>Kho: <span>" + row["SoLuong"].ToString() + @"</span></p>
                    <p class='The'>Tag:  <span>";
            DataTable tbTag = this.dbSanPham.LayDanhSachChuDe(idSP);
            foreach (DataRow r in tbTag.Rows)
            {
                strLiteral += "<a href='TrangChu.aspx?modul=TimKiem&thaotac=cd"+ r["ID"].ToString()+"'>"+ r["TenCD"].ToString()+"</a>, ";
            }
            strLiteral += "</span></p>";
            ltChiTiet.Text = strLiteral;

            string strLiteral2 = @" <p> <span class='span1'> Nhà xuất bản:</span><span>" + row["TenNXB"].ToString() + @"</span></p>
                                    <p> <span class='span1'> Năm xuất bản:</span><span>" + row["NamXuatBan"].ToString() + @"</span></p>
                                    <p> <span class='span1'> Kích thước:</span><span>" + row["KichThuoc"].ToString() + @"mm</span></p>
                                    <p> <span class='span1'> Số trang:</span><span>" + row["SoTrang"].ToString() + @" trang</span></p>
                                    <p> <span class='span1'> Trọng lượng:</span><span>" + row["TrongLuong"].ToString() + @" gr</span></p>";
            ltrChiTiet2.Text = strLiteral2;
            string idDM = row["MaDM"].ToString();
            DataTable tbSanPhamCungLoai = dbSanPham.LayDanhSachSanPhamCungLoai(idDM);
            dlSanPhamCungLoai.DataSource = tbSanPhamCungLoai;
            dlSanPhamCungLoai.DataBind();
            int i = 0;
            foreach (DataListItem item in dlSanPhamCungLoai.Items)
            {
                if (tbSanPhamCungLoai.Rows[i++]["MaKM"].ToString() == "0")
                {
                    item.FindControl("lbkm1").Visible = false;
                    item.FindControl("lbGiaBia").Visible = false;
                }
            }
        }

        protected void btnThemVaoGioHang1_Click(object sender, EventArgs e)
        {
            if (Session["idtk"] != null)
            {
                dbGioHang = new DuLieu.GioHang();
                string soLuong = tbsoluong.Text;
                string idtk = Session["idtk"].ToString();
                bool check;
                if (dbGioHang.KiemTraGioHang(idtk, idSP))
                {
                    check = dbGioHang.CapNhatSoLuong(idtk, idSP, soLuong);
                }
                else
                {
                    check = dbGioHang.ThemVaoGioHang(idtk, idSP, soLuong);
                }
                if (check)
                    thongBao(1, "Thành công", "Đã thêm vào giỏ hàng");
                else
                {
                    thongBao(3, "Chú ý", "Thêm vào không thành công");
                }
            }
            else
            {
                thongBao(3, "Chú ý", "Vui lòng đăng nhập tài khoản");
            }

        }
        protected void btnThemVaoGioHang2_Click(object sender, EventArgs e)
        {
            if (Session["idtk"] != null)
            {
                string idtk = Session["idtk"].ToString();
                dbGioHang = new DuLieu.GioHang();
                string idSP = ((LinkButton)sender).CommandArgument;
                string soLuong = "1";
                bool check;
                if(dbGioHang.KiemTraGioHang(idtk, idSP))
                {
                     check = dbGioHang.CapNhatSoLuong(idtk, idSP, soLuong);
                }
                else
                {
                    check = dbGioHang.ThemVaoGioHang(idtk, idSP, soLuong);
                }
                if (check)
                    thongBao(1, "Thành công", "Đã thêm vào giỏ hàng");
                else
                {
                    thongBao(3, "Chú ý", "Thêm vào không thành công");
                }
            }
            else
            {
                thongBao(3, "Chú ý", "Vui lòng đăng nhập tài khoản");
            }
        }
        protected void btnGiamSL_Click(object sender, EventArgs e)
        {
            int count = Int32.Parse(tbsoluong.Text);
            if (count != 1)
                count -= 1;
            tbsoluong.Text = count + "";
        }

        protected void btnTangSL_Click(object sender, EventArgs e)
        {
            int count = Int32.Parse(tbsoluong.Text);
            if (count != 10)
                count += 1;
            tbsoluong.Text = count + "";
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
        protected void imgHinhAnhSP_Click(object sender, ImageClickEventArgs e)
        {
            string id = ((ImageButton)sender).CommandArgument;
            Response.Redirect("TrangChu.aspx?modul=ChiTiet&id=" + id);
        }


        protected void linkTenSP_Click1(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;
            Response.Redirect("TrangChu.aspx?modul=ChiTiet&id=" + id);
        }

        protected void btnMuaNgay_Click(object sender, EventArgs e)
        {
            if (Session["idtk"] != null)
            {
                dbGioHang = new DuLieu.GioHang();
                string soLuong = tbsoluong.Text;
                string idtk = Session["idtk"].ToString();
                bool check;
                if (dbGioHang.KiemTraGioHang(idtk, idSP))
                {
                    check = dbGioHang.CapNhatSoLuong(idtk, idSP, soLuong);
                }
                else
                {
                    check = dbGioHang.ThemVaoGioHang(idtk, idSP, soLuong);
                }
                if (check)
                {
                    dbGioHang.CapNhatSanPhamDuocChon(idtk, idSP);
                    Response.Redirect("TrangChu.aspx?modul=DatHang");
                }
                   
                    
               
            }
            else
            {
                thongBao(3, "Chú ý", "Vui lòng đăng nhập tài khoản");
            }
        }
    }
}