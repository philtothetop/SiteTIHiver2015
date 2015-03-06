<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validation-Inscription.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.Validation_Inscription"  MasterPageFile="~/Admin.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
        <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Header Carousel -->
 </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Validation des inscriptions</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <asp:ListView ID="lviewValidationInscription" runat="server"></asp:ListView>
        </div>
    </div>
</asp:Content>
