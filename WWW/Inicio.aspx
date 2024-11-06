<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WWW.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style4 {
            width: 274px;
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
            width: 274px;
        }
        .auto-style2 {
            width: 274px;
            height: 21px;
        }
        .auto-style3 {
            height: 21px;
        }
        .auto-style7 {
            width: 274px;
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
            width: 117px;
        }
        .auto-style51 {
            width: 117px;
        }
        .auto-style52 {
            height: 21px;
            width: 117px;
        }
        .auto-style53 {
            height: 27px;
            width: 117px;
        }
        .auto-style54 {
            width: 274px;
            height: 24px;
        }
        .auto-style56 {
            height: 24px;
            width: 117px;
        }
        .auto-style59 {
            height: 24px;
        }
        .auto-style75 {
            width: 274px;
            height: 16px;
        }
        .auto-style77 {
            height: 16px;
            width: 117px;
        }
        .auto-style80 {
            height: 16px;
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
        .auto-style85 {
            width: 203px;
            height: 16px;
        }
        .auto-style86 {
            width: 203px;
            height: 27px;
        }
        .auto-style88 {
            width: 42px;
            height: 26px;
        }
        .auto-style89 {
            width: 42px;
            height: 24px;
        }
        .auto-style90 {
            width: 42px;
        }
        .auto-style91 {
            width: 42px;
            height: 21px;
        }
        .auto-style92 {
            width: 42px;
            height: 16px;
        }
        .auto-style93 {
            width: 42px;
            height: 27px;
        }
        .auto-style94 {
            width: 274px;
            height: 23px;
        }
        .auto-style95 {
            width: 42px;
            height: 23px;
        }
        .auto-style96 {
            height: 23px;
            width: 117px;
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
        .auto-style102 {
            width: 352px;
            height: 16px;
        }
        .auto-style103 {
            width: 352px;
            height: 27px;
        }
        .auto-style104 {
            width: 352px;
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
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style88">&nbsp;</td>
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
                <td class="auto-style54"></td>
                <td class="auto-style89"></td>
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
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style90">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style100">
                    &nbsp;</td>
                <td class="auto-style83">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    <asp:Label ID="lblnElementos" runat="server"></asp:Label>
                </td>
                <td class="auto-style91">&nbsp;</td>
                <td class="auto-style52"></td>
                <td class="auto-style101">
                    <asp:Label ID="lblInfo" runat="server" Font-Bold="True" Font-Underline="True" Text="Información del usuario"></asp:Label>
                </td>
                <td class="auto-style84">&nbsp;</td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style75"></td>
                <td class="auto-style75">
                    &nbsp;</td>
                <td class="auto-style92"></td>
                <td class="auto-style77"></td>
                <td class="auto-style102"></td>
                <td class="auto-style85">&nbsp;</td>
                <td class="auto-style80"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btnRaiz" runat="server" Height="29px" OnClick="btnRaiz_Click" Text="Añadir raíz" />
                </td>
                <td class="auto-style91">&nbsp;</td>
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
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style91">
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
                <td class="auto-style7">
                    <asp:Label ID="lblMensaje" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td class="auto-style93">&nbsp;</td>
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
                <td class="auto-style94">
                </td>
                <td class="auto-style95"></td>
                <td class="auto-style96"></td>
                <td class="auto-style104">&nbsp;</td>
                <td class="auto-style97">
                    <asp:TextBox ID="tbPais" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style98">
                    <asp:Button ID="btnCPais" runat="server" OnClick="btnCPais_Click" Text="Aceptar" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style90">&nbsp;</td>
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
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style90">&nbsp;</td>
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
