﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Concepteur.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Concepteur" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Concepteurs
                    
                </h1>
              
            </div>
        </div>
        <!-- /.row -->

        <!-- Projects Row -->
        <div class="row">
            <div class="col-md-6 img-portfolio">
               
                    <img class="img-responsive" src='<%# isLocal() ? "~/Upload/Photos/Concepteurs/Cedric.jpg" : "~/../Upload/Photos/Concepteurs/Cedric.jpg" %>' alt=""/>
               
                <h3>
                    Cédric Archambault
                </h3>
                <p>Le grand designer en formulaire.</p>
            </div>
            <div class="col-md-6 img-portfolio">
              
                    <img class="img-responsive" src='<%# isLocal() ? "~/Upload/Photos/Concepteurs/Baron.jpg" : "~/../Upload/Photos/Concepteurs/Baron.jpg" %>' alt=""/>
               
                <h3>
                    Philippe Baron
                </h3>
                <p>Le grand Gitmaster. (Libéral)</p>
            </div>
        </div>
        <!-- /.row -->

        <!-- Projects Row -->
        <div class="row">
            <div class="col-md-6 img-portfolio">
               
                    <img class="img-responsive" src='<%# isLocal() ? "~/Upload/Photos/Concepteurs/Bibeau.jpg" : "~/../Upload/Photos/Concepteurs/Bibeau.jpg" %>' alt=""/>
              
                <h3>
                    Philippe Bibeau
                </h3>
                <p>Le grand photoshop master spécialisé en "meme".</p>
            </div>
            <div class="col-md-6 img-portfolio">
                
                    <img class="img-responsive" src='<%# isLocal() ? "~/Upload/Photos/Concepteurs/Raphael.jpg" : "~/../Upload/Photos/Concepteurs/Raphael.jpg" %>' alt=""/>
               
                <h3>
                    Raphael Brouard
                </h3>
                <p>Le grand adorateur de poney.</p>
            </div>
        </div>
        <!-- /.row -->

        <!-- Projects Row -->
        <div class="row">
            <div class="col-md-6 img-portfolio">
                
                    <img class="img-responsive" src='<%# isLocal() ? "~/Upload/Photos/Concepteurs/Jacob.jpg" : "~/../Upload/Photos/Concepteurs/Jacob.jpg" %>' alt=""/>
                
                <h3>
                    Jacob Fontaine
                </h3>
                <p>Le grand "la journée a mal été".</p>
            </div>
            <div class="col-md-6 img-portfolio">
                
                    <img class="img-responsive" src='<%# isLocal() ? "~/Upload/Photos/Concepteurs/Marie.jpg" : "~/../Upload/Photos/Concepteurs/Marie.jpg" %>' alt=""/>
               
                <h3>
                    Marie-Philippe Gill
                </h3>
                <p>Le grand côté féminin du groupe, avec 500$ en poche.</p>
            </div>
             <div class="col-md-6 img-portfolio">
                
                    <img class="img-responsive" src='<%# isLocal() ? "~/Upload/Photos/Concepteurs/Karl.jpg" : "~/../Upload/Photos/Concepteurs/Karl.jpg" %>' alt=""/>
                
                <h3>
                    Karl Gosselin
                </h3>
                <p>Le grand Johnny Fap, star d'internet.</p>
            </div>
             <div class="col-md-6 img-portfolio">
                
                    <img class="img-responsive" src='<%# isLocal() ? "~/Upload/Photos/Concepteurs/Yannick.jpg" : "~/../Upload/Photos/Concepteurs/Yannick.jpg" %>' alt=""/>
               
                <h3>
                    Yannick Huard
                </h3>
                <p>Le grand escroc qui paye en dessous de la table.</p>
            </div>
             <div class="col-md-6 img-portfolio">
               
                    <img class="img-responsive" src='<%# isLocal() ? "~/Upload/Photos/Concepteurs/Xavier.jpg" : "~/../Upload/Photos/Concepteurs/Xavier.jpg" %>' alt=""/>
                
                <h3>
                    Xavier Poutré
                </h3>
                <p>Le grand destructeur de BD.</p>
            </div>
             <div class="col-md-6 img-portfolio">
                
                    <img class="img-responsive" src='<%# isLocal() ? "~/Upload/Photos/Concepteurs/Francis.jpg" : "~/../Upload/Photos/Concepteurs/Francis.jpg" %>' alt=""/>
               
                <h3>
                    Francis Trépanier
                </h3>
                <p>Le grand gardien de la chasteté de la BD et de Minecraft.</p>
            </div>           
        </div>
        <!-- /.row -->

        <hr/>

       
        <!-- /.row -->

        <hr/>

        </div>
</asp:Content>
