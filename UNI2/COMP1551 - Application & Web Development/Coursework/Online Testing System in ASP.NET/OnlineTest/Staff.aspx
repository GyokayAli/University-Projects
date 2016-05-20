<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="OnlineTest.Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
     <div class="wrapper col2">
        <br />
&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Welcome to your Portal"></asp:Label>
         <br />
         <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
         <asp:Button ID="CreateTestButton" runat="server" Height="106px" Text="Create Test" Width="150px" BackColor="#00CC66" OnClick="CreateTestButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="CheckTestButton" runat="server" Height="106px" Text="Check Test Results" Width="150px" BackColor="#00CC66" OnClick="CheckTestButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="FeedbackButton" runat="server" Height="106px" Text="Send Feedback" Width="150px" BackColor="#00CC66" OnClick="FeedbackButton_Click" />
        <br />
&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />

        </div>
</asp:Content>
