using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.QuanTriVien.SanPham
{
    public partial class ucTacGia : System.Web.UI.UserControl
    {
        DuLieu.TacGia knTacGia;
        protected void Page_Load(object sender, EventArgs e)
        {
            knTacGia = new DuLieu.TacGia();
            loadDanhSachTacGia();

        }
        public void loadDanhSachTacGia()
        {
            DataTable tb = knTacGia.layDanhSachTacGia();
            tbTacGia.DataSource = tb;
            tbTacGia.DataBind();
        }
        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            lbThem.Text = "CẬP NHẬT DANH MỤC";
            btnThem.Text = "Cập nhật";
            string id = ((ImageButton)sender).CommandArgument;
            DataTable tb = knTacGia.layTacGiaTheoID(id);
            tbTenTG.Text = tb.Rows[0]["TenTG"].ToString();
            lbID.Text = tb.Rows[0]["ID"].ToString();
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            string id = ((ImageButton)sender).CommandArgument;
            if (knTacGia.xoaTacGia(id))
            {
                loadDanhSachTacGia();
                thongBao(1, "Thành công", "Tác giả đã được xóa");
            }
            else
            {
                thongBao(2, "Thất bại", "Thao tác không được thực hiện");
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string tenTG = tbTenTG.Text;
            string id = lbID.Text;
            if(btnThem.Text == "Cập nhật")
            {
                if (knTacGia.capNhatTacGia(id, tenTG))
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
                if (knTacGia.themMoiTacGia( tenTG))
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
            lbThem.Text = "THÊM MỚI TÁC GIẢ";
            btnThem.Text = "Thêm mới";
            tbTenTG.Text = "";
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