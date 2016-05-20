<%@ Page Title="Restaurant Details" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RestaurantDetails.aspx.cs" Inherits="WebAppRestaurantSystem.RestaurantDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="scrollable">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>

                <asp:TemplateField HeaderText="Restaurant" SortExpression="Restaurant"> 
                <ItemTemplate> 
                <asp:Image ID="Image1" Height="125" Width="125" ImageUrl =<%# string.Format("http://stuiis.cms.gre.ac.uk/ag306/myroot/pdc/images/{0}",Eval("Logo"))%> runat="server" /> 
                <asp:HyperLink ID="Hyperlink1" 
                  NavigateUrl="#"
                  Text='<%# Bind("Restaurant") %>' runat="server"/>
                </ItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Address" SortExpression="Address"> 
                <ItemTemplate> 
                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Address") %>'></asp:Label> 
                </ItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Postcode" SortExpression="Postcode"> 
                <ItemTemplate> 
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Postcode") %>'></asp:Label> 
                </ItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Contact Number" SortExpression="Telephone"> 
                <ItemTemplate> 
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Telephone") %>'></asp:Label> 
                </ItemTemplate> 
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
            <Columns>

                <asp:TemplateField HeaderText="Food offered" SortExpression="Food"> 
                <ItemTemplate> 
                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Food") %>'></asp:Label> 
                </ItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Average Meal Price" SortExpression="AvgPrice"> 
                <ItemTemplate> 
                <b><asp:Label ID="Label5" runat="server" Text=<%# string.Format("£{0}",Eval("AvgPrice"))%>></asp:Label></b> 
                </ItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email" SortExpression="Email"> 
                <ItemTemplate> 
                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Email") %>'></asp:Label> 
                </ItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Website" SortExpression="Website"> 
                <ItemTemplate> 
                <asp:Label ID="Label8" runat="server" Text='<%# Bind("Website") %>'></asp:Label> 
                </ItemTemplate> 
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
