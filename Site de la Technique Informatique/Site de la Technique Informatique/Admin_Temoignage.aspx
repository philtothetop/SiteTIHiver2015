<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Admin_Temoignage.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_Temoignage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h1>Administrateur : Les Témoignages</h1>

                <asp:ListView ID="lviewTemoignage" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.Etudiant"
                        SelectMethod="GetLesTemoignagesEtudiants">

                        <LayoutTemplate>
                            <div>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </div>
                        </LayoutTemplate>

                        <ItemTemplate>
                        <div>
                            <h2> '<%# Item.nom + ", " + Item.prenom %></h2>
                            <asp:Label ID="lblTemoignage" runat="server" Text='<%# "Témoignage : " + Item.temoignage %>'></asp:Label>
                        
                            <div id="divPourTemoignagePasValide" runat="server" style="clear:both;">

                            <div style="float:left; padding-left:35px">
                                <asp:Button ID="btnAccepterTemoignage" runat="server" Text="Accepter" CssClass="btn btn-success" CommandArgument='<%# Item.IDEtudiant %>' OnClick="AccepterTemoignage_Click" />

                            </div>
                            <div style="float:right; padding-right:35px">

                            <asp:Button ID="btnRefuserTemoignage" runat="server" Text="Refuser" CssClass="btn btn-danger" CommandArgument='<%# Item.IDEtudiant %>' OnClick="SupprimerTemoignage_Click"/>


                            </div>
                                </div>
                            </div>

                             <div style="clear:both; height:10px;">
                            </div>

                        </ItemTemplate>

                    <EmptyDataTemplate>
                          <div>
            <div style="width:100%; text-align:center; padding-top:20px;">
                       <asp:Label ID="lblPasDeTemoignage" runat="server" Text="Il n'y a pas de témoignage à valider pour le moment" style="font:bold; font-size:large"></asp:Label>
                </div>
        </div>
                    </EmptyDataTemplate>

            <EmptyDataTemplate>
            <div>

                </div>
                </EmptyDataTemplate>
            
        </asp:ListView>

        <div style="text-align:center; width:100%;">
            
            <asp:DataPager ID="dataPagerDesTemoignages" runat="server" PagedControlID="lviewTemoignage"
                            PageSize="6">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" PreviousPageText="<<" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowLastPageButton="False" ShowPreviousPageButton="False" NextPageText=">>" />
                            </Fields>
                        </asp:DataPager>
                </div>

</asp:Content>