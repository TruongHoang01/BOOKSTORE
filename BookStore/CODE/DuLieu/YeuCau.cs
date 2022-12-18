using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class YeuCau
    {
        KetNoi ketNoi;
        public YeuCau()
        {
            ketNoi = new KetNoi();
        }
        public DataTable layTatCaDanhSachYeuCau()
        {
            string sql = "select * from YEUCAU order by NgayTao";
            return ketNoi.getDataTable(sql);
        }

        public DataTable layDanhSachYeuCauMoi()
        {
            string sql = "select * from YEUCAU where TinhTrang=0";
            return ketNoi.getDataTable(sql);
        }
        public DataTable layYeuCauTheoID(string id)
        {
            string sql = "select * from YEUCAU where ID=" + id;
            return ketNoi.getDataTable(sql);
        }
        public bool taoMoiYeuCau(string idKH, string chuDe, string noiDung, string ngayTao)
        {
            string sql = "insert into YEUCAU values('" + idKH + "',N'" + chuDe + "',N'" + noiDung + "','" + ngayTao + "',0)";
            return ketNoi.AddDataToTable(sql);
        }
        public bool duyetYeuCau(string id)
        {
            string sql = "update YEUCAU set TinhTrang=1 where ID=" + id;
            return ketNoi.EditData(sql);
        }

        public bool xoaYeuCau(string id)
        {
            string sql = "delete from YEUCAU where ID=" + id;
            return ketNoi.DeleteData(sql);
        }

    }
}