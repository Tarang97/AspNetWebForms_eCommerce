<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewProduct.aspx.cs" Inherits="ViewProduct" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View All Products</title>
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
                <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                All Products
                            </div>
                            <!-- /.panel-heading -->
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="table-responsive">
                                            <asp:Repeater ID="rptrViewProduct" runat="server" OnItemDataBound="rptrViewProduct_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table class="table table-striped table-bordered table-hover">
                                                        <thead>
                                                            <tr>
                                                                <th>#</th>
                                                                <th>Product Name</th>
                                                                <th>Product Price</th>
                                                                <th>Selling Price</th>
                                                                <th>Brand</th>
                                                                <th>Category</th>
                                                                <th>Sub Category</th>
                                                                <th>Gender</th>
                                                                <th>Discount</th>
                                                                <th>Status</th>
                                                                <th>Product Option</th>
                                                                <th>Manage</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("PID") %>'></asp:Label></td>
                                                        <td><%# Eval("PName") %></td>
                                                        <td><%# Eval("PPrice") %></td>
                                                        <td><%# Eval("PSelPrice") %></td>
                                                        <td><%# Eval("Name") %></td>
                                                        <td><%# Eval("CatName") %></td>
                                                        <td><%# Eval("SubCatName") %></td>
                                                        <td><%# Eval("GenderName") %></td>
                                                        <td><%# Eval("PDiscount") %></td>
                                                        <td><asp:Label ID="Label2" runat="server" Text='<%# Eval("Status") %>'></asp:Label></td>
                                                        <td><asp:Label ID="Label3" runat="server" Text='<%# Eval("ProductOption") %>'></asp:Label></td>
                                                        <td>
                                                            <a href='ViewProduct.aspx?pid=<%# Eval("PID") %>' title="Delete"><i class="fa fa-trash-o fa-lg"></i></a>
                                                            |
                                                <a href="EditProduct.aspx?pid=<%# Eval("PID") %>" title="Edit"><i class="fa fa-pencil-square-o fa-lg"></i></a>
                                                        </td>
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
    $('.myCheckBoxList :checkbox').eq(0).click(function () {
        var toggle = this.checked;
        $('.myCheckBoxList :checkbox').attr("checked", toggle);
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
