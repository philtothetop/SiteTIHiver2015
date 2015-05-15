<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Content -->
    <div class="container">

        <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Bienvenue sur le site de techniques en informatique de gestion du Cégep de Granby
                </h1>
            </div>
                
        </div>
        <!-- /.row -->

        <!-- Carousel Section -->
        <div class="row well">
            
            <div id="carousel-example-generic" class="carousel slide" data-ride="carousel" data-interval="10000" style="height: 400px;">
                <!-- Wrapper for slides -->
                <div class="carousel-inner">

                    <div class="item active">
                        <div style="width: 100%; height: 400px; text-align: center; border-left: solid black 1px; border-right: solid black 1px;">
                            <span style="display: inline-block; height: 100%; vertical-align: middle;"></span>
                            <asp:Image runat="server" ImageUrl='<%# isLocal() ? "~/Upload/Photos/logo/Logo_Informatique.jpg" : "~/../Upload/Photos/logo/Logo_Informatique.jpg"  %>' height="400" width="500" />
                        </div>
                        <div class="carousel-caption"></div>
                    </div>

                    <asp:ListView ID="lviewAlbumPhoto" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.Photos"
                        SelectMethod="lviewAlbumPhoto_GetData">

                        <ItemTemplate>

                            <div class="item">
                                <div style="width: 100%; height: 400px; text-align: center; border-left: solid black 1px; border-right: solid black 1px;">
                                    <span style="display: inline-block; height: 100%; vertical-align: middle;"></span>
                                    <asp:Image ID="imgDansCarousel" runat="server" ImageUrl='<%# isLocal() ? "~/Upload/Photos/" + Item.pathPhoto : "~/../Upload/Photos/" + Item.pathPhoto %>' Style="vertical-align: middle;" />
                                </div>

                                <div class="carousel-caption">
                                </div>
                            </div>

                        </ItemTemplate>

                        <LayoutTemplate>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </LayoutTemplate>

                    </asp:ListView>
                </div>

                <!-- Controls -->
                <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left"></span>
                </a>
                <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right"></span>
                </a>
            </div>

           
        </div>
        <!-- /.row -->

        <!-- Features Section -->
        <div class="row" style="background-color:#eaeaea; padding-bottom:5px;">
            <div class="col-lg-12">
                <h2 class="page-header">Une technique spécialisée en programmation</h2>
            </div>
            <div class="col-md-6">
                <p>La programmation exige certaines qualités</p>
                <ul>
                    <li>Débrouillardise</li>
                    <li>Logique</li>
                    <li>Esprit d’analyse</li>
                    <li>Aptitudes en mathématiques</li>
                    <li>Sens de l’organisation</li>
                    <li>Capacité à travailler en équipe</li>
                    <li>Persévérance</li>
                    <li>Polyvalence</li>
                    <li>Bonne communication</li>
                    <li>Patience</li>
                    <li>Aimer le café</li>
                </ul>
                <p>Cette technique ne concerne en rien la programmation de jeux vidéo, prendre note qu'il faut s'appliquer et travailler fort pour réussir les cours.</p>
            </div>
            <div class="col-md-6">
                <img class="img-responsive" src="Photos/Autres/Accueil.jpg" alt="" />
            </div>
        </div>
        <!-- /.row -->

        <hr />

        <div class="col-lg-12 media">
            <div class="col-lg-4 media-left media-middle">
                <asp:Calendar ID="CalendrierEvents" runat="server" BackColor="#ECEEF0" BorderColor="Black" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px"
                    ToolTip="Événements du mois" OnSelectionChanged="CalendrierEvents_SelectionChanged" Caption="Calendrier" OnVisibleMonthChanged="CalendrierEvents_VisibleMonthChanged">
                    <DayHeaderStyle Font-Bold="True" Font-Size="10pt" HorizontalAlign="Right" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#CCCCCC" ForeColor="White" BorderColor="#000000" BorderWidth="1px" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="1px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BorderColor="#CCCCCC" BorderWidth="1px" ForeColor="Red" />
                </asp:Calendar>
            </div>

            <div class="col-lg-8 media-body">
                <h2 class="media-heading">Événements du mois</h2>
                <asp:ListView runat="server" ID="lviewEvents"
                    ItemType="Site_de_la_Technique_Informatique.Model.Evenement"
                    SelectMethod="lviewEvents_GetData"
                    GroupItemCount="3">

                    <EmptyDataTemplate>
                        <p>Aucun événement particulier ce mois-ci.</p>
                    </EmptyDataTemplate>

                    <ItemTemplate>
                        <div class="well col-lg-4" style="min-height: 150px;">
                            <asp:Label runat="server" ID="lblDateEvent" Text='<%# Item.dateDebutEvenement.Day + " " + Convert.ToDateTime(Eval("dateDebutEvenement")).ToString("MMM") + "" + (Item.dateFinEvenement.HasValue == true ? ( ((Eval("dateDebutEvenement.Date") == Eval("dateFinEvenement.Date")) ? (" au " + Eval("dateFinEvenement.Day") + " " + Convert.ToDateTime(Eval("dateFinEvenement")).ToString("MMM")) : "")) : "" ) %>' />
                            <br />
                            <asp:Label runat="server" ID="lblTitreEvent" Style="word-wrap: break-word;"
                                Text='<%# Eval("titreEvenement").ToString().PadLeft(50).Substring(0, 50) +
                                   (Eval("titreEvenement").ToString().Length > 50 ? "..." :  "") %>' />
                            <asp:Label runat="server" ID="lblHeureEvent" Text='<%# ((Item.dateDebutEvenement.TimeOfDay.ToString() != "00:00:00" ) ? ( "\n" + Eval("dateDebutEvenement.TimeOfDay.Hours") + "h" + (Eval("dateDebutEvenement.TimeOfDay.Minutes").ToString() == "0" ? "00" : Eval("dateDebutEvenement.TimeOfDay.Minutes") ) ) : "\r" ) 
                            + "" + ((Item.dateFinEvenement.HasValue == true) && (Item.dateFinEvenement.Value.TimeOfDay.ToString() != "00:00:00" ) ? (" à " + Eval("dateFinEvenement.TimeOfDay.Hours") + "h" + (Eval("dateFinEvenement.TimeOfDay.Minutes").ToString() == "0" ? "00" : Eval("dateFinEvenement.TimeOfDay.Minutes") ) ) : "" ) %>' />
                            <br />
                            <asp:Label runat="server" ID="Label2" Text='<%# Eval("descriptionEvenement").ToString().PadLeft(50).Substring(0, 50) +
                                   (Eval("descriptionEvenement").ToString().Length > 50 ? "..." :  "") %>' />
                            <br />
                        </div>
                    </ItemTemplate>

                    <LayoutTemplate>
                        <asp:PlaceHolder ID="groupPlaceHolder" runat="server" />
                    </LayoutTemplate>

                    <GroupTemplate>
                        <div class="row">
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </div>
                    </GroupTemplate>

                </asp:ListView>
                <div style="text-align: center; width: 100%;">
                    <asp:DataPager ID="dataPagerEvents" runat="server" PagedControlID="lviewEvents"
                        PageSize="3">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" PreviousPageText="<<" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="False" ShowPreviousPageButton="False" NextPageText=">>" />
                        </Fields>
                    </asp:DataPager>
                </div>

            </div>
        </div>

        <hr />

        <!-- Call to Action Section -->
        <div class="well col-lg-12" style="margin-top: 30px;">
            <div class="row">
                <div class="col-md-8">
                    <p>Pour une liste de tous les cours avec leur description détaillée.</p>
                </div>
                <div class="col-md-4">
                    <a class="btn btn-lg btn-default btn-block" onclick="window.open('Upload/Cours/grilles_informatique.pdf', '_blank', 'fullscreen=yes'); return false;" href="#">Liste des cours</a>
                </div>
            </div>
        </div>

        <hr />
    </div>
    <!-- /.container -->



    <!-- Script to Activate the Carousel -->
    <script>
        $('.carousel').carousel({
            interval: 5000 //changes the speed
        })
    </script>

</asp:Content>
