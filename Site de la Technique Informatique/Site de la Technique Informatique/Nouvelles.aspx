<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nouvelles.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Nouvelles" %>
<<<<<<< HEAD

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="css/modern-business.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />


    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>



    <!-- Navigation -->
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.html">Techniques de Informatique</a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="about.html">Qui sommes-nous?</a>
                    </li>
                    <li>
                        <a href="services.html">Services</a>
                    </li>
                    <li>
                        <a href="contact.html">Contact</a>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Portfolio <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="portfolio-1-col.html">Portfolio: 1 colonne</a>
                            </li>
                            <li>
                                <a href="portfolio-2-col.html">Portfolio: 2 colonnes</a>
                            </li>
                            <li>
                                <a href="portfolio-3-col.html">Portfolio: 3 colonnes</a>
                            </li>
                            <li>
                                <a href="portfolio-4-col.html">Portfolio: 4 colonnes</a>
                            </li>
                            <li>
                                <a href="portfolio-item.html">Portfolio: 1 projet</a>
                            </li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Autres Pages <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="full-width.html">Page pleine largeur</a>
                            </li>
                            <li>
                                <a href="sidebar.html">Page avec menu Ã  gauche</a>
                            </li>
                            <li>
                                <a href="faq.html">Foire Aux Questions</a>
                            </li>
                            <li>
                                <a href="404.html">404</a>
                            </li>
                            <li>
                                <a href="pricing.html">Table des Prix </a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>
=======
>>>>>>> 8e2d378ebd447a6a5af9671a24df7328935cc5e7

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         
    <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Nouvelles
                    <small> concernants la technique</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="index.html">Accueil</a>
                    </li>
                    <li class="active">Nouvelles</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->

        <!-- Content Row -->
        <div class="row">
            <!-- Sidebar Column -->
            <div class="col-md-3">
                <div class="list-group">
                    <a href="default.aspx" class="list-group-item">Accueil</a>
                    <a href="QuiSommesNous.aspx" class="list-group-item">Qui sommes-nous?</a>
                    <a href="services.html" class="list-group-item">Services</a>
                    <a href="contact.html" class="list-group-item">Contact</a>
                    <a href="portfolio-1-col.html" class="list-group-item">Portfolio: 1 colonne</a>
                    <a href="portfolio-2-col.html" class="list-group-item">Portfolio: 2 colonnes</a>
                    <a href="portfolio-3-col.html" class="list-group-item">Portfolio: 3 colonnes</a>
                    <a href="portfolio-4-col.html" class="list-group-item">Portfolio: 4 colonnes</a>
                    <a href="portfolio-item.html" class="list-group-item">Portfolio: 1 projet</a>
                    <a href="full-width.html" class="list-group-item">Page pleine largeur</a>
                    <a href="sidebar.html" class="list-group-item">Page avec menu Ã  gauche</a>
                    <a href="faq.html" class="list-group-item">Foire Aux Questions</a>
                    <a href="404.html" class="list-group-item">404</a>
                    <a href="pricing.html" class="list-group-item">Table des prix</a>
                </div>
            </div>
            <!-- Content Column -->
            <div class="col-md-9" style="margin-top:-15px;">
                <asp:ListView ID="lviewNouvelles" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.NouvelleJeu"
                    SelectMethod="getNouvelles">
                    <ItemTemplate>
                        <h3><%# Item.titreNouvelle %></h3>
                        <p> <%# Item.dateNouvelle.ToLongDateString() %></p>
                        <div style="margin-top:5px;" />
                        <p><%# Item.texteNouvelle %></p>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <!-- /.row -->

            <hr>
        </div>


    </div>

    <!-- /.container -->






</asp:Content>
