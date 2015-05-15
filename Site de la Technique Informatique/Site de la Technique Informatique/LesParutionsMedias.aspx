<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LesParutionsMedias.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Site_de_la_Technique_Informatique.LesParutionsMedias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Header Carousel -->
    <div class="container" >
        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Les parutions médias
                </h1>
                <ol class="breadcrumb">
                    <li><a href="Default.aspx">Accueil</a>
                    </li>
                    <li class="active">Les Parutions Médias</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->
        <!-- Content Row -->
        <div class="row">
          
            <!-- Content Column -->
            <div class="col-md-12">
                <asp:ListView ID="lviewLesParutionsMedias" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.ParutionMedia"
                        SelectMethod="GetLesParutionsMedias">

                        <LayoutTemplate>
                            <div>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </div>
                        </LayoutTemplate>

                        <ItemTemplate>
                            <div style="clear:both; text-align:left; border-bottom:solid black 1px; margin-bottom:20px;">

                                <div style="float:right; text-align:center;">
                                    <asp:Label ID="lblDateParution" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}",Item.dateParution) %>'></asp:Label>
                                    </div>

                                <div style="clear:both;">
                                <h2><%# Item.titreParution %></h2>
                                    </div>
                                

                                <div style="word-break:break-all; clear:both;">
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Item.descriptionParution %>'></asp:Label>
                                </div>
                                <asp:LinkButton ID="lnkVoirPDF" runat="server" CommandArgument='<%# Item.pathFichierPDF %>' OnClick="lnkPDF_Click">Consulter l'article</asp:LinkButton>
                            </div>
                            
                        </ItemTemplate>

                    <EmptyDataTemplate>
                        <div style="text-align:center;">
                            <asp:Label ID="lblPasDeParution" runat="server" Text="Il n'y a pas de parution média depuis plus d'un an."></asp:Label>
                        </div>
                </EmptyDataTemplate>
            
        </asp:ListView>

                <div style="text-align:center; width:100%;">
            
            <asp:DataPager ID="dataPagerDesParutions" runat="server" PagedControlID="lviewLesParutionsMedias"
                            PageSize="4">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" PreviousPageText="<<" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowLastPageButton="False" ShowPreviousPageButton="False" NextPageText=">>" />
                            </Fields>
                        </asp:DataPager>
                </div>
            </div>
            <!-- /.row -->
           
        </div>
    </div>
    <!-- /.container -->
</asp:Content>
