<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="PageNotFound.aspx.cs" Inherits="PageNotFound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-wrapper">
        <div class="container">
            <div class="std">
                <div class="page-not-found">
                    <h2>404</h2>
                    <asp:Image ID="Image1" runat="server" Width="150" Height="150" ImageUrl="~/images/products/signal.png" CssClass="img-responsive" Style="align-content: center;" />
                    <h4>Error:</h4>
                    <p></p>
                    <asp:Label ID="NotFoundErrorMsg" runat="server" Font-Size="Large" ForeColor="Red" Text="We are sorry, the page you requested cannot be found. The URL may be misspelled or the page you're looking for is no longer available."></asp:Label>
                    <div style="margin-top:35px;"><a href="Index.aspx" type="button" class="btn-home"><span>Back To Home</span></a></div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

