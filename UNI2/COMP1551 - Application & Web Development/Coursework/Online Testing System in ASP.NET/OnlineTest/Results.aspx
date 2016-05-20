<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="OnlineTest.Results" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    <div class ="wrapper col2">
        <br />
        &nbsp;<h1>&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Results"></asp:Label>
        </h1>
&nbsp;&nbsp;
        <asp:Image ID="Image1" runat="server" Height="306px" ImageUrl="~/images/Exam-Results.jpg" Width="630px" />
        <asp:Panel ID="Panel1" runat="server" Width="645px">
        </asp:Panel>
&nbsp;<br />
&nbsp;Test:
        <asp:Label ID="lblTest" runat="server" Font-Bold="True" ForeColor="Red" Text="Label"></asp:Label>
        <br />
&nbsp;Course:
        <asp:Label ID="lblCourse" runat="server" Font-Bold="True" ForeColor="Red" Text="Label"></asp:Label>
        <br />
&nbsp;No. of Questions:
        <asp:Label ID="lblNo" runat="server" Font-Bold="True" ForeColor="Red" Text="Label"></asp:Label>
        <br />
&nbsp;Starting Time:
        <asp:Label ID="lblStart" runat="server" Font-Bold="True" ForeColor="Red" Text="Label"></asp:Label>
        <br />
&nbsp;Time taken to Complete:
        <asp:Label ID="lblDuration" runat="server" Font-Bold="True" ForeColor="Red" Text="Label"></asp:Label>
        <br />
&nbsp;End Time:
        <asp:Label ID="lblEnd" runat="server" Font-Bold="True" ForeColor="Red" Text="Label"></asp:Label>
        <br />
&nbsp;Score:
        <br />
&nbsp;Grade:<br />
        <h1>
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </h1>
&nbsp;
        <asp:Button ID="FinishButton" runat="server" OnClick="FinishButton_Click" Text="Finish" />
        <br />
        <br />
        </div>
</asp:Content>
