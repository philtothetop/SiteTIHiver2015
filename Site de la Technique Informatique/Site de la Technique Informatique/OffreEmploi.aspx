<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="OffreEmploi.aspx.cs" Inherits="Site_de_la_Technique_Informatique.OffreEmploi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-3">
                <h1>Offre d'emploi</h1>
            </div>
            <div class="col-lg-3">
                <asp:Button class="btn-default" ID="btnRetour" runat="server" Text="Retour" PostBackUrl="~/ListeOffresEmploi.aspx" Style="margin-top: 30px;" />
            </div>
        </div>
        <div class="row" style="margin-left: 5px">
            <asp:Label ID="lblTitreOffre" runat="server" Font-Size="20"></asp:Label>
            <br />
            <asp:Label ID="lblDescriptionOffre" runat="server" Font-Size="14"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblAdresseVille" runat="server" Font-Size="14"></asp:Label>
            <br />
            <asp:Label ID="lblNbHeureSemaine" runat="server" Font-Size="14"></asp:Label>
            <br />
            <asp:Label ID="lblDateExpiration" runat="server" Font-Size="14"></asp:Label>
            <br />
            <asp:Label ID="lblDateDebutOffre" runat="server" Font-Size="14"></asp:Label>
            <br />
            <asp:Label ID="lblSalaire" runat="server" Font-Size="14"></asp:Label>
            <br />
            <asp:Label ID="lblNoTelephone" runat="server" Font-Size="14"></asp:Label>
            <br />
            <asp:Label ID="lblNoTelecopieur" runat="server" Font-Size="14"></asp:Label>
            <br />
            <asp:Label ID="lblCourrielOffre" runat="server" Font-Size="14"></asp:Label>
            <br />
            <asp:Label ID="lblPersonneRessource" runat="server" Font-Size="14"></asp:Label>
            <br />
            <asp:LinkButton ID="lnkPDF" Text="Version PDF" runat="server" OnClick="lnkPDF_Click"></asp:LinkButton>
            <br />
        </div>
    </div>
</asp:Content>
