<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contribute.aspx.cs" Inherits="FYProject.Contribute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Would you like to contribute to us?</h1>
    <!-- GitHub img source: https://kanbanize.com/blog/wp-content/uploads/2014/11/GitHub.jpg -->
    <figure><a href="https://github.com/GyokayAli"><img class="borderedbox inspace-5" src="images/demo/github.jpg" alt="Contribute at GitHub" title="Contribute at GitHub"></a>
            <figcaption><a href="https://github.com/GyokayAli">Fork in our source code</a></figcaption>
     </figure>
    <br/>
    <h1>Would you like to add new questions to our Question Bank?</h1>
    <p>You need to login with a privileged account. Don't have? Please get in <a href="./Contact">touch with us</a>!</p>
    <p>Note: ID: admin1 PASS: admin1</p>
    <asp:Label AssociatedControlId="usernameTxtBox" ID="usernameLbl" runat="server" Text="Username"></asp:Label>
    <asp:TextBox ID="usernameTxtBox" runat="server" BackColor="#333333" ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="usernameTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Username missing!</asp:RequiredFieldValidator>
    <asp:Label AssociatedControlId="passTxtBox" ID="passLbl" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="passTxtBox" type="password" BackColor="#333333" runat="server" ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="passTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Password missing!</asp:RequiredFieldValidator>
    <br />
    <div class="inline">
            <asp:Button CssClass="myBtn" ID="logButton" runat="server" Text="Login" OnClick="logButton_Click" />
    </div>

    <!-- regex for alphanumeric user name that allows underscore with length 5-30 -->
    <asp:RegularExpressionValidator ID="regexUsernameValid" runat="server" ValidationExpression="^[a-zA-Z0-9][a-zA-Z0-9_]{4,29}$" ControlToValidate="usernameTxtBox" ErrorMessage="Invalid Username Format (5 - 15 characters)"></asp:RegularExpressionValidator><br/>
    <!-- regex for alphanumeric password with length 5-15 and at least one digit -->
    <asp:RegularExpressionValidator ID="regexPassValid" runat="server" ValidationExpression="^(?=.*\d).{4,14}$" ControlToValidate="passTxtBox" ErrorMessage="Invalid Password Format (5 - 15 alphanumeric characters)"></asp:RegularExpressionValidator><br/>
    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
</asp:Content>
