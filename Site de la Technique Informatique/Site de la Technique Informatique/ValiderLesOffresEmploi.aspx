<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValiderLesOffresEmploi.aspx.cs" Inherits="Site_de_la_Technique_Informatique.ValiderLesOffresEmploi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-3">
                <h1>Valider les offres d'emploi</h1>
            </div>
        </div>

        <asp:ListView ID="lviewOffresDEmploi" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.OffreEmploi"
                        SelectMethod="GetLesOffresDEmploi">

                        <LayoutTemplate>
                            <div>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </div>
                        </LayoutTemplate>

                        <ItemTemplate>

                            <div class="row" style="margin-left: 5px">
            <asp:Label ID="lblTitreOffre" runat="server" Font-Size="20" Text='<%# Item.titreOffre %>'></asp:Label>
            <br />
            <asp:Label ID="lblDescriptionOffre" runat="server" Font-Size="14" Text='<%# Item.descriptionOffre %>'></asp:Label>
            <br />
            <br />
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
            <asp:LinkButton ID="lnkPDF" Text="Version PDF" runat="server" CommandArgument='<%# Item.pathPDFDescription %>' OnClick="lnkPDF_Click"></asp:LinkButton>
            <br />
        </div>

                            <div>
                                <div style="float:left;">
                                    <asp:Button ID="btnValiderOffre" runat="server" Text="Valider" CssClass="btn btn-success" Width="100px" OnClick="accepterOffreEmploi_Click" CommandArgument='<%# Item.IDOffreEmploi %>'  />

                                </div>
                                <div style="float:right;">
                                    <asp:Button ID="btnRefuserOffre" runat="server" Text="Refuser" CssClass="btn btn-danger" Width="100px" OnClick="refuserOffreEmploi_Click" CommandArgument='<%# Item.IDOffreEmploi %>' />
                                </div>

                            </div>
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
