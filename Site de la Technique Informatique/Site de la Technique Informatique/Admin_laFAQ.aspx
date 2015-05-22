<%--Cette classe permet aux administrateurs d'ajouter, supprimer ou modifier des questions de la FAQ  
Écrit par Marie-Philippe Gill, Avril 2015
Intrants: MasterPage
Extrants: --%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Admin_laFAQ.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_laFAQ" ValidateRequest="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
<script type="text/javascript" src="tinymce/js/tinymce/tinymce.min.js"></script>
<script type="text/javascript">
    tinymce.init({
        selector: "textarea",
        encoding: "xml",
        plugins: ["image link media advlist autolink charmap emoticons lists charmap preview hr anchor",
                "pagebreak code nonbreaking table contextmenu directionality paste textcolor searchreplace"],
        toolbar1: " undo redo | bold italic underline | alignleft aligncenter alignright alignjustify | fontselect | fontsizeselect | forecolor backcolor | charmap emoticons | bullist numlist outdent indent | link image media",
        language: 'fr_FR',
    });
</script>


    <div class="row">
        <div class="col-lg-8">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <h1 class="page-header">FAQ</h1>
        </div>
    </div>
    <%-- Ajouter une question --%>
    <div class="row">
        <div class="col-lg-8">
            <h3>Ajouter une question</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-8">
            <asp:Label ID="lblAjouterQuestion" runat="server" Text="Question:"></asp:Label>
            <asp:TextBox ID="txtAjouterQuestion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-8">
            <asp:Label ID="lblAjouterReponse" runat="server" Text="Réponse:"></asp:Label>
            <asp:TextBox ID="txtAjouterReponse" runat="server" CssClass="form-control noresize" TextMode="MultiLine" Height="180px"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-lg-offset-6 col-lg-1">
        </div>
        <div class="col-lg-2">
            <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" CssClass="btn btn-primary" OnClick="btnAjouter_Click" />
        </div>
    </div>

    <%-- Modifier une image --%>
    <div class="row">
        <div class="col-lg-8">
            <h3>Modifier une question</h3>
            <asp:DropDownList ID="ddlQuestionsFAQ" runat="server" CssClass="form-control" SelectMethod="getQuestionsFAQ" DataTextField="texteQuestion" DataValueField="IDFAQ" AutoPostBack="true" OnSelectedIndexChanged="ddlQuestionsFAQ_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
    <asp:ListView ID="lviewModifFAQ" runat="server"
        SelectMethod="getQuestionAModifier"
        ItemType="Site_de_la_Technique_Informatique.Model.FAQ">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>

        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <div class="col-lg-8">
                    <asp:Label ID="lblQuestion" runat="server" Text="Question:"></asp:Label>
                    <asp:TextBox ID="txtQuestion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-8">
                    <asp:Label ID="lblReponse" runat="server" Text="Réponse:"></asp:Label>
                    <asp:TextBox ID="txtReponse" runat="server" CssClass="form-control noresize" TextMode="MultiLine" Height="180px"></asp:TextBox>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <br />
    <div class="row">
        <div class="col-lg-offset-6 col-lg-1">
            <asp:Button ID="btnModifier" runat="server" Text="Modifier" OnClick="btnModifier_Click" CssClass="btn btn-primary" />
        </div>
        <div class="col-lg-2">
            <asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" OnClick="btnSupprimer_Click" CssClass="btn btn-danger" />
        </div>
    </div>

   

</asp:Content>
