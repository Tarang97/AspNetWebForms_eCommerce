<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductBanner.aspx.cs" Inherits="ProductBanner" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page Product Banner</title>
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
                            <h1 class="page-header">Home Page</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <asp:Label ID="lblSuccess" ForeColor="Green" runat="server"></asp:Label>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Add Banner Image
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <h3>Below Slider Image</h3>
                                            <div class="form-group">
                                                <label>Banner 1 Text 1</label>
                                                <asp:TextBox ID="txt1Ban1" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner 1 Text 2</label>
                                                <asp:TextBox ID="txt2Ban1" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner 1 Button Text</label>
                                                <asp:TextBox ID="btnBan1" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner Image 1</label>
                                                <asp:FileUpload ID="fuImgBan1" CssClass="form-control" runat="server" />
                                            </div>
                                            <hr />
                                            <div class="form-group">
                                                <label>Banner 2 Text 1</label>
                                                <asp:TextBox ID="txt1Ban2" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner 2 Text 2</label>
                                                <asp:TextBox ID="txt2Ban2" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner 2 Button Text</label>
                                                <asp:TextBox ID="btnBan2" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner Image 2</label>
                                                <asp:FileUpload ID="fuImgBan2" CssClass="form-control" runat="server" />
                                            </div>
                                            <h3>Below Featured Categories</h3>
                                            <div class="form-group">
                                                <label>Banner 3 Text 1</label>
                                                <asp:TextBox ID="txt1Ban3" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner 3 Text 2</label>
                                                <asp:TextBox ID="txt2Ban3" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner 3 Text 3</label>
                                                <asp:TextBox ID="txt3Ban3" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner Image 3</label>
                                                <asp:FileUpload ID="fuImgBan3" CssClass="form-control" runat="server" />
                                            </div>
                                            <hr />
                                            <div class="form-group">
                                                <label>Banner 4 Text 1</label>
                                                <asp:TextBox ID="txt1Ban4" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner 4 Text 2</label>
                                                <asp:TextBox ID="txt2Ban4" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner Image 4</label>
                                                <asp:FileUpload ID="fuImgBan4" CssClass="form-control" runat="server" />
                                            </div>
                                            <hr />
                                            <div class="form-group">
                                                <label>Banner 5 Text 1</label>
                                                <asp:TextBox ID="txt1Ban5" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner 5 Text 2</label>
                                                <asp:TextBox ID="txt2Ban5" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner 5 Text 3</label>
                                                <asp:TextBox ID="txt3Ban5" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner 5 Text 4</label>
                                                <asp:TextBox ID="txt4Ban5" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner 5 Text 5</label>
                                                <asp:TextBox ID="txt5Ban5" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Banner Image 5</label>
                                                <asp:FileUpload ID="fuImgBan5" CssClass="form-control" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <asp:Button ID="btnAddBanner" OnClick="btnAddBanner_Click" CssClass="btn btn-success" runat="server" Text="Submit" style="border:0;" />
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
