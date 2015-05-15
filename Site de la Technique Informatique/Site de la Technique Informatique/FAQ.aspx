<%--Cette classe permet à qui le souhaite de lire les questions et réponses de la FAQ 
Écrit par Marie-Philippe Gill, Avril 2015
Intrants: MasterPage
Extrants: --%>

<%@ Page Title="Foire aux questions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="Site_de_la_Technique_Informatique.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $('.collapse').collapse()
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Foire aux questions (FAQ)
                    
                </h1>
                </div>
        </div>
        <!-- /.row -->

        <!-- Content Row -->
        <div class="row">
            <div class="col-lg-12">
                <asp:ListView ID="lviewFAQ" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.FAQ"
                    SelectMethod="SelectFAQ">
                    <LayoutTemplate>
                        <div class="panel-group" id="accordion">
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                            </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapse<%# Item.IDFAQ %>" >
                                        <%--<asp:Label ID="lblQuestionFAQ" runat="server" Text='<%# BindItem.texteQuestion %>'></asp:Label>--%>
                                            <asp:Literal ID="lblQuestionFAQ" runat="server" Text='<%# BindItem.texteQuestion %>'></asp:Literal>
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapse<%# Item.IDFAQ %>" class="panel-collapse collapse" role="tabpanel">
                                    <div class="panel-body">
                                        <%--<asp:Label ID="lblReponseFAQ" runat="server" Text='<%# BindItem.texteReponse %>'></asp:Label>--%>
                                        <asp:Literal ID="lblReponseFAQ" runat="server" Text='<%# Server.HtmlDecode(Item.texteReponse) %>'></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
        </div>
        <!-- /.panel-group -->
</asp:Content>
