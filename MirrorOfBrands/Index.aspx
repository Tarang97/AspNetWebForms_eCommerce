<%@ Page Title="Mirror of Brands" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Slideshow  -->
    <div class="main-slider" id="home">
        <div class="jtv-slideshow">
            <div id="jtv-slideshow">
                <div id='rev_slider_4_wrapper' class='rev_slider_wrapper fullwidthbanner-container'>
                    <div id='rev_slider_4' class='rev_slider fullwidthabanner'>
                        <ul>
                            <li data-transition='slideup' data-slotamount='7' data-masterspeed='1000' data-thumb=''>
                                <asp:Image ID="Image1" data-bgposition='left top' data-bgfit='cover' data-bgrepeat='no-repeat' runat="server" AlternateText="Slider1" />
                                <div class="caption-inner left">
                                    <div class='tp-caption LargeTitle sft  tp-resizeme' data-x='50' data-y='200' data-endspeed='500' data-speed='500' data-start='1300' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 3; white-space: nowrap;'>
                                        <asp:Label ID="Img1lbl1" runat="server"></asp:Label></div>
                                    <div class='tp-caption ExtraLargeTitle sft  tp-resizeme' data-x='50' data-y='250' data-endspeed='500' data-speed='500' data-start='1100' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 2; white-space: nowrap;'>
                                        <asp:Label ID="Img1lbl2" runat="server"></asp:Label></div>
                                    <div class='tp-caption' data-x='72' data-y='320' data-endspeed='500' data-speed='500' data-start='1100' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 2; white-space: nowrap;'>
                                        <asp:Label ID="Img1lbl3" runat="server"></asp:Label></div>
                                    <div class='tp-caption sfb  tp-resizeme ' data-x='72' data-y='370' data-endspeed='500' data-speed='500' data-start='1500' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 4; white-space: nowrap;'><asp:HyperLink ID="hlSlider1" CssClass="buy-btn" runat="server"><asp:Label ID="btn1lbl1" runat="server"></asp:Label></asp:HyperLink></div>
                                </div>
                            </li>
                            <li data-transition='slideup' data-slotamount='7' data-masterspeed='1000' data-thumb=''>
                                <asp:Image ID="Image2" data-bgposition='left top' data-bgfit='cover' data-bgrepeat='no-repeat' runat="server" AlternateText="Slider2" />
                                <div class="caption-inner">
                                    <div class='tp-caption LargeTitle sft  tp-resizeme' data-x='360' data-y='170' data-endspeed='500' data-speed='500' data-start='1300' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 3; white-space: nowrap;'>
                                        <asp:Label ID="Img2lbl1" runat="server"></asp:Label></div>
                                    <div class='tp-caption ExtraLargeTitle sft  tp-resizeme' data-x='290' data-y='240' data-endspeed='500' data-speed='500' data-start='1100' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 2; white-space: nowrap;'>
                                        <asp:Label ID="Img2lbl2" runat="server"></asp:Label></div>
                                    <div class='tp-caption' data-x='415' data-y='315' data-endspeed='500' data-speed='500' data-start='1100' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 2; white-space: nowrap; color: #273f5b;'>
                                        <asp:Label ID="Img2lbl3" runat="server"></asp:Label></div>
                                    <div class='tp-caption sfb  tp-resizeme ' data-x='550' data-y='380' data-endspeed='500' data-speed='500' data-start='1500' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 4; white-space: nowrap;'><asp:HyperLink ID="hlSlider2" CssClass="buy-btn" runat="server"><asp:Label ID="btn2lbl1" runat="server"></asp:Label></asp:HyperLink></div>
                                </div>
                            </li>
                            <li data-transition='slideup' data-slotamount='7' data-masterspeed='1000' data-thumb=''>
                                <asp:Image ID="Image3" runat="server" data-bgposition='left top' data-bgfit='cover' data-bgrepeat='no-repeat' AlternateText="Slider3" />
                                <div class="caption-inner right">
                                    <div class='tp-caption LargeTitle sft  tp-resizeme' data-x='450' data-y='170' data-endspeed='500' data-speed='500' data-start='1300' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 3; white-space: nowrap;'>
                                        <asp:Label ID="Img3lbl1" runat="server"></asp:Label></div>
                                    <div class='tp-caption ExtraLargeTitle sft  tp-resizeme' data-x='450' data-y='210' data-endspeed='500' data-speed='500' data-start='1100' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 2; white-space: nowrap;'>
                                        <asp:Label ID="Img3lbl2" runat="server"></asp:Label></div>
                                    <div class='tp-caption ExtraLargeTitle sft  tp-resizeme' data-x='450' data-y='270' data-endspeed='500' data-speed='500' data-start='1100' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 2; white-space: nowrap;'>
                                        <asp:Label ID="Img3lbl3" runat="server"></asp:Label></div>
                                    <div class='tp-caption' data-x='475' data-y='340' data-endspeed='500' data-speed='500' data-start='1100' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 2; white-space: nowrap;'>
                                        <asp:Label ID="Img3lbl4" runat="server"></asp:Label></div>
                                    <div class='tp-caption sfb  tp-resizeme ' data-x='475' data-y='390' data-endspeed='500' data-speed='500' data-start='1500' data-easing='Linear.easeNone' data-splitin='none' data-splitout='none' data-elementdelay='0.1' data-endelementdelay='0.1' style='z-index: 4; white-space: nowrap;'><asp:HyperLink ID="hlSlider3" CssClass="buy-btn" runat="server"><asp:Label ID="btn3lbl1" runat="server"></asp:Label></asp:HyperLink></div>
                                </div>
                            </li>
                        </ul>
                        <div class="tp-bannertimer"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-sm-6">
                <div class="jtv-text-top-banner">
                    <asp:HyperLink ID="hlAudio" ToolTip="Audios" runat="server">
                        <asp:Image ID="ImgBan1" CssClass="img-responsive" runat="server" />
                        <span class="jtv-b-content middle-left"><span class="title"><span class="skincolor">
                            <asp:Label ID="lbl1Ban1" runat="server"></asp:Label></span><br>
                            <small><asp:Label ID="lbl2Ban1" runat="server"></asp:Label></small></span><span class="btn-buy"><span>Shop Now </span></span></span>
                    </asp:HyperLink>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="jtv-text-top-banner">
                    <asp:HyperLink ID="Handbaglink" ToolTip="Handbag" runat="server">
                        <asp:Image ID="ImgBan2" CssClass="img-responsive" runat="server" />
                        <span class="jtv-b-content middle-left"><span class="banner-label-wrapper"></span><span class="title"><span class="title-color">
                            <asp:Label ID="lbl1Ban2" runat="server"></asp:Label></span><br>
                            <small><asp:Label ID="lbl2Ban2" runat="server"></asp:Label></small></span><span class="btn-buy"><span>Shop Now </span></span></span>
                    </asp:HyperLink>
                </div>
            </div>
        </div>
    </div>

    <!-- Categories -->
    <section class="jtv-bestsell-section">
        <div class="container">
            <div class="slider-items-products">
                <div class="bestsell-block">
                    <div class="jtv-block-inner">
                        <div class="block-title">
                            <h2>Featured Categories</h2>
                        </div>
                    </div>
                    <div id="bestsell-slider" class="product-flexslider hidden-buttons">
                        <div class="slider-items slider-width-col4 products-grid block-content">
                            <div class="item">
                                <div class="item-inner">
                                    <div class="item-img">
                                        <div class="item-img-info">
                                            <asp:HyperLink ID="Clothinglink" CssClass="product-image" ToolTip="Clothing" runat="server">
                                                <asp:Image ID="Image4" CssClass="img-responsive" runat="server" />
                                            </asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="item-info">
                                        <div class="info-inner">
                                            <div class="item-title"><a title="Clothing" href="javascript:void(0)">Clothing</a></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="item">
                                <div class="item-inner">
                                    <div class="item-img">
                                        <div class="item-img-info">
                                            <asp:HyperLink ID="Shoeslink" CssClass="product-image" runat="server" ToolTip="Shoes">
                                                <asp:Image ID="Image5" CssClass="img-responsive" runat="server" />
                                            </asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="item-info">
                                        <div class="info-inner">
                                            <div class="item-title"><a title="Shoes" href="javascript:void(0)">Shoes </a></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="item">
                                <div class="item-inner">
                                    <div class="item-img">
                                        <div class="item-img-info">
                                            <asp:HyperLink ID="HandbagSL" CssClass="product-image" runat="server" ToolTip="Handbag">
                                                <asp:Image ID="Image6" CssClass="img-responsive" runat="server" />
                                            </asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="item-info">
                                        <div class="info-inner">
                                            <div class="item-title"><a title="Handbag" href="javascript:void(0)">Handbag</a></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="item">
                                <div class="item-inner">
                                    <div class="item-img">
                                        <div class="item-img-info">
                                            <asp:HyperLink ID="Watchlink" CssClass="product-image" ToolTip="Watches" runat="server">
                                                <asp:Image ID="Image7" runat="server" CssClass="img-responsive" />
                                            </asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="item-info">
                                        <div class="info-inner">
                                            <div class="item-title"><a title="Watches" href="javascript:void(0)">Watches</a></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="item">
                                <div class="item-inner">
                                    <div class="item-img">
                                        <div class="item-img-info">
                                            <asp:HyperLink ID="Sglink" CssClass="product-image" ToolTip="Sunglasses" runat="server">
                                                <asp:Image ID="Image8" CssClass="img-responsive" runat="server" />
                                            </asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="item-info">
                                        <div class="info-inner">
                                            <div class="item-title"><a title="Sunglasses" href="javascript:void(0)">Sunglasses</a></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="item">
                                <div class="item-inner">
                                    <div class="item-img">
                                        <div class="item-img-info">
                                            <asp:HyperLink ID="Accessorylink" CssClass="product-image" ToolTip="Accessories" runat="server">
                                                <asp:Image ID="Image9" CssClass="img-responsive" runat="server" />
                                            </asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="item-info">
                                        <div class="info-inner">
                                            <div class="item-title"><a title="Accessories" href="javascript:void(0)">Accessories</a></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- /Categories -->

    <!-- jtv bottom banner section -->
    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <div class="jtv-text-top-banner">
                    <asp:HyperLink ID="hlSmartphone" ToolTip="Smartphones" runat="server">
                        <asp:Image ID="ImgBan3" CssClass="img-responsive" runat="server" />
                        <span class="jtv-b-content bottom-left"><span class="text">
                            <asp:Label ID="lbl1Ban3" runat="server"></asp:Label></span> <span class="title"><span class="black-text"><asp:Label ID="lbl2Ban3" runat="server"></asp:Label></span><br>
                                <small><asp:Label ID="lbl3Ban3" runat="server"></asp:Label></small></span></span>
                    </asp:HyperLink>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="jtv-text-top-banner">
                    <asp:HyperLink ID="hlCameras" ToolTip="Cameras" runat="server">
                        <asp:Image ID="ImgBan4" CssClass="img-responsive" runat="server" />
                        <span class="jtv-b-content top-center"><span class="title"><span class="black-text">
                            <asp:Label ID="lbl1Ban4" runat="server"></asp:Label></span><br>
                            <small><asp:Label ID="lbl2Ban4" runat="server"></asp:Label></small></span></span>
                    </asp:HyperLink>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="jtv-text-top-banner">
                    <asp:HyperLink ID="Headphonelink" ToolTip="Headphone" runat="server">
                        <asp:Image ID="ImgBan5" CssClass="img-responsive" runat="server" />
                        <span class="jtv-b-content middle-center"><span class="strong-title">
                            <asp:Label ID="lbl1Ban5" runat="server"></asp:Label></span></span><span class="jtv-b-content bottom-center"><span class="text-left"><span class="media-body text-right"><span class="subtitle skincolor"><asp:Label ID="lbl2Ban5" runat="server"></asp:Label><br>
                                <asp:Label ID="lbl3Ban5" runat="server"></asp:Label></span></span> </span></span><span class="jtv-b-price-box"><span class="banner-text-wrapper"><span class="jtv-b-price-text">
                                    <asp:Label ID="lbl4Ban5" runat="server"></asp:Label></span> <span class="jtv-b-price">&#8377;<asp:Label ID="lbl5Ban5" runat="server"></asp:Label></span> </span></span>
                    </asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
    <!-- /jtv bottom banner section -->

    <!-- Brand Logo -->
    <div class="container">
        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" data-wow-delay="0.2s">
                <div class="jtv-testimonial-block" style="height: 360px;">
                    <div class="carousel slide" data-ride="carousel" id="quote-carousel">
                        <!-- Carousel Slides / Quotes -->
                        <div class="carousel-inner text-center">
                            <asp:Repeater ID="rptrNewsView" runat="server">
                                <ItemTemplate>
                                    <div class="item <%# GetActiveClass(Container.ItemIndex) %>">
                                        <blockquote>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <p><%# Eval("NewsMessage") %></p>
                                                    <div class="holder-info"><strong class="name"><%# Eval("NewsName") %></strong></div>
                                                </div>
                                            </div>
                                        </blockquote>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <!-- Bottom Carousel Indicators -->
                        <ol class="carousel-indicators">
                            <asp:Repeater ID="rptrNewsImage" runat="server">
                                <ItemTemplate>
                                    <li data-target="#quote-carousel" data-slide-to="0">
                                        <img class="img-responsive" src="images/<%# Eval("NewsImage") %><%# Eval("Extension") %>" alt="<%# Eval("NewsImage") %>">
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ol>
                        <!-- Carousel Buttons Next/Prev -->
                        <a data-slide="prev" href="#quote-carousel" class="left carousel-control"><i class="fa fa-chevron-left"></i></a><a data-slide="next" href="#quote-carousel" class="right carousel-control"><i class="fa fa-chevron-right"></i></a>
                    </div>
                    <br />
                    <div class="holder-info text-center">
                        <strong class="name">
                            <h3>Latest News</h3>
                        </strong>
                    </div>
                </div>
            </div>

            <!-- Brand Logo -->
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                <div class="brand-logo">
                    <div class="slider-items-products">
                        <div id="brand-logo-slider" class="product-flexslider hidden-buttons">
                            <div class="slider-items slider-width-col6">
                                <!-- Item -->
                                <div class="item">
                                    <a href="javascript:void(0)">
                                        <img class="img-responsive" src="images/SiteImages/adidas.png" alt="Adidas" width="160" height="70">
                                    </a><a href="javascript:void(0)">
                                        <img class="img-responsive" src="images/SiteImages/apple.png" alt="Image" width="160" height="70">
                                    </a><a href="javascript:void(0)">
                                        <img class="img-responsive" src="images/SiteImages/calvinklein.png" alt="Image" width="160" height="70">
                                    </a>
                                </div>
                                <!-- End Item -->

                                <!-- Item -->
                                <div class="item">
                                    <a href="javascript:void(0)">
                                        <img class="img-responsive" src="images/SiteImages/cartier.png" alt="Image" width="160" height="70">
                                    </a><a href="javascript:void(0)">
                                        <img class="img-responsive" src="images/SiteImages/casio.png" alt="Image" width="160" height="70">
                                    </a><a href="javascript:void(0)">
                                        <img class="img-responsive" src="images/SiteImages/emporio-armani.png" alt="Image" width="160" height="70">
                                    </a>
                                </div>
                                <!-- End Item -->

                                <!-- Item -->
                                <div class="item">
                                    <a href="javascript:void(0)">
                                        <img class="img-responsive" src="images/SiteImages/fossil.png" alt="Image" width="160" height="70">
                                    </a><a href="javascript:void(0)">
                                        <img class="img-responsive" src="images/SiteImages/gucci.png" alt="Image" width="160" height="70">
                                    </a><a href="javascript:void(0)">
                                        <img class="img-responsive" src="images/SiteImages/lacoste.png" alt="Image" width="160" height="70">
                                    </a>
                                </div>
                                <!-- End Item -->

                                <!-- Item -->
                                <div class="item">
                                    <a href="javascript:void;">
                                        <img class="img-responsive" src="images/SiteImages/louisphilippe.png" alt="Image" width="160" height="70">
                                    </a><a href="javascript:void;">
                                        <img class="img-responsive" src="images/SiteImages/michaelkors.png" alt="Image" width="160" height="70">
                                    </a><a href="javascript:void;">
                                        <img class="img-responsive" src="images/SiteImages/louisvuitton.png" alt="Image" width="160" height="70">
                                    </a>
                                </div>
                                <!-- End Item -->

                                <!-- Item -->
                                <div class="item">
                                    <a href="javascript:void;">
                                        <img class="img-responsive" src="images/SiteImages/rado.png" alt="Image" width="160" height="70">
                                    </a><a href="javascript:void;">
                                        <img class="img-responsive" src="images/SiteImages/nike.png" alt="Image" width="160" height="70">
                                    </a><a href="javascript:void;">
                                        <img class="img-responsive" src="images/SiteImages/police.png" alt="Image" width="160" height="70">
                                    </a>
                                </div>
                                <!-- End Item -->

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Our Features -->
    <div class="our-features-box">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-xs-12 col-sm-4">
                    <div class="feature-box" style="overflow: hidden; text-align: center; color: #191919; line-height: 1.4em; font-weight: normal; text-transform: uppercase; background-color: #f0f2f9; padding: 1em 18px;">
                        <i class="pe-7s-plane" style="display: inline-block; font-size: 70px; font-weight: normal; padding-top: 0px; text-transform: none; margin-right: 10px; color: #1467c1; vertical-align: -2px;"></i>
                        <div class="content" style="display: inline-block; text-align: left; text-transform: none; color: #666; vertical-align: 10px;">
                            <h3 style="color: #191919; font-size: 18px; line-height: 1; font-weight: 500; margin-top: 0px; margin-bottom: 5px;">Free Shipping in all Over India</h3>
                            <p style="margin: 0px;">Free Shipping on All Orders</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-sm-4">
                    <div class="feature-box" style="overflow: hidden; text-align: center; color: #191919; line-height: 1.4em; font-weight: normal; text-transform: uppercase; background-color: #f0f2f9; padding: 1em 18px;">
                        <i class="pe-7s-piggy" style="display: inline-block; font-size: 70px; font-weight: normal; padding-top: 0px; text-transform: none; margin-right: 10px; color: #1467c1; vertical-align: -2px;"></i>
                        <div class="content" style="display: inline-block; text-align: left; text-transform: none; color: #666; vertical-align: 10px;">
                            <h3 style="color: #191919; font-size: 18px; line-height: 1; font-weight: 500; margin-top: 0px; margin-bottom: 5px;">Reasonable Pricing</h3>
                            <p style="margin: 0px;">To establish a selling price for a product</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-sm-4">
                    <div class="feature-box" style="overflow: hidden; text-align: center; color: #191919; line-height: 1.4em; font-weight: normal; text-transform: uppercase; background-color: #f0f2f9; padding: 1em 18px;">
                        <i class="pe-7s-headphones" style="display: inline-block; font-size: 70px; font-weight: normal; padding-top: 0px; text-transform: none; margin-right: 10px; color: #1467c1; vertical-align: -2px;"></i>
                        <div class="content" style="display: inline-block; text-align: left; text-transform: none; color: #666; vertical-align: 10px;">
                            <h3 style="color: #191919; font-size: 18px; line-height: 1; font-weight: 500; margin-top: 0px; margin-bottom: 5px;">Online Support 24/7</h3>
                            <p style="margin: 0px;">In order to provide 24X7 customer support</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /Our Features -->
</asp:Content>

