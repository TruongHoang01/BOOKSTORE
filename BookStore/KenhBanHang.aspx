<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KenhBanHang.aspx.cs" Inherits="BookStore.CODE.ChuCuaHang.KenhBanHang" %>

<%@ Register Src="~/CODE/ChuCuaHang/ucKenhBanHang.ascx" TagPrefix="uc1" TagName="ucKenhBanHang" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BookStore_Kênh bán hàng</title>
    <link href="CODE/css/style.css" rel="stylesheet" />
    <link href="CODE/css/chucuahang.css" rel="stylesheet" />
      <script src="https://kit.fontawesome.com/8deb314de0.js" crossorigin="anonymous"></script> 
</head>
<body>
    <form id="form1" runat="server">
        <div class="kbh_header">
            <div class="flex">
                <asp:LinkButton ID="btnTrangChu" OnClick="btnTrangChu_Click" runat="server" >
                     <img class="logo" src="../../Image/logo.jpg" "/>
                </asp:LinkButton>
                <p class="title">Cửa Hàng</p>
            </div>
            <div class="kbh_divtaikhoan divcenter">
                <img class="logotaikhoan" src="../../Image/taikhoan.jpeg" />
                <asp:Label CssClass="lbtaikhoan" Text="caohuuhieu14" runat="server" />
            </div>
        </div>
        <div class="flex">
             <div class="width15 kbh_divtrai">
                 <div class="dropdown">
                     <asp:LinkButton  class="dropbtn" Text="Quản Lý Đơn Hàng" runat="server"></asp:LinkButton>
                       <ul class="dropdown-content">
                            <li> <a href="KenhBanHang.aspx?modul=DonHang&tinhtrang=0"> Mới</a></li>
                            <li> <a href="KenhBanHang.aspx?modul=DonHang&tinhtrang=1"> Chờ lấy hàng</a></li>
                            <li> <a href="KenhBanHang.aspx?modul=DonHang&tinhtrang=3"> Đã giao</a></li>
                     </ul>
                </div>
                   <div class="dropdown">
                     <asp:LinkButton  class="dropbtn" Text="Quản Lý Sản Phẩm" runat="server"></asp:LinkButton>
                       <ul class="dropdown-content">
                            <li> <a href="KenhBanHang.aspx?modul=SanPham&thaotac=DanhSach&tinhtrang=0">Danh sách sản phẩm</a></li>
                           <li> <a href="KenhBanHang.aspx?modul=SanPham&thaotac=ThemMoi">Thêm mới sản phẩm</a></li>
                     </ul>
                </div>
                   <div class="dropdown">
                     <asp:LinkButton  class="dropbtn" Text="Quản Lý Khuyến Mãi" runat="server"></asp:LinkButton>
                       <ul class="dropdown-content">
                             <li> <a href="KenhBanHang.aspx?modul=KhuyenMai&thaotac=DanhSach&tinhtrang=0">Danh sách khuyến mãi</a></li>
                             <li> <a href="KenhBanHang.aspx?modul=KhuyenMai&thaotac=ThemMoi">Thêm mới khuyến mãi</a></li>
                     </ul>
                </div>
                  <div class="dropdown">
                     <asp:LinkButton  class="dropbtn" Text="Thống Kê Báo Cáo" runat="server"></asp:LinkButton>
                       <ul class="dropdown-content">
                            <li> <asp:LinkButton  href="KenhBanHang.aspx?modul=ThongKe" Text="Dữ liệu bán hàng" runat="server" /></li>
                     </ul>
                </div>
                   <div>
                      <a class="dropbtn" href="KenhBanHang.aspx?modul=YeuCau">Gửi Yêu Cầu</a>
                </div>
            </div>
            <div class="width85">
                <uc1:ucKenhBanHang runat="server" id="ucKenhBanHang" />
            </div>
    </div>
    </form>
</body>
</html>
