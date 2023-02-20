using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        string idtk = "";
        CODE.DuLieu.ChiTietDonHang dbChiTiet;
        CODE.DuLieu.DonHang dbDonHang;
        CODE.DuLieu.DanhGia dbDanhGia;
        string tinhTrang = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            dbDanhGia = new CODE.DuLieu.DanhGia();
            dbChiTiet = new CODE.DuLieu.ChiTietDonHang();
            dbDonHang = new CODE.DuLieu.DonHang();
            if (Session["idtk"] != null)
            {
                idtk = Session["idtk"].ToString();
            }
            if (Request.QueryString["tinhtrang"] != null)
            {
                tinhTrang = Request.QueryString["tinhtrang"].ToString();
            }
            if(!IsPostBack)
                LoadGiaoDien();
        }
        public void LoadGiaoDien()
        {
            string ltr = "";
            DataTable tbDonHang = dbDonHang.LayDonHangTheoKhachHang(idtk, tinhTrang);
            dlDonHang.DataSource = tbDonHang;
            dlDonHang.DataBind();
            int i = 0;
            foreach (DataRow r1 in tbDonHang.Rows)
            {
                string iddh = r1["ID"].ToString();
                DataTable tbChiTiet = dbChiTiet.LayChiTietDonHang(iddh);
                foreach (DataRow r2 in tbChiTiet.Rows)
                {
                    ltr += @" <div class='center DivChiTietDonHang'>
                                <div class='divflex''>
                                    <div>
                                         <img class='AnhSanPham' src='../../Image/product/" + r2["HinhAnh"].ToString() + @"'/>
                                    </div>
                                    <div>
                                        <p> 
                                            <span class='TenSanPham'>" + r2["TenSach"].ToString() + @"</span>
                                        </p>   
                                        <p>
                                            <span class='chitiet'>" + r2["TenTG"].ToString() + @"</span>
                                         </p>
                                        <p class='chitiet'>Số lượng: " + r2["SoLuong"].ToString() + @"</p>
                                    </div>
                                </div>
                            <div>
                                <p class='Gia'>
                                    <span>" + r2["GiaBia"].ToString() + @"đ</span>
                                    <span>" + r2["GiaBan"].ToString() + @"đ</span>
                                </p>
                            </div>
                        </div>";
                }
                int thanhTien = dbDonHang.TinhTongDonHang(iddh);
                DataListItem dlitem = dlDonHang.Items[i];
                Literal ltrSanPham = dlitem.FindControl("ltrDonHang") as Literal;
                Label lb = dlitem.FindControl("lbThanhTien") as Label;
                lb.Text = thanhTien + "đ";
                ltrSanPham.Text = ltr;
                ltr = "";
                if(tinhTrang == "0")
                {
                    Button btnHuy = dlitem.FindControl("btnHuy_DanhGia") as Button;
                    btnHuy.Visible = true;
                    btnHuy.Text = "Hủy đơn hàng";
                }else if(tinhTrang == "3")
                {
                    Button btnHuy = dlitem.FindControl("btnHuy_DanhGia") as Button;
                    btnHuy.Visible = true;
                    btnHuy.Text = "Đánh giá";
                }
                i++;
            }
        }
  

        protected void btnGui_Click(object sender, EventArgs e)
        {
            bool check = true;
            foreach (DataListItem rowSP in dlsanpham.Items)
            {
                string idsp = (rowSP.FindControl("hfID") as HiddenField).Value;
                string soSao = (rowSP.FindControl("r1") as AjaxControlToolkit.Rating).CurrentRating.ToString();
                string noiDungDanhGia = (rowSP.FindControl("txtDanhGia") as TextBox).Text;
                if (noiDungDanhGia == "")
                    noiDungDanhGia = "Khách hàng không viết điều gì.";
                check = dbDanhGia.ThemMoiDanhGia(idsp, idtk, soSao, noiDungDanhGia);
            }
            if(check == false)
            {
                thongBao(2, "Lỗi", "Đánh giá không thành công");
            }
            else
            {
                thongBao(1, "Thành công", "Đã đánh giá sản phẩm");
            }

        }
        protected void btnOK_Click(object sender, EventArgs e)
        {

            if (btnOK.Text == "OK")
            {
                ThongBao.Visible = false;

                DivXacNhanEmail.Visible = false;
            }
            else
            {
                string id = Session["iddh"].ToString();
                btnOK.Text = "OK";
                btnCancel.Visible = false;
                if (dbDonHang.HuyDonHang(id))
                {
                    LoadGiaoDien();
                    thongBao(1, "Thành công", "Đơn hàng đã được hủy");
                }
                else
                {
                    thongBao(2, "Thất bại", "Thao tác không được thực hiện");
                }
            }
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
        protected void btnDanhGia_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            DataTable tb = dbChiTiet.LayChiTietDonHang(id);
            dlsanpham.DataSource = tb;
            dlsanpham.DataBind();
            DivXacNhanEmail.Visible = true;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
        }
        protected void btnHuy_DanhGia_Click(object sender, EventArgs e)
        {
            Button btnSender = ((Button)sender);
            string iddh = btnSender.CommandArgument;
            if(btnSender.Text == "Hủy đơn hàng")
            {
                Session["iddh"] = iddh;
                btnCancel.Visible = true;
                btnOK.Text = "Xác nhận";
                thongBao(3, "Chú ý", "Bạn xác nhận hủy đơn hàng");
            }
            else
            {
                DataTable tb = dbChiTiet.LayChiTietDonHang(iddh);
                dlsanpham.DataSource = tb;
                dlsanpham.DataBind();
                DivXacNhanEmail.Visible = true;
            }
        }
    }
}