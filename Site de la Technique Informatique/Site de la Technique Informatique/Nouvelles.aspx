<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nouvelles.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Nouvelles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         
   

    <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Nouvelles
                   
                </h1>
                <ol class="breadcrumb">
                    <li><a href="Default.aspx">Accueil</a>
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
                    <a href="QuiSommesNous.aspx" class="list-group-item">Nouvelles</a>
                    <a href="listeOffresEmploi.aspx" class="list-group-item">Offre d'emploi</a>
                    <a href="#" class="list-group-item">Parutions médias</a>
                    <a href="FAQ.aspx" class="list-group-item">FAQ</a>
                    <a href="#" class="list-group-item">Témoignages</a>                   
                </div>
            </div>
            <!-- Content Column -->
            <div class="col-md-9" style="margin-top">
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

        <hr/>       

    </div>
        </div>
    <!-- /.container -->

</asp:Content>
