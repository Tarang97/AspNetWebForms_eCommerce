<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromoCode.aspx.cs" Inherits="PromoCode" %>
<%@ Register Src="~/AdminHeader.ascx" TagPrefix="ah" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Coupon Code</title>
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

    <!-- Calender CSS -->
    <link href="dist/css/calendar-blue.css" rel="stylesheet" />

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

                    <div class="row">
                        <div class="col-lg-6">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Create Coupon
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                                            <div class="form-group">
                                                <label>Coupon Code</label>
                                                <asp:TextBox ID="tbCouponCode" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Discount (%)</label>
                                                <asp:TextBox ID="tbDiscount" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Max Discount (Rs.)</label>
                                                <asp:TextBox ID="tbMaxDiscount" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Expire Date</label>
                                                <asp:TextBox ID="tbExpire" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                <img src="images/AdminImages/calender.png" />
                                            </div>

                                            <div class="form-group">
                                                <label>User Name: &nbsp;&nbsp;&nbsp;</label>
                                                <div class="checkbox-inline">
                                                    <asp:CheckBoxList ID="cblUser" CssClass="myCheckBoxList" onclick="GetSelectedCentralValue();" RepeatDirection="Vertical" runat="server">
                                                    </asp:CheckBoxList>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <asp:Button ID="btnCoupon" CssClass="btn btn-success" Style="border: 0;" runat="server" Text="Create" OnClick="btnCoupon_Click" />
                                                <asp:Button ID="btnUpdateCoupon" CssClass="btn btn-primary" BorderStyle="None" runat="server" Text="Update" OnClick="btnUpdateCoupon_Click" />
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
                                    Create Coupon
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <asp:Repeater ID="rptrCoupon" runat="server">
                                                    <HeaderTemplate>
                                                        <table class="table table-striped table-bordered table-hover">
                                                            <thead>
                                                                <tr>
                                                                    <th>#</th>
                                                                    <th>Coupon Code</th>
                                                                    <th>Discount (%)</th>
                                                                    <th>Max Discount (Rs.)</th>
                                                                    <th>Expire date</th>
                                                                    <th>User Name</th>
                                                                    <th>Used(1)/Not Used(0)</th>
                                                                    <th>Manage</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Eval("CouponID") %></td>
                                                            <td><%# Eval("CouponCode") %></td>
                                                            <td><%# Eval("Discount") %></td>
                                                            <td><%# Eval("MaxDiscount") %></td>
                                                            <td><%# Eval("ExpireDate") %></td>
                                                            <td><%# Eval("Name") %></td>
                                                            <td><%# Eval("IsUsed") %></td>
                                                            <td><a href='PromoCode.aspx?pcid=<%# Eval("CouponID") %>' title="Delete"><i class="fa fa-trash-o fa-lg"></i></a>
                                                                |
                                                                <a href='PromoCode.aspx?del=<%# Eval("UserID") %>' title="Edit"><i class="fa fa-pencil-square-o fa-lg"></i></a>
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

<!-- Jquery Calender -->
<script src="admin_js/jquery.dynDateTime.min.js"></script>
<script src="admin_js/calendar-en.min.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=tbExpire.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%m/%d/%Y %H:%M",
            daFormat: "%l;%M %p, %e %m, %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
</script>
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
