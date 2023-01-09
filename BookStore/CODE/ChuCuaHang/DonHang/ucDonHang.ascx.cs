using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.ChuCuaHang.DonHang
{
    public partial class ucDonHang : System.Web.UI.UserControl
    {
        string tinhTrang = "";
        string idCH ;
        DuLieu.DonHang dbDonHang;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["idch"] != null)
            {
                idCH = Session["idch"].ToString();
            }
            dbDonHang = new DuLieu.DonHang();
            if(Request.QueryString["tinhtrang"] != null)
            {
                tinhTrang = Request.QueryString["tinhtrang"].ToString();
            }
            LoadDanhSachDonHang();
        }

        public void LoadDanhSachDonHang()
        {
            switch (tinhTrang)
            {
               
                case "0":
                    lbloaidonhang.Text = "đơn hàng mới";
                    break;
                case "1":
                    lbloaidonhang.Text = "đơn hàng đã duyệt";
                    break;
                case "2":
                    lbloaidonhang.Text = "đơn hàng đang giao";
                    break;
                case "3":
                    lbloaidonhang.Text = "đơn hàng đã giao";
                    break;
                case "4":
                    lbloaidonhang.Text = "đơn hàng bị hủy";
                    break;
            }
            grDonHang.DataSource = dbDonHang.LayDanhSachDonHang(idCH, tinhTrang);
            grDonHang.DataBind();
            if(tinhTrang == "0")
                HienThiButtonHuy();
        }

        private void HienThiButtonHuy()
        {
            int count = grDonHang.Rows.Count;
           foreach(GridViewRow grRow in grDonHang.Rows)
            {
                ImageButton imgHuy = grRow.FindControl("btnHuy") as ImageButton;
                imgHuy.Visible = true;
            }
        }

        protected void linkChiTietDonHang_Click(object sender, ImageClickEventArgs e)
        {
            string idDH = ((ImageButton)sender).CommandArgument;
            Response.Redirect("KenhBanHang.aspx?modul=DonHang&tinhtrang="+tinhTrang+"&thaotac=chitiet&iddh=" + idDH);
        }

        protected void btnHuy_Click(object sender, ImageClickEventArgs e)
        {
            Session["iddhhuy"] = ((ImageButton)sender).CommandArgument;
            btnCancel.Visible = true;
            thongBao(3, "Cảnh báo", "Xác nhận hủy đơn hàng?");
        }
       

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
            string iddh = Session["iddhhuy"].ToString();
            Session.Remove("iddhhuy");
            if (dbDonHang.HuyDonHang(iddh))
            {
                thongBao(1, "Thành công", "Đã hủy thành công");
                LoadDanhSachDonHang();
                btnCancel.Visible = false;
            }
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

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kieuTimKiem = ddlTimKiem.SelectedValue;
            string tuKhoa = tbTuKhoa.Text;
            DataTable tbDonHang = dbDonHang.TimKiemDonHang(idCH, tuKhoa, tinhTrang, kieuTimKiem);
            if (tbDonHang == null)
                lbThongBao.Text = "Không tìm thấy đơn hàng liên quan";
            else
            {
                lbThongBao.Text = "";
                grDonHang.DataSource = tbDonHang;
                grDonHang.DataBind();
            }
           
        }
    }
}