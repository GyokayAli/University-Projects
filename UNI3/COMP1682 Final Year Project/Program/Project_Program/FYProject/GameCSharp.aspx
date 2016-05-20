<%@ Page Title="C# Game" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GameCSharp.aspx.cs" Inherits="FYProject.GameCSharp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- instruction image -->
    <img src="images/instruction/papyr.png" alt="Game Instruction" title="Game Instruction">
    
    <!-- the code editor starts here -->
    <style type="text/css" media="screen">

        #editor {
            height: 480px;
            width: 412px;
            position: relative; 
        }
    </style>

    <pre id="editor">public void HelloWorld() {
    //Say Hello!
    Console.WriteLine("Hello World");
}
</pre>
       <div>
           <script>
               var editor = ace.edit("editor");
               editor.setTheme("ace/theme/monokai");
               editor.getSession().setMode("ace/mode/csharp");

               editor.getSession().setTabSize(4);
               document.getElementById('editor').style.fontSize = '14px';

               editor.resize();
        </script>
       </div> <!-- code editor ends here -->

        <!-- the game starts here -->
       <div>
            <script src="Game-Goblin/js/game.js"></script>
       </div>

        <asp:Button CssClass="myBtn" ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
       
</asp:Content>
