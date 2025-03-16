<%@ Page Title="Edit Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="ProductManager.Pages.EditCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mt-3">Edit Categories</h2>
    <div class="mb-3">
        <asp:HiddenField ID="hfCategoryID" runat="server" />

        <label class="form-label">Category Name</label>
        <asp:TextBox ID="txtCategoryName" runat="server" Placeholder="Category" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnUpdateCategory" runat="server" CssClass="btn btn-sm btn-primary mt-2" OnClick="btnUpdate_Click" Text="Update Category" />
    </div>
</asp:Content>
