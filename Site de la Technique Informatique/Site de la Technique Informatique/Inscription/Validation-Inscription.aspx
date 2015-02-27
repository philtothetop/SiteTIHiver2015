<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validation-Inscription.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.Validation_Inscription" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Header Carousel -->
    <div class="container">
        <style type="text/css">
            .EvenRowColor {
                background-color: #d9d9d9;
            }

            .OddRowColor {
                background-color: white;
            }

            .vcenter {
                display: inline-block;
                vertical-align: middle;
                float: none;
            }

            .img-thumbnail {
                height: 50px;
                width: 50px;
            }

            .top-list {
                height: 50px;
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Validation des inscriptions étudiants</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <asp:UpdatePanel ID="upListValidation" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <asp:ListView ID="lviewValidationInscription" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.Etudiant"
                        SelectMethod="GetUtilisateurEtudiantList"
                        UpdateMethod="CreerUtilisateurEtudiantList">
                        <LayoutTemplate>
                            <div class="col-lg-12 top-list">
                                <asp:CheckBox ID="chSelectionnerTous" runat="server" CssClass="vcenter chk" OnCheckedChanged="chSelectionnerTous_CheckedChanged" AutoPostBack="true" />
                                <span class="col-md-1 vcenter">Photo</span>
                                <span class="col-md-3 vcenter">Prénom Nom</span>
                                <span class="col-md-3 vcenter">Courriel</span>
                                <span class="col-md-2 vcenter">Date inscription</span>

                                <asp:LinkButton ID="lnkAccepterTousHaut" Text="Accepter tous" runat="server" CssClass="btn btn-primary" OnClick="lnkAccepterTousHaut_Click" />&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkRefuserTousHaut" Text="Refuser tous" runat="server" CssClass="btn btn-warning" OnClick="lnkRefuserTousHaut_Click" />
                            </div>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            <div class="col-lg-12 top-list">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                        <span class="col-md-1 vcenter"></span>
                                <span class="col-md-3 vcenter"></span>
                                <span class="col-md-3 vcenter"></span>
                                <span class="col-md-2 vcenter"></span>

                                <asp:LinkButton ID="LinkButton1" Text="Accepter tous" runat="server" CssClass="btn btn-primary" />&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton2" Text="Refuser tous" runat="server" CssClass="btn btn-warning" />
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class='<%#Convert.ToBoolean(Container.DisplayIndex % 2) ? "OddRowColor col-lg-12" : "EvenRowColor col-lg-12" %>'>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("IDEtudiant") %>' Visible="false" />
                                <asp:CheckBox ID="chSelectionner" runat="server" CssClass="vcenter chk" />
                                <span class="col-md-1 vcenter">

                                    <asp:Image ID="imgPhotoProfil" runat="server" ImageUrl='<%#"../Photos/"+Eval("pathPhotoProfil")%>' CssClass="img-thumbnail" /></span>
                                <asp:Label ID="lblPrenom" runat="server" Text='<%#Eval("prenom")+" "+Eval("nom") %>' CssClass="col-md-3 vcenter" />
                                <asp:Label ID="lvlCourriel" runat="server" Text='<%#Eval("courriel") %>' CssClass="col-md-3 vcenter" />
                                <asp:Label ID="lblDateInscription" runat="server" Text='<%#Eval("dateInscription") %>' CssClass="col-md-2 vcenter" />
                                &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkAccepter" Text="Accepter" runat="server" CssClass="btn" OnClick="lnkAccepterTousHaut_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkRefuser" Text="Refuser" runat="server" CssClass="btn" OnClick="lnkRefuserTousHaut_Click" />
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
