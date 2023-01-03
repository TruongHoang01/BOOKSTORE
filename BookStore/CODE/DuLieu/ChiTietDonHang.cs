using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    public class ChiTietDonHang:DonHang
    {
        
        public ChiTietDonHang():base()
        {

        }
        public DataTable LayChiTietDonHang(string idDH)
        {
            string sql = "select S.HinhAnh, TenTG, S.TenSach, CT.SoLuong,S.GiaBia, CT.GiaBan, CT.SoLuong*CT.GiaBan as ThanhTien from ChiTietDonHang CT, Sach S, TacGia T where T.ID=S.MaTG and  S.ID=CT.ID_Sach and ID_DH=" + idDH;
            return ketNoi.getDataTable(sql);
        }
    }
}