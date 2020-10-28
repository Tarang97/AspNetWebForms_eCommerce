<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" Debug="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Register Form -->
    <section class="main-container col1-layout">
        <div class="main container">
            <div class="account-login">
                <div class="col-md-4 hidden-xs"></div>
                <div class="col-lg-6 col-sm-8 col-md-7 col-xs-12">
                    <div class="page-title">
                        <h2>Create an Account</h2>
                    </div>
                    <fieldset class="col2-set">
                        <div class="col registered-users">
                            <div class="content">
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                <asp:Label ID="lblError" runat="server"></asp:Label>
                                <p>Please fill in this form to create an account.</p>
                                <ul class="form-list">
                                    <li>
                                        <label for="Name">Name <span class="required">*</span></label>
                                        <br />
                                        <asp:TextBox ID="tbName" runat="server" CssClass="input-text required-entry"></asp:TextBox><br />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tbName" FilterType="UppercaseLetters, LowercaseLetters, Custom" ValidChars=" " />
                                    </li>
                                    <li>
                                        <label for="Email">Email <span class="required">*</span></label>
                                        <br />
                                        <asp:TextBox ID="tbEmail" runat="server" CssClass="input-text required-entry" TextMode="Email"></asp:TextBox><br />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="tbEmail" FilterType="Numbers, LowercaseLetters, UppercaseLetters, Custom" ValidChars=".@_" />
                                    </li>
                                    <li>
                                        <label for="Mobile Number">Mobile <span class="required">*</span></label>
                                        <br />
                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="input-text required-entry"></asp:TextBox><br />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtMobileNo" FilterType="Numbers" />
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Mobile Number must be of 10 digits" ControlToValidate="txtMobileNo" ForeColor="Red" MaximumValue="10" MinimumValue="10"></asp:RangeValidator>
                                    </li>
                                    <li>
                                        <label for="Password">Password <span class="required">*</span></label>
                                        <br />
                                        <asp:TextBox ID="tbPass" runat="server" CssClass="input-text required-entry" TextMode="Password"></asp:TextBox><br />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="tbPass" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom" ValidChars="!@#$%" />
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Password length should be more than 8 characters" ForeColor="Red" ControlToValidate="tbPass" MaximumValue="8" MinimumValue="14"></asp:RangeValidator>
                                    </li>
                                    <li>
                                        <label for="Confirm Password">Confirm Password <span class="required">*</span></label>
                                        <br>
                                        <asp:TextBox ID="tbCPass" runat="server" CssClass="input-text required-entry" TextMode="Password"></asp:TextBox><br />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="tbCPass" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom" ValidChars="!@#$%" />
                                    </li>
                                </ul>
                                <p>By creating an account you agree to our <a href="Terms-Condition.aspx" style="color: dodgerblue">Terms & Conditions</a>.</p>
                                <div class="buttons-set">
                                    <asp:Button ID="btSignup" runat="server" Text="Sign Up" CssClass="btn btn-info btn-round-lg btn-lg" OnClick="btSignup_Click" />
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </section>
    <!-- /Register Form -->
</asp:Content>

