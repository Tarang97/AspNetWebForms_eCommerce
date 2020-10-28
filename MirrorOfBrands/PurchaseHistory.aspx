<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PurchaseHistory.aspx.cs" Inherits="PurchaseHistory" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order History</title>
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
            <!-- Modal -->
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content col-lg-12">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="myModalLabel">Edit Order Status</h4>
                        </div>
                        <div class="modal-body col-lg-12">
                            <div class="col-lg-12">
                                <div class="table-responsive">
                                    <table class="table table-bordered table-striped table-hover">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>User Name</th>
                                                <th>User Email</th>
                                                <th>Product Name</th>
                                                <th>Product Price</th>
                                                <th>Product Discount</th>
                                                <th>Size Name</th>
                                                <th>Quantity</th>
                                                <th>Delivery Option</th>
                                                <th>Cart Amount</th>
                                                <th>Cart Discount</th>
                                                <th>Total Payed</th>
                                                <th>Payment Type</th>
                                                <th>Payment Status</th>
                                                <th>Order Status</th>
                                                <th>Courier</th>
                                                <th>Date Of Purchase</th>
                                                <th>Name</th>
                                                <th>Address</th>
                                                <th>PinCode</th>
                                                <th>Mobile No.</th>
                                                <th>City</th>
                                                <th>State</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><asp:Label ID="lblID" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="lblUserName" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="lblUEmail" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="lblPName" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="lblPPrice" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="PrdDisc" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="Size" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="Qty" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="Delivery" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="CartA" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="CartD" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="TotalP" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="PayT" runat="server"></asp:Label></td>
                                                <td><asp:DropDownList ID="ddlPayS" CssClass="form-control" runat="server">
                                                    <asp:ListItem Value="0">Not Paid</asp:ListItem>
                                                    <asp:ListItem Value="1">Paid</asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td><asp:DropDownList ID="ddlOS" CssClass="form-control" runat="server">
                                                    <asp:ListItem Value="0">Received</asp:ListItem>
                                                    <asp:ListItem Value="1">Processed</asp:ListItem>
                                                    <asp:ListItem Value="2">Dispatched</asp:ListItem>
                                                    <asp:ListItem Value="3">Out for Delivery</asp:ListItem>
                                                    <asp:ListItem Value="4">Delivered</asp:ListItem>
                                                    <asp:ListItem Value="5">Canceled</asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td><asp:Label ID="Courier" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="DateOP" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="Name" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="Address" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="PinCode" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="Mobile" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="City" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="State" runat="server"></asp:Label></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" BorderStyle="None" OnClick="btnUpdate_Click" Text="Update" />
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->
            <!-- Navigation -->
            <ah:Header ID="AdminHeader" runat="server" />

            <!-- Page Content -->
            <div id="page-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Order History</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    All Orders
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <asp:Repeater ID="rptrPurchase" runat="server">
                                                    <HeaderTemplate>
                                                        <table class="table table-striped table-bordered table-hover">
                                                            <thead>
                                                                <tr>
                                                                    <th>#</th>
                                                                    <th>User Name</th>
                                                                    <th>User Email</th>
                                                                    <th>Product Name</th>
                                                                    <th>Product Price</th>
                                                                    <th>Product Discount</th>
                                                                    <th>Size Name</th>
                                                                    <th>Quantity</th>
                                                                    <th>Delivery Option</th>
                                                                    <th>Cart Amount</th>
                                                                    <th>Cart Discount</th>
                                                                    <th>Total Payed</th>
                                                                    <th>Payment Type</th>
                                                                    <th>Payment Status</th>
                                                                    <th>Order Status</th>
                                                                    <th>Courier</th>
                                                                    <th>Date Of Purchase</th>
                                                                    <th>Name</th>
                                                                    <th>Address</th>
                                                                    <th>PinCode</th>
                                                                    <th>Mobile No.</th>
                                                                    <th>City</th>
                                                                    <th>State</th>
                                                                    <th>Manage</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Eval("OrderID") %></td>
                                                            <td><%# Eval("UserName") %></td>
                                                            <td><%# Eval("Email") %></td>
                                                            <td><%# Eval("PName") %></td>
                                                            <td><%# Eval("PSelPrice") %></td>
                                                            <td><%# Eval("PDiscount") %>% Off</td>
                                                            <td><%# Eval("SizeName") %></td>
                                                            <td><%# Eval("Quantity") %></td>
                                                            <td><%# Eval("DeliveryOpt") %></td>
                                                            <td><%# Eval("CartAmount") %></td>
                                                            <td><%# Eval("CartDiscount") %></td>
                                                            <td><%# Eval("TotalPayed") %></td>
                                                            <td><%# Eval("PaymentType") %></td>
                                                            <td><%# Eval("PaymentStatus") %></td>
                                                            <td><%# Eval("OrderStatus") %></td>
                                                            <td><%# Eval("Courier") %></td>
                                                            <td><%# Eval("DateOfOrder") %></td>
                                                            <td><%# Eval("Name") %></td>
                                                            <td><%# Eval("Address") %></td>
                                                            <td><%# Eval("PinCode") %></td>
                                                            <td><%# Eval("MobileNo") %></td>
                                                            <td><%# Eval("City") %></td>
                                                            <td><%# Eval("State") %></td>
                                                            <td><a href="PurchaseHistory.aspx?phid=<%# Eval("OrderID") %>"><i class="fa fa-pencil-square-o fa-lg"></i></a></td>
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
