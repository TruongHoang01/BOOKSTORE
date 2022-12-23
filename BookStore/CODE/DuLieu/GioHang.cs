using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class GioHang
    {
        KetNoi ketNoi;
        public GioHang()
        {
            ketNoi = new KetNoi();
        }
        public bool ThemVaoGioHang(string id, string idSach, string soLuong)
        {
            string sql = "insert into GioHang values(" + id + "," + idSach + "," + soLuong + ")";
            return ketNoi.AddDataToTable(sql);
        }
        public DataTable LayDanhSachGioHang(string idch)
        {
            string sql = "select S.ID, TenSach, HinhAnh, TenTG, G.SoLuong, S.GiaBia, S.GiaBia as GiaKM, G.SoLuong*S.GiaBia as ThanhTien from SACH S, GIOHANG G, TacGia T where S.ID=G.ID_SACH and S.MaTG=T.ID and MaCuaHang=" + idch;
            return ketNoi.getDataTable(sql);
        }
        public DataTable LayDanhSachCuaHang(string idtk)
        {
            string sql = "select CH.ID, TenCuaHang from CUAHANG CH, GIOHANG GH, SACH S where CH.ID=S.MaCuaHang and S.ID=GH.ID_SACH and GH.ID_KH=" + idtk + " GROUP BY CH.ID, TenCuaHang";
            return ketNoi.getDataTable(sql);
        }
    }
}