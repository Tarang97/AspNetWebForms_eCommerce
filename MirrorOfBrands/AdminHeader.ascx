<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminHeader.ascx.cs" Inherits="AdminHeader" %>

<!-- Navigation -->
<nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
    <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <a class="navbar-brand" href="AdminDash.aspx">Mirror Of Brands Admin</a>
    </div>
    <!-- /.navbar-header -->

    <ul class="nav navbar-top-links navbar-right">
        <li class="dropdown">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </li>
        <li class="dropdown">
            <a href="Index.aspx" target="_blank">Home Site</a>
        </li>
        <li class="dropdown">
            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                <% if (Session["EMAIL"] != null)
                    {
                        lblSuccess.Text = Session["USERNAME"].ToString(); %>
                <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                    <%  }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    } %>

                <i class="fa fa-user fa-fw"></i><i class="fa fa-caret-down"></i>
            </a>
            <ul class="dropdown-menu dropdown-user">
                <li><a href="AdminProfile.aspx"><i class="fa fa-user fa-fw"></i>User Profile</a>
                </li>
                <li class="divider"></li>
                <li>
                    <!-- PostBackUrl = btnSignOut_Click -->
                    <asp:LinkButton ID="btnSignOut" runat="server" OnClick="btnSignOut_Click"><i class="fa fa-sign-out fa-fw"></i> Logout</asp:LinkButton>
                </li>
            </ul>
            <!-- /.dropdown-user -->
        </li>
        <!-- /.dropdown -->
    </ul>
    <!-- /.navbar-top-links -->

    <div class="navbar-default sidebar" role="navigation">
        <div class="sidebar-nav navbar-collapse">
            <ul class="nav" id="side-menu">
                <li>
                    <a href="AdminDash.aspx"><i class="fa fa-dashboard fa-fw"></i>Dashboard</a>
                </li>
                <li>
                    <a href="#"><i class="fa fa-product-hunt"></i>&nbsp;Products<span class="fa arrow"></span></a>
                    <ul class="nav nav-second-level">
                        <li>
                            <a href="ViewProduct.aspx"><i class="fa fa-eye"></i>&nbsp;View Products</a>
                        </li>
                        <li>
                            <a href="AddProduct.aspx"><i class="fa fa-plus-circle"></i>&nbsp;Add Products</a>
                        </li>
                        <li>
                            <a href="AddBrands.aspx"><i class="fa fa-plus-circle"></i>&nbsp;Add & View Brands</a>
                        </li>
                        <li>
                            <a href="ProductComments.aspx"><i class="fa fa-comments-o"></i>&nbsp;Product Comments</a>
                        </li>
                        <li>
                            <a href="ProductPgSlider.aspx"><i class="fa fa-picture-o"></i>&nbsp;Product Page Image Slider</a>
                        </li>
                    </ul>
                    <!-- /.nav-second-level -->
                </li>
                <li>
                    <a href="AddGender.aspx"><i class="fa fa-mars-stroke"></i>&nbsp;Gender</a>
                </li>
                <li>
                    <a href="#"><i class="fa fa-arrows-alt"></i>&nbsp;Sizes<span class="fa arrow"></span></a>
                    <ul class="nav nav-second-level">
                        <li>
                            <a href="AddSize.aspx"><i class="fa fa-eye"></i>&nbsp;Add & View Size</a>
                        </li>
                    </ul>
                    <!-- /.nav-second-level -->
                </li>
                <li>
                    <a href="#"><i class="fa fa-newspaper-o"></i>&nbsp;Categories<span class="fa arrow"></span></a>
                    <ul class="nav nav-second-level">
                        <li>
                            <a href="AddCategory.aspx"><i class="fa fa-plus-circle"></i>&nbsp;Add Category</a>
                        </li>
                        <li>
                            <a href="AddSubCategory.aspx"><i class="fa fa-plus-circle"></i>&nbsp;Add Sub-Category</a>
                        </li>
                    </ul>
                    <!-- /.nav-second-level -->
                </li>
                <li>
                    <a href="ContactRequest.aspx"><i class="fa fa-phone"></i>&nbsp;Customer Contact Request</a>
                </li>
                <li>
                    <a href="#"><i class="fa fa-truck"></i>&nbsp;Orders<span class="fa arrow"></span></a>
                    <ul class="nav nav-second-level">
                        <li>
                            <a href="PurchaseHistory.aspx"><i class="fa fa-history"></i>&nbsp;Order History</a>
                        </li>
                        <li>
                            <a href="SendOrderDetails.aspx" target="_blank"><i class="fa fa-send-o"></i>&nbsp;Send Order Details</a>
                        </li>
                    </ul>
                    <!-- /.nav-second-level -->
                </li>
                <li>
                    <a href="ListUsers.aspx"><i class="fa fa-user"></i>&nbsp;Users</a>
                </li>
                <li>
                    <a href="#"><i class="fa fa-newspaper-o"></i>&nbsp;Newsletter<span class="fa arrow"></span></a>
                    <ul class="nav nav-second-level">
                        <li>
                            <a href="Newsletter.aspx"><i class="fa fa-eye"></i>&nbsp;View Newsletter</a>
                        </li>
                    </ul>
                </li>
                <li>
                    <a href="NewsFeed.aspx"><i class="fa fa-newspaper-o"></i>&nbsp;News</a>
                </li>
                <li>
                    <a href="#"><i class="fa fa-home"></i>&nbsp;Home Page<span class="fa arrow"></span></a>
                    <ul class="nav nav-second-level">
                        <li>
                            <a href="HomeImgSlider.aspx"><i class="fa fa-plus-square-o"></i>&nbsp;Add Home Slider Image</a>
                        </li>
                        <li>
                            <a href="ViewEditImgSlider.aspx"><i class="fa fa-eye"></i>&nbsp;View & Edit Image Slider</a>
                        </li>
                        <li>
                            <a href="ProductBanner.aspx"><i class="fa fa-plus-circle"></i>&nbsp;Add Product Banner</a>
                        </li>
                        <li>
                            <a href="ViewEditBannerImg.aspx"><i class="fa fa-eye"></i>&nbsp;View & Edit Product Banner</a>
                        </li>
                        <li>
                            <a href="FeaturedCategoriesImg.aspx"><i class="fa fa-picture-o"></i>&nbsp;View & Edit Feat. Cat. Img</a>
                        </li>
                    </ul>
                    <!-- /.nav-second-level -->
                </li>
                <li>
                    <a href="MessageService.aspx"><i class="fa fa-comments"></i>&nbsp;Message</a>
                </li>
                <li>
                    <a href="AboutTermPrivacy.aspx"><i class="fa fa-lock"></i>&nbsp; About & Terms & Privacy</a>
                </li>
                <li>
                    <a href="PromoCode.aspx"><i class="fa fa-tags"></i>&nbsp; Coupons</a>
                </li>
            </ul>
        </div>
        <!-- /.sidebar-collapse -->
    </div>
    <!-- /.navbar-static-side -->
</nav>