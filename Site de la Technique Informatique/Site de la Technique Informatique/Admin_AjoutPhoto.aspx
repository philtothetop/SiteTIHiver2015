<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Admin_AjoutPhoto.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_AjoutPhoto" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
    </div>

    <div id="divPasReussiAjouterImage" runat="server" visible="false">
        <asp:Label ID="lblPasReussi" runat="server" Text="" Visible="false"></asp:Label>
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
                        <asp:Image ID="showDataURL" runat="server" ImageUrl="../Photos/Profils/photobase.bmp" Width="125" Height="125" />
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
                <asp:Button ID="btnSauvegarderImage" Text="Sauvegarder" runat="server" OnClientClick="copieImgData()" OnClick="SauvegarderLaPhoto_Click" />
            </ItemTemplate>
        </asp:ListView>
        </div>
    <asp:DropDownList ID="ddlTypeDImage" runat="server">
        <asp:ListItem Text="Souvenir"></asp:ListItem>
        <asp:ListItem Text="Cégep"></asp:ListItem>
        <asp:ListItem Text="Autre"></asp:ListItem>
    </asp:DropDownList>


    <link rel="stylesheet" href="Css/Inscription.css" />
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
</asp:Content>