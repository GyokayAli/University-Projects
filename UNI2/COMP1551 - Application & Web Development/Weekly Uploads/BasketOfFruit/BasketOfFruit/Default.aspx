<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BasketOfFruit._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 style="height: 47px">The Fruit Basket application</h1>
        <div class="col-md-4">
            <p>
                <asp:Label ID="Label4" runat="server" Text="Fruit name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TbxName" runat="server"></asp:TextBox>
&nbsp;edible?<asp:CheckBox ID="CheckBox1" runat="server" />
&nbsp;</p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Fruit weight (g):"></asp:Label>
&nbsp;<asp:TextBox ID="TbxWeight" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Fruit calories (per g):"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TbxCal" runat="server"></asp:TextBox>
            </p>
            <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add the fruit info to my list" />
            </p>
            <p>
                <asp:ListBox ID="ListBox1" runat="server" Height="132px" Width="513px"></asp:ListBox>
            </p>
        </div>
        <div class="col-md-4">
        </div>
    </div>

</asp:Content>
