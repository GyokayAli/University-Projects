<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="OnlineTest.Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    <div class="wrapper col2">
        <br />
        &nbsp;<h1>&nbsp; <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Sit an online test"></asp:Label>
        </h1>
&nbsp; Choose course:
&nbsp;<asp:DropDownList ID="CourseDropDown" runat="server" Height="25px" Width="108px">
        </asp:DropDownList>
        <br />
        <br />
&nbsp;<asp:Label ID="Label3" runat="server" Text="Check for available tests:"></asp:Label>
&nbsp;<asp:DropDownList ID="TestDropDown" runat="server" Height="21px" Width="405px">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <br />
        &nbsp;<br />
&nbsp;<asp:Label ID="Label4" runat="server" Text="Please enter the secret key:"></asp:Label>
&nbsp;<asp:TextBox ID="SecretBox" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="ProceedButton" runat="server" OnClick="ProceedButton_Click" Text="Proceed" />
        
        <br />
&nbsp;<asp:Label ID="Label5" runat="server" Text="Hint: openbook"></asp:Label>
        <br />
        <br />
        &nbsp;<br />
        <h1>
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </h1>
        <br />
        <br />
        </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
