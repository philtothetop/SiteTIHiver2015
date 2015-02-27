﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AjoutOffreEmploi.aspx.cs" Inherits="Site_de_la_Technique_Informatique.AjoutOffreEmploi" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <h1>Ajout d'une offre d'emploi</h1>
        </div>
        <div class="row row-centered">
            <div class="col-lg-5 col-centered">
                <div class="control-group form-group">
                    <div class="controls">
                        <asp:Label ID="lblErreur" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                        <br />
                        <br />
                        <label>*Poste offert:</label>
                        <asp:TextBox ID="txtTitreOffre" runat="server" CssClass="form-control" placeholder="Poste" name="fname" MaxLength="80" Width="600" />
                        <asp:Label ID="lblTitreOffre" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>*Description de l'offre:</label>
                        <asp:TextBox ID="txtDescriptionOffre" runat="server" CssClass="form-control" placeholder="Description offre"
                            name="fname" TextMode="MultiLine" MaxLength="2000" Style="overflow: auto; height: 150px; width: 500px; max-height: 150px; min-height: 150px; max-width: 500px; min-width: 500px;" />
                        <asp:Label ID="lblDescriptionOffre" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Date d'expiration de l'offre:</label>
                        <div class="row">
                            <div class="col-lg-2">
                                <asp:TextBox runat="server" ID="txtJourExpiration" placeholder="Jour" MaxLength="2" Width="60" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-2" style="margin-left: -15px;">
                                <asp:TextBox runat="server" ID="txtMoisExpiration" placeholder="Mois" MaxLength="2" Width="60" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-3" style="margin-left: -15px;">
                                <asp:DropDownList runat="server" ID="ddlAnneeExpiration" Width="100" CssClass="form-control">
                                    <asp:ListItem Text="Année" Value="" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <asp:Label ID="lblDateExpiration" runat="server" Text="" ForeColor="Red" Font-Bold="true" width="500"/>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>*Date de début de l'emploi:</label>
                        <div class="row">
                            <div class="col-lg-2">
                                <asp:TextBox runat="server" ID="txtJourDebut" placeholder="Jour" MaxLength="2" Width="60" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-2" style="margin-left: -15px;">
                                <asp:TextBox runat="server" ID="txtMoisDebut" placeholder="Mois" MaxLength="2" Width="60" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-3" style="margin-left: -15px;">
                                <asp:DropDownList runat="server" ID="ddlAnneeDebut" Width="100" CssClass="form-control">
                                    <asp:ListItem Text="Année" Value="" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <asp:Label ID="lblDebut" runat="server" Text="" ForeColor="Red" Font-Bold="true" width="500"/>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>*Salaire horaire:</label>
                        <asp:TextBox ID="txtSalaire" runat="server" CssClass="form-control" placeholder="Salaire" name="fname" MaxLength="5" Width="80" />
                        <asp:Label ID="lblSalaire" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>*Heures par semaine:</label>
                        <asp:TextBox ID="txtHeures" runat="server" CssClass="form-control" placeholder="Heures" name="fname" MaxLength="2" Width="80" />
                        <asp:Label ID="lblHeures" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>*Adresse lieu de travail:</label>
                        <asp:TextBox ID="txtAdresse" runat="server" CssClass="form-control" placeholder="Adresse lieu de travail" name="fname" MaxLength="80" Width="400" />
                        <asp:Label ID="lblAdresse" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>*Ville:</label>
                        <asp:TextBox ID="txtVille" runat="server" CssClass="form-control" placeholder="Ville" name="fname" MaxLength="100" Width="200" />
                        <asp:Label ID="lblVille" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                          <asp:AutoCompleteExtender ID="AutoCompleteExtender"
                            runat="server" DelimiterCharacters="" Enabled="True"
                            TargetControlID="txtVille" UseContextKey="True" CompletionInterval="30"
                            MinimumPrefixLength="1" EnableCaching="true" ServiceMethod="GetCompletionList">
                        </asp:AutoCompleteExtender>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <div class="row">
                            <div class="col-lg-4">
                                <label>*No de téléphone:</label>
                                <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control" placeholder="No de téléphone" name="fname" MaxLength="14" Width="140" />
                                <asp:Label ID="lblTelephonePoste" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                            </div>
                            <div class="col-lg-4" style="margin-left: -15px;">
                                <label>Poste:</label>
                                <asp:TextBox ID="txtposte" runat="server" CssClass="form-control" placeholder="Poste" name="fname" MaxLength="6" Width="80" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>No de télécopieur:</label>
                        <asp:TextBox ID="txtTelecopieur" runat="server" CssClass="form-control" placeholder="No de télécopieur" name="fname" MaxLength="14" Width="140" />
                        <asp:Label ID="lblTelecopieur" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>*Courriel:</label>
                        <asp:TextBox ID="txtCourriel" runat="server" CssClass="form-control" placeholder="Courriel" name="fname" MaxLength="50" Width="300" />
                        <asp:Label ID="lblCourriel" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>*Personne ressource:</label>
                        <asp:TextBox ID="txtRessource" runat="server" CssClass="form-control" placeholder="Personne ressource" name="fname" MaxLength="80" Width="300" />
                        <asp:Label ID="lblRessource" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Fichier PDF pour information supplémentaire:</label>
                        <input id="fuPDF" type="file" name="fileupload" onchange="displayPreview(this.files);" style="width: 300px"  runat="server"/>
                        <asp:Label ID="lblPDF" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                    </div>
                </div>
                <asp:LinkButton ID="lnkAnnuler" Text="Annuler" runat="server" CssClass="btn btn-default" />
                <asp:LinkButton ID="lnkAjouter" Text="Ajouter" runat="server" CssClass="btn btn-default" OnClick="lnkAjouter_Click" />
                <br />
                <br />
            </div>
        </div>
    </div>
</asp:Content>