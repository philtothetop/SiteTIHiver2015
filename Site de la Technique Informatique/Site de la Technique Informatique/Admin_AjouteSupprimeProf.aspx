<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Admin_AjouteSupprimeProf.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_AjouteSupprimeProf" MaintainScrollPositionOnPostback="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Css/Inscription.css" />
    <div class="container">
        

            <asp:MultiView ID="mViewAjoutSupprime" runat="server" ActiveViewIndex="0">

                <asp:View ID="viewAjouterProf" runat="server">
                    
                    <asp:Button ID="btnAllezSupprimerProf" runat="server" OnClick="btnAllezSupprimerProf_Click" CssClass="btn btn-default" Text="Supprimer un professeur" />
                    
                    <div class="row" id="divAjoutProf" runat="server">
                                <div class="col-md-12">
                                <div class="col-md-4">
                
                                    <h1>Ajouter un professeur</h1>
                                    <br />
                
                                    <fieldset>
                                         <div class="control-group form-group champs-requis">
                                                Tous les champs sont requis.
                                            </div>
                                        <h4>Informations Personnelles</h4>
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <label>Prénom:</label>
                                            <asp:TextBox runat="server" ID="txtPrenom" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <label>Nom:</label>
                                            <asp:TextBox runat="server" ID="txtNom" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                         </fieldset>
                                    </div>
                                    </div>
           
                                <div class="col-md-12">
                                <div class="col-md-4">
                                   <br />
                                    <fieldset>
                                    <h4>Informations de connexion</h4>
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <label>Courriel:</label>
                                            <asp:TextBox runat="server" ID="txtCourriel" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <label>Le mot de passe sera généré automatiquement et sera envoyé à l'adresse courriel</label>
                                             </div>
                                    </div>
                                        </fieldset>
                                    </div>
                                    </div>
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                    <asp:LinkButton ID="lnkEnvoyer" Text="Ajouter" runat="server" CssClass="btn btn-default" OnClick="lnkEnvoyer_Click" />
                                        </div>
                                </div>
            
                            </div>
                            <div class="row" runat="server" id="divComplete" visible ="false">
                                <div class="col-md-12">
                                    <h2>Le professeur a été ajouté.</h2>
                                    <asp:LinkButton ID="lnkAjouterUnAutreProf" runat="server" CssClass="btn btn-default" Text="Ajouter un autre professeur" OnClick="lnkAjouterUnAutreProf_Click" />
                                </div>
                            </div>
                
                            <asp:Label ID="lblMessages" runat="server" Text ="" />
                </asp:View>


                <asp:View ID="viewSupprimerProf" runat="server">
                    <asp:Button ID="btnAllezAjouterProf" runat="server" OnClick="btnAllezAjouterProf_Click" CssClass="btn btn-default" Text="Ajouter un professeur" />

                    <h1>Supprimer un professeur</h1>
                    <br />


                <asp:ListView runat="server"
                    ID="lviewLesProfs"
                    ItemType="Site_de_la_Technique_Informatique.Model.Professeur"
                    SelectMethod="GetLesProfs"
                    GroupItemCount="2">


                    <GroupTemplate>
                        <div style="clear:both;">
                         <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </div>
                    </GroupTemplate>

                    <ItemTemplate>


                        <div style="float:left; width:50%;">
                            <div style="border:black solid 1px; min-height:75px;">
                            <div style="clear:both; width:75px; float:left;">
                                 <asp:ImageButton ID="photoProfil" runat="server" Width="75px" Height="75px" ImageUrl='<%# Item.pathPhotoProfil %>' CommandArgument='<%# Item.IDUtilisateur %>' OnClick="photoProfil_Click"></asp:ImageButton>

                            </div>
                            <div style="width:100%;">
                                <div>
                                    <asp:Label runat="server" ID="lblNomPrenom" Text='<%# Item.prenom + " " + Item.nom%>'></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblCourrielProf" Text='<%# Item.courriel %>' runat="server" Style="text-decoration: none; color: black;"></asp:Label>
                                </div>
                            </div>
                             <div style="clear:both; float:left;">
                                  <asp:Button ID="btnSupprimerProf" runat="server" Text="Supprimer" CssClass="btn-danger" CommandArgument='<%# Item.IDUtilisateur %>' OnClick="btnSupprimerProf_Click" />
                                
                                 </div>
                            </div>
                            <br />
                            <br />
                        </div>
                    </ItemTemplate>

                    <LayoutTemplate>

                        <asp:PlaceHolder ID="groupPlaceHolder" runat="server" />

                    </LayoutTemplate>

                   

                    <EmptyDataTemplate>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="col-lg-3">
                                    <asp:Label ID="lblVide" runat="server" Font-Bold="true" Text="Aucun professeur trouvé!"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </EmptyDataTemplate>

                </asp:ListView>
                 <div style="text-align:center; width:100%;">
            <asp:DataPager ID="dataPagerProfs" runat="server" PagedControlID="lviewLesProfs"
                            PageSize="10">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" PreviousPageText="<<" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowLastPageButton="False" ShowPreviousPageButton="False" NextPageText=">>" />
                            </Fields>
                        </asp:DataPager>
                </div>




                </asp:View>
            </asp:MultiView>
        
    </div>
</asp:Content>
