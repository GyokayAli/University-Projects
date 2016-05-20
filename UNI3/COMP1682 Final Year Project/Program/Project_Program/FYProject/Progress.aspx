<%@ Page Title="Progress" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Progress.aspx.cs" Inherits="FYProject.Progress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 

    <!--User progress details -->
    <h1>Progress</h1>
    <p>Check your performance details</p>
    <asp:Label ID="levelLbl" runat="server" Text="Level --> ">
        <asp:Label ID="userLvlLbl" runat="server" Text="1"></asp:Label></asp:Label>
    <asp:Label ID="expLbl" runat="server" Text="Exp --> ">
        <asp:Label ID="userExpLbl" runat="server" Text="0.0%"></asp:Label></asp:Label>

    <div id="progressbar"></div>


</asp:Content>
