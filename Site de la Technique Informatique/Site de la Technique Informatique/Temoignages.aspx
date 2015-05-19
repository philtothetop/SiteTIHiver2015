<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Temoignages.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Temoignages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Les témoignages</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12" style="padding-right:40px;">

                <asp:ListView ID="lviewTemoignages" runat="server"
                ItemType="Site_de_la_Technique_Informatique.Model.Membre"
                SelectMethod="lviewTemoignages_GetData">

                <EmptyDataTemplate>
                    Aucun témoignages disponibles.
                </EmptyDataTemplate>

                <ItemTemplate>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="display:inline; padding:10px; background-color: #eaeaea; text-align:center; border-radius:10px; padding-bottom:30px; margin:10px;">
                            <div style="clear:both; text-align:center; border-bottom:solid 2px black; margin-bottom:20px;">
                                <asp:Label runat="server" Text='<%# Item.prenom + " "  +Item.nom %>' style="font-size:x-large;" />
                            </div>
                            <div class="col-md-4">
                                <asp:Image runat="server" style="float:left;" class="img-responsive customer-img media-object" Height="125" Width="125" ImageUrl='<%#   isLocal() ? "~/../Upload/Photos/Profils/" + Item.pathPhotoProfil : "~/Upload/Photos/Profils/" +  Item.pathPhotoProfil %>' />
                            </div>
                            <div class="col-md-8">
                                <div style="word-break:break-all; float:right;">
                                    <asp:Label runat="server" style="float:right;" Text='<%# Item.temoignage.Replace("¤", "\r") %>' />
                                </div>
                            </div>
                    </div>
                </ItemTemplate>

                <AlternatingItemTemplate>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="display:inline; padding:10px; background-color: #eaeaea; text-align:center; border-radius:10px; padding-bottom:30px; margin:10px;">
                        <div style="clear:both; text-align:center; border-bottom:solid 2px black; margin-bottom:20px;">
                            <asp:Label runat="server" Text='<%# Item.prenom + " "  +Item.nom %>' style="font-size:x-large;" />
                        </div>
                        <div class="col-md-8">
                            <div style="word-break:break-all;">
                                <asp:Label runat="server" style="float:left" Text='<%# Item.temoignage.Replace("¤", "\r") %>' />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:Image runat="server" style="float:right;" class="img-responsive customer-img media-object" Height="125" Width="125" ImageUrl='<%# (isLocal() ? "~/Upload/" : "~/../Upload/") + "Photos/Profils/" +  Eval("pathPhotoProfil") %>' />
                        </div>
                        
                    </div>
                </AlternatingItemTemplate>

                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>

            </asp:ListView>

            </div>
        </div>

    </div>


</asp:Content>
