<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThongKeBaoCao.ascx.cs" Inherits="BookStore.CODE.QuanTriVien.ThongKeBaoCao.ucThongKeBaoCao" %>
<div class="divdate mt20">
        <div class="divdaterow">
            <span>Từ ngày: </span>
            <asp:TextBox ID="from_date" runat="server"/>
            <asp:ImageButton ID="btn_fromdate" ImageUrl="../../../Image/calendar.png" runat="server" />
          
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                TargetControlID="from_date" PopupButtonID="btn_fromdate" Format="MM/dd/yyyy">
            </ajaxToolkit:CalendarExtender>
        </div> 
        <div class="divdaterow">   
            <span>Đến ngày: </span>
            <asp:TextBox ID="date_end" runat="server"   />
            <asp:ImageButton ID="btn_enddate" ImageUrl="../../../Image/calendar.png" runat="server" />
            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                TargetControlID="date_end" PopupButtonID="btn_enddate" Format="MM/dd/yyyy" >
            </ajaxToolkit:CalendarExtender>
        </div>
        <asp:LinkButton CssClass="btncalendar" Onclick="btnXemDuLieu_Click" Text="Xem dữ liệu" runat="server" />
</div>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
     <div>
    <div class="divflex divbaocao">
        <div class="width20 col">
            <p><i class="fa-solid fa-user"></i></p>
            <p> <asp:Label Text="" ID="lbTaiKhoan" runat="server" /></p>
            <p class="danhmuc">TÀI KHOẢN</p>
        </div>
        <div  class="width20 col">
            <p><i class="fa-sharp fa-solid fa-user-plus"></i></p>
            <p>
                <asp:Label Text="" ID="lbTaiKhoanMoi" runat="server" />
            </p>
            <p class="danhmuc">TÀI KHOẢN MỚI</p>
        </div>
        <div  class="width20 col">
            <p><i class="fa-solid fa-store"></i></p>
            <p>
                <asp:Label Text="" ID="lbCuaHang" runat="server" />
            </p>
            <p class="danhmuc">CỬA HÀNG</p>
        </div>
        <div  class="width20 col">
            <p><i class="fa-solid fa-magnifying-glass"></i></p>
            <p>
                <asp:Label Text="120" ID="lbView" runat="server" /></p>
            <p class="danhmuc">VIEW</p>
        </div>
    </div>
    <div  class="divflex divbaocao">
        <div class="width20 col">
            <p><i class="fa-solid fa-book"></i></p>
            <p><asp:Label Text="" ID="lbBaiDang" runat="server" /></p>
            <p class="danhmuc">BÀI ĐĂNG</p>
        </div>
        <div class="width20 col">
            <p><i class="fa-solid fa-cart-shopping"></i></p>
            <p><asp:Label Text="" ID="lbDonHang" runat="server" /></p>
            <p class="danhmuc">ĐƠN HÀNG</p>
        </div>
        <div class="width20 col">
            <p><i class="fa-solid fa-dollar-sign"></i></p>
            <p><asp:Label Text="" ID="lbDoanhThu" runat="server" /></p>
            <p class="danhmuc">DOANH THU</p>
        </div>
        <div class="width20 col">
            <p><i class="fa-solid fa-money-bill-transfer"></i></p>
            <p>
                <asp:Label Text="" ID="lbThue" runat="server" />
            </p>
               <p class="danhmuc">THUẾ</p>
        </div>
    </div>
</div>

    </ContentTemplate>
</asp:UpdatePanel>
