<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebAppRestaurantSystem.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="sectiontitle">Registration</h2>
    <ul class="nospace group btmspace-80">
      <li class="one_third first">
          <article class="service"><i class=""></i>

              <h2 class="sectiontitle">
                <asp:Label AssociatedControlId="genderDropDown" ID="genderLbl" runat="server" Text="Gender"></asp:Label>
              </h2>
              <asp:DropDownList CssClass="myDrop" ID="genderDropDown" runat="server">
                  <asp:ListItem>Male</asp:ListItem>
                  <asp:ListItem>Female</asp:ListItem>
                  <asp:ListItem>Other</asp:ListItem>
              </asp:DropDownList>
              <br />

              <h2 class="sectiontitle">
                  Date of birth
              </h2>
              
              <asp:DropDownList CssClass="myDrop" ID="dayDropDown" runat="server"></asp:DropDownList>
              <asp:DropDownList CssClass="myDrop" ID="monthDropDown" runat="server"></asp:DropDownList>
              <asp:DropDownList CssClass="myDrop" ID="yearDropDown" runat="server"></asp:DropDownList>
                         
          </article>
      </li>
      <li class="one_third">
        <article class="service"><i class=""></i>
        <!--Registration FORM -->
            <h2 class="sectiontitle">
                <asp:Label AssociatedControlId="emailTxtBox" ID="emailLbl" runat="server" Text="Email"></asp:Label>
            </h2>
            <asp:TextBox CssClass="myInput" ID="emailTxtBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="emailTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Email missing!</asp:RequiredFieldValidator>
           
            <h2 class="sectiontitle">
                <asp:Label AssociatedControlId="fnameTxtBox" ID="fnameLbl" runat="server" Text="First name"></asp:Label>
            </h2>
            <asp:TextBox CssClass="myInput" ID="fnameTxtBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fnameTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">First name missing!</asp:RequiredFieldValidator>
            
            <h2 class="sectiontitle">
                <asp:Label AssociatedControlId="lnameTxtBox" ID="lnameLbl" runat="server" Text="Last name"></asp:Label>
            </h2>
            <asp:TextBox CssClass="myInput" ID="lnameTxtBox" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lnameTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Last name missing!</asp:RequiredFieldValidator>
            
            <h2 class="sectiontitle">
                <asp:Label AssociatedControlId="passTxtBox" ID="passLbl" runat="server" Text="Password"></asp:Label>
            </h2>
            <asp:TextBox CssClass="myInput" ID="passTxtBox" type="password" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="passTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Password missing!</asp:RequiredFieldValidator>
           
            <h2 class="sectiontitle">
                <asp:Label AssociatedControlId="confTxtBox" ID="confLbl" runat="server" Text="Confirm password"></asp:Label>
            </h2>
            <asp:TextBox CssClass="myInput" ID="confTxtBox" type="password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="confTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Confirm password!</asp:RequiredFieldValidator>

            <br />
            <asp:Button CssClass="myBtn" ID="regButton" runat="server" Text="Register" OnClick="regButton_Click" />

            <!-- regex to validate email (not the best possible one)-->
            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailTxtBox" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator><br/>
            <!-- regex for alphanumeric password with length 5-15 and at least one digit -->
            <asp:RegularExpressionValidator ID="regexPassValid" runat="server" ValidationExpression="^(?=.*\d).{4,14}$" ControlToValidate="passTxtBox" ErrorMessage="Invalid Password Format (5 - 15 alphanumeric characters)"></asp:RegularExpressionValidator><br/>
            <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

        <!--------------->
        </article>
      </li>
      <li class="one_third">
          <article class="service"><i class=""></i>

              <h2 class="sectiontitle">
                <asp:Label AssociatedControlId="telTxtBox" ID="telLbl" runat="server" Text="Telephone number"></asp:Label>
              </h2>
              <asp:TextBox CssClass="myInput" ID="telTxtBox" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="telTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Telelphone number missing!</asp:RequiredFieldValidator>

              <h2 class="sectiontitle">
                 <asp:Label AssociatedControlId="addressTxtBox" ID="addressLbl" runat="server" Text="Address"></asp:Label>
              </h2>
              <asp:TextBox CssClass="myInput" ID="addressTxtBox" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="addressTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Address missing!</asp:RequiredFieldValidator>

              <h2 class="sectiontitle">
                <asp:Label AssociatedControlId="postcodeTxtBox" ID="postcodeLbl" runat="server" Text="Postcode"></asp:Label>
              </h2>
              <asp:TextBox CssClass="myInput" ID="postcodeTxtBox" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="postcodeTxtBox" ErrorMessage="RequiredFieldValidator" ForeColor="#CC3300">Postcode missing!</asp:RequiredFieldValidator>
              
          </article>
      </li>
    </ul>


</asp:Content>
