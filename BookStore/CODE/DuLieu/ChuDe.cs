using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class ChuDe
    {
        KetNoi ketNoi;
        public ChuDe()
        {
            ketNoi = new KetNoi();
        }
        public DataTable LayDanhSachChuDe()
        {
            string sql = "select * from CHUDE where TinhTrang = 0";
            return ketNoi.getDataTable(sql);
        }
      
        public DataTable LayDanhSachChuDeTheoID(string id)
        {
            string sql = "select * from CHUDE where TinhTrang = 0 and id="+id;
            return ketNoi.getDataTable(sql);
        }
        public bool ThemMoiChuDe(string chuDe)
        {
            string sql = "insert into CHUDE values(N'" + chuDe + "',0)";
            return ketNoi.AddDataToTable(sql);
        }
        public bool ChinhSuaChuDe(string id, string tenCD)
        {
            string sql = "update CHUDE set TenCD=N'" + tenCD + "' where id=" + id;
            return ketNoi.EditData(sql);
        }
        public bool XoaChuDe(string id)
        {
            string sql = "update CHUDE set TinhTrang=1 where id="+id;
            return ketNoi.EditData(sql);
        }
    }
}