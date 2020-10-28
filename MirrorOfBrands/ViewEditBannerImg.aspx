<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewEditBannerImg.aspx.cs" Inherits="ViewEditBannerImg" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View & Edit Banner Images</title>
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
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Banner Images
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <table class="table table-striped table-bordered table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th>#</th>
                                                            <th>Image 1 Text 1</th>
                                                            <th>Image 1 Text 2</th>
                                                            <th>Banner Image 1</th>
                                                            <th>Extension</th>
                                                            <th>Image 2 Text 1</th>
                                                            <th>Image 2 Text 2</th>
                                                            <th>Banner Image 2</th>
                                                            <th>Extension</th>
                                                            <th>Image 3 Text 1</th>
                                                            <th>Image 3 Text 2</th>
                                                            <th>Image 3 Text 3</th>
                                                            <th>Banner Image 3</th>
                                                            <th>Extension</th>
                                                            <th>Image 4 Text 1</th>
                                                            <th>Image 4 Text 2</th>
                                                            <th>Banner Image 4</th>
                                                            <th>Extension</th>
                                                            <th>Image 5 Text 1</th>
                                                            <th>Image 5 Text 2</th>
                                                            <th>Image 5 Text 3</th>
                                                            <th>Image 5 Text 4</th>
                                                            <th>Image 5 Text 5</th>
                                                            <th>Banner Image 5</th>
                                                            <th>Extension</th>
                                                            <th>Manage</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server"></asp:Label></td>
                                                            <%--Banner Image 1--%>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Image ID="Image1" runat="server" Height="150" Width="150" /></td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server"></asp:Label></td>
                                                            <%--Banner Image 2--%>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Image ID="Image2" runat="server" Height="150" Width="150" /></td>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server"></asp:Label></td>
                                                            <%--Banner Image 3--%>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Image ID="Image3" runat="server" Height="150" Width="150" /></td>
                                                            <td>
                                                                <asp:Label ID="Label11" runat="server"></asp:Label></td>
                                                            <%--Banner Image 4--%>
                                                            <td>
                                                                <asp:Label ID="Label12" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Image ID="Image4" runat="server" Height="150" Width="150" /></td>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server"></asp:Label></td>
                                                            <%--Banner Image 5--%>
                                                            <td>
                                                                <asp:Label ID="Label15" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label16" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label17" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label18" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label19" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Image ID="Image5" runat="server" Width="150" Height="150" /></td>
                                                            <td>
                                                                <asp:Label ID="Label20" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:HyperLink ID="HyperLink1" runat="server"><i class="fa fa-pencil-square-o fa-lg"></i></asp:HyperLink></td>
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
