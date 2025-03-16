<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ProductManager.Pages.AddProduct" %>

<asp:Content ID="productCreateFrom" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mt-3">Create new product</h2>
    <div class="mb-3">
        <asp:TextBox ID="txtProductName" runat="server" Placeholder="Product Name" CssClass="form-control"></asp:TextBox>
        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control mt-2" placeholder="Price"></asp:TextBox>
       <asp:TextBox ID="txtStock" runat="server" CssClass="form-control mt-2" placeholder="Stock"></asp:TextBox>
        <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-select mt-2">
             <asp:ListItem Text="--Select Category--" Value="0" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:FileUpload ID="ProductImageFile" runat="server" CssClass="form-control mt-2" />
        <asp:Button ID="btnAddProduct" runat="server" class="btn btn-sm btn-primary mt-2" OnClick="btnAddProduct_Click" Text="Add Product" />
    </div>
</asp:Content>
