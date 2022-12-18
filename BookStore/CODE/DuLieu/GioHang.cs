using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class GioHang
    {
        KetNoi ketNoi;
        public GioHang()
        {
            ketNoi = new KetNoi();
        }
        public bool ThemVaoGioHang(string id, string idSach, string soLuong)
        {
            string sql = "insert into GioHang values(" + id + "," + idSach + "," + soLuong + ")";
            return ketNoi.AddDataToTable(sql);
        }
    }
}