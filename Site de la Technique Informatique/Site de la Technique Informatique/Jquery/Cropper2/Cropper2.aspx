<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cropper2.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Jquery.Cropper2.Cropper2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta content="IE=edge" http-equiv="X-UA-Compatible">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="A basic example of Cropper.">
    <meta name="keywords" content="HTML, CSS, JS, JavaScript, jQuery, image cropping, web development">
    <meta name="author" content="Fengyuan Chen">
    <title>Cropper</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/cropper.css" rel="stylesheet">
    <link href="css/docs.css" rel="stylesheet">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div>

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

        <script src="Cropper2/js/jquery.min.js"></script>
        <script src="Cropper2/js/bootstrap.min.js"></script>
        <script src="Cropper2/js/cropper.js"></script>
        <script src="Cropper2/js/docsV2.js"></script>

       

        <div class="modal-footer">
            <div class="row eg-output">
                <div class="col-md-12">
                    <button class="btn btn-primary" id="getDataURL3" type="button" data-dismiss="modal">Fermer</button>
                </div>
            </div>
        </div>



        <script src="js/jquery.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/cropper.js"></script>
        <script src="js/docsV2.js"></script>

    </form>
</body>
</html>
