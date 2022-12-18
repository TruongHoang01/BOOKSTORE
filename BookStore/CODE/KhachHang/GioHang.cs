using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.CODE.KhachHang
{
    public class GioHang
    {
        string idsp;
        string soluong;
        public GioHang(string idsp, string soluong)
        {
            this.idsp = idsp;
            this.soluong = soluong;
        }
    }
}