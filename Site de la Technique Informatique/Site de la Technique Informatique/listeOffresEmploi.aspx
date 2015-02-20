<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="listeOffresEmploi.aspx.cs" Inherits="Site_de_la_Technique_Informatique.listeOffresEmploi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1>Liste des offres d'emploi</h1>
            </div>
        </div>
        <div class="row">
            <asp:ListView ID="lviewOffresEmploi" runat="server" SelectMethod="getOffresEmploi" OnItemDataBound="lviewOffresEmploi_ItemDataBound"
                DataKeyNames="VilleIDVille,nbHeureSemaine">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkOffre" CommandArgument='<%# Eval("IDOffreEmploi").ToString()%>' OnClick="lnkOffre_Click" Text="" runat="server" BorderStyle="Solid" BorderColor="black" BorderWidth="1" Style="width: 80%">
                        <div class="row">
                            <div class="col-lg-4">
                                <asp:Label ID="lblTitreOffre" Text='<%# Eval("titreOffre").ToString()%>' Font-Size="20" runat="server" Style="color: black; text-decoration: none; padding-left: 20px"></asp:Label>
                            </div>
                            <div class="col-lg-4">
                                <asp:Label ID="lblVille" runat="server" Font-Size="14" Style="color: black; text-decoration: none"></asp:Label>
                            </div>
                            <div class="col-lg-3">
                                <asp:Label ID="lblNbHeureSemaine" runat="server" Font-Size="14" Style="color: black; text-decoration: none"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:Label ID="lblDescriptionOffre" Text='<%# Eval("descriptionOffre").ToString()%>' runat="server" Font-Size="14" Style="color: black; text-decoration: none; padding-left: 20px"></asp:Label>
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
    </div>
</asp:Content>
