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
            <div class="col-lg-12" style="background-color: #f5f5f5; border-radius:40px; padding-top:30px; padding-bottom:30px;">

                <asp:ListView ID="lviewTemoignages" runat="server"
                ItemType="Site_de_la_Technique_Informatique.Model.Membre"
                SelectMethod="lviewTemoignages_GetData">

                <EmptyDataTemplate>
                    Aucun témoignages disponibles.
                </EmptyDataTemplate>

                <ItemTemplate>
                    <div class="col-md-12 col-sm-6 col-xs-6 media alert alert-info alert-dismissible" style="float:left; display:inline; padding:10px;">
                        <div class="media-left media-middle" style="float:left;">
                            <asp:Image runat="server" style="float:right;" class="img-responsive customer-img media-object" Height="175" Width="175" ImageUrl='<%# "~/Photos/Profils/" +  Eval("pathPhotoProfil") %>' />
                        </div>
                        <div class="media-body" style="word-wrap:break-word; float:left;">
                            <asp:Label runat="server" style="text-align:center; word-wrap:break-word;" Text='<%# Item.temoignage.Replace("¤", "\r") %>' />
                        </div>
                    </div>
                </ItemTemplate>

                <AlternatingItemTemplate>
                    <div class="col-md-12 col-sm-6 col-xs-6 media alert alert-info alert-dismissible" style="float:right; display:inline; padding:10px;">
                        <div class="media-left media-middle" style="float:right;">
                            <asp:Image runat="server" style="float:right;" class="img-responsive customer-img media-object" Height="175" Width="175" ImageUrl='<%# "~/Photos/Profils/" +  Eval("pathPhotoProfil") %>' />
                        </div>
                        <div class="media-body" style=" float:right;">
                            <div style="word-wrap:break-word;">
                                <asp:Label runat="server" style="text-align:center;" Text='<%# Item.temoignage.Replace("¤", "\r") %>' />
                            </div>
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
