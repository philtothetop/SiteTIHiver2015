<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DiscussionForum.aspx.cs" Inherits="Site_de_la_Technique_Informatique.DiscussionForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="tinymce/plupload-2.1.2/js/plupload.full.min.js"></script>
<script type="text/javascript" src="tinymce/js/tinymce/tinymce.min.js"></script>
<script type="text/javascript">
    tinymce.init({
        selector: "textarea",
        encoding: "xml",
        plugins: ["image link media advlist autolink lists charmap preview hr anchor",
                "pagebreak code nonbreaking table contextmenu directionality paste textcolor searchreplace"],
        toolbar1: " undo redo | bold italic underline | alignleft aligncenter alignright alignjustify | fontselect | fontsizeselect | forecolor backcolor | bullist numlist outdent indent | link image media",
        language: 'fr_FR',              
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
                <h1 class="page-header">
                    <asp:Label ID="lblTitreDiscussion" runat="server" Font-Size="20"></asp:Label>
                </h1>
                <asp:Label ID="lblNbMessages" Font-Size="12" runat="server" Font-Bold="true"></asp:Label>
            </div>
        </div>
        <div class="row">
            <asp:ListView ID="lviewDiscussion" runat="server" SelectMethod="getDiscussion" DataKeyNames=" dateMessage, MembreIDUtilisateur" OnItemDataBound="lviewDiscussion_ItemDataBound">
                <ItemTemplate>
                    <div class="row" style="border: solid; border-color: lightgray; border-width: 1px; margin-top: 5px;">
                        <div class="col-lg-2" style="text-align: center">
                            <br />
                            <asp:Image ID="imgPhotoProfil" runat="server" Height="71" Width="75" max-height="71" max-width="75" />
                            <br />
                            <asp:Label ID="lblNom" Font-Size="12" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDateMessage" Font-Size="12" runat="server"></asp:Label>
                        </div>
                        <div class="col-lg-7">
                            <br />
                            <asp:Label ID="message" Text='<%# Server.HtmlDecode(Eval("texteMessage").ToString())%>' Font-Size="12" runat="server"></asp:Label>
                        </div>
                    </div>
                </ItemTemplate>
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <div style="text-align: center">
                        <asp:Label ID="lblPasDeMessage" runat="server">
                         <h4 class="sous-titre">Cette discussion est vide</h4>
                        </asp:Label>
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>
            <div style="text-align: center">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lviewDiscussion" PageSize="10">
                    <Fields>
                        <asp:NumericPagerField ButtonType="Link" />
                    </Fields>
                </asp:DataPager>
                <br />
                <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" placeholder="Message" Style="max-height: 150px; min-height: 150px; min-width: 600px; max-width: 600px" MaxLength="2000"></asp:TextBox>
                <br />
                <asp:LinkButton ID="lnkNouveauMessage" Text="Envoyer" runat="server" CssClass="btn btn-primary" OnClick="lnkNouveauMessage_Click" />
            </div>
            <hr />
        </div>
    </div>
</asp:Content>
