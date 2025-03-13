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

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryID" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" CssClass="table table-striped table-sm table-hover mt-3" HeaderStyle-CssClass="table-primary">

        <Columns>
            <asp:TemplateField HeaderText="S No.">
                <ItemTemplate>
                    <asp:Label ID="RowDataIndex" Width="40" runat="server"
                        Text="<%#: Container.DataItemIndex + 1 %>" ReadOnly="true"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CategoryName" HeaderText="Category Name" SortExpression="CategoryName" />

            <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-sm btn-outline-dark" CommandName="Edit" Text="Edit"></asp:LinkButton>                
                <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-sm btn-outline-primary" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure?');">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />

</asp:Content>
