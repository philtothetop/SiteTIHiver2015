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

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Les logs</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12" style="background-color: #f5f5f5; text-align:center; border-radius:40px;">
        <asp:ListView ID="lviewLogs" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.LogJeu"
                        SelectMethod="GetLesLogs">

                        <LayoutTemplate>
                            <div style="width:100%;">
                                        <div class="col-lg-1">
                                            <asp:Label ID="lblTitreNoLog" runat="server" Text="No Log" style="font:bold; font-size:large; border-bottom: solid black 2px;"></asp:Label>
                            </div>
                            <div class="col-lg-1">
                                            <asp:Label ID="lblTitreNoCompte" runat="server" Text="No Compte" style="font:bold; font-size:large; border-bottom: solid black 2px;"></asp:Label>
                                            </div>
                            <div class="col-lg-2">
                                            <asp:Label ID="lblTitreTypeCompte" runat="server" Text="Type Compte" style="font:bold; font-size:large; border-bottom: solid black 2px;"></asp:Label>
                                            </div>
                            <div class="col-lg-6">
                                            <asp:Label ID="lblTitreActionLog" runat="server" Text="Action" style="font:bold; font-size:large; border-bottom: solid black 2px;"></asp:Label>
                                </div>

                                <div class="col-lg-2">
                                            <asp:Label ID="lblTitreDate" runat="server" Text="Date" style="font:bold; font-size:large; border-bottom: solid black 2px;"></asp:Label>
                                            </div>
                                </div>
                            <div style="clear:both"></div>

                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </LayoutTemplate>

                        <ItemTemplate>
                            <div class="col-lg-1">
                                            <asp:Label ID="lblNoLog" runat="server" Text='<%# Item.IDLog %>'></asp:Label>
                                            </div>
                             <div class="col-lg-1">
                                            <asp:Label ID="lblNoCompte" runat="server"  Text='<%# GetIdOfAccount(Item.IDLog) %>'></asp:Label>
                                            </div>
                            <div class="col-lg-2">
                                            <asp:Label ID="lblTypeCompte" runat="server" Text='<%# GetTypeOfAccount(Item.IDLog) %>'></asp:Label>
                                            </div>
                            <div class="col-lg-6">
                                            <asp:Label ID="lblActionLog" runat="server" Text='<%# Item.actionLog %>'></asp:Label>
                                </div>

                                <div class="col-lg-2">
                                            <asp:Label ID="lblDate" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}",Item.dateLog) %>'></asp:Label>
                            </div>
                            <div style="clear:both"></div>
                        </ItemTemplate>

            <EmptyDataTemplate>
                <div style="width:100%; text-align:center;">
                                            <asp:Label ID="lblPasDeLog" runat="server" Text="Il n'y a pas de log" style="font:bold; font-size:large"></asp:Label>
                            </div>
            </EmptyDataTemplate>
            
        </asp:ListView>
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


</asp:Content>
