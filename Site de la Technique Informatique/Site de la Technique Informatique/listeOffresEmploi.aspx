<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="listeOffresEmploi.aspx.cs" Inherits="Site_de_la_Technique_Informatique.listeOffresEmploi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-7 col-lg-push-1">
                <h1 style="margin-top: 80px;">Liste des offres d'emploi</h1>
                <asp:listView id="lviewOffresEmploi" runat="server" selectMethod="getOffresEmploi" 
                    ItemType="Site_de_la_Technique_Informatique.OffreEmploiJeu" OnItemDataBound="lviewOffresEmploi_ItemDataBound">

                </asp:listView>
                <hr />
            </div>
        </div>
    </div>
</asp:Content>
