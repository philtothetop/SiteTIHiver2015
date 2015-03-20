<%@ Page Title="Recherche de membres" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recherche.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Recherche" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Page pleine largeur
                    <small>Exemple</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="index.html">Accueil</a>
                    </li>
                    <li class="active">Page pleine largeur</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->

        <!-- Content Row -->
        <div class="row">
            <div class="col-lg-12">
               

                  <div >
        
                      <div style="padding-top: 5px;">
                        <asp:Label ID="Label4" runat="server" Text="Prénom du Membre:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtPrenomMembre"></asp:TextBox>
                    </div>
                    <div style="padding-top: 5px;">
                        <asp:Label ID="Label1" runat="server" Text="Nom du Membre:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtNomMembre"></asp:TextBox>
                    </div>                 
                    <div style="padding-top: 5px;">
                        <asp:Label ID="Label2" runat="server" Text="Type de Membre:"></asp:Label>
                        <asp:CheckBox ID="chbProfesseur" Text="Professeur" runat="server" TextAlign="Left" />
                        <asp:CheckBox ID="chbEtudiant" Text="Etudiant" runat="server" TextAlign="Left" Style="margin-left: 10px;" />
                    </div>
                    <div style="padding-top: 5px;">
                        <asp:Button runat="server" ID="btnRecherche" Text="Rechercher" OnClick="btnRecherche_Click"></asp:Button>
                    </div>
                    </div>
                <br />
        </div>

        <br />
        <asp:Panel ID="panelResultats" runat="server" Visible="false">
            <asp:ListView runat="server"
                ID="lviewRecherche"
                ItemType="Site_de_la_Technique_Informatique.Model.Membre"
                SelectMethod="lviewRecherche_GetData">
                
                <ItemTemplate>
                    

                    <asp:LinkButton ID="lnkOffre" CssClass="couleurGris"  Text="" runat="server" BorderStyle="Solid" BorderColor="black" BorderWidth="1" Style="width: 50%; border-radius: 5px;">

                    <div class="row">
                            <div class="col-lg-12">


                                <div class="col-lg-2" style="text-align:left;" >
                                 <asp:Image ID="photoProfil" runat="server" Width="75px" ImageUrl='<%# Item.pathPhotoProfil %>'></asp:Image> 
                                    </div>

                                <div class="col-lg-8" style="text-align:left;" >
                                    <div>
                                    <asp:Label runat="server" ID="lblProfil" Text='<%# Item.prenom + " " + Item.nom%>'></asp:Label>
                                        </div>
                                    <div>
                                    <asp:Label ID="lblCourriel" Text='<%# Item.courriel %>' runat="server" Style="text-decoration: none; color: black;"></asp:Label>
                                        </div>
                                </div>

                             

                                    
                               

                               

                            </div>
                        </div>
                         </asp:LinkButton>
                  
                </ItemTemplate>

                <LayoutTemplate>                   
                       
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                
                </LayoutTemplate>

            </asp:ListView>
        </asp:Panel>
    </div>
        
</div>
</asp:Content>
