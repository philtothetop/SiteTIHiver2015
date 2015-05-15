<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Admin_Profil.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_motDePasse" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:HiddenField runat="server" ID="ImgExSrc" />
    <asp:ScriptManagerProxy ID="smProxy" runat="server" />
    <div class="container">
        <div class="col-lg-2"></div>
        <div class="col-lg-6 col-centered">

            <div class="container-fluid">
                <asp:ListView ID="lvModifProfilAdmin" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.Utilisateur"
                    SelectMethod="SelectAdmin"
                    UpdateMethod="UpdateAdmin">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </LayoutTemplate>
                    
                    <ItemTemplate>
                        <div class="row row-centered">
                            <div class="col-lg-9 col-centered">
                                <h1>Modification du profil Admin</h1>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-8">
                                <h4>Changer votre mot de passe</h4>
                            </div>
                        </div>
                        <div class="control-group form-group" id="dvMotDePasse">
                            <div class="controls">
                                <label>Mot de passe actuel:</label>
                                <asp:TextBox ID="txtMotDePasse" runat="server" CssClass="form-control" Text="" TextMode="Password" />
                                <asp:Label ID="lblMotDePasse" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group" id="dvNouveauMotDePasse">
                            <div class="controls">
                                <label>Nouveau mot de passe:</label>
                                <asp:TextBox ID="txtNouveauMotDePasse" runat="server" CssClass="form-control" Text="" TextMode="Password" />
                                <asp:Label ID="lblNouveauMotDePasse" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group" id="dvConfirmationNouveauMotDePasse">
                            <div class="controls">
                                <label>Confirmation du nouveau mot de passe:</label>
                                <asp:TextBox ID="txtConfirmationNouveauMotDePasse" runat="server" CssClass="form-control" Text="" TextMode="Password" />
                                <asp:Label ID="lblConfirmationNouveauMotDePasse" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="row"></div>
                        <div class="col-lg-offset-8 col-lg-8 ">
                            
                            <asp:Button ID="btnSave" runat="server" Text="Sauvegarder" CssClass="btn btn-primary" CommandName="Update" OnClientClick="copieImgData()" />
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
   </asp:Content>
