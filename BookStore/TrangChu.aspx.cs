using BookStore.CODE.DuLieu;
using BookStore.CODE.KhachHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore
{
    public partial class TrangChu : System.Web.UI.Page
    {
        static TaiKhoan dbTaiKhoan = new TaiKhoan();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string SendEmail(Account account)
        {
            Random rnd = new Random();
            string num = rnd.Next(1000, 10000).ToString();
            SendMail.sendMail(account.UserName, "Mã OTP xác nhận gmail BookStore", "Mã xác nhận của bạn là:  " + num);
            return num;
        }
        [WebMethod]
        public static bool checkDangKy(Account account)
        {
            int count = dbTaiKhoan.taiKhoanTonTai(account.UserName);
            if (count > 0)
                return false;
            else
            {
                return true;
            }
        }
        [WebMethod]
        public static bool checkDangNhap(Account account)
        {
            int count = dbTaiKhoan.KiemTraDangNhap(account.UserName, account.Password);
            if (count > 0)
                return true;
            else
            {
                return false;
            }
        }
        [WebMethod]
        public static bool DangKyTaiKhoan(Account account)
        {
            if (dbTaiKhoan.DangKyTaiKhoan(account.UserName, account.Password, DateTime.Now.ToString("MM/dd/yyyy")))
                return true;
            return false;
        }
    }
    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
} 
