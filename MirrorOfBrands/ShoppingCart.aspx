<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="main-container col1-layout">
        <div class="main container">
            <div class="col-main">
                <div class="shopping-cart-inner">
                    <div class="page-title">
                        <h2>Shopping Cart Summary</h2>
                    </div>
                    <div class="page-content">
                        <div class="heading-counter warning"><strong>Your shopping cart contains <span runat="server" id="spanNoItems"></span></strong> </div>
                        <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                        <div class=" table-responsive">
                            <div class="order-detail-content">
                                <table class="table table-bordered jtv-cart-summary">
                                    <thead runat="server" id="theadPriceDetails">
                                        <tr>
                                            <th class="cart_product">Product</th>
                                            <th>Description</th>
                                            <th>Avail.</th>
                                            <th>Quantity</th>
                                            <th>Unit price</th>
                                            <th>Total</th>
                                            <th class="action"><i class="fa fa-trash-o"></i></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptrCartProducts" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="cart_product"><a href="ProductDetails.aspx?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>" target="_blank">
                                                        <img class="img-responsive" src="images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extension") %>" alt="<%# Eval("Name") %>" onerror="this.src='images/ProductImages/noimage.jpg'"></a></td>
                                                    <td class="cart_description">
                                                        <p class="product-name" title="<%# Eval("PName") %>"><%# Eval("PName") %></p>
                                                        <small style="text-transform: uppercase;">Size/Color/Storage : <%# Eval("SizeName") %></small><br />
                                                        <small style="text-transform: uppercase;">Delivery Chrg: &#8377;<%# Eval("DeliveryOpt") %></small>
                                                    </td>
                                                    <td class="cart_avail"><span class="label label-success">In stock</span></td>
                                                    <td><center><span><%# Eval("Quantity") %></span></center></td>
                                                    <td class="price"><span>&#8377;<%# Eval("PSelPrice") %></span>&nbsp;<span style="text-decoration: line-through;">&#8377;<%# Eval("PPrice") %></span></td>
                                                    
                                                    <td class="price"><span>&#8377;<%# Eval("PSelPrice") %></span></td>
                                                    <td class="action">
                                                        <asp:LinkButton ID="lbDelete" CommandName="DeleteCart" CommandArgument='<%# Eval("UniqueID") %>' runat="server" OnClick="lbDelete_Click"><i class="fa fa-trash-o fa-lg"></i></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                    <tfoot runat="server" id="tfootPriceDetails">
                                        <tr>
                                            <td colspan="2" rowspan="2"></td>
                                            <td colspan="3">Total price (tax incl.)</td>
                                            <td colspan="2"><strong id="tdCartTotal" runat="server"></strong></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"><strong>Total Discount</strong></td>
                                            <td colspan="2"><strong style="color: #14cda8;" id="tdDiscount" runat="server"></strong></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"></td>
                                            <td colspan="3"><strong>Delivery Charges</strong></td>
                                            <td colspan="2"><strong id="strongDlvy" runat="server"></strong></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"></td>
                                            <td colspan="3"><strong>Total</strong></td>
                                            <td colspan="2"><strong id="strongTotal" runat="server"></strong></td>
                                        </tr>
                                    </tfoot>
                                </table>
                                <div class="cart_navigation" runat="server" id="divCheckoutBtn">
                                    <asp:Button ID="btnCheckOut" CssClass="button btn-cart btn-round-lg btn-lg" runat="server" Text="Proceed to CheckOut" OnClick="btnCheckOut_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

