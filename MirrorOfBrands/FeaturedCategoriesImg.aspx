<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeaturedCategoriesImg.aspx.cs" Inherits="FeaturedCategoriesImg" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fetured Categories Image</title>
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
                    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Featured Categories Image Edit
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Image 1</label>
                                                <asp:FileUpload ID="fuImg1" CssClass="form-control" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <label>Image 2</label>
                                                <asp:FileUpload ID="fuImg2" CssClass="form-control" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <label>Image 3</label>
                                                <asp:FileUpload ID="fuImg3" CssClass="form-control" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <label>Image 4</label>
                                                <asp:FileUpload ID="fuImg4" CssClass="form-control" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <label>Image 5</label>
                                                <asp:FileUpload ID="fuImg5" CssClass="form-control" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <label>Image 6</label>
                                                <asp:FileUpload ID="fuImg6" CssClass="form-control" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" Text="Update" CssClass="btn btn-primary" BorderStyle="None" />
                                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" BorderStyle="None" Text="Add" OnClick="btnAdd_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="table-responsive">
                                    <table class="table table-striped table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Image 1</th>
                                                <th>Extension</th>
                                                <th>Image 2</th>
                                                <th>Extension</th>
                                                <th>Image 3</th>
                                                <th>Extension</th>
                                                <th>Image 4</th>
                                                <th>Extension</th>
                                                <th>Image 5</th>
                                                <th>Extension</th>
                                                <th>Image 6</th>
                                                <th>Extension</th>
                                                <th>Manage</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><asp:Label ID="lblID" runat="server"></asp:Label></td>
                                                <td><asp:Image ID="Image1" runat="server" CssClass="img-responsive" /></td>
                                                <td><asp:Label ID="Extension1" runat="server"></asp:Label></td>
                                                <td><asp:Image ID="Image2" runat="server" CssClass="img-responsive" /></td>
                                                <td><asp:Label ID="Extension2" runat="server"></asp:Label></td>
                                                <td><asp:Image ID="Image3" runat="server" CssClass="img-responsive" /></td>
                                                <td><asp:Label ID="Extension3" runat="server"></asp:Label></td>
                                                <td><asp:Image ID="Image4" runat="server" CssClass="img-responsive" /></td>
                                                <td><asp:Label ID="Extension4" runat="server"></asp:Label></td>
                                                <td><asp:Image ID="Image5" runat="server" CssClass="img-responsive" /></td>
                                                <td><asp:Label ID="Extension5" runat="server"></asp:Label></td>
                                                <td><asp:Image ID="Image6" runat="server" CssClass="img-responsive" /></td>
                                                <td><asp:Label ID="Extension6" runat="server"></asp:Label></td>
                                                <td><asp:HyperLink ID="HyperLink1" runat="server"><i class="fa fa-pencil-square-o fa-lg"></i></asp:HyperLink></td>
                                            </tr>
                                        </tbody>
                                    </table>
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
