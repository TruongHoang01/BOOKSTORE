<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDangKyBanHang.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucDangKyBanhang" %>
<%@ Register Src="~/CODE/KhachHang/ucFooter.ascx" TagPrefix="uc1" TagName="ucFooter" %>



<div class="flex mt20">
    <div class="width50">
        <div class="flex relative">
            <h1 style="font-size: 30px; font-weight: 600; color: #7a7a7a">Đăng ký bán hàng cùng
            </h1>
            <img style="width: 160px; height: 50px" src="../../Image/logonotback.jpg" />
        </div>
        <p>Tiếp cận hơn <span style="color: #40A9FF;">12 triệu</span> lượt truy cập mỗi tháng</p>
        <img class="imgBookStore mt20" src="../../Image/bookstore.jpg" />
    </div>
    <div class="width50 tableDangKy">
        <div class="head">Đăng ký ngay</div>
        <div>
            <div class="lable">Email</div>
            <div>
                <asp:TextBox ID="tbEmail" runat="server" />
            </div>
        </div>
        <div>
            <div class="lable">Tên cửa hàng</div>
            <div>
                <asp:TextBox ID="tbTenCuaHang" runat="server" />
            </div>
        </div>
        <div>
            <div class="lable">Địa chỉ</div>
            <div>
                <asp:TextBox ID="tbDiaChi" runat="server" />
            </div>
        </div>
        <div>
            <div class="lable">Nhập captcha</div>
            <div>
                
                <asp:TextBox Width="300" ID="tbCaptcha" runat="server" />
                <asp:Label CssClass="lableCapCha" ID="lbCapCha" Text="123456" runat="server" />
            </div>
        </div>
        <div class="divbutton">
            <asp:Label ID="lbID" Visible="false" runat="server" />
            <asp:LinkButton ID="btnDangKy" OnClick="btnDangKy_Click" Text="Đăng ký ngay" runat="server" />
        </div>
    </div>
</div>
<div class="rowflex">
    <div class="row1">
        <div>
            <img src="https://salt.tikicdn.com/ts/user/fa/31/98/4274d22438e2359f0ff7de1afe2fcf5a.png" />
        </div>
        <div class="title">Sàn thương mại điện tử bán sách được tin tưởng nhất Việt Nam</div>
        <div>BOOKVN luôn hoàn thiện mình để mang đến những trải nghiệm tốt nhất cho cả Khách Hàng và Nhà Bán. Với 100% hàng chính hãng và hơn 95% Khách Hàng hài lòng, BOOKVN xứng đáng là sàn TMĐT được tin tưởng nhất Việt Nam.</div>
    </div>
    <div class="row1">
        <div>
            <img src="	https://salt.tikicdn.com/ts/user/77/10/04/4c528effdbb6f98b15a1536f43a3cf27.png" alt="Alternate Text" />
        </div>
        <div class="title">Chi phí bán hàng cạnh tranh</div>
        <div>BOOKVN mang đến cơ hội kinh doanh online cho Nhà Bán với mức phí chiết khấu và phí thanh toán rẻ nhất thị trường. Đồng thời, phí vận chuyện cực kỳ cạnh tranh sẽ hỗ trợ tỷ lệ chuyển đổi đơn hàng hiệu quả hơn bao giờ hết.</div>
    </div>
    <div class="row1">
        <div>
            <img src="../../Image/booknow.jpg" />
        </div>
        <div class="title">Dịch vụ BookVNNow 2h</div>
        <div>Duy nhất trên thị trường TMĐT, dịch vụ BookVNNow 2h giúp Nhà Bán trong nước giao hàng trăm ngàn sản phẩm cho Khách Hàng chỉ trong 2 giờ.</div>
    </div>

</div>
 <div class="dialog overlay " id="DivXacNhanEmail" runat="server" visible="false">
            <div class="dialog-body dialog-body_xacnhanemail ">
                   <asp:ImageButton CssClass="imgClose" ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="../../Image/close.jpeg" runat="server" />
                <div class="FormXacNhanGmail">
                    <div class="div">
                        <p>Mã OTP đã được gửi đến địa chỉ gmail của quý khách.  <br />
                        Vui lòng kiểm tra tin nhắn và nhập mã OTP để thực hiện đăng ký</p>
                    </div>
                    <div class="div">
                         <asp:TextBox runat="server" ID="tbOtp"/>
                        <asp:LinkButton CssClass="btnxacnhan" OnClick="btnXacNhanOTP_Click" Text="Xác nhận" ID="btnXacNhanOTP" runat="server" />
                        <br />
                        <asp:Label Text="Mã xác nhận không trùng khớp!" ID="lbThongBaoXacNhanEmail" runat="server" Visible="false"/>
                    </div>
                    <div class="div">Quý khách không nhận được tin nhắn?</div>
                    <div class="div">
                        Vui lòng bấm
                        <asp:LinkButton OnClick="btnguilaima_Click" CssClass="btnguilaima" ID="btnguilaima" Text="Gửi lại mã" runat="server" />
                    </div>
                    <div class="div">
                          hoặc <asp:LinkButton OnClick="btnBaoLoi_Click" ID="btnBaoLoi" CssClass="linkbaoloi" Text="Báo lỗi không gửi được tin nhắn" runat="server" />
                    </div>
                </div>
            </div>
        </div>
  <div class="ThongBao" visible="false"  id="ThongBao" runat="server">
        <div class="divflex  flexThongBao">
            <div>
                <asp:Image ID="imgThongBao" Width="60" Height="60"  runat="server" />
            </div>
            <div class="content">
                <div>
                    <p class="chuDeThongBao" id="chuDeThongBao" runat="server"></p>
                    <p id="noiDungThongBao" runat="server"></p>
                </div>
            </div>
        </div>
        <div class="btnOK">
            <asp:LinkButton OnClick="btnOK_Click" ID="btnOK" Text="OK" runat="server" />
        </div>
    </div>
<uc1:ucFooter runat="server" ID="ucFooter" />
