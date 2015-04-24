<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Souvenirs.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Souvenirs" MaintainScrollPositionOnPostback="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Header Carousel -->
    <div class="container" >
        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Souvenirs
                </h1>
                <ol class="breadcrumb">
                    <li><a href="Default.aspx">Accueil</a>
                    </li>
                    <li class="active">Souvenirs</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->

        <!-- Content Row -->
        <div class="row">

            <asp:DropDownList ID="ddlTypeDeSouvenir" runat="server" OnSelectedIndexChanged="ddlTypeDeSouvenir_IndexChange" AutoPostBack="true">
        </asp:DropDownList>
        <br />
        <br />
           
            <asp:ListView ID="lviewSouvenirs" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.Photos"
                        SelectMethod="GetLesPhotos"                
                        GroupItemCount="2">

                        <LayoutTemplate>
                            <div style="clear:both;">
                                <asp:PlaceHolder runat="server" ID="groupPlaceholder" />
                            </div>
                        </LayoutTemplate>

                        <GroupTemplate>
                            <div style=" clear:both;">
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </div>
                        </GroupTemplate>

                        <ItemTemplate>
                            <div class="col-md-6 img-portfolio">
                                <div>
                                    <asp:Image ID="imgDuSouvenir" runat="server" ImageUrl='<%# "~/Photos/Souvenir/" + Item.typePhoto + "/" + Item.pathPhoto %>' style="width:400px;" />

                                     <div> <asp:Label ID="lblDescriptionDuSouvenir" runat="server" Text='<%# SavoirSiDescriptionEstVide(Item.descriptionPhoto) %>'></asp:Label></div> 

                                </div>                           
                               
                            </div>
                        </ItemTemplate>

                        <EmptyDataTemplate>
                             <div class="col-md-6 img-portfolio">
                                <asp:Label ID="lblPasDeSouvenirs" runat="server" Text="Il n'y a pas de souvenir pour le type recherché"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
            
            </asp:ListView>

            <div style="text-align:center;  clear:both;">
            
                <asp:DataPager ID="dataPagerDesSouvenirs" runat="server" PagedControlID="lviewSouvenirs"
                                PageSize="10">
                                <Fields>
                                    <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" PreviousPageText="<<" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ShowLastPageButton="False" ShowPreviousPageButton="False" NextPageText=">>" />
                                </Fields>
                            </asp:DataPager>
                    </div>
        </div>
    </div>
    <!-- /.container -->


</asp:Content>
