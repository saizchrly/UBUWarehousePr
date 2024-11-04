<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioPassword.aspx.cs" Inherits="WWW.CambioPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style13 {
            width: 100%;
            margin-left: 1px;
            margin-bottom: 0px;
        }
        
        .auto-style4 {
            width: 274px;
            height: 26px;
        }
        .auto-style34 {
            width: 128px;
            height: 26px;
        }
        .auto-style50 {
            height: 26px;
            width: 24px;
        }
        .auto-style6 {
            height: 26px;
            text-align: center;
            width: 144px;
        }
        .auto-style60 {
            width: 127px;
            height: 26px;
        }
        .auto-style5 {
            height: 26px;
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
            width: 24px;
        }
        .auto-style65 {
            width: 144px;
            height: 24px;
        }
        .auto-style61 {
            width: 127px;
            height: 24px;
        }
        .auto-style59 {
            height: 24px;
        }
        .auto-style1 {
            width: 274px;
        }
        .auto-style35 {
            width: 128px;
        }
        .auto-style51 {
            width: 24px;
        }
        .auto-style66 {
            width: 144px;
        }
        .auto-style62 {
            width: 127px;
        }
        .auto-style2 {
            width: 274px;
            height: 21px;
        }
        .auto-style36 {
            width: 128px;
            height: 21px;
        }
        .auto-style52 {
            height: 21px;
            width: 24px;
        }
        .auto-style67 {
            width: 144px;
            height: 21px;
        }
        .auto-style63 {
            width: 127px;
            height: 21px;
        }
        .auto-style3 {
            height: 21px;
        }
        .auto-style7 {
            width: 274px;
            height: 27px;
        }
        .auto-style37 {
            width: 128px;
            height: 27px;
        }
        .auto-style53 {
            height: 27px;
            width: 24px;
        }
        .auto-style68 {
            width: 144px;
            height: 27px;
        }
        .auto-style64 {
            width: 127px;
            height: 27px;
        }
        .auto-style8 {
            height: 27px;
        }
        </style>
</head>
<body>
    <form id="form2" runat="server">
        <table class="auto-style13">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblTitulo" runat="server" Text="UBUWarehouse"></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style34">&nbsp;</td>
                <td class="auto-style50"></td>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style60">
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style54"></td>
                <td class="auto-style54"></td>
                <td class="auto-style55"></td>
                <td class="auto-style56"></td>
                <td class="auto-style65">
                    <asp:LinkButton ID="lbCerrarSesion" runat="server" OnClick="lbCerrarSesion_Click">Cerrar Sesión</asp:LinkButton>
                </td>
                <td class="auto-style61"></td>
                <td class="auto-style59">
                    <asp:LinkButton ID="lbInicio" runat="server" OnClick="lbInicio_Click">Menú principal</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style66">
                    &nbsp;</td>
                <td class="auto-style62">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style36">&nbsp;</td>
                <td class="auto-style52"></td>
                <td class="auto-style67"></td>
                <td class="auto-style63"></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style36">&nbsp;</td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style67">&nbsp;</td>
                <td class="auto-style63">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style36">&nbsp;</td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style67">&nbsp;</td>
                <td class="auto-style63">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style36">&nbsp;</td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style67">&nbsp;</td>
                <td class="auto-style63">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style37">&nbsp;</td>
                <td class="auto-style53"></td>
                <td class="auto-style68">
                </td>
                <td class="auto-style64">
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style66">&nbsp;</td>
                <td class="auto-style62">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style66">
                    &nbsp;</td>
                <td class="auto-style62">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style66">
                    &nbsp;</td>
                <td class="auto-style62">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
