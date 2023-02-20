<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHeader.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucHeader" ClientIDMode="Static" %>

<div class="header">
    <div class="div1300px ">
        <div class="headerflex">
            <div>
                <asp:ImageButton ID="imglogo" OnClick="imglogo_Click" Width="160" Height="52" ImageUrl="../../Image/logo1.jpg" runat="server" />
            </div>
            <div class="divTimKiem">
                <asp:TextBox ID="tukhoa" runat="server" PlaceHolder="Tìm Kiếm..." />
                <asp:LinkButton ID="btnTimKiem" OnClick="btnTimKiem_Click" Text="Tìm kiếm" runat="server" />
            </div>
            <div class="divTaiKhoan flex">
                <div>
                    <img class="icon" src="../../Image/taikhoan.jpeg" />
                </div>
                <div style="margin-left: 5px;">
                    <div runat="server" id="divhiden">
                        <span class="linkheader" onclick="btnDangKy_Click()" runat="server">Đăng ký</span>
                        <span class="linkheader" onclick="btnDangNhap_Click()" runat="server" >Đăng nhập</span>
                    </div>
                    <div>
                        <div class="divhovertaikhoan">
                            <asp:Label ID="lbName" CssClass="lbtentaikhoan" Text="Tài khoản" runat="server" Visible="false" />
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
                <asp:LinkButton OnClientClick="return checkLogin()" ID="linkGioHang" OnClick="linkGioHang_Click" CssClass="linkheader" runat="server"><img style="width: 40px" src="../../Image/giohang.png" alt="Alternate Text" /> Giỏ hàng</asp:LinkButton>
            </div>
        </div>
        <div class="divDangKyBanHang flex">
            <div>
                <asp:LinkButton CssClass="linkheader" OnClientClick="return checkLogin()" OnClick="Unnamed_Click" runat="server">
                    <img class="icon" src="https://frontend.tikicdn.com/_desktop-next/static/img/icon-seller.svg"/>
                    Đăng ký Bán hàng
                </asp:LinkButton>
            </div>
            <div>
                <asp:LinkButton CssClass="linkheader" ID="btnKenhNguoiBan" OnClientClick="return checkLogin()" OnClick="btnKenhNguoiBan_Click" Text="Kênh người bán" runat="server" />
            </div>
        </div>
    </div>
</div>
<div class="dialog overlay " id="modelDangNhapDangKy" style="display:none" runat="server">
    <div class="dialog-body dialog-body_dangky-dangnhap">
       <span class="imgClose" onclick="imgClose()">X</span>
        <div class="FormDangKy">
            <div class="title">
                <asp:Label Text="Đăng Nhập" ID="lbFormTitle" runat="server" />
            </div>
               <div class="rowdk">
                <asp:TextBox ID="tbTaiKhoan" runat="server" PlaceHolder="Nhập Email" onblur="validateEmail()" />
                <span id="lbThongBaoEmail" class="validate span"></span>
            </div>
            <div class="rowdk">
                <asp:TextBox ID="tbMatKhau" runat="server" PlaceHolder="Mật khẩu" TextMode="Password" onblur="validatePassword()" />
                <p><span id="lbThongBaoPass" class="validate span"></span></p>
            </div>
           <div class="flex rowdk" style="padding: 0 18px;">
                <asp:TextBox Width="200" ID="tbCaptCha" runat="server" PlaceHolder="Mã Captcha" onblur="validateCaptcha()" />
                <span class="lableCapCha" id="lbCaptCha" runat="server"></span>
                <img src="../../Image/refresh.png" onclick="createCaptcha()" style="width: 24px; height: 24px; line-height:36px; margin-top: 6px;"/>
                <span class="validate span" id="lbThongBaoCaptCha"></span>
               <asp:HiddenField ID="hfCaptCha" runat="server" />
            </div>
            <div>
                <asp:Label CssClass="lbThongBao" ID="lbThongBao" runat="server" />
            </div>
            <div>
                <a href="#" class="button btnDangKy" id="buttonDangKy" onclick="dangKy()">Đăng ký</a>
                <asp:LinkButton OnClick="btnCheckLog_Click" OnClientClick="return checkDangNhap();" CssClass="button btnDangKy" Text="Đăng nhập" ID="buttonDangNhap" runat="server" />
            </div>
            <div>
                <asp:Label Text="" ID="lbFormQuestion" runat="server" />
                <span ID="spanChuyenDoi" onclick="chuyenDoi_Click()" runat="server"></span>
            </div>
        </div>
    </div>
</div>
<div class="dialog overlay " id="DivXacNhanEmail" style="display:none" runat="server">
    <div class="dialog-body dialog-body_xacnhanemail ">
        <asp:ImageButton CssClass="imgClose" ID="imgClose"  ImageUrl="../../Image/close.jpeg" runat="server" />
        <div class="FormXacNhanGmail">
            <div class="div">
                <p>
                    Mã OTP đã được gửi đến địa chỉ gmail của quý khách. 
                    <br />
                    Vui lòng kiểm tra tin nhắn và nhập mã OTP để thực hiện đăng ký
                </p>
            </div>
            <div class="div">
                <asp:TextBox runat="server" ID="tbOtp" />
                <span class="btnxacnhan" onclick="checkOTPGmail()" >Xác nhận</span>
                <br />
                <asp:Label  ID="lbThongBaoXacNhanEmail" runat="server" />
            </div>
            <div class="div">Quý khách không nhận được tin nhắn?</div>
            <div class="div">
                Vui lòng bấm
                        <asp:LinkButton  CssClass="btnguilaima" ID="btnguilaima" Text="Gửi lại mã" runat="server" />
            </div>
            <div class="div">
                hoặc
                <asp:LinkButton  ID="btnBaoLoi" CssClass="linkbaoloi" Text="Báo lỗi không gửi được tin nhắn" runat="server" />
            </div>
        </div>
    </div>
</div>
<div class="ThongBao" visible="false"  id="ThongBao" runat="server">
        <div class="divflex  flexThongBao">
            <div>
                <asp:Image ID="imgThongBao" Width="60" Height="60" runat="server" />
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

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
<script>
    var otpGmail = "";
    var taiKhoan = "";
    var matKhau = "";
    var account = "";
    function createCaptcha() {
        var uniquechar = "";
        const randomchar =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        for (let i = 1; i < 5; i++) {
            uniquechar += randomchar.charAt(
                Math.random() * randomchar.length)
        }
        $("#lbCaptCha")[0].innerText = uniquechar + "";
        $("#hfCaptCha")[0].value = uniquechar + "";
        
    }
    function validateEmail() {
        var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        if ($("#tbTaiKhoan")[0].value == "") {
            $("#lbThongBaoEmail")[0].innerText = "Email không được để trống!";
            return false;
        } else if (!$("#<%=tbTaiKhoan.ClientID%>")[0].value.match(mailformat)) {
            $("#lbThongBaoEmail")[0].innerText = "Email không đúng định dạng!";
            return false;
        } else {
            $("#lbThongBaoEmail")[0].innerText = ""
            return true;
        }
    }
    function validatePassword() {
        const valuePass = $("#tbMatKhau")[0].value
        if (valuePass == "") {
            $("#lbThongBaoPass")[0].innerText = "Mật khẩu không được để trống";
            return false;
        } else
            $("#lbThongBaoPass")[0].innerText = "";
        return true;

    }
    function validateCaptcha() {
        if ($("#tbCaptCha")[0].value == "") {
            $("#lbThongBaoCaptCha")[0].innerText = "Mã captcha không được để trống.";
            return false;
        } else if ($("#lbCaptCha")[0].innerText != $("#tbCaptCha")[0].value) {
            $("#lbThongBaoCaptCha")[0].innerText = "Mã captcha không chính xác."
            return false
        } else {
            $("#lbThongBaoCaptCha")[0].innerText = ""
            return true
        }

    }
    function btnDangKy_Click(e ) {
        createCaptcha()
        reset()
        const ele = $("#modelDangNhapDangKy")[0];
        ele.style.display = "flex";
        $("#lbFormTitle")[0].innerText = "Đăng ký"
        $("#buttonDangKy")[0].style.display = "inline-block"
        $("#buttonDangNhap")[0].style.display = "none"
        $("#lbFormQuestion")[0].innerHTML = "Bạn đã có tài khoản? <br> Vui lòng chọn "
        $("#spanChuyenDoi")[0].innerText = "Đăng nhập."
       
    }
    function btnDangNhap_Click(e) {
        createCaptcha()
        reset()
        const ele = $("#modelDangNhapDangKy")[0];
        ele.style.display = "flex";
        console.log(ele)
        $("#lbFormTitle")[0].innerText = "Đăng nhập"
        $("#buttonDangKy")[0].style.display = "none"
        $("#buttonDangNhap")[0].style.display = "inline-block"
        $("#lbFormQuestion")[0].innerHTML = "Bạn chưa có tài khoản? <br> Vui lòng chọn "
        $("#spanChuyenDoi")[0].innerText = "Đăng ký."
      
    }
    function reset() {
        $("#<%=tbTaiKhoan.ClientID%>")[0].value = "";
        $("#<%=tbMatKhau.ClientID%>")[0].value = "";
        $("#tbCaptCha")[0].value = "";
        $("#lbThongBaoPass")[0].innerText = "";
        $("#lbThongBaoCaptCha")[0].innerText = "";
        $("#lbThongBaoEmail")[0].innerText = "";
        $("#lbThongBao")[0].innerText = "";
    }
    function chuyenDoi_Click() {
        if ($("#lbFormTitle")[0].innerText == "Đăng nhập")
            btnDangKy_Click()
        else {
            btnDangNhap_Click()
        }
    }
    function imgClose() {
        reset();
        $("#modelDangNhapDangKy")[0].style.display = "none";
        conlole.log("hihi")
    }
    function dangKy() {
        validateCaptcha();
        validateEmail();
        validatePassword();
        if (validateCaptcha() && validateEmail() && validatePassword()) {
            taiKhoan = $("#<%=tbTaiKhoan.ClientID%>")[0].value;
            matKhau = $("#<%=tbMatKhau.ClientID%>")[0].value
            account = {
                "UserName": taiKhoan,
                "Password": matKhau
            };
            $.ajax({
                type: "POST",
                url: "TrangChu.aspx/checkDangKy",
                data: JSON.stringify({ account }),
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                success: function (response) {
                    if (response.d) {
                        $("#modelDangNhapDangKy")[0].style.display = "none";
                        $("#DivXacNhanEmail")[0].style.display = "flex";
                        $.ajax({
                            type: "POST",
                            url: "TrangChu.aspx/SendEmail",
                            data: JSON.stringify({ account }),
                            contentType: "application/json; charset=utf-8",
                            datatype: "json",
                            success: function (res) {
                                otpGmail = res.d;
                            },
                            failure: function () {
                               
                            }
                        });
                        console.log("Mã otp đã gửi: " + otpGmail)
                    } else {
                        $("#lbThongBao")[0].innerText = "Tài khoản đã tồn tại. Vui lòng chọn đăng nhập"
                    }
                },
                failure: function () {
                }
            });
         
        } else {
            $("#lbThongBao")[0].innerText = "Thông tin không hợp lệ!"
        }
        createCaptcha()
    }
    function checkOTPGmail(e) {
        if ($("#tbOtp")[0].value == otpGmail) {
            $("#DivXacNhanEmail")[0].style.display = "none";
            $.ajax({
                type: "POST",
                url: "TrangChu.aspx/DangKyTaiKhoan",
                data: JSON.stringify({ account }),
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                success: function (res) {
                    
                    if (res.d == true) {
                        toasting.create({
                            "title": "Thành công",
                            "text": "Bạn đã đăng ký tài khoản. Vui lòng đăng nhập.",
                            "type": "success",
                            "timeout": 3000,
                        })
                        btnDangNhap_Click();
                    }
                    else {
                        toasting.create({
                            "title": "Lỗi",
                            "text": "Đã xãy ra lỗi, đăng ký không thành công!",
                            "type": "error",
                            "timeout": 3000,
                        })
                    }
                },
                failure: function () {
                    alert("error! try again...");
                }
            });
        } else {
            $("#lbThongBaoXacNhanEmail")[0].innerText = "Mã OTP không chính xác. Vui lòng thử lại!";
        }
    }
    function checkDangNhap() {
        validateCaptcha()
        validateEmail()
        validatePassword()
        if (validateCaptcha() && validateEmail() && validatePassword()) {
            taiKhoan = $("#<%=tbTaiKhoan.ClientID%>")[0].value;
            matKhau = $("#<%=tbMatKhau.ClientID%>")[0].value
            account = {
                "UserName": taiKhoan,
                "Password": matKhau
            };
            console.log(account)
             $.ajax({
                type: "POST",
                url: "TrangChu.aspx/checkDangNhap",
                data: JSON.stringify({ account }),
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                success: function (response) {
                    console.log(response.d)
                    if (response.d) {
                        toasting.create({
                            "title": "Thành công",
                            "text": "Bạn đã đăng nhập tài khoản.",
                            "type": "success",
                            "timeout": 3000,
                        })
                        sessionStorage.setItem("login", "true");
                        return true;
                    } else {
                        $("#lbThongBao")[0].innerText = "Tài khoản hoặc mật khẩu không chính xác."
                        return false
                    }
                },
                failure: function () {
                    console.log("hihihi")
                    return false
                }
            });
        } else {
            $("#lbThongBao")[0].innerText = "Thông tin không hợp lệ!"
            return false
        }
        createCaptcha();
    }
    function checkLogin() {
        console.log(sessionStorage.getItem("login") )
        if (sessionStorage.getItem("login") == "true")
            return true;
        else {
            btnDangNhap_Click();
            return false;
        }
    }
</script>

