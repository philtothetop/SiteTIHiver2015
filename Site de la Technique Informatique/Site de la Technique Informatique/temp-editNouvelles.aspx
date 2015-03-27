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
            SelectMethod="getEditNouvelles"
            UpdateMethod="lviewEditNews_UpdateItem"
            DataKeyNames="IDNouvelle">
            <LayoutTemplate>
                <div class="panel panel-default">
                    <div id="itemPlaceholder" runat="server" />                  
                    <br />
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="panel-body">
                    <asp:Label ID="idNews" runat="server" Text='<%# Item.IDNouvelle %>'></asp:Label>
                    <asp:Label runat="server" Text="Titre:"></asp:Label>                
                    <asp:TextBox runat="server" ID="txtTitreNouvelle" Text="<%# BindItem.titreNouvelle %>" Width="350px"></asp:TextBox>
                    <asp:CheckBox ID="chkMajor" runat="server" Text="Modification Importante"></asp:CheckBox>
                    <div style="margin-top: 10px;">
                        <asp:Label runat="server" Text="Contenu de la nouvelle" />
                    </div>
                    <div>
                        <asp:TextBox ID="txtContenuNouvelle" runat="server" TextMode="MultiLine" Text="<%# BindItem.texteNouvelle %>" Style="overflow-y: scroll; overflow-x: hidden" Width="700px" Height="350px" />
                    </div>
                </div>
                 <div>
                        <asp:Button ID="btnModifier" runat="server" Text="Modifier" CommandName="Update" />
                        <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" />
                        <asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" />
                    </div>
            </ItemTemplate>
        </asp:ListView>


        <div class="panel panel-default">
            <div class="panel-body">
                <asp:Label runat="server" Text="Titre:"></asp:Label>
                <asp:TextBox runat="server" ID="txtTitreAjout" Width="350px"></asp:TextBox>
                <div style="margin-top: 10px;">
                    <asp:Label runat="server" Text="Contenu de la nouvelle" />
                </div>
                <div>
                    <asp:TextBox ID="txtNouvelleAjout" runat="server" TextMode="MultiLine" Style="overflow-y: scroll; overflow-x: hidden" Width="700px" Height="350px" />
                </div>
            </div>
            <div>
                <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" OnClick="btnAjouter_Click" />
                <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" />
            </div>
            <br />
        </div>
    </div>
</asp:Content>
