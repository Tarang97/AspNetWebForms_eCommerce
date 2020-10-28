<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- breadcrumbs -->
    <div class="breadcrumbs">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <ul>
                        <li class="home"><a title="Go to Home Page" href="Index.aspx">Home</a> <span>/</span> </li>
                        <li class="category1601"><strong>Contact Us</strong> </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- main-container -->
    <div class="main-container col2-right-layout">
        <div class="main container">
            <div class="row">
                <section class="col-sm-9 wow">
                    <div class="col-main">
                        <div class="page-title">
                            <h2>Contact Us</h2>
                        </div>
                        <div class="page-title">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="static-contain">
                            <fieldset class="group-select">
                                <ul>
                                    <li id="billing-new-address-form">
                                        <fieldset>

                                            <input type="hidden" name="billing[address_id]" value="" id="billing:address_id">
                                            <ul>
                                                <li>
                                                    <div class="customer-name">
                                                        <div class="input-box name-firstname">
                                                            <label for="billing:firstname">Name<span class="required">*</span></label>
                                                            <br>
                                                            <asp:TextBox ID="txtFullName" CssClass="input-text" runat="server"></asp:TextBox>
                                                            <br />
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFullName" FilterType="UppercaseLetters, LowercaseLetters, Custom" ValidChars=" " />
                                                        </div>
                                                        <div class="input-box name-lastname">
                                                            <label for="billing:lastname">Email Address <span class="required">*</span> </label>
                                                            <br>
                                                            <asp:TextBox ID="txtEmail" CssClass="input-text" runat="server"></asp:TextBox>
                                                            <br />
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtEmail" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom" ValidChars=".@_" />
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <label for="billing:street1">Subject <span class="required">*</span></label>
                                                    <br>
                                                    <asp:TextBox ID="txtSubject" CssClass="input-text required-entry" runat="server"></asp:TextBox>
                                                    <br />
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtSubject" FilterType="UppercaseLetters, LowercaseLetters, Custom" ValidChars=" " />
                                                </li>
                                                <li class="">
                                                    <label for="comment">Comments<em class="required">*</em></label>
                                                    <br>
                                                    <div style="float: none" class="">
                                                        <asp:TextBox ID="txtComments" TextMode="MultiLine" CssClass="required-entry input-text" runat="server"></asp:TextBox>
                                                        <br />
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtComments" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom" ValidChars="? " />
                                                    </div>
                                                </li>
                                            </ul>
                                        </fieldset>
                                    </li>
                                    <li>
                                        <p class="require"><em class="required">* </em>Required Fields</p>
                                    </li>
                                    <li>
                                        <div class="buttons-set">
                                            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" CssClass="button submit" Text="Submit" />
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                        </div>
                    </div>
                </section>
                <aside class="col-right sidebar col-sm-3 wow">
                    <div class="block block-company">
                        <div class="block-title">Mirror Of Brands </div>
                        <div class="block-content">
                            <ol id="recently-viewed-items">
                                <li class="item odd"><a href="About.aspx">About Us</a></li>
                                <li class="item odd"><a href="Terms-Condition.aspx">Terms &amp; Conditions</a></li>
                                <li class="item odd"><a href="Privacy.aspx">Privacy Policy</a></li>
                                <li class="item last"><strong>Contact Us</strong></li>
                            </ol>
                        </div>
                    </div>
                </aside>
            </div>
        </div>
    </div>
    <!--End main-container -->

    <!-- Google Map Location -->
    <div class="main-container col2-right-layout">
        <div class="main container">
            <div class="row">
                <section class="col-sm-9 wow">
                    <div class="col-main">
                        <div class="page-title">
                            <h2>Our Location</h2>
                        </div>
                        <hr />
                        <div id="map" style="height:350px;width:100%;">
                        </div>
                        <script>
                            function initMap() {
                                // The location of Uluru
                                var uluru = { lat: 23.039779, lng: 72.558658 };
                                // The map, centered at Uluru
                                var map = new google.maps.Map(
                                    document.getElementById('map'), { zoom: 17, center: uluru });
                                // The marker, positioned at Uluru
                                var marker = new google.maps.Marker({ position: uluru, map: map });
                            }
                        </script>
                        <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBd8GjQzvKWk47lczx3bam9A9OP_3BnK_w&callback=initMap"></script>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <br />
</asp:Content>

