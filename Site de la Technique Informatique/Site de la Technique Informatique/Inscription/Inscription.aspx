<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.Inscription" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Css/Inscription.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-iframe" style="height:100%;margin: 0;">
        <iframe class="iframe-body" src="Inscription-formulaire.aspx"  frameBorder="0" />
    </div>
</asp:Content>
