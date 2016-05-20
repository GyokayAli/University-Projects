<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebAppRestaurantSystem.Home" %>
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
                        <asp:Button CssClass="myBtn" ID="noticeBtn" runat="server" Text="Virtual" OnClick="noticeBtn_Click"  />
                    </div>
                </article>
            </li>
        </ul>
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
            <Columns>

                <asp:TemplateField HeaderText="Restaurant" SortExpression="Restaurant"> 
                <ItemTemplate> 
                <a href=<%# string.Format("RestaurantDetails.aspx?restID={0}",Eval("ID"))%>><asp:Image ID="Image1" Height="75" Width="75" ImageUrl =<%# string.Format("http://stuiis.cms.gre.ac.uk/ag306/myroot/pdc/images/{0}",Eval("Logo"))%> runat="server" /> </a> 
                <asp:HyperLink id="hyperlink1" 
                  ToolTip=<%# string.Format("Click to see full details of {0}",Eval("Restaurant"))%>
                  NavigateUrl=<%# string.Format("RestaurantDetails.aspx?restID={0}",Eval("ID"))%>
                  Text='<%# Bind("Restaurant") %>' runat="server"/>
                </ItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Food offered" SortExpression="Food"> 
                <ItemTemplate> 
                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Food") %>'></asp:Label> 
                </ItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Average Meal Price" SortExpression="AvgPrice"> 
                <ItemTemplate> 
                <b><asp:Label ID="Label2" runat="server" Text=<%# string.Format("£{0}",Eval("AvgPrice"))%>></asp:Label></b> 
                </ItemTemplate> 
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
