<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="freecycle._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Label ID="Label1" runat="server" Text="imgID"></asp:Label>
    <asp:TextBox ID="imgID" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="imgName"></asp:Label>
    <asp:TextBox ID="imgName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="image"></asp:Label>
    <asp:FileUpload ID="fileUp" runat="server" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="itemID"></asp:Label>
    <asp:TextBox ID="itemID" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
</asp:Content>
