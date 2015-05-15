<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Admin_Temoignage.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_Temoignage" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/AdministrateutTemoignage.css" rel="stylesheet" />

    <h1 class="page-header">Témoignages</h1>

    <asp:Button ID="btnVoirTemoignageNonValide" runat="server" Text="Témoignages non-validés" CssClass="btn btnTemoignageSelectionne" OnClick="VoirTemoignageNonValide_Click" />
    <asp:Button ID="btnVoirTemoignageValide" runat="server" Text="Témoignages validés" CssClass="btn btn-default" OnClick="VoirTemoignageValide_Click" />


    <asp:ListView ID="lviewTemoignage" runat="server"
        ItemType="Site_de_la_Technique_Informatique.Model.Membre"
        SelectMethod="GetLesTemoignages">

        <LayoutTemplate>
            <div>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </div>
        </LayoutTemplate>

        <ItemTemplate>
            <div style="padding-right: 5px;">
                <h2><%# Item.nom + ", " + Item.prenom %></h2>
                <asp:Label ID="lblTemoignage" runat="server" Text='<%# Item.temoignage.Replace("¤","<br />") %>'></asp:Label>
                <br />
                <br />
                <div id="divPourAccepterTemoignage" runat="server" visible='<%# savoirSiEstUnEtudiant(Item) %>' style="float: left;">
                    <asp:Button ID="btnAccepterTemoignage" runat="server" Text="Accepter" CssClass="btn btn-success" CommandArgument='<%# Item.IDMembre %>' OnClick="AccepterTemoignage_Click" />

                </div>
                <div style="float: right;">

                    <asp:Button ID="btnRefuserTemoignage" runat="server" Text="Refuser/Supprimer" CssClass="btn btn-danger" CommandArgument='<%# Item.IDMembre %>' OnClick="SupprimerTemoignage_Click" />

                </div>

            </div>

            <div style="clear: both; height: 10px; border-bottom: black solid 1px;">
            </div>

        </ItemTemplate>

        <EmptyDataTemplate>
            <div>
                <div style="width: 100%; text-align: center; padding-top: 20px;">
                    <asp:Label ID="lblPasDeTemoignage" runat="server" Text="Il n'y a pas de témoignage pour le moment" Style="font: bold; font-size: large"></asp:Label>
                </div>
            </div>
        </EmptyDataTemplate>

    </asp:ListView>

    <div style="text-align: center; width: 100%;">

        <asp:DataPager ID="dataPagerDesTemoignages" runat="server" PagedControlID="lviewTemoignage"
            PageSize="6">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" PreviousPageText="<<" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="False" ShowPreviousPageButton="False" NextPageText=">>" />
            </Fields>
        </asp:DataPager>
    </div>

    <asp:HiddenField ID="hfieldVoirTemoignageValideOuNon" runat="server" Value="NonValidé" />

</asp:Content>
