<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebPrestamosUNED.app._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 45%;
        }
        .auto-style2 {
            width: 463px;
        }
        .auto-style3 {
            width: 433px;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            width: 433px;
            height: 30px;
        }
        .auto-style6 {
            width: 463px;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style4" colspan="2">Calculadora de Prestamos</td>
                </tr>
                <tr>
                    <td class="auto-style3">Monto</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Tasa de Interes</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtTasa" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Plazo</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtPlazo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Moneda</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddlMoneda" runat="server" DataSourceID="SqlDataSource1" DataTextField="descripcion" DataValueField="tipo_moneda">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PrestamosConnectionString %>" SelectCommand="SELECT [tipo_moneda], [descripcion] FROM [Moneda]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style6">
                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" OnClick="btnCalcular_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="#CC3300"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Cuota Mensual</td>
                    <td class="auto-style2">
                        <asp:Label ID="txtCalculo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
            </table>



        </div>
        <p>
            &nbsp;</p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
