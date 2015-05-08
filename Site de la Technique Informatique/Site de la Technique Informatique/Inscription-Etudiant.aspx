<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription-Etudiant.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.Inscription" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Css/Inscription.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta content="IE=edge" http-equiv="X-UA-Compatible" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="A basic example of Cropper." />
    <meta name="keywords" content="HTML, CSS, JS, JavaScript, jQuery, image cropping, web development" />
    <meta name="author" content="Fengyuan Chen" />
    <title>Cropper</title>
    <link href="Cropper/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Cropper/css/cropper.css" rel="stylesheet" />
    <link href="Cropper/css/docs.css" rel="stylesheet" />
    <link href="../Css/Inscription.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>-->
    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        function openModal() {
            $('#maPhotoProfile').modal('show');
        }
    </script>
    <script type="text/javascript">
        window.closeModal = function () {
            $('#maPhotoProfile').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
        };
    </script>
    <!--Afficher les erreurs de input-->
    <script type="text/javascript">
        $(document).ready(function () {
            $(".has-error").removeClass("has-error");
            $(".has-feedback").removeClass("has-feedback");
            var idValue = '<%=this.lviewFormulaireInscription.ClientID%>';
            var IDS = JSON.parse('<%= this.idsEnErreurTab%>');
            var MSGS = '<%= this.msgsEnErreur%>';

            for (index = 0; index < IDS.length; ++index) {
                var id = IDS[index];
                var msg = MSGS[index];

                var element = "dv" + id;

                $("#" + element).addClass("has-error");
                $("#" + element).addClass("has-feedback");
                if (id == "MotDePasse") {
                    element = "dvConfirmationMotDePasse";
                    $("#" + element).addClass("has-error");
                    $("#" + element).addClass("has-feedback");
                }

            }

        });
    </script>
    <script type="text/javascript">
        function copieImgData() {
            document.getElementById("<%=ImgExSrc.ClientID%>").value = ContentPlaceHolder1_lviewFormulaireInscription_showDataURL_0.src;
        }
    </script>
    <script type="text/javascript">
        window.transfertDataImg = function (dataURL) {
            $("#ContentPlaceHolder1_lviewFormulaireInscription_showDataURL_0").attr("src", dataURL);
        };
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="ImgExSrc" />
    <asp:ScriptManagerProxy ID="smProxy" runat="server" />
    <div class="container">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#">Étudiant</a></li>
            <li><a href="Inscription-Employeur.aspx">Employeur</a></li>
        </ul>
        <div class="row row-centered">
            <div class="col-lg-5 col-centered">
                <h1>Inscription Étudiant</h1>
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
                            <p>Tous les champs sont requis.</p>
                            <asp:Label ID="lblMessage" runat="server" Text="" />
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <!-- Modal Profil picture-->
                                <div class="modif-photo">
                                    <div class="img-thumbnail img-photo preview-photo">
                                        <div></div>
                                        <asp:Image ID="showDataURL" runat="server" ImageUrl="../Photos/Profils/photobase.bmp" Width="125" Height="125" />
                                    </div>
                                    <div class="div-btnChangerPhoto">
                                        <a href="#maPhotoProfile" class="btn btn-primary btnChangerPhoto" data-toggle="modal" data-target="#maPhotoProfile" data-backdrop="static" data-keyboard="false">Changer la photo du profil</a>

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
                        <div class="control-group form-group" id="dvPrenom">
                            <div class="controls">
                                <label>Prénom:</label>
                                <asp:TextBox ID="txtPrenom" runat="server" CssClass="form-control" placeholder="Prénom" Text='<%#BindItem.prenom %>' name="fname" MaxLength="32" />
                                <asp:Label ID="lblPrenom" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group" id="dvNom">
                            <div class="controls">
                                <label>Nom:</label>
                                <asp:TextBox ID="txtNom" runat="server" CssClass="form-control" placeholder="Nom" Text='<%#BindItem.nom %>' name="lname" MaxLength="32" />
                                <asp:Label ID="lblNom" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group" id="dvDateNaissance">
                            <div class="controls">
                                <label>Date de naissance:</label>
                                <div class="row">
                                    <div class="col-xs-3">
                                        <asp:TextBox ID="txtDateNaissanceJour" runat="server" CssClass="form-control inputJourMois" placeholder="JJ" MaxLength="2" />
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox ID="txtDateNaissanceMois" runat="server" CssClass="form-control inputJourMois" placeholder="mm" MaxLength="2" />
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox ID="txtDateNaissanceAnnee" runat="server" CssClass="form-control" placeholder="AAAA" MaxLength="4" />
                                    </div>
                                    <asp:Label ID="lblDateNaissance" runat="server" Text="" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group form-group" id="dvCourriel">
                            <div class="controls">
                                <label>Courriel:</label>
                                <asp:TextBox ID="txtCourriel" runat="server" CssClass="form-control" placeholder="courriel@exemple.qc.ca" Text='<%#BindItem.courriel %>' Font-Names="email" />
                                <asp:Label ID="lblCourriel" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group" id="dvMotDePasse">
                            <div class="controls">
                                <label>Mot de passe:</label>
                                <asp:TextBox ID="txtMotDePasse" runat="server" TextMode="password" CssClass="form-control" Text='<%#BindItem.hashMotDePasse %>' />
                                <asp:Label ID="lblMotDePasse" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group" id="dvConfirmationMotDePasse">
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
                                        <a href="TermesConditions.aspx" target="_blank">Termes et conditions</a>
                                        <%--<asp:LinkButton ID="lnkConditions" runat="server" Text="Termes et conditions" data-toggle="modal" data-target="#mesConditions" />--%>
                                    </div>

                                </div>

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
                                                <button type="button" class="btn btn-default" data-dismiss="modal" >Fermer</button>
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
</asp:Content>
