<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ProductManager.Pages.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row d-flex align-items-center">
        <div class="col-10">
            <h2 class="mt-3">Product List</h2>
        </div>
        <div class="col-2">
            <asp:Button ID="btnAddProduct" runat="server" Text="Add New" OnClick="btnAddProduct_Click" CssClass="btn btn-sm btn-primary" />
        </div>
    </div>

    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-sm table-hover mt-3" HeaderStyle-CssClass="table-primary">
        <Columns>
            <asp:TemplateField HeaderText="S No.">
                <ItemTemplate>
                    <asp:Label ID="RowDataIndex" Width="40" runat="server"
                        Text="<%#: Container.DataItemIndex + 1 %>" ReadOnly="true"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Image">
                <asp:ItemTemplate>
                    <img src='<%# Eval("PicturePath") %>' width="50" height="50" />
                </asp:ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>
                    <%# Eval("ProductName") %>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <%# Eval("CategoryName") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                     <%# Eval("Price", "{0:C}") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Stock">
                <ItemTemplate>
                    <%# Eval("Stock") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Edit" CssClass="btn btn-sm btn-outline-dark" CommandName="Edit" CommandArgument='<%# Eval("ProductID") %>' />
                        <asp:Button runat="server" Text="Delete" CssClass="btn btn-sm btn-outline-primary" CommandName="Delete" CommandArgument='<%# Eval("ProductID") %>' OnClientClick="return confirm('Are you sure?');" />
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>

    </asp:GridView>
</asp:Content>
