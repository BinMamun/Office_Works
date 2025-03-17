<%@ Page Title="Category List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="ProductManager.Pages.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row d-flex align-items-center">
        <div class="col-10">
            <h2 class="mt-3">Category List</h2>
        </div>
        <div class="col-2">
            <asp:Button ID="btnAddCategory" runat="server" Text="Add New" OnClick="btnAddCategory_Click" CssClass="btn btn-sm btn-primary" />
        </div>
    </div>

    <asp:GridView ID="gvCategory" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryID" CssClass="table table-striped table-sm table-hover mt-3" HeaderStyle-CssClass="table-primary"
        OnRowEditing="gvCategory_RowEditing"
        OnRowUpdating="gvCategory_RowUpdating"
        OnRowCancelingEdit="gvCategory_CancelEdit"
        OnRowDeleting="gvCategory_RowDeleting">

        <Columns>
            <asp:TemplateField HeaderText="S No.">
                <ItemTemplate>
                    <asp:Label ID="RowDataIndex" Width="50" runat="server"
                        Text="<%#: Container.DataItemIndex + 1 %>" ReadOnly="true"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Name" ItemStyle-Width="250">
                <ItemTemplate>
                    <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Bind("CategoryName") %>' CssClass="form-control" ></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="text-end ms-3" ItemStyle-CssClass="text-end">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-sm btn-outline-dark" CommandName="Edit" Text="Edit"></asp:LinkButton>
                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-sm btn-outline-primary" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure?');">
                    </asp:LinkButton>
                </ItemTemplate>

                <EditItemTemplate>
                    <div class="text-end">
                        <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-sm btn-primary" CommandName="Update" Text="Update"></asp:LinkButton>
                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sm btn-dark" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </div>
                </EditItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>
