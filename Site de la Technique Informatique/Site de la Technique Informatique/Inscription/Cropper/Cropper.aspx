﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cropper.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.Cropper.Cropper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <head>
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
                <div class="container-fluid eg-container" id="basic-example">
                    <div class="row eg-main">
                        <div class="col-xs-12 col-sm-9">
                            <div class="eg-wrapper">
                                <img class="cropper" src="img/picture-2.jpg" alt="Picture">
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-3">
                            <asp:Label ID="lblPostBack" runat="server" Text="" />
                            <%--        <div class="eg-preview clearfix">
          <div class="preview preview-lg"></div>
          <div class="preview preview-md"></div>
          <div class="preview preview-sm"></div>
          <div class="preview preview-xs"></div>
        </div>--%>
                            <%--        <div class="eg-data">
          <div class="input-group">
            <span class="input-group-addon">X</span>
            <input class="form-control" id="dataX" type="text" placeholder="x">
            <span class="input-group-addon">px</span>
          </div>
          <div class="input-group">
            <span class="input-group-addon">Y</span>
            <input class="form-control" id="dataY" type="text" placeholder="y">
            <span class="input-group-addon">px</span>
          </div>
          <div class="input-group">
            <span class="input-group-addon">Width</span>
            <input class="form-control" id="dataWidth" type="text" placeholder="width">
            <span class="input-group-addon">px</span>
          </div>
          <div class="input-group">
            <span class="input-group-addon">Height</span>
            <input class="form-control" id="dataHeight" type="text" placeholder="height">
            <span class="input-group-addon">px</span>
          </div>
          <!-- <div class="input-group">
            <span class="input-group-addon">Rotate</span>
            <input class="form-control" id="dataRotate" type="text" placeholder="rotate">
            <span class="input-group-addon">deg</span>
          </div> -->
        </div>--%>
                        </div>
                    </div>
                    <div class="clearfix">
                        <div class="eg-button">
                            <button class="btn btn-warning" id="reset" type="button">Reset</button>
                            <%--<button class="btn  btn-warning" id="reset2" type="button">Reset (deep)</button>--%>
                            <%--<button class="btn btn-primary" id="clear" type="button">Clear</button>--%>
                            <%--        <button class="btn btn-danger" id="destroy" type="button">Destroy</button>
        <button class="btn btn-success" id="enable" type="button">Enable</button>--%>
                            <%--<button class="btn btn-warning" id="disable" type="button">Disable</button>--%>
                            <button class="btn btn-info" id="zoomIn" type="button">Zoom In</button>
                            <button class="btn btn-info" id="zoomOut" type="button">Zoom Out</button>
                            <%--        <button class="btn btn-info" id="rotateLeft" type="button">Rotate Left</button>
        <button class="btn btn-info" id="rotateRight" type="button">Rotate Right</button>--%>
                            <%--<button class="btn btn-primary" id="setData" type="button">Set Data</button>--%>
                            <label class="btn btn-primary" for="inputImage" title="Upload image file">
                                <input class="hide" id="inputImage" name="file" type="file" accept="image/*">
                                Télécharger
       
                            </label>
                        </div>
                        <div class="row eg-input">
                            <div class="col-md-6">
                                <%-- <div class="input-group">
            <span class="input-group-btn">
              <button class="btn btn-info" id="getData" type="button">Get Data</button>
            </span>
            <input class="form-control" id="showData" type="text">
            <span class="input-group-btn">
              <button class="btn btn-info" id="getData2" type="button">Get Data (Rounded)</button>
            </span>
          </div>--%>
                                <%-- <div class="input-group">
            <span class="input-group-btn">
              <button class="btn btn-info" id="getImageData" type="button">Get Image Data</button>
            </span>
            <input class="form-control" id="showImageData" type="text">
          </div>--%>
                            </div>
                            <%--                            <div class="col-md-3">
      <%--                          <div class="input-group">
                                    <span class="input-group-btn">
                                        <button class="btn btn-primary" id="replace" type="button">Replace</button>
                                    </span>
                                    <input class="form-control" id="replaceWith" type="text" value="img/picture-2.jpg">
                                </div>--%>
                            <%--<div class="input-group">
            <span class="input-group-btn">
              <button class="btn btn-primary" id="setAspectRatio" type="button">Set Aspect Ratio</button>
            </span>
            <input class="form-control" id="aspectRatio" type="text" value="auto">
          </div></div>--%>

                            <%--        <div class="col-md-3">
          <div class="input-group">
            <span class="input-group-btn">
              <button class="btn btn-primary" id="zoom" type="button">Zoom</button>
            </span>
            <input class="form-control" id="zoomWith" type="number" value="0.5">
          </div>
          <div class="input-group">
            <span class="input-group-btn">
              <button class="btn btn-primary" id="rotate" type="button">Rotate</button>
            </span>
            <input class="form-control" id="rotateWith" type="number" value="45">
          </div>
        </div>--%>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-primary" id="getDataURL2" type="button" runat="server">Get Data URL (JPG)</button>
                            <%--<asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" Text="Fermer" OnClick="LinkButton1_Click" />--%>
                        </div>
                        <div class="row eg-output">
                            <div class="col-md-12">
                                <%-- <button class="btn btn-primary" id="getDataURL" type="button">Get Data URL</button>--%>
                                <%--<button class="btn btn-primary" id="getDataURL2" type="button">Get Data URL (JPG)</button>--%>
                                <%--          <button class="btn btn-primary" id="getDataURL3" type="button">Get Data URL (160*90)</button>--%>
                            </div>
                            <div class="col-md-6">
                                <%-- <asp:TextBox ID="dataURL" runat="server" Text="" />--%>
                                <asp:Label class="form-control" ID="dataURL" runat="server" Text=""></asp:Label>
                            </div>
                            <%--                            <div class="col-md-6">
                                <div id="showDataURL"></div>
                            </div>--%>
                        </div>
                    </div>
                </div>

                <script src="js/jquery.min.js"></script>
                <script src="js/bootstrap.min.js"></script>
                <script src="js/cropper.js"></script>
                <script src="js/docs.js"></script>
            </body>
</html>
</div>
    </form>
</body>
</html>
