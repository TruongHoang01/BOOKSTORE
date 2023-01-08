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
        string tinhTrang = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void btnXacNhanOTP_Click(object sender, EventArgs e)
        {


        }

        protected void btnGui_Click(object sender, EventArgs e)
        {


        }

        protected void Rating1_Changed(object sender, RatingEventArgs e)
        {

        }



        protected void btnDanhGia_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            DataTable tb = dbChiTiet.LayChiTietDonHang(id);
            dlsanpham.DataSource = tb;
            dlsanpham.DataBind();
            DivXacNhanEmail.Visible = true;
        }

        protected void btnHuy_DanhGia_Click(object sender, EventArgs e)
        {
            Button btnSender = ((Button)sender);
            string iddh = btnSender.CommandArgument;
            if(btnSender.Text == "Hủy đơn hàng")
            {
                if (dbDonHang.HuyDonHang(iddh))
                {
                    //thongbaodahuy
                    LoadGiaoDien();
                }
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