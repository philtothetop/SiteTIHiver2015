<%@ Page Title="Nouvelles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nouvelles.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Nouvelles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                     
                <%--<asp:ListView ID="lviewNouvelles" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.NouvelleJeu"
                    SelectMethod="getNouvelles">
                    <ItemTemplate>
                        <h3><%# Item.titreNouvelle %></h3>
                        <p> <%# Item.dateNouvelle.ToLongDateString() %></p>
                        <div style="margin-top:5px;" />
                        <p><%# Item.texteNouvelle %></p>
                    </ItemTemplate>
                </asp:ListView>--%>
  
            <!-- Content Column -->
            <div class="col-md-9" style="margin-top">
                <asp:ListView ID="lviewNouvelles" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.Nouvelle"
                    SelectMethod="getNouvelles">
                    <ItemTemplate>

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo"><%# Item.titreNouvelle %></a>
                                </h4>
                            </div>
                            <div id="collapseTwo" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p><%# Item.dateNouvelle.ToLongDateString() %></p>
                                    <div style="margin-top: 5px;" />
                                    <p><%# Item.texteNouvelle %></p>
                                </div>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:ListView>
            </div>

</asp:Content>