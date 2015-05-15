<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErreursImportants.aspx.cs" Inherits="Site_de_la_Technique_Informatique.ErreursImportants" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Erreurs</title>
    <link rel="icon" href="toast.gif" type="image/gif" />
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
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
                        - Département de la technique informatique.
                    </label>
                    <br />
                    <br />
                    <br />

                    <div style="text-align: center;">
                        <asp:LinkButton runat="server" CssClass="btn btn-primary" Text="Retour à l'accueil" OnClick="Redirect_Click" />
                    </div>
                </div>

                <div id="divLesErreurs" class="row">
                </div>


            </div>

    </div>
    </form>
</body>
</html>
