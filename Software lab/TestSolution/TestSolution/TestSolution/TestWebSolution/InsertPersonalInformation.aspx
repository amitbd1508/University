<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertPersonalInformation.aspx.cs" Inherits="TestWebSolution.InsertPersonalInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 104px;
        }
        .auto-style2 {
            width: 104px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            width: 138px;
        }
        .auto-style5 {
            height: 26px;
            width: 138px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width: 100%; height: 131px;">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style5"></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style4">Name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style4">Program</td>
                <td>
                    <asp:TextBox ID="txtProgram" runat="server" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="status" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="225px" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
