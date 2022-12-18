using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class KhuyenMai
    {
        KetNoi ketNoi;
        public KhuyenMai()
        {
            ketNoi = new KetNoi();
        }
        public DataTable LayDanhSachKhuyenMai(string idCH, string tinhTrang)
        {
            
            string sql = "select * from khuyenmai where ID_CuaHang=" + idCH+
              " and TinhTrang=" + tinhTrang;
            return ketNoi.getDataTable(sql);
        }
        public int LaySoLuongKhuyenMai(string idCH, string tinhTrang)
        {
            string sql = "select count(*) from khuyenmai where ID_CuaHang=" + idCH +
             " and TinhTrang=" + tinhTrang;
            return ketNoi.getScalar(sql);
        }
        public bool ThemKhuyenMai(string noiDung, string tiLe, string ngayBD, string ngayKT, string idCH)
        {
            string sql = "insert into KhuyenMai values(N'" + noiDung + "'," + tiLe + ",'" + ngayBD + "', '" + ngayKT + "',0," +idCH+")";
            return ketNoi.AddDataToTable(sql);
        }
        public DataTable LayKhuyenMaiTheoID(string id)
        {
            string sql = "select * from KhuyenMai where id=" + id;
            return ketNoi.getDataTable(sql);
        }
        public DataTable LaySanPhamCuaDotKhuyenMai(string idKM, string idCH)
        {
            string sql = "select ID, TenSach from Sach where MaKM=" + idKM + " and MaCuaHang=" + idCH;
            return ketNoi.getDataTable(sql);
        }

        internal bool CapNhatKhuyenMai(string idKM, string noiDung, string tiLe, string ngayBD, string ngayKT)
        {
            string sql = "update KhuyenMai set NoiDung=N'" + noiDung + "', TiLe=" + tiLe + ", NgayBatDau='" + ngayBD + "',NgayKetThuc='" + ngayKT + "' where ID=" + idKM;
            return ketNoi.EditData(sql);
        }

        internal bool XoaKhuyenMai(string idKM)
        {
            string sql = "update KhuyenMai set tinhtrang=1 where ID=" + idKM;
            return ketNoi.DeleteData(sql);
        }

        public bool CapNhatKhuyenMaiDaXoa(string idKM)
        {
            string sql = "update sach set MaKM=0 where MaKM=" + idKM;
            return ketNoi.EditData(sql);
        }
    }
}