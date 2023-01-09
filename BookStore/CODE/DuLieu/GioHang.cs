using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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
            string sql = "insert into GioHang values(" + id + "," + idSach + "," + soLuong + ", 0)";
            return ketNoi.AddDataToTable(sql);
        }
        public DataTable LayDanhSachGioHang(string idch)
        {
            string sql = "select S.ID, TenSach, HinhAnh, TenTG, G.SoLuong, S.GiaBia, S.GiaBia as GiaKM, G.SoLuong*S.GiaBia as ThanhTien from SACH S, GIOHANG G, TacGia T where S.ID=G.ID_SACH and S.MaTG=T.ID and G.TinhTrang=0 and MaCuaHang=" + idch;
            return ketNoi.getDataTable(sql);
        }
        public DataTable LayDanhSachCuaHang(string idtk)
        {
            string sql = "select CH.ID, TenCuaHang from CUAHANG CH, GIOHANG GH, SACH S where CH.ID=S.MaCuaHang and S.ID=GH.ID_SACH and GH.TinhTrang = 0 and  GH.ID_KH=" + idtk + " GROUP BY CH.ID, TenCuaHang ";
            return ketNoi.getDataTable(sql);
        }

        internal DataTable LayDanhSachSanPhamCuaHang(string idtk, object maCH)
        {
            string sql = "select S.ID, TenSach, HinhAnh, TenTG, G.SoLuong, S.GiaBia, S.GiaBia as GiaKM, G.SoLuong*S.GiaBia as ThanhTien from SACH S, GIOHANG G, TacGia T where S.ID=G.ID_SACH and S.MaTG=T.ID and G.TinhTrang=1 and MaCuaHang=" + maCH;
            return ketNoi.getDataTable(sql);
        }

        public DataTable LayDanhSachCuaHangDuocChon(string idtk)
        {
            string sql = "select CH.ID, TenCuaHang from CUAHANG CH, GIOHANG GH, SACH S where CH.ID=S.MaCuaHang and S.ID=GH.ID_SACH and GH.TinhTrang = 1 and GH.ID_KH=" + idtk + " GROUP BY CH.ID, TenCuaHang ";
            return ketNoi.getDataTable(sql);
        }

        internal bool CapNhatSanPhamDuocChon(string idtk, string idsp)
        {
            string sql = "update giohang set tinhtrang=1 where id_kh=" + idtk + "and id_sach=" + idsp;
            return ketNoi.EditData(sql);
        }
    }
}