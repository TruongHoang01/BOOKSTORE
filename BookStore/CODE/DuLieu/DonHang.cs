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
            string sql = "update DonHang set TinhTrang=4 where ID=" + idDH;
            return ketNoi.EditData(sql);
        }
        public DataTable LayDonHangTheoKhachHang(string idtk, string tinhTrang)
        {
            string sql = "Select D.ID, TenCuaHang from DONHANG D, CUAHANG CH where CH.ID=D.ID_CH  and D.ID_KH="+idtk +" and D.TinhTrang="+tinhTrang;
            return ketNoi.getDataTable(sql);
        }
        public int TinhTongDonHang(string iddh)
        {
            string sql = "Select SUM(C.SoLuong*C.GiaBan) from DONHANG D, CHITIETDONHANG C where  C.ID_DH=D.ID  and D.ID="+iddh + " GROUP BY D.ID";
            return (int)ketNoi.getScalar(sql);
        }

        internal DataTable TimKiemDonHang(string idCH, string tuKhoa, string tinhTrang, string loaiTimKiem)
        {
            string sql = "select ID, HoTen, SDT, DiaChi, format(NgayTao,'dd-MM-yyyy') as NgayTao from DonHang where ID_CH=" + idCH + " and TinhTrang=" + tinhTrang;
            if (loaiTimKiem == "1")
            {
                int iout;
                if (Int32.TryParse(tuKhoa, out iout))
                    sql += " and ID ='" + tuKhoa + "'";
                else return null;
            }
            else if (loaiTimKiem == "2")
                sql += " and HoTen like N'%" + tuKhoa + "%  '";
            else if (loaiTimKiem == "3")
                sql += " and SDT='" + tuKhoa + "'";
            return ketNoi.getDataTable(sql);
        }

        internal bool ThemMoiDonHang(string iddh, string idtk, string maCH, string hoTen, string sdt, string diaChi, string ngayTao, string ghiChu)
        {
            string sql = "insert into DonHang values ("+iddh+", " + idtk + ", " + maCH + ", N'" + hoTen + "','" + sdt + "',N'" + diaChi + "','" + ngayTao + "',N'" + ghiChu + "',0)";
            return ketNoi.AddDataToTable(sql);
        }
    }
}