<%--Cette classe permet aux étudiants de modifier leur profil (photo de profil, nom, prénom, courriel, mot de passe)
Écrit par Marie-Philippe Gill, Février 2015
Intrants: MasterPage
Extrants: --%>

<%-- CÉDRIC : 
    - Changer la photo de profil 
    - Changer l'email (codé, je n'ai pas pu tester cette partie, connexion non fonctionnelle)
    - Envoi du courriel de validation au changement de l'email 
    - Changement du mot de passe
    - Gestion des messages d'erreur? 

    Marie-Philippe: 
    - Changement du nom (Fonctionne)
    - Changement du prénom (fonctionne)
    --%>

<%@ Page Title="Modification de votre profil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modifProfilEtudiant.aspx.cs" Inherits="Site_de_la_Technique_Informatique.modifProfilEtudiant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="col-lg-6 col-centered">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <div class="container-fluid">
                <asp:ListView ID="lvModifProfilEtudiant" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.Etudiant"
                    SelectMethod="SelectEtudiant"
                    UpdateMethod="UpdateEtudiant">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Prénom:</label>
                                <asp:TextBox ID="txtPrenom" runat="server" CssClass="form-control" placeholder="Prénom" Text='<%#BindItem.prenom %>' name="fname" />
                                <asp:Label ID="lblPrenom" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Nom:</label>
                                <asp:TextBox ID="txtNom" runat="server" CssClass="form-control" placeholder="Nom" Text='<%#BindItem.nom %>' name="lname" />
                                <asp:Label ID="lblNom" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Date de naissance:</label>
                                <div class="row">
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="txtDateNaissanceJour" runat="server" CssClass="form-control inputJourMois" placeholder="JJ" />
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="txtDateNaissanceMois" runat="server" CssClass="form-control inputJourMois" placeholder="mm" />
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox ID="txtDateNaissanceAnnee" runat="server" CssClass="form-control" placeholder="AAAA" />
                                    </div>
                                    <asp:Label ID="lblDateNaissance" runat="server" Text="" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Courriel:</label>
                                <asp:TextBox ID="txtCourriel" runat="server" CssClass="form-control" placeholder="courriel@exemple.qc.ca" Text='<%#BindItem.courriel %>' />
                                <asp:Label ID="lblCourriel" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="row"></div>
                        <div class="col-lg-offset-8 col-lg-3">
                            <asp:Button ID="btnSave" runat="server" Text="Sauvegarder" CssClass="btn btn-primary" CommandName="Update" />
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
