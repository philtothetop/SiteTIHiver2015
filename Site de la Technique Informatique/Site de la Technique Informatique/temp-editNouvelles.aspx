<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="temp-editNouvelles.aspx.cs" Inherits="Site_de_la_Technique_Informatique.temp_editNouvelles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ListView ID="lviewNouvelles" runat="server"
            ItemType="Site_de_la_Technique_Informatique.Model.Nouvelle"
            SelectMethod="getNouvelles">
            <LayoutTemplate>
                <div class="panel panel-default">
                    <ul>
                        <li id="itemPlaceholder" runat="server" />
                    </ul>
                    <div style="margin-left: auto; margin-right: auto; width: 250px;">
                        <asp:Button ID="btnAjouter" runat="server" Text="Ajouter une nouvelle" />                       
                    </div>
                     <br />
                </div>

            </LayoutTemplate>
            <ItemTemplate>
                <div class="panel-body">
                    <asp:LinkButton runat="server" ID="lnkEditNews" OnCommand="lnkEditNews_Command" CommandArgument="<%# Item.IDNouvelle %>"><%# Item.titreNouvelle %></asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:ListView>


        <asp:ListView ID="lviewEditNews" runat="server"
            ItemType="Site_de_la_Technique_Informatique.Model.Nouvelle"
            SelectMethod="getEditNouvelles">
            <LayoutTemplate>
                <div class="panel panel-default">
                    <div id="itemPlaceholder" runat="server" />
                    <div>
                        <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" />
                        <asp:Button ID="btnModifier" runat="server" Text="Modifier" />
                        <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" />
                        <asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" />
                    </div>
                    <br />
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="panel-body">
                    <asp:Label runat="server" Text="Titre:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtTitreNouvelle" Text="<%# BindItem.titreNouvelle %>" Width="350px"></asp:TextBox>
                    <div style="margin-top: 10px;">
                        <asp:Label runat="server" Text="Contenu de la nouvelle" />
                    </div>
                    <div>
                        <asp:TextBox ID="txtContenuNouvelle" runat="server" TextMode="MultiLine" Text="<%# BindItem.texteNouvelle %>" Style="overflow-y: scroll; overflow-x: hidden" Width="700px" Height="350px" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
