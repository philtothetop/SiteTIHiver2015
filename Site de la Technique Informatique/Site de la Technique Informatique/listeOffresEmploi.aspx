<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="listeOffresEmploi.aspx.cs" Inherits="Site_de_la_Technique_Informatique.listeOffresEmploi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-7 col-lg-push-1">
                <h1 style="margin-top: 80px;">Liste des offres d'emploi</h1>
                <asp:ListView ID="lviewOffresEmploi" runat="server" SelectMethod="getOffresEmploi" OnItemDataBound="lviewOffresEmploi_ItemDataBound" 
                    DataKeyNames="VilleIDVille,nbHeureSemaine">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkOffre" CommandArgument='<%# Eval("IDOffreEmploi").ToString()%>' OnClick="lnkOffre_Click"  Text="" runat="server">                        
                        <h3><asp:Label ID="lblTitreOffre" Text='<%# Eval("titreOffre").ToString()%>' runat="server"></asp:Label></h3>              
                        <asp:Label ID="lblVille" runat="server"></asp:Label>
                        <asp:Label ID="lblNbHeureSemaine" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblDescriptionOffre" Text='<%# Eval("descriptionOffre").ToString()%>' runat="server"></asp:Label>
                        </asp:LinkButton>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </LayoutTemplate>
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <asp:Label ID="lblPasDeMessage" runat="server">
                         <h4 class="sous-titre">Il n'y a aucune offre d'emploi disponible pour l'instant/h4>
                            </asp:Label>
                        </div>
                    </EmptyDataTemplate>
                </asp:ListView>
                <hr />
            </div>
        </div>
    </div>
</asp:Content>
