<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet"/>
    <link href="Css/modern-business.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/Global.css" rel="stylesheet" />

    <script src="Js/bootstrap.js"></script>
    <script src="Js/jquery.js"></script>

    <!-- Header Carousel -->
    <header id="myCarousel" class="carousel slide">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
			<li data-target="#myCarousel" data-slide-to="3"></li>
			<li data-target="#myCarousel" data-slide-to="4"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <div class="fill" style="background-image:url('../Photos/image1.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Élèves 2010-2013</h2><
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image:url('Photos/entete.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Élèves 2011-2014</h2>
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image:url('Photos/img1600-380-3.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Élèves 2012-2015</h2> 
                </div>
            </div>
			 <div class="item">
                <div class="fill" style="background-image:url('Photos/img1600-380-4.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Élèves 2013-20167</h2>
                </div>
            </div>
			 <div class="item">
                <div class="fill" style="background-image:url('Photos/img1600-380-5.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Élèves 2014-2017</h2>
                </div>
            </div>
        </div>

        <!-- Controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="icon-prev"></span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="icon-next"></span>
        </a>
    </header>

    <!-- Page Content -->
    <div class="container">

        <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    Bienvenue sur le site de la techniques en informatique de gestion du Cégep de Granby
                </h1>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="glyphicon glyphicon-question-sign"></i> Qui sommes-nous?</h4>
                    </div>
                    <div class="panel-body">
                        <p>Vous n'êtes pas certain de vous incrire dans une spécialisation de l'informatique de gestion? Vous vous interrogez si c'est votre vraie vocation? Apprenez tout ce que vous devez savoir de la technique! </p>
                        <a href="full-width.html" class="btn btn-default">En savoir plus...</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="glyphicon glyphicon-info-sign"></i> Nouvelles</h4>
                    </div>
                    <div class="panel-body">
                        <p>Apprenez toutes les nouvelles de la technique</p>
                        <a href="full-width.html" class="btn btn-default">En savoir plus...</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="glyphicon glyphicon-usd"></i> Offres d'emploi</h4>
                    </div>
                    <div class="panel-body">
                        <p>Vous êtes sur le point d'avoir votre diplôme et vous cherchez un travail le plus rapidement que possible? Vous serez gâté(e) par toutes les offres d'emploi que nous vous proposons!</p>
                        <a href="full-width.html" class="btn btn-default">En savoir plus...</a>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.row -->

        <!-- Portfolio Section -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Les professeurs</h2>
            </div>
            <div class="col-md-3 col-sm-6">
                <h4 style="text-align:center;">Denis Dupaul</h4>
                <a href="portfolio-item.html">
                    <img class="img-responsive img-portfolio img-hover" src="Photos/image1.jpg" alt="">
                </a>
            </div>
            <div class="col-md-3 col-sm-6">
                <h4 style="text-align:center;">Axel Rassart</h4>
                <a href="portfolio-item.html">
                    <img class="img-responsive img-portfolio img-hover" src="Photos/entete.jpg" alt="">
                </a>
            </div>
            <div class="col-md-3 col-sm-6">
                <h4 style="text-align:center;">Régis Lessard</h4>
                <a href="portfolio-item.html">
                    <img class="img-responsive img-portfolio img-hover" src="Photos/image3.jpg" alt="">
                </a>
            </div>
            <div class="col-md-3 col-sm-6">
                <h4 style="text-align:center;">Maryse Desaulniers</h4>
                <a href="portfolio-item.html">
                    <img class="img-responsive img-portfolio img-hover" src="Photos/image4.jpg" alt="">
                </a>
            </div>
            <div class="col-md-3 col-sm-6">
                <h4 style="text-align:center;">Laurent Beauregard</h4>
                <a href="portfolio-item.html">
                    <img class="img-responsive img-portfolio img-hover" src="Photos/image5.jpg" alt="">
                </a>
            </div>
            <div class="col-md-3 col-sm-6">
                <h4 style="text-align:center;">Jie Yang</h4>
                <a href="portfolio-item.html">
                    <img class="img-responsive img-portfolio img-hover" src="Photos/image6.jpg" alt="">
                </a>
            </div>
            <div class="col-md-3 col-sm-6">
                <h4 style="text-align:center;">Simon quelque chose</h4>
                <a href="portfolio-item.html">
                    <img class="img-responsive img-portfolio img-hover" src="Photos/image6.jpg" alt="">
                </a>
            </div>
        </div>
        <!-- /.row -->

        <!-- Features Section -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Une technique spécialisée en programmation</h2>
            </div>
            <div class="col-md-6">
                <p>La programmation exige certaine qualités</p>
                <ul>
                    <li>Débrouillardise</li>                   
                    <li>Logique</li>
                    <li>Esprit d’analyse</li>
                    <li>Aptitudes en mathématiques</li>
                    <li>Sens de l’organisation</li>
                    <li>Capacité à travailler en équipe</li>
                    <li>Persévérance</li>
                    <li>Polyvalence</li>
                    <li>Bonne communication</li>
                    <li>Patience</li>
                    <li>Aimer le café</li>
                </ul>
                <p>Cette technique ne concerne en rien la programmation de jeux vidéo, prendre note qu'il faut s'appliquer et travailler fort pour réussir les cours.</p>
            </div>
            <div class="col-md-6">
                <img class="img-responsive" src="Photos/image1.jpg" alt="">
            </div>
        </div>
        <!-- /.row -->    

        <hr>

        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>

         <hr>

        <!-- Call to Action Section -->
        <div class="well">
            <div class="row">
                <div class="col-md-8">
                    <p>Ici vous trouverai une liste de tous les cours de la technique avec leur description</p>
                </div>
                <div class="col-md-4">
                    <a class="btn btn-lg btn-default btn-block" href="#">Liste de cours</a>
                </div>
            </div>
        </div>

        <hr>
       
        
            
    </div>
    <!-- /.container -->

    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <!--   <script src="js/bootstrap.min.js"></script> -->
	<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>

    <!-- Script to Activate the Carousel -->
    <script>
    $('.carousel').carousel({
        interval: 5000 //changes the speed
    })
    </script>

</asp:Content>
