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
                            <div style="clear:both; width:100%;">
                                <asp:PlaceHolder runat="server" ID="groupPlaceholder" />
                            </div>
                        </LayoutTemplate>

                        <GroupTemplate>
                            <div style="width:100%; clear:both;">
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </div>
                        </GroupTemplate>

                        <ItemTemplate>
                            <div style="float:left;width:50%;">
                                <div style="text-align:center;max-height:500px; min-height:500px">
                                    <asp:Image ID="imgDuSouvenir" runat="server" ImageUrl='<%# "~/Photos/Souvenir/" + Item.typePhoto + "/" + Item.pathPhoto %>' style="max-width:100%;" />
                                </div>

                                <div style="clear:both; min-height:100px; border:1px solid black;">
                                    <asp:Label ID="lblDescriptionDuSouvenir" runat="server" Text='<%# SavoirSiDescriptionEstVide(Item.descriptionPhoto) %>'></asp:Label>
                                </div>
                            </div>
                        </ItemTemplate>

                        <EmptyDataTemplate>
                            <div style="width:100%;">
                                <asp:Label ID="lblPasDeSouvenirs" runat="server" Text="Il n'y a pas de souvenir pour le type recherché"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
            
            </asp:ListView>

            <div style="text-align:center; width:100%; clear:both;">
            
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
