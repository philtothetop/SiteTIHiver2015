<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="listeOffresEmploi.aspx.cs" Inherits="Site_de_la_Technique_Informatique.listeOffresEmploi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-5">
                    <h1>Liste des offres d'emploi</h1>
                </div>
                <div style="margin-top: 25px;">
                    <asp:LinkButton ID="lnkAjouterOffre" Text="Ajouter une offre" runat="server" CssClass="btn btn-default" PostBackUrl="~/AjoutOffreEmploi.aspx" Visible="false" />
                </div>
            </div>
        </div>
        <div class="row">
            <asp:ListView ID="lviewOffresEmploi" runat="server" SelectMethod="getOffresEmploi" OnItemDataBound="lviewOffresEmploi_ItemDataBound"
                DataKeyNames="VilleIDVille,nbHeureSemaine">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkOffre" CssClass="couleurGris" CommandArgument='<%# Eval("IDOffreEmploi").ToString()%>' OnClick="lnkOffre_Click" Text="" runat="server" BorderStyle="Solid" BorderColor="black" BorderWidth="1" Style="width: 60%; border-radius: 5px;">
                        <div class="row">
                            <div class="col-lg-12">

                                <div class="col-lg-4" style="text-align: left;">
                                    <asp:Label ID="lblVille" runat="server" Font-Size="10" Style="text-decoration: none; color: black;"></asp:Label>
                                </div>

                                <div class="col-lg-4" style="text-align: center;">

                                    <asp:Label ID="lblTitreOffre" Text='<%# Eval("titreOffre").ToString()%>' Font-Size="12" runat="server" Style="text-decoration: none; color: black;"></asp:Label>
                                </div>

                                <div class="col-lg-4" style="text-align: right;">
                                    <asp:Label ID="lblNbHeureSemaine" runat="server" Font-Size="10" Style="text-decoration: none; color: black;"></asp:Label>
                                </div>

                                <div class="col-lg-12" style="text-align: center;">
                                    <asp:Label ID="lblDescriptionOffre" Text='<%# Eval("descriptionOffre").ToString()%>' runat="server" Font-Size="10" Style="text-decoration: none; color: black;"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </ItemTemplate>
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <div style="text-align: center">
                        <asp:Label ID="lblPasDeMessage" runat="server">
                         <h4 class="sous-titre">Il n'y a aucune offre d'emploi disponible pour l'instant</h4>
                        </asp:Label>
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>
            <hr />
        </div>
        <div style="text-align: center; width: 100%;">
            <asp:DataPager ID="dataPager" runat="server" PagedControlID="lviewOffresEmploi"
                PageSize="10">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" PreviousPageText="<<" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="False" ShowPreviousPageButton="False" NextPageText=">>" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>
