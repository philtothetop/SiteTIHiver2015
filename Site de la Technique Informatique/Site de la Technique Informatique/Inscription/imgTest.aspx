<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imgTest.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.imgTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="txtBox" runat="server" Text=""></asp:TextBox>
        <asp:LinkButton ID="lnk" runat="server" Text="go" OnClick="lnk_Click" />
    </div>
    </form>
</body>
</html>
