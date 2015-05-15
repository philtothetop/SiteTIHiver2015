<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageNotFound.aspx.cs" Inherits="Site_de_la_Technique_Informatique.PageNotFound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Page Not Found</title>
    <%--lien du favicon a la racine--%>
    <link rel="icon" href="toast.gif" type="image/gif" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center;">
        <h1 style="margin-top:100px;">Vous êtes arrivés sur le fameux 404 NOT FOUND</h1>
        <asp:LinkButton runat="server" CssClass="btn btn-primary" Text="Accueil" OnClick="Redirect_Click" />
        <a href="../Default.aspx">
            <img src="Photos/image2.jpg" height="600" width="900" />    
            <br /><br />
        </a>             
    </div>
    </form>
</body>
</html>