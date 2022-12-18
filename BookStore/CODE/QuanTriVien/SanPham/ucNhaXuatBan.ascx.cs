using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.QuanTriVien.SanPham
{
    public partial class ucNhaXuatBan : System.Web.UI.UserControl
    {
        DuLieu.NhaXuatBan knNhaXuatBan;
        protected void Page_Load(object sender, EventArgs e)
        {
            knNhaXuatBan = new DuLieu.NhaXuatBan();
            loadDanhSachNhaXuatBan();
        }
        public void loadDanhSachNhaXuatBan()
        {
            DataTable tbNXB = knNhaXuatBan.layDanhSachNXB();
            grNhaXuatBan.DataSource = tbNXB;
            grNhaXuatBan.DataBind();
        }
        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            lbThem.Text = "CẬP NHẬT NHÀ XUẤT BẢN";
            btnThem.Text = "Cập nhật";
            string id = ((ImageButton)sender).CommandArgument;
            DataTable tb = knNhaXuatBan.layNXBTheoID(id);
            tbNhaXuatBan.Text = tb.Rows[0]["TenNXB"].ToString();
            lbID.Text = tb.Rows[0]["ID"].ToString();
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            string id = ((ImageButton)sender).CommandArgument;
            if (knNhaXuatBan.xoaNhaXuatBan(id))
            {
                loadDanhSachNhaXuatBan();
                thongBao(1, "Thành công", "Tác giả đã được xóa");
            }
            else
            {
                thongBao(2, "Thất bại", "Thao tác không được thực hiện");
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string tenNXB = tbNhaXuatBan.Text;
            string id = lbID.Text;
            if (btnThem.Text == "Cập nhật")
            {
                if (knNhaXuatBan.capNhatNXB(id, tenNXB))
                {
                    thongBao(1, "Thành công", "Đã cập nhật thành công!");
                }
                else
                {
                    thongBao(2, "Thất bại", "Thao tác không được thực hiện!");
                }
            }
            else
            {
                if (knNhaXuatBan.themMoiNXB(tenNXB))
                {

                    thongBao(1, "Thành công", "Đã thêm mới một tác giả!");
                }
                else
                {
                    thongBao(2, "Thất bại", "Thao tác không được thực hiện!");
                }
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            lbThem.Text = "THÊM MỚI NHÀ XUẤT BẢN";
            btnThem.Text = "Thêm mới";
            lbID.Text = "";
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