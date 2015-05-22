<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AjoutDiscussion.aspx.cs" Inherits="Site_de_la_Technique_Informatique.AjoutDiscussion" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="tinymce/plupload-2.1.2/js/plupload.full.min.js"></script>
    <script type="text/javascript" src="tinymce/js/tinymce/tinymce.min.js"></script>
    <script type="text/javascript">
        tinymce.init({
            selector: "textarea",
            encoding: "xml",
            plugins: ["image link media advlist charmap emoticons autolink lists charmap preview hr anchor",
                    "pagebreak code nonbreaking table contextmenu directionality paste textcolor searchreplace"],
            toolbar1: " undo redo | bold italic underline | alignleft aligncenter alignright alignjustify | fontselect | fontsizeselect | forecolor backcolor | charmap emoticons | bullist numlist outdent indent | link image media",
            language: 'fr_FR',
            setup: function (editor) {
                editor.on('SaveContent', function (ed) {
                    ed.content = ed.content.replace(/&#39/g, "&apos");
                });
            }
        });
    </script>
    <script>
        function Encode() {
            var value = (document.getElementById('TextBox1').value);
            value = value.replace('<', "&lt;");
            value = value.replace('>', "&gt;");
            document.getElementById('txtMessage').value = value;
        }
    </script>
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
                        <div class="col-centered">
                            <asp:Label ID="lblErreur" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                            <br />
                            <br />
                            <div class="control-group form-group">
                                <div class="controls">
                                    <label>*Titre discussion:</label><br />
                                    <asp:TextBox ID="txtTitreDiscussion" runat="server" MaxLength="150" placeholder="Titre discussion" Width="600px"></asp:TextBox><br />
                                    <asp:Label ID="lblTitreDiscussion" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                                </div>
                            </div>
                            <label>*Message:</label>
                            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" placeholder="Message" Width="600px" Style="max-height: 150px; min-height: 150px; min-width: 600px; max-width: 600px" MaxLength="2000"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Font-Bold="true" />
                            <asp:LinkButton ID="lnkAjouter" Text="Valider" runat="server" CssClass="btn btn-primary" OnClick="lnkAjouter_Click" />
                            <asp:LinkButton ID="lnkAnnuler" Text="Annuler" runat="server" CssClass="btn btn-danger" PostBackUrl="~/EnteteForum.aspx" />
                            <br />
                            <br />
                        </div>
                    </asp:View>
                    <asp:View runat="server" ID="viewFin">
                        <div style="text-align: center">
                            <h4>Votre discussion a été créée avec succès</h4>
                            <asp:LinkButton ID="lnkRetour" Text="Voir ma discussion" runat="server" CssClass="btn btn-primary" OnClick="lnkRetour_Click" />
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
</asp:Content>
