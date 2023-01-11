using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.QuanTriVien.DanhMuc
{
    public partial class ucDanhSachDanhMuc : System.Web.UI.UserControl
    {
        DuLieu.dbDanhMuc danhMuc;
        protected void Page_Load(object sender, EventArgs e)
        {
            danhMuc = new DuLieu.dbDanhMuc();
            ThongBao.Visible = false;
            hienThiDanhSachDanhMuc();
            hienThiDanhSachDropDownListDanhMuc();
           
        }
        public void hienThiDanhSachDropDownListDanhMuc()
        {
            DataTable dtDanhMuc = danhMuc.layDanhSachDuLieu();
            ddlDanhMucCha.Items.Clear();
            ddlDanhMucCha.Items.Add(new ListItem("Chọn danh mục", "0"));
            foreach(DataRow row in dtDanhMuc.Rows)
            {
                ddlDanhMucCha.Items.Add(new ListItem(row["TenDM"].ToString(), row["ID"].ToString()));
            }
        }
        public void hienThiDanhSachDanhMuc()
        {
            DataTable tb = danhMuc.layDanhSachDuLieu();
            tbDanhMuc.DataSource = tb;
            tbDanhMuc.DataBind();
        
        }
 

        protected void editDM_Click(object sender, ImageClickEventArgs e)
        {
            lbThem.Text = "CẬP NHẬT DANH MỤC";
            btnThem.Text = "Cập nhật";
            string id = ((ImageButton)sender).CommandArgument;
            DataTable dt = danhMuc.layDanhMucTheoID(id);
            if (dt.Rows.Count > 0)
            {
                tbTenDanhMuc.Text = dt.Rows[0]["TenDM"].ToString();
                ddlDanhMucCha.SelectedValue = dt.Rows[0]["IdDmCha"].ToString();
                lbID.Text = dt.Rows[0]["ID"].ToString();
            }
        }
  
        public String validateDanhMuc(string tenDM, string maDmCha)
        {
            if (tenDM == "" && maDmCha == "0")
                return "Chưa chọn danh mục cha và nhập tên danh mục!";
            else if (tenDM == "")
                return "Chưa nhập tên danh mục!";
            else if (maDmCha == "0")
                return "Chưa chọn danh mục cha!";
            else return String.Empty;
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string id = lbID.Text;
            string tenDM = tbTenDanhMuc.Text;
            string maDmCha = ddlDanhMucCha.SelectedValue;
            bool check = false;
            string validate = validateDanhMuc(tenDM, maDmCha);
            if (validate != String.Empty)
                lbThongBao.Text = validate;
            else
            {
                if (btnThem.Text == "Cập nhật")
                {
                    if (danhMuc.capNhatDanhMuc(id, tenDM, maDmCha))
                    {
                        check = true;
                    }
                }
                else if (btnThem.Text == "Thêm mới")
                {
                    if (danhMuc.themMoiDanhMuc(tenDM, maDmCha))
                    {
                        check = true;
                    }
                }
                if (check)
                {
                    btnHuy_Click(sender, e);
                    hienThiDanhSachDanhMuc();
                    thongBao(1, "Thành công", "Thao tác thực hiện thành công!");
                    lbThongBao.Text = "";
                }
                else
                {
                    thongBao(2, "Thất bại", "Thao tác không được thực hiện!");
                }
                
            }
        }



        protected void btnHuy_Click(object sender, EventArgs e)
        {
            lbThem.Text = "THÊM MỚI DANH MỤC";
            btnThem.Text = "Thêm mới";
            ddlDanhMucCha.SelectedValue = "0";
            tbTenDanhMuc.Text = "";
            lbThongBao.Text = "";
        }
        protected void deleteDM_Click(object sender, ImageClickEventArgs e)
        {
            Session["iddm"] = ((ImageButton)sender).CommandArgument;
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
                string id = Session["iddm"].ToString();
                btnOK.Text = "OK";
                btnCancel.Visible = false;
                if (danhMuc.xoaDanhMuc(id))
                {
                    hienThiDanhSachDanhMuc();
                    thongBao(1, "Thành công", "Thao tác thực hiện thành công!");
                }
                else
                {
                    thongBao(2, "Thất bại", "Thao tác không được thực hiện!");
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