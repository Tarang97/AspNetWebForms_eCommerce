<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Callback.aspx.cs" Inherits="Callback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirmation & Payment Receipt</title>
    <meta name="title" content="Mirror of Brands" />
    <meta name="description" content="MirrorofBrands.com: Online Shopping India - Buy mobiles, cameras, watches, apparel, shoes. Free Shipping & Cash on Delivery Available." />
    <meta name="keywords" content="MirrorofBrands.com, Mirror, Online Shopping, online shopping india, india shopping online, mirror of brands india, mob, buy online, buy mobiles online, watches, fashion jewellery, electronic products, apparels, accessories, audio devices, audio appliances" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <meta name="language" content="English" />
    <meta name="google" content="nositelinksearchbox" />
    <meta name="google-site-verification" content="w8RRvIuUXpS_LrxW40BMikUIVeICYTlqFaxdNiyvlv4" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" style="width: 80%; margin-top: 20px;">
            <div class="jumbotron jumbotron-fluid">
                <div class="container">
                    <asp:Image ID="Image1" CssClass="img-responsive" Style="float: right;" ImageUrl="images/MirrorOfBrands.png" runat="server" />
                    <h1 class="display-4">
                        <asp:Label ID="lblOrder" runat="server"></asp:Label></h1>
                    <p class="lead">
                        <asp:Label ID="lbltxnID" runat="server"></asp:Label><br />
                        <asp:Label ID="lbltID" runat="server" Text="Label"></asp:Label>
                        <label>Your Order will be Processed in 24 to 48 hrs after the Confirmation.</label>
                    </p>
                    <hr class="my-4">
                    <p>Click below to go at Home Page. You'll soon receive and email from us about your Order Confirmation and Payment Receipt.</p>
                    <asp:LinkButton ID="lbhome" CssClass="btn btn-primary btn-lg" PostBackUrl="~/Index.aspx" runat="server">Got to Home Page</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
<script src="http://code.jquery.com/jquery-3.3.1.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
</body>
</html>
