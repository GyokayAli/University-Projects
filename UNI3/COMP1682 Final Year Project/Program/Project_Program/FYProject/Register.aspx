<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FYProject.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Registration form -->
    <h1>Registration</h1>
    <p>Please fill in your details below</p>
    <asp:Label AssociatedControlId="usernameTxtBox" ID="userbaneLbl" runat="server" Text="Username"></asp:Label>
    <asp:TextBox ID="usernameTxtBox" runat="server" BackColor="#333333"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="usernameTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Username missing!</asp:RequiredFieldValidator>
    <asp:Label AssociatedControlId="emailTxtBox" ID="emailLbl" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="emailTxtBox" runat="server" BackColor="#333333"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="emailTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Email missing!</asp:RequiredFieldValidator>
    <asp:Label AssociatedControlId="passTxtBox" ID="passLbl" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="passTxtBox" type="password" runat="server" BackColor="#333333"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="passTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Password missing!</asp:RequiredFieldValidator>
    <asp:Label AssociatedControlId="confTxtBox" ID="confLbl" runat="server" Text="Cofirm password"></asp:Label>
    <asp:TextBox ID="confTxtBox" type="password" runat="server" BackColor="#333333"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="confTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Confirm password!</asp:RequiredFieldValidator>
    <br />
    <asp:Button CssClass="myBtn" ID="regButton" runat="server" Text="Submit" OnClick="regButton_Click" />

    <!-- regex to validate email (not the best possible one)-->
    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailTxtBox" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator><br/>
    <!-- regex for alphanumeric user name that allows underscore with length 3-30 -->
    <asp:RegularExpressionValidator ID="regexUsernameValid" runat="server" ValidationExpression="^[a-zA-Z0-9][a-zA-Z0-9_]{4,29}$" ControlToValidate="usernameTxtBox" ErrorMessage="Invalid Username Format (5 - 15 characters)"></asp:RegularExpressionValidator><br/>
    <!-- regex for alphanumeric password with length 5-15 and at least one digit -->
    <asp:RegularExpressionValidator ID="regexPassValid" runat="server" ValidationExpression="^(?=.*\d).{4,14}$" ControlToValidate="passTxtBox" ErrorMessage="Invalid Password Format (5 - 15 alphanumeric characters)"></asp:RegularExpressionValidator><br/>

    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
</asp:Content>
