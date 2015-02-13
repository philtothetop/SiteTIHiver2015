<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuiSommesNous.aspx.cs" Inherits="Site_de_la_Technique_Informatique.QuiSommesNous" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

    <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Qui sommes-nous?
                    
                </h1>
                <ol class="breadcrumb">
                    <li><a href="index.html">Accueil</a>
                    </li>
                    <li class="active">À propos</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->

        <!-- Intro Content -->
        <div class="row">
            <div class="col-md-6">
                <img class="img-responsive" src="Photos/quiSommesNous.jpg" alt=""/>
            </div>
            <div class="col-md-6">
                <h2>Notre équipe</h2>
                <p>L'équipe de la Technique de l'informatique de gestion possède des professeurs dynamiques qui contribueront à votre réussite scolaire.</p>
                <p>Pour l'obtention de votre diplôme, vous devrez réussir 20 cours de spécialisations en informatique, 14 cours de bases, réussir l'Épreuve Uniforme de Langue et l'Épreuve Synthèse de Programme.</p>
                <p>Venez vivre la vie étudiante, faites connaissance avec de nouvelles personnes qui partagent les mêmes passions que vous en informatique.</p>
            </div>
        </div>
        <!-- /.row -->

        <!-- Prof -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Nos professeurs</h2>
            </div>
            <div class="col-md-4 text-center">
                <div class="thumbnail">
                    <img class="img-responsive" src="Photos/entete.jpg" alt=""/>
                    <div class="caption">
                        <h3>Axel Rassart<br>
                            <small>Professeur</small>
                        </h3>
                        <p>Binding avec présentation</p>
                        <ul class="list-inline">
                            <li><i class="glyphicon glyphicon-envelope"></i>
                            </li>          
                            <li>Binding avec email</li>                                          
                        </ul>
                    </div>
                </div>
            </div>
                      
           
        </div>
        <!-- /.row -->

        <!-- Élèves -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Nos Étudiants</h2>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6">
                <img class="img-responsive customer-img" src="Photos/image1.jpg" alt=""/>
            </div>
            
        </div>
        <!-- /.row -->

        <hr/>

    </div>
    

</asp:Content>
