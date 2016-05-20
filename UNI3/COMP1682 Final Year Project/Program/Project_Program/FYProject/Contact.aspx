<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="FYProject.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p>Please get in touch</p>
    <address>
        <abbr title="Developer">Developed by:</abbr>
        Gyokay Ali<br />
        <abbr title="Organization">Organization:</abbr>
        University of Greenwich<br />
        <abbr title="Phone">Phone:</abbr>
        +447588656659
    </address>

    <address>
        <strong>University Email:</strong>   <a href="mailto:ag306@greenwich.ac.uk">ag306@greenwich.ac.uk</a><br />
        <strong>Personal Email:</strong> <a href="mailto:gyokay.metin.ali@gmail.com">gyokay.metin.ali@gmail.com</a>
    </address>
</asp:Content>
