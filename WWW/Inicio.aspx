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
            width: 274px;
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
        .auto-style103 {
            width: 352px;
            height: 27px;
        }
        .auto-style104 {
            width: 352px;
            height: 23px;
        }
        .auto-style105 {
            width: 157px;
            height: 26px;
        }
        .auto-style106 {
            width: 157px;
            height: 24px;
        }
        .auto-style107 {
            width: 157px;
        }
        .auto-style108 {
            width: 157px;
            height: 21px;
        }
        .auto-style110 {
            width: 157px;
            height: 27px;
        }
        .auto-style111 {
            width: 157px;
            height: 23px;
        }
        .auto-style112 {
            width: 198px;
            height: 26px;
        }
        .auto-style113 {
            width: 198px;
            height: 24px;
        }
        .auto-style114 {
            width: 198px;
        }
        .auto-style115 {
            width: 198px;
            height: 21px;
        }
        .auto-style117 {
            width: 198px;
            height: 27px;
        }
        .auto-style118 {
            width: 198px;
            height: 23px;
        }
        .auto-style119 {
            width: 274px;
            height: 122px;
        }
        .auto-style120 {
            width: 157px;
            height: 122px;
        }
        .auto-style121 {
            width: 198px;
            height: 122px;
        }
        .auto-style122 {
            height: 122px;
            width: 117px;
        }
        .auto-style123 {
            width: 352px;
            height: 122px;
        }
        .auto-style124 {
            width: 203px;
            height: 122px;
        }
        .auto-style125 {
            height: 122px;
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
                <td class="auto-style105">&nbsp;</td>
                <td class="auto-style112">&nbsp;</td>
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
                <td class="auto-style106"></td>
                <td class="auto-style113"></td>
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
                <td class="auto-style107">&nbsp;</td>
                <td class="auto-style114">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style100">
                    &nbsp;</td>
                <td class="auto-style83">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style108">
                    <asp:Label ID="lblnElementos" runat="server"></asp:Label>
                </td>
                <td class="auto-style115">&nbsp;</td>
                <td class="auto-style52"></td>
                <td class="auto-style101">
                    &nbsp;</td>
                <td class="auto-style84">&nbsp;</td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style119"></td>
                <td class="auto-style120">
                    <asp:Label ID="lblMostrarElem" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style121"></td>
                <td class="auto-style122"></td>
                <td class="auto-style123">
                    <asp:Label ID="lblInfo" runat="server" Font-Bold="True" Font-Underline="True" Text="Información del usuario"></asp:Label>
                </td>
                <td class="auto-style124"></td>
                <td class="auto-style125"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style108">
                    &nbsp;</td>
                <td class="auto-style115">
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
                <td class="auto-style108">
                    &nbsp;</td>
                <td class="auto-style115">
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
                <td class="auto-style110">
                    &nbsp;</td>
                <td class="auto-style117">&nbsp;</td>
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
                <td class="auto-style111">
                </td>
                <td class="auto-style118"></td>
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
                <td class="auto-style107">
                    <asp:Label ID="lblMensaje" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td class="auto-style114">&nbsp;</td>
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
                <td class="auto-style107">&nbsp;</td>
                <td class="auto-style114">&nbsp;</td>
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
