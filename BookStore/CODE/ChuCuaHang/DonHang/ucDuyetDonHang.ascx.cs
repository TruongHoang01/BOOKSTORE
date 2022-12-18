using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.ChuCuaHang.DonHang
{
    public partial class ucDuyetDonHang : System.Web.UI.UserControl
    {
        string idDH = "";
        string tinhtrang = "";
        DuLieu.ChiTietDonHang dbChiTietDonHang;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbChiTietDonHang = new DuLieu.ChiTietDonHang();
            if (Request.QueryString["iddh"] != null)
            {
                idDH = Request.QueryString["iddh"].ToString();
            }
            if (Request.QueryString["tinhtrang"] != null)
            {
                tinhtrang = Request.QueryString["tinhtrang"].ToString();
            }
            LoadGiaoDien();
        }
        public void LoadGiaoDien()
        {
            if (tinhtrang != "1")
            {
                btnDuyet.Visible = false;
                btnHuy.Visible = false;
            }
            DataTable tbDonHang = dbChiTietDonHang.LayDonHangTheoID(idDH);
            grThongTinDonHang.DataSource = tbDonHang;
            if(tbDonHang.Rows.Count  > 0)
            {
                grThongTinDonHang.DataBind();
                DataTable tbChiTiet = dbChiTietDonHang.LayChiTietDonHang(idDH);
                grChiTietDonHang.DataSource = tbChiTiet;
                grChiTietDonHang.DataBind();
                if(tbChiTiet.Rows.Count > 0)
                {
                    grChiTietDonHang.FooterRow.Cells[0].ColumnSpan = 4;
                    grChiTietDonHang.FooterRow.Cells[0].Text = "Tổng tiền: ";
                    grChiTietDonHang.FooterRow.Cells.RemoveAt(1);
                    grChiTietDonHang.FooterRow.Cells.RemoveAt(2);
                    grChiTietDonHang.FooterRow.Cells.RemoveAt(2);
                    grChiTietDonHang.FooterRow.Cells[0].CssClass = "tongtien";
                    grChiTietDonHang.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    int thanhTien = tbChiTiet.AsEnumerable().Sum(row => row.Field<int>("ThanhTien"));
                    grChiTietDonHang.FooterRow.Cells[1].Text = thanhTien + "";
                }
            }
         


        }

        protected void btnDuyet_Click(object sender, EventArgs e)
        {
            if (dbChiTietDonHang.DuyetDonHang(idDH))
            {
                thongBao(1, "Thành công", "Đã duyệt đơn hàng!");
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            if (dbChiTietDonHang.HuyDonHang(idDH))
            {
                thongBao(1, "Thành công", "Đã hủy đơn hàng!");
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect("KenhBanHang.aspx?modul=DonHang&tinhtrang="+tinhtrang);
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