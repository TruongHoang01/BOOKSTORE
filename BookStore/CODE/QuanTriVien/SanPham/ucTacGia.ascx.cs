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

        

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string tenTG = tbTenTG.Text;
            string id = lbID.Text;
            if (tenTG == "")
                lbThongBao.Text = "Chưa nhập tên tác giả!";
            else
            {
                if (btnThem.Text == "Cập nhật")
                {
                    if (knTacGia.capNhatTacGia(id, tenTG))
                    {
                        thongBao(1, "Thành công", "Đã cập nhật thành công!");
                        btnHuy_Click(sender, e);
                    }
                    else
                    {
                        thongBao(2, "Thất bại", "Thao tác không được thực hiện!");
                    }
                }
                else
                {
                    if (knTacGia.themMoiTacGia(tenTG))
                    {
                        thongBao(1, "Thành công", "Đã thêm mới một tác giả!");
                        tbTenTG.Text = "";
                    }
                    else
                    {
                        thongBao(2, "Thất bại", "Thao tác không được thực hiện!");
                    }
                }
                lbThongBao.Text = "";
            }
            
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            lbThem.Text = "THÊM MỚI TÁC GIẢ";
            btnThem.Text = "Thêm mới";
            tbTenTG.Text = "";
            lbThongBao.Text = "";
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            Session["idtg"] = ((ImageButton)sender).CommandArgument;
            btnCancel.Visible = true;
            btnOK.Text = "Xác nhận";
            thongBao(3, "Cảnh báo", "Xác nhận xóa!");

        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            
            if(btnOK.Text == "OK")
            {
                ThongBao.Visible = false;
            }
            else
            {
                 string id = Session["idtg"].ToString();
                btnOK.Text = "OK";
                btnCancel.Visible = false;
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
                case 3: imgThongBao.ImageUrl = "../../../Image/warning.jpeg";
                    break;
            }
            chuDeThongBao.InnerText = chuDe;
            noiDungThongBao.InnerText = noiDung;
            ThongBao.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
        }
    }
}