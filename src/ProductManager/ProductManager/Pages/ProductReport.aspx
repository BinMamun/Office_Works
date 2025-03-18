<%@ Page Title="Product List Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductReport.aspx.cs" Inherits="ProductManager.Pages.ProductReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    <asp:Panel ID="Panel1" runat="server" CssClass="container mt-4">
        <rsweb:ReportViewer ID="rvProducts" runat="server" Width="100%" Height="500px" ProcessingMode="Local"></rsweb:ReportViewer>
    </asp:Panel>
</asp:Content>
