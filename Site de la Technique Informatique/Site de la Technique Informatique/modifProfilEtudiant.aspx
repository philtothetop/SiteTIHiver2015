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
    <!--Afficher les erreurs de input-->
    <script type="text/javascript">
        $(document).ready(function () {
            $(".has-error").removeClass("has-error");
            $(".has-feedback").removeClass("has-feedback");
            var idValue = '<%=this.lvModifProfilEtudiant.ClientID%>';
            var IDS = JSON.parse('<%= this.idsEnErreurTab%>');
            var MSGS = '<%= this.msgsEnErreur%>';

            for (index = 0; index < IDS.length; ++index) {
                var id = IDS[index];
                var msg = MSGS[index];
                   
                var element ="dv" + id;

                $("#" + element).addClass("has-error");
                $("#" + element).addClass("has-feedback");
                if(id=="NouveauMotDePasse"){
                    element = "dvConfirmationNouveauMotDePasse";
                    $("#" + element).addClass("has-error");
                    $("#" + element).addClass("has-feedback");
                }

            }

        });
    </script>
    <!--ToolTips-->
    <script type="text/javascript">
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
    </script>
    <!--Modal-->
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>

    <script type="text/javascript">
        function copieImgData()
        {
            document.getElementById("<%=ImgExSrc.ClientID%>").value = ContentPlaceHolder1_lvModifProfilEtudiant_showDataURL_0.src;
        }
    </script>
    <script type="text/javascript">
        window.transfertDataImg = function (dataURL) {
            $("#ContentPlaceHolder1_lvModifProfilEtudiant_showDataURL_0").attr("src", dataURL);
            document.getElementById("<%=ImgExSrc.ClientID%>").value = dataURL;
        };
    </script>
    <script type="text/javascript">
        window.closeModal = function () {
            $('#maPhotoProfile').modal('hide');
            $('#maPhotoProfile').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
        };
    </script>

    <!-- jQuery -->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="ImgExSrc" />
    <asp:ScriptManagerProxy ID="smProxy" runat="server" />
    <div class="container">
        <div class="col-lg-2"></div>
        <div class="col-lg-6 col-centered">

            <div class="container-fluid">
                <div class="control-group form-group">
                            <div class="controls">
                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                            </div>
                        </div>

                <asp:ListView ID="lvModifProfilEtudiant" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.Etudiant"
                    SelectMethod="SelectEtudiant"
                    UpdateMethod="UpdateEtudiant">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </LayoutTemplate>
                    <EmptyDataTemplate>
                        <table class="emptyTable">
                            <tr>
                                <td>
                                </td>
                                <td> L'étudiant n'existe pas.
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <div class="row row-centered">
                            <div class="col-lg-9 col-centered">
                                <h1>Modification du profil</h1>
                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <!-- Modal Profil picture-->
                                <div class="modif-photo">
                                    <div class="img-thumbnail img-photo preview-photo">
                                        <div></div>
                                        <asp:Image ID="showDataURL" runat="server" ImageUrl='<%#Eval ("pathPhotoProfil", "~//Upload//Photos//Profils//{0}")%>' Width="125" Height="125" />
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
                                                <iframe src='<%=".."+Request.ApplicationPath +"/Jquery/Cropper/Cropper.aspx"%>' width="570" height="625" scrolling="no" frameborder="0"></iframe>

                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <!--Fin Profil picture-->

                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Prénom:</label><br />
                                <asp:Label ID="lblPrenom" runat="server" placeholder="Prénom" Text='<%#Eval("prenom") %>' />

                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Nom:</label><br />
                                <asp:Label ID="lbltNom" runat="server" placeholder="Nom" Text='<%#Eval("nom") %>' />

                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Date de naissance:</label><br />

                                <asp:Label ID="lblDateNaissance" runat="server" Text='<%#Convert.ToDateTime(Eval("dateNaissance")).ToShortDateString() %>' />

                            </div>
                        </div>
                        <div class="control-group form-group" id="dvCourriel">
                            <div class="controls">
                                <label>Courriel:</label>
                                <asp:TextBox ID="txtCourriel" runat="server" CssClass="form-control" placeholder="courriel@exemple.qc.ca" Text='<%#BindItem.courriel %>' />
                                <asp:Label ID="lblCourriel" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <label>CV:</label>
                                <asp:LinkButton ID="lnkCV" runat="server" PostBackUrl='<%#Server.MapPath("~/ProjetDeux_2015_1/Upload/CV/" + Eval("pathCV")) %>' Text='<%#Eval("pathCV")%>' /><br />
                                <label>Changer de CV:</label>
                                <asp:FileUpload ID="fupCV" runat="server" />
                                (.pdf seulement)

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-8">
                                <h4>Changer votre mot de passe</h4>
                            </div>
                        </div>
                        <div class="control-group form-group" id="dvMotDePasse">
                            <div class="controls">
                                <label>Mot de passe actuel:</label>
                                <asp:TextBox ID="txtMotDePasse" runat="server" CssClass="form-control" Text="" TextMode="Password" />
                                <asp:Label ID="lblMotDePasse" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group" id="dvNouveauMotDePasse">
                            <div class="controls">
                                <label>Nouveau mot de passe:</label>
                                <asp:TextBox ID="txtNouveauMotDePasse" runat="server" CssClass="form-control" Text="" TextMode="Password" />
                                <asp:Label ID="lblNouveauMotDePasse" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group" id="dvConfirmationNouveauMotDePasse">
                            <div class="controls">
                                <label>Confirmation du nouveau mot de passe:</label>
                                <asp:TextBox ID="txtConfirmationNouveauMotDePasse" runat="server" CssClass="form-control" Text="" TextMode="Password" />
                                <asp:Label ID="lblConfirmationNouveauMotDePasse" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="row"></div>
                        <div class="col-lg-offset-8 col-lg-8 ">
                           
                           <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" CssClass="btn btn-danger" OnClick="btnAnnuler_Click" />
                            <asp:Button ID="btnSave" runat="server" Text="Sauvegarder" CssClass="btn btn-primary" CommandName="Update" OnClientClick="copieImgData()" />
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
