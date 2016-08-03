<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebDropDownListExample.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span style="font-family: Arial">Select Continent : </span>
            <asp:DropDownList ID="ddlContinents" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlContinents_SelectedIndexChanged">
                <asp:ListItem Text="--Select Continent--" Value=""></asp:ListItem>
            </asp:DropDownList>

            <br />
            <br />
            <span style="font-family: Arial">Select Country : </span>
            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true"
                Enabled="false" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                <asp:ListItem Text="--Select Country--" Value=""></asp:ListItem>
            </asp:DropDownList>

            <br />
            <br />
            <span style="font-family: Arial">Select City : </span>
            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true"
                Enabled="false" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                <asp:ListItem Text="--Select City--" Value=""></asp:ListItem>
            </asp:DropDownList>

            <br />
            <br />
            <asp:Label ID="lblResults" runat="server" Text="" Font-Names="Arial" />
        </div>
    </form>
</body>
</html>
