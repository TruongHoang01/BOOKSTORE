<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGuiYeuCau.ascx.cs" Inherits="BookStore.CODE.ChuCuaHang.YeuCau.ucGuiYeuCau" %>


<div class="containerdonhang">
    <div class="divdonhangphai">
        <div class="divthanhden"></div>
        <div class="divthemmoi">
            <div class="divtitle">
                <asp:Label ID="lbtitle" Text="GỬI YÊU CẦU" runat="server" />
            </div>
            <div >
                <div class="rowthemmoi">
                    <span>Chủ đề: </span>
                    <asp:TextBox ID="tbChuDe" runat="server" />
                </div>
                <div class="rowthemmoi flex">
                    <span>Nội dung: </span>
                    <asp:TextBox  class="textArea" ID="tbNoiDung" runat="server"  TextMode="MultiLine"/>
                </div>
                <div class="linkbutton">
                    <asp:LinkButton ID="btnGuiYC" OnClick="btnGuiYC_Click" Text="Gửi" runat="server" />
                    <asp:LinkButton ID="btnHuy" OnClick="btnHuy_Click" Text="Hủy" runat="server"  />
                </div>
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
