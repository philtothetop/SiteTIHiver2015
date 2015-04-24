<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Admin_LesPhotos.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_LesPhotos" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="JS/bootstrap.js"></script>

 <h1>Administrateur : Les Photos</h1>
    
    <asp:MultiView ID="mviewLesPhotos" runat="server" ActiveViewIndex="0">

        <asp:View ID="viewMenu" runat="server">

            <asp:Button ID="btnAjouterUnePhoto" runat="server" Text="Ajouter une photo" OnClick="btnAjouterUnePhoto_Click" />
            <br />
            <asp:Button ID="btnAccueilVoirLesPhotos" runat="server" Text="Voir les photos" OnClick="btnVoirLesPhotos_Click" />
            <br />

        </asp:View>

        <asp:View ID="viewAjouterPhoto" runat="server">
            <div id="divReussiAjouterImage" runat="server" visible="false" style="text-align:center; width:100%;">
        <asp:Label ID="lblReussi" runat="server" Text="L'image a bien été ajouté."></asp:Label>
        <br />
        <asp:Button ID="btnAjouterAutreImage" runat="server" Text="Ajouter une autre photo" OnClick="btnajouterAutreImage_Click"/>
                <asp:Button ID="btnVoirLesPhotos" runat="server" Text="Voir les photos" OnClick="btnVoirLesPhotos_Click"/>
    </div>

    <div id="divPasReussiAjouterImage" runat="server" visible="false" style="text-align:center; width:100%; color:red;">
        <asp:Label ID="lblPasReussi" runat="server" Text=""></asp:Label>
        <br />
        <br />
    </div>

    <div id="divPourAjouterUnePhoto" runat="server">

    <div id="divPourUpdatePhoto" runat="server" style="text-align:center; width:100%;">
    Type d'image : <asp:DropDownList ID="ddlTypeDImage" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Prévisualisation
                        <div id="dvPreview" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=image); text-align:center; width:100%;">
                            <img src="../Photos/Profils/photobase.bmp" width="120" height="120"/>
                        </div>

                    <asp:TextBox ID="txtbPhoto" Enabled="false" Visible="false" placeholder="Fichier de type .jpg ou .png" runat="server" Style="width: 200px" Text='' />
                    <asp:FileUpload ID="fuplPhoto" runat="server" Width="0px" ClientIDMode="Static" AllowMultiple="false" />
                    <button onclick="$('[id$=fuplPhoto]').click(); return false;"
                        class="btn btn-default">
                        Choisir une photo</button>
        <br />
        <br />
        <asp:Label ID="lblImageTailleInitial" runat="server" Text="Taille Initial : 0x0"></asp:Label>
        <br />
        <asp:Label ID="lblImageTailleFinal" runat="server" Text="Taille Final : 0x0"></asp:Label>
        <br />
        <br />
        <div style="text-align:left; width:100%;">
            <asp:Label ID="lblDescription" runat="server" Text="Decription de la photo :" style="margin-left:15%;"></asp:Label>
            <br />
            <div style="text-align:center; width:100%;">
                <asp:TextBox ID="txtbDescriptionPhotoAAjouter" runat="server" TextMode="MultiLine" style="max-width:70%; min-width:70%; text-align:left; min-height:100px; max-height:500px;"></asp:TextBox>
           </div>

        </div>
        <br />
        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-default"  Text="Uploader cette photo" OnClick="btnUpdate_Click" />
            <br />
        
         </div>

        </div>

            <br />
            <asp:Button ID="btnAllezVoirLesPhotos" runat="server" Text="Voir les photos" OnClick="btnVoirLesPhotos_Click" />
            <br />
            
        </asp:View>
























        <asp:View ID="viewModifierPhoto" runat="server">
            <div id="divModifierPhotoReussi" runat="server" visible="false" style="text-align:center; width:100%;">
        <asp:Label ID="lblModifierPhotoReussi" runat="server" Text="L'image a bien été ajouté."></asp:Label>
        <br />
                <asp:Button ID="btnModifierRetourAuPhotos" runat="server" Text="Revenir aux photos" OnClick="btnVoirLesPhotos_Click"/>
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








        <div id="divPourAjouterUnePhotoModal" runat="server">
     <asp:ListView ID="lviewPhoto" runat="server"
            ItemType="Site_de_la_Technique_Informatique.Model.Photos"
            SelectMethod="GetUnePhoto">

         <LayoutTemplate>
             <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
         </LayoutTemplate>

            <ItemTemplate>
                <div class="modif-photo">
                    <div id="divDeLImage" runat="server" class="preview-photo" style="min-height:500px; clear:both;">
                        
                        <asp:Image ID="showDataURL" runat="server" ImageUrl="../Photos/Profils/photobase.bmp" style="width:500px;height:500px;max-width:500px;max-height:500px;" />
                    </div>

                    <div class="div-btnChangerPhoto" style="clear:both; min-height:100px;">
                        <asp:LinkButton ID="lnkProfilePhoto" runat="server" Text="Changer la photo du profil" CssClass="btn btn-primary" data-toggle="modal" data-target="#maPhotoProfile" />
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
                <div style="clear:both; float:none; padding:0px; margin:0px;">
                <asp:Button ID="btnSauvegarderImage" Text="Sauvegarder" runat="server" OnClientClick="copieImgData()" OnClick="SauvegarderLaPhoto_Click" />
            </div>
            </ItemTemplate>

        </asp:ListView>
            </div>
















        Prévisualisation
                        <div id="dvPreview2" style="text-align:center; width:100%;">
                            <asp:Image ID="imgModifierPhoto" runat="server" />
                        </div>
        <br />
        <br />
        <div style="text-align:left; width:100%;">
            <asp:Label ID="lblModifierDescription" runat="server" Text="Decription de la photo :" style="margin-left:15%;"></asp:Label>
            <br />
            <div style="text-align:center; width:100%;">
                <asp:TextBox ID="txtbModifierPhotoDescription" runat="server" TextMode="MultiLine" style="max-width:70%; min-width:70%; text-align:left; min-height:100px; max-height:500px;"></asp:TextBox>
           </div>

        </div>
        <br />
        <asp:Button ID="btnUpdaterModifierPhoto" runat="server" CssClass="btn btn-default"  Text="Modifier cette photo" OnClick="btnUpdaterModifierPhoto_Click" />
            <br />
        
         </div>

        </div>

            <br />
            <asp:Button ID="btnModifierRetourAuPhoto" runat="server" Text="Retour aux photos" OnClick="btnVoirLesPhotos_Click" />
            <br />
            <asp:HiddenField ID="hfieldIDItemAModifier" runat="server" Value="" />
        </asp:View>





























        <asp:View ID="viewSupprimerPhoto" runat="server">
            <div id="divSupprimerPhotos" runat="server" style="text-align:center; width:100%; clear:both;">
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
                                <asp:Image ID="imgLaPhoto" runat="server" ImageUrl='<%# "~/Photos/Souvenir/" + Item.typePhoto + "/" + Item.pathPhoto %>' style="max-width:100%; max-height:100%;" />
                             </div>
                                <div style="width:97%;padding-left:3%; clear:both;">
                                    <asp:TextBox ID="txtbDescriptionVoir" runat="server" TextMode="MultiLine" Text='<%# Item.descriptionPhoto %>' style="width:100%; min-height:100px;" Enabled="false"></asp:TextBox>
                             </div>
                                <div style="clear:both">

                                    <div style="float:left; text-align:left; width:50%; padding-left:15px;">
                                        <asp:Button ID="btnModifierLaPhoto" runat="server" Text="Modifier" CommandArgument='<%# Item.IDPhotos %>' OnClick="btnModifierLaPhoto_Click" />
                                    </div>

                                    <div style="float:right;text-align:right; width:50%; padding-right:15px;">
                                         <asp:Button ID="btnSupprimerLaPhoto" runat="server" Text="Supprimer" CommandArgument='<%# Item.IDPhotos %>' OnClick="btnSupprimerLaPhoto_Click" />
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
                <br />
            <asp:Button ID="btnAllezAjouterUnePhoto" runat="server" Text="Ajouter une photo" OnClick="btnAjouterUnePhoto_Click" />
            </div>
        </asp:View>

    </asp:MultiView>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#fuplPhoto").change(function () {
                //POUR DÉBUGER

                //Max et min size pour le preview
                var maxSize = 1000;
                var minSize = 120;

                $("#dvPreview").html("");
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                if (regex.test($(this).val().toLowerCase())) {
                    if (typeof (FileReader) != "undefined") {
                        $("#dvPreview").show();

                        $("#dvPreview").append("<img />");
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            $("#dvPreview img").attr("src", e.target.result);

                            var img = new Image();
                            img.src = e.target.result;

                            document.getElementById('<%= lblImageTailleInitial.ClientID %>').textContent = "Taille Initial : " + img.width + "x" + img.height;

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

                                document.getElementById('<%= lblImageTailleFinal.ClientID %>').textContent = "Taille Final : " + width + "x" + height;

                                $("#dvPreview img").attr("width", width);
                                $("#dvPreview img").attr("height", height);
                            }
                            reader.readAsDataURL($(this)[0].files[0]);
                        } else {
                            alert("Ce navigateur ne support pas FileReader.");
                        }
                    //}
                    } else {
                        $("#dvPreview").show();
                        $("#dvPreview").append("<img />");
                        $("#dvPreview img").attr("width", minSize);
                        $("#dvPreview img").attr("height", minSize);
                        $("#dvPreview img").attr("src", "../Photos/Profils/photobase.bmp");
                        alert("Svp, mettre une image valide.");
                    }
            });
        });
</script>
</asp:Content>