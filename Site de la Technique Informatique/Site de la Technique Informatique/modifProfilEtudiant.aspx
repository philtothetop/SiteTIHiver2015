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
      <link href="../Css/Inscription.css" rel="stylesheet" />
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
    <script type="text/javascript">
        function copieImgData() {
            document.getElementById("<%=ImgExSrc.ClientID%>").value = ContentPlaceHolder1_lvModifProfilEtudiant_showDataURL_0.src;
        }
    </script>
    <script type="text/javascript">
        window.transfertDataImg = function (dataURL) {
            $("#ContentPlaceHolder1_lvModifProfilEtudiant_showDataURL_0").attr("src", dataURL);
        };
    </script>
    <script type="text/javascript">
        window.closeModal = function () {
            $('#maPhotoProfile').modal('hide');
        };
    </script>
    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:HiddenField runat="server" ID="ImgExSrc" />
        <asp:ScriptManagerProxy ID="smProxy" runat="server" />
    <div class="container">
        <div class="col-lg-6 col-centered">
            
            <div class="container-fluid">
                <asp:ListView ID="lvModifProfilEtudiant" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.Etudiant"
                    SelectMethod="SelectEtudiant"
                    UpdateMethod="UpdateEtudiant" 
                    DeleteMethod="lvModifProfilEtudiant_DeleteItem"
                    >
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="control-group form-group">
                            <div class="controls">
                                <!-- Modal Profil picture-->
                                        <div class="modif-photo">
                                            <div class="img-thumbnail img-photo preview-photo">
                                                <div></div>
                                                <asp:Image ID="showDataURL" runat="server" ImageUrl='<%#Eval("Photos/Profils/{0}","pathPhotoProfil") %>' Width="125" Height="125" />
                                            </div>
                                            <div class="div-btnChangerPhoto">
                                                <asp:LinkButton ID="lnkProfilePhoto" runat="server" Text="Changer la photo du profil" CssClass="btn btn-primary btnChangerPhoto" data-toggle="modal" data-target="#maPhotoProfile" />

                                            </div>
                                        </div>
                                        <div class="modal" id="maPhotoProfile" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                        <h4 class="modal-title" id="myModalLabelProfile">Photo profil</h4>
                                                    </div>
                                                    <div class="modal-body">
                                                        <iframe src="../Jquery/Cropper/Cropper.aspx" width="570" height="625" scrolling="no" frameborder="0"></iframe>

                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                <!--Fin Profil picture-->

                            </div>
                        </div>
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
                                        <asp:TextBox ID="txtDateNaissanceJour" runat="server" CssClass="form-control inputJourMois" placeholder="JJ" Text='<%#BindItem.dateNaissance.Day %>' />
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="txtDateNaissanceMois" runat="server" CssClass="form-control inputJourMois" placeholder="mm" Text='<%#BindItem.dateNaissance.Month %>' />
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox ID="txtDateNaissanceAnnee" runat="server" CssClass="form-control" placeholder="AAAA" Text='<%#BindItem.dateNaissance.Year %>' />
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
                                                <div class="control-group form-group">
                            <div class="controls">
                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="row"></div>
                        <div class="col-lg-offset-4 col-lg-9 ">
                            <asp:LinkButton ID="lnkEffacerCompte" runat="server" Text="Supprimer compte" CssClass="btn btn-default"  CommandName="Delete" />
                            <asp:Button ID="btnSave" runat="server" Text="Sauvegarder" CssClass="btn btn-primary" CommandName="Update"  OnClientClick="copieImgData()" />
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
