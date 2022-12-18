using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
   
    public class CuaHang
    {
        KetNoi ketNoi;
        public CuaHang()
        {
            ketNoi = new KetNoi();
        }
        public DataTable LayIDCuaHang(string idkh)
        {
            string sql = "select ID from  CUAHANG where ID_KH=" + idkh;
            return ketNoi.getDataTable(sql);
        }

        internal bool TaoCuaHang(string idKH,  string tenCuaHang, string diaChi)
        {
            string sql = "insert into CUAHANG(ID_KH,TenCuaHang,DiaChi, TinhTrang) values(" + idKH + ",N'" + tenCuaHang + "',N'" + diaChi + "',0)";
            return ketNoi.AddDataToTable(sql);
        }
    }
   
}