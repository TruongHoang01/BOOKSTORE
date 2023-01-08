<%@ Control Language="C#" EnableViewState="true" AutoEventWireup="true" CodeBehind="ucDonHangCaNhan.ascx.cs" Inherits="BookStore.WebUserControl1" %>
<%@ Register Src="~/CODE/KhachHang/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>


 <div class="DonHang">
                <div class="divlink">
                    <a href="TaiKhoan.aspx?modul=TaiKhoan&modulphu=DonHang&tinhtrang=0">Chờ duyệt</a>
                    <a href="TaiKhoan.aspx?modul=TaiKhoan&modulphu=DonHang&tinhtrang=2">Đang vận chuyển</a>
                    <a href="TaiKhoan.aspx?modul=TaiKhoan&modulphu=DonHang&tinhtrang=3">Đã giao</a>
                    <a href="TaiKhoan.aspx?modul=TaiKhoan&modulphu=DonHang&tinhtrang=4">Đã hủy</a>
                </div>
                <asp:DataList runat="server" ID="dlDonHang" Width="100%">
                    <ItemTemplate>
                        <div class="ThongTin">
                            <div class='center DivCuaHang'>
                                <h1><%#Eval("TenCuaHang") %></h1>
                                <p>ĐÃ HỦY </p>
                            </div>
                            <asp:Literal ID="ltrDonHang" runat="server" />
                            <div class="flex-end">
                                <p class="thanhtien">Thành tiền:
                                    <asp:Label ID="lbThanhTien" runat="server" /></p>
                            </div>
                            <div class="flex-end">
                                <asp:Button CommandArgument='<%#Eval("ID") %>' Visible="false" OnClick="btnHuy_DanhGia_Click" ID="btnHuy_DanhGia" CssClass="btnHuy" Text="Hủy đơn hàng" runat="server" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <asp:ScriptManager runat="server" />
            <div class="dialog overlay" id="DivXacNhanEmail" runat="server" visible="false">
                <div class="dialog-body dialog-body_danhgia ">
                    <h1>Đánh giá sản phẩm</h1>
                    <asp:DataList runat="server" ID="dlsanpham" Width="100%">
                        <ItemTemplate>
                            <div class="row">
                                <div class="divflex">
                                    <asp:Image ImageUrl='<%#"../../Image/product/"+Eval("HinhAnh") %>' runat="server" />
                                    <div>
                                        <p class="tensach">  <asp:Label Text='<%#Eval("TenSach") %>' runat="server" /></p>
                                        <p class="tacgia"> <asp:Label Text='<%#Eval("TenTG") %>' runat="server" /></p>
                                        <div class="">
                                            <ajaxToolkit:Rating CssClass="rating" ID="r1" runat="server"
                                            CurrentRating="2" MaxRating="5"
                                            EmptyStarCssClass="emptypng" FilledStarCssClass="smileypng"
                                            StarCssClass="smileypng" WaitingStarCssClass="donesmileypng" />
                                         </div>
                                    </div>
                                </div>
                            <div>
                                <asp:TextBox runat="server" TextMode="MultiLine" Rows="5" PlaceHolder="Nhận xét gì đó..."/>
                            </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>

                    <div class="btn">
                        <asp:Button ID="btnGui" OnClick="btnGui_Click" Text="GỬI" runat="server" />
                    </div>
                </div>
            </div>

             