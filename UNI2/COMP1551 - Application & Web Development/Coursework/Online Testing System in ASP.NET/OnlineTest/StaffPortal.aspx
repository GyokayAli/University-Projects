<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffPortal.aspx.cs" Inherits="OnlineTest.StaffPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    &nbsp;<h1><asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Enter your secret key to continue"></asp:Label>
    </h1>
    <br />
    <br />
&nbsp;<asp:Label ID="Label1" runat="server" Text="Please enter your secret key:"></asp:Label>
&nbsp;<asp:TextBox ID="PassBox" runat="server" TextMode="Password"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PassBox" ErrorMessage="Required field!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
&nbsp;Hint: admin&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="LoginButton" runat="server" OnClick="passButton_Click1" Text="Login" Width="57px" />
&nbsp;&nbsp;&nbsp;&nbsp;<br />
    <br />
    &nbsp;&nbsp;<h1>
        <asp:Label ID="Label3" runat="server"></asp:Label>
    </h1>
&nbsp; 

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
