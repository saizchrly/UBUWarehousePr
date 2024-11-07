<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WWW.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style4 {
            width: 214px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
            text-align: center;
            width: 352px;
        }
        .auto-style5 {
            height: 26px;
        }
        .auto-style1 {
            width: 214px;
        }
        .auto-style2 {
            width: 214px;
            height: 21px;
        }
        .auto-style3 {
            height: 21px;
        }
        .auto-style7 {
            width: 214px;
            height: 27px;
        }
        .auto-style8 {
            height: 27px;
        }
        .auto-style13 {
            width: 100%;
            margin-left: 1px;
            margin-bottom: 0px;
        }
        .auto-style50 {
            height: 26px;
            width: 12px;
        }
        .auto-style51 {
            width: 12px;
        }
        .auto-style52 {
            height: 21px;
            width: 12px;
        }
        .auto-style53 {
            height: 27px;
            width: 12px;
        }
        .auto-style54 {
            width: 214px;
            height: 24px;
        }
        .auto-style56 {
            height: 24px;
            width: 12px;
        }
        .auto-style59 {
            height: 24px;
        }
        .auto-style81 {
            width: 203px;
            height: 26px;
        }
        .auto-style82 {
            width: 203px;
            height: 24px;
        }
        .auto-style83 {
            width: 203px;
        }
        .auto-style84 {
            width: 203px;
            height: 21px;
        }
        .auto-style86 {
            width: 203px;
            height: 27px;
        }
        .auto-style94 {
            width: 214px;
            height: 23px;
        }
        .auto-style96 {
            height: 23px;
            width: 12px;
        }
        .auto-style97 {
            width: 203px;
            height: 23px;
        }
        .auto-style98 {
            height: 23px;
        }
        .auto-style99 {
            width: 352px;
            height: 24px;
        }
        .auto-style100 {
            width: 352px;
        }
        .auto-style101 {
            width: 352px;
            height: 21px;
        }
        .auto-style103 {
            width: 352px;
            height: 27px;
        }
        .auto-style104 {
            width: 352px;
            height: 23px;
        }
        .auto-style119 {
            width: 214px;
            height: 196px;
        }
        .auto-style122 {
            height: 196px;
            width: 12px;
        }
        .auto-style123 {
            width: 352px;
            height: 196px;
        }
        .auto-style124 {
            width: 203px;
            height: 196px;
        }
        .auto-style125 {
            height: 196px;
        }
        .auto-style133 {
            height: 26px;
            width: 32px;
        }
        .auto-style134 {
            height: 24px;
            width: 32px;
        }
        .auto-style135 {
            width: 32px;
        }
        .auto-style136 {
            height: 21px;
            width: 32px;
        }
        .auto-style137 {
            height: 196px;
            width: 32px;
        }
        .auto-style138 {
            height: 27px;
            width: 32px;
        }
        .auto-style139 {
            height: 23px;
            width: 32px;
        }
        .auto-style140 {
            width: 280px;
            height: 26px;
        }
        .auto-style141 {
            width: 280px;
            height: 24px;
        }
        .auto-style142 {
            width: 280px;
        }
        .auto-style143 {
            width: 280px;
            height: 21px;
        }
        .auto-style144 {
            width: 280px;
            height: 196px;
        }
        .auto-style145 {
            width: 280px;
            height: 27px;
        }
        .auto-style146 {
            width: 280px;
            height: 23px;
        }
    </style>
</head>
<body style="height: 0px">
    <form id="form1" runat="server">
        <table class="auto-style13">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblTitulo" runat="server" Text="UBUWarehouse"></asp:Label>
                </td>
                <td class="auto-style140">&nbsp;</td>
                <td class="auto-style133">&nbsp;</td>
                <td class="auto-style50"></td>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style81">
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style54"></td>
                <td class="auto-style141"></td>
                <td class="auto-style134"></td>
                <td class="auto-style56">&nbsp;</td>
                <td class="auto-style99">
                    &nbsp;</td>
                <td class="auto-style82">
                    <asp:LinkButton ID="lbCerrarSesion" runat="server" OnClick="lbCerrarSesion_Click">Cerrar Sesión</asp:LinkButton>
                </td>
                <td class="auto-style59">
                    <asp:LinkButton ID="lbCambiarPassword" runat="server" OnClick="lbCambiarPassword_Click">Cambiar Contraseña</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style142">&nbsp;</td>
                <td class="auto-style135">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style100">
                    &nbsp;</td>
                <td class="auto-style83">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style143">
                    <asp:Label ID="lblnElementos" runat="server"></asp:Label>
                </td>
                <td class="auto-style136">&nbsp;</td>
                <td class="auto-style52"></td>
                <td class="auto-style101">
                    &nbsp;</td>
                <td class="auto-style84">&nbsp;</td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style119"></td>
                <td class="auto-style144">
                    <asp:Button ID="btnRaiz" runat="server" Text="Añadir raíz" OnClick="btnRaiz_Click" />
                </td>
                <td class="auto-style137"></td>
                <td class="auto-style122"></td>
                <td class="auto-style123">
                    <asp:Label ID="lblInfo" runat="server" Font-Bold="True" Font-Underline="True" Text="Información del usuario"></asp:Label>
                </td>
                <td class="auto-style124"></td>
                <td class="auto-style125"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style143">
                    &nbsp;</td>
                <td class="auto-style136">
                    &nbsp;</td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style101">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td class="auto-style84">
                    <asp:Button ID="btnNombre" runat="server" Height="29px" OnClick="btnNombre_Click" Text="Editar" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style143">
                    &nbsp;</td>
                <td class="auto-style136">
                    &nbsp;</td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style101">&nbsp;</td>
                <td class="auto-style84">
                    <asp:TextBox ID="tbNombre" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnCNombre" runat="server" OnClick="btnCNombre_Click" Text="Aceptar" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style145">
                    &nbsp;</td>
                <td class="auto-style138">&nbsp;</td>
                <td class="auto-style53"></td>
                <td class="auto-style103">
                    <asp:Label ID="lblPais" runat="server" Text="País"></asp:Label>
                </td>
                <td class="auto-style86">
                    <asp:Button ID="btnPais" runat="server" OnClick="btnPais_Click" Text="Editar" />
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style94">
                    </td>
                <td class="auto-style146">
                </td>
                <td class="auto-style139"></td>
                <td class="auto-style96"></td>
                <td class="auto-style104">&nbsp;</td>
                <td class="auto-style97">
                    <asp:TextBox ID="tbPais" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style98">
                    <asp:Button ID="btnCPais" runat="server" Height="29px" OnClick="btnCPais_Click" Text="Aceptar" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style142">
                    <asp:Label ID="lblMensaje" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td class="auto-style135">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style100">
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
                </td>
                <td class="auto-style83">
                    <asp:Button ID="btnTelefono" runat="server" OnClick="btnTelefono_Click" Text="Editar" />
                    <asp:TextBox ID="tbTelefono" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnCTelefono" runat="server" OnClick="btnCTelefono_Click" Text="Aceptar" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style142">&nbsp;</td>
                <td class="auto-style135">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style100">
                    <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td class="auto-style83">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
    </body>
</html>
