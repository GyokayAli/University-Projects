<%@ Page Title="Members" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="FYProject.Members" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="wrapper row3">
  <main class="container clear"> 
    <!-- main body -->

    <h2>Maybe you should start with a short quiz? Or just dive into programming...</h2>
    <div class="flexslider carousel basiccarousel btmspace-80">
      <ul class="slides">
       <li>
          <figure><a href="./TheQuiz"><img class="borderedbox inspace-5" src="images/demo/quiz.png" alt="Programming Quiz" title="Programming Quiz" onclick="proceed_Click"></a>
            <figcaption><a href="./TheQuiz">Take a Quiz</a></figcaption>
          </figure>
        </li>
        <li>
          <figure><a href="./GameCSharp"><img class="borderedbox inspace-5" src="images/demo/csharp.png" alt="C# Game" title="C# Game"></a>
            <figcaption><a href="./GameCSharp">Learn C# while playing games</a></figcaption>
          </figure>
        </li>
      </ul>
    </div>
     <!-- slide 2-->
    <p><strong>Coming soon!</strong></p>
      <div class="flexslider carousel basiccarousel btmspace-80">
      <ul class="slides">
        <li>
          <figure><img class="borderedbox inspace-5" src="images/demo/java.png" alt="">
            <figcaption><a href="#">Learn Java while playing games</a></figcaption>
          </figure>
        </li>
        <li>
          <figure><img class="borderedbox inspace-5" src="images/demo/js.png" alt="">
            <figcaption><a href="#">Learn JS while playing games</a></figcaption>
          </figure>
        </li>
        <li>
          <figure><img class="borderedbox inspace-5" src="images/demo/php.png" alt="">
            <figcaption><a href="#">Learn PHP while playing games</a></figcaption>
          </figure>
        </li>
           <li>
          <figure><img class="borderedbox inspace-5" src="images/demo/python.png" alt="">
            <figcaption><a href="#">Learn Python while playing games</a></figcaption>
          </figure>
        </li>
           <li>
          <figure><img class="borderedbox inspace-5" src="images/demo/ruby.png" alt="">
            <figcaption><a href="#">Learn Ruby while playing games</a></figcaption>
          </figure>
        </li>
         <li>
          <figure><img class="borderedbox inspace-5" src="images/demo/c.png" alt="">
            <figcaption><a href="#">Learn C while playing games</a></figcaption>
          </figure>
        </li>
          <li>
          <figure><img class="borderedbox inspace-5" src="images/demo/cpp.png" alt="">
            <figcaption><a href="#">Learn C++ while playing games</a></figcaption>
          </figure>
        </li>
      </ul>
    </div>
    <p><strong>Other</strong></p>
    <!-- slide 3-->
      <div class="flexslider carousel basiccarousel btmspace-80">
      <ul class="slides">
        <li>
          <figure><a href="./Progress"><img class="borderedbox inspace-5" src="images/demo/progress.png" alt=""></a>
            <figcaption><a href="./Progress">Check progress</a></figcaption>
          </figure>
        </li>
        <li>
          <figure><a href="./Settings"><img class="borderedbox inspace-5" src="images/demo/set.png" alt=""></a>
            <figcaption><a href="./Settings">Account settings</a></figcaption>
          </figure>
        </li>
      </ul>
    </div>
    <!-- / main body -->
  </main>
</div>

</asp:Content>
