<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTacGia.ascx.cs" Inherits="BookStore.CODE.QuanTriVien.SanPham.ucTacGia" %>

<div class="mt20">
    <div class="divflex">
    <div class="width60 scroll">
        <div class="HeaderText">DANH SÁCH TÁC GIẢ</div>
        <asp:GridView CssClass="tbDanhMuc tableAdmin" ID="tbTacGia" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField ItemStyle-CssClass="TextCenter col10" HeaderText="Mã" DataField="ID" runat="server"/>
                <asp:BoundField ItemStyle-CssClass="col60" HeaderText="Tên" DataField="TenTG" runat="server" />
                <asp:TemplateField HeaderText="Thao tác" ItemStyle-CssClass="TextCenter">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" CommandArgument='<%#Eval("ID") %>' Onclick="imgEdit_Click" ImageUrl="../../../Image/edit.jpeg" runat="server" title ="Cập nhật"/>
                        <asp:ImageButton ID="imgDelete" CommandArgument='<%#Eval("ID") %>' OnClick="imgDelete_Click" ImageUrl="../../../Image/delete.png" runat="server" title="Xóa"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
    <div class="width40">
        <div class="FormThemMoi ml20">
             <table class="tableThemMoi ">
            <tr>
                <th colspan="2">
                    <asp:Label ID="lbThem" Text="THÊM MỚI TÁC GIẢ" runat="server" />
                </th>
            </tr>
            <tr>
                <td>Tên tác giả</td>
                <td>
                    <asp:TextBox runat="server" ID="tbTenTG"/>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="TextCenter">
                    <asp:Label ID="lbID" Visible="false" Text="" runat="server" />
                 <asp:Label Text="" ID="lbThongBao" style="color: red; display: block; text-align:center; " runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="TextCenter ">
                    <asp:LinkButton CssClass="btnThem" OnClick="btnThem_Click" ID="btnThem" Text="Thêm mới" runat="server" />
                    <asp:LinkButton CssClass="btnThem" OnClick="btnHuy_Click" ID="btnHuy" Text="Hủy" runat="server" />
                </td>
            </tr>
        </table>
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
            <asp:LinkButton Visible="false" OnClick="btnCancel_Click" ID="btnCancel" Text="Hủy" runat="server" />
        </div>
</div>