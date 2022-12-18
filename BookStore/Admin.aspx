<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="BookStore.Admin" %>

<%@ Register Src="~/CODE/QuanTriVien/ucQuanTriVien.ascx" TagPrefix="uc1" TagName="ucQuanTriVien" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CODE/css/style.css" rel="stylesheet" />
    <link href="CODE/css/admin.css" rel="stylesheet" />
       <script src="https://kit.fontawesome.com/8deb314de0.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="div1300px">
                <div class="divflex itemCenter">
                    <div >
                        <img style="width: 200px; height: 100px" src="Image/logo.jpg" />
                    </div>
                    <div class="logout">
                        Chào Admin!
                        <asp:LinkButton Text="Đăng xuất" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class=" AdminNavbar">
            <div class="div1300px divflex">
                <div class="divSanPhamCha">
                    <a class="MenuItem" >Quản lý sản phẩm</a>
                    <div class="divSanPhamCon">
                        <a class="" href="Admin.aspx?modul=DanhMuc"> danh mục</a>
                        <a class="" href="Admin.aspx?modul=TacGia">tác giả</a>
                        <a class="" href="Admin.aspx?modul=NhaXuatBan">Nhà xuất bản</a>
                        <a class="" href="Admin.aspx?modul=ChuDe">Chủ đề</a>
                    </div>
                </div>
                <div><a class="" href="Admin.aspx?modul=TaiKhoan">Quản lý tài khoản</a></div>
                <div><a class="" href="Admin.aspx?modul=YeuCau">Quản lý yêu cầu</a></div>
                <div><a class="" href="Admin.aspx?modul=ThongKeBaoCao">Thống kê báo cáo</a></div>
            </div>
        </div>
        <div class="div1300px">
            <uc1:ucQuanTriVien runat="server" ID="ucQuanTriVien" />
        </div>
    </form>
</body>
</html>
