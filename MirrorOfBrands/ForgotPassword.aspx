<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Forogt Password Form -->
    <section class="main-container col1-layout">
        <div class="main container">
            <div class="account-login">
                <div class="col-md-4 hidden-xs"></div>
                <div class="col-lg-6 col-sm-8 col-md-7 col-xs-12">
                    <div class="page-title">
                        <h2>Forgot your password?</h2>
                    </div>
                    <fieldset class="col2-set">
                        <div class="col registered-users">
                            <div class="content">
                                <p>Enter your email address, and we'll send you a link so you can reset your password.</p>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email is Required!" ControlToValidate="tbEmailId" ForeColor="Red"></asp:RequiredFieldValidator>
                                <ul class="form-list">
                                    <li>
                                        <label for="Your Email">Your Email <span class="required">*</span></label>
                                        <br>
                                        <asp:TextBox ID="tbEmailId" runat="server" CssClass="input-text required-entry" placeholder="Enter your Email ID"></asp:TextBox>
                                        <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email Format!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbEmailId" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </li>
                                </ul>
                                <div class="buttons-set">
                                    <asp:Button ID="btPassRec" runat="server" Text="Reset My Password" CssClass="btn btn-info btn-round-lg btn-lg" OnClick="btPassRec_Click" />
                                </div>
                                <asp:Label ID="lblPassRec" runat="server"></asp:Label>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </section>
            <!-- /Forogt Password Form -->
</asp:Content>

