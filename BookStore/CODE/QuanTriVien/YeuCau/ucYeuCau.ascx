<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucYeuCau.ascx.cs" Inherits="BookStore.CODE.QuanTriVien.YeuCau.ucYeuCau" %>
<div class="divTop divflex mt20">
 
</div>
<div class="divTable">
    <div class="HeaderText">DANH SÁCH YÊU CẦU</div>
    <asp:GridView ID="grYeuCau" CssClass="tableAdmin" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField ItemStyle-CssClass="col5 TextCenter" HeaderText="Mã Khách Hàng" DataField="ID_KH" runat="server" />
            <asp:BoundField ItemStyle-CssClass="col20 " HeaderText="Chủ Đề" DataField="ChuDe" runat="server" />
            <asp:BoundField ItemStyle-CssClass="col50" HeaderText="Nội Dung" DataField="NoiDung" runat="server" />
            <asp:BoundField ItemStyle-CssClass="col10" HeaderText="Ngày Gửi" DataField="NgayTao" runat="server" />
            <asp:BoundField ItemStyle-CssClass="col5 TextCenter" HeaderText="Tình Trạng" DataField="TinhTrang" runat="server" />
            <asp:TemplateField HeaderText="Thao tác" ItemStyle-CssClass="TextCenter">
                <ItemTemplate>
                    <asp:ImageButton ID="imgChiTiet" CommandArgument='<%#Eval("ID") %>' OnClick="imgChiTiet_Click" ImageUrl="../../../Image/edit.jpeg" runat="server" title="Cập nhật" />
                    <asp:ImageButton ID="imgDelete" CommandArgument='<%#Eval("ID") %>' OnClick="imgDelete_Click" ImageUrl="../../../Image/delete.png" runat="server" title="Xóa" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<div class="ThongBao" visible="false" id="ThongBao" runat="server">
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

 <div class="dialog overlay" id="model" runat="server">
    <div class="dialog-body">
        <table class="tableAdmin tableChiTiet">
            <tr>
                <th colspan="2">
                    CHI TIẾT YÊU CẦU
                </th>
            </tr>
            <tr>
                <td class="col20">Mã yêu cầu</td>
                <td class="col80">
                    <asp:TextBox ID="tbMaYC" runat="server" ReadOnly="true"/>
                </td>
            </tr>
            <tr>
                <td>Mã KH</td>
                <td>
                    <asp:TextBox ID="tbIDKH" runat="server" ReadOnly="true" />
                </td>
            </tr>
            <tr>
                <td>Chủ đề</td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="tbChuDe" runat="server" TextMode="MultiLine" Rows="4"/>
                </td>
            </tr>
            <tr>
                <td>Nội dung</td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="tbNoiDung" TextMode="MultiLine" Rows="8"  runat="server" />
                </td>
            </tr>
            <tr>
                <td>Ngày tạo</td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="tbNgayTao" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Trạng thái</td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="tbTrangThai" runat="server" />
                </td>
            </tr>
            <tr>
                <td  class="TextCenter" colspan="2">
                    <asp:LinkButton CssClass="btnThem" ID="btnPhanHoi" Onclick="btnPhanHoi_Click" Text="Duyệt" runat="server" />
              
                    <asp:LinkButton  CssClass="btnThem"  ID="btnQuayLai" OnClick="btnQuayLai_Click" Text="Quay lại" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</div>

