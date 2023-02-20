using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class DanhGia
    {
        KetNoi ketNoi;
        public DanhGia()
        {
            ketNoi = new KetNoi();
        }
        public bool ThemMoiDanhGia(string idSach, string idTK, string soSao, string noiDung)
        {
            string sql = "insert into DanhGia values(" + idSach + "," + idTK + "," + soSao + ",N'" + noiDung + "',NULL)";
            return ketNoi.AddDataToTable(sql);
        }
    }
}