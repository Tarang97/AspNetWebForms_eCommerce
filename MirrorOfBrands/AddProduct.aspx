<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AddProduct" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Products</title>
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
                                    Add Products
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Product Name</label>
                                                <asp:TextBox ID="txtPName" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="txtPName" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group input-group">
                                                <span class="input-group-addon">&#8377;</span>
                                                <asp:TextBox ID="txtPPrice" runat="server" CssClass="form-control" placeholder="Product Price"></asp:TextBox>
                                                <span class="input-group-addon">.00</span>
                                            </div>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="txtPPrice" ForeColor="Red"></asp:RequiredFieldValidator>

                                            <div class="form-group input-group">
                                                <span class="input-group-addon">&#8377;</span>
                                                <asp:TextBox ID="txtSelPrice" runat="server" CssClass="form-control" placeholder="Selling Price"></asp:TextBox>
                                                <span class="input-group-addon">.00</span>
                                            </div>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="txtSelPrice" ForeColor="Red"></asp:RequiredFieldValidator>

                                            <div class="form-group">
                                                <label>Category</label>
                                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </div>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="ddlCategory" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>

                                            <div class="form-group">
                                                <label>Brand</label>
                                                <asp:DropDownList ID="ddlBrands" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="ddlBrands" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>

                                            <div class="form-group">
                                                <label>Sub Category</label>
                                                <asp:DropDownList ID="ddlSubCategory" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="ddlSubCategory" ForeColor="Red"></asp:RequiredFieldValidator>

                                            <div class="form-group">
                                                <label>Gender</label>
                                                <asp:DropDownList ID="ddlGender" OnSelectedIndexChanged="ddlGender_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Size:&nbsp;&nbsp;&nbsp;</label>
                                                <div class="checkbox-inline">
                                                    <asp:CheckBoxList ID="cblSize" runat="server" RepeatDirection="Vertical"></asp:CheckBoxList>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label>Quantity</label>
                                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="txtQuantity" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <label>Description</label>
                                                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="txtDesc" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <label>Product Details</label>
                                                <asp:TextBox ID="txtPDetails" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="txtPDetails" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <label>Material and Care</label>
                                                <asp:TextBox ID="txtMatCare" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="txtMatCare" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <label>Images:</label>
                                                <asp:FileUpload ID="fuImg01" runat="server" CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="fuImg01" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <asp:FileUpload ID="fuImg02" CssClass="form-control" runat="server" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="fuImg02" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <asp:FileUpload ID="fuImg03" CssClass="form-control" runat="server" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="fuImg03" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <asp:FileUpload ID="fuImg04" CssClass="form-control" runat="server" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="This Field is Required!" ForeColor="Red" ControlToValidate="fuImg04"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <asp:FileUpload ID="fuImg05" CssClass="form-control" runat="server" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="fuImg05" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="This Field is Required!" ControlToValidate="txtDiscOffer" ForeColor="Red"></asp:RequiredFieldValidator>
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
