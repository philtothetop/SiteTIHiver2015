<%@ Page MasterPageFile="~/Admin.master" Language="C#" AutoEventWireup="true" CodeBehind="Admin_editNouvelles.aspx.cs" Inherits="Site_de_la_Technique_Informatique.temp_editNouvelles" MaintainScrollPositionOnPostback="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="tinymce/js/tinymce/tinymce.min.js"></script>
<script type="text/javascript">
    tinymce.init({
        selector: "textarea",
        encoding: "xml",
        plugins: ["image link media advlist autolink lists charmap emoticons preview hr anchor",
                "pagebreak code charmap nonbreaking table contextmenu directionality paste textcolor searchreplace"],
        toolbar1: " undo redo | bold italic underline | alignleft aligncenter alignright alignjustify | fontselect | fontsizeselect | forecolor backcolor | charmap emoticons | bullist numlist outdent indent | link image media",
        language: 'fr_FR',
    });
</script>
<script>
    function Encode() {
        var value = (document.getElementById('TextBox1').value);
        value = value.replace('<', "&lt;");
        value = value.replace('>', "&gt;");
        document.getElementById('txtContenuNouvelle').value = value;
    }
 </script>
        <asp:Panel ID="panelNouvelles" runat="server">
            <div>
             <asp:Label id="msgError" runat="server" style="text-align:center;" ForeColor="Red" Font-Bold="true" Visible="false">Message d'erreur</asp:Label>
                </div>

            <br />
                <div>
                        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Ajouter une nouvelle" OnClick="btnNewNouvelle_Click" />                   
                    <br />
                          <br />
               </div>

        <asp:ListView ID="lviewNouvelles" runat="server"     
            ItemType="Site_de_la_Technique_Informatique.Model.Nouvelle"
            SelectMethod="getNouvelles">
            <LayoutTemplate>
                <div class="panel panel-default">
                    <ul>
                        <li id="itemPlaceholder" runat="server" />
                    </ul>            
                    <br />
                </div>
            </LayoutTemplate>
            
            <ItemTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapse<%# Item.IDNouvelle %>"><%# Item.titreNouvelle %></a>
                                </h4>
                            </div>
                            <div id="collapse<%# Item.IDNouvelle %>" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <asp:LinkButton runat="server" ID="LinkButton1" OnCommand="lnkEditNews_Command" CommandArgument="<%# Item.IDNouvelle %>"> Modifier ou supprimer</asp:LinkButton>
                                    <asp:Literal runat="server" Text="<%# Server.HtmlDecode(Item.texteNouvelle) %>"></asp:Literal>
                                    <asp:LinkButton runat="server" ID="lnkEditNews" OnCommand="lnkEditNews_Command" CommandArgument="<%# Item.IDNouvelle %>"> Modifier ou supprimer</asp:LinkButton>
                                </div>
                            </div>
                        </div>                        
                    </ItemTemplate>
        </asp:ListView>             
            </asp:Panel>



          <div>
                        <asp:Button ID="btnNewNouvelle" CssClass="btn btn-primary" runat="server" Text="Ajouter une nouvelle" OnClick="btnNewNouvelle_Click" />                   
                   
               </div>



        <asp:ListView ID="lviewEditNews" runat="server" Visible="false"
            ItemType="Site_de_la_Technique_Informatique.Model.Nouvelle"
            SelectMethod="getEditNouvelles"
            UpdateMethod="lviewEditNews_UpdateItem"
            DataKeyNames="IDNouvelle">
            <LayoutTemplate>
                <div class="panel panel-default">
                    <div id="itemPlaceholder" runat="server" />                  
                    <br />
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="panel-body">
                    <asp:Label ID="idNews" runat="server" Text='<%# Item.IDNouvelle %>' Visible="false"></asp:Label>
                    <asp:Label runat="server" Text="Titre:"></asp:Label>                
                    <asp:TextBox runat="server" ID="txtTitreNouvelle" Text="<%# BindItem.titreNouvelle %>" Width="350px"></asp:TextBox>
                    <asp:CheckBox ID="chkMajor" runat="server" Text="Modification Importante"></asp:CheckBox>
                    <div style="margin-top: 10px;">
                        <asp:Label runat="server" Text="Contenu de la nouvelle" />
                    </div>
                     <div>
                        <asp:TextBox ID="txtContenuNouvelle" runat="server" TextMode="MultiLine" Text="<%# BindItem.texteNouvelle %>" Style="overflow-y: scroll; overflow-x: hidden" Width="700px" Height="350px" />
                  </div>
                </div>
                 <div>
                        <asp:Button ID="btnModifier" CssClass="btn btn-primary" runat="server" Text="Modifier" CommandName="Update" />
                        <asp:Button ID="btnAnnuler" CssClass="btn btn-primary" runat="server" Text="Annuler" OnClick="btnAnnuler_Click" />
                        <asp:Button ID="btnSupprimer" CssClass="btn btn-danger" runat="server" Text="Supprimer" OnClick="btnSupprimer_Click" />
                    </div>
            </ItemTemplate>
        </asp:ListView>


    <asp:Panel class="panel panel-default" runat="server" ID="panelAjoutNews" Visible="false">
            <div class="panel-body">
                <asp:Label runat="server" Text="Titre:"></asp:Label>
                <asp:TextBox runat="server" ID="txtTitreAjout" Width="350px"></asp:TextBox>
                <div style="margin-top: 10px;">
                    <asp:Label runat="server" Text="Contenu de la nouvelle" />
                </div>
                <div>
                    <asp:TextBox ID="txtNouvelleAjout" runat="server" TextMode="MultiLine" Style="overflow-y: scroll; overflow-x: hidden" Width="700px" Height="350px" />
                </div>
            </div>
            <div>
                <asp:Button ID="btnAjouter" CssClass="btn btn-primary" runat="server" Text="Ajouter" OnClick="btnAjouter_Click" />
                <asp:Button ID="btnAnnuler" CssClass="btn btn-primary"  runat="server" Text="Annuler" OnClick="btnAnnuler_Click" />
            </div>
            <br />
        </asp:Panel>
</asp:Content>
