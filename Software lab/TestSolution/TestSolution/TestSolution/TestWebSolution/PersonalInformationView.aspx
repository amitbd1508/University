<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInformationView.aspx.cs" Inherits="TestSoftwareLab163.PersonalInformationView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>
                List of Persona Information</h3>
            <br />
            <asp:GridView ID="gvPersonalInfo" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False"
                AutoGenerateEditButton="True" OnRowCancelingEdit="gvPersonalInfo_RowCancelingEdit"
                OnRowEditing="gvPersonalInfo_RowEditing" OnRowUpdating="gvPersonalInfo_RowUpdating" BorderColor="Silver"
                BorderStyle="Solid" BorderWidth="1px" OnRowDeleted="gvPersonalInfo_RowDeleted" OnRowDeleting="gvPersonalInfo_RowDeleting">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Id">
                        <EditItemTemplate>
                            <asp:Label ID="txtId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblId2" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Program">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProgram" runat="server" Text='<%# Bind("Program") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblProgram" runat="server" Text='<%# Bind("Program") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/DeleteEmployee.aspx?Id={0}" />
                </Columns>
                <EmptyDataTemplate>
                    <b>No Data Found !</b>
                </EmptyDataTemplate>
            </asp:GridView>
            &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Button ID="btnInsert" runat="server" Text="Insert Personal Information" OnClick="btnInsert_Click" /><br />
            <br />
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label></div>
    </form>
</body>
</html>
