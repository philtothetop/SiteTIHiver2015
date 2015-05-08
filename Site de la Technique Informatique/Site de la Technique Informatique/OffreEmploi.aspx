<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="OffreEmploi.aspx.cs" Inherits="Site_de_la_Technique_Informatique.OffreEmploi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <asp:Label ID="lblTitreOffre" runat="server" Font-Size="20"></asp:Label>
                </h1>
                <asp:LinkButton ID="lnkPDF" Text="Version PDF" runat="server" OnClick="lnkPDF_Click" Visible="false"></asp:LinkButton>
                <div style="float: right">
                    <asp:LinkButton ID="lnkSupprimer" Text="Supprimer l'offre" runat="server" OnClick="lnkSupprimer_Click" Visible="false"></asp:LinkButton>
                    <asp:LinkButton Style="margin-left: 5px" ID="lnkModifier" Text="Modifier l'offre" runat="server" OnClick="lnkModifier_Click" Visible="false"></asp:LinkButton>
                </div>

            </div>
        </div>
        <!-- /.row -->

        <!-- Content Row -->
        <div class="row">
            <div class="col-lg-12">

                <div class="col-lg-6">
                    <div class="row" style="margin-left: 5px; float: left;">
                        <asp:Label ID="lblDescriptionOffre" runat="server" Font-Size="14"></asp:Label>
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
                        <asp:Label ID="lblNoPoste" runat="server" Font-Size="14"></asp:Label>
                        <br />
                        <asp:Label ID="lblNoTelecopieur" runat="server" Font-Size="14"></asp:Label>
                        <br />
                        <asp:Label ID="lblCourrielOffre" runat="server" Font-Size="14"></asp:Label>
                        <br />
                        <asp:Label ID="lblPersonneRessource" runat="server" Font-Size="14"></asp:Label>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
