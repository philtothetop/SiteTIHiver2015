﻿<%@ Page Title="Nouvelles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nouvelles.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Nouvelles" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Header Carousel -->
    <div class="container">
        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Nouvelles
                </h1>
                <ol class="breadcrumb">
                    <li><a href="Default.aspx">Accueil</a>
                    </li>
                    <li class="active">Nouvelles</li>
                </ol>
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
                                    <p><%# Item.texteNouvelle %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>

                <asp:ListView ID="lviewNouvellesEdit" runat="server" Visible="false"
                    ItemType="Site_de_la_Technique_Informatique.Model.Nouvelle"
                    SelectMethod="getNouvelleToEdit">
                    <ItemTemplate>
                        <div>
                            <asp:TextBox runat="server" Text="<%# Item.dateNouvelle.ToLongDateString() %>"></asp:TextBox>
                            <asp:TextBox runat="server" Text="<%# Item.texteNouvelle %>" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <!-- /.row -->
           
        </div>
    </div>
    <!-- /.container -->

</asp:Content>
