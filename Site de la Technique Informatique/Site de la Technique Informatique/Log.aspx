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
            <div class="col-lg-12" style="background-color: #f5f5f5;">
        <asp:ListView ID="lviewLogs" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.LogJeu"
                        SelectMethod="GetLesLogs">

                        <LayoutTemplate>
                            <div>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </div>
                        </LayoutTemplate>

                        <ItemTemplate>
                            <div>
                                <asp:Label ID="lblActionLog" runat="server" Text='<%# Eval("actionLog") %>'></asp:Label>
                            </div>
                        </ItemTemplate>

            <EmptyDataTemplate>
                <div>
                                <asp:Label ID="lblActionLogEmpty" runat="server" Text="Il y a aucun log"></asp:Label>
                            </div>
            </EmptyDataTemplate>
            
        </asp:ListView>
            </div>
        </div>

    </div>


</asp:Content>
