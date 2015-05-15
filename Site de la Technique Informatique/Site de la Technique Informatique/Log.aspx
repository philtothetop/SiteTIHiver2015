<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Log.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Log" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Header Carousel -->
    <div class="container">

    <!-- CSS -->
    <link href="Css/Log.css" rel="stylesheet" />


        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Les logs</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12" style="background-color: #f5f5f5; text-align:center; border-radius:40px; padding-bottom:30px;">
        <asp:ListView ID="lviewLogs" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.Log"
                        SelectMethod="GetLesLogs">

                        <LayoutTemplate>
                            <div style="width:100%; margin-bottom:4px;">
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblTitreNoLog" runat="server" Text="No Log" style="font:bold; font-size:large;"></asp:Label>
                                            </div>
                            <div class="col-lg-2">
                                            <asp:Label ID="lblTitreNoCompte" runat="server" Text="No Compte" style="font:bold; font-size:large;"></asp:Label>
                                            </div>
                            <div class="col-lg-6">
                                            <asp:Label ID="lblTitreActionLog" runat="server" Text="Action" style="font:bold; font-size:large;"></asp:Label>
                                            </div>
                            <div class="col-lg-2">
                                            <asp:LinkButton ID="lnkTitreDate" runat="server" CssClass="lnkDate" Text="Date" style="font:bold; font-size:large;" CommandName="Sort" CommandArgument="dateLog"></asp:LinkButton>
                                            </div>
                                </div>
                            <div style="clear:both; height:15px;"></div>
                            
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </LayoutTemplate>

                        <ItemTemplate>
                            <div class='<%# GetCSSForTypeLog(Item.typeLog) %>' style="border-top:thin black solid; border-bottom:thin black solid">
                            <div class="col-lg-2">
                                            <asp:Label ID="lblNoLog" runat="server" Text='<%# Item.IDLog %>'></asp:Label>
                                            </div>
                             <div class="col-lg-2">
                                            <asp:LinkButton ID="lnkNoCompte" runat="server" Enabled='<%# SavoirSiLienEnable(Item) %>' CssClass='<%# SavoirCSSPourLien(Item) %>' OnClick="lnkNoCompte_Click" CommandArgument='<%# LeIdDuCompte(Item) %>'>
                                                <asp:Label ID="lblNoCompte" runat="server"  Text='<%# LeIdDuCompte(Item) %>'></asp:Label>
                                            </asp:LinkButton>
                                            
                                            </div>
                            <div class="col-lg-6" style="border-right: thin solid black; border-left: thin solid black; min-height:40px;">
                                            <asp:Label ID="lblActionLog" runat="server" Text='<%# Item.actionLog %>'></asp:Label>
                                </div>

                                <div class="col-lg-2">
                                            <asp:Label ID="lblDate" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}",Item.dateLog) + "<br/>" + String.Format("{0:H:mm}",Item.dateLog)  %>'></asp:Label>
                                            </div>
                            <div style="clear:both;"></div>
                                </div>
                        </ItemTemplate>

            <EmptyDataTemplate>
                <br />
                <div style="width:100%; text-align:center;">
                                            <asp:Label ID="lblPasDeLog" runat="server" Text="Il n'y a pas de log" style="font:bold; font-size:large"></asp:Label>
                <br />
                    <br />                            
                </div>
                </EmptyDataTemplate>
            
        </asp:ListView>

                <asp:Button ID="btnVoirToutLesLogs" runat="server" Text="Tous" OnClick="ChercherUnTypeDeLog" CommandArgument="9000" style="width:14%; margin-left:1%; margin-right:1%;" CssClass="btn btn-default"  />
                            <asp:Button ID="btnVoirQueLogNormal" runat="server" Text="Logs normaux" OnClick="ChercherUnTypeDeLog" CommandArgument="0" style="width:14%; margin-left:1%; margin-right:1%;" CssClass="btn btn-default"  />
                            <asp:Button ID="btnVoirQueLogErreur" runat="server" Text="Logs erreurs" OnClick="ChercherUnTypeDeLog" CommandArgument="1" style="width:14%; margin-left:1%; margin-right:1%;" CssClass="btn btnErreur" />
                            <asp:Button ID="btnVoirQueLogWarning" runat="server" Text="Logs warnings" OnClick="ChercherUnTypeDeLog" CommandArgument="2" style="width:14%; margin-left:1%; margin-right:1%;" CssClass="btn btnWarning" />
                            <asp:Button ID="btnVoirQueLogInscription" runat="server" Text="Logs inscriptions" OnClick="ChercherUnTypeDeLog" CommandArgument="3" style="width:14%; margin-left:1%; margin-right:1%;" CssClass="btn btnInscription" />
                            <asp:Button ID="btnVoirQueLogBanni" runat="server" Text="Logs bannissement" OnClick="ChercherUnTypeDeLog" CommandArgument="4" style="width:14%; margin-left:1%; margin-right:1%;" CssClass="btn btnBanissement"/>
            </div>

            <div style="text-align:center; width:100%;">
            <asp:DataPager ID="dataPagerDesLogs" runat="server" PagedControlID="lviewLogs"
                            PageSize="20">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" PreviousPageText="<<" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowLastPageButton="False" ShowPreviousPageButton="False" NextPageText=">>" />
                            </Fields>
                        </asp:DataPager>
                </div>
        </div>

    </div>
    <asp:HiddenField ID="hfieldTrierType" runat="server" />
</asp:Content>




