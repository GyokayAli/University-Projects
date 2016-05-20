<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppRestaurantSystem._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
   <div id="slider" class="clear"> 
   <!-- ################################################################################################ -->
      <div class="flexslider basicslider">
         <ul class="slides">
            <!--IMG Source: http://www.spiceofbengal.com/images/banner-img-6.jpg -->
           <li><a href="/Login"><img class="radius-10" src="img/demo/slides/01.jpg" alt=""></a></li>
         </ul>
      </div>
     <br />
      <div class="flexslider basicslider">
         <ul class="slides">
            <!--IMG Source: http://www.easyappetite.com/assets/images/slider_bg1.jpg -->
           <li><a href="./Login"><img class="radius-10" src="img/demo/slides/02.jpg" alt=""></a></li>
         </ul>
      </div>
      <br />
      <div class="flexslider basicslider">
         <ul class="slides">
            <!--IMG Source: http://cdn.tokyotimes.com/wp-content/uploads/2013/03/japanese-food.jpg -->
           <li><a href="/Login"><img class="radius-10" src="img/demo/slides/03.jpg" alt=""></a></li>
         </ul>
      </div>

   <!-- ################################################################################################ --> 
   </div>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
</asp:Content>
