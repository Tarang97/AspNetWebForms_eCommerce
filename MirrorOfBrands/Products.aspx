<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                    <div class="category-description std" id="imgSlider" runat="server">
                        <div class="slider-items-products">
                            <div id="category-desc-slider" class="product-flexslider hidden-buttons">
                                <div class="slider-items slider-width-col1 owl-carousel owl-theme">

                                    <!-- Item -->
                                    <div class="item">
                                        <asp:Image ID="Image1" CssClass="img-responsive" runat="server" />
                                        <div class="cat-img-title cat-bg cat-box">
                                            <div class="small-tag"><asp:Label ID="lblImg1Txt1" runat="server"></asp:Label></div>
                                            <h2 class="cat-heading"><asp:Label ID="lblImg1Txt2" runat="server"></asp:Label></h2>
                                            <p><asp:Label ID="lblImg1Txt3" runat="server"></asp:Label></p>
                                        </div>
                                    </div>
                                    <!-- End Item -->

                                    <!-- Item -->
                                    <div class="item">
                                        <asp:Image ID="Image2" CssClass="img-responsive" runat="server" />
                                        <div class="cat-img-title cat-bg cat-box">
                                            <div class="small-tag"><asp:Label ID="lblImg2Txt1" runat="server"></asp:Label></div>
                                            <h2 class="cat-heading"><asp:Label ID="lblImg2Txt2" runat="server"></asp:Label></h2>
                                            <p><asp:Label ID="lblImg2Txt3" runat="server"></asp:Label></p>
                                        </div>
                                    </div>
                                    <!-- End Item -->

                                    <!-- Item -->
                                    <div class="item">
                                        <asp:Image ID="Image3" CssClass="img-responsive" runat="server" />
                                        <div class="cat-img-title cat-bg cat-box">
                                            <div class="small-tag"><asp:Label ID="lblImg3Txt1" runat="server"></asp:Label></div>
                                            <h2 class="cat-heading"><asp:Label ID="lblImg3Txt2" runat="server"></asp:Label></h2>
                                            <p><asp:Label ID="lblImg3Txt3" runat="server"></asp:Label></p>
                                        </div>
                                    </div>
                                    <!-- End Item -->
                                </div>
                            </div>
                        </div>
                    </div>
                    <article class="col-main">
                        <h2 class="page-heading"><span class="page-heading-title"><asp:Label ID="lblCatName" runat="server"></asp:Label></span> </h2>
                        <h4><asp:Label ID="lblBrandName" runat="server"></asp:Label></h4> <h5><asp:Label ID="lblAccessoryName" runat="server"></asp:Label></h5>
                        <asp:Label ID="lblNone" runat="server" Font-Size="Larger" Font-Bold="True"></asp:Label>
                        <div class="category-products">
                            <ul class="products-grid">
                                <asp:Repeater ID="rptrProducts" runat="server">
                                    <ItemTemplate>
                                        <li class="item col-lg-4 col-md-4 col-sm-6 col-xs-6">
                                            <div class="item-inner">
                                                <div class="item-img">
                                                    <div class="item-img-info">
                                                        <a class="product-image" href="ProductDetails.aspx?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>">
                                                            <img class="img-responsive" alt="<%# Eval("PName") %>" src="images/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extension") %>" onerror="this.src='images/ProductImages/noimage.jpg'">
                                                        </a>
                                                        <div class="new-label new-top-left">
                                                            <%# ((string)Eval("ProductOption")=="New")?"New":"" %>
                                                            <%# ((string)Eval("ProductOption")=="Sale")?"Sale":"" %>
                                                            <%# ((string)Eval("ProductOption")=="Featured")?Eval("PDiscount")+"%":"" %>
                                                            <%# ((string)Eval("ProductOption")=="None")?Eval("PDiscount")+"%":"" %>
                                                        </div>
                                                        <div class="action text-center" style="margin-left:50px;"><a href='ProductDetails.aspx?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>' title="Add to cart"><i class="fa fa-shopping-cart"></i></a><asp:LinkButton ID="lbWishlist" ToolTip="Add to Wishlist" OnClick="lbWishlist_Click" CommandName="AddtoWishlist" CommandArgument='<%# Eval("PID") %>' runat="server"><i class="fa fa-heart-o"></i></asp:LinkButton></div>
                                                    </div>
                                                </div>
                                                <div class="item-info">
                                                    <div class="info-inner">
                                                        <div class="item-title"><a title="<%# Eval("PName") %>" href="ProductDetails.aspx?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>"><%# Eval("PName") %></a></div>
                                                        <div class="item-content">
                                                            <div class="item-price">
                                                                <div class="price-box"><span class="regular-price"><span class="price" style="text-decoration: line-through;">₹ <%# Eval("PPrice") %></span>&nbsp; <span class="price">₹ <%# Eval("PSelPrice") %></span> <span style="color: red;"><%# Eval("PDiscount") %>% Off (-₹<%#Eval("DiscAmount") %>)</span></span></div>
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
                <div class="sidebar col-sm-4 col-md-3 col-xs-12 col-md-pull-9 col-sm-pull-8" id="filters" runat="server">
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
                                            <li><asp:LinkButton ID="lbPrice1" runat="server" OnClick="lbPrice1_Click"><span>₹399</span> - <span class="price">₹1000</span></asp:LinkButton><asp:Label ID="lblProductCount1" runat="server"></asp:Label></li>
                                            <li><asp:LinkButton ID="lbPrice2" runat="server" OnClick="lbPrice2_Click"><span>₹1000</span> - <span class="price">₹3000</span></asp:LinkButton><asp:Label ID="lblProductCount2" runat="server"></asp:Label></li>
                                            <li><asp:LinkButton ID="lbPrice3" runat="server" OnClick="lbPrice3_Click"><span>₹3000</span> - <span class="price">₹5000</span></asp:LinkButton><asp:Label ID="lblProductCount3" runat="server"></asp:Label></li>
                                            <li><asp:LinkButton ID="lbPrice4" runat="server" OnClick="lbPrice4_Click"><span>₹5000</span> - <span class="price">₹10,000</span></asp:LinkButton><asp:Label ID="lblProductCount4" runat="server"></asp:Label></li>
                                            <li runat="server" id="liPC5"><asp:LinkButton ID="lbPrice5" runat="server" OnClick="lbPrice5_Click"><span>₹10,000</span> and above</asp:LinkButton><asp:Label ID="lblProductCount5" runat="server"></asp:Label></li>
                                        </ol>
                                    </dd>
                                    <dt class="odd" id="dttags" runat="server">Tags</dt>
                                    <dd class="odd" id="ddtags" runat="server">
                                        <ol>
                                            <li><asp:Label ID="Tags" runat="server"></asp:Label><asp:Button ID="btnClose" runat="server" Text="&times;" CssClass="btn btn-link pull-right" OnClick="btnClose_Click" /></li>
                                        </ol>
                                    </dd>
                                    <dt class="even">Brands</dt>
                                    <dd class="even">
                                        <ol class="bag-material">
                                            <li>
                                                <asp:CheckBoxList ID="cblBrands" OnSelectedIndexChanged="cblBrands_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:CheckBoxList>
                                            </li>
                                            <li><asp:HiddenField ID="hfBrand" runat="server" /></li>
                                        </ol>
                                    </dd>
                                    <dt class="odd" id="dtMAccess" runat="server">Accessories</dt>
                                    <dd class="odd" id="ddMAccess" runat="server">
                                        <ol>
                                            <asp:Repeater ID="rptrAccessories" runat="server">
                                                <ItemTemplate>
                                                    <li><asp:LinkButton ID="lbAccessory" runat="server" OnClick="lbAccessory_Click" CommandName="Accessories" CommandArgument='<%# Eval("SubCatID") %>'><%# Eval("SubCatName") %></asp:LinkButton></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <asp:HiddenField ID="hfAccessory" runat="server" />
                                        </ol>
                                    </dd>
                                </dl>
                            </div>
                        </div>

                        <div class="block block-cart">
                            <div class="block-title ">My Cart</div>
                            <div class="block-content">
                                <div class="summary">
                                    <p class="amount" id="spanNoItems" runat="server"><span class="cart_count" id="pCount" runat="server"></span></p>
                                    <p class="subtotal"> <span class="price" id="strongTotal" runat="server"></span> </p>
                                </div>
                                <div class="ajax-checkout" id="divCheckoutBtn" runat="server">
                                    <asp:Button ID="btnCheckOut" runat="server" Text="CHECKOUT" CssClass="btn btn-primary" style="border: none;" />
                                </div>
                                <p class="block-subtitle"></p>
                                <ul>
                                    <asp:Repeater ID="rptrCart" runat="server">
                                        <ItemTemplate>
                                            <li class="item"><a href='ProductDetails.aspx?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>' title="<%# Eval("Name") %>" class="product-image">
                                                <img class="img-responsive" src="images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extension") %>" alt="<%# Eval("PName") %>"></a>
                                                <div class="product-details">
                                                    <div class="access">
                                                    <asp:LinkButton ID="lbDelete" CssClass="jtv-btn-remove" CommandName="DeleteCart" CommandArgument='<%# Eval("UniqueID") %>' runat="server" ToolTip="Remove this Item" OnClick="lbDelete_Click"><i class="fa fa-trash-o"></i></asp:LinkButton></div>
                                                    <span class="price"><%# Eval("Quantity") %> x ₹<%# Eval("PSelPrice") %></span>
                                                    <p class="product-name"><a href='ProductDetails.aspx?product=<%# MirrorOfBrands.Crypto.GetencryptedQueryString(Eval("PID").ToString()) %>'><%# Eval("PName") %></a> </p>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </aside>
                </div>
            </div>
        </div>
    </section>
    <!-- Main Container End -->
</asp:Content>

