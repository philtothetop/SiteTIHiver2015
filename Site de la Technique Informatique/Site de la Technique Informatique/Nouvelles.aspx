<%@ Page Title="Nouvelles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nouvelles.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Nouvelles" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Header Carousel -->
    <div class="container" >
        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Nouvelles
                </h1>
              
            </div>
        </div>
        <!-- /.row -->
        <!-- Content Row -->
        <div class="row">
          
            <!-- Content Column -->
            <div class="col-md-9">
                <asp:ListView ID="lviewNouvelles" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.Nouvelle"
                    SelectMethod="getNouvelles">
                    <LayoutTemplate>
                       <div class="panel-group" id="accordion">
                           <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                       </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapse<%# Item.IDNouvelle %>"><%# Item.titreNouvelle %></a>
                                </h4>
                            </div>
                            <div id="collapse<%# Item.IDNouvelle %>" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p><%# Item.dateNouvelle.ToLongDateString() %></p>
                                    <asp:Literal runat="server" Text="<%# Server.HtmlDecode(Item.texteNouvelle) %>"></asp:Literal>
                                </div>
                            </div>
                        </div>                        
                    </ItemTemplate>
                </asp:ListView>              
            </div>
            <!-- /.row -->
           
        </div>
    </div>
    <!-- /.container -->

</asp:Content>
