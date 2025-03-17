<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserManagement.aspx.cs" EnableEventValidation="true" Inherits="WebApplication1.DAL.UserManagement" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="bg-info">User Management</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Age" HeaderText="Age" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <h3>Add User</h3>
    <asp:TextBox ID="txtName" runat="server" Placeholder="Name"></asp:TextBox>
    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox>
    <asp:TextBox ID="txtAge" runat="server" Placeholder="Age"></asp:TextBox>
    <asp:Button ID="btnAdd" runat="server" Text="Add User" OnClick="btnAdd_Click" />
</asp:Content>
