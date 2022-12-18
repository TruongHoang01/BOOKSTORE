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
                strLiteral += r["TenCD"].ToString();
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

        protected void btnThemVaoGioHang_Click(object sender, EventArgs e)
        {
            dbGioHang = new DuLieu.GioHang();
            string soLuong = tbsoluong.Text;
            string idtk = Session["idtk"].ToString();
            if (dbGioHang.ThemVaoGioHang(idtk, idSP, soLuong))
            {
               
            }
        }
    }
}