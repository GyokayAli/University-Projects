<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FYProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<!-- ################################################################################################ -->
<div class="wrapper">
  <div id="slider" class="clear"> 
    <div class="flexslider basicslider">
      <ul class="slides">
        <li><a href="./Login"><img src="images/demo/slides/slide1.png" alt=""></a></li>
        <li><a href="./Login"><img src="images/demo/slides/slide2.png" alt=""></a></li>
        <li><a href="./Login"><img src="images/demo/slides/slide3.png" alt=""></a></li>
      </ul>
    </div>
  </div>
</div>
<!-- ################################################################################################ -->

<!-- ################################################################################################ -->
<div class="wrapper row3">
  <main class="container clear"> 
    <!-- main body -->
    <h2>Feel bored? Let's get motivated!</h2>
    <div class="flexslider carousel basiccarousel btmspace-80">
      <ul class="slides">
        <li>
          <figure><a href="./QuizCSharp"><img class="borderedbox inspace-5" src="images/demo/quiz.png" alt=""></a>
            <figcaption><a href="./QuizCSharp">Take a Quiz</a></figcaption>
          </figure>
        </li>
        <li>
          <figure><a href="./GameCSharp"><img class="borderedbox inspace-5" src="images/demo/csharp.png" alt=""></a>
            <figcaption><a href="./GameCSharp">Learn C# while playing games</a></figcaption>
          </figure>
        </li>
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
    <!-- / main body -->
  </main>
</div>
<!-- ################################################################################################ -->

</asp:Content>
