﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Admin_laFAQ.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_laFAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="col-lg-8">
            <div class="row">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <h1>Gérer la FAQ</h1>
                <p>Sur cette page, vous pouvez modifier, ajouter ou supprimer des questions de la foire aux questions (FAQ).</p>

            </div>
            <div class="row">
                <h3>Ajouter une question</h3>
            </div>
            <div class="row">
                <asp:Label ID="lblAjouterQuestion" runat="server" Text="Question:"></asp:Label>
                <asp:TextBox ID="txtAjouterQuestion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="lblAjouterReponse" runat="server" Text="Réponse:"></asp:Label>
                <asp:TextBox ID="txtAjouterReponse" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <br />
            <div class="row">
                <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" CssClass="btn btn-success pull-right" OnClick="btnAjouter_Click" />
            </div>
            <div class="row">
                <h3>Modifier une question</h3>
                <asp:DropDownList ID="ddlQuestionsFAQ" runat="server" CssClass="form-control" SelectMethod="getQuestionsFAQ" DataTextField="texteQuestion" DataValueField="IDFAQ" AutoPostBack="true" OnSelectedIndexChanged="ddlQuestionsFAQ_SelectedIndexChanged"> 

                     </asp:DropDownList>
            </div>
            <asp:ListView ID="lviewModifFAQ" runat="server"
                SelectMethod="getQuestionAModifier"
                ItemType="Site_de_la_Technique_Informatique.Model.FAQ">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="row">
                        <asp:Label ID="lblQuestion" runat="server" Text="Question:"></asp:Label>
                        <asp:TextBox ID="txtQuestion" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:Label ID="lblReponse" runat="server" Text="Réponse:"></asp:Label>
                        <asp:TextBox ID="txtReponse" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <br />
            <asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" OnClick="btnSupprimer_Click" CssClass="btn btn-danger pull-right" /><div>&nbsp;</div>
            <asp:Button ID="btnModifier" runat="server" Text="Modifier" OnClick="btnModifier_Click" CssClass="btn btn-primary pull-right" />
            
        </div>
    </div>
</asp:Content>
