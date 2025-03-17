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

    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-sm table-hover mt-3" HeaderStyle-CssClass="table-primary" DataKeyNames="ProductID"
        OnRowDataBound="gvProducts_RowDataBound"
        OnRowEditing="gvProducts_RowEditing"
        OnRowUpdating="gvProducts_RowUpdating"
        OnRowCancelingEdit="gvProducts_RowCancelingEdit"
        OnRowDeleting="gvProduct_RowDeleting">
        <Columns>
            <%--<asp:TemplateField HeaderText="S No.">
                <ItemTemplate>
                    <asp:Label ID="RowDataIndex" Width="40" runat="server"
                        Text="<%#: Container.DataItemIndex + 1 %>" ReadOnly="true"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <img src='<%# Eval("PicturePath") != DBNull.Value && !string.IsNullOrEmpty(Eval("PicturePath").ToString()) ? ResolveUrl("~/Images/") + Eval("PicturePath") : ResolveUrl("~/Images/default.png") %>' width="50" height="50" />
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:FileUpload ID="fullImage" runat="server" CssClass="form-control" />
                    <asp:HiddenField ID="hfExistingImage" runat="server" Value='<%# Eval("PicturePath") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>
                    <%# Eval("ProductName") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control">
                    </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <%# Eval("CategoryName") %>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <%# Eval("Price", "{0:C}") %>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind ("Price") %>' CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Stock">
                <ItemTemplate>
                    <%# Eval("Stock") %>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:TextBox ID="txtStock" runat="server" Text='<%# Bind ("Stock") %>' CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Edit" CssClass="btn btn-sm btn-outline-dark" CommandName="Edit" />
                    <asp:Button runat="server" Text="Delete" CssClass="btn btn-sm btn-outline-primary" CommandName="Delete" OnClientClick="return confirm('Are you sure?');" />
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:Button runat="server" Text="Update" CssClass="btn btn-sm btn-primary" CommandName="Update" />
                    <asp:Button runat="server" Text="Cancel" CssClass="btn btn-sm btn-dark" CommandName="Cancel" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
</asp:Content>
