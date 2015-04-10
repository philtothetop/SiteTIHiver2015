<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AjoutMedia.aspx.cs" Inherits="Site_de_la_Technique_Informatique.AjoutMedia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Ajout Médias</h3>
    <div>
        <div class="row">
            <div class="col-lg-2">
                <asp:Label ID="lblListMedia" runat="server" Text="Article(s): " />
            </div>
            <div class="col-lg-3">
                <asp:DropDownList ID="ddlMedia" CssClass="form-control" runat="server" SelectMethod="GetMediaList" DataTextField="descriptionParution" DataValueField="IDParutionMedia" AppendDataBoundItems="true"></asp:DropDownList>
            </div>
            <div class=" col-lg-2">
                <asp:Button ID="btnModif" runat="server" Text="Modifier" CssClass="btn btn-primary" OnClick="btnModif_Click" />
            </div>
            <div class="col-lg-2">
                <asp:Button ID="btnAjout" runat="server" Text="Ajouter" CssClass="btn btn-primary" OnClick="btnAjout_Click" />
            </div>

        </div>
        <hr />

        <asp:ListView ID="lvMedia" runat="server"
            ItemType="Model.ParutionMedia"
            SelectMethod="GetMedia"
            UpdateMethod="UpdateMedia"
            DeleteMethod="DeleteMedia"
            OnItemDataBound="lvMedia_ItemDataBound">

            <LayoutTemplate>
                <div class="row">
                    <div class="col-lg-9"></div>
                    <div class="col-lg-3">
                        <asp:DataPager ID="datapagerMedia" runat="server"
                            PagedControlID="lvMedia" PageSize="1">
                        </asp:DataPager>
                    </div>
                </div>

                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />

            </LayoutTemplate>
            <ItemTemplate>

                <!--Rangée 2-->

                <div class="row rowEspace">
                    <div class="col-lg-2">
                        <asp:Label ID="lblTitre" runat="server" Text="Titre: " />
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="txtTitre" CssClass="form-control" runat="server" Text='<%# BindItem.titreParution %>'></asp:TextBox>
                    </div>
                    <div class="col-lg-offset-1 col-lg-2">
                        <asp:Label ID="lblDate" runat="server" Text="Date: "></asp:Label>
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" Text='<%# BindItem.dateParution %>'></asp:TextBox>
                    </div>
                </div>

                <!--Rangée 3-->

                <div class="row rowEspace">
                    <div class="col-lg-2">
                        <asp:Label ID="lblDescription" runat="server" Text="Description: " />
                    </div>
                </div>

                <!--Rangée 4-->

                <div class="row rowEspace">
                    <div class="col-lg-6">
                        <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" TextMode="MultiLine" Text='<%# BindItem.descriptionParution %>'></asp:TextBox>
                    </div>
                </div>
                
                <!--Rangée 5-->

                <div class="row rowEspace">
                    <asp:FileUpload ID="fuMedia" runat="server" />
                    <asp:Button ID="btnUpload" CssClass="btn btn-primary rowEspace" runat="server" Text="Télécharger" OnClick="btnUpload_Click" />
                    <asp:Textbox ID="txtArticle" runat="server" Text="" Enabled="false" />
                    <asp:Label runat="server" id="lblMessageSuccess" Text="" />
                                                

                </div>

                
                <!--Rangée 6-->
                <br />
                <div class="row rowEspace">
                    <div class="col-lg-offset-8 col-lg-2">
                        <asp:Button ID="btnSave" runat="server" Text="Enregistrer" CssClass="btn btn-primary" CommandName="Update" />
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" CssClass="btn btn-danger" CommandName="Delete" />
                    </div>
                </div>
                <br />

            </ItemTemplate>

            <asp:Label runat="server" id="lblMessage" Text="" />

        </asp:ListView>
    </div>



</asp:Content>
