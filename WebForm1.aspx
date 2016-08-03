<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DropFor.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h3>nested dropdownlist entityframework</h3>
            <table>
                <tr>
                    <td>Kıta Seç
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlkita" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlkita_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>ülke seç
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlulke" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlulke_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Şehir seç
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlsehir" runat="server" Enabled="false" OnSelectedIndexChanged="ddlsehir_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>

            <h5>Seçilen Bilgi</h5>

            <table>
                <tr>
                    <td>Kıta Adı</td>
                    <td>
                        <asp:Label ID="lblKita" runat="server" /></td>
                </tr>
                <tr>
                    <td>Ülke Adı</td>
                    <td>
                        <asp:Label ID="lblUlke" runat="server" /></td>
                </tr>
                <tr>
                    <td>Şehir Adı</td>
                    <td>
                        <asp:Label ID="lblŞehir" runat="server" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
