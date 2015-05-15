<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SectionForum.aspx.cs" Inherits="Site_de_la_Technique_Informatique.SectionForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-2">
                    <h1 class="page-header">
                        <asp:Label ID="lblSection" Text="Sections" runat="server" Font-Size="20"></asp:Label>
                    </h1>
                </div>
                <div style="margin-top: 45px;">
                    <asp:LinkButton ID="lnkMesDiscussions" Text="Mes discussions" runat="server" CssClass="btn btn-primary" PostBackUrl="~/MesDiscussionsForum.aspx" />
                </div>
            </div>
        </div>
        <div class="row">
            <asp:ListView ID="lviewSectionsForum" runat="server" SelectMethod="getSectionsForum">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkSection" CssClass="couleurGris" CommandArgument='<%# Eval("IDSectionForum").ToString()%>' OnClick="lnkSection_Click" Text="" runat="server" BorderStyle="Solid" BorderColor="black" BorderWidth="1" Style="width: 60%; border-radius: 5px; text-decoration: none; color: black; margin-top:5px">
                        <div class="col-lg-offset-1">
                            <asp:Label ID="lblTitreSection" Text='<%# Eval("titreSection").ToString()%>' Font-Size="14" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescriptionSection" Text='<%# Eval("descriptionSection").ToString()%>' Font-Size="12" runat="server"></asp:Label>
                        </div>
                    </asp:LinkButton>
                </ItemTemplate>
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <div style="text-align: center">
                        <asp:Label ID="lblPasDeMessage" runat="server">
                         <h4 class="sous-titre">Il n'y a aucune section de disponible pour l'instant</h4>
                        </asp:Label>
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>
            <hr />
        </div>
    </div>
</asp:Content>
