<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription-valide.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.validation_courriel" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Inscription : validation du courriel</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row row-centered">
            <div class="col-lg-6 col-centered">
                <h1>Inscription : validation du courriel</h1>
                <p>
                Votre courriel a été validé. Veuillez attendre que l'administrateur accepte votre inscription. Il vous contactera par courriel.
                    </p>
                <a href='<%=Request.ApplicationPath%>' class="btn btn-primary">Retour à l'accueil</a>
            </div>
        </div>
        </div>
    
</asp:Content>
