<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Admin_LesPhotos.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_LesPhotos" MaintainScrollPositionOnPostback="true" %>




<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Css/Inscription.css" /> 
    <script src="Js/bootstrap.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta content="IE=edge" http-equiv="X-UA-Compatible">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="A basic example of Cropper.">
    <meta name="keywords" content="HTML, CSS, JS, JavaScript, jQuery, image cropping, web development">
    <meta name="author" content="Fengyuan Chen">
    <title>Cropper</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>-->
    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
    <script type="text/javascript">
        function copieImgData() {
            document.getElementById("<%=ImgExSrc.ClientID%>").value = ContentPlaceHolder1_ContentPlaceHolder1_lviewPhoto_showDataURL_0.src;
        }
    </script>
    <script type="text/javascript">
        window.transfertDataImg = function (dataURL) {

            $("#ContentPlaceHolder1_ContentPlaceHolder1_lviewPhoto_showDataURL_0").attr("src", dataURL);

            var maxSize = 500;
            var minSize = 120;

            var img = new Image();
            img.src = dataURL// e.target.result;

            var width = img.width;
            var height = img.height;

            if (width == height) {
                width = maxSize;
                height = maxSize;
            }
            else if (width > height) {
                height = (maxSize / width) * height;
                width = maxSize;
            }
            else if (height > width) {
                width = (maxSize / height) * width;
                height = maxSize;
            }

            var valeurAUtiliser = img.height;

            //Si image plus grand que max size
            if (img.height > maxSize && img.width > maxSize) {
                if (valeurAUtiliser < img.width) {
                    valeurAUtiliser = img.width;
                }
            }
            else if (img.height > maxSize) {
                valeurAUtiliser = img.height;
            }
            else if (img.width > maxSize) {
                valeurAUtiliser = img.width;
            }
            else {
                valeurAUtiliser = maxSize;
            }

            var valeurDivision = maxSize / valeurAUtiliser;
            width = img.width * valeurDivision;
            height = img.height * valeurDivision;

            //Si plus petit que min grosseur maintenant
            if (width < minSize) {
                width = minSize;
            }

            //Si plus petit que min hauteur maintenant
            if (height < minSize) {
                height = minSize;
            }

            //Pour redimentionner le preview image
            $("#ContentPlaceHolder1_ContentPlaceHolder1_lviewPhoto_showDataURL_0").attr("width", width);
            $("#ContentPlaceHolder1_ContentPlaceHolder1_lviewPhoto_showDataURL_0").attr("height", height);




        };
    </script>
    <script type="text/javascript">
        window.closeModal = function () {
            $('#maPhotoProfile').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
        };
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:HiddenField runat="server" ID="ImgExSrc" />
    <asp:ScriptManagerProxy ID="smProxy" runat="server" />
<script src="JS/bootstrap.js"></script>

<h1 class="page-header">Photos</h1>
    
    <asp:MultiView ID="mviewLesPhotos" runat="server" ActiveViewIndex="0">

        <asp:View ID="viewMenu" runat="server">
            <asp:Button ID="btnAccueilVoirLesPhotos" runat="server" Text="Voir/Modifier les photos" OnClick="btnVoirLesPhotos_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnAjouterUnePhoto" runat="server" Text="Ajouter une photo" OnClick="btnAjouterUnePhoto_Click" CssClass="btn btn-primary" />
            <br />

        </asp:View>

        <asp:View ID="viewAjouterPhoto" runat="server">

            <div style="text-align:left">
            <asp:Button ID="btnAllezVoirLesPhotos" runat="server" Text="Voir les photos" OnClick="btnVoirLesPhotos_Click" CssClass="btn btn-primary" />
            </div>

            <div id="divReussiAjouterImage" runat="server" visible="false" style="text-align:center; width:100%;">

                

        <asp:Label ID="lblReussi" runat="server" Text="L'image a bien été ajouté."></asp:Label>
        <br />
        <asp:Button ID="btnAjouterAutreImage" runat="server" Text="Ajouter une autre photo" OnClick="btnajouterAutreImage_Click" CssClass="btn btn-primary"/>
    </div>

    <div id="divPasReussiAjouterImage" runat="server" visible="false" style="text-align:center; width:100%; color:red;">
        <asp:Label ID="lblPasReussi" runat="server" Text=""></asp:Label>
        <br />
        <br />
    </div>

            <div id="divPourAjouterUnePhoto" runat="server" style="text-align:center; width:100%;">

                Type d'image : <asp:DropDownList ID="ddlTypeDImage" runat="server">
        </asp:DropDownList>
        <br />
        <br />

     <asp:ListView ID="lviewPhoto" runat="server"
            ItemType="Site_de_la_Technique_Informatique.Model.Photos"
            SelectMethod="GetUnePhoto">

         <LayoutTemplate>
             <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
         </LayoutTemplate>

            <ItemTemplate>
                <div>
                <div>
                    Prévisualisation
                    <div id="divDeLImage" style="clear:both; max-height:500px; margin:0px; padding:0px;">
                        <asp:Image ID="showDataURL" runat="server" ImageUrl="../Photos/Profils/photobase.bmp" style="min-width:120px;min-height:120px; max-width:500px; max-height:500px" />
                    </div>

                    <div style="clear:both;">
                        <br />
                        <asp:LinkButton ID="lnkProfilePhoto" runat="server" Text="Choisir une image" CssClass="btn btn-primary" data-toggle="modal" data-target="#maPhotoProfile" />
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
                                <iframe src='<%=".." + Request.ApplicationPath +"/Jquery/Cropper2/Cropper2.aspx"%>' width="570" height="625" scrolling="no" frameborder="0"></iframe>
                            </div>
                        </div>

                    </div>
                </div>

                    
        <div style="text-align:left; width:100%;">
            <asp:Label ID="lblDescription" runat="server" Text="Decription de la photo:" style="margin-left:15%;"></asp:Label>
            <br />
            <div style="text-align:center; width:100%;">
                <asp:TextBox ID="txtbDescriptionPhotoAAjouter" runat="server" TextMode="MultiLine" style="max-width:70%; min-width:70%; text-align:left; min-height:100px; max-height:500px;"></asp:TextBox>
           </div>

        </div>
                <div style="clear:both; float:none; padding:0px; margin:0px;">
                <asp:Button ID="btnSauvegarderImage" Text="Sauvegarder" runat="server" OnClientClick="copieImgData()" OnClick="btnUpdate_Click" CssClass="btn btn-primary" />
            </div>
                    </div>
            </ItemTemplate>

        </asp:ListView>
            </div>
            
        </asp:View>

        <asp:View ID="viewModifierPhoto" runat="server">
            
            <div style="text-align:left">
            <asp:Button ID="btnModifierRetourAuPhoto" runat="server" Text="Retour aux photos" OnClick="btnVoirLesPhotos_Click" CssClass="btn btn-primary" />
            </div>


            <div id="divModifierPhotoReussi" runat="server" visible="false" style="text-align:center; width:100%;">
        <asp:Label ID="lblModifierPhotoReussi" runat="server" Text="L'image a bien été modifié."></asp:Label>
    </div>

    <div id="divModifierPhotoPasReussi" runat="server" visible="false" style="text-align:center; width:100%; color:red;">
        <asp:Label ID="lblModifierPhotoPasReussi" runat="server" Text=""></asp:Label>
        <br />
        <br />
    </div>

    <div id="divModifierPhotoGlobal" runat="server">

    <div id="divModifierPhoto" runat="server" style="text-align:center; width:100%;">
    Type d'image : <asp:DropDownList ID="ddlModifierPhoto" runat="server">
        </asp:DropDownList>
        <br />
        <br />
                Photo
                        <div id="dvPreview2" style="text-align:center; width:100%;">
                            <asp:Image ID="imgModifierPhoto" runat="server" style="max-height:500px;max-width:500px;" />
                        </div>
        <br />
        <br />
        <div style="text-align:left; width:100%;">
            <asp:Label ID="lblModifierDescription" runat="server" Text="Decription de la photo:" style="margin-left:15%;"></asp:Label>
            <br />
            <div style="text-align:center; width:100%;">
                <asp:TextBox ID="txtbModifierPhotoDescription" runat="server" TextMode="MultiLine" style="max-width:70%; min-width:70%; text-align:left; min-height:100px; max-height:500px;"></asp:TextBox>
           </div>

        </div>
        <br />
        <asp:Button ID="btnUpdaterModifierPhoto" runat="server" CssClass="btn btn-primary"  Text="Modifier cette photo" OnClick="btnUpdaterModifierPhoto_Click" />
            <br />
        
         </div>

        </div>
            <asp:HiddenField ID="hfieldIDItemAModifier" runat="server" Value="" />
        </asp:View>

        <asp:View ID="viewSupprimerPhoto" runat="server">
            <div id="divSupprimerPhotos" runat="server" style="text-align:center; width:100%; clear:both;">
                            <div style="text-align:left">
                <asp:Button ID="btnAllezAjouterUnePhoto" runat="server" Text="Ajouter une photo" OnClick="btnAjouterUnePhoto_Click" CssClass="btn btn-primary" />
</div>
            Type d'image : <asp:DropDownList ID="ddlTypePhotoSupprimer" runat="server" OnSelectedIndexChanged="ddlTypePhotoSupprimer_IndexChange" AutoPostBack="true">
        </asp:DropDownList>

                <br />
                <br />
            <asp:ListView ID="lviewSupprimerPhotos" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.Photos"
                        SelectMethod="GetLesPhotos"
                        GroupItemCount="2"
                        OnItemDataBound="lviewSupprimerPhotosDataBound">

                        <LayoutTemplate>
                            <div style="clear:both;">
                                <asp:PlaceHolder runat="server" ID="groupPlaceholder" />
                            </div>
                        </LayoutTemplate>

                <GroupTemplate>
                    <div style="width:100%; clear:both;">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </div>
                </GroupTemplate>

                        <ItemTemplate>
                            <div style="width:50%; float:left;">
                                <div style="width:97%;padding-left:3%;">
                                <asp:Image ID="imgLaPhoto" runat="server" ImageUrl='<%# "~/Upload/Photos/Souvenir/" + Item.typePhoto + "/" + Item.pathPhoto %>' style="max-width:100%; max-height:100%;" />
                             </div>
                                <div style="width:97%;padding-left:3%; clear:both;">
                                    <asp:TextBox ID="txtbDescriptionVoir" runat="server" TextMode="MultiLine" Text='<%# Item.descriptionPhoto %>' style="width:100%; max-width:100%; min-height:100px;" Enabled="false"></asp:TextBox>
                             </div>
                                <div style="clear:both">

                                    <div style="float:left; text-align:left; width:50%; padding-left:15px;">
                                        <asp:Button ID="btnModifierLaPhoto" runat="server" Text="Modifier" CommandArgument='<%# Item.IDPhotos %>' OnClick="btnModifierLaPhoto_Click" CssClass="btn btn-primary" />
                                    </div>

                                    <div style="float:right;text-align:right; width:50%; padding-right:15px;">
                                         <asp:Button ID="btnSupprimerLaPhoto" runat="server" Text="Supprimer" CommandArgument='<%# Item.IDPhotos %>' OnClick="btnSupprimerLaPhoto_Click" CssClass="btn btn-danger" />
                                    </div>

                                </div>
                               
                            </div>
                        </ItemTemplate>

            <EmptyDataTemplate>
                <div style="width:100%;">
                    <asp:Label ID="lblPasDePhoto" runat="server" Text="Aucune photo de ce type trouvé."></asp:Label>
                </div>
                </EmptyDataTemplate>
            
        </asp:ListView>

                </div>
            <div style="clear:both;">
                <div style="text-align:center; width:100%;">
            
            <asp:DataPager ID="dataPagerPhotosSouvenirs" runat="server" PagedControlID="lviewSupprimerPhotos"
                            PageSize="10">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" PreviousPageText="<<" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowLastPageButton="False" ShowPreviousPageButton="False" NextPageText=">>" />
                            </Fields>
                        </asp:DataPager>
                </div>
            </div>
        </asp:View>

    </asp:MultiView>


    <asp:HiddenField ID="hfPathPhotoProfil" runat="server" />
</asp:Content>