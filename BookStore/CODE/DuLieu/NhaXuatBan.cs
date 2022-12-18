using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class NhaXuatBan
    {
        KetNoi ketNoi;
        public NhaXuatBan()
        {
            ketNoi = new KetNoi();
        }
        public DataTable layDanhSachNXB()
        {
            string sql = "select * from NHAXUATBAN where TinhTrang=0";
            return ketNoi.getDataTable(sql);
        }
        public DataTable layNXBTheoID(string id)
        {
            string sql = "select * from NHAXUATBAN where TinhTrang=0 and ID=" + id;
            return ketNoi.getDataTable(sql);
        }
        public bool themMoiNXB(string tenNXB)
        {
            string sql = "insert into NHAXUATBAN values(N'" + tenNXB + "',0)";
            return ketNoi.AddDataToTable(sql);
        }
        public bool capNhatNXB(string id, string tenNXB)
        {
            string sql = "update NHAXUATBAN set TenNXB=N'" + tenNXB + "' where ID=" + id;
            return ketNoi.EditData(sql);
        }
        public bool xoaNhaXuatBan(string id)
        {
            string sql = "update NHAXUATBAN set TinhTrang=1 where ID=" + id;
            return ketNoi.EditData(sql);
        }
    }
}