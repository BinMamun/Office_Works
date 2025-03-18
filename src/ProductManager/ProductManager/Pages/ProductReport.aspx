<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductReport.aspx.cs" Inherits="ProductManager.Pages.ProductReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:Panel ID="Panel1" runat="server" CssClass="container mt-4">
        <rsweb:ReportViewer ID="rvProducts" runat="server" Width="100%" Height="600px" ProcessingMode="Local" />
    </asp:Panel>
</asp:Content>
