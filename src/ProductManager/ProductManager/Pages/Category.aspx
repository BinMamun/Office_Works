<%@ Page Title="Category List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="ProductManager.Pages.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Content/js/category.js"></script>
    <script>
        function openModal(categoryId, categoryName) {
            document.getElementById('<%= hfCategoryID.ClientID %>').value = categoryId || '';
            document.getElementById('<%= txtCategoryNameModal.ClientID %>').value = categoryName || '';
            var myModal = new bootstrap.Modal(document.getElementById('categoryModal'));
            myModal.show();
        }
    </script>

    <div>
        <!-- Modal -->
        <div class="modal fade" id="categoryModal" tabindex="-1" aria-labelledby="categoryModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="categoryModalLabel">Add/Edit Category</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField ID="hfCategoryID" runat="server" />
                        <div class="mb-3">
                            <label for="txtCategoryNameModal" class="form-label">Category Name</label>
                            <asp:TextBox ID="txtCategoryNameModal" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnAddCategory_Click" Text="Add Category" />
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row d-flex align-items-center">
        <div class="col-10">
            <h2 class="mt-3">Category List</h2>
        </div>
        <div class="col-2">
            <asp:Button ID="btnAddCategory" runat="server" Text="Add New" CssClass="btn btn-sm btn-primary"
                OnClientClick="openModal(null, ''); return false;" />
        </div>
    </div>

    <asp:GridView ID="gvCategory" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryID" CssClass="table table-striped table-sm table-hover mt-3"
        HeaderStyle-CssClass="table-primary"
        OnRowEditing="gvCategory_RowEditing"
        OnRowUpdating="gvCategory_RowUpdating"
        OnRowCancelingEdit="gvCategory_CancelEdit"
        OnRowDeleting="gvCategory_RowDeleting">

        <Columns>
            <asp:TemplateField HeaderText="S No.">
                <ItemTemplate>
                    <asp:Label ID="RowDataIndex" Width="50" runat="server" ReadOnly="true" CssClass="text-end"
                        Text="<%#: Container.DataItemIndex + 1 %>" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Name" ItemStyle-Width="250">
                <ItemTemplate>
                    <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Bind("CategoryName") %>' CssClass="form-control"></asp:TextBox>
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
