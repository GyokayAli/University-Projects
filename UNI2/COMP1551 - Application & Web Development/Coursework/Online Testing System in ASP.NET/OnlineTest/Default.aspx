<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineTest.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
     <!-- ####################################################################################################### -->
<div class="wrapper col2">
  <div id="featured_slide">
    <div id="featured_content">
      <ul>
        <li><img src="images/demo/1.gif" alt="" />
          <div class="floater">
            <h2>What is GREEN TEST?</h2>
            <p>GREEN TEST is an online computerised testing system of CIS. It allows University of Greenwich students to sit online exams created by the staff, using the system</a>.</p>
            <p class="readmore"><a href="Faqs.aspx">FAQs &raquo;</a></p>
          </div>
        </li>
        <li><img src="images/demo/2.gif" alt="" />
          <div class="floater">
            <h2>Student Portal</h2>
            <p>This is the place where the student will be able to sit online exam from a particular course. Each exam is timed and marked automatically. 
                The student will be able to check their score immediately after the test has been finished
</a>.</p>
            <p class="readmore"><a href="StudentPortal.aspx">Go to Student Portal &raquo;</a></p>
          </div>
        </li>
        <li><img src="images/demo/3.gif" alt="" />
          <div class="floater">
            <h2>Staff Portal</h2>
            <p>Staff will be able to create exams for a particular course. They can add questions to the question pool(database)
                , edit them and delete if needed. The staff will be able to retrieve reports for each student after the exam.
                ATTENTION! Staff needs to enter a secret keyword in order to use the system, due to security issues
</a>.</p>       
            <p class="readmore"><a href="StaffPortal.aspx">Go to Staff Portal &raquo;</a></p>
          </div>
        </li>
      </ul>
    </div>
    <a href="javascript:void(0);" id="featured-item-prev"><img src="layout/images/prev.png" alt="" /></a> <a href="javascript:void(0);" id="featured-item-next"><img src="layout/images/next.png" alt="" /></a> </div>
</div>
<!-- #########################
</asp:Content>
