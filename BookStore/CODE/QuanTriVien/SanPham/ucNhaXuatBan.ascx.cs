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

     

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string tenNXB = tbNhaXuatBan.Text;
            string id = lbID.Text;
            if (tenNXB == "")
                lbThongBao.Text = "Chưa nhập tên nhà xuất bản!";
            else
            {
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
                lbThongBao.Text = "";
                tbNhaXuatBan.Text = "";
            }
            
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            lbThem.Text = "THÊM MỚI NHÀ XUẤT BẢN";
            btnThem.Text = "Thêm mới";
            lbID.Text = "";
            lbThongBao.Text = "";
            tbNhaXuatBan.Text = "";
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            Session["idnxb"] = ((ImageButton)sender).CommandArgument;
            btnCancel.Visible = true;
            btnOK.Text = "Xác nhận";
            thongBao(3, "Cảnh báo", "Xác nhận xóa!");

        }
        protected void btnOK_Click(object sender, EventArgs e)
        {

            if (btnOK.Text == "OK")
            {
                ThongBao.Visible = false;
            }
            else
            {
                string id = Session["idnxb"].ToString();
                btnOK.Text = "OK";
                btnCancel.Visible = false;
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
        }
    }
}