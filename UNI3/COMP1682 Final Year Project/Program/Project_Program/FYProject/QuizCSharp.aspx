<%@ Page Title="Quiz C#" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QuizCSharp.aspx.cs" Inherits="FYProject.QuizCSharp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><asp:Label ID="questionLbl" runat="server" Text="The question"></asp:Label></h1>
    <p>Please choose the correct answer out of 4.</p>
    <asp:Label ID="pointLbl" runat="server" Text="Points: "></asp:Label>
    <asp:RadioButtonList ID="radioBtnList" runat="server">
        </asp:RadioButtonList>
    <asp:Button ID="nextBtn" runat="server" Text="Next" OnClick="nextBtn_Click" />
</asp:Content>
