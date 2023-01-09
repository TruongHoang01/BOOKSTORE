<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTrangChu.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucTrangChu" %>
<%@ Register Src="~/CODE/KhachHang/ucFooter.ascx" TagPrefix="uc1" TagName="ucFooter" %>
<%@ Register Src="~/CODE/KhachHang/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>


<div class="mt12 flex" >
    <div class="width30 trangChu ">
        <div class="head">
            <i class="fa-solid fa-bars"></i>
            Danh mục</div>
        <div class="listDanhMuc">
            <asp:DataList runat="server" ID="dlDanhMuc1">
                <ItemTemplate>
                    <asp:LinkButton OnClick="danhMuc_Click" Text='<%#Eval("TenDM") %>' CommandArgument='<%#Eval("ID") %>' runat="server" />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="head">
       <i class="fa-solid fa-tag"></i>
            Chủ đề</div>
        <div>
            <asp:DataList runat="server" ID="dlChuDe">
                <ItemTemplate>
                    <asp:LinkButton OnClick="chuDe_Click"  Text='<%#Eval("TenCD") %>' CommandArgument='<%#Eval("ID") %>' runat="server" />
                </ItemTemplate>
            </asp:DataList>
           
        </div>
        <div class="head">
            <i class="fa-solid fa-person-breastfeeding"></i>
            Tác giả</div>
        <div>
            <asp:DataList runat="server" ID="dlTacGia">
                <ItemTemplate>
                    <asp:LinkButton OnClick="chuDe_Click" Text='<%#Eval("TenTG") %>' CommandArgument='<%#Eval("ID") %>' runat="server" />
                </ItemTemplate>
            </asp:DataList>
           
        </div>

        <div class="head">
            <i class="fa-solid fa-clipboard"></i>
            Nhà xuất bản</div>
        <div>
            <asp:DataList runat="server" ID="dlNhaXuatBan">
                <ItemTemplate>
                    <asp:LinkButton OnClick="nhaXuatBan_Click" Text='<%#Eval("TenNXB") %>' CommandArgument='<%#Eval("ID") %>' runat="server" />
                </ItemTemplate>
            </asp:DataList>
         
        </div>
    </div>
    <div class="width70">
        <asp:PlaceHolder ID="plTranhChu" runat="server" />
</div>
</div>
<uc1:ucFooter runat="server" ID="ucFooter" />
