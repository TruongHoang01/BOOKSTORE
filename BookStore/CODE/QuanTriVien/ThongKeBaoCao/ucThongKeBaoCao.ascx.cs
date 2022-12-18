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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalendar1_Click(object sender, EventArgs e)
        {
            divcaledar1.Visible = true;
            divcaledar2.Visible = false;
        }

        protected void btnCalendar2_Click(object sender, EventArgs e)
        {
            divcaledar2.Visible = true;
        }

        protected void calendar1_SelectionChanged(object sender, EventArgs e)
        {

            DateTime dt = calendar1.SelectedDate;
            lbcalendar1.Text = dt.ToString("dd-MM-yyyy");
            divcaledar1.Visible = false;
        }

        protected void calendar2_SelectionChanged(object sender, EventArgs e)
        {

            DateTime dt = calendar2.SelectedDate;
            lbcalendar2.Text = dt.ToString("dd-MM-yyyy");
            divcaledar2.Visible = false;
        }
    }
}