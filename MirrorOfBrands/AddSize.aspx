<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSize.aspx.cs" Inherits="AddSize" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Sizes</title>
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
                            <h1 class="page-header">Sizes</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->

                    <div class="row">
                        <div class="col-lg-6">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Add Size
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <asp:Label ID="lblSuccess" runat="server"></asp:Label>

                                            <div class="form-group">
                                                <label>Size Name</label>
                                                <asp:TextBox ID="txtSizeName" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="txtSizeName" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <label>Category</label>
                                                <asp:DropDownList ID="ddlCategory" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="ddlCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <label>Brand</label>
                                                <asp:DropDownList ID="ddlBrands" CssClass="form-control" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="ddlBrands" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="fom-group">
                                                <label>Sub Category</label>
                                                <asp:DropDownList ID="ddlSubCat" CssClass="form-control" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="ddlSubCat" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <label>Gender</label>
                                                <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="ddlGender" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add" OnClick="btnAdd_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <!-- /.row -->
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Sizes for All Brand Products
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <asp:Repeater ID="rptrSizes" runat="server">
                                                    <HeaderTemplate>
                                                        <table class="table table-striped table-bordered table-hover">
                                                            <thead>
                                                                <tr>
                                                                    <th>#</th>
                                                                    <th>Name</th>                                                                                      <th>Brand</th>
                                                                    <th>Category</th>
                                                                    <th>Sub Category</th>
                                                                    <th>Gender</th>
                                                                    <th>Manage</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Eval("SizeID") %></td>
                                                            <td><%# Eval("SizeName") %></td>
                                                            <td><%# Eval("Name") %></td>
                                                            <td><%# Eval("CatName") %></td>
                                                            <td><%# Eval("SubCatName") %></td>
                                                            <td><%# Eval("GenderName") %></td>
                                                            <td><a href='AddSize.aspx?sid=<%# Eval("SizeID") %>'><i class="fa fa-trash-o fa-lg"></i></a>
                                                                |
                                                    <a href='EditSize.aspx?sid=<%# Eval("SizeID") %>'><i class="fa fa-pencil-square-o fa-lg"></i></a>
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

<!-- Bootstrap Core JavaScript -->
<script src="vendor/bootstrap/js/bootstrap.min.js"></script>

<!-- Metis Menu Plugin JavaScript -->
<script src="vendor/metisMenu/metisMenu.min.js"></script>

<!-- Custom Theme JavaScript -->
<script src="dist/js/sb-admin-2.js"></script>
</body>
</html>
