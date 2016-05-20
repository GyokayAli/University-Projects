<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NoticeBoard.aspx.cs" Inherits="WebAppRestaurantSystem.NoticeBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="scrollable">
        
        <ul class="nospace group btmspace-10">
          <li class="one_third first">
              <article class="service"><i class=""></i>
                  <h2 class="sectiontitle">
                       <asp:Label AssociatedControlId="postcodeTxtBox" ID="postcodeLbl" runat="server" Text="Enter postcode"></asp:Label>
                  </h2> 
              </article>
          </li>
          
            <li class="one_third">
                <article class="service"><i class=""></i>
                    <asp:TextBox CssClass="myInput" ID="postcodeTxtBox" runat="server"  ></asp:TextBox>
                 </article>
            </li>

            <li class="one_third">
                <article class="service"><i class=""></i>
                   <div class="inline">
                        <asp:Button CssClass="myBtn" ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click"  />
                       <asp:Button CssClass="myBtn" ID="listBtn" runat="server" Text="List View" OnClick="listBtn_Click"   />
                   </div>
                    
                    <asp:DropDownList ID="closestDropDown" runat="server" AutoPostBack="True" AppendDataBoundItems="true" OnSelectedIndexChanged="closestDropDown_SelectedIndexChanged">
                        <asp:ListItem Value="25">Closest 25</asp:ListItem>
                        <asp:ListItem Value="9">Closest 9</asp:ListItem>
                    </asp:DropDownList>
                </article>
            </li>
        </ul>
      </div>
    
    
    <asp:DataList CssClass="mydatalist" ID="ImageList" runat="server" >
        <ItemTemplate>
            <a href=<%# string.Format("RestaurantDetails.aspx?restID={0}",Eval("ID"))%>><asp:Image ID="Image1" Height="125" Width="125" ImageUrl =<%# string.Format("http://stuiis.cms.gre.ac.uk/ag306/myroot/pdc/images/{0}",Eval("Logo"))%> runat="server" /> </a> 
        </ItemTemplate>
    </asp:DataList>

</asp:Content>
