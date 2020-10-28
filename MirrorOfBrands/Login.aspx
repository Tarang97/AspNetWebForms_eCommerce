<%@ Page Title="Log In" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Login Form -->
    <section class="main-container col1-layout">
        <div class="main container">
            <div class="account-login">
                <div class="page-title">
                    <h2>Login or Create an Account</h2>
                </div>
                <fieldset class="col2-set">
                    <div class="col-1 new-users">
                        <strong>New Customers</strong>
                        <div class="content">
                            <p>By creating an account with our store, you will be able to move through the checkout process faster, store multiple shipping addresses, view and track your orders in your account and more.</p>
                            <div class="buttons-set">
                                <button onclick="window.location='Signup.aspx';" class="button create-account" type="button"><span>Create an Account</span></button>
                            </div>
                        </div>
                    </div>
                    <div class="col-2 registered-users">
                        <strong>Registered Customers</strong>
                        <div class="content">
                            <asp:Label ID="lblSuccess" runat="server" ForeColor="Green"></asp:Label>
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                            <p>If you have an account with us, please log in.</p>
                            <ul class="form-list">
                                <li>
                                    <label for="email">Email Address <span class="required">*</span></label>
                                    <br />
                                    <asp:TextBox ID="UserEmail" runat="server" CssClass="input-text required-entry" TextMode="SingleLine" placeholder="Email ID"></asp:TextBox>
                                    <br />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="UserEmail" FilterType="LowercaseLetters, Numbers, Custom" ValidChars=".@_" />
                                </li>
                                <li>
                                    <label for="pass">Password <span class="required">*</span></label>
                                    <br />
                                    <asp:TextBox ID="Password" runat="server" CssClass="input-text required-entry validate-password" TextMode="Password" placeholder="Password"></asp:TextBox>
                                    <br />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="Password" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom" ValidChars="!@#$%" />
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" MaximumValue="8" MinimumValue="14" ErrorMessage="Password length should be more than 8 characters" ControlToValidate="Password" ForeColor="Red"></asp:RangeValidator>
                                </li>
                                <li>
                                    <div class="form-check">
                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="" />
                                        <span class="lable-text">Remember Me ?</span>
                                    </div>
                                </li>
                            </ul>
                            <p class="required">* Required Fields</p>
                            <div class="buttons-set">
                                <asp:Button ID="Button1" runat="server" Text="LOG IN" CssClass="btn btn-info btn-round-lg btn-lg" Style="background-color: #0083ff; border: 1px #0083ff solid;" OnClick="Button1_Click" /><br />
                                <br />
                                <asp:LinkButton ID="lbForgotPass" runat="server" PostBackUrl="~/ForgotPassword.aspx">Forgot Password?</asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </section>
    <!-- /Login Form -->
</asp:Content>

