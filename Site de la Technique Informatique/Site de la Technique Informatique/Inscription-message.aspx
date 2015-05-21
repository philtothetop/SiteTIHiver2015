<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription-message.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.Inscription_messaga" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Inscription</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row row-centered">
            <div class="col-lg-3 col-centered"></div>
            <div class="col-lg-6 col-centered">
                <h1>Inscription</h1>
                <p>
                    <asp:Label ID="lblMessage" runat="server" Text="Votre inscription a été sauvegardée.<br> Un courriel vous sera envoyé contenant un lien pour valider votre courriel." />
                    
                </p>
                <a href='<%=Request.ApplicationPath%>' class="btn btn-primary">Retour à l'accueil</a>
            </div>
            <div class="col-lg-3 col-centered"></div>
        </div>
    </div>

</asp:Content>
