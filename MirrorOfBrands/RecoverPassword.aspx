<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs" Inherits="RecoverPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recover Password</title>
    <meta name="title" content="Mirror of Brands" />
    <meta name="description" content="MirrorofBrands.com: Online Shopping India - Buy mobiles, cameras, watches, apparel, shoes. Free Shipping & Cash on Delivery Available." />
    <meta name="keywords" content="MirrorofBrands.com, Mirror, Online Shopping, online shopping india, india shopping online, mirror of brands india, mob, buy online, buy mobiles online, watches, fashion jewellery, electronic products, apparels, accessories, audio devices, audio appliances" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <meta name="language" content="English" />
    <meta name="google" content="nositelinksearchbox" />
    <meta name="google-site-verification" content="w8RRvIuUXpS_LrxW40BMikUIVeICYTlqFaxdNiyvlv4" />

    <!-- Mobile specific metas  -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="stylesheet" type="text/css" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <script type="text/javascript" src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js" type="text/javascript"></script>
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/RecoverPass.css" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-md-4 mx-auto text-center">
                <div class="header-title" style="margin-bottom: 15px;">
                    <img src="images/MirrorOfBrands.png" alt="MirrorOfBrands" style="width: 200px; height: 100px;" />
                    <h2 class="wv-heading--subtitle">Recover Password</h2>
                </div>
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
            </div>
            <div class="row">
                <div class="col-md-4 mx-auto">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter your New Password" ControlToValidate="tbNewPass" ForeColor="Red" Visible="False"></asp:RequiredFieldValidator>
                    <div class="myform form">
                        <div class="form-group">
                            <asp:Label ID="lblPassword" runat="server" Text="New Password" Visible="False"></asp:Label>
                            <asp:TextBox ID="tbNewPass" runat="server" CssClass="form-control my-input" placeholder="New Password" TextMode="Password" Visible="False"></asp:TextBox>
                            <asp:Label ID="lblPassError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblRetypePass" runat="server" Text="Confirm Password" Visible="False"></asp:Label>
                            <asp:TextBox ID="tbConfirmPass" runat="server" CssClass="form-control my-input" placeholder="Re-Type Password" TextMode="Password" Visible="False"></asp:TextBox>
                        </div>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Both Password must be Same!" ControlToCompare="tbNewPass" ControlToValidate="tbConfirmPass" ForeColor="Red" Visible="False"></asp:CompareValidator>

                        <div class="text-center">
                            <asp:Button ID="btRecPass" runat="server" Text="Reset" CssClass="btn btn-block send-button tx-tfm" Visible="False" OnClick="btRecPass_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
