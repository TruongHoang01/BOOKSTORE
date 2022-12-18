using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    
    public class dbDanhMuc
    {
        KetNoi ketNoi;
        public dbDanhMuc()
        {
            ketNoi = new KetNoi();
        }
       
        public DataTable layDanhSachDuLieu()
        {
            string sql = "select * from DANHMUC where TinhTrang=0";
            return ketNoi.getDataTable(sql);
        }
        public DataTable layDanhMucTheoID(string id)
        {
            string sql = "select * from DANHMUC where  ID=" + id;
            return ketNoi.getDataTable(sql);
        }
        public DataTable layDanhSachDuLieu(string maDanhMucCha)
        {
            string sql = "select * from DANHMUC where TinhTrang=0 and IdDmCha="+maDanhMucCha;
            return ketNoi.getDataTable(sql);
        }
        public bool themMoiDanhMuc(string tenDanhMuc, string maDanhMucCha)
        {
            string sql = "insert into DANHMUC values(N'" + tenDanhMuc + "'," + maDanhMucCha + ",0)";
            return ketNoi.AddDataToTable(sql);
        }
        public bool capNhatDanhMuc(string id, string tenDanhMuc, string maDanhMucCha)
        {
            string sql = "update DANHMUC set TenDM=N'" + tenDanhMuc + "', IdDmCha=" + maDanhMucCha + " where ID=" + id;
            return ketNoi.EditData(sql);
        }
        public bool xoaDanhMuc(string id)
        {
            string sql = "update DANHMUC set TinhTrang=1 where ID=" + id;
            return ketNoi.EditData(sql);
        }

       
    }
}