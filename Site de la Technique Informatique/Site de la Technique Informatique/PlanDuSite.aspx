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
                <asp:TreeView ID="TreeView1" runat="server">

                    <Nodes>
                        <asp:TreeNode Text="Site de Techniques de l'informatique">
                            <asp:TreeNode Text="Accueil"  />
                            <asp:TreeNode Text="Qui sommes-nous?"  />
                            <asp:TreeNode Text="Nouvelles"  />

                            <asp:TreeNode Text="Souvenirs"  >

                                <asp:TreeNode Text="Photos étudiants"  />
                                <asp:TreeNode Text="Photos professeurs"  />
                                <asp:TreeNode Text="Photos projets" />

                            </asp:TreeNode>

                             <asp:TreeNode Text="Informations" >

                                <asp:TreeNode Text="Verdic"  />
                                <asp:TreeNode Text="Stages"  />
                               

                            </asp:TreeNode>

                            <asp:TreeNode Text="Offres d'emploi"  />
                            <asp:TreeNode Text="Témoignages"  />

                        </asp:TreeNode>
                    </Nodes>

                </asp:TreeView>

            </div>
        </div>
</asp:Content>
