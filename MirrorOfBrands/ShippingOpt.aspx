<%@ Page Title="Shipping Policy" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="ShippingOpt.aspx.cs" Inherits="ShippingOpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Breadcrumbs -->
    <div class="breadcrumbs">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <ul>
                        <li class="home"><a href="Index.aspx" title="Go to Home Page">Home</a> <span>/</span> </li>
                        <li><strong>Shipping Options</strong> </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumbs End -->
    <!-- main-container -->
    <div class="main-container col2-right-layout">
        <div class="main container">
            <div class="row">
                <section class="col-sm-12">
                    <div class="col-main">
                        <div class="page-title">
                            <h2>Shipping Policy</h2>
                        </div>
                        <div class="static-contain">
                            <p><asp:Label ID="lblShipping" runat="server"></asp:Label></p>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <!--End main-container -->
</asp:Content>

