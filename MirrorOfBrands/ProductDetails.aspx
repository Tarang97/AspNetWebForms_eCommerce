<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Main Container -->
    <section class="main-container col1-layout">
        <div class="main">
            <div class="container">
                <div class="row">
                    <div class="col-main">
                        <div class="product-view">
                            <div class="product-essential">
                                <div class="product-img-box col-lg-5 col-sm-5 col-xs-12">
                                    <div class="new-label new-top-left">New </div>
                                    <div class="product-image">
                                        <div id="myCarousel" class="carousel slide" data-ride="carousel">
                                            <!-- Indicators -->
                                            <ol class="carousel-indicators">
                                                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                                                <li data-target="#myCarousel" data-slide-to="1" class="active"></li>
                                                <li data-target="#myCarousel" data-slide-to="2" class="active"></li>
                                                <li data-target="#myCarousel" data-slide-to="3" class="active"></li>
                                                <li data-target="#myCarousel" data-slide-to="4" class="active"></li>
                                            </ol>
                                            <div class="carousel-inner">
                                                <asp:Repeater ID="rptrImages" runat="server">
                                                    <ItemTemplate>
                                                        <div class="item <%# GetActiveClass(Container.ItemIndex) %>">
                                                            <img class="d-block w-100" src="images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extension") %>" alt="<%# Eval("Name") %>" onerror="this.src='images/ProductImages/noimage.jpg'">
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                                                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                                <span class="sr-only">Previous</span>
                                            </a>
                                            <a class="right carousel-control" href="#myCarousel" data-slide="next">
                                                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                                <span class="sr-only">Next</span>
                                            </a>
                                        </div>
                                    </div>
                                    <!-- end: more-images -->
                                </div>
                                <div class="product-shop col-lg-7 col-sm-7 col-xs-12">
                                    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                                    <asp:Repeater ID="rptrProductDetails" OnItemDataBound="rptrProductDetails_ItemDataBound" runat="server">
                                        <ItemTemplate>
                                            <div class="product-name">
                                                <h3><%# Eval("PName") %></h3>
                                            </div>
                                            <div class="price-block">
                                                <div class="price-box">
                                                    <p class="special-price"><span class="price-label">Special Price</span> <span id="product-price-48" class="price"> &#8377; <%# Eval("PSelPrice") %> </span></p>
                                                    <p class="old-price"><span class="price-label">Regular Price:</span> <span class="price">&#8377; <%# Eval("PPrice") %> </span></p>
                                                    <p style="color: red;"><%# Eval("PDiscount") %>% Off</p>
                                                </div>
                                            </div>
                                            <div class="info-orther" style="border-bottom: 1px dotted #ddd;">
                                                <p>Availability: <span class="in-stock">In stock</span></p>
                                                <p>Sizes/Color/Storage: <asp:DropDownList ID="ddlSize" runat="server" CssClass="form-control" style="width: auto;"></asp:DropDownList>&nbsp;&nbsp;<asp:Label ID="lblSError" runat="server" ForeColor="Red"></asp:Label>
                                                </p>
                                                <p>Quantity: <asp:TextBox ID="tbQuantity" CssClass="form-control" Text="1" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:Label ID="lblNone" runat="server" ForeColor="Red"></asp:Label></p>
                                                <p>Delivery Option: <asp:DropDownList ID="ddlDelivery" CssClass="form-control" style="width: auto;" runat="server">
                                                    <asp:ListItem Value="0">Free Delivery</asp:ListItem>
                                                    <asp:ListItem Value="250">2 Day Delivery</asp:ListItem>
                                                                    </asp:DropDownList></p>
                                                <strong>Delivery Details:</strong>
                                                <p style="font-size: 13px;"><%# ((int)Eval("FreeDelivery")==1)?"Free Delivery":"" %></p>
                                                <p style="font-size: 13px;"><%# ((int)Eval("DayReturns")==1)?"10 Day Returns":"" %></p>
                                                <p style="font-size: 13px;"><%# ((int)Eval("COD")==1)?"Cash On Delivery (Available)":"" %></p>
                                            </div>
                                            <div class="form-option">
                                                <div class="add-to-box" style="border-bottom: 0px;">
                                                    <div class="add-to-cart">
                                                        <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="button btn-cart btn-round-lg btn-lg" OnClick="btnAddToCart_Click" />
                                                    </div>
                                                    <div class="email-addto-box">
                                                        <ul class="add-to-links">
                                                            <li><asp:LinkButton ID="lbWishlist" CssClass="link-wishlist" runat="server" CommandArgument='<%# Eval("PID") %>' OnClick="lbWishlist_Click" CommandName="AddtoWishlist"><span>Add to Wishlist</span></asp:LinkButton></li>
                                                            <li><asp:Label ID="lblAlready" runat="server"></asp:Label></li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="product-collateral col-lg-12 col-sm-12 col-xs-12">
                                                <div class="add_info">
                                                    <ul class="nav nav-tabs">
                                                    <li class="active"><a data-toggle="tab" href="#home">Description</a></li>
                                                    <li><a data-toggle="tab" href="#menu1">Product Details</a></li>
                                                    <li><a data-toggle="tab" href="#menu2">Material & Care</a></li>
                                                </ul>

                                                <div class="tab-content">
                                                    <div id="home" class="tab-pane fade in active">
                                                        <p><%# Eval("PDescription") %></p>
                                                    </div>
                                                    <div id="menu1" class="tab-pane fade">
                                                        <p>
                                                            <%# Eval("PProductDetails").ToString().Replace(Environment.NewLine, "<br/>") %><br />
                                                        </p>
                                                    </div>
                                                    <div id="menu2" class="tab-pane fade">
                                                        <p>
                                                            <%# Eval("PMaterialCare").ToString().Replace(Environment.NewLine, "<br/>") %>
                                                        </p>
                                                    </div>
                                                </div>
                                                </div>
                                            </div>

                                            <asp:HiddenField ID="hfCatID" Value='<%# Eval("PCategoryID") %>' runat="server" />
                                            <asp:HiddenField ID="hfSubCatID" Value='<%# Eval("PSubCatID") %>' runat="server" />
                                            <asp:HiddenField ID="hfGenderID" Value='<%# Eval("PGender") %>' runat="server" />
                                            <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                    <style type="text/css">
                        .starempty {
                            background-image: url(images/Rating/empty-star.png);
                            width: 32px;
                            height: 32px;
                        }
                        .starfilled {
                            background-image: url(images/Rating/full-star.png);
                            width: 32px;
                            height: 32px;
                        }
                        .starwaiting {
                            background-image: url(images/Rating/waiting-star.png);
                            width: 32px;
                            height: 32px;
                        }
                    </style>
                    <div class="product-collateral col-lg-12 col-sm-12 col-xs-12">
                        <div class="add_info">
                            <ul id="product-detail-tab" class="nav nav-tabs product-tabs">
                                <li class="active"><a href="#reviews_tabs" data-toggle="tab">Customer Reviews</a></li>
                            </ul>
                            <div id="productTabContent" class="tab-content">
                                <div class="tab-pane fade in active" id="reviews_tabs">
                                    <div class="box-collateral box-reviews" id="customer-reviews">
                                        <div class="box-reviews1">
                                            <div class="form-add">
                                                <h3><asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label></h3>
                                                <h3>Write Your Own Review</h3>
                                                <h5>Login to Submit you Review <em class="required">*</em></h5><br />
                                                <h4>How do you rate this product? <em class="required">*</em></h4>
                                                <br />
                                                <br />
                                                <fieldset>
                                                    <span id="input-message-box"></span>
                                                    <div class="review1">
                                                        <ul class="form-list">
                                                            <li>
                                                                <ajaxToolkit:Rating ID="Rating1" runat="server" MaxRating="5" CurrentRating="1" StarCssClass="starempty" FilledStarCssClass="starfilled" WaitingStarCssClass="starwaiting" EmptyStarCssClass="starempty" OnClick="Rating1_Click"></ajaxToolkit:Rating>
                                                                <br />
                                                            </li>
                                                            <li>
                                                                <br />
                                                            </li>
                                                            <li><asp:Label ID="Label1" runat="server"></asp:Label></li>
                                                            <li>
                                                                <label class="required">Name<em>*</em></label>&nbsp;&nbsp;
                                                                <asp:Label ID="lblUReview" Font-Bold="true" runat="server"></asp:Label>
                                                            </li>
                                                            <li>
                                                                <label class="required">Review<em>*</em></label>
                                                                <div class="input-box">
                                                                    <asp:TextBox ID="tbRReview" CssClass="required-entry input-text" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tbRReview" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom" ValidChars=". " />
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <br />
                                                            </li>
                                                            <li>
                                                                <div class="button-set">
                                                                    <asp:Button ID="btnSubmitReview" runat="server" CssClass="button submit" Text="Submit Review" OnClick="btnSubmitReview_Click" />
                                                                </div>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </fieldset>
                                            </div>
                                        </div>
                                        <div class="box-reviews2">
                                            <h3>Customer Reviews</h3>
                                            <div class="box visible">
                                                <asp:Label ID="lblCommentsError" runat="server"></asp:Label>
                                                <ul>
                                                    <asp:Repeater ID="rptrComments" runat="server">
                                                        <ItemTemplate>
                                                            <li>
                                                                <table class="ratings-table">
                                                                    <colgroup>
                                                                        <col width="1">
                                                                        <col>
                                                                    </colgroup>
                                                                    <tbody>
                                                                        <tr>
                                                                            <th>Rating</th>
                                                                        </tr>
                                                                        <tr>
                                                                            <th>Name</th>
                                                                        </tr>
                                                                        <tr>
                                                                            <th>Review On</th>
                                                                        </tr>
                                                                        <tr>
                                                                            <th>Comment</th>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <div class="review">
                                                                    <h6 style="font-size:14px;">Ratings: <%# Eval("Rating") %> Stars</h6>
                                                                    <h6><a href="javascript:void(0)"><%# Eval("UserName") %></a></h6>
                                                                    <small>Review on <%# Eval("DateofComment") %> </small>
                                                                    <div class="review-txt"><%# Eval("Comments") %></div>
                                                                </div>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--</div>--%>
    </section>
  <!-- Main Container End --> 
</asp:Content>

