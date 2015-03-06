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
        <asp:TreeNode Text="Bradley" Value="ID-1234" />
        <asp:TreeNode Text="Whitney" Value="ID-5678" />
        <asp:TreeNode Text="Barbara" Value="ID-9101" />
      </asp:TreeNode>
    </Nodes>

                </asp:TreeView>
               
            </div>
        </div>


</asp:Content>
