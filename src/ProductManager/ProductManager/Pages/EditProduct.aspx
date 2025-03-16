<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="ProductManager.Pages.EditProduct" %>

<asp:Content ID="EditProduct" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hfProductID" runat="server" />

            <div class="mb-3">
                <label class="form-label">Product Name</label>
                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Category</label>
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label class="form-label">Price</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Stock</label>
                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Current Image</label>
                <img ID="imgPreview" runat="server" width="100" height="100" />
            </div>

            <div class="mb-3">
                <label class="form-label">Upload New Image</label>
                <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success" Text="Update" OnClick="btnUpdate_Click" />
            <a href="/Pages/Products.aspx" class="btn btn-secondary">Back to List</a>
</asp:Content>

