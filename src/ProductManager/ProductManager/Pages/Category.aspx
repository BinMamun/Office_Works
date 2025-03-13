<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="ProductManager.Pages.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Category List</h2>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryID" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting">

        <Columns>
            <%--<asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <asp:TextBox ID="RowNumber" Width="40" runat="server" Text="<%#:  %>"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:BoundField DataField="CategoryID" HeaderText="Category ID" SortExpression="CategoryID" />
            <asp:BoundField DataField="CategoryName" HeaderText="Category Name" SortExpression="CategoryName" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <br />
    <asp:Button ID="btnAddCategory" runat="server" Text="Add New" OnClick="btnAddCategory_Click" />
</asp:Content>
