using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class TaiKhoan
    {
        KetNoi ketNoi;
        public TaiKhoan()
        {
            ketNoi = new KetNoi();
        }
        private string RandomString()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < 8; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public DataTable LayDanhSachTaiKhoan()
        {
            string sql = "select TK.ID, Email, SDT, MatKhau, Hoten, GioiTinh, DiaChi, AnhDaiDien, TenQuyen, TinhTrang from taikhoan tk, Quyen Q where Q.ID=TK.MaQuyen and (TinhTrang=0 or TinhTrang=1)";
            return ketNoi.getDataTable(sql);
        }

        public DataTable LayTaiKhoanTheoID(string id)
        {
            string sql = "select * from taikhoan where ID=" + id;
            return ketNoi.getDataTable(sql);
        }
        public bool DangKyTaiKhoan(string taiKhoan, string matKhau, string ngayTao)
        {
            int check;
            string sql = "";
            string hoTen = RandomString();
            if(Int32.TryParse(taiKhoan, out check))
            {
               sql = "insert into TAIKHOAN(SDT,MatKhau,HoTen,NgayTao,MaQuyen, TinhTrang) values('" + taiKhoan + "','" + matKhau + "',N'" + hoTen + "','" + ngayTao + "',2,0)";
            }else
                sql = "insert into TAIKHOAN(Email,MatKhau,HoTen,NgayTao,MaQuyen, TinhTrang) values('" + taiKhoan + "','" + matKhau + "',N'" + hoTen + "','" + ngayTao + "',2,0)";
            return ketNoi.AddDataToTable(sql);
        }
        public int KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            string sql = "select count(ID) from TAIKHOAN where (Email='" + taiKhoan + "' or SDT='" + taiKhoan + "') and MatKhau='" + matKhau + "' and TinhTrang=0";
            return ketNoi.getScalar(sql);
        }
        public bool ThemMoiTaiKhoan(string email, string sdt, string matKhau, string hoTen, string gioiTinh, string diaChi,
            string ngayTao, string ngayCapNhat, string anhDaiDien, string maQuyen)
        {
            string sql = "insert into TAIKHOAN values('"+email+"','"+sdt+"','"+matKhau+
                "',N'"+hoTen+"',N'"+gioiTinh+"',N'"+diaChi+"','"+ngayTao+"','"+ngayCapNhat+"',N'"+anhDaiDien+"',"+maQuyen+", 0)";
            return ketNoi.AddDataToTable(sql);
        }
        public bool CapNhatTaiKhoan(string id, string email, string sdt, string matKhau, string hoTen, 
            string gioiTinh, string diaChi, string ngayCapNhat, string anhDaiDien, string maQuyen)
        {
            string sql = "update TAIKHOAN set Email='" + email + "', SDT='" + sdt + "', MatKhau='" + matKhau +
                "', hoTen=N'" + hoTen + "', gioiTinh=N'" + gioiTinh + "', DiaChi=N'"+diaChi+"', AnhDaiDien=N'" +
                anhDaiDien + "', NgayCapNhat='" + ngayCapNhat + "',MaQuyen=" + maQuyen + " where id=" + id;
            return ketNoi.EditData(sql);
        }

        internal DataTable TimKiemTaiKhoan(string tuKhoa)
        {
            string sql = "select * from TAIKHOAN where (SDT='" + tuKhoa + "' or Email='" + tuKhoa + "') and TinhTrang=0";
            return ketNoi.getDataTable(sql);
        }

        public bool KhoaTaiKhoan(string id)
        {
            string sql = "update TAIKHOAN set TinhTrang=1 where ID=" + id;
            return ketNoi.EditData(sql);
        }

        public bool MoKhoa(string id)
        {
            string sql = "update TaiKhoan set tinhtrang=0 where id=" + id;
            return ketNoi.EditData(sql);
        }
        public bool XoaTaiKhoan(string id)
        {
            string sql = "update TAIKHOAN set TinhTrang=2 where ID=" + id;
            return ketNoi.EditData(sql);
        }

        internal bool SoHuuCuaHang(string idkh)
        {
            string sql = "select count(*) from TaiKhoan tk, CuaHang ch where tk.ID=ch.id_kh and tk.id=" + idkh;
            int count = (int)ketNoi.getScalar(sql);
            return count > 0;
        }
    }
}