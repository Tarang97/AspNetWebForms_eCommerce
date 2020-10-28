<%@ Page Title="Error...Page Not Found!" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="NotFound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- main-container -->
    <section class="content-wrapper">
        <div class="container">
            <div class="std">
                <div class="page-not-found">
                    <h2>500</h2>
                    <asp:Image ID="Image1" runat="server" Width="150" Height="150" ImageUrl="~/images/products/signal.png" CssClass="img-responsive" style="align-content:center;" />
                    <h4>Error:</h4>
                    <p></p>
                    <asp:Label ID="FriendlyErrorMsg" runat="server" Font-Size="Large" ForeColor="Red" Text="An Error has been encountered while processing your request. Error description has been sent to Administrator for a proper analysis. You can surf the site by clicking below."></asp:Label>  
                    <div style="margin-top:35px;"><a href="Index.aspx" type="button" class="btn-home"><span>Back To Home</span></a></div>
                </div>
            </div>
        </div>
    </section>
    <!--End main-container -->
</asp:Content>

