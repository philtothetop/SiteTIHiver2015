<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.Inscription" MasterPageFile="~/Site.Master" %>

<asp:Content ID="InscriptionHead" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Css/Inscription.css" />

</asp:Content>
<asp:Content ID="InscriptionContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container">
        <div class="row row-centered">
            <div class="col-lg-4 col-centered">
                <h1>Inscription</h1>
            </div>
        </div>


    </div>


    <asp:ListView ID="lviewFormulaireInscription" runat="server"
        ItemType="Site_de_la_Technique_Informatique.Model.UtilisateurJeu"
        SelectMethod="GetUtilisateurEtudiant"
        UpdateMethod="CreerUtilisateurEtudiant">

        <ItemTemplate>
            <div class="row row-centered">
                <div class="col-lg-4 col-centered">
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Prénom:</label>
                            <asp:TextBox ID="txtPrenom" runat="server" CssClass="form-control" placeholder="Prénom" Text='<%#BindItem.nom %>' />
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Nom:</label>
                            <asp:TextBox ID="txtNom" runat="server" CssClass="form-control" placeholder="Nom" Text='<%#BindItem.nom %>' />
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Date de naissance:</label>
                            <div class="row">
                                <div class="col-xs-2">
                                    <asp:TextBox ID="txtDateNaissanceJour" runat="server" CssClass="form-control" placeholder="JJ" />
                                </div>
                                <div class="col-xs-2">
                                    <asp:TextBox ID="txtDateNaissanceMois" runat="server" CssClass="form-control" placeholder="mm" />
                                </div>
                                <div class="col-xs-3">
                                    <asp:TextBox ID="txtDateNaissanceAnnee" runat="server" CssClass="form-control" placeholder="AAAA" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Courriel:</label>
                            <asp:TextBox ID="txtCourriel" runat="server" CssClass="form-control" placeholder="courriel@exemple.qc.ca" Text='<%#BindItem.courriel %>' />
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Mot de passe:</label>
                            <asp:TextBox ID="txtMotDePasse" runat="server" TextMode="password" CssClass="form-control" Text='<%#BindItem.hashMotDepasse %>' />
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Confirmation du mot de passe:</label>
                            <asp:TextBox ID="txtConfirmationMotDePasse" runat="server" TextMode="password" CssClass="form-control" />
                        </div>

                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:LinkButton ID="lnkConditions" runat="server" Text="Conditions" data-toggle="modal" data-target="#mesConditions" />
                        </div>

                    </div>
                    <asp:LinkButton ID="lnkAnnuler" Text="Annuler" runat="server" CssClass="btn btn-default" />
                    <asp:LinkButton ID="lnkEnvoyer" Text="Envoyer" runat="server" CssClass="btn btn-primary" CommandName="Update" />
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <!-- Modal Termes et conditions-->
    <div class="modal fade" id="mesConditions" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Termes et conditions</h4>
                </div>
                <div class="modal-body">
                    ...
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Fermer</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Accepter</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
