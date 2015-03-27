<%--Cette classe présente les professeurs du Département d'informatique ainsi que les élèves inscrits au programme 
Écrit par Yannick Huard - Marie-Philippe Gill, Février 2015
Intrants: MasterPage
Extrants: --%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuiSommesNous.aspx.cs" Inherits="Site_de_la_Technique_Informatique.QuiSommesNous" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        var count = 15;
        var counter = setInterval(timer, 1000); //1000 will  run it every 1 second
        function timer(myImage) {
            count = count - 1;
            if (count <= 0) {
                clearInterval(counter);
                $('#AxelModal').modal();                      // initialized with defaults
                $('#AxelModal').modal({ keyboard: false });   // initialized with no keyboard
                $('#AxelModal').modal('show');                // initializes and invokes show immediately
                return;
            }

            //Do code for showing the number of seconds here
        }

        function EasterEgg(myImage) {
            debugger;
            if (myImage.title == "Axel") {
                timer(myImage);
                count = 10;
            }
        }
    </script>

    <!-- Header container -->
    <div class="container">

        <!-- /.modal -->
        <div class="modal fade" id="AxelModal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Oh oh un Easter Egg!</h4>
                    </div>
                    <div class="modal-body">
                        <img src="Photos/Profils/Xavier.JPG" height="500" width="500" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- modal ./ -->

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Qui sommes-nous?
                    
                </h1>
                <ol class="breadcrumb">
                    <li><a href="Default.aspx">Accueil</a>
                    </li>
                    <li class="active">Qui sommes-nous?</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->

        <!-- Intro Content -->
        <div class="row">
            <div class="col-md-6">
                <img class="img-responsive" src="Photos/quiSommesNous.jpg" alt="" />
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

            <asp:ListView ID="lvProfesseurs" runat="server"
                ItemType="Site_de_la_Technique_Informatique.Model.Professeur"
                SelectMethod="lvProfesseurs_GetData"
                GroupItemCount="3">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="groupPlaceHolder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <GroupTemplate>
                    <div class="row">
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </div>
                </GroupTemplate>
                <ItemTemplate>
                    <div class="col-lg-4 text-center">
                        <div class="thumbnail">
                            <div class="row" style="">
                                <%-- Photo du professeur --%>
                                <asp:Image ID="imgProf" runat="server" ImageUrl='<%# Eval ("pathPhotoProfil", "~/Photos/Profils/{0}") %>' ToolTip='<%# Eval("prenom") %>' onMouseOver="EasterEgg(this);" />
                            </div>
                            <div class="row">
                                <%-- Nom du professeur --%>
                                <h3>
                                    <asp:Label ID="lblNomProf" runat="server" Text='<%# Eval("prenom") %>'></asp:Label><br />
                                    <small>Professeur</small>
                                </h3>
                            </div>
                            <div class="row">
                                <%-- Présentation --%>
                                <p>
                                    <asp:Label ID="lblPresentation" runat="server" Text='<%# BindItem.presentation %>'></asp:Label>
                                </p>
                            </div>
                            <div class="row">
                                <%-- Email --%>
                                <ul class="list-inline">
                                    <li><i class="glyphicon glyphicon-envelope"></i>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# BindItem.courriel %>'></asp:Label></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>



        </div>
        <!-- /.row -->

        <!-- Élèves -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Nos Étudiants</h2>
            </div>

            <asp:ListView ID="lvEtudiants" runat="server"
                ItemType="Site_de_la_Technique_Informatique.Model.Etudiant"
                SelectMethod="lviewEtudiants_GetData"
                GroupItemCount="6">

                <EmptyDataTemplate>
                    Aucune information disponible pour le moment.
                </EmptyDataTemplate>

                <ItemTemplate>
                    <div class="col-md-2 col-sm-4 col-xs-6">
                        <asp:Image runat="server" class="img-responsive customer-img" ImageUrl='<%# "~/Photos/Profils/" +  Eval("pathPhotoProfil") %>' />
                    </div>
                </ItemTemplate>

                <LayoutTemplate>
                    <asp:PlaceHolder ID="groupPlaceHolder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <GroupTemplate>
                    <div class="row">
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </div>
                </GroupTemplate>
                <GroupSeparatorTemplate>
                    <div class="row">&nbsp;</div>
                </GroupSeparatorTemplate>

            </asp:ListView>

        </div>
        <!-- /.row -->

        <hr />

    </div>



</asp:Content>
