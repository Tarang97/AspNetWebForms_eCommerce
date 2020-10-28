<%@ Page Title="Your Wishlist" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="Wishlist.aspx.cs" Inherits="Wishlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/custom/userprofile.css" rel="stylesheet" />
    <div class="container">
        <div class="row profile">
            <div class="col-md-3">
                <div class="profile-sidebar">
                    <!-- SIDEBAR USER TITLE -->
                    <div class="profile-usertitle">
                        <div class="profile-usertitle-name">
                            <span class="hidden-xs"></span>
                        </div>
                        <div class="profile-usertitle-job">
                        </div>
                    </div>
                    <!-- END SIDEBAR USER TITLE -->
                    <!-- SIDEBAR MENU -->
                    <div class="profile-usermenu">
                        <ul class="nav">
                            <li>
                                <a href="UserProfile.aspx">
                                    <i class="glyphicon glyphicon-home"></i>
                                    <span class="hidden-xs">My Profile</span> </a>
                            </li>
                            <li>
                                <a href="MyOrders.aspx">
                                    <i class="glyphicon glyphicon-ok"></i>
                                    <span class="hidden-xs">Your Orders </span><span class="label pull-right" id="spanOCount" runat="server"></span></a>
                            </li>
                            <li class="active">
                                <a href="Wishlist.aspx">
                                    <i class="glyphicon glyphicon-flag"></i>
                                    <span class="hidden-xs">My Wishlist </span><span class="label pull-right" id="spanWCount" runat="server"></span></a>
                            </li>
                        </ul>
                    </div>
                    <!-- END MENU -->
                </div>
            </div>

            <div class="main-container col2-right-layout">
                <div class="main container">
                    <div class="row">
                        <section class="col-sm-9 wow">
                            <div class="col-main">
                                <div class="my-account">
                                    <div class="page-title">
                                        <h2>My Wishlist</h2>
                                    </div>
                                    <br />
                                    <asp:Label ID="lblEmpty" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                                    <div class="my-wishlist" id="fieldsetWishlist" runat="server">
                                        <div class="table-responsive">
                                            <fieldset>
                                                <table class="wishlist-table data-table">
                                                    <thead>
                                                        <tr class="first last">
                                                            <th class="customer-wishlist-item-image">Product</th>
                                                            <th class="customer-wishlist-item-info">Description</th>
                                                            <th class="customer-wishlist-item-quantity">Discount</th>
                                                            <th class="customer-wishlist-item-price">Price</th>
                                                            <th class="customer-wishlist-item-remove"><i class="fa fa-trash-o"></i></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="rptrWishlist" runat="server">
                                                            <ItemTemplate>
                                                                <tr id="item_31" class="first odd">
                                                                    <td class="wishlist-cell0 customer-wishlist-item-image"><a title="<%# Eval("PName") %>" href='ProductDetails.aspx?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>' class="product-image">
                                                                        <img class="img-responsive" width="150" alt="Product Title Here" src="images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extension") %>" onerror="this.src='images/ProductImages/noimage.jpg'">
                                                                    </a></td>
                                                                    <td class="wishlist-cell1 customer-wishlist-item-info">
                                                                        <h3 class="product-name"><a title="<%# Eval("PName") %>" href='ProductDetails.aspx?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>'><%# Eval("PName") %></a></h3>
                                                                        <div class="description std">
                                                                            <div class="inner"><%# Eval("PDescription") %></div>
                                                                        </div>
                                                                    </td>
                                                                    <td data-rwd-label="Quantity" class="wishlist-cell2 customer-wishlist-item-quantity">
                                                                        <div class="cart-cell">
                                                                            <div class="add-to-cart-alt">
                                                                                <p style="color: red;"><%# Eval("PDiscount") %>% Off</p>
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                    <td data-rwd-label="Price" class="wishlist-cell3 customer-wishlist-item-price">
                                                                        <div class="cart-cell">
                                                                            <div class="price-box"><span id="product-price-39" class="regular-price"><span class="price">&#8377;<%#Eval("PSelPrice") %></span> </span></div>
                                                                        </div>
                                                                    </td>
                                                                    <td class="wishlist-cell5 customer-wishlist-item-remove last">
                                                                        <asp:LinkButton ID="lblDelete" CommandName="DeleteWishlist" CommandArgument='<%# Eval("UniqueID") %>' CssClass="remove-item" runat="server" OnClick="lblDelete_Click"><span><span></span></span></asp:LinkButton></td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

