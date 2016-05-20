<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppRestaurantSystem.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="sectiontitle">Login</h2>
    <ul class="nospace group btmspace-80">
      <li class="one_third first"><article class="service"><i class=""></i></article></li>
      <li class="one_third">
        <article class="service"><i class=""></i>
        <!--LOGIN FORM -->
            <h2 class="sectiontitle">
                <asp:Label AssociatedControlId="emailTxtBox" ID="emailLbl" runat="server" Text="Email"></asp:Label>
            </h2>  
            <asp:TextBox CssClass="myInput" ID="emailTxtBox" runat="server"  ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="emailTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Email missing!</asp:RequiredFieldValidator>
            <h2 class="sectiontitle">
                <asp:Label AssociatedControlId="passTxtBox" ID="passLbl" runat="server" Text="Password"></asp:Label>
            </h2>
            <asp:TextBox CssClass="myInput" ID="passTxtBox" type="password"  runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="passTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Password missing!</asp:RequiredFieldValidator>
            <br />
            <div class="inline">
                <asp:Button CssClass="myBtn" ID="logButton" runat="server" Text="Login" OnClick="logButton_Click" />
                <a href="./Register">Not registered?</a>
            </div>

            <!-- regex to validate email (not the best possible one)-->
            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailTxtBox" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator><br/>
            <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
        <!--------------->
        </article>
      </li>
      <li class="one_third"><article class="service"><i class=""></i></article></li>
    </ul>

</asp:Content>
