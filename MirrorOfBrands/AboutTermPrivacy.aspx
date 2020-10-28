<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutTermPrivacy.aspx.cs" Inherits="AboutTermPrivacy" ValidateRequest="false" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add About Us, Terms & Conditions, Privacy Policy</title>
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
                                    About us, Term of Service and Privacy Policy
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>About Us</label>
                                                <CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                            </div>

                                            <div class="form-group">
                                                <label>Terms of Service</label>
                                                <CKEditor:CKEditorControl ID="CKEditor2" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                            </div>

                                            <div class="form-group">
                                                <label>Privacy Policy</label>
                                                <CKEditor:CKEditorControl ID="CKEditor3" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                            </div>

                                            <div class="form-group">
                                                <label>Shipping Options</label>
                                                <CKEditor:CKEditorControl ID="CKEditor4" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                            </div>

                                            <div class="form-group">
                                                <label>Return Policy</label>
                                                <CKEditor:CKEditorControl ID="CKEditor5" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                            </div>

                                            <div class="form-group">
                                                <asp:Button ID="btnSubmit" CssClass="btn btn-success" style="border:0;" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" style="border:0;" OnClick="btnUpdate_Click" />
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
                                    About us, Term of Service and Privacy Policy
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <table class="table table-striped table-bordered table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th>#</th>
                                                            <th>About Us</th>
                                                            <th>Terms of Service</th>
                                                            <th>Privacy</th>
                                                            <th>Shipping Options</th>
                                                            <th>Return Policy</th>
                                                            <th>Manage</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td><asp:Label ID="lblID" runat="server"></asp:Label></td>
                                                            <td><asp:Label ID="lblAbout" runat="server"></asp:Label></td>
                                                            <td><asp:Label ID="lblTerms" runat="server"></asp:Label></td>
                                                            <td><asp:Label ID="lblPrivacy" runat="server"></asp:Label></td>
                                                            <td><asp:Label ID="lblShipping" runat="server"></asp:Label></td>
                                                            <td><asp:Label ID="lblReturn" runat="server"></asp:Label></td>
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
