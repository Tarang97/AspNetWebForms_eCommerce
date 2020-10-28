<%@ Page Title="Site Map" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="Sitemap.aspx.cs" Inherits="Sitemap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="main-container col1-layout">
        <div class="main container">
            <div class="col-main">
                <div class="cart wow">
                    <div class="page-title">
                        <h2>Sitemap</h2>
                    </div>
                    <div class="row content-row">
                        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-4">
                            <ul class="simple-list arrow-list bold-list">
                                <li><a href="Index.aspx">Home</a></li>
                                <li><a href="Products.aspx?cat=1">Men</a></li>
                                <li><a href="Products.aspx?cat=4">Women</a></li>
                                <li><a href="Products.aspx?cat=5">Clones</a></li>
                                <li><a href="Products.aspx?cat=6">Audio</a></li>
                                <li><a href="Products.aspx?cat=7">Accessories</a></li>
                                <li><a href="ShoppingCart.aspx">Shopping Cart</a></li>
                                <li><a href="UserProfile.aspx">My Account</a>
                                    <ul>
                                        <li><a href="UserProfile.aspx">User Profile</a></li>
                                        <li><a href="MyOrders.aspx">Your Orders</a></li>
                                        <li><a href="Wishlist.aspx">Your Wishlist</a></li>
                                        <li><a href="Reviews.aspx">Your Reviews</a></li>
                                    </ul>
                                </li>
                                <li><a href="javascript:void(0)">Customer Service</a>
                                    <ul>
                                        <li><a href="Contact.aspx">Contact Us</a></li>
                                        <li><a href="FAQs.aspx">Help & FAQs</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-4">
                            <ul class="simple-list arrow-list bold-list">
                                <li><a href="javascript:void(0)">Information</a>
                                    <ul>
                                        <li><a href="About.aspx">About Us</a></li>
                                        <li><a href="ShippingOpt.aspx">Shipping Policy</a></li>
                                        <li><a href="ReturnPolicy.aspx">Return Policy</a></li>
                                        <li><a href="Privacy.aspx">Privacy Policy</a></li>
                                        <li><a href="Terms-Condition.aspx">Terms &amp; Conditions</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                            <img class="img-responsive" class="img-responsive animate scale" src="images/large-icon-sitemap.png" alt="">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

