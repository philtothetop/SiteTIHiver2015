<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Admin_Evenement.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_Evenement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .outer {
            width: 100%;
            position: relative;
        }

            .outer .inner {
                position: absolute;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
            }
    </style>

    <%@ Import Namespace="Site_de_la_Technique_Informatique.Classes" %>

    <div class="row">
        <section id="echeancier" class="echeancier-section">

            <div class="row col-lg-12">
                <div class="row col-lg-12">
                    <h2>Événements</h2>

                </div>
                <div class="row col-lg-12" style="height: 75px; margin-bottom:50px;">
                    <div class="col-lg-2">
                        Événement:
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtAjoutEvenement" runat="server" TextMode="MultiLine" Style="word-wrap: break-word; 
                        min-height: 75px; max-height: 75px; max-width: 300px; min-width: 300px;"></asp:TextBox>
                        </div>
                    <div class="col-lg-3" style="height: 75px;">
                        Date:
                        <asp:TextBox ID="txtAjoutDate" runat="server" placeholder="AAAA-MM-JJ hh:mm:ss"></asp:TextBox>
                        </div>
                    <div class="col-lg-3">
                        <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" OnClick="btnAjouter_Click" />
                        </div>
                    </div>
                
                <div class="row col-lg-12">
                <asp:ListView ID="lviewEcheancier" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.DateEvenementVerTIC"
                    SelectMethod="lvEcheancier_GetData">
                    <LayoutTemplate>
                        <div class="row col-lg-12" style="background-color: #eee; border-bottom: 1px solid black; border-radius: 3px;">
                            <div class="col-lg-5" style="border-right: 1px solid black;">
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
                        <div class="row col-lg-12" style="min-height: 50px; height: auto; position: relative; border-bottom: 1px solid black;">
                            <div class="col-lg-5" style="min-height: 50px; border-right: 1px solid black; margin: auto;">
                                <asp:TextBox ID="txtDescEvent" runat="server" Text='<%#BindItem.evenement %>' Style="word-wrap: break-word; 
                                min-height: 150px; max-height: 150px; max-width: 300px; min-width: 300px;" TextMode="MultiLine" />
                            </div>

                            <div class="col-lg-4" style="position: inherit;">

                                <div class="control-group form-group">
                                    <div class="controls">
                                        <div style="margin-top:10px;"></div>
                                        <label>Date de l'événement :</label>
                                        <div class="row">
                                            <div class="col-lg-3">
                                                <asp:TextBox runat="server" ID="txtJourEvent" Text='<%# BindItem.dateDescription.Day %>' Style="text-align:center;"
                                                    placeholder="Jour" MaxLength="2" Width="60" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-3" style="margin-left: -15px;">
                                                <asp:DropDownList runat="server" ID="ddlMoisEvent" Width="70" CssClass="form-control" 
                                                DataSource='<%# new listeMois() %>' DataTextField="Value" DataValueField="Key" SelectedValue='<%# BindItem.dateDescription.Month %>'>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-3" style="margin-left: -15px;">
                                                <asp:DropDownList runat="server" ID="ddlAnneeEvent" Width="90" CssClass="form-control" 
                                                DataSource='<%# new listeAnnees() %>' DataTextField="Value" DataValueField="Key" SelectedValue='<%# BindItem.dateDescription.Year %>' >
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div style="margin-top:10px;"></div>
                                        <label>Heure de l'événement :</label>
                                        <div></div>
                                        <div class="col-lg-3" style="margin-left: -15px;">
                                            <asp:DropDownList runat="server" ID="ddlHeures" Width="70" CssClass="form-control"
                                            DataSource='<%# new listeHeure() %>' DataTextField="Value" DataValueField="Key" SelectedValue='<%# BindItem.dateDescription.Hour %>' >
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-4" style="margin-left: -5px;">
                                            <asp:DropDownList runat="server" ID="ddlMinutes" Width="70" CssClass="form-control" 
                                            DataSource='<%# new listeMinute() %>' DataTextField="Value" DataValueField="Key" SelectedValue='<%# BindItem.dateDescription.Minute %>' >
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="col-lg-3" style="margin-top:30px;" >

                                <asp:Button ID="btnModifier" runat="server" Text="Modifier" CommandArgument='<%# Eval("IDDateEvenementVerTIC").ToString()%>' OnClick="UpdateEvent" />
                                <asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" Style="margin-left: 20px; margin-top:45px;" CommandArgument='<%# Eval("IDDateEvenementVerTIC").ToString()%>' OnClick="btnSupprimer_Click" />

                            </div> 
                        
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                </div>
                    
            </div>
        </section>
    </div>
    </div>
</asp:Content>
