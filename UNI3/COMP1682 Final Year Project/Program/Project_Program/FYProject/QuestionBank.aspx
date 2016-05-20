<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QuestionBank.aspx.cs" Inherits="FYProject.QuestionBank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Label CssClass="pull-right" ID="welcomeLbl" runat="server" Text=""></asp:Label>
        <h1>Add questions</h1>
        <p>Select question difficulty
            <asp:DropDownList ID="diffDropDown" runat="server" AutoPostBack="True" BackColor="#333333" >
                <asp:ListItem Value="easy">Easy</asp:ListItem>
                <asp:ListItem Value="medium">Medium</asp:ListItem>
                <asp:ListItem Value="difficult">Difficult</asp:ListItem>
                <asp:ListItem Value="very difficult">Very difficult</asp:ListItem>
                <asp:ListItem Value="expert">Expert</asp:ListItem>
            </asp:DropDownList>
        
        Select programming language 
            <asp:DropDownList ID="langDropDown" runat="server" AutoPostBack="True" BackColor="#333333">
                <asp:ListItem>C#</asp:ListItem>
            </asp:DropDownList>
             <br />
           <asp:Label AssociatedControlId="questionTxtBox" ID="questionLbl" runat="server" Text="Question:"></asp:Label>
           <asp:TextBox ID="questionTxtBox" runat="server" Height="58px" MaxLength="250" BackColor="#333333" TextMode="MultiLine" Width="421px"></asp:TextBox></p>
       <div class="inline">
             <asp:Label AssociatedControlId="pointTxtBox" ID="pointLbl" runat="server" Text="Points given:"></asp:Label>
             <asp:TextBox ID="pointTxtBox" runat="server" MaxLength="3" BackColor="#333333" Height="16px" Width="87px" ></asp:TextBox><br />
       </div>  
       <p>    
       Answers: 
            <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
            <br />
       Only one correct answer please!
    </p>
    <div class="inline">
           <asp:Label AssociatedControlId="answerTxtBox1" ID="answ1" runat="server" Text="1:"></asp:Label>
           <asp:TextBox ID="answerTxtBox1" runat="server" BackColor="#333333" Width="405px"></asp:TextBox>
           <asp:CheckBox ID="CheckBox1" runat="server"   Text="correct ?"/>
           <br />
           <asp:Label AssociatedControlId="answerTxtBox2" ID="answ2" runat="server" Text="2:"></asp:Label>
           <asp:TextBox ID="answerTxtBox2" runat="server" BackColor="#333333" Width="405px"></asp:TextBox>
           <asp:CheckBox ID="CheckBox2" runat="server" Text="correct ?" />
           <br />
           <asp:Label AssociatedControlId="answerTxtBox3" ID="answ3" runat="server" Text="3:"></asp:Label>
           <asp:TextBox ID="answerTxtBox3" runat="server" BackColor="#333333" Width="406px"></asp:TextBox>
           <asp:CheckBox ID="CheckBox3" runat="server" Text="correct ?" />
           <br />
           <asp:Label AssociatedControlId="answerTxtBox4" ID="answ4" runat="server" Text="4:"></asp:Label>
           <asp:TextBox ID="answerTxtBox4" runat="server" BackColor="#333333" Width="405px"></asp:TextBox>
           <asp:CheckBox ID="CheckBox4" runat="server" Text="correct ?"/>
           <br /><br />
           <asp:Button CssClass="myBtn" ID="submitBtn" runat="server" Text="Submit" OnClick="submitBtn_Click" />
    </div>
    <asp:Label ID="erroLbl" runat="server" Text=""></asp:Label>
</asp:Content>
