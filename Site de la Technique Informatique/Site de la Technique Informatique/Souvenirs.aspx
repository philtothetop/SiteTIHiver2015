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
                       >

                        <LayoutTemplate>
                            <div style="clear:both;">
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </div>
                        </LayoutTemplate>

                   

                        <ItemTemplate>
                            
                                <div style="border:Solid; border-color:black; border-width:1px; border-radius:5px;background-color:#eaeaea; margin-top:5px; padding-top:20px;">

                            <div class="col-md-6 img-portfolio">
                                <div>
                                    <div style="text-align:center;">
                                        <asp:Image ID="imgDuSouvenir" runat="server" ImageUrl='<%# (isLocal() ? "~/Upload/Photos/Souvenir/" : "~/../Upload/Photos/Souvenir/" ) + Item.typePhoto + "/" + Item.pathPhoto %>' Height='<%# ImageToResize(Item.typePhoto + "/" + Item.pathPhoto, true) %>' Width='<%# ImageToResize(Item.typePhoto + "/" + Item.pathPhoto, false) %>' style="max-width:500px; max-height:500px;" />

                                    </div>                             
                                </div>                           
                               
                            </div>

                             <div class="col-md-6 img-portfolio">

                                       <div style="text-align:center;"> 
                                         <asp:Label ID="lblDescriptionDuSouvenir" runat="server" Text='<%# SavoirSiDescriptionEstVide(Item.descriptionPhoto) %>'></asp:Label>

                                     </div> 
                                   </div>

                            <div style="clear:both;">

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
                                PageSize="5">
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
