using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.QuanTriVien.QuanLyThue
{
    public partial class ucDanhSachTaiKhoan : System.Web.UI.UserControl
    {
        DuLieu.TaiKhoan knTaiKhoan;
        protected void Page_Load(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
            knTaiKhoan = new DuLieu.TaiKhoan();
            loadDanhSachTaiKhoan();
        }

        public void loadDanhSachTaiKhoan()
        {
            DataTable tbTaiKhoan = knTaiKhoan.LayDanhSachTaiKhoan();
            grTaiKhoan.DataSource = tbTaiKhoan;
            grTaiKhoan.DataBind();
            int i = 0;
            foreach(GridViewRow grRow in grTaiKhoan.Rows)
            {
                ImageButton imgKhoa = grRow.FindControl("btnKhoa") as ImageButton;
                ImageButton imgMoKhoa = grRow.FindControl("btnMoKhoa") as ImageButton;
                if(tbTaiKhoan.Rows[i++]["TinhTrang"].ToString() == "0")
                {
                    imgKhoa.Visible = true;
                    imgMoKhoa.Visible = false;
                }
                else
                {
                    imgKhoa.Visible = false;
                    imgMoKhoa.Visible = true;
                }
            }
            
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
            if(Session["idtkxoa"] != null)
            {
                string id = Session["idtkxoa"].ToString();
                btnCancel.Visible = false;
                if (knTaiKhoan.XoaTaiKhoan(id))
                {
                    loadDanhSachTaiKhoan();
                    thongBao(1, "Thành công", "Tài khoàn này đã bị khóa!");
                }
                else
                {
                    thongBao(2, "Thất bại", "Thao tác không được thực hiện!");
                }
            }
           
        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            string id = ((ImageButton)sender).CommandArgument;
            Response.Redirect("Admin.aspx?modul=TaiKhoan&thaotac=CapNhat&id=" + id);
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            Session["idtkxoa"] = ((ImageButton)sender).CommandArgument;
            btnCancel.Visible = true;
            thongBao(3, "Cảnh báo", "Xóa tài khoản?");
        }

        protected void btnTiemKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text;
            DataTable tb = knTaiKhoan.TimKiemTaiKhoan(tuKhoa);
            if(tb.Rows.Count > 0)
            {
                grTaiKhoan.DataSource = tb;
                grTaiKhoan.DataBind();
            }
            else
            {
                thongBao(3, "Thông báo!", "Email hoặc sdt không tồn tại!");
            }
          
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx?modul=TaiKhoan&thaotac=ThemMoi");
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

        protected void btnMoKHoa_Click(object sender, ImageClickEventArgs e)
        {
            string id = ((ImageButton)sender).CommandArgument;
            if (knTaiKhoan.MoKhoa(id))
            {
                loadDanhSachTaiKhoan();
            }
        }

        protected void btnKhoa_Click(object sender, ImageClickEventArgs e)
        {
            string id = ((ImageButton)sender).CommandArgument;
            if (knTaiKhoan.KhoaTaiKhoan(id))
            {
                loadDanhSachTaiKhoan();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ThongBao.Visible = false;
        }
    }
}