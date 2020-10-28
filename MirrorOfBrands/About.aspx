<%@ Page Title="About Us" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Breadcrumbs -->
    <div class="breadcrumbs">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <ul>
                        <li class="home"><a href="Index.aspx" title="Go to Home Page">Home</a> <span>/</span> </li>
                        <li><strong>About Us</strong> </li>
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
                <section class="col-sm-9">
                    <div class="col-main">
                        <div class="page-title">
                            <h2>About Us</h2>
                        </div>
                        <div class="static-contain">
                            <p><asp:Label ID="lblAboutUs" runat="server"></asp:Label></p>
                        </div>
                    </div>
                </section>
                <aside class="col-right sidebar col-sm-3 wow">
                    <div class="block block-company">
                        <div class="block-title">Mirror of Brands </div>
                        <div class="block-content">
                            <ol id="recently-viewed-items">
                                <li class="item odd"><strong>About Us</strong></li>
                                <li class="item even"><a href="Sitemap.aspx">Sitemap</a></li>
                                <li class="item  odd"><a href="Terms-Condition.aspx">Terms of Service</a></li>
                                <li class="item even"><a href="Privacy.aspx"></a>Privacy Policy</li>
                                <li class="item last"><a href="Contact.aspx">Contact Us</a></li>
                            </ol>
                        </div>
                    </div>
                </aside>
            </div>
        </div>
    </div>
    <!--End main-container -->
</asp:Content>

