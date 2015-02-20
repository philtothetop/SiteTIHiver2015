<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="OffreEmploi.aspx.cs" Inherits="Site_de_la_Technique_Informatique.OffreEmploi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 style="margin-top: 80px;">Offre d'emploi</h1>
                <div class="row">
                    <asp:ListView ID="lviewOffreEmploi" runat="server" SelectMethod="getOffreEmploi" OnItemDataBound="lviewOffreEmploi_ItemDataBound"
                        DataKeyNames="VilleIDVille,nbHeureSemaine">
                        <ItemTemplate>
                            <h3>
                                <asp:Label ID="lblTitreOffre" Text='<%# Eval("titreOffre").ToString()%>' runat="server"></asp:Label></h3>
                            <asp:Label ID="lblVille" runat="server"></asp:Label>
                            <asp:Label ID="lblNbHeureSemaine" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescriptionOffre" Text='<%# Eval("descriptionOffre").ToString()%>' runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDateOffre" Text='<%# Eval("dateOffre").ToString()%>' runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDateExpiration" Text='<%# Eval("dateExpiration").ToString()%>' runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDateDebutOffre" Text='<%# Eval("dateDebutOffre").ToString()%>' runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblPathPDSDescription" Text='<%# Eval("pathPDSDescription").ToString()%>' runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblSalaire" Text='<%# Eval("salaire").ToString()%>' runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblAdresseTravail" Text='<%# Eval("adresseTravail").ToString()%>' runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblNoTelephone" Text='<%# Eval("noTelephone").ToString()%>' runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblNoTelecopieur" Text='<%# Eval("noTelecopieur").ToString()%>' runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblCourrielOffre" Text='<%# Eval("courrielOffre").ToString()%>' runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblPersonneRessource" Text='<%# Eval("personneRessource").ToString()%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </LayoutTemplate>
                    </asp:ListView>
                    <hr />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
