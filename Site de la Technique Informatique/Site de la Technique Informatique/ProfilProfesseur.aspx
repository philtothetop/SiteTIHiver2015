<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProfilProfesseur.aspx.cs" Inherits="Site_de_la_Technique_Informatique.ProfilProfesseur" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="divPasTrouveProf" runat="server">
        <h2>Le professeur est introuvable.</h2>
    </div>

    <div id="divTrouverProf" runat="server" class="container" style="margin-top:80px; text-align:center;">

            <asp:LinkButton ID="lnkInformations" runat="server" OnClick="lnkInformation_Click" Text="Informations générales"></asp:LinkButton>
            <asp:LinkButton ID="lnkCours" runat="server" OnClick="lnkMesCours_Click" Text="Mes Cours" style="margin-left:30px;"></asp:LinkButton>

        <div class="row row-centered">
            <h2>Profil d'un Professeur</h2>
        </div>

        

        <div style="text-align:center; width:100%;">

            <asp:MultiView ID="mltvProfesseur" runat="server">
            
               <asp:View ID="vInformations" runat="server">

            <div class="tab-pane fade in active" style="text-align:center;">
                <div class="row row-centered" >
                    <h3>Informations générales</h3>
                    <asp:ListView ID="lvProfesseur" runat="server"
                        ItemType="Site_de_la_Technique_Informatique.Model.Professeur"
                        SelectMethod="lvProfesseur_GetData">

                        <LayoutTemplate>
                            <div style="text-align:center;">
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </div>
                        </LayoutTemplate>

                        <EmptyDataTemplate>
                            QUI ES-TU, QUE VIENS-TU FAIRE ICI?
                        </EmptyDataTemplate>

                        <ItemTemplate>

                            <div style="text-align:center; width:100%;">
                                <label>Prénom et Nom</label>
                                <div>
                                       <asp:label runat="server" ID="lblNomPrenom" Text='<%# Item.prenom + " " + Item.nom %>' style="border:solid #ccc 1px; padding: 6px 12px;"></asp:label>
                                     </div>   
                            </div>

                            <br />
                            <div style="text-align:center; width:100%;">
                                <label>Courriel:</label>
                                <div>
                                <asp:Label runat="server" ID="lblCourriel" Text='<%#Item.courriel %>' style="border:solid #ccc 1px; padding: 6px 12px;"></asp:Label>
                                    </div>
                            </div>
                            <br />
                            <div style="text-align:center; width:100%;">
                                <label>Texte de présentation:</label>
                                <div>
                                            <asp:Label runat="server" ID="lblPresentation" Text='<%# Item.presentation %>' style="border:solid #ccc 1px; padding: 6px 12px;"></asp:Label>
                                     </div>   
                            </div>

                            <br />
                            <div style="text-align:center; width:100%;">
                                       <img src='<%# "~/../Photos/Profils/" + Item.pathPhotoProfil %>' width="125" height="125" />
                            </div>


                            <div style="text-align:center; width:100%;">
                                <label>Description de la photo:</label>
                                <div>
                                       <asp:label runat="server" ID="lblDesPhoto" Text='<%# Item.photoDescription  %>' style="border:solid #ccc 1px; padding: 6px 12px;"></asp:label>
                                     </div>   
                            </div>

                        </ItemTemplate>
                    </asp:ListView>
                </div>

            </div>

                   </asp:View>

                <asp:View ID="vCours" runat="server">
            <div>
                <div class="row row-centered">
                    <div class="col-md-10 col-centered">
                        <div class="row row-centered">

                            <h3>Mes Cours</h3>
                            <div>

                                <div style="text-align:center; width:100%;">
                                    <label>Session</label>
                                    <div>
                                                <asp:DropDownList ID="ddlSession" runat="server"
                                                    OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" AutoPostBack="true" style="border:solid #ccc 1px; padding: 6px 12px;">
                                                    <asp:ListItem Text="Session 1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Session 2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Session 3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Session 4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="Session 5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="Session 6" Value="6"></asp:ListItem>
                                                </asp:DropDownList>
                                        </div>
                                    </div>
                            </div>
                        </div>
                        <hr />
                        <asp:ListView ID="lvCours" runat="server"
                            SelectMethod="GetLesCoursDuProf"
                            ItemType="Site_de_la_Technique_Informatique.Model.Cours">

                            <EmptyDataTemplate>
                                <p>Aucun cours assigné pour cette session.</p>
                            </EmptyDataTemplate>
                            <LayoutTemplate>

                                <div style="clear:both;">
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                                </div>
                             
                            </LayoutTemplate>


                            <ItemTemplate>

                                <div class="row row-centered">

                                    <div class="col-md-2 col-centered form-group form">

                                        <label>No. de cours</label>
                                        <asp:Label ID="lblNoCours" runat="server" CssClass="form-control" Text='<%#Item.noCours %>' />

                                    </div>
                                    <div class="col-md-4 col-md-offset-1 col-centered form-group form">
                                        <label>Nom du cours</label>
                                        <asp:Label ID="lblNomCours" CssClass="form-control" runat="server" Text='<%#Item.nomCours %>' />
                                    </div>
                                    <div class="col-md-7 col-centered form-group form">
                                        <label>Description</label>
                                        <asp:Label ID="lblDescriptionCours" CssClass="form-control" runat="server"  Text='<%#Item.descriptionCours %>' style="height:200px;" />
                                    </div>  
                                </div>


                            </ItemTemplate>

                        </asp:ListView>
                    </div>
                </div>


            </div>
                    </asp:View>
            </asp:MultiView>
        </div>

    </div>

</asp:Content>



