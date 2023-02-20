using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.QuanTriVien.ThongKeBaoCao
{
    public partial class ucThongKeBaoCao : System.Web.UI.UserControl
    {
        DuLieu.ThongKe dbThongKe;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbThongKe = new DuLieu.ThongKe();
            if (!IsPostBack)
                LoadGiaoDien();

        }

        private void LoadGiaoDien()
        {
            string ngayBD = from_date.Text;
            string ngayKT = date_end.Text;
            int taiKhoan = dbThongKe.LaySoLuongTaiKhoan();
            lbTaiKhoan.Text = taiKhoan == -1 ? "0" : taiKhoan.ToString();
            int taiKhoanMoi = dbThongKe.LaySoLuongCuaHang(ngayBD, ngayKT);
            lbTaiKhoanMoi.Text = taiKhoanMoi == -1 ? "0" : taiKhoanMoi.ToString();
            int cuaHang = dbThongKe.LaySoLuongCuaHang(ngayBD, ngayKT);
            lbCuaHang.Text = cuaHang == -1 ? "0" : cuaHang.ToString();
            int baiDang = dbThongKe.LaySoLuongBaiDang(ngayBD, ngayKT);
            lbBaiDang.Text = baiDang==-1?"0":baiDang.ToString();
            int donHang = dbThongKe.LaySoLuongDonHang(ngayBD, ngayKT);
            lbDonHang.Text = donHang==-1?"0":donHang.ToString();
            int doanhThu = dbThongKe.LayTongDoanhThu(ngayBD, ngayKT);
            lbDoanhThu.Text = doanhThu==-1?"0":doanhThu.ToString();
            lbThue.Text = doanhThu == -1?"0":(doanhThu*10/100).ToString();
        }

        protected void btnXemDuLieu_Click(object sender, EventArgs e)
        { 
                 LoadGiaoDien();
        }
    }
}