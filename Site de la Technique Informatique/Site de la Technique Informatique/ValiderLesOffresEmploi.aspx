<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValiderLesOffresEmploi.aspx.cs" Inherits="Site_de_la_Technique_Informatique.ValiderLesOffresEmploi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1>Valider les offres d'emploi</h1>
            </div>
        </div>

        <asp:ListView ID="lviewOffresDEmploi" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.OffreEmploi"
                        SelectMethod="GetLesOffresDEmploi">

                        <LayoutTemplate>
                            <div>
                                
                <ol class="breadcrumb">
                    <li><a href="nullFORnow.aspx">Retour au panneau d'administration</a>
                    </li>
                    <li class="active">
                        <asp:Label ID="lblTitreOffre2" runat="server" Font-Size="10"></asp:Label>
                    </li>
                </ol>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </div>
                        </LayoutTemplate>

                        <ItemTemplate>
                            <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
            <asp:Label ID="lblTitreOffre" runat="server" Font-Size="20" Text='<%# Item.titreOffre %>'></asp:Label>
                </h1>
            </div>
        </div>
        <!-- /.row -->

        <!-- Content Row -->
        <div class="row">
            <div class="col-lg-12">

                <div class="col-lg-6">
                    <div class="row" style="margin-left: 5px; float: left;">

                        <asp:Label ID="lblAdresseVille" runat="server" Font-Size="14" Text='<%# Item.adresseTravail %>'></asp:Label>
            <br />
            <asp:Label ID="lblNbHeureSemaine" runat="server" Font-Size="14" Text='<%# Item.nbHeureSemaine %>'></asp:Label>
            <br />
            <asp:Label ID="lblDateExpiration" runat="server" Font-Size="14" Text='<%# Item.dateExpiration %>'></asp:Label>
            <br />
            <asp:Label ID="lblDateDebutOffre" runat="server" Font-Size="14" Text='<%# Item.dateDebutOffre %>'></asp:Label>
            <br />
            <asp:Label ID="lblSalaire" runat="server" Font-Size="14" Text='<%# Item.salaire %>'></asp:Label>
            <br />
            <asp:Label ID="lblNoTelephone" runat="server" Font-Size="14" Text='<%# Item.noTelephone %>'></asp:Label>
            <br />
            <asp:Label ID="lblNoTelecopieur" runat="server" Font-Size="14" Text='<%# Item.noTelecopieur %>'></asp:Label>
            <br />
            <asp:Label ID="lblCourrielOffre" runat="server" Font-Size="14" Text='<%# Item.courrielOffre %>'></asp:Label>
            <br />
            <asp:Label ID="lblPersonneRessource" runat="server" Font-Size="14" Text='<%# Item.personneRessource %>'></asp:Label>
                        <br />
            <asp:LinkButton ID="LinkButton1" Text="Version PDF" runat="server" CommandArgument='<%# Item.pathPDFDescription %>' OnClick="lnkPDF_Click"></asp:LinkButton>
                        <br />

                    </div>

                </div>
                <div class="col-lg-6" style="font-weight:bold;">
            <asp:Label ID="lblDescriptionOffre" runat="server" Font-Size="14" Text='<%# Item.descriptionOffre %>'></asp:Label>
                </div>

            </div>
        </div>
        </div>
                            <div style="clear:both; height:10px"></div>
                        </ItemTemplate>

            <EmptyDataTemplate>
                <div style="width:100%; text-align:center;">
                       <asp:Label ID="lblPasOffreDEmploi" runat="server" Text="Il n'y a pas d'offre d'emploi à valider pour le moment" style="font:bold; font-size:large"></asp:Label>
                </div>
                </EmptyDataTemplate>
            
        </asp:ListView>

        <div style="text-align:center; width:100%;">
            <asp:DataPager ID="dataPagerDesLogs" runat="server" PagedControlID="lviewOffresDEmploi"
                            PageSize="4">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" PreviousPageText="<<" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowLastPageButton="False" ShowPreviousPageButton="False" NextPageText=">>" />
                            </Fields>
                        </asp:DataPager>
                </div>

        </div>
</asp:Content>
