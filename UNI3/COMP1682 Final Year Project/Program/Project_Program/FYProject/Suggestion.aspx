<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Suggestion.aspx.cs" Inherits="FYProject.Suggestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Please share with us your ideas and suggestions!</h1>
    <asp:TextBox ID="suggTxtBox" runat="server" BackColor="#333333" MaxLength="250" Height="93px" TextMode="MultiLine" Width="558px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="suggTxtBox" ErrorMessage="Field cannot be empty!" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <asp:Button CssClass="myBtn" ID="submitBtn" runat="server" Text="Submit" OnClick="submitBtn_Click"  />

    <asp:Label ID="errorLbl" runat="server"></asp:Label>

</asp:Content>
