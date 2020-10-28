<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditSize.aspx.cs" Inherits="EditSize" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Sizes</title>
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
                    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Edit Size
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>Size Name</label>
                                                <asp:TextBox ID="txtSName" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Category</label>
                                                <asp:DropDownList ID="ddlCategory" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Brands</label>
                                                <asp:DropDownList ID="ddlBrands" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Sub Category</label>
                                                <asp:DropDownList ID="ddlSubCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Gender</label>
                                                <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <asp:Button ID="btnUpdateSize" runat="server" OnClick="btnUpdateSize_Click" CssClass="btn btn-success" Text="Update" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <label style="color: red;text-align:justify;"><strong style="color: black;">Note</strong>:- Please Update all the fields even if you want to keep the things as it is because that is gonna update your particular product size successfully.<br /><br />
                              <strong style="color: black;">For example</strong>:- If you're not changing brand, category, subcategory, gender, and size name then no problem but, if you're changing only one field then also select other as it is when you selected the things at the time of adding size.</label>
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
