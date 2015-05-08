<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlanDuSite.aspx.cs" Inherits="Site_de_la_Technique_Informatique.PlanDuSite" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Plan du site
                    
                </h1>
                <ol class="breadcrumb">
                    <li><a href="default.aspx">Accueil</a>
                    </li>
                    <li class="active">Plan du site</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->

        <!-- Content Row -->
        <div class="row">
            <div class="col-lg-12">
                <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="1">

                    <Nodes>
                        <asp:TreeNode Text="Site de Techniques de l'informatique"  SelectAction="None" >
                            <asp:TreeNode Text="Accueil" NavigateUrl="~/Default.aspx"  />
                            <asp:TreeNode Text="Qui sommes-nous?" NavigateUrl="~/QuiSommesNous.aspx"  />
                            <asp:TreeNode Text="Nouvelles" NavigateUrl="~/Nouvelles.aspx"  />
                             <asp:TreeNode Text="Souvenirs" NavigateUrl="~/Souvenirs.aspx"  />


                             <asp:TreeNode Text="Informations" SelectAction="None" >

                                <asp:TreeNode Text="Vertic" NavigateUrl="~/Vertic.aspx"  />
                                <asp:TreeNode Text="Stages" NavigateUrl="~/InformationsStage.aspx" />
                                <asp:TreeNode Text="Témoignages" NavigateUrl="~/.aspx"  />
                                <asp:TreeNode Text="Parutions média" NavigateUrl="~/LesParutionsMedias.aspx" />

                            </asp:TreeNode>

                            <asp:TreeNode Text="Offres d'emploi" NavigateUrl="~/OffreEmploi.aspx" />
                         
                            <asp:TreeNode Text="Inscription" NavigateUrl="~/Inscription-Etudiant.aspx" />

                            <asp:TreeNode Text="Recherche" NavigateUrl="~/Recherche.aspx" />
                          
                             <asp:TreeNode Text="Ressources" SelectAction="None" >
                                 <asp:TreeNode Text="Contactez-nous" NavigateUrl="~/Contact.aspx" />
                                 <asp:TreeNode Text="Concepteurs" NavigateUrl="~/Concepteur.aspx" />
                                 

                                 </asp:TreeNode>

                              <asp:TreeNode Text="Aide" SelectAction="None" >
                                 <asp:TreeNode Text="Foire aux questions" NavigateUrl="~/FAQ.aspx" />
                                 <asp:TreeNode Text="Plan du site" NavigateUrl="~/PlanDuSite.aspx"  />
                               

                                 </asp:TreeNode>

                        </asp:TreeNode>
                    </Nodes>

                </asp:TreeView>

            </div>
        </div>
        </div>
</asp:Content>
