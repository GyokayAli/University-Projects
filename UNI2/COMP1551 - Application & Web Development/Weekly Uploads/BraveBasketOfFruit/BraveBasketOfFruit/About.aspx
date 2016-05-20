<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BasketOfFruit.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Choose a drink mixer</h3>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Fruit:"></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="30px" Width="104px">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Desired beverage:"></asp:Label>
&nbsp;<asp:DropDownList ID="DropBeverage" runat="server" AutoPostBack="True" Height="30px">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="3.00">Wine</asp:ListItem>
            <asp:ListItem Value="2.80">Cider</asp:ListItem>
            <asp:ListItem Value="1.50">Fresh juice</asp:ListItem>
            <asp:ListItem Value="4.00">Cocktail</asp:ListItem>
            <asp:ListItem Value="2.50">Smoothie</asp:ListItem>
            <asp:ListItem Value="1.20">Lemonade</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropBeverage" ErrorMessage="Choose a beverage!" ForeColor="Red"></asp:RequiredFieldValidator>
    &nbsp;</p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Amount of fruit (kg):"></asp:Label>
&nbsp;<asp:TextBox ID="TbxFruitWeight" runat="server" Width="39px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TbxFruitWeight" ErrorMessage="Required field!" ForeColor="Red"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Mix everything" Width="150px" OnClick="Button1_Click" />
    </p>
    <p>
        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="103px" Width="579px"></asp:ListBox>
    </p>
    <p>
        <img src="Images/menu.png" style="width: 187px; height: 229px" /></p>
    <p>
        &nbsp;</p>
    </asp:Content>
