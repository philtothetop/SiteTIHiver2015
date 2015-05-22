<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Validation-Inscription-Etudiant.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.Validation_Inscription" MasterPageFile="~/Admin.master" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery.js"></script>
    <link rel="stylesheet" href="­~/../Css/Validation-Inscription.css" />
    <!-- Bootstrap Core JavaScript -->
  

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-11">
            <h1 class="page-header">Validation des inscriptions des étudiants</h1>
            <div class="col-lg-11 control-group form-group ">
                <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" />
            </div><br />
            <span id="lblCourrielNonValider"><%=GetCourrielNonValiderList()%> inscription(s) dont la validation du courriel n'a pas été validé dans les 24 dernières heures.</span>
            <asp:LinkButton ID="lnkEffacerInscriptionCourrielNonValider" runat="server" Text="Effacer" OnClick="lnkEffacerInscriptionCourrielNonValider_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-lg-11">
            <div id="divAucunNouvelleInscription" class="aucunInsctiption" runat="server" visible="false">
                Aucune nouvelle inscription.
            </div>
            <div class="datapager">
                <asp:UpdatePanel ID="upListValidation" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                        <asp:ListView ID="lviewValidationInscription" runat="server"
                            ItemType="Site_de_la_Technique_Informatique.Model.Etudiant"
                            SelectMethod="GetUtilisateurEtudiantList"
                            UpdateMethod="CreerUtilisateurEtudiantList">
                            <LayoutTemplate>
                                <div class="col-lg-12">
                                    <asp:DataPager ID="dpLviewValidationInscription" runat="server" PagedControlID="lviewValidationInscription" PageSize="10">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                                ShowNextPageButton="false" />
                                            <asp:NumericPagerField ButtonType="Link" />
                                            <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                                <div class="col-lg-12 top-list  bar-bottom">
                                    <span class="col-md-1 vcenter">Photo</span>
                                    <span class="col-md-3 vcenter">Prénom Nom</span>
                                    <span class="col-md-3 vcenter">Courriel</span>
                                    <span class="col-md-2 vcenter">Date inscription</span>

                                </div>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />

                                <div class="col-lg-12 top-list bar-top">
                                    &nbsp;&nbsp;&nbsp;
                        <span class="col-md-1 vcenter btn-bas"></span>
                                    <span class="col-md-3 vcenter"></span>
                                    <span class="col-md-3 vcenter"></span>
                                    <span class="col-md-2 vcenter"></span>
                                </div>
                                <div class="col-lg-12">
                                    <asp:DataPager ID="dpLview2" runat="server" PagedControlID="lviewValidationInscription" PageSize="10">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                                ShowNextPageButton="false" />
                                            <asp:NumericPagerField ButtonType="Link" />
                                            <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class='<%#Convert.ToBoolean(Container.DisplayIndex % 2) ? "OddRowColor col-lg-12 OddHeight" : "EvenRowColor col-lg-12 OddHeight" %>'>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("IDEtudiant") %>' Visible="false" />
                                    <span class="col-md-1 vcenter">

                                        <asp:Image ID="imgPhotoProfil" runat="server" ImageUrl='<%#  "~/Upload/Photos/Profils/"+Eval("pathPhotoProfil") %>' CssClass="img-thumbnail" /></span>
                                    <asp:Label ID="lblPrenom" runat="server" Text='<%#Eval("prenom")+" "+Eval("nom") %>' CssClass="col-md-3 vcenter" />
                                    <asp:Label ID="lvlCourriel" runat="server" Text='<%#Eval("courriel") %>' CssClass="col-md-3 vcenter" />
                                    <asp:Label ID="lblDateInscription" runat="server" Text='<%#Eval("dateInscription") %>' CssClass="col-md-2 vcenter" />
                                    &nbsp;&nbsp;
                        <asp:LinkButton ID="lnkAccepter" Text="Accepter" runat="server" CssClass="btn" OnClick="lnkAccepter_Click" CommandArgument='<%#Eval("IDEtudiant") %>' />&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkRefuser" Text="Supprimer" runat="server" CssClass="btn" OnClick="lnkRefuser_Click" CommandArgument='<%#Eval("IDEtudiant") %>' />
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
