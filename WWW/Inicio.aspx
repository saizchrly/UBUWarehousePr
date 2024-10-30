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
            width: 113px;
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
        .auto-style34 {
            width: 128px;
            height: 26px;
        }
        .auto-style35 {
            width: 128px;
        }
        .auto-style36 {
            width: 128px;
            height: 21px;
        }
        .auto-style37 {
            width: 128px;
            height: 27px;
        }
        .auto-style43 {
            width: 113px;
        }
        .auto-style44 {
            height: 21px;
            width: 113px;
        }
        .auto-style45 {
            height: 27px;
            width: 113px;
        }
        .auto-style46 {
            height: 26px;
            width: 19px;
        }
        .auto-style47 {
            width: 19px;
        }
        .auto-style48 {
            height: 21px;
            width: 19px;
        }
        .auto-style49 {
            height: 27px;
            width: 19px;
        }
        .auto-style50 {
            height: 26px;
            width: 1px;
        }
        .auto-style51 {
            width: 1px;
        }
        .auto-style52 {
            height: 21px;
            width: 1px;
        }
        .auto-style53 {
            height: 27px;
            width: 1px;
        }
        .auto-style54 {
            width: 274px;
            height: 24px;
        }
        .auto-style55 {
            width: 128px;
            height: 24px;
        }
        .auto-style56 {
            height: 24px;
            width: 1px;
        }
        .auto-style57 {
            height: 24px;
            width: 113px;
        }
        .auto-style58 {
            height: 24px;
            width: 19px;
        }
        .auto-style59 {
            height: 24px;
        }
    </style>
</head>
<body style="height: 0px">
    <form id="form1" runat="server">
        <table class="auto-style13">
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style34">&nbsp;</td>
                <td class="auto-style50"></td>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style46">
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style54"></td>
                <td class="auto-style54"></td>
                <td class="auto-style55"></td>
                <td class="auto-style56"></td>
                <td class="auto-style57">
                    <asp:LinkButton ID="lbCerrarSesion" runat="server" OnClick="lbCerrarSesion_Click">Cerrar Sesión</asp:LinkButton>
                </td>
                <td class="auto-style58"></td>
                <td class="auto-style59">
                    <asp:LinkButton ID="lbCambiarPassword" runat="server">Cambiar Contraseña</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style43">
                    &nbsp;</td>
                <td class="auto-style47">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style36">&nbsp;</td>
                <td class="auto-style52"></td>
                <td class="auto-style44"></td>
                <td class="auto-style48"></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style36">&nbsp;</td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style44">&nbsp;</td>
                <td class="auto-style48">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style36">&nbsp;</td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style44">&nbsp;</td>
                <td class="auto-style48">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style36">&nbsp;</td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style44">&nbsp;</td>
                <td class="auto-style48">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style37">&nbsp;</td>
                <td class="auto-style53"></td>
                <td class="auto-style45">
                </td>
                <td class="auto-style49">
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style43">&nbsp;</td>
                <td class="auto-style47">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style43">
                    &nbsp;</td>
                <td class="auto-style47">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style43">
                    &nbsp;</td>
                <td class="auto-style47">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
    </body>
</html>
