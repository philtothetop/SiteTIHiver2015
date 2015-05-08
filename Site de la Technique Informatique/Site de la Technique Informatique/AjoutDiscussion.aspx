<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AjoutDiscussion.aspx.cs" Inherits="Site_de_la_Technique_Informatique.AjoutDiscussion" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Nouvelle discussion
                </h1>
            </div>
        </div>
        <div class="row">
            <div class="row row-centered">
                <asp:MultiView ID="mvAjoutDiscussion" runat="server" ActiveViewIndex="0">
                    <asp:View runat="server" ID="viewAjout">
                        <div class="col-lg-5 col-centered">
                            <asp:Label ID="lblErreur" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                            <br />
                            <br />
                            <div class="control-group form-group">
                                <div class="controls">
                                    <label>*Titre discussion:</label><br />
                                    <asp:TextBox ID="txtTitreDiscussion" runat="server" MaxLength="30" placeholder="Titre discussion" Width="600px"></asp:TextBox><br />
                                    <asp:Label ID="lblTitreDiscussion" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                                </div>
                            </div>
                            <div class="control-group form-group">
                                <div class="controls">
                                    <label>*Message:</label>
                                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" placeholder="Message" Style="max-height: 150px; min-height: 150px; min-width: 600px; max-width: 600px" MaxLength="2000"></asp:TextBox>
                                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                                </div>
                            </div>
                             <asp:LinkButton ID="lnkAjouter" Text="Valider" runat="server" CssClass="btn btn-primary" OnClick="lnkAjouter_Click" />
                            <asp:LinkButton ID="lnkAnnuler" Text="Annuler" runat="server" CssClass="btn btn-danger" PostBackUrl="~/EnteteForum.aspx" />                          
                            <br />
                            <br />
                        </div>
                    </asp:View>
                    <asp:View runat="server" ID="viewFin">
                        <div style="text-align: center">
                            <h4>Votre discussion a été créée avec succès</h4>
                            <asp:LinkButton ID="lnkRetour" Text="Voir ma discussion" runat="server" CssClass="btn btn-primary" onclick="lnkRetour_Click" />
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
</asp:Content>
