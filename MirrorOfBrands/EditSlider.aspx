<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditSlider.aspx.cs" Inherits="EditSlider" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Image Slider</title>
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
                                    Edit Home Image Slider
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <h3>Image 1</h3>
                                            <div class="form-group">
                                                <label>Image Text 1</label>
                                                <asp:TextBox ID="Img1txt1" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Image Text 2</label>
                                                <asp:TextBox ID="Img1txt2" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Image Text 3</label>
                                                <asp:TextBox ID="Img1txt3" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Button Text</label>
                                                <asp:TextBox ID="btn1txt" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Image</label><br />
                                                <asp:Image ID="Image1" runat="server" Width="250" Height="150" />
                                            </div>

                                            <div class="form-group">
                                                <label>New Image 1</label>
                                                <asp:FileUpload ID="fuImg1" CssClass="form-control" runat="server" />
                                            </div>

                                            <h3>Image 2</h3>
                                            <div class="form-group">
                                                <label>Image Text 1</label>
                                                <asp:TextBox ID="Img2txt1" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Image Text 2</label>
                                                <asp:TextBox ID="Img2txt2" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Image Text 3</label>
                                                <asp:TextBox ID="Img2txt3" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Button Text</label>
                                                <asp:TextBox ID="btn2txt" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Image</label><br />
                                                <asp:Image ID="Image2" runat="server" Width="250" Height="150" />
                                            </div>

                                            <div class="form-group">
                                                <label>New Image 2</label>
                                                <asp:FileUpload ID="fuImg2" CssClass="form-control" runat="server" />
                                            </div>

                                            <h3>Image 3</h3>
                                            <div class="form-group">
                                                <label>Image Text 1</label>
                                                <asp:TextBox ID="Img3txt1" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Image Text 2</label>
                                                <asp:TextBox ID="Img3txt2" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Image Text 3</label>
                                                <asp:TextBox ID="Img3txt3" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Image Text 4</label>
                                                <asp:TextBox ID="Img3txt4" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Button Text</label>
                                                <asp:TextBox ID="btn3txt" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Image 3</label><br />
                                                <asp:Image ID="Image3" runat="server" Width="250" Height="150" />
                                            </div>

                                            <div class="form-group">
                                                <label>New Image 3</label>
                                                <asp:FileUpload ID="fuImg3" CssClass="form-control" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <asp:Button ID="btnUpdateImage" OnClick="btnUpdateImage_Click" CssClass="btn btn-success" runat="server" Text="Submit" style="border:0;" />
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
