<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription-Employeur.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Inscription.Inscription_Employeur" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Inscription Employeur</title>
    <script type="text/javascript">
        function copieImgData() {
            document.getElementById("<%=ImgExSrc.ClientID%>").value = ContentPlaceHolder1_lviewFormulaireInscription_showDataURL_0.src;
        }
    </script>
    <script type="text/javascript">
        window.transfertDataImg = function (dataURL) {
            $("#ContentPlaceHolder1_lviewFormulaireInscriptionEmployeur_showDataURL_0").attr("src", dataURL);
        };
    </script>
    <script type="text/javascript">
        window.closeModal = function () {
            $('#maPhotoProfile').modal('hide');
            $('#maPhotoProfile').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
        };
    </script>
    <script>
        function goBack() {
            window.history.back();
        }
    </script>
    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="ImgExSrc" />
    <asp:ScriptManagerProxy ID="smProxy" runat="server" />

    <div class="container">
        
        <div class="row row-centered">
            <div class="col-lg-5 col-centered">
                <h1>Inscription d'un employeur</h1>
            </div>
        </div>


        <asp:ListView ID="lviewFormulaireInscriptionEmployeur" runat="server"
            ItemType="Site_de_la_Technique_Informatique.Model.Employeur"
            SelectMethod="GetUtilisateurEmployeur"
            UpdateMethod="CreerUtilisateurEmployeur">
            <ItemTemplate>
                <div class="row row-centered">
                    <div class="col-lg-5 col-centered">
                        <div class="control-group form-group champs-requis">
                            <p>Tous les champs sont requis.</p>
                            <div class="control-group form-group">
                                <div class="controls">
                                    <asp:Label ID="lblMessageValidationErreur" runat="server" Text="" Visible="false" />
                                </div>
                            </div>

                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                            </div>
                        </div>

                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Nom Employeur:</label>
                                <asp:TextBox ID="txtNom" runat="server" CssClass="form-control" placeholder="Nom" Text='<%#BindItem.nomEmployeur %>' name="lname" />
                                <asp:Label ID="lblNomErreur" runat="server" Text="" />
                            </div>
                        </div>

                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Courriel:</label>
                                <asp:TextBox ID="txtCourriel" runat="server" CssClass="form-control" placeholder="courriel@exemple.qc.ca" Text='<%#BindItem.courriel %>' Font-Names="email" />
                                <asp:Label ID="lblCourrielErreur" runat="server" Text="" />
                            </div>
                        </div>
                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Mot de passe:</label>
                                <asp:TextBox ID="txtMotDePasse" runat="server" TextMode="password" CssClass="form-control" Text='<%#BindItem.hashMotDePasse %>' />
                                <asp:Label ID="lblMotDePasseErreur" runat="server" Text="" />
                            </div>
                        </div>

                        <div class="control-group form-group">
                            <div class="controls">
                                <label>Confirmation du mot de passe:</label>
                                <asp:TextBox ID="txtConfirmationMotDePasse" runat="server" TextMode="password" CssClass="form-control" />
                                <asp:Label ID="lblConfirmationMotDePasseErreur" runat="server" Text="" />

                            </div>
                            <asp:UpdatePanel ID="upCondition" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                <ContentTemplate>

                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <asp:CheckBox ID="cbCondition" runat="server" OnCheckedChanged="cbCondition_CheckedChanged" AutoPostBack="true" />
                                            <a href="TermesConditions.aspx" target="_blank">Termes et conditions</a>
                                            <%--<asp:LinkButton ID="lnkConditions" runat="server" Text="Termes et conditions" data-toggle="modal" data-target="#mesConditions" />--%>
                                        </div>

                                    </div>

                                    <asp:LinkButton ID="lnkAnnuler" Text="Retour" runat="server" CssClass="btn btn-danger" OnClientClick="goBack()" />
                                    <asp:LinkButton ID="lnkEnvoyer" Text="Envoyer" runat="server" CssClass="btn btn-default" CommandName="Update" Enabled="false" ValidationGroup="g1" OnClientClick="copieImgData()" />



                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cbCondition" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                   
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
