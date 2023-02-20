 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="BookStore.TrangChu" %>

<%@ Register Src="~/CODE/KhachHang/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>
<%@ Register Src="~/CODE/KhachHang/UserControl.ascx" TagPrefix="uc1" TagName="UserControl" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CODE/css/style.css" rel="stylesheet" />
    <link href="CODE/css/user.css" rel="stylesheet" />
    <link href="CODE/css/general.css" rel="stylesheet" />
    <script src="CODE/css/js/toasting.js"></script>
    <link href="CODE/css/toasting.css" rel="stylesheet" />
    <link href="CODE/css/swiper-bundle.min.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/8deb314de0.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:ucHeader runat="server" id="ucHeader" />
        <div class="div1300px">
                <uc1:UserControl runat="server" ID="UserControl" />
        </div>
    </form>
     <script
        type="module"
        src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"
      ></script>
  <script
    src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js">
  </script>
    <script src="CODE/css/js/swiper-bundle.min.js"></script>
    <script src="CODE/css/js/index.js"></script>
</body>
</html>
    