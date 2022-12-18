<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThemMoiCapNhatKhuyenMai.ascx.cs" Inherits="BookStore.CODE.ChuCuaHang.KhuyenMai.ucThemMoiCapNhatKhuyenMai" %>


<div class="containerdonhang">
    <div class="divdonhangphai">
        <div class="divthanhden"></div>
        <div class="divthemmoi">
            <div class="divtitle">
                <asp:Label ID="lbtitle" Text="THÊM MỚI KHUYẾN MÃI" runat="server" />
            </div>
            <div class="divflex">
                <div class="divflexcon">
                    <div class="rowthemmoi">
                        <span>Nội dung: </span>
                        <asp:TextBox ID="tbNoiDung" runat="server" />
                    </div>
                    <div class="rowthemmoi">
                        <span>Tỷ lệ KM: </span>
                        <asp:TextBox ID="tbTiLe" runat="server" />
                    </div>
                    <div class="rowthemmoi">
                        <span>Ngày bắt đầu: </span>
                        <asp:Label CssClass="lbcalendar" ID="lbcalendar1" Text="12-12-2022" runat="server" />
                        <asp:LinkButton ID="btnCalendar1" OnClick="btnCalendar1_Click" CssClass="btncalendar" Text="Chọn ngày bắt đầu" runat="server" />
                        <div runat="server" class="divcalendar" id="divcaledar1" visible="false">
                            <asp:Calendar ID="calendar1" runat="server" BackColor="#3399FF" ForeColor="White" Height="280px" TabIndex="10" Width="352px" OnSelectionChanged="calendar1_SelectionChanged"></asp:Calendar>
                        </div>
                    </div>
                    <div class="rowthemmoi">
                        <span>Ngày kết thúc: </span>
                        <asp:Label CssClass="lbcalendar" ID="lbcalendar2" Text="12-12-2022" runat="server" TabIndex="1" />
                        <asp:LinkButton ID="btnCalendar2" OnClick="btnCalendar2_Click" CssClass="btncalendar" Text="Chọn ngày kết thúc" runat="server" />
                        <div runat="server" class="divcalendar" id="divcaledar2" visible="false">
                            <asp:Calendar ID="calendar2" runat="server" BackColor="#3399FF" ForeColor="White" Height="280px" TabIndex="10" Width="352px" OnSelectionChanged="calendar2_SelectionChanged" ></asp:Calendar>
                        </div>
                    </div>
                    <div class="linkbutton ">
                        <asp:CheckBoxList ID="CheckBoxList2" runat="server"></asp:CheckBoxList>
                    </div>
                    <div class="linkbutton">
                        <asp:LinkButton ID="btnThemMoi" OnClick="btnThemMoi_Click" Text="Thêm mới" runat="server" />
                        <asp:LinkButton ID="btnDatLai" OnClick="btnDatLai_Click" Text="Đặt lại" runat="server" />
                    </div>
                </div>
                <div class="divflexcon">
                    <div class="divsanphamkhuyenmai">Chọn sản phẩm khuyến mãi</div>
                    <asp:CheckBoxList ID="cblSanPham" runat="server"></asp:CheckBoxList>
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

