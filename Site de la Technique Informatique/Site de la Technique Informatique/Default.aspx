<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Default" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Content -->
    <div class="container">

        <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Bienvenue sur le site de la techniques en informatique de gestion du Cégep de Granby
                </h1>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="glyphicon glyphicon-question-sign"></i>Qui sommes-nous?</h4>
                    </div>
                    <div class="panel-body">
                        <p>Vous n'êtes pas certain de vous incrire dans une spécialisation de l'informatique de gestion? Vous vous interrogez si c'est votre vraie vocation? Apprenez tout ce que vous devez savoir de la technique! </p>
                        <a href="full-width.html" class="btn btn-default">En savoir plus...</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="glyphicon glyphicon-info-sign"></i>Nouvelles</h4>
                    </div>
                    <div class="panel-body">
                        <p>Apprenez toutes les nouvelles de la technique</p>
                        <a href="full-width.html" class="btn btn-default">En savoir plus...</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="glyphicon glyphicon-usd"></i>Offres d'emploi</h4>
                    </div>
                    <div class="panel-body">
                        <p>Vous êtes sur le point d'avoir votre diplôme et vous cherchez un travail le plus rapidement que possible? Vous serez gâté(e) par toutes les offres d'emploi que nous vous proposons!</p>
                        <a href="full-width.html" class="btn btn-default">En savoir plus...</a>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.row -->

        <!-- Carousel Section -->
        <div class="row">
            <div id="carousel-example-generic" class="carousel slide col-lg-7" data-ride="carousel" data-interval="10000" style="height: 400px;">
                <!-- Wrapper for slides -->
                <div class="carousel-inner">
                    <asp:ListView ID="lviewAlbumPhoto" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.Photos"
                        SelectMethod="lviewAlbumPhoto_GetData">

                        <ItemTemplate>

                            <div class="item active">
                                <div style="width: 100%; height: 400px; text-align: center; border-left: solid black 1px; border-right: solid black 1px;">
                                    <span style="display: inline-block; height: 100%; vertical-align: middle;"></span>
                                    <img src="../Photos/Jacob.jpg" height="400" width="400" />
                                </div>
                                <div class="carousel-caption"></div>
                            </div>

                            <div class="item">
                                <div style="width: 100%; height: 400px; text-align: center; border-left: solid black 1px; border-right: solid black 1px;">
                                    <span style="display: inline-block; height: 100%; vertical-align: middle;"></span>
                                    <asp:Image ID="imgDansCarousel" runat="server" ImageUrl='<%# ".." + Item.pathPhoto %>' Style="vertical-align: middle;" />
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

            <!-- Information right side -->
            <div class="col-lg-5">
                <h2>Une place dynamique!</h2>
                <h3><a href="QuiSommesNous.aspx">Qui Sommes Nous?</a></h3>
                <h3><a href="marie-TestVerTIC.aspx">marie-TestVerTIC.aspx</a></h3>
            </div>
        </div>
        <!-- /.row -->

        <!-- Features Section -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Une technique spécialisée en programmation</h2>
            </div>
            <div class="col-md-6">
                <p>La programmation exige certaine qualités</p>
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
                <img class="img-responsive" src="Photos/image1.jpg" alt="" />
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
                        <div class="well col-lg-4" style="height: 130px;">
                            <asp:Label runat="server" ID="lblDateEvent" Text='<%# Item.dateDebutEvenement.Day + " " + Convert.ToDateTime(Eval("dateDebutEvenement")).ToString("MMM") + "" + (Item.dateFinEvenement.HasValue == true ? ( ((Eval("dateDebutEvenement.Date") == Eval("dateFinEvenement.Date")) ? (" au " + Eval("dateFinEvenement.Day") + " " + Convert.ToDateTime(Eval("dateFinEvenement")).ToString("MMM")) : "")) : "" ) %>' />
                            <br />
                            <asp:Label runat="server" ID="lblTitreEvent" Style="word-wrap: break-word;"
                                Text='<%# Eval("titreEvenement").ToString().PadLeft(50).Substring(0, 50) +
                                   (Eval("titreEvenement").ToString().Length > 50 ? "..." :  "") %>' />
                            <asp:Label runat="server" ID="lblHeureEvent" Text='<%# ((Item.dateDebutEvenement.TimeOfDay.ToString() != "00:00:00" ) ? ( "\n" + Eval("dateDebutEvenement.TimeOfDay.Hours") + "h" + (Eval("dateDebutEvenement.TimeOfDay.Minutes").ToString() == "0" ? "00" : Eval("dateDebutEvenement.TimeOfDay.Minutes") ) ) : "\r" ) 
                        + "" + ((Item.dateFinEvenement.HasValue == true) && (Item.dateFinEvenement.Value.TimeOfDay.ToString() != "00:00:00" ) ? (" à " + Eval("dateFinEvenement.TimeOfDay.Hours") + "h" + (Eval("dateFinEvenement.TimeOfDay.Minutes").ToString() == "0" ? "00" : Eval("dateFinEvenement.TimeOfDay.Minutes") ) ) : "" ) %>' />
                            <br />
                            <asp:LinkButton runat="server" ID="btnPlusEvents" Text="En savoir plus..."
                                OnClick="btnPlusEvents_Click" CommandArgument='<%# Eval("IDEvenement") %>' /><br />
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
                    <p>Ici vous trouverai une liste de tous les cours de la technique avec leur description</p>
                </div>
                <div class="col-md-4">
                    <a class="btn btn-lg btn-default btn-block" href="#">Liste de cours</a>
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
