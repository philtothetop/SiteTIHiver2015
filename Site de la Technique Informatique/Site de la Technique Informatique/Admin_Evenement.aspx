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


    <div class="row">
        <section id="echeancier" class="echeancier-section">


            <div class="row" style="width: 1100px; margin-left: 15px;">
                <div class="row" style="width: 1100px;">
                    <h2>Événements</h2>

                </div>
                <div class="row" style="height:75px;">
                    <div class="col-lg-2">
                        Événement:
                    </div>
                    <div class="col-lg-4" >
                <asp:TextBox ID="txtAjoutEvenement" runat="server" TextMode="MultiLine" Style="word-wrap: break-word;min-height:75px; max-height:75px;max-width:300px;min-width:300px;"></asp:TextBox>
                        </div>
                    <div class="col-lg-3" style="height:75px;">
                Date: <asp:TextBox ID="txtAjoutDate" runat="server" placeholder="AAAA-MM-JJ hh:mm:ss"></asp:TextBox>
                        </div>
                    <div class="col-lg-3">
                   <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" OnClick="btnAjouter_Click"/>
                        </div>
                    </div>
                <br />
                <asp:ListView ID="lviewEcheancier" runat="server" ItemType="Site_de_la_Technique_Informatique.Model.DateEvenementVerTIC" 
                    SelectMethod="lvEcheancier_GetData" 
                    DataKeyNames="LeModelTI.IDDateEvenementVerTIC" 
                    UpdateMethod="lviewEcheancier_UpdateItem">
                    <LayoutTemplate>
                        <div class="row" style="background-color: #eee; border-bottom: 1px solid black; border-radius: 3px; width: 1100px;">
                            <div class="col-lg-6" style="border-right: 1px solid black;">
                                <h4>Événement</h4>
                            </div>
                            <div id="topDate" class="col-lg-3">
                                <h4>Date</h4>
                            </div>

                        </div>
                        <div>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="row " style="min-height: 50px; height: auto; position: relative; width: 1100px; border-bottom: 1px solid black;">
                            <div class="col-lg-6" style="min-height: 50px; border-right: 1px solid black; margin: auto;">
                                <asp:Textbox ID="txtDescEvent" runat="server" Text='<%#BindItem.evenement %>' Style="word-wrap: break-word;min-height:150px; max-height:150px;max-width:300px;min-width:300px;" TextMode="MultiLine" />
                            </div>

                            <div class="col-lg-3" style="min-height: 50px; position: inherit;">

                                <asp:Textbox ID="txtDateEvent" runat="server" Text='<%#BindItem.dateDescription %>' TextMode="MultiLine" style="min-height:50px; max-height:50px;max-width:150px;min-width:150px;" />

                            </div>

                            <div class="col-lg-3" style="min-height: 50px;">

                                <asp:Button ID="btnModifier" runat="server" Text="Modifier" CommandArgument='<%# Eval("IDDateEvenementVerTIC").ToString()%>' CommandName="Update" />
                                <asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" style="margin-left:20px;" OnClick="btnSupprimer_Click" CommandArgument='<%# Eval("IDDateEvenementVerTIC").ToString()%>' />

                            </div> 
                        
                        </div>
                    </ItemTemplate>

                </asp:ListView>
                    
            </div>
        </section>
    </div>
</asp:Content>
