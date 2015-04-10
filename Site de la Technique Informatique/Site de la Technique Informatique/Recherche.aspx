<%@ Page Title="Recherche de membres" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recherche.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Recherche" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Recherche
                   
                </h1>
                <ol class="breadcrumb">
                    <li><a href="Default.aspx">Accueil</a>
                    </li>
                    <li class="active">Recherche</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->

        <!-- Content Row -->
        <div class="row">
            <div class="col-lg-12">

                <div class="well">

                    <div>
                        <div>
                            <asp:TextBox runat="server" ID="txtNomMembre"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Button runat="server" ID="btnRecherche" class="btn btn-default" Text="Rechercher" OnClick="btnRecherche_Click"></asp:Button>
                            
                        </div>
                    </div>


                    <div style="padding-top: 5px;">
                        <asp:RadioButton ID="rdbEtudiant" Text="Étudiant" runat="server" GroupName="rdbChoix" Checked="true" />
                        <asp:RadioButton ID="rdbProfesseur" Text="Professeur" runat="server" GroupName="rdbChoix" />
                    </div>

                </div>
                </div>
                <br />
            </div>

            <br />
        
            <asp:Panel ID="panelResultats" runat="server" Visible="false">

                <div class="col-lg-12">
                <asp:ListView runat="server"
                    ID="lviewRecherche"
                    ItemType="Site_de_la_Technique_Informatique.Model.Membre"
                    SelectMethod="lviewRecherche_GetData"
                    GroupItemCount="2">


                    <GroupTemplate>
                        <div style="clear:both;">
                         <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </div>
                    </GroupTemplate>

                    <ItemTemplate>
                       
                        <div class="col-lg-6" style="float:left;">
                        <asp:LinkButton ID="lnkMembre" CssClass="couleurGris" Text="" runat="server" BorderStyle="Solid" BorderColor="black" BorderWidth="1" Style="border-radius: 5px; text-align:center; width:100%;">
                          
                                    <div class="col-lg-2" style="text-align: left;">
                                        <asp:Image ID="photoProfil" runat="server" Width="75px" Height="75px" ImageUrl='<%# Item.pathPhotoProfil %>'></asp:Image>
                                    </div>

                                    <div class="col-lg-10" style="text-align: left; color: black;">
                                        <div>
                                            <asp:Label runat="server" ID="lblProfil" Text='<%# Item.prenom + " " + Item.nom%>'></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblCourriel" Text='<%# Item.courriel %>' runat="server" Style="text-decoration: none; color: black;"></asp:Label>
                                        </div>
                                    </div>
                        </asp:LinkButton>
                      </div>
                    </ItemTemplate>

                    <LayoutTemplate>

                        <asp:PlaceHolder ID="groupPlaceHolder" runat="server" />

                    </LayoutTemplate>

                   

                    <EmptyDataTemplate>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="col-lg-3">
                                    <asp:Label ID="lblVide" runat="server" Font-Bold="true" Text="Aucun utilisateur trouvé!"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </EmptyDataTemplate>

                </asp:ListView>
                </div>
                 <div style="text-align:center; width:100%;">
            <asp:DataPager ID="dataPagerRecherche" runat="server" PagedControlID="lviewRecherche"
                            PageSize="10">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" PreviousPageText="<<" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowLastPageButton="False" ShowPreviousPageButton="False" NextPageText=">>" />
                            </Fields>
                        </asp:DataPager>
                </div>

            </asp:Panel>
        

    </div>
</asp:Content>
