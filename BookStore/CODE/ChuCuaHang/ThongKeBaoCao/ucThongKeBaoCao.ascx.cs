using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.CODE.ChuCuaHang.ThongKeBaoCao
{
    public partial class ucThongKeBaoCao : System.Web.UI.UserControl
    {
        string idch = "";
        DuLieu.ThongKe dbThongKe;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbThongKe = new DuLieu.ThongKe();
            if (Session["idch"] != null)
                idch = Session["idch"].ToString();
            LoadGiaoDien();
        }
        public void LoadGiaoDien()
        {
            int soBaiDang = dbThongKe.SoBaiDangCuaHang(idch);
        }

        protected void btnXemDuLieu_Click(object sender, EventArgs e)
        {
            string ngayBD = from_date.Text;
            string ngayKT = date_end.Text;
            int soBaiDang = dbThongKe.SoBaiDangCuaHang(idch, ngayBD, ngayKT);
        }
    }
}