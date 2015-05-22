<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Media.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_Media" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
                <div class="col-md-3 col-md-offset-4" style="position: absolute">
                    <div class="alert alert-success" runat="server" id="divSuccess" visible="false">
                        <p>Les modifications ont été effectuées.</p>
                    </div>
                </div>
            </div>
    <div class="row">
                <div class="col-md-3 col-md-offset-7" style="position: absolute;">
                    <div class="alert alert-warning" runat="server" id="divWarning" visible="false">
                        <p>Veuillez porter attention à ces champs:</p>
                        <br />
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
   <h1 class="page-header">Médias</h1>
     
    
    <div>
        <div class="row">
            <div class="col-lg-2">
                <asp:Label ID="lblListMedia" runat="server" Text="Article(s): " />
            </div>
           <div class="col-lg-3">
                <asp:DropDownList ID="ddlMedia" CssClass="form-control" runat="server" SelectMethod="GetMediaList" DataTextField="titreParution" DataValueField="IDParutionMedia" AutoPostBack="false"></asp:DropDownList>
           </div> 
            <div class="col-lg-1">
                <asp:Button ID="btnModif" runat="server" Text="Modifier" CssClass="btn btn-primary" OnClick="btnModif_Click" />
            </div>
            <div class="col-lg-1">
                <asp:Button ID="btnAjout" runat="server" Text="Ajouter" CssClass="btn btn-primary" OnClick="btnAjout_Click" />
            </div>

        </div>
        <hr />

        <asp:ListView ID="lvMedia" runat="server"
            ItemType="Site_de_la_Technique_Informatique.Model.ParutionMedia"
            SelectMethod="GetMedia"
            UpdateMethod="UpdateMedia"
            DeleteMethod="DeleteMedia"
            OnItemDataBound="lvMedia_ItemDataBound" 
            Visible="false"
            >

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
                   
                       
                    <div class="col-lg-1">
                        <asp:Label ID="lblTitre" runat="server" Text="Titre: " />
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtTitre" CssClass="form-control" runat="server" Text='<%# BindItem.titreParution %>' ></asp:TextBox> 
                    </div>
                    <div class=" col-lg-1">
                        <asp:Label ID="lblDate" runat="server" Text="Date: "></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" Text='<%# BindItem.dateParution %>'></asp:TextBox> 
                     </div>
                </div>

                <!--Rangée 3-->
                <br />
                <div class="row rowEspace">
                    <div class="col-lg-2 rowEspace">
                        <asp:Label ID="lblDescription" runat="server" Text="Description: " />
                    </div>
                </div>

                <!--Rangée 4-->

                <div class="row rowEspace">
                    <div class="col-lg-6">
                        <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" TextMode="MultiLine" Text='<%# BindItem.descriptionParution %>'></asp:TextBox>
                    </div>
                </div>
                <br />


                <!--Rangée 5-->

                <div class="row rowEspace">
                    <div class="col-lg-3">
                        <asp:FileUpload ID="fuMedia" runat="server" />
                    </div>
                </div>

                <!--Rangée 5A-->
                <div class="row rowEspace">
                    <div class="col-lg-1">
                        <asp:Button ID="btnUpload" CssClass="btn btn-primary rowEspace" runat="server" Text="Télécharger" OnClick="btnUpload_Click" />
                    </div>
                    <div class="col-lg-offset-1 col-lg-3">
                        <asp:TextBox ID="txtArticle" CssClass="form-control" runat="server" Text='<%# BindItem.pathFichierPDF %>' Enabled="false" />
                    </div>
                    <div class="col-lg-3">
                        <asp:Label runat="server" ID="lblMessageSuccess" Text="" />
                    </div>
                </div>

              

                
                <!--Rangée 6-->
                <br />
                <div class="row rowEspace">
                    <div class="col-lg-offset-5 col-lg-1">
                        <asp:Button ID="btnSave" runat="server" Text="Sauvegarder" CssClass="btn btn-primary" CommandName="Update" />
                    </div>
                    <div class="col-lg-2">
                       &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" CssClass="btn btn-danger" CommandName="Delete" />
                    </div>
                </div>
                <br />
                 <!--Rangée invisible -->

                <asp:TextBox ID="TextBox1" Visible="false" CssClass="form-control" runat="server" Text='<%# BindItem.ProfesseurIDUtilisateur %>'></asp:TextBox> 
                <asp:TextBox ID="txtNo" Visible="false" CssClass="form-control" runat="server" Text='<%# BindItem.IDParutionMedia %>' ></asp:TextBox> 
               

            </ItemTemplate>

        </asp:ListView>


       
            
          

            
     
    </div>



</asp:Content>
