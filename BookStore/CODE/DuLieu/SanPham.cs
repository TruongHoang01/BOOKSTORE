using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class SanPham
    {
        KetNoi ketNoi;
        public SanPham()
        {
            ketNoi = new KetNoi();
        }
        public DataTable LayDanhSachCheckBoxList(string idCH)
        {
            string sql = "select S.ID, TenSach from sach s, khuyenmai km where S.MaKM = km.ID and MaCuaHang=" + idCH + " and (km.tinhtrang=1 or makm=0)";
            return ketNoi.getDataTable(sql);
        }
        public DataTable LaySachTheoID(string id)
        {
            string sql = "select * from sach where id=" + id;
            return ketNoi.getDataTable(sql);
        }

        internal DataTable layChiTietSanPham(string id)
        {
            string sql = "select HinhAnh, MaDM, TenSach, TenTG, TenNXB, NamXuatBan, TiLe, SoTrang, KichThuoc, TrongLuong, SoLuong, GiaBia, FORMAT((GiaBia-GiaBia*TiLe/100), 'N0', 'en-us') AS GiaKM, DaBan, (GiaBia*TiLe/100) as TietKiem from TACGIA tg, NHAXUATBAN nxb, KHUYENMAI km, SACH s where s.matg=tg.id and s.manxb=nxb.id and s.makm=km.id and s.id=" + id;
            return ketNoi.getDataTable(sql);
        }

        internal DataTable TimKiem(string tuKhoa)
        {
            string sql = "select TOP 8 S.ID, HinhAnh, TenSach, MaKM, TenTG, FORMAT(GiaBia, 'N0', 'en-us') AS GiaBia, FORMAT((GiaBia-GiaBia*TiLe/100), 'N0', 'en-us') AS GiaBan, TiLe from SACH S, TACGIA TG, KHUYENMAI KM where S.MaKM=KM.ID and S.MaTG=TG.ID and S.TinhTrang=0 and TenSach like N'%"+tuKhoa+"%' ORDER BY NEWID()";
            return ketNoi.getDataTable(sql);
        }

        internal DataTable LayDanhSachKhuyenMai()
        {
            string sql = "select TOP 8 S.ID as IDSP, HinhAnh, TenSach, TenTG, FORMAT(GiaBia, 'N0', 'en-us') AS GiaBia, FORMAT((GiaBia-GiaBia*TiLe/100), 'N0', 'en-us') AS GiaBan, TiLe from SACH S, TACGIA TG, KHUYENMAI KM where S.MaKM=KM.ID and S.MaTG=TG.ID and S.TinhTrang=0 and MaKM <> 0 and KM.TinhTrang=0 ORDER BY NEWID()";
            return ketNoi.getDataTable(sql);
        }

        public DataTable DanhChoBan()
        {
            string sql = "select TOP 8 S.ID as IDSP, HinhAnh, TenSach, MaKM, TenTG, FORMAT(GiaBia, 'N0', 'en-us') AS GiaBia, FORMAT((GiaBia-GiaBia*TiLe/100), 'N0', 'en-us') AS GiaBan, TiLe from SACH S, TACGIA TG, KHUYENMAI KM where S.MaKM=KM.ID and S.MaTG=TG.ID and S.TinhTrang=0 ORDER BY NEWID()";
            return ketNoi.getDataTable(sql);
        }

        internal DataTable LayDanhSachChuDe(string idSP)
        {
            string sql = "Select TenCD from CHUDE cd, SACH_CHUDE scd where ID_CD=cd.ID and ID_Sach=" + idSP;
            return ketNoi.getDataTable(sql);
        }

        public DataTable DanhSachBanChay()
        {
            string sql = "select TOP 8 S.ID as IDSP, HinhAnh, TenSach, MaKM, TenTG, FORMAT(GiaBia, 'N0', 'en-us') AS GiaBia, FORMAT((GiaBia-GiaBia*TiLe/100), 'N0', 'en-us') AS GiaBan, TiLe from SACH S, TACGIA TG, KHUYENMAI KM where S.MaKM=KM.ID and S.MaTG=TG.ID and S.TinhTrang=0 order by DaBan";
            return ketNoi.getDataTable(sql);
        }
        public DataTable LayDanhSachSanPham(string idCH, string tinhTrang)
        {
            string sql = "select * from Sach where MaCuaHang=" + idCH + " and";
            if (tinhTrang == "0")
                sql += " TinhTrang = 0 and SoLuong <> 0";
            else if (tinhTrang == "1")
                sql += " TinhTrang=0 and SoLuong=0";
            else if (tinhTrang == "2")
                sql += " TinhTrang=2";
            else sql += " TinhTrang <> 2";
            return ketNoi.getDataTable(sql);
        }
        public int LaySoLuongSanPham(string idCH, string tinhTrang)
        {
            string sql = "select * from Sach where MaCuaHang=" + idCH + " and";
            if (tinhTrang == "0")
                sql += " TinhTrang = 0 and SoLuong <> 0";
            else if (tinhTrang == "1")
                sql += " TinhTrang=0 and SoLuong=0";
            else if (tinhTrang == "2")
                sql += " TinhTrang=2";
            else sql += " TinhTrang <> 2";
            return ketNoi.getScalar(sql);
        }
        public bool ThemMoiSach(string tenSach, string hinhAnh, string maTG, string maDM, string maNXB, string namXB, string maCH, string maKM, string soTrang, string kichThuoc, string trongLuong, string soLuong, string giaBia, string daBan, string ngayTao, string ngayCapNhat)
        {
           string sql = "insert into sach values(N'" + tenSach + "', N'" + hinhAnh + "'," + maTG + "," + maDM + "," + maNXB + "," + namXB + "," + maCH + "," + maKM +","+soTrang+ ",'" + kichThuoc + "','" + trongLuong + "'," + soLuong + "," + giaBia + "," + daBan + ",'" + ngayTao + "','" + ngayCapNhat + "',0)";
            return ketNoi.AddDataToTable(sql);
        }
        public bool CapNhatSach(string id, string tenSach, string hinhAnh, string maTG, string maDM, string maNXB, string namXB, string maKM, string soTrang, string kichThuoc, string trongLuong, string soLuong, string giaBia, string daBan,  string ngayCapNhat)
        {
            string sql = "update Sach set TenSach=N'" + tenSach + "', HinhAnh=N'" + hinhAnh + "', MaTG=" + maTG + ", MaDM=" + maDM + ", maNXB=" + maNXB + ",NamXuatBan=" + namXB + ", MaKM=" + maKM + ",SoTrang=" + soTrang + ",KichThuoc='" + kichThuoc + "', TrongLuong='" + trongLuong + "', SoLuong=" + soLuong + ",GiaBia=" + giaBia + ", DaBan=" + daBan + ",NgayCapNhat='" + ngayCapNhat + "' where ID=" + id;
            return ketNoi.EditData(sql);
        }
        public bool XoaSach(string id)
        {
            string sql = "update Sach set TinhTrang=2 where ID=" + id;
            return ketNoi.EditData(sql);
        }

        public bool CapNhatKhuyenMai(string idSP, string idKM)
        {
            string sql = "update SACH set MaKM=" + idKM + " where ID=" + idSP;
            return ketNoi.EditData(sql);
        }

        public DataTable LayDanhSachSanPhamCungLoai(string idDM)
        {
            string sql = "select TOP 5 S.ID as IDSP, HinhAnh, TenSach, MaKM, TenTG, FORMAT(GiaBia, 'N0', 'en-us') AS GiaBia, FORMAT((GiaBia-GiaBia*TiLe/100), 'N0', 'en-us') AS GiaBan, TiLe from SACH S, TACGIA TG, KHUYENMAI KM where S.MaKM=KM.ID and S.MaTG=TG.ID and S.TinhTrang=0 and MaDM=" + idDM + " order by DaBan ";
            return ketNoi.getDataTable(sql);
        }
    }
}