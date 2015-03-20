<%@ Page Title="Recherche de membres" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recherche.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Recherche" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page Heading/Breadcrumbs -->
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Recherche de Membre
            </h1>
            <ol class="breadcrumb">
                <li><a href="Default.aspx">Accueil</a>
                </li>
                <li class="active">Recherche de membre</li>
            </ol>
        </div>
    </div>
    <div style="padding-left: 20px;">
        <table>
            <tr>
                <td>
                        <asp:Label ID="Label1" runat="server" Text="Nom du Membre:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtNomMembre"></asp:TextBox>
                    </div>                 
                    <div style="padding-top: 5px;">
                        <asp:Label ID="Label2" runat="server" Text="Type de Membre:"></asp:Label>
                        <asp:CheckBox ID="chbProfesseur" Text="Professeur" runat="server" TextAlign="Left" />
                        <asp:CheckBox ID="chbEtudiant" Text="Etudiant" runat="server" TextAlign="Left" Style="margin-left: 10px;" />
                    </div>
                    <div style="padding-top: 5px;">
                        <asp:Button runat="server" ID="btnRecherche" Text="Rechercher" OnClick="btnRecherche_Click"></asp:Button>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="panelResultats" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="false">
            <asp:ListView runat="server"
                ID="lviewRecherche"
                ItemType="Site_de_la_Technique_Informatique.Model.Membre"
                SelectMethod="lviewRecherche_GetData">
                <LayoutTemplate>
                    <div style="margin: 10px; padding: 3px; margin-top: 20px;">
                        <table runat="server" id="table1" style="width: 100%;">
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr id="Tr1" runat="server" style="border: 1px  dashed; height:80px;">
                        <td id="Td1" runat="server">
                            <%-- Data-bound content. --%>
                            <div style="height: auto">
                                <div style="float: left; margin-top: -3px"> 
                                       <asp:Image ID="photoProfil" runat="server" Height="75px" Width="75px" style="margin-top:2px; margin-left:2px;" ImageUrl='<%# Item.pathPhotoProfil %>'></asp:Image>                                
                                </div>
                                <div class="span7">
                                    <asp:LinkButton runat="server" ID="lnkUserFound" Style="width: 70px; margin-left: 5px;" Text='<%# Item.prenom + " " + Item.nom%>'></asp:LinkButton>
                                    <div class="span7">
                                        <p runat="server" id="P1" style="margin-left: 80px; font-size: small;"><%# Item.courriel %></p>
                                    </div>
                                </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </asp:Panel>
    </div>
</asp:Content>
