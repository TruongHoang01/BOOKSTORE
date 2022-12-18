using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class TacGia
    {
        KetNoi ketNoi;
        public TacGia()
        {
            ketNoi = new KetNoi();
        }
        public DataTable layDanhSachTacGia()
        {
            string sql = "select * from TACGIA where TinhTrang=0";
            return ketNoi.getDataTable(sql);
        }

        public bool themMoiTacGia(string tenTG)
        {
            string sql = "insert into TACGIA values(N'" + tenTG + "', 0)";
            return ketNoi.AddDataToTable(sql);
        }
        public bool capNhatTacGia(string id, string tenTG)
        {
            string sql = "update TACGIA set TenTG=N'" + tenTG + "' where ID=" + id;
            return ketNoi.EditData(sql);
        }
        public bool xoaTacGia(string id)
        {
            string sql = "update TACGIA set TinhTrang=1 where ID="+id;
            return ketNoi.EditData(sql);
        }
        public DataTable layTacGiaTheoID(string id)
        {
            string sql = "select * from tacgia where TinhTrang=0 and ID=" + id;
            return ketNoi.getDataTable(sql);
        }
    }

}