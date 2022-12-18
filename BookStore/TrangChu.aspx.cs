using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore
{
    public partial class TrangChu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idtk"] == null)
            {
                Random r = new Random();
                Session["idtk"] = r.Next(1000, 10000).ToString();
            }
        }
    }
}
//aaaaaaaa