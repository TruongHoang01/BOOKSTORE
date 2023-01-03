<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHeader.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucHeader" %>
        <div class="header">
            <div class="div1300px ">
                <div class="headerflex">
                    <div>
                        <asp:ImageButton ID="imglogo" OnClick="imglogo_Click" Width="160" Height="52" ImageUrl="../../Image/logo1.jpg" runat="server" />
                    </div>
                    <div class="divTimKiem">
                        <asp:TextBox ID="tukhoa" runat="server" PlaceHolder="Tìm Kiếm..." />
                        <asp:LinkButton ID="btnTimKiem" OnClick="btnTimKiem_Click"  Text="Tìm kiếm" runat="server" />
                    </div>
                    <div class="divTaiKhoan flex">
                        <div >
                            <img class="icon" src="../../Image/taikhoan.jpeg" />
                        </div>
                            <div style="margin-left: 5px;">
                                <div runat="server" id="divhiden">
                                    <asp:LinkButton CssClass="linkheader" OnClick="btnDangKy_Click" ID="btnDangKy" Text="Đăng ký" runat="server" />
                                    <asp:LinkButton CssClass="linkheader" ID="btnDangNhap" OnClick="btnDangNhap_Click" Text="Đăng nhập" runat="server" />
                                </div>
                                  <div>
                                    <div class="divhovertaikhoan">
                                        <asp:Label ID="lbName" CssClass="lbtentaikhoan" Text="Tài khoản" runat="server"  Visible="false"/>
                                         <div class="danhmuccontaikhoan">
                                        <asp:LinkButton OnClick="linkDonHang_Click" ID="linkDonHang" Text="Đơn hàng của tôi" runat="server" />
                                        <asp:LinkButton ID="linkTaiKhoan" OnClick="linkTaiKhoan_Click" Text="Tài khoản của tôi" runat="server" />
                                        <asp:LinkButton Text="Đánh giá sản phẩm" runat="server" />
                                        <asp:LinkButton ID="btnDangXuat" OnClick="btnDangXuat_Click" Text="Đăng xuất tài khoản" runat="server" />
                                    </div>
                                    </div>
                                   
                                </div>
                            </div>
                    </div>
                    <div class="divGioHang">
                        <asp:LinkButton ID="linkGioHang" OnClick="linkGioHang_Click" CssClass="linkheader" runat="server" ><img style="width: 40px" src="../../Image/giohang.png" alt="Alternate Text" /> Giỏ hàng</asp:LinkButton>
                    </div>
                </div>
                <div class="divDangKyBanHang flex">
                    <div> <asp:LinkButton CssClass="linkheader"  OnClick="Unnamed_Click" runat="server">
                    <img class="icon" src="https://frontend.tikicdn.com/_desktop-next/static/img/icon-seller.svg"/>
                    Đăng ký Bán hàng
                    </asp:LinkButton></div>
                    <div>
                        <asp:LinkButton CssClass="linkheader" ID="btnKenhNguoiBan" OnClick="btnKenhNguoiBan_Click" Text="Kênh người bán" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="dialog overlay " id="modelDangNhapDangKy" runat="server" visible="false">
            <div class="dialog-body dialog-body_dangky-dangnhap">
                   <asp:ImageButton CssClass="imgClose" ID="imgCloseDN" OnClick="imgClose_Click" ImageUrl="../../Image/close.jpeg" runat="server" />
                <div class="FormDangKy">
                    <div class="title">
                        <asp:Label Text="Đăng Nhập" ID="lbFormTitle" runat="server" /></div>
                    <div>
                        <asp:TextBox ID="tbTaiKhoan" runat="server" PlaceHolder="Nhập Email"/>
                    </div>
                      <div>
                        <asp:TextBox ID="tbMatKhau" runat="server" PlaceHolder="Mật khẩu" TextMode="Password"/>
                      
                      </div>
                     <div class="flex" style="padding: 0 18px;">
                        <asp:TextBox Width="200" ID="tbCaptCha" runat="server"  PlaceHolder="Mã Captcha"/>
                          <asp:Label CssClass="lableCapCha" ID="lbCapCha" Text="123456" runat="server" />
                      </div>
                    
                    <div><asp:Label CssClass="lbThongBao" ID="lbThongBao" runat="server" />  </div>
                      <div >
                        <asp:LinkButton OnClick="btnCheckLog_Click" CssClass="button btnDangKy" ID="btnCheckLog" Text="Đăng nhập" runat="server" />
                    </div>
                    <div>
                        <asp:Label Text="" ID="lbFormQuestion" runat="server" />
                        <asp:LinkButton OnClick="btnChuyeNDoi_Click" ID="btnChuyeNDoi" runat="server" />
                    </div>
                </div>
            </div>
        </div>
  <div class="dialog overlay " id="DivXacNhanEmail" runat="server" visible="false">
            <div class="dialog-body dialog-body_xacnhanemail ">
                   <asp:ImageButton CssClass="imgClose" ID="ImageButton1" OnClick="imgClose_Click" ImageUrl="../../Image/close.jpeg" runat="server" />
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