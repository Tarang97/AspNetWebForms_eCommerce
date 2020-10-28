<%@ Page Title="Your Orders" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="MyOrders.aspx.cs" Inherits="MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="main-container col1-layout">
        <div class="main container">
            <div class="col-main">
                <div class="shopping-cart-inner">
                    <div class="page-title">
                        <h2>My Orders</h2>
                    </div>
                    <asp:Label ID="lblNote" runat="server" Text="If you want to Cancel your Order, then Contact Us at: +(91)-9725201308 and provide your Order Details for Cancellation." ForeColor="Red" Font-Size="Large"></asp:Label>
                    <div class="page-content">
                        <div class="heading-counter warning"><strong id="spanOH" runat="server"></strong></div>
                        <div class="table-responsive">
                            <div class="order-detail-content" id="tableOrder" runat="server">
                                <table class="table table-bordered jtv-cart-summary">
                                    <thead>
                                        <tr>
                                            <th class="cart_product">Product</th>
                                            <th>Description</th>
                                            <th>Name</th>
                                            <th style="width: 25%;">Delieverd To:</th>
                                            <th>Mobile No.</th>
                                            <th>Payment Type</th>
                                            <th>Order Status</th>
                                            <th>Unit Price</th>
                                            <%--<th>Total Amt.</th>--%>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptrOrderHist" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="cart_product"><a href='ProductDetails?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>' target="_blank">
                                                        <img class="img-responsive" src="images/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extension") %>" alt="<%# Eval("ImageName") %>" onerror="this.src='images/ProductImages/noimage.jpg'"></a></td>
                                                    <td class="cart_description">
                                                        <p class="product-name" title="<%# Eval("PName") %>"><%# Eval("PName") %></p>
                                                        <small style="text-transform: uppercase;">Size : <%# Eval("SizeName") %></small><br />
                                                        <small style="text-transform: uppercase;">Quantity: <%# Eval("Quantity") %></small><br />
                                                        <small style="text-transform: uppercase;">Date: <%# Eval("DateOfOrder") %></small><br />
                                                        <small style="text-transform: uppercase;">Delivery Chrg: <%# Eval("DeliveryOpt") %></small>
                                                    </td>
                                                    <td><asp:Label ID="PurchName" runat="server" Text='<%# Eval("Namee") %>'></asp:Label></td>
                                                    <td><asp:Label ID="PurchAddDetails" runat="server" Text='<%# Eval("Address")+", "+Eval("City")+", "+Eval("State")+", "+Eval("PinCode") %>'></asp:Label></td>
                                                    <td><asp:Label ID="MobileNo" runat="server" Text='<%# Eval("MobileNo") %>'></asp:Label></td>
                                                    <td><asp:Label ID="PayType" runat="server" Text='<%# Eval("PaymentType") %>'></asp:Label></td>
                                                    <td><asp:Label ID="OrderSt" runat="server" Text='<%# Eval("OrderStatus") %>'></asp:Label></td>
                                                    <td class="price"><span><%# Eval("PSelPrice") %> x <%# Eval("Quantity") %> = &#8377;<%# string.Format("{0}",Convert.ToInt64(Eval("PSelPrice"))*Convert.ToInt64(Eval("Quantity"))) %></span></td>
                                                    <%--<td class="price">&#8377;<%# Eval("TotalPayed") %></td>--%>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                                <div class="cart_navigation">
                                    <asp:Button ID="btnBack" CssClass="btn btn-default" BorderStyle="None" runat="server" Text="Go Back" PostBackUrl="~/UserProfile.aspx" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

