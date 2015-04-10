<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MesDiscussionsForum.aspx.cs" Inherits="Site_de_la_Technique_Informatique.MesDiscussionsForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-3">
                    <h1 class="page-header">
                        <asp:Label ID="lblTitre" Text="Mes discussions" runat="server" Font-Size="20"></asp:Label>
                    </h1>
                </div>
            </div>
        </div>
        <ol class="breadcrumb">
            <li><a href="SectionForum.aspx">Retour aux sections</a>
            </li>
        </ol>
        <div class="row">
            <asp:ListView ID="lviewMesDiscussions" runat="server" SelectMethod="getEntetesForum" DataKeyNames="MembreIDUtilisateur, dateEnteteForum" OnItemDataBound="lviewMesDiscussions_ItemDataBound">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEntete" CssClass="couleurGris" CommandArgument='<%# Eval("IDEnteteForum").ToString()%>' OnClick="lnkEntete_Click" Text="" runat="server" BorderStyle="Solid" BorderColor="black" BorderWidth="1" Style="width: 60%; border-radius: 5px; text-decoration: none; color: black;">
                        <div class="col-lg-offset-1">
                            <asp:Label ID="lblTitreEntete" Text='<%# Eval("titreEnteteForum").ToString()%>' Font-Size="14" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblNom" Font-Size="12" runat="server"></asp:Label>
                            <asp:Label ID="lblDateForum" Font-Size="12" runat="server" Style="float: right; margin-right: 20px"></asp:Label>
                        </div>
                        <br />
                    </asp:LinkButton>
                </ItemTemplate>
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <div style="text-align: center">
                        <asp:Label ID="lblPasDeMessage" runat="server">
                         <h4 class="sous-titre">Vous ne participez à aucune discussion</h4>
                        </asp:Label>
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>
            <hr />
        </div>
    </div>
</asp:Content>