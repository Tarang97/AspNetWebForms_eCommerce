<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="FeaturedProducts.aspx.cs" Inherits="ProductFeatured" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Breadcrumbs -->
    <div class="breadcrumbs" id="bdc" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <ul>
                        <li class="home"><a href="Index.aspx" title="Go to Home Page">Home</a> <span>/</span> </li>
                        <li><strong><asp:Label ID="lblCatNamebc" runat="server" ForeColor="#273F5B" Font-Bold="True" Font-Size="13px"></asp:Label></strong> </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumbs End -->
    <!-- Main Container -->
    <section class="main-container col2-left-layout">
        <div class="container">
            <div class="row">
                <div class="col-sm-8 col-sm-push-4 col-md-9 col-md-push-3">
                    <article class="col-main">
                        <h2 class="page-heading"><span class="page-heading-title"><asp:Label ID="lblCatName" runat="server"></asp:Label></span> </h2>
                        <h4><asp:Label ID="lblBrandName" runat="server"></asp:Label></h4>
                        <h5><asp:Label ID="lblAccessoryName" runat="server"></asp:Label></h5>
                        <asp:Label ID="lblNone" runat="server" Font-Size="Larger" Font-Bold="True"></asp:Label>
                        <div class="category-products">
                            <ul class="products-grid">
                                <asp:Repeater ID="rptrProducts" runat="server">
                                    <ItemTemplate>
                                        <li class="item col-lg-4 col-md-4 col-sm-6 col-xs-6">
                                            <div class="item-inner">
                                                <div class="item-img">
                                                    <div class="item-img-info">
                                                        <a class="product-image" href='ProductDetails.aspx?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>'>
                                                            <img class="img-responsive" alt="<%# Eval("ImageName") %>" src="images/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extension") %>" onerror="this.src='images/ProductImages/noimage.jpg'">
                                                        </a>
                                                        <div class="new-label new-top-left">
                                                            <%# ((string)Eval("ProductOption")=="New")?"New":"" %>
                                                            <%# ((string)Eval("ProductOption")=="Sale")?"Sale":"" %>
                                                            <%# ((string)Eval("ProductOption")=="Featured")?Eval("PDiscount")+"%":"" %>
                                                            <%# ((string)Eval("ProductOption")=="None")?Eval("PDiscount")+"%":"" %>
                                                        </div>
                                                        <div class="action text-center" style="margin-left: 50px;">
                                                            <a href='ProductDetails.aspx?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>' title="Add to cart"><i class="fa fa-shopping-cart"></i></a>
                                                            <asp:LinkButton ID="lbWishlist" ToolTip="Add to Wishlist" OnClick="lbWishlist_Click" CommandName="AddtoWishlist" CommandArgument='<%# Eval("PID") %>' runat="server"><i class="fa fa-heart-o"></i></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="item-info">
                                                    <div class="info-inner">
                                                        <div class="item-title"><a title="<%# Eval("PName") %>" href="ProductDetails.aspx?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>"><%# Eval("PName") %></a></div>
                                                        <div class="item-content">
                                                            <div class="item-price">
                                                                <div class="price-box"><span class="regular-price"><span class="price" style="text-decoration: line-through;">&#8377; <%# Eval("PPrice") %></span>&nbsp; <span class="price">&#8377; <%# Eval("PSelPrice") %></span> <span style="color: red;"><%# Eval("PDiscount") %>% Off (-&#8377;<%#Eval("DiscAmount") %>)</span></span></div>
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
                </div>
                <div class="sidebar col-sm-4 col-md-3 col-xs-12 col-md-pull-9 col-sm-pull-8" id="divPrice" runat="server">
                    <aside class="sidebar">
                        <div class="block block-layered-nav">
                            <div class="block-title">Shop By</div>
                            <div class="block-content">
                                <p class="block-subtitle">Shopping Options</p>
                                <dl id="narrow-by-list">
                                    <dt class="odd">Price</dt>
                                    <dd class="odd">
                                        <ol>
                                            <li><asp:LinkButton ID="lbAllProducts" runat="server" OnClick="lbAllProducts_Click">All Products</asp:LinkButton><asp:Label ID="lblAllPrdCount" runat="server"></asp:Label></li>
                                            <li><asp:LinkButton ID="lbPrice1" runat="server" OnClick="lbPrice1_Click"><span>&#8377;399</span> - <span class="price">&#8377;1000</span></asp:LinkButton><asp:Label ID="lblProductCount1" runat="server"></asp:Label></li>
                                            <li><asp:LinkButton ID="lbPrice2" runat="server" OnClick="lbPrice2_Click"><span>&#8377;1000</span> - <span class="price">&#8377;3000</span></asp:LinkButton><asp:Label ID="lblProductCount2" runat="server"></asp:Label></li>
                                            <li><asp:LinkButton ID="lbPrice3" runat="server" OnClick="lbPrice3_Click"><span>&#8377;3000</span> - <span class="price">&#8377;5000</span></asp:LinkButton><asp:Label ID="lblProductCount3" runat="server"></asp:Label></li>
                                            <li><asp:LinkButton ID="lbPrice4" runat="server" OnClick="lbPrice4_Click"><span>&#8377;5000</span> - <span class="price">&#8377;10,000</span></asp:LinkButton><asp:Label ID="lblProductCount4" runat="server"></asp:Label></li>
                                            <li runat="server"><asp:LinkButton ID="lbPrice5" runat="server" OnClick="lbPrice5_Click"><span>&#8377;10,000</span> and above</asp:LinkButton><asp:Label ID="lblProductCount5" runat="server"></asp:Label></li>
                                        </ol>
                                    </dd>
                                </dl>
                            </div>
                        </div>
                    </aside>
                </div>
            </div>
        </div>
    </section>
    <!-- /Main Container -->
</asp:Content>

