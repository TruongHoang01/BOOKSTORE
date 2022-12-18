using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class Quyen
    {
        KetNoi ketNoi;
        public Quyen(){
            ketNoi = new KetNoi();
        }
        public DataTable layDanhSachQuyen()
        {
            string sql = "select * from quyen";
            return ketNoi.getDataTable(sql);
        }
    }
}