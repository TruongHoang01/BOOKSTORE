using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.KhachHang
{
    public partial class ucDonHang : System.Web.UI.UserControl
    {
        string idtk = "";
        DuLieu.ChiTietDonHang dbChiTiet;
        DuLieu.DonHang dbDonHang;
        string tinhTrang = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            dbChiTiet = new DuLieu.ChiTietDonHang();
            dbDonHang = new DuLieu.DonHang();
            if(Session["idtk"] != null)
            {
                idtk = Session["idtk"].ToString();
            }
            if(Request.QueryString["tintrang"] != null)
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
            foreach(DataRow r1 in tbDonHang.Rows)
            {
                string iddh = r1["ID"].ToString();
                DataTable tbChiTiet = dbChiTiet.LayChiTietDonHang(iddh);
                foreach(DataRow r2 in tbChiTiet.Rows)
                {
                    ltr += @" <div class='center DivChiTietDonHang'>
                                <div class='divflex''>
                                    <div>
                                         <img class='AnhSanPham' src='../../Image/product/"+r2["HinhAnh"].ToString()+ @"'/>
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
                i++;
                ltr = "";
            }
        }

        protected void btnXacNhanOTP_Click(object sender, EventArgs e)
        {
        
   
        }

        protected void btnGui_Click(object sender, EventArgs e)
        {
            string soSao = lbStar.Text;
            string danhGia = txtDanhGia.Text;

        }
     
    }

}