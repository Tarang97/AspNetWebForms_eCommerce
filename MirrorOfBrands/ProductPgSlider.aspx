<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductPgSlider.aspx.cs" Inherits="ProductPgSlider" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Page Image Slider</title>
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
                            <h1 class="page-header">Dashboard</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <asp:Label ID="lblSuccess" runat="server" ForeColor="Green"></asp:Label>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Product Page Image Slider
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group col-lg-6">
                                                <label>Image 1 Text 1</label>
                                                <asp:TextBox ID="tbImg1Txt1" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group col-lg-6">
                                                <label>Image 1 Text 2</label>
                                                <asp:TextBox ID="tbImg1Txt2" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <br />
                                            <div class="form-group col-lg-6">
                                                <label>Image 1 Text 3</label>
                                                <asp:TextBox ID="tbImg1Txt3" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group col-lg-6">
                                                <label>Image 1</label>
                                                <asp:FileUpload ID="fuImg1" CssClass="form-control" runat="server" />
                                                <asp:Image ID="Image1" CssClass="img-responsive" runat="server" />
                                            </div>
                                            <br />
                                            <div class="form-group col-lg-6">
                                                <label>Image 2 Text 1</label>
                                                <asp:TextBox ID="tbImg2Txt1" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group col-lg-6">
                                                <label>Image 2 Text 2</label>
                                                <asp:TextBox ID="tbImg2Txt2" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <br />
                                            <div class="form-group col-lg-6">
                                                <label>Image 2 Text 3</label>
                                                <asp:TextBox ID="tbImg2Txt3" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group col-lg-6">
                                                <label>Image 2</label>
                                                <asp:FileUpload ID="fuImg2" CssClass="form-control" runat="server" />
                                                <asp:Image ID="Image2" CssClass="img-responsive" runat="server" />
                                            </div>


                                            <div class="form-group col-lg-6">
                                                <label>Image 3 Text 1</label>
                                                <asp:TextBox ID="tbImg3Txt1" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group col-lg-6">
                                                <label>Image 3 Text 2</label>
                                                <asp:TextBox ID="tbImg3Txt2" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group col-lg-6">
                                                <label>Image 3 Text 3</label>
                                                <asp:TextBox ID="tbImg3Txt3" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group col-lg-6">
                                                <label>Image 3</label>
                                                <asp:FileUpload ID="fuImg3" CssClass="form-control" runat="server" />
                                                <asp:Image ID="Image3" CssClass="img-responsive" runat="server" />
                                            </div>

                                            <div class="form-group">
                                                <asp:Button ID="btnSubmit" CssClass="btn btn-success" BorderStyle="None" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                                <asp:Button ID="btnUpdate" CssClass="btn btn-primary" BorderStyle="None" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Product Page Image Slider
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <asp:Repeater ID="rptrImage" runat="server">
                                                    <HeaderTemplate>
                                                        <table class="table table-bordered table-hover table-striped">
                                                            <thead>
                                                                <tr>
                                                                    <th>#</th>
                                                                    <th>Image 1 Text 1</th>
                                                                    <th>Image 1 Text 2</th>
                                                                    <th>Image 1 Text 3</th>
                                                                    <th>Image 1</th>
                                                                    <th>Extension</th>
                                                                    <th>Image 2 Text 1</th>
                                                                    <th>Image 2 Text 2</th>
                                                                    <th>Image 2 Text 3</th>
                                                                    <th>Image 2</th>
                                                                    <th>Extension</th>
                                                                    <th>Image 3 Text 1</th>
                                                                    <th>Image 3 Text 2</th>
                                                                    <th>Image 3 Text 3</th>
                                                                    <th>Image 3</th>
                                                                    <th>Extension</th>
                                                                    <th>Manage</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Eval("ID") %></td>
                                                            <td><%# Eval("Text1Img1") %></td>
                                                            <td><%# Eval("Text2Img1") %></td>
                                                            <td><%# Eval("Text3Img1") %></td>
                                                            <td><img src="images/ProductPgSlider/<%# Eval("Image1") %><%# Eval("Extension1") %>" alt="<%# Eval("Image1") %>" class="img-responsive" /></td>
                                                            <td><%# Eval("Extension1") %></td>
                                                            <td><%# Eval("Text1Img2") %></td>
                                                            <td><%# Eval("Text2Img2") %></td>
                                                            <td><%# Eval("Text3Img2") %></td>
                                                            <td><img src="images/ProductPgSlider/<%# Eval("Image2") %><%# Eval("Extension2") %>" alt="<%# Eval("Image2") %>" class="img-responsive" /></td>
                                                            <td><%# Eval("Extension2") %></td>
                                                            <td><%# Eval("Text1Img3") %></td>
                                                            <td><%# Eval("Text2Img3") %></td>
                                                            <td><%# Eval("Text3Img3") %></td>
                                                            <td><img src="images/ProductPgSlider/<%# Eval("Image3") %><%# Eval("Extension3") %>" alt="<%# Eval("Image3") %>" class="img-responsive" /></td>
                                                            <td><%# Eval("Extension3") %></td>
                                                            <td><a href='ProductPgSlider.aspx?ppsid=<%# Eval("ID") %>'><i class="fa fa-pencil-square-o fa-lg"></i></a></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody>
                                                </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
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

<script type="text/javascript">
    $(function ShowPopup() {
        $("#myModal").modal("show");
    });
</script>

<!-- Bootstrap Core JavaScript -->
<script src="vendor/bootstrap/js/bootstrap.min.js"></script>

<!-- Metis Menu Plugin JavaScript -->
<script src="vendor/metisMenu/metisMenu.min.js"></script>

<!-- Custom Theme JavaScript -->
<script src="dist/js/sb-admin-2.js"></script>
</body>
</html>
