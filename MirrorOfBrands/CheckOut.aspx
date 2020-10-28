<%@ Page Title="CheckOut" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="CheckOut" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hdCart" runat="server" />
    <asp:HiddenField ID="hdCartAmount" runat="server" />
    <asp:HiddenField ID="hdCartDiscount" runat="server" />
    <asp:HiddenField ID="hdTotalPayed" runat="server" />
    <asp:HiddenField ID="hfPurchaseID" runat="server" />
    <asp:HiddenField ID="hfProductID" runat="server" />
    <asp:HiddenField ID="hfDlvy" runat="server" />
    <!-- main-container -->
    <div class="main-container col1-layout" runat="server" id="divCheckOut">
        <div class="main container">
            <div class="row">
                <section class="col-sm-12 col-xs-12">
                    <div class="col-main">
                        <div class="page-title">
                            <h1>Checkout</h1>
                        </div>
                        <div class="page-content checkout-page">
                            <h3 class="checkout-sep">1. Shipping Information</h3>
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Size="Large"></asp:Label>
                            <div class="box-border">
                                <ul>
                                    <li class="row">
                                        <div class="col-sm-6">
                                            <label>Name <span class="required">*</span></label>
                                            <asp:TextBox ID="txtName" runat="server" CssClass="input form-control"></asp:TextBox><br />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtName" FilterType="UppercaseLetters, LowercaseLetters, Custom" ValidChars=" " />
                                        </div>
                                        <!--/ [col] -->

                                        <div class="col-sm-6">
                                            <label>Mobile/Phone No. <span class="required">*</span></label>
                                            <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="input form-control"></asp:TextBox><br />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMobileNumber" FilterType="Numbers" />
                                        </div>
                                        <!--/ [col] -->
                                    </li>
                                    <!--/ .row -->

                                    <li class="row">
                                        <div class="col-xs-12">
                                            <label>Address <span class="required">*</span></label>
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="input form-control"></asp:TextBox><br />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtAddress" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom" ValidChars="-/,. " />
                                        </div>
                                        <!--/ [col] -->
                                    </li>
                                    <!--/ .row -->

                                    <li class="row">
                                        <div class="col-sm-6">
                                            <label>City <span class="required">*</span></label>
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="input form-control"></asp:TextBox><br />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtCity" FilterType="UppercaseLetters, LowercaseLetters, Custom" ValidChars=" " />
                                        </div>
                                        <!--/ [col] -->

                                        <div class="col-sm-6">
                                            <label>State/Province <span class="required">*</span></label>
                                            <asp:TextBox ID="txtState" runat="server" CssClass="input form-control"></asp:TextBox><br />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtState" FilterType="UppercaseLetters, LowercaseLetters, Custom" ValidChars=" " />
                                        </div>
                                        <!--/ [col] -->

                                    </li>
                                    <!--/ .row -->

                                    <li class="row">
                                        <div class="col-sm-6">
                                            <label>Zip/Postal Code <span class="required">*</span></label>
                                            <asp:TextBox ID="txtPinCode" runat="server" CssClass="input form-control"></asp:TextBox><br />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtPinCode" FilterType="Numbers" />
                                        </div>
                                        <!--/ [col] -->

                                    </li>
                                    <!--/ .row -->
                                </ul>
                            </div>

                            <h3 class="checkout-sep">2. Order Review</h3>
                            <div class="box-border">
                                <div class="table-responsive">
                                    <div class="order-detail-content">
                                        <table class="table table-bordered jtv-cart-summary">
                                            <thead>
                                                <tr>
                                                    <th class="cart_product">Product</th>
                                                    <th>Description</th>
                                                    <th>Avail.</th>
                                                    <th>Quantity</th>
                                                    <th>Unit price</th>
                                                    <th>Total</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptrReview" runat="server" OnItemDataBound="rptrReview_ItemDataBound">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td class="cart_product"><a href="ProductDetails?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>" target="_blank">
                                                                <img class="img-responsive" src="images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extension") %>" alt="<%# Eval("Name") %>" onerror="this.src='images/ProductImages/noimage.jpg'"></a></td>
                                                            <td class="cart_description">
                                                                <p class="product-name" title="<%# Eval("PName") %>"><%# Eval("PName") %></p>
                                                                <small style="text-transform: uppercase;">Size/Color/Storage : <%# Eval("SizeName") %></small><br>
                                                            </td>
                                                            <td class="cart_avail"><span class="label label-success">In stock</span></td>
                                                            <td>
                                                                <center><span><%# Eval("Quantity") %></span></center>
                                                            </td>
                                                            <td class="price"><span>&#8377;<%# Eval("PSelPrice") %></span>&nbsp;<span style="text-decoration: line-through;">&#8377;<%# Eval("PPrice") %></span></td>

                                                            <td class="price"><span>&#8377;<%# Eval("PSelPrice") %></span></td>
                                                        </tr>
                                                        <asp:HiddenField ID="hfCart" runat="server" Value='<%# Eval("CartID") %>' />
                                                        <asp:HiddenField ID="hfPID" runat="server" Value='<%# Eval("PID") %>' />
                                                        <asp:HiddenField ID="hfSID" runat="server" Value='<%# Eval("SizeName") %>' />
                                                        <asp:HiddenField ID="hfQty" runat="server" Value='<%# Eval("Quantity") %>' />
                                                        <asp:HiddenField ID="hfDlvy" runat="server" Value='<%# Eval("DeliveryOpt") %>' />
                                                        <asp:HiddenField ID="hfCA" runat="server" Value='999' />
                                                        <asp:HiddenField ID="hfCD" runat="server" Value='999' />
                                                        <asp:HiddenField ID="hfTP" runat="server" Value='999' />
                                                        <asp:HiddenField ID="hfPT" runat="server" Value='PayType' />
                                                        <asp:HiddenField ID="hfPS" runat="server" Value='PayS' />
                                                        <asp:HiddenField ID="hfOS" runat="server" Value='Received' />
                                                        <asp:HiddenField ID="hfName" runat="server" Value="XYZ" />
                                                        <asp:HiddenField ID="hfAddr" runat="server" Value='XYZ' />
                                                        <asp:HiddenField ID="hfPC" runat="server" Value='123456' />
                                                        <asp:HiddenField ID="hfMob" runat="server" Value='1234567890' />
                                                        <asp:HiddenField ID="hfCity" runat="server" Value='XYZ' />
                                                        <asp:HiddenField ID="hfState" runat="server" Value='XYZ' />
                                                        <asp:HiddenField ID="hfCC" runat="server" Value='XYZ' />
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <td colspan="2" rowspan="2"></td>
                                                    <td colspan="3">Total products (tax incl.)</td>
                                                    <td colspan="2" id="tdCartTotal" runat="server"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3"><strong>Total Discount</strong></td>
                                                    <td colspan="2"><strong style="color: #14cda8;" id="tdDiscount" runat="server"></strong></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2"></td>
                                                    <td colspan="3"><strong>Delivery Charge</strong></td>
                                                    <td colspan="2"><strong id="strongDlvy" runat="server"></strong></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2"></td>
                                                    <td colspan="3"><strong>Total</strong></td>
                                                    <td colspan="2"><strong id="strongTotal" runat="server"></strong></td>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                                <div class="cart_navigation">
                                    <label>Coupon Code</label>
                                    <asp:TextBox ID="txtCoupon" CssClass="input-text required-entry" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnCouponApply" Style="display: inline-block; font-size: 14px; letter-spacing: 0.5px; line-height: normal; padding: 8px 16px; border: 2px solid #6987ab; font-weight: 700; background-color: #ecf4fc; color: #6987ab; border-radius: 50px; text-transform: uppercase;"
                                        runat="server" Text="Apply" OnClick="btnCouponApply_Click" />
                                </div>
                                <asp:Label ID="lblCouponSuccess" runat="server"></asp:Label><br />
                                <asp:Label ID="lblMaxDiscount" runat="server"></asp:Label>
                            </div>

                            <h3 class="checkout-sep">3. Select Courier Company</h3>
                            <div class="box-border">
                                <asp:RadioButtonList ID="rblCourier" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0">DTDC</asp:ListItem>
                                    <asp:ListItem Value="1">FedEx</asp:ListItem>
                                    <asp:ListItem Value="2">BlueDart</asp:ListItem>
                                </asp:RadioButtonList>
                                <style type="text/css">
                                    input[type=radio] {
                                        margin-left: 15px;
                                        margin-right: 5px;
                                    }
                                </style>
                            </div>

                            <h3 class="checkout-sep">4. Payment Information</h3>
                            <div class="box-border">
                                <ul class="nav nav-tabs">
                                    <li class="active"><a data-toggle="tab" href="#wallets">Wallets</a></li>
                                    <li><a data-toggle="tab" href="#cod">Cash On Delivery</a></li>
                                </ul>

                                <div class="tab-content">
                                    <div id="wallets" class="tab-pane fade in active">
                                        <h3>Pay with Paytm</h3>
                                        <p>India's No. 1 UPI Payment Gateway.</p>
                                        <asp:Button ID="btnPaytm" runat="server" Text="Pay Now" OnClick="btnPaytm_Click" CssClass="button btn-cart btn-round-lg btn-lg pull-left" />
                                    </div>
                                    <div id="cod" class="tab-pane fade">
                                        <h3>Cash On Delivery</h3>
                                        <asp:Button ID="btnCod" CssClass="button btn-cart btn-round-lg btn-lg pull-left" runat="server" Text="Pay Now" OnClick="btnCod_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <!--End main-container -->
</asp:Content>

