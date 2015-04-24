<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="QuePourTest.aspx.cs" Inherits="Site_de_la_Technique_Informatique.QuePourTest" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="JS/bootstrap.js"></script>

 <h1>Administrateur : Ajouter une photo</h1>

        <ol class="breadcrumb">
                    <li>
                        <a href="nullFORnow.aspx">Retour au panneau d'administration</a>
                    </li>
                </ol>

    <div id="divReussiAjouterImage" runat="server" visible="false" style="text-align:center; width:100%;">
        <asp:Label ID="lblReussi" runat="server" Text="L'image a bien été ajouté."></asp:Label>
        <br />
        <asp:Button ID="btnAjouterAutreImage" runat="server" Text="Ajouter une autre image" OnClick="btnajouterAutreImage_Click"/>
    </div>

    <div id="divPasReussiAjouterImage" runat="server" visible="false" style="text-align:center; width:100%; color:red;">
        <asp:Label ID="lblPasReussi" runat="server" Text=""></asp:Label>
        <br />
        <br />
    </div>

    <div id="divPourAjouterUnePhoto" runat="server">

    <div id="divPourUpdatePhoto" runat="server" style="text-align:center; width:100%;">
    Type d'image : <asp:DropDownList ID="ddlTypeDImage" runat="server">
        <asp:ListItem Text="Souvenir"></asp:ListItem>
        <asp:ListItem Text="Cégep"></asp:ListItem>
        <asp:ListItem Text="Autre"></asp:ListItem>
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
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-default"  Text="Uploader cette image" OnClick="btnUpdate_Click" />
        <br />
        <br />
        <asp:Label ID="lblImageTailleInitial" runat="server" Text="Taille Initial : 0x0"></asp:Label>
        <br />
        <asp:Label ID="lblImageTailleFinal" runat="server" Text="Taille Final : 0x0"></asp:Label>
        <br />

            </div>

        </div>

    <img id="imgIDOK" width="100" height="100"/>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#fuplPhoto").change(function () {
                //POUR DÉBUGER
                //$("#imgIDOK").attr("width", 200);
                //$("#imgIDOK").attr("height", 200);

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
                                if (img.height > maxSize && img.width > maxSize)
                                {
                                    if (valeurAUtiliser < img.width)
                                    {
                                        valeurAUtiliser = img.width;
                                    }
                                }
                                else if (img.height > maxSize)
                                {
                                    valeurAUtiliser = img.height;
                                }
                                else if (img.width > maxSize)
                                {
                                    valeurAUtiliser = img.width;
                                }
                                else
                                {
                                    valeurAUtiliser = maxSize;
                                }

                                var valeurDivision = maxSize / valeurAUtiliser;
                                width = img.width * valeurDivision;
                                height = img.height * valeurDivision;

                                //Si plus petit que min grosseur maintenant
                                if (width < minSize)
                                {
                                    width = minSize;
                                }

                                //Si plus petit que min hauteur maintenant
                                if (height < minSize)
                                {
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