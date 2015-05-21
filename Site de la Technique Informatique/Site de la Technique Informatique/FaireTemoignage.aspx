<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FaireTemoignage.aspx.cs" Inherits="Site_de_la_Technique_Informatique.FaireTemoignage" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Header Carousel -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Votre témoignage</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12" style="background-color: #f5f5f5; text-align:center; border-radius:40px; padding-bottom:30px; padding-top:5px;">

                <div id="divSuccesEnvoiTemoignage" runat="server" visible="false" style="text-align:center; color:white; background-color:green; width:80%; margin-left:10%;">
                     <asp:Label ID="lblSuccesTemoignage" runat="server" Text="Votre témoignage a été sauvegardé avec succes!"></asp:Label>

                </div>

        <div id="divErreurEnvoiTemoignage" runat="server" visible="false" style="text-align:center; clear:both; color:white; background-color:red; width:80%; margin-left:10%">
                    <asp:Label ID="lblErreurTemoignage" runat="server" Text=""></asp:Label>
                </div>
                <div style="text-align:center;">
                    <b>*Votre témoignage doit comporter un maximum de 1000 caractères et devra être validé par un enseignant si vous êtes un étudiant.</b>
                </div>

                <div style="clear:both; text-align:center;">
                    <br />   
                    <asp:TextBox ID="txtbLeTemoignageDuConnecte" runat="server" TextMode="MultiLine" style="min-width:80%; max-width:80%; min-height:200px; max-height:400px;"></asp:TextBox>
                <br />
                    </div>
                 <asp:Button ID="btnFaireUnTemoignage" runat="server" Text="Envoyer mon témoignage" OnClick="EnvoyerTemoignage_Click" CssClass="btn btn-primary" />
            </div>
        </div>

    </div>
</asp:Content>

