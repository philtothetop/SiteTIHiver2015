<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Admin_AjoutPhoto.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_AjoutPhoto" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="JS/bootstrap.js"></script>
    <script src="http://code.jquery.com/jquery.js"></script>

    <asp:HiddenField runat="server" ID="ImgExSrc" />
    <asp:ScriptManagerProxy ID="smProxy" runat="server" />

 <h1>Administrateur : Ajouter une photo</h1>

        <ol class="breadcrumb">
                    <li>
                        <a href="nullFORnow.aspx">Retour au panneau d'administration</a>
                    </li>
                </ol>

    <div id="divReussiAjouterImage" runat="server" visible="false">
        <asp:Label ID="lblReussi" runat="server" Text="L'image a bien été ajouté."></asp:Label>
        <br />
        <asp:Button ID="btnAjouterAutreImage" runat="server" Text="Ajouter une autre image" OnClick="btnajouterAutreImage_Click"/>
    </div>

    <div id="divPasReussiAjouterImage" runat="server" visible="false">
        <asp:Label ID="lblPasReussi" runat="server" Text=""></asp:Label>
    </div>

    <div id="divPourAjouterUnePhoto" runat="server">
     <asp:ListView ID="lviewPhoto" runat="server"
            ItemType="Site_de_la_Technique_Informatique.Model.Photos"
            SelectMethod="GetUnePhoto">

         <LayoutTemplate>
             <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
         </LayoutTemplate>

            <ItemTemplate>
                <div class="modif-photo">
                    <div class="img-thumbnail img-photo preview-photo">
                        <div></div>
                        <asp:Image ID="showDataURL" runat="server" ImageUrl="../Photos/Profils/photobase.bmp" style="min-width:120px;min-height:120px;max-width:1000px;max-height:1000px;" />
                    </div>
                    <br />
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
                                <iframe src="../Jquery/Cropper2/Cropper2.aspx" width="570" height="625" scrolling="no" frameborder="0"></iframe>

                            </div>
                        </div>

                    </div>
                </div>
                <asp:Button ID="btnSauvegarderImage" Text="Sauvegarder" runat="server" OnClientClick="copieImgData()" OnClick="SauvegarderLaPhoto_Click" />
            </ItemTemplate>
        </asp:ListView>

        <%--<div style="clear:both">
            <br />
            <br />
            <br />
            <asp:ListView ID="lviewAjouterUneImage" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.Photos"
                    SelectMethod="GetUnePhoto">

                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </LayoutTemplate>

                    <ItemTemplate>

            <div style="text-align: left; margin-left: 40px;">

            <asp:Image ID="imgPhoto" runat="server" ImageUrl="../Photos/Profils/photobase.bmp" Height="120px" Width="120px" />

            <div id="dvPreview" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=image);">
            </div>

            <asp:TextBox ID="txtPhoto" Enabled="false" Visible="false" placeholder="Fichier de type .jpg ou .png" runat="server" Style="width: 200px" />
            <asp:FileUpload ID="fuplPhoto" runat="server" Width="1px" ClientIDMode="Static" />
            <button onclick="$('[id$=fuplPhoto]').click(); return false;"
                class="btn btn-default">
                Choisir</button>
            <asp:Button ID="btnUpdate" CssClass="btn btn-default"  runat="server" Text="Valider son image" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnAnnulerImage" runat="server" CssClass="btn btn-default" Text="Annuler son image" />

                <asp:Label ID="lblEchecImage" runat="server" Text=""></asp:Label>
        </div>

                        </ItemTemplate>
                </asp:ListView>
            </div>--%>
        <div style="clear:both;">
    <asp:DropDownList ID="ddlTypeDImage" runat="server">
        <asp:ListItem Text="Souvenir"></asp:ListItem>
        <asp:ListItem Text="Cégep"></asp:ListItem>
        <asp:ListItem Text="Autre"></asp:ListItem>
    </asp:DropDownList>
            </div>
    </div>

    <asp:HiddenField ID="hfPathPhotoProfil" runat="server" />

    <link rel="stylesheet" href="Css/Inscription.css" 
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta content="IE=edge" http-equiv="X-UA-Compatible">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="A basic example of Cropper.">
    <meta name="keywords" content="HTML, CSS, JS, JavaScript, jQuery, image cropping, web development">
    <meta name="author" content="Fengyuan Chen">
    <title>Cropper</title>
    <link href="Cropper2/css/bootstrap.min.css" rel="stylesheet">
    <link href="Cropper2/css/cropper.css" rel="stylesheet">
    <link href="Cropper2/css/docs.css" rel="stylesheet">
    <link href="Css/Inscription.css" rel="stylesheet" />
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
            document.getElementById("<%=ImgExSrc.ClientID%>").value = ContentPlaceHolder1_lviewPhoto_showDataURL_0.src;
        }
    </script>
    <script type="text/javascript">
        window.transfertDataImg = function (dataURL) {
            $("#ContentPlaceHolder1_lviewPhoto_showDataURL_0").attr("src", dataURL);
        };
    </script>
    <script type="text/javascript">
        window.closeModal = function () {
            $('#maPhotoProfile').modal('hide');
        };
    </script>




    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#fuplPhoto").change(function () {
                $("#dvPreview").html("");
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                if (regex.test($(this).val().toLowerCase())) {
                    if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                        $("#dvPreview").show();
                        $("#dvPreview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
                    }
                    else {
                        if (typeof (FileReader) != "undefined") {
                            $("#dvPreview").show();
                            $("#dvPreview").append("<img />");
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $("#dvPreview img").attr("src", e.target.result);
                                $("#dvPreview img").attr("width", 120);
                                $("#dvPreview img").attr("height", 120);
                            }
                            reader.readAsDataURL($(this)[0].files[0]);
                        } else {
                            alert("Ce navigateur ne support pas FileReader.");
                        }
                    }
                } else {
                    alert("Svp, mettre une image valide.");
                }
            });
        });
</script>

</asp:Content>