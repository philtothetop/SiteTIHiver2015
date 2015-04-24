<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifierProfesseur.aspx.cs" Inherits="Site_de_la_Technique_Informatique.ModifierProfesseur" %>

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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <link href="Cropper/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Cropper/css/cropper.css" rel="stylesheet" />
    <link href="Cropper/css/docs.css" rel="stylesheet" />

    <link rel="stylesheet" href="../Css/Inscription.css" />

    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
    <script type="text/javascript">
        function copieImgData() {
            document.getElementById("<%=ImgExSrc.ClientID%>").value = ContentPlaceHolder1_lvProfesseur_showDataURL_0.src;
        }
    </script>
    <script type="text/javascript">
        window.transfertDataImg = function (dataURL) {
            $("#ContentPlaceHolder1_lvProfesseur_showDataURL_0").attr("src", dataURL);
        };
    </script>
    <script type="text/javascript">
        window.closeModal = function () {
            $('#maPhotoProfile').modal('hide');
        };
        function closeDivs(value) {

            document.getElementById('<%= hidTab.ClientID%>').value = value;
            document.getElementById("ContentPlaceHolder1_divSuccess").style.visibility = "hidden";
            document.getElementById("ContentPlaceHolder1_divWarning").style.visibility = "hidden";

        };
        function keepTab() {
            document.getElementById("aDelete").click();
        };

        $(document).ready(function () {

            var tab = document.getElementById('<%= hidTab.ClientID%>').value;
            $('#myTab a[href="#' + tab + '"]').tab('show');
        });

    </script>
    <!-- jQuery -->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:HiddenField runat="server" ID="ImgExSrc" />
    <asp:HiddenField runat="server" ID="hidTab" Value="informations" />
    <asp:ScriptManagerProxy ID="smProxy" runat="server" />

    <div class="container">
        <ul class="nav nav-tabs" id="myTab">
            <li role="presentation" class="active"><a href="#informations" id="aInfos" aria-controls="informations" role="tab" data-toggle="tab" onclick="closeDivs('informations')">Informations générales</a></li>
            <li role="presentation"><a href="#cours" id="aCours" aria-controls="cours" role="tab" data-toggle="tab" onclick="closeDivs('cours') ">Mes Cours</a></li>
            <li role="presentation"><a href="#delete" id="aDelete" aria-controls="cours" role="tab" data-toggle="tab" onclick="closeDivs('delete'); ">Supprimer mon profil</a></li>
        </ul>

        <div class="row row-centered">
            <h2>Modifier mon profil</h2>
        </div>

        <div class="tab-content">

            <div class="row">
                <div class="col-md-3 col-md-offset-8" style="position: absolute">
                    <div class="alert alert-success" runat="server" id="divSuccess">
                        <p>Les modifications ont été effectuées.</p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 col-md-offset-8" style="position: absolute;">
                    <div class="alert alert-warning" runat="server" id="divWarning">
                        <p>Veuillez porter attention à ces champs:</p>
                        <br />
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div role="tabpanel" class="tab-pane fade in active" id="informations">
                <div class="row row-centered">
                    <h3>Informations générales</h3>
                    <asp:ListView ID="lvProfesseur" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.Professeur"
                        SelectMethod="lvProfesseur_GetData"
                        UpdateMethod="updateProfesseur">

                        <LayoutTemplate>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />

                        </LayoutTemplate>

                        <EmptyDataTemplate>
                            QUI ES-TU, QUE VIENS-TU FAIRE ICI?
                        </EmptyDataTemplate>

                        <ItemTemplate>
                            <div class="row row-centered">
                                <div class="col-md-5 col-centered">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <label>Courriel:</label>
                                            <asp:TextBox runat="server" ID="txtCourriel" CssClass="form-control" Text='<%#BindItem.courriel %>'></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row row-centered">
                                <div class="col-md-5 col-centered">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <label>Texte de présentation:</label>
                                            <asp:TextBox runat="server" ID="txtPresentation" TextMode="MultiLine" CssClass="form-control" Text='<%#BindItem.presentation %>' MaxLength="2000"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="modif-photo">
                                <div class="row row-centered">
                                    <div class="col-md-5 col-centered">
                                        <div class="img-thumbnail img-photo preview-photo">

                                            <asp:Image ID="showDataURL" runat="server" ImageUrl='<%#Eval ("pathPhotoProfil", "~/Photos/Profils/{0}") %>' Width="125" Height="125" />
                                        </div>
                                        <div class="div-btnChangerPhoto">
                                            <asp:LinkButton ID="lnkProfilePhoto" runat="server" Text="Changer la photo du profil" CssClass="btn btn-primary btnChangerPhoto" data-toggle="modal" data-target="#maPhotoProfile" />

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



                                    </div>
                                </div>
                            </div>

                            <div class="row row-centered">
                                <div class="col-md-5 col-centered">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <label>Description de la photo:</label>
                                            <asp:TextBox runat="server" ID="txtDescPhoto" TextMode="MultiLine" CssClass="form-control" Text='<%#BindItem.photoDescription  %>' MaxLength="500"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row row-centered" style="margin-bottom: 20px;">
                                <div class="col-md-1 col-md-push-2 col-centered">
                                    <asp:LinkButton ID="lnkSauvegarderModifs" Text="Sauvegarder" runat="server" CssClass="btn btn-default" Style="float: right;" CommandName="Update" OnClientClick="copieImgData()" />
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:ListView>

                    <div class="row row-centered">
                        <h4>Changer mon mot de passe</h4>
                    </div>
                    <div class="row row-centered">
                        <div class="col-md-5 col-centered">
                            <div class="control-group form-group">
                                <div class="controls">
                                    <label>Ancien mot de passe:</label>
                                    <asp:TextBox runat="server" ID="txtAncienMp" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row row-centered">
                        <div class="col-md-5 col-centered">
                            <div class="control-group form-group">
                                <div class="controls">
                                    <label>Nouveau mot de passe:</label>
                                    <asp:TextBox runat="server" ID="txtNouveauMp" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row row-centered">
                        <div class="col-md-5 col-centered">
                            <div class="control-group form-group">
                                <div class="controls">
                                    <label>Confirmer le nouveau mot de passe:</label>
                                    <asp:TextBox runat="server" ID="txtNouveauMpConfirm" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row row-centered" style="margin-bottom: 20px;">
                        <div class="col-md-1 col-md-push-2 col-centered">
                            <asp:LinkButton ID="lnkSaveNewPassword" runat="server" CssClass="btn btn-default" Style="float: right;" Text="Sauvegarder" OnClick="lnkSaveNewPassword_Click"></asp:LinkButton>
                        </div>
                    </div>
                </div>

            </div>
            <div role="tabpanel" class="tab-pane fade" id="cours">
                <div class="row row-centered">
                    <div class="col-md-10 col-centered">
                        <div class="row row-centered">

                            <h3>Mes Cours</h3>
                            <div>
                                <div class="row row-centered">

                                    <div class="col-md-3 col-centered">
                                        <div class="control-group form-group">
                                            <div class="controls">
                                                <label>Session</label>
                                                <asp:DropDownList ID="ddlSession" CssClass="form-control" runat="server"
                                                    OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Text="Session 1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Session 2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Session 3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Session 4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="Session 5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="Session 6" Value="6"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 col-centered">
                                        <div class="control-group form-group">
                                            <div class="controls">
                                                <label>Cours</label>
                                                <asp:DropDownList ID="ddlCours" CssClass="form-control" runat="server" SelectMethod="getAllCours" DataTextField="nomCours" DataValueField="IDCours"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-1 col-centered">
                                        <asp:Button ID="btnModif" runat="server" Text="Modifier" CssClass="btn btn-primary" OnClick="btnModif_Click" />
                                    </div>
                                    <div class="col-md-1 col-centered">
                                        <asp:Button ID="btnAjout" runat="server" Text="Ajouter" CssClass="btn btn-primary" OnClick="btnAjout_Click" />
                                    </div>
                                </div>
                                <div class="row row-centered">
                                    <asp:Label ID="lblNoClass" runat="server" Text="Vous n'avez pas de cours lors de cette session" Visible="false" />
                                </div>
                            </div>
                        </div>
                        <hr />
                        <asp:ListView ID="lvModifierCours" runat="server"
                            SelectMethod="lvModifierCours_GetData"
                            ItemType="Site_de_la_Technique_Informatique.Model.Cours"
                            Visible="false"
                            UpdateMethod="updateCours"
                            DeleteMethod="deleteCours"
                            OnItemDataBound="lvModifierCours_ItemDataBound">

                            <EmptyDataTemplate>
                                <p>Vous n'avez aucun cours assignés!</p>
                            </EmptyDataTemplate>
                            <LayoutTemplate>
                                <div class="row">
                                    <div class="col-lg-9"></div>
                                    <div class="col-lg-3">
                                        <asp:DataPager ID="datapagerCours" runat="server"
                                            PagedControlID="lvModifierCours" PageSize="1">
                                        </asp:DataPager>
                                    </div>
                                </div>

                                <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>

                                <div class="row-centered">

                                    <asp:LinkButton ID="lnkSaveCours" runat="server" Text="Sauvegarder" Style="float: right" CssClass="btn btn-default" />

                                </div>
                            </LayoutTemplate>


                            <ItemTemplate>
                                <div class="row row-centered">

                                    <div class="col-md-2 col-centered form-group form">

                                        <label>No. de cours</label>
                                        <asp:TextBox ID="txtNoCours" runat="server" CssClass="form-control" Text='<%#BindItem.noCours %>' />

                                    </div>
                                    <div class="col-md-4 col-centered form-group form">
                                        <label>Nom du cours</label>
                                        <asp:TextBox ID="txtNomCours" CssClass="form-control" runat="server" Text='<%#BindItem.nomCours %>' />
                                    </div>

                                </div>


                            </ItemTemplate>

                        </asp:ListView>
                    </div>
                </div>


            </div>
            <div role="tabpanel" class="tab-pane fade" id="delete">
                <div class="row-centered">
                    <div class="col-md-8 col-centered" style="text-align: center">
                        <h3>déjà tanné d'être ici? :'(</h3>
                        <p>Si vous désactivez votre profil, vous ne pourrez plus vous connecter. Êtes-vous certain de vouloir désactiver votre compte?</p>
                    </div>
                </div>
                <div class="row-centered" style="margin-top: 25px;">
                    <div class="col-md-1 col-md-push-5">
                        <asp:LinkButton ID="lnkDeleteProfil" runat="server" Text="Désactiver mon profil" CssClass="btn btn-danger" OnClick="lnkDeleteProfil_Click" />
                    </div>
                </div>
            </div>
        </div>






    </div>

    <div class="modal fade" id="popupDelete" role="dialog" aria-labelledby="popupDelete" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upDelete" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">


                            <div class="container-fluid">
                                <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                                <div class="row" style="margin-top: 5px;">
                                    <div class="col-md-6 ">
                                        <div class="control-group form-group">
                                            <div class="controls">
                                                <label>Mot de passe:</label>
                                                <asp:TextBox runat="server" ID="txtDeletePass" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-push-8 col-md-1">
                                        <asp:LinkButton ID="lnkDeletePass" runat="server" Text="Désactiver mon Compte" CssClass="btn btn-danger" OnClick="lnkDeletePass_Click"></asp:LinkButton>
                                    </div>
                                </div>


                            </div>
                        </div>



                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Annuler</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>


</asp:Content>
