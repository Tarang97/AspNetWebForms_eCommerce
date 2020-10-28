<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="EditProduct" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Products</title>
    <meta name="title" content="Mirror of Brands" />
    <meta name="description" content="MirrorofBrands.com: Online Shopping India - Buy mobiles, cameras, watches, apparel, shoes. Free Shipping & Cash on Delivery Available." />
    <meta name="keywords" content="MirrorofBrands.com, Mirror, Online Shopping, online shopping india, india shopping online, mirror of brands india, mob, buy online, buy mobiles online, watches, fashion jewellery, electronic products, apparels, accessories, audio devices, audio appliances" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <meta name="language" content="English" />
    <meta name="google" content="nositelinksearchbox" />
    <meta name="google-site-verification" content="w8RRvIuUXpS_LrxW40BMikUIVeICYTlqFaxdNiyvlv4" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Favicon  -->
    <link rel="icon" type="image/png" sizes="16x16" href="favicon-16x16.png">

    <!-- Bootstrap Core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- MetisMenu CSS -->
    <link href="vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="dist/css/sb-admin-2.css" rel="stylesheet" />

    <!-- Morris Charts CSS -->
    <link href="vendor/morrisjs/morris.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <!-- Navigation -->
            <ah:Header ID="AdminHeader" runat="server" />

            <!-- Page Content -->
            <div id="page-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Products</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <asp:Label ID="lblSuccess" runat="server" ForeColor="Green"></asp:Label>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Edit Products
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>Product Name</label>
                                                <asp:TextBox ID="txtPName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <label>Product Price</label>
                                            <div class="form-group input-group">
                                                <span class="input-group-addon">&#8377;</span>
                                                <asp:TextBox ID="txtPPrice" runat="server" CssClass="form-control" placeholder="Product Price"></asp:TextBox>
                                                <span class="input-group-addon">.00</span>
                                            </div>
                                            <label>Product Selling Price</label>
                                            <div class="form-group input-group">
                                                <span class="input-group-addon">&#8377;</span>
                                                <asp:TextBox ID="txtSelPrice" runat="server" CssClass="form-control" placeholder="Selling Price"></asp:TextBox>
                                                <span class="input-group-addon">.00</span>
                                            </div>

                                            <div class="form-group">
                                                <label>Category</label>
                                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Brand</label>
                                                <asp:DropDownList ID="ddlBrands" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Sub Category</label>
                                                <asp:DropDownList ID="ddlSubCategory" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Gender</label>
                                                <asp:DropDownList ID="ddlGender" OnSelectedIndexChanged="ddlGender_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Size:</label>&nbsp;&nbsp;&nbsp;
                                                <div class="checkbox-inline">
                                                    <asp:CheckBoxList ID="cblSize" RepeatDirection="Vertical" runat="server">
                                                    </asp:CheckBoxList>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label>Quantity</label>
                                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Description</label>
                                                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Product Details</label>
                                                <asp:TextBox ID="txtPDetails" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Material and Care</label>
                                                <asp:TextBox ID="txtMatCare" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Recent Product Images</label><br />
                                                <div class="product-image" style="width:200px;height:200px;">
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
                                            </div>
                                            <br /><br /><br />
                                            <div class="form-group">
                                                <label>New Images:</label>
                                                <asp:FileUpload ID="fuImg01" runat="server" CssClass="form-control" />
                                            </div>

                                            <div class="form-group">
                                                <asp:FileUpload ID="fuImg02" CssClass="form-control" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <asp:FileUpload ID="fuImg03" CssClass="form-control" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <asp:FileUpload ID="fuImg04" CssClass="form-control" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <asp:FileUpload ID="fuImg05" CssClass="form-control" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <label>Delivery and Return</label>
                                                <div>
                                                    <asp:CheckBox ID="cbFD" runat="server" />
                                                    <asp:Label ID="Label1" runat="server" Text="Free Delivery"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <div>
                                                    <asp:CheckBox ID="cb10Ret" runat="server" />
                                                    <asp:Label ID="Label2" runat="server" Text="10 Day Return"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <div>
                                                    <asp:CheckBox ID="cbCOD" runat="server" />
                                                    <asp:Label ID="Label3" runat="server" Text="Cash On Delivery"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label>Discounts and Offers</label>
                                                <asp:TextBox ID="txtDiscOffer" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Product Status:</label>
                                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="0">Draft</asp:ListItem>
                                                    <asp:ListItem Value="1">Publish</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Product Option:</label>
                                                <asp:DropDownList ID="ddlPrdOpt" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="0">- Select Product Option -</asp:ListItem>
                                                    <asp:ListItem Value="1">New</asp:ListItem>
                                                    <asp:ListItem Value="2">Sale</asp:ListItem>
                                                    <asp:ListItem Value="3">Featured</asp:ListItem>
                                                    <asp:ListItem Value="4">None</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" CssClass="btn btn-primary" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <label style="color: red; text-align: justify;">
                                <strong style="color: black;">Note</strong>:- Please Update all the fields even if you want to keep the things as it is because that is gonna update your product successfully.<br />
                                <br />
                                <strong style="color: black;">For example</strong>:- If you're not changing brand, category, subcategory, gender, and size then also select as it is when you selected the things at the time of adding products, and same is applicable for 10 Day Returns, COD, Free Delivery too.<br />
                                Lastly, don't need to worry about Product Details, Product material care, Product Description, Product Images, Product Price, Product Selling Price, means if you not gonna change it then no problem, your product will be updated successfully.</label>
                        </div>
                    </div>
                </div>
                <!-- /.container-fluid -->
            </div>
            <!-- /#page-wrapper -->
        </div>
    </form>

<!-- jQuery -->
<script src="vendor/jquery/jquery.min.js"></script>

<!-- Bootstrap Core JavaScript -->
<script src="vendor/bootstrap/js/bootstrap.min.js"></script>

<!-- Metis Menu Plugin JavaScript -->
<script src="vendor/metisMenu/metisMenu.min.js"></script>

<!-- Custom Theme JavaScript -->
<script src="dist/js/sb-admin-2.js"></script>
</body>
</html>
