<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WingtipToys.Pages._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center mt-3"><%: Title %>...</h1>
    <h2 class="text-center mt-3">Wingtip Toys can help you find the perfect gift.</h2>
    <p class="lead text-center" style="font-size:medium;">
        We're all about transportation toys. You can order 
                any of our toys today. Each toy listing has detailed 
                information to help you choose the right toy.
    </p>
</asp:Content>
