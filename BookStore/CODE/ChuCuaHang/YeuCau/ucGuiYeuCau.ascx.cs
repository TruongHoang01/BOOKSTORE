using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.ChuCuaHang.YeuCau
{
    public partial class ucGuiYeuCau : System.Web.UI.UserControl
    {
        string idKH = "";
        DuLieu.YeuCau dbYeuCau;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbYeuCau = new DuLieu.YeuCau();
            if(Session["idkh"] != null)
            {
                idKH = Session["idkh"].ToString();
            }
        }

        protected void btnGuiYC_Click(object sender, EventArgs e)
        {
            string noiDung = tbNoiDung.Text;
            string chuDe = tbChuDe.Text;
            string ngayTao = DateTime.Today.ToString("MM-dd-yyyy");

            if(dbYeuCau.taoMoiYeuCau(idKH, chuDe, noiDung, ngayTao)){
                thongBao(1, "Thành công", "Đã gửi yêu cầu!");
                btnHuy_Click(sender, e);
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            tbChuDe.Text = "";
            tbNoiDung.Text = "";
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
            Response.Redirect("KenhBanHang.aspx?modul=KhuyenMai&thaotac=DanhSach");
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