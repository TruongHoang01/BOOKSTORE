using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class DonHang
    {
        protected KetNoi ketNoi;
        public DonHang()
        {
            ketNoi = new KetNoi();
        }
        public DataTable LayDanhSachDonHang(string idCH, string tinhTrang)
        {
            string sql = "select ID, HoTen, SDT, DiaChi, format(NgayTao,'dd-MM-yyyy') as NgayTao from DonHang where ID_CH=" + idCH ;
            if (tinhTrang != "0")
                sql += " and TinhTrang=" + tinhTrang;
            return ketNoi.getDataTable(sql);
        }
        public int LaySoLuongDonHang(string idCH, string tinhTrang)
        {
            string sql = "select count(*) from DonHang where ID_CH="+idCH;
            if (tinhTrang != "0")
                sql += " and TinhTrang=" + tinhTrang;
            return (int)ketNoi.getScalar(sql);
        }
        public DataTable LayDonHangTheoID(string id)
        {
            string sql = "select ID, HoTen, SDT, DiaChi, format(NgayTao,'dd-MM-yyyy') as NgayTao, GhiChu from DonHang where ID=" + id;
            return ketNoi.getDataTable(sql);
        }

        public bool DuyetDonHang(string idDH)
        {
            string sql = "update DonHang set TinhTrang=1 where ID="+idDH;
            return ketNoi.EditData(sql);
        }
        public bool HuyDonHang(string idDH)
        {
            string sql = "update DonHang set TinhTrang=5 where ID=" + idDH;
            return ketNoi.EditData(sql);
        }
        public DataTable LayDonHangTheoKhachHang(string idtk, string tinhTrang)
        {
            string sql = "Select D.ID, TenCuaHang from DONHANG D, CUAHANG CH where CH.ID=D.ID_CH  and D.ID_KH="+idtk +" and D.TinhTrang="+tinhTrang;
            return ketNoi.getDataTable(sql);
        }
        public int TinhTongDonHang(string iddh)
        {
            string sql = "Select SUM(C.SoLuong*C.GiaBan)  from DONHANG D, CHITIETDONHANG C where  C.ID_DH=D.ID  and D.TinhTrang=0 and D.ID="+iddh + " GROUP BY D.ID";
            return (int)ketNoi.getScalar(sql);
        }
    }
}