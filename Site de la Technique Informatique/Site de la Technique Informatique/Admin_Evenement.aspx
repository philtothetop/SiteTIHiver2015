<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Admin_Evenement.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_Evenement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%@ Import Namespace="Site_de_la_Technique_Informatique.Classes" %>

    <section id="echeancier" class="echeancier-section">
        <asp:Label ID="lblErreur" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
        <div class="row col-lg-12" style="margin-bottom: 40px;">
            <div class="row col-lg-12">
               <h1 class="page-header">Événements</h1>
            </div>
            <div class="row well col-lg-12 col-md-12" style=" margin-bottom: 50px;">
                <div class="col-lg-5 col-md-5">
                    <h4>Événement</h4>
                    Titre :
                                <br />
                                <asp:TextBox ID="txtAjoutTitre" runat="server" Text="" Style="word-wrap: break-word; min-height:20px; max-height:20px; max-width: 300px; min-width: 300px;"></asp:TextBox>
                                    Description :
                                <br />
                    <asp:TextBox ID="txtAjoutEvenement" runat="server" TextMode="MultiLine" Style="word-wrap: break-word; min-height: 120px; max-height: 120px; max-width: 300px; min-width: 300px;"></asp:TextBox>
                </div>
                <div class="col-lg-7 col-md-7">
                    <h4>Date:</h4>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Début de l'événement</label>
                            <div class="row">
                                <div style="float:left; margin-right:5px; margin-left:20px;">
                                    <asp:TextBox runat="server" ID="txtJourDebutEventAjouter" Style="text-align: center;"
                                        placeholder="Jour" MaxLength="2" Width="60" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div style="float:left; margin-right:5px;">
                                    <asp:DropDownList runat="server" ID="ddlMoisDebutEventAjouter" Width="75" CssClass="form-control"
                                        DataSource='<%# new listeMois() %>' DataTextField="Value" DataValueField="Key">
                                    </asp:DropDownList>
                                </div>
                                <div style="float:left; margin-right:5px;">
                                    <asp:DropDownList runat="server" ID="ddlAnneeDebutEventAjouter" Width="90" CssClass="form-control"
                                        DataSource='<%# new listeAnnees() %>' DataTextField="Value" DataValueField="Key">
                                    </asp:DropDownList>
                                </div>
                                <div style="float:left; margin-right:10px; border-left:black solid 1px;">
                                <asp:DropDownList runat="server" ID="ddlHeuresDebutAjouter" Width="80" CssClass="form-control"
                                    DataSource='<%# new listeHeure() %>' DataTextField="Value" DataValueField="Key">
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:DropDownList runat="server" ID="ddlMinutesDebutAjouter" Width="80" CssClass="form-control"
                                    DataSource='<%# new listeMinute() %>' DataTextField="Value" DataValueField="Key">
                                </asp:DropDownList>
                            </div>
                            </div>

                            <label>Fin de l'événement (Optionnel)</label>
                            <br />
                            <asp:CheckBox ID="chkbPasDateDeFinAjouter" runat="server" Text="Pas de date de fin" />
                            <div class="row">
                                <div style="float:left; margin-right:5px; margin-left:20px;">
                                    <asp:TextBox runat="server" ID="txtJourFinEventAjouter" Style="text-align: center;"
                                        placeholder="Jour" MaxLength="2" Width="60" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div style="float:left; margin-right:5px;">
                                    <asp:DropDownList runat="server" ID="ddlMoisFinEventAjouter" Width="75" CssClass="form-control"
                                        DataSource='<%# new listeMois() %>' DataTextField="Value" DataValueField="Key">
                                    </asp:DropDownList>
                                </div>
                                <div style="float:left; margin-right:5px;">
                                    <asp:DropDownList runat="server" ID="ddlAnneeFinEventAjouter" Width="90" CssClass="form-control"
                                        DataSource='<%# new listeAnnees() %>' DataTextField="Value" DataValueField="Key">
                                    </asp:DropDownList>
                                </div>
                                <div style="float:left; margin-right:10px; border-left:black solid 1px;">
                                <asp:DropDownList runat="server" ID="ddlHeuresFinAjouter" Width="80" CssClass="form-control"
                                    DataSource='<%# new listeHeure() %>' DataTextField="Value" DataValueField="Key">
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:DropDownList runat="server" ID="ddlMinutesFinAjouter" Width="80" CssClass="form-control"
                                    DataSource='<%# new listeMinute() %>' DataTextField="Value" DataValueField="Key">
                                </asp:DropDownList>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="float:right;">
                    <asp:Button ID="btnAjouter" CssClass="btn btn-primary" runat="server" Text="Ajouter" OnClick="btnAjouter_Click" />
                </div>
            </div>

            <div style="clear:both;">
                <br />
            </div>

            <div class="row col-lg-12">
                <asp:ListView ID="lviewEcheancier" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.Evenement"
                    SelectMethod="lvEcheancier_GetData">
                    <LayoutTemplate>
                        <div class="row col-lg-12 col-md-12" style="background-color: #eee; border-bottom: 1px solid black; border-radius: 3px;">
                            <div class="col-lg-5 col-md-5" style="border-right: 1px solid black;">
                                <h4>Événement</h4>
                            </div>
                            <div class="col-lg-7">
                                <h4>Date</h4>
                            </div>
                        </div>
                        <div>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="row col-lg-12 col-md-12" style="min-height: 50px; height: auto; position: relative; border-bottom: 1px solid black;">
                            <div class="col-lg-5 col-md-5" style="min-height: 50px; margin: auto;">
                                Titre :
                                <br />
                                <asp:TextBox ID="txtModifTitre" runat="server" Text='<%#BindItem.titreEvenement %>' Style="word-wrap: break-word; min-height:20px; max-height:20px; max-width: 300px; min-width: 300px;"></asp:TextBox>
                                    Description :
                                <br />
                                <asp:TextBox ID="txtDescEvent" runat="server" Text='<%#BindItem.descriptionEvenement %>' Style="word-wrap: break-word; min-height:150px; max-height:150px; max-width: 300px; min-width: 300px;"
                                    TextMode="MultiLine" />
                            </div>

                            <div class="col-lg-7 col-md-7">

                                <div class="control-group form-group">
                                    <div class="controls">
                                        <div style="margin-top: 10px;"></div>
                                        <label>Début de l'événement :</label>
                                        <div class="row">
                                            <div style="float:left; margin-right:5px; margin-left:20px;">
                                                <asp:TextBox runat="server" ID="txtJourDebutEvent" Text='<%# BindItem.dateDebutEvenement.Day %>' Style="text-align: center;"
                                                    placeholder="Jour" MaxLength="2" Width="60" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div style="float:left; margin-right:5px;">
                                                <asp:DropDownList runat="server" ID="ddlMoisDebutEvent" Width="75" CssClass="form-control"
                                                    DataSource='<%# new listeMois() %>' DataTextField="Value" DataValueField="Key" SelectedValue='<%# BindItem.dateDebutEvenement.Month %>'>
                                                </asp:DropDownList>
                                            </div>
                                            <div style="float:left; margin-right:5px;">
                                                <asp:DropDownList runat="server" ID="ddlAnneeDebutEvent" Width="90" CssClass="form-control"
                                                    DataSource='<%# new listeAnnees() %>' DataTextField="Value" DataValueField="Key" SelectedValue='<%# BindItem.dateDebutEvenement.Year %>'>
                                                </asp:DropDownList>
                                            </div>
                                             <div style="float:left; margin-right:10px; border-left:black solid 1px;">
                                            <asp:DropDownList runat="server" ID="ddlHeuresDebut" Width="80" CssClass="form-control"
                                                DataSource='<%# new listeHeure() %>' DataTextField="Value" DataValueField="Key" SelectedValue='<%# BindItem.dateDebutEvenement.Hour %>'>
                                            </asp:DropDownList>
                                        </div>
                                        <div>
                                            <asp:DropDownList runat="server" ID="ddlMinutesDebut" Width="80" CssClass="form-control"
                                                DataSource='<%# new listeMinute() %>' DataTextField="Value" DataValueField="Key" SelectedValue='<%# BindItem.dateDebutEvenement.Minute %>'>
                                            </asp:DropDownList>
                                        </div>
                                        </div>

                                        <div style="margin-top: 10px;"></div>
                                        <label>Fin de l'événement (Optionnel) :</label> 
                                        <br />
                                        <asp:CheckBox ID="chkbPasDateDeFin" runat="server" Text="Pas de date de fin" Checked='<%# KnowIfNoEndDate(Item.dateFinEvenement.Value) %>'  />
                                        <div class="row">
                                            <div style="float:left; margin-right:5px; margin-left:20px;">
                                                <asp:TextBox runat="server" ID="txtJourFinEvent" Text='<%# BindItem.dateFinEvenement.Day %>' Style="text-align: center;"
                                                    placeholder="Jour" MaxLength="2" Width="60" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div style="float:left; margin-right:5px;">
                                                <asp:DropDownList runat="server" ID="ddlMoisFinEvent" Width="75" CssClass="form-control"
                                                    DataSource='<%# new listeMois() %>' DataTextField="Value" DataValueField="Key" SelectedValue='<%# BindItem.dateFinEvenement.Month %>'>
                                                </asp:DropDownList>
                                            </div>
                                            <div style="float:left; margin-right:5px;">
                                                <asp:DropDownList runat="server" ID="ddlAnneeFinEvent" Width="90" CssClass="form-control"
                                                    DataSource='<%# new listeAnnees() %>' DataTextField="Value" DataValueField="Key" SelectedValue='<%# BindItem.dateFinEvenement.Year %>'>
                                                </asp:DropDownList>
                                            </div>
                                             <div style="float:left; margin-right:10px; border-left:black solid 1px;">
                                            <asp:DropDownList runat="server" ID="ddlHeuresFin" Width="80" CssClass="form-control"
                                                DataSource='<%# new listeHeure() %>' DataTextField="Value" DataValueField="Key" SelectedValue='<%# BindItem.dateFinEvenement.Hour %>'>
                                            </asp:DropDownList>
                                        </div>
                                        <div>
                                            <asp:DropDownList runat="server" ID="ddlMinutesFin" Width="80" CssClass="form-control"
                                                DataSource='<%# new listeMinute() %>' DataTextField="Value" DataValueField="Key" SelectedValue='<%# BindItem.dateFinEvenement.Minute %>'>
                                            </asp:DropDownList>
                                        </div>
                                        </div>

                                       
                                    </div>
                                </div>

                            </div>

                            <div style="float:right;">

                                <asp:Button ID="btnModifier" runat="server" Text="Modifier" CssClass="btn btn-primary" CommandArgument='<%# Item.IDEvenement.ToString() %>' OnClick="UpdateEvent" />
                                <asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" CssClass="btn btn-danger" CommandArgument='<%# Item.IDEvenement.ToString()%>' OnClick="btnSupprimer_Click" />

                            </div>

                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>

        </div>
    </section>
</asp:Content>
