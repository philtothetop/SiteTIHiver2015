<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EnteteForum.aspx.cs" Inherits="Site_de_la_Technique_Informatique.EnteteForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-3">
                    <h1 class="page-header">
                        <asp:Label ID="lblTitreSection" runat="server" Font-Size="20"></asp:Label>
                    </h1>
                </div>
                <div style="margin-top: 45px;">
                    <asp:LinkButton ID="lnkNouvelleDiscusison" Text="Nouvelle discussion" runat="server" CssClass="btn btn-default" OnClick="lnkNouvelleDiscusison_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <asp:ListView ID="lviewEntete" runat="server" SelectMethod="getEntetesForum" DataKeyNames="MembreIDUtilisateur, dateEnteteForum,IDEnteteForum" OnItemDataBound="lviewEntete_ItemDataBound">
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
                         <h4 class="sous-titre">Il n'y a aucune discussion pour l'instant</h4>
                        </asp:Label>
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>
            <hr />
        </div>
    </div>
</asp:Content>
