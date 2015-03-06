<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AjoutOffreEmploi.aspx.cs" Inherits="Site_de_la_Technique_Informatique.AjoutOffreEmploi" %>

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
                        <label>Poste:</label>
                        <asp:TextBox ID="txtTitreOffre" runat="server" CssClass="form-control" placeholder="Poste" name="fname"  MaxLength="80" Width="980"/>
                        <asp:Label ID="lblTitreOffre" runat="server" Text="" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Description offre:</label>
                        <asp:TextBox ID="txtDescriptionOffre" runat="server" CssClass="form-control" placeholder="Description offre" 
                            name="fname" TextMode="MultiLine" MaxLength="2000"/>
                        <asp:Label ID="lblDescriptionOffre" runat="server" Text="" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Date expiration:</label>
                        <asp:TextBox ID="txtDateExpiration" runat="server" CssClass="form-control" placeholder="Date expiration" name="fname" />
                        <asp:Label ID="lblDateExpiration" runat="server" Text="" />
                    </div>
                </div>
                 <div class="control-group form-group">
                    <div class="controls">
                        <label>Date début emploi:</label>
                        <asp:TextBox ID="txtDateDebut" runat="server" CssClass="form-control" placeholder="Date début emploi" name="fname" />
                        <asp:Label ID="lblDateDebut" runat="server" Text="" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Salaire horaire:</label>
                        <asp:TextBox ID="txtSalaire" runat="server" CssClass="form-control" placeholder="Salaire horaire" name="fname" />
                        <asp:Label ID="lblSalaire" runat="server" Text="" />
                    </div>
                </div>
                 <div class="control-group form-group">
                    <div class="controls">
                        <label>Heures par semaine:</label>
                        <asp:TextBox ID="txtHeures" runat="server" CssClass="form-control" placeholder="Heures par semaine" name="fname" />
                        <asp:Label ID="lblHeures" runat="server" Text="" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Adresse lieu de travail:</label>
                        <asp:TextBox ID="txtAdresse" runat="server" CssClass="form-control" placeholder="Adresse lieu de travail" name="fname" />
                        <asp:Label ID="lblAdresse" runat="server" Text="" />
                    </div>
                </div>
                 <div class="control-group form-group">
                    <div class="controls">
                        <label>Ville lieu de travail:</label>
                        <asp:TextBox ID="txtVille" runat="server" CssClass="form-control" placeholder="Vile lieu de travail" name="fname" />
                        <asp:Label ID="lblVille" runat="server" Text="" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>No de téléphone:</label>
                        <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control" placeholder="No de téléphone" name="fname" />
                        <asp:Label ID="lblTelephone" runat="server" Text="" />
                    </div>
                </div>
                 <div class="control-group form-group">
                    <div class="controls">
                        <label>No de télécopieur:</label>
                        <asp:TextBox ID="txtTelecopieur" runat="server" CssClass="form-control" placeholder="No de télécopieur" name="fname" />
                        <asp:Label ID="lblTelecopieur" runat="server" Text="" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Courriel:</label>
                        <asp:TextBox ID="txtCourriel" runat="server" CssClass="form-control" placeholder="Courriel" name="fname" />
                        <asp:Label ID="lblCourriel" runat="server" Text="" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Personne ressource:</label>
                        <asp:TextBox ID="txtRessource" runat="server" CssClass="form-control" placeholder="Personne ressource" name="fname" />
                        <asp:Label ID="lblRessource" runat="server" Text="" />
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Fichier PDF pour information supplémentaire:</label>
                        <input id="fuPDF" type="file" name="fileupload" onchange="displayPreview(this.files);" />
                        <asp:Label ID="lblPDF" runat="server" Text="" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
