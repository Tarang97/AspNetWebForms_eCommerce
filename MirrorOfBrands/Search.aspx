<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Breadcrumbs -->
    <div class="breadcrumbs">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <ul>
                        <li class="home"><a href="Index.aspx" title="Go to Home Page">Home</a> <span>/</span> </li>
                        <li><strong>Search</strong> </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Main Container -->
    <section class="main-container col1-layout">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 col-xs-12">
                    <article class="col-main">
                        <h2 class="page-heading"><span class="page-heading-title" id="spanResult" runat="server"></span> </h2>
                        <h4><asp:Label ID="lblNoFound" runat="server" ForeColor="Red"></asp:Label></h4>
                        <div class="category-products">
                            <ul class="products-grid">
                                <asp:Repeater ID="rptrProducts" runat="server">
                                    <ItemTemplate>
                                        <li class="item col-lg-3 col-md-4 col-sm-4 col-xs-6">
                                            <div class="item-inner">
                                                <div class="item-img">
                                                    <div class="item-img-info">
                                                        <a class="product-image" title="<%# Eval("PName") %>" href="ProductDetails.aspx?mob=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>">
                                                            <img class="img-responsive" alt="<%# Eval("ImageName") %>" src="images/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extension") %>" onerror="this.src='images/ProductImages/noimage.jpg'">
                                                        </a>
                                                        <div class="new-label new-top-left">
                                                            <%# ((string)Eval("ProductOption")=="New")?"New":"" %>
                                                            <%# ((string)Eval("ProductOption")=="Sale")?"Sale":"" %>
                                                            <%# ((string)Eval("ProductOption")=="Featured")?Eval("PDiscount")+"%":"" %>
                                                            <%# ((string)Eval("ProductOption")=="None")?Eval("PDiscount")+"%":"" %>
                                                        </div>
                                                        <div class="action text-center" style="margin-left:50px;"><a href="ProductDetails.aspx?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>" title="Add to cart"><i class="fa fa-shopping-cart"></i></a><asp:LinkButton ID="lbWishlist" ToolTip="Add to Wishlist" OnClick="lbWishlist_Click" CommandName="AddtoWishlist" CommandArgument='<%# Eval("PID") %>' runat="server"><i class="fa fa-heart-o"></i></asp:LinkButton></div>
                                                        <!-- Compare, QuickView, WishList -->
                                                    </div>
                                                </div>
                                                <div class="item-info">
                                                    <div class="info-inner">
                                                        <div class="item-title"><a title="Product Title Here" href="ProductDetails.aspx?mob=<%# Eval("PID") %>"><%# Eval("PName") %></a></div>
                                                        <div class="item-content">
                                                            <div class="item-price">
                                                                <div class="price-box">
                                                                    <span class="regular-price"><span class="price" style="text-decoration: line-through;">&#8377; <%# Eval("PPrice") %></span>&nbsp; <span class="price">&#8377; <%# Eval("PSelPrice") %></span> <span style="color: red;"><%# Eval("PDiscount") %> (-&#8377;<%#Eval("DiscAmount") %>)</span></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="toolbar" id="divPagination" runat="server">
                            <div class="row">
                                <div class="col-sm-6 text-left">
                                    <ul class="pagination">
                                        <li><asp:LinkButton ID="lb1" runat="server" OnClick="lb1_Click">|&lt;</asp:LinkButton></li>
                                        <li><asp:LinkButton ID="lb2" runat="server" OnClick="lb2_Click">&lt;</asp:LinkButton></li>
                                        <li><asp:LinkButton ID="lb3" runat="server" OnClick="lb3_Click">&gt;</asp:LinkButton></li>
                                        <li><asp:LinkButton ID="lb4" runat="server" OnClick="lb4_Click">&gt;|</asp:LinkButton></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </article>
                    <!--	///*///======    End article  ========= //*/// -->
                </div>
            </div>
        </div>
    </section>
    <!-- Main Container End -->
</asp:Content>

