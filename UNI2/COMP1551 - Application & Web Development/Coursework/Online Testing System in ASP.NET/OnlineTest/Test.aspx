<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="OnlineTest.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="server">     
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
        .auto-style2 {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">

  <div class ="wrapper col2">
        &nbsp;

        <br />
&nbsp;<h1>&nbsp;
            <asp:Label ID="TestNameLabel" runat="server" Font-Size="Large" style="text-align: left" Text="Title"></asp:Label>
        </h1>
     
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Student ID:
        <asp:Label ID="id" runat="server" Font-Bold="True" ForeColor="Red" Text="id"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Student name: <asp:Label ID="name" runat="server" Font-Bold="True" ForeColor="Red" Text="name"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Course: <asp:Label ID="course" runat="server" Font-Bold="True" ForeColor="Red" Text="course"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Test:
        <asp:Label ID="testString" runat="server" Font-Bold="True" ForeColor="Red" Text="test"></asp:Label>
        <br />
&nbsp;Number of questions:
        <asp:Label ID="number" runat="server" Font-Bold="True" ForeColor="Red" Text="number"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exam start time:
        <asp:Label ID="start" runat="server" Font-Bold="True" ForeColor="Red" Text="start"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Current time:
        <asp:Label ID="current" runat="server" Font-Bold="True" ForeColor="Red" Text="current"></asp:Label>
        <br />
        <br />
&nbsp;<br />
        <br />
        <span class="auto-style2"><span class="auto-style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>You have <span id="countdown" class="timer"></span>
<script>
    var seconds = 120;
    function secondPassed() {
        var minutes = Math.round((seconds - 30) / 60);
        var remainingSeconds = seconds % 60;
        if (remainingSeconds < 10) {
            remainingSeconds = "0" + remainingSeconds;
        }
        document.getElementById('countdown').innerHTML = minutes + ":" + remainingSeconds;
        if (seconds == 0) {
            clearInterval(countdownTimer);
            alert("You were dissmissed from the test!")
            window.location.href = "Student.aspx";
        } else {
            seconds--;
        }
    }

    var countdownTimer = setInterval('secondPassed()', 1000);
</script>
        seconds to answer each question!</span></span><br />
&nbsp;Instructions:
        <asp:Label ID="InstructLabel" runat="server" Text="Label"></asp:Label>
   <br />
          &nbsp;Question:
        <asp:Label ID="QuestLabel" runat="server" Text="Label"></asp:Label>
        <br />
&nbsp;&nbsp;
        <asp:Image ID="Image1" runat="server" />
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        </asp:RadioButtonList>
        &nbsp; 
        <asp:Button ID="PrevButton" runat="server" OnClick="PrevButton_Click" Text="Previous question" Width="144px" />
        <br />
&nbsp; Points:
        <asp:Label ID="PointLabel" runat="server" Text="Label"></asp:Label>
        <br />
&nbsp;
        <br />
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Next question" OnClick="Button1_Click" />
        <br />
        <br />

     </div>   

</asp:Content>
