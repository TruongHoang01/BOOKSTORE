<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaiKhoan.aspx.cs" Inherits="BookStore.WebForm3" %>

<%@ Register Src="~/CODE/KhachHang/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>






<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 
    <link href="CODE/css/user.css" rel="stylesheet" />
    <link href="CODE/css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:ucHeader runat="server" ID="ucHeader" />
        <div class="div1300px">
            <div class="TaiKhoan">
                <div class="flex">
                    <div class="width30 CotTrai">
                        <div class="divflex">
                            <div>
                                <asp:Image ImageUrl="../../Image/anhdaidien.png" runat="server" />
                            </div>
                            <div>
                                <div>
                                    <asp:Label Text="Cao Hữu Hiếu" runat="server" /></div>
                                <div class="divChinhSua">
                                    <asp:LinkButton runat="server"><i class="fa-regular fa-pen-to-square"></i>  Sửa hồ sơ </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <asp:LinkButton ID="linkTaiKhoan" OnClick="linkTaiKhoan_Click" CssClass="link" runat="server"><i class="fa-solid fa-user"></i>Tài khoản của tôi</asp:LinkButton>
                        <asp:LinkButton ID="linkDonHang" OnClick="linkDonHang_Click" CssClass="link" runat="server"><i class="fa-solid fa-list"></i>Đơn mua</asp:LinkButton>
                    </div>
                    <div class="width70 CotPhai">
                            <asp:PlaceHolder runat="server" ID="plTaiKhoan" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
