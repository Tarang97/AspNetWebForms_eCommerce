<%@ Page Title="Your Profile" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/custom/userprofile.css" rel="stylesheet" />
    <div class="container" style="background: #F1F3FA;">
        <div class="row profile">
            <div class="col-md-3">
                <div class="profile-sidebar">
                    <!-- SIDEBAR USER TITLE -->
                    <div class="profile-usertitle">
                        <div class="profile-usertitle-name">
                            <span class="hidden-xs"></span>
                        </div>
                        <div class="profile-usertitle-job">
                        </div>
                    </div>
                    <!-- END SIDEBAR USER TITLE -->
                    <!-- SIDEBAR MENU -->
                    <div class="profile-usermenu">
                        <ul class="nav">
                            <li class="active">
                                <a href="UserProfile.aspx">
                                    <i class="glyphicon glyphicon-home"></i>
                                    <span class="hidden-xs">My Profile</span> </a>
                            </li>
                            <li>
                                <a href="MyOrders.aspx">
                                    <i class="glyphicon glyphicon-ok"></i>
                                    <span class="hidden-xs">Your Orders </span><span class="label pull-right" id="spanOCount" runat="server"></span></a>
                            </li>
                            <li>
                                <a href="Wishlist.aspx">
                                    <i class="glyphicon glyphicon-flag"></i>
                                    <span class="hidden-xs">My Wishlist </span><span class="label pull-right" id="spanWCount" runat="server"></span></a>
                            </li>
                        </ul>
                    </div>
                    <!-- END MENU -->
                </div>
            </div>
            <div class="col-md-9 order-content">
                <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                <asp:Label ID="lblError" runat="server"></asp:Label>
                <div class="form_main col-md-4 col-sm-5 col-xs-7">
                    <h4 class="heading"><strong>My </strong>Profile <span></span></h4>
                    <div class="form">
                        <div class="form-group">
                            <label>Name</label>
                            <asp:TextBox ID="txtName" CssClass="input-text required-entry" runat="server"></asp:TextBox><br />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="UppercaseLetters, LowercaseLetters, Custom" ValidChars=" " TargetControlID="txtName" />
                        </div>

                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox ID="txtEmail" CssClass="input-text required-entry" runat="server"></asp:TextBox><br />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtEmail" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom" ValidChars=".@_" />
                        </div>

                        <div class="form-group">
                            <label>Mobile Number</label>
                            <asp:TextBox ID="txtMobileNumber" CssClass="input-text required-entry" runat="server"></asp:TextBox><br />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtMobileNumber" FilterType="Numbers" />
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Mobile Number must be of 10 Digits" ControlToValidate="txtMobileNumber" ForeColor="Red" MaximumValue="10" MinimumValue="10"></asp:RangeValidator>
                        </div>

                        <div class="form-group">
                            <label>Password</label>
                            <asp:TextBox ID="txtPass" CssClass="input-text required-entry" runat="server" TextMode="Password"></asp:TextBox><br />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtPass" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom" ValidChars="!@#$%" />
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Password must be in between of 8 to 14 Characters" ForeColor="Red" ControlToValidate="txtPass" MaximumValue="8" MinimumValue="14"></asp:RangeValidator>
                        </div>

                        <div class="form-group">
                            <label>Confirm Password</label>
                            <asp:TextBox ID="txtCPass" CssClass="input-text required-entry" runat="server" TextMode="Password"></asp:TextBox><br />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtCPass" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom" ValidChars="!@#$%" />
                            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Confirm Password must be in between of 8 to 14 Characters" ForeColor="Red" ControlToValidate="txtCPass" MaximumValue="8" MinimumValue="14"></asp:RangeValidator>
                        </div>

                        <div class="form-group">
                            <asp:Button ID="txtUpdate" OnClick="txtUpdate_Click" runat="server" Text="Update" CssClass="btn btn-primary" style="border:0;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

