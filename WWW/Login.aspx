<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WWW.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 274px;
        }
        .auto-style2 {
            width: 274px;
            height: 21px;
        }
        .auto-style3 {
            height: 21px;
        }
        .auto-style4 {
            width: 274px;
            height: 26px;
        }
        .auto-style5 {
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
            text-align: center;
        }
        .auto-style7 {
            width: 274px;
            height: 28px;
        }
        .auto-style8 {
            height: 28px;
        }
        .auto-style9 {
            width: 274px;
            height: 29px;
        }
        .auto-style10 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style5"></td>
                <td class="auto-style6">
                    &nbsp;
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Italic="True" Text="Inicio de sesión"></asp:Label>
                    &nbsp;</td>
                <td class="auto-style5"></td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style5"></td>
                <td class="auto-style5"></td>
                <td class="auto-style5"></td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
                <td class="auto-style10">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:TextBox ID="tbxUsuario" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style3"></td>
                <td class="auto-style3"></td>
                <td class="auto-style3"></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style8"></td>
                <td class="auto-style8">
                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="tbxPassword" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnRegistrarse" runat="server" OnClick="Button1_Click" Text="Registrarse" />
                </td>
                <td>
                    <asp:Button ID="btnAceptar" runat="server" OnClick="Button1_Click" Text="Aceptar" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
