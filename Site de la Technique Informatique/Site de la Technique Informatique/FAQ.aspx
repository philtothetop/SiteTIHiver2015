<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="Site_de_la_Technique_Informatique.FAQ" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/modern-business.css" rel="stylesheet"/>
    <link href="font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Foire aux questions (FAQ)
                    
                </h1>
                <ol class="breadcrumb">
                    <li><a href="index.html">Accueil</a>
                    </li>
                    <li class="active">Foire aux questions</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->

        <!-- Content Row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel-group" id="accordion">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Est-ce que je vais apprendre à programmer des jeux vidéo?</a>
                            </h4>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse">
                            <div class="panel-body">
                                Non, la Technique en informatique de gestion montre divers branches de l'informatique, c'est-à-dire matériel, réseautique et logiciel. La branche logiciel est de la programmation, mais nous apprenons à faire des logiciels et des sites web en langage JAVA et C#. Néamoins, vous pourrez vous spécialiser en jeu vidéo à l'université.
                            </div>
                        </div>
                    </div>
                    <!-- /.panel -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Est-il difficile de me trouver un emploi une fois mon DEC obtenu?</a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse">
                            <div class="panel-body">
                                Absolument pas! Au contraire, le secteur de l'informatique est très en demande chez les employeurs le taux de placement 91% après l'obtention de votre DEC.
                            </div>
                        </div>
                    </div>
                    <!-- /.panel -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">Quel serait mon salaire moyen avec un DEC en informatique de gestion? </a>
                            </h4>
                        </div>
                        <div id="collapseThree" class="panel-collapse collapse">
                            <div class="panel-body">
                                Le taux horaire moyen des finissants est de 19.90$/h, votre salaire peut par la suite augmenter jusqu'à 30$/h!
                            </div>
                        </div>
                    </div>
                    <!-- /.panel -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFour">Quels sont les avantages d'aller à l'Université en informatique?</a>
                            </h4>
                        </div>
                        <div id="collapseFour" class="panel-collapse collapse">
                            <div class="panel-body">
                                L'Université permet de se spécialiser dans une branche précise. En plus, vous aurez un an d'expérience reconnu grâce aux stages offerts.
                            </div>
                        </div>
                    </div>
                    <!-- /.panel -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFive">Quel emploi puis-je obtenir avec un DEC en informatique?</a>
                            </h4>
                        </div>
                        <div id="collapseFive" class="panel-collapse collapse">
                            <div class="panel-body">
                                De nombreux emplois s'offrent à vous, pour plus de détails, vous pouvez consulter <a href="http://reperes.qc.ca">http://reperes.qc.ca</a>.
                            </div>
                        </div>
                    </div>
                    <!-- /.panel -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSix">Je suis une fille, vais-je avoir une bourse?</a>
                            </h4>
                        </div>
                        <div id="collapseSix" class="panel-collapse collapse">
                            <div class="panel-body">
                                <a href="http://www.cegepgranby.qc.ca/ressources-aide-et-vie-etudiante/animation-et-activites/chapeau-les-filles/marie-philippe-gill-laureate-pour-la-monteregie-a-la-18e-edition">Oui</a>.
                            </div>
                        </div>
                    </div>                                                
                </div>
                <!-- /.panel-group -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->

        <hr>

        <!-- Footer -->
        <footer>
            <div class="row">
                <div class="col-lg-12">
                    <p>Copyright &copy; Mon site 2014</p>
                </div>
            </div>
        </footer>

    </div>
    <!-- /.container -->

    

</asp:Content>
