<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cropper.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.cropper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="utf-8">
  <meta content="IE=edge" http-equiv="X-UA-Compatible">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <meta name="description" content="A basic example of Cropper.">
  <meta name="keywords" content="HTML, CSS, JS, JavaScript, jQuery, image cropping, web development">
  <meta name="author" content="Fengyuan Chen">
  <title>Cropper</title>
  <link href="css/bootstrap.min.css" rel="stylesheet">
  <link href="cropper.css" rel="stylesheet">
  <link href="css/docs.css" rel="stylesheet">

  <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<body>
    <div>
  <div class="container-fluid eg-container" id="basic-example">
    <div class="row eg-main">
      <div class="col-xs-12 col-sm-9">
        <div class="eg-wrapper">
          <img class="cropper" src="img/picture-2.jpg" alt="Picture">
        </div>
      </div>
      <div class="col-xs-12 col-sm-3">
        <div class="eg-preview clearfix">
          <div class="preview preview-lg"></div>
        </div>
        
      </div>
    </div>
    <div class="clearfix">
      <div class="eg-button">
        <button class="btn btn-warning" id="reset" type="button">Restaurer</button>
        <button class="btn btn-info" id="zoomIn" type="button">Zoom In</button>
        <button class="btn btn-info" id="zoomOut" type="button">Zoom Out</button>
        <label class="btn btn-primary" for="inputImage" title="Upload image file">
          <input class="hide" id="inputImage" name="file" type="file" accept="image/*">
         Téléverser
        </label>
      </div>
      <div class="row eg-input">
        <div class="col-md-3">
          <div class="input-group">
            <span class="input-group-btn">
              <button class="btn btn-primary" id="replace" type="button">Replace</button>
            </span>
            <input class="form-control" id="replaceWith" type="text" value="img/picture-2.jpg">
          </div>
          
        </div>
      </div>

   
    </div>
  </div>
  <script src="js/jquery.min.js"></script>
  <script src="js/bootstrap.min.js"></script>
  <script src="cropper.js"></script>
  <script src="js/docs.js"></script>
</body>
</html>