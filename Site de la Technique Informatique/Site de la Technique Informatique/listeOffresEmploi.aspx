<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="listeOffresEmploi.aspx.cs" Inherits="Site_de_la_Technique_Informatique.listeOffresEmploi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-7 col-lg-push-1">
                <h1 style="margin-top: 80px;">Liste des offres d'emploi</h1>
               <%-- <asp:listView id="lviewOffresEmploi" runat="server" selectMethod="getOffresEmploi" 
                    ItemType="Site_de_la_Technique_Informatique.OffreEmploiJeuSet" OnItemDataBound="lviewOffresEmploi_ItemDataBound">
                    <ItemTemplate>
                    <asp:Label id="lblTitreOffre" Text='<%# Eval("titreOffre").ToString()%>' runat="server"></asp:Label>
                    <asp:Label id="lblDescriptionOffre" Text='<%# Eval("descriptionOffre").ToString()%>' runat="server"></asp:Label>
                    <asp:Label id="lblVille" Text='<%# Eval("ville").ToString()%>' runat="server"></asp:Label>
                    <asp:Label id="lblNbHeuresSemaine" Text='<%# Eval("nbHeuresSemaine").ToString()%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:listView>--%>
                <hr />
            </div>
        </div>
    </div>
</asp:Content>
