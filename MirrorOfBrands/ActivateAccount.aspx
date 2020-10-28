<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActivateAccount.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account Activation</title>
    <meta name="title" content="Mirror of Brands" />
    <meta name="description" content="MirrorofBrands.com: Online Shopping India - Buy mobiles, cameras, watches, apparel, shoes. Free Shipping & Cash on Delivery Available." />
    <meta name="keywords" content="MirrorofBrands.com, Mirror, Online Shopping, online shopping india, india shopping online, mirror of brands india, mob, buy online, buy mobiles online, watches, fashion jewellery, electronic products, apparels, accessories, audio devices, audio appliances" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <meta name="language" content="English" />
    <meta name="google" content="nositelinksearchbox" />
    <meta name="google-site-verification" content="w8RRvIuUXpS_LrxW40BMikUIVeICYTlqFaxdNiyvlv4" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="myModalLabel">Please Check your Email for Activation Code to Activate your Account.</h5>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label>Activation Code</label>
                            <asp:TextBox ID="tbActivate" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnBack" CssClass="btn btn-default" Style="border: 0;" runat="server" Text="Close" PostBackUrl="~/Signup.aspx" />
                        <asp:Button ID="btnActivate" CssClass="btn btn-primary" OnClick="btnActivate_Click" Style="border: 0;" runat="server" Text="Activate" />
                    </div>
                </div>
            </div>
        </div>
    </form>

<script src="https://code.jquery.com/jquery-3.3.1.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function ShowPopup() {
        $("#myModal").modal("show");
    });
</script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
