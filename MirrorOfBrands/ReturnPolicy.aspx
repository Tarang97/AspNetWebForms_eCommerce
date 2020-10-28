<%@ Page Title="Return Policy" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="ReturnPolicy.aspx.cs" Inherits="ReturnPolicy" %>

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
                        <li><strong>Return Policy</strong> </li>
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
                            <h2>Return Policy</h2>
                        </div>
                        <div class="static-contain">
                            <p><asp:Label ID="lblReturn" runat="server"></asp:Label></p>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <!--End main-container -->
</asp:Content>

