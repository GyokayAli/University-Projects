<%@ Page Title="Settings" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="FYProject.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!--Settings form -->
    <h1>Settings</h1>
    <p>You can change your password using the form below</p>
    <asp:Label AssociatedControlId="oldPassTxtBox" ID="oldPassLbl" runat="server" Text="Old password"></asp:Label>
    <asp:TextBox type="password" ID="oldPassTxtBox" runat="server" BackColor="#333333"></asp:TextBox>
    <asp:RequiredFieldValidator ID="oldPassValid" runat="server" ControlToValidate="oldPassTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Current password missing!</asp:RequiredFieldValidator>
    <asp:Label AssociatedControlId="newPassTxtBox" ID="newPassLbl" runat="server" Text="New password"></asp:Label>
    <asp:TextBox type="password" ID="newPassTxtBox" runat="server" BackColor="#333333"></asp:TextBox>
    <asp:RequiredFieldValidator ID="newPassValid" runat="server" ControlToValidate="newPassTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">New password missing!</asp:RequiredFieldValidator>
    <asp:Label AssociatedControlId="confPassTxtBox" ID="confPassLbl" runat="server" Text="New password again"></asp:Label>
    <asp:TextBox type="password" ID="confPassTxtBox" runat="server" BackColor="#333333"></asp:TextBox>
    <asp:RequiredFieldValidator ID="confPassValid" runat="server" ControlToValidate="confPassTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Re-enter new password!</asp:RequiredFieldValidator>
    <br />
    <asp:Button CssClass="myBtn" ID="settingsButton" runat="server" Text="Submit" OnClick="settingsButton_Click" />
    <asp:Label ID="erroLbl" runat="server" Text=""></asp:Label>
</asp:Content>
