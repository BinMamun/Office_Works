<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ProductManager.Pages.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mt-2">
        <h2>Product List</h2>
    </div>
    <div class="row d-flex align-items-center">
        <div class="col-10 mt-2">
            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true"
                OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" CssClass="form-select form-select-sm">
                <asp:ListItem Text="10" Value="10" Selected="True"></asp:ListItem>
                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                <asp:ListItem Text="100" Value="100"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-1">
            <asp:Button ID="btnAddProduct" runat="server" Text="Add" OnClick="btnAddProduct_Click" CssClass="btn btn-sm btn-primary px-4" />
        </div>
        <div class="col-1">
            <asp:Button ID="btnShowReport" runat="server" Text="Print" CssClass="btn btn-sm btn-primary px-4" OnClientClick="window.open('ProductReport.aspx', '_blank'); return false;" />
        </div>
    </div>

    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-sm table-hover mt-3" HeaderStyle-CssClass="table-primary" DataKeyNames="ProductID" AllowPaging="true" PageSize="10"
        OnRowDataBound="gvProducts_RowDataBound"
        OnRowEditing="gvProducts_RowEditing"
        OnRowUpdating="gvProducts_RowUpdating"
        OnRowCancelingEdit="gvProducts_RowCancelingEdit"
        OnRowDeleting="gvProduct_RowDeleting"
        OnPageIndexChanging="gvProducts_PageIndexChanging">
        <Columns>

            <asp:TemplateField HeaderText="SL">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>

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
                    <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind ("ProductName") %>' CssClass="form-control"></asp:TextBox>
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
