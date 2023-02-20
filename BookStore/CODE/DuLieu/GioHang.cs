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
            string sql = "insert into GioHang(ID_KH,ID_SACH,SoLuong,TinhTrang) values(" + id + "," + idSach + "," + soLuong + ", 0)";
            return ketNoi.AddDataToTable(sql);
        }
        public DataTable LayDanhSachGioHang(string idch)
        {
            string sql = "select S.ID, TenSach, HinhAnh, TenTG, G.SoLuong, S.GiaBia, (S.GiaBia-S.GiaBia*KM.TiLe/100) as GiaKM, G.SoLuong*(S.GiaBia-S.GiaBia*KM.TiLe/100) as ThanhTien from SACH S, GIOHANG G, TacGia T, KhuyenMai KM where S.MaKM = KM.ID and  S.ID=G.ID_SACH and S.MaTG=T.ID and (G.TinhTrang=0 or G.TinhTrang=1) and MaCuaHang=" + idch;
            return ketNoi.getDataTable(sql);
        }
        public DataTable LayDanhSachCuaHang(string idtk)
        {
            string sql = "select CH.ID, TenCuaHang from CUAHANG CH, GIOHANG GH, SACH S where CH.ID=S.MaCuaHang and S.ID=GH.ID_SACH and GH.TinhTrang = 0 and  GH.ID_KH=" + idtk + " GROUP BY CH.ID, TenCuaHang ";
            return ketNoi.getDataTable(sql);
        }

        internal int TongTienDonHang(string maCH)
        {
            string sql = "select SUM(G.SoLuong*(S.GiaBia-S.GiaBia*KM.TiLe/100)) from SACH S, GIOHANG G, KHUYENMAI KM where S.MaKM =KM.ID and S.ID=G.ID_SACH and G.TinhTrang=1 and MaCuaHang=" + maCH +" group by MaCuaHang";
            return ketNoi.getScalar(sql);
        }

        internal DataTable LayDanhSachSanPhamCuaHang(string idtk, object maCH)
        {
            string sql = "select S.ID, TenSach, HinhAnh, TenTG, G.SoLuong, S.GiaBia,(S.GiaBia-S.GiaBia*KM.TiLe/100) as GiaKM, G.SoLuong*(S.GiaBia-S.GiaBia*KM.TiLe/100) as ThanhTien from SACH S, GIOHANG G, TacGia T, KHUYENMAI KM where S.MaKM =KM.ID and S.ID=G.ID_SACH and S.MaTG=T.ID and G.TinhTrang=1 and MaCuaHang=" + maCH;
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

        internal bool XoaKhoiGioHang(string idsp, string idtk)
        {
            string sql = "delete from giohang where ID_Sach=" + idsp + " and ID_KH=" + idtk;
            return ketNoi.DeleteData(sql);
        }

      

        internal bool CapNhatSoLuong(string idtk, string idsp, string soLuong)
        {
            string sql = "update giohang set SoLuong=SoLuong+"+soLuong+" where ID_KH=" + idtk + " and ID_Sach=" + idsp;
            return ketNoi.EditData(sql);
        }

        internal bool KiemTraGioHang(string idtk, string idSP)
        {
            string sql = "select count(id) from giohang where ID_KH=" + idtk + " and ID_SACH=" + idSP;
            return ketNoi.getScalar(sql) > 0;
        }
        internal bool CapNhatSanPhamChuaDuocMua(string idtk)
        {
            string sql = "update giohang set tinhtrang = 0 where tinhtrang = 1 and ID_KH=" + idtk;
            return ketNoi.EditData(sql);
        }
    }
}