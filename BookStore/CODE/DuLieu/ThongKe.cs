using System;

namespace BookStore.CODE.DuLieu
{
    public class ThongKe
    {
        KetNoi ketNoi = new KetNoi();

        public int SoBaiDangCuaHang(string idch, string ngayBD, string ngayKT)
        {
            string sql = "select count(id) from SACH where tinhtrang=0 and soluong<>0 and NgayTao Between '"+ngayBD+"' and '"+ngayKT+"' and MaCuaHang="+idch;
            return (int) ketNoi.getScalar(sql);
        }
        public int SoBaiDangCuaHang(string idch)
        {
            string sql = "select count(id) from SACH where tinhtrang=0 and soluong<>0 and MaCuaHang=" + idch;
            return (int)ketNoi.getScalar(sql);
        }

        internal int LaySoLuongTaiKhoan()
        {
            string sql = "select count(ID) from taikhoan where tinhtrang=0";
            return (int)ketNoi.getScalar(sql);
        }

        internal int LaySoLuongTaiKhoanMoi(string ngayBD, string ngayKT)
        {

            string sql = "select count(ID) from taikhoan where tinhtrang=0 ";
            if (ngayBD != "" && ngayKT != "")
                sql += "and ngaytao between '" + ngayBD + "' and '" + ngayKT + "'";
            return (int)ketNoi.getScalar(sql);
        }

        internal int LaySoLuongDonHang(string ngayBD, string ngayKT)
        {
            string sql = "select count(ID) from donhang where tinhtrang<>4";
            if (ngayBD != "" && ngayKT != "")
                sql += " and ngaytao between '" + ngayBD + "' and '" + ngayKT + "'";
            return (int)ketNoi.getScalar(sql);
        }

        internal int LayTongDoanhThu(string ngayBD, string ngayKT)
        {
            string sql = "select sum(soluong*giaban) from chitietdonhang ct, donhang dh where ct.ID_DH=dh.ID and dh.tinhtrang<>4";
            if (ngayBD != "" && ngayKT != "")
                sql += " and ngaytao between CONVERT(VARCHAR,'" + ngayBD + "',103)  and CONVERT(VARCHAR,'" + ngayKT + "',103)";
            return (int)ketNoi.getScalar(sql);
        }

        internal int LaySoLuongBaiDang(string ngayBD, string ngayKT)
        {
            string sql = "select count(ID) from sach where tinhtrang=0";
            if (ngayBD != "" && ngayKT != "")
                sql += " and ngaytao between '" + ngayBD + "' and '" + ngayKT + "'";
            return (int)ketNoi.getScalar(sql);
        }

        internal int LaySoLuongCuaHang(string ngayBD, string ngayKT)
        {
            string sql = "select count(ID) from cuahang";
            if (ngayBD != "" && ngayKT != "")
                sql += " and ngaytao between '" + ngayBD + "' and '" + ngayKT + "'";
            return (int)ketNoi.getScalar(sql);
        }
    }
}