<%@ Page Title="Add new Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="ProductManager.Pages.AddCategory" %>


<asp:Content ID="CategoryCreateForm" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mt-3">Create Categories</h2>
    <div class="mb-3">
        <asp:TextBox ID="txtCategoryName" runat="server" Placeholder="Category" CssClass="form-control"></asp:TextBox>
        <%--<button id="btnAddCategory" runat="server" class="btn btn-sm btn-primary mt-2" onserverclick="btnAddCategory_Click">Add Category</button>--%>
        <asp:Button ID="btnAddCategory" runat="server" CssClass="btn btn-sm btn-primary mt-2" OnClick ="btnAddCategory_Click" Text="Add Category" />
    </div>
</asp:Content>



