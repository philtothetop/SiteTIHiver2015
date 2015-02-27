<%@ Page Title="Modification de votre profil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modifProfilEtudiants.aspx.cs" Inherits="Site_de_la_Technique_Informatique.modifProfilEtudiants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-12">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <div class="container-fluid">
            <asp:ListView ID="lvModifProfilEtudiants" runat="server"
                ItemType="Site_de_la_Technique_Informatique.Model.Etudiant"
                SelectMethod="SelectEtudiant"
                UpdateMethod="UpdateEtudiant">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="row">
                        <div class="col-lg-2">
                            <asp:Label ID="lblPrenom" runat="server" Text="Prénom:"></asp:Label>
                        </div>
                        <div class="col-lg-2">
                            <asp:TextBox ID="txtPrenom" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2">
                            <asp:Label ID="lblNom" runat="server" Text="Nom:"></asp:Label>
                        </div>
                        <div class="col-lg-2">
                            <asp:TextBox ID="txtNom" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2">
                            <asp:Label ID="lblCourriel" runat="server" Text="Courriel:"></asp:Label>
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtCourriel" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2">
                            <asp:Label ID="lblDateNaissance" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="col-lg-2">

                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
