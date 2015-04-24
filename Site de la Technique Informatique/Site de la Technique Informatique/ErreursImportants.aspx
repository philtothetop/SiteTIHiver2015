<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErreursImportants.aspx.cs" Inherits="Site_de_la_Technique_Informatique.ErreursImportants" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div style="margin: 200px;">
                <div id="divLesExcuses" class="row">
                    <h3>humm... c'est embarrassant...</h3>
                    <label>
                        Nous sommes désolés, il semblerait que l'une de vos manoeuvres a fait s'écrouler la page où vous étiez.<br />
                        Nous tenons ce problème très à coeur et en cas de problème persistant, veuillez contacter le Cégep de Granby
                        - Département de la technique informatique. <a href="../Default.aspx">Revenir à l'accueil</a>.
                    </label>
                    <br />
                    <br />
                    <br />

                    <label­>Ce message est pour retracer l'erreur. N'en tenez pas compte.</label>
                    <div id="error" runat="server" visible="false">
                        <asp:Label runat="server" ID="lblErreurs" />
                        <br />
                        <asp:Label runat="server" ID="lblInnerTrace" />
                        <br />
                        <asp:Label runat="server" ID="lblStackTrace" />
                    </div>

                </div>

                <div id="divLesErreurs" class="row">
                </div>


            </div>

    </div>
    </form>
</body>
</html>
