<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilEtudiant.aspx.cs" Inherits="Site_de_la_Technique_Informatique.ProfilEtudiant" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/ProfilEtudiant.css" rel="stylesheet" />
    <!--Afficher les erreurs de input-->

    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="ImgExSrc" />
    <asp:ScriptManagerProxy ID="smProxy" runat="server" />
    <div class="container">
        <div class="col-lg-3"></div>
        <div class="col-lg-6 col-centered">

            <div class="container-fluid">
                <asp:ListView ID="lvModifProfilEtudiant" runat="server"
                    ItemType="Site_de_la_Technique_Informatique.Model.Etudiant"
                    SelectMethod="SelectEtudiant">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </LayoutTemplate>
                    <EmptyDataTemplate>
                        <table class="emptyTable">
                            <tr>
                               
                                <td>Cet étudiant n'existe pas.
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <div class="row row-centered">
                            <div class="col-lg-9 col-centered">
                                <h1>Profil</h1>
                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <!-- Modal Profil picture-->
                                <div class="modif-photo">
                                    <div class="img-thumbnail img-photo preview-photo">
                                        <div></div>
                                        <asp:Image ID="showDataURL" runat="server" ImageUrl='<%#"Photos/Profils/"+Eval("pathPhotoProfil") %>' Width="125" Height="125" />
                                    </div>
                                </div>


                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Prénom:</label><br />
                                <asp:Label ID="lblPrenom" runat="server" placeholder="Prénom" Text='<%#Eval("prenom") %>' />

                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Nom:</label><br />
                                <asp:Label ID="lbltNom" runat="server" placeholder="Nom" Text='<%#Eval("nom") %>' />

                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Date de naissance:</label><br />

                                <asp:Label ID="lblDateNaissance" runat="server" Text='<%#Convert.ToDateTime(Eval("dateNaissance")).ToShortDateString() %>' />

                            </div>
                        </div>
                        <div class="control-group form-group" id="dvCourriel">
                            <div class="controls">
                                <label>Courriel:</label>
                                <asp:Label ID="lblCourriel" runat="server" placeholder="courriel@exemple.qc.ca" Text='<%#Eval("courriel")%>' />
                               
                            </div>
                        </div>
                        <div class="control-group form-group cv" id="dvCV">
                            <div class="controls">
                                <label>CV:</label>
                                <asp:LinkButton ID="lnkCV" runat="server" PostBackUrl='<%#Server.MapPath("/Upload/CV/" + Eval("pathCV")) %>' Text='<%#Eval("pathCV")%>' /><br />
                            </div>
                        </div>


                    </ItemTemplate>
                </asp:ListView>
                                        <div class="col-lg-offset-8 col-lg-8 " id="dvModifier" runat="server">
                    <asp:LinkButton ID="lnkModifier" runat="server" Text="Modifier" CssClass="btn btn-primary" OnClick="lnkModifier_Click" CommandArgument='<%#Eval("IDEtudiant")%>' />
                     <asp:LinkButton ID="lnkFaireTemoignage" runat="server" Text="Faire un témoignage" CssClass="btn btn-primary" OnClick="lnkFaireTemoignage_Click"  />
                </div> 
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>

