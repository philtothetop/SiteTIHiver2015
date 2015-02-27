﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription-formulaire.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.Inscription_formulaire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Css/Inscription.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta content="IE=edge" http-equiv="X-UA-Compatible">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="A basic example of Cropper.">
    <meta name="keywords" content="HTML, CSS, JS, JavaScript, jQuery, image cropping, web development">
    <meta name="author" content="Fengyuan Chen">
    <title>Cropper</title>
    <link href="Cropper/css/bootstrap.min.css" rel="stylesheet">
    <link href="Cropper/css/cropper.css" rel="stylesheet">
    <link href="Cropper/css/docs.css" rel="stylesheet">
    <link href="../Css/Inscription.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>-->

    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>

    <script type="text/javascript">
        function copieImgData() {
            //mm.src = "photo1.jpg";
            document.getElementById("<%=ImgExSrc.ClientID%>").value = lviewFormulaireInscription_showDataURL_0.src;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".has-error").removeClass("has-error");

            var idValue = '<%=this.lviewFormulaireInscription.ClientID%>';
                var IDS = JSON.parse('<%= this.idsEnErreurTab%>');
                var MSGS = '<%= this.msgsEnErreur%>';

                for (index = 0; index < IDS.length; ++index) {
                    var id = IDS[index];
                    var msg = MSGS[index];
                    if (id != "DateNaissance") {
                        var element = idValue + "_txt" + id + "_0";

                        $("#" + element).addClass("has-error");

                    } else {
                        $("#" + idValue + "_DateNaissanceJour").addClass("has-error");
                        $("#" + idValue + "_DateNaissanceMois").addClass("has-error");
                        $("#" + idValue + "_DateNaissanceAnnee").addClass("has-error");
                    }
                }

            });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="ImgExSrc" />
        <div class="container">
            <asp:ScriptManager ID="scriptManager" runat="server" />
            <div class="row row-centered">
                <div class="col-lg-5 col-centered">
                    <h1>Inscription</h1>
                </div>
            </div>
            <asp:ListView ID="lviewFormulaireInscription" runat="server"
                ItemType="Site_de_la_Technique_Informatique.Model.Etudiant"
                SelectMethod="GetUtilisateurEtudiant"
                UpdateMethod="CreerUtilisateurEtudiant">
                <ItemTemplate>
                    <div class="row row-centered">
                        <div class="col-lg-5 col-centered">
                            <div class="control-group form-group champs-requis">
                                Tous les champs sont requis.
                            </div>
                            <div class="control-group form-group">
                                <div class="controls">
                                    <!-- Modal Profil picture-->
                                    <asp:UpdatePanel ID="upPhotoProfil" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="modif-photo">
                                                <div class="img-thumbnail img-photo preview-photo">
                                                    <div></div>
                                                    <asp:Image ID="showDataURL" runat="server" ImageUrl="../Photos/photobase.jpg" Width="125" Height="125" />
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
                                                            <div class="container-fluid eg-container" id="basic-example">
                                                                <div class="row eg-main blue">
                                                                    <div class="col-xs-12 col-sm-9 red">
                                                                        <div class="eg-wrapper">

                                                                            <img class="cropper" alt="Télécharger une photo.">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-xs-12 col-sm-3">
                                                                        <asp:Label ID="lblPostBack" runat="server" Text="" />

                                                                    </div>
                                                                </div>
                                                                <div class="clearfix">
                                                                    <div class="eg-button">
                                                                        <button class="btn btn-warning" id="reset" type="button">Restaurer</button>

                                                                        <button class="btn btn-info" id="zoomIn" type="button">Zoom In</button>
                                                                        <button class="btn btn-info" id="zoomOut" type="button">Zoom Out</button>
                                                                        <label class="btn btn-primary" for="inputImage" title="Télécharger">
                                                                            <input class="hide" id="inputImage" name="file" type="file" accept="image/*">
                                                                            Télécharger
       
                                                                        </label>
                                                                    </div>
                                                                    <div class="row eg-input">
                                                                        <div class="col-md-6">
                                                                        </div>

                                                                    </div>

                                                                </div>
                                                            </div>

                                                            <script src="Cropper/js/jquery.min.js"></script>
                                                            <script src="Cropper/js/bootstrap.min.js"></script>
                                                            <script src="Cropper/js/cropper.js"></script>
                                                            <script src="Cropper/js/docs.js"></script>

                                                        </div>

                                                        <div class="modal-footer">
                                                            <div class="row eg-output">
                                                                <div class="col-md-12">
                                                                    <button class="btn btn-primary" id="getDataURL3" type="button" data-dismiss="modal">Fermer</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>

                                        </ContentTemplate>
                                        <Triggers>
                                        </Triggers>
                                    </asp:UpdatePanel>
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
                                    <asp:TextBox ID="txtCourriel" runat="server" CssClass="form-control" placeholder="courriel@exemple.qc.ca" Text='<%#BindItem.courriel %>' Font-Names="email" />
                                    <asp:Label ID="lblCourriel" runat="server" Text="" />
                                </div>
                            </div>
                            <div class="control-group form-group">
                                <div class="controls">
                                    <label>Mot de passe:</label>
                                    <asp:TextBox ID="txtMotDePasse" runat="server" TextMode="password" CssClass="form-control" Text='<%#BindItem.hashMotDePasse %>' />
                                    <asp:Label ID="lblMotDePasse" runat="server" Text="" />
                                </div>
                            </div>
                            <div class="control-group form-group">
                                <div class="controls">
                                    <label>Confirmation du mot de passe:</label>
                                    <asp:TextBox ID="txtConfirmationMotDePasse" runat="server" TextMode="password" CssClass="form-control" />

                                </div>

                            </div>
                            <asp:UpdatePanel ID="upCondition" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                <ContentTemplate>

                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <asp:CheckBox ID="cbCondition" runat="server" OnCheckedChanged="cbCondition_CheckedChanged" AutoPostBack="true" />
                                            <asp:LinkButton ID="lnkConditions" runat="server" Text="Termes et conditions" data-toggle="modal" data-target="#mesConditions" />
                                        </div>

                                    </div>
                                    <asp:LinkButton ID="lnkAnnuler" Text="Annuler" runat="server" CssClass="btn btn-default" />
                                    <asp:LinkButton ID="lnkEnvoyer" Text="Envoyer" runat="server" CssClass="btn btn-default" CommandName="Update" Enabled="false" ValidationGroup="g1" OnClientClick="copieImgData()" />

                                    <!-- Modal Termes et conditions-->
                                    <div class="modal fade" id="mesConditions" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title" id="myModalLabel">Termes et conditions</h4>
                                                </div>
                                                <div class="modal-body">
                                                    bla bla bla...
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Fermer</button>
                                                    <asp:LinkButton ID="lnkAcccepter" runat="server" CssClass="btn btn-primary" Text="Accepter" OnClick="lnkAcccepter_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!--Fin Termes et condition-->


                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cbCondition" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>

        </div>
    </form>
</body>
</html>