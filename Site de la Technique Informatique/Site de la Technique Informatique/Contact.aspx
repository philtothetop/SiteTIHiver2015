<%--Cette classe permet à ceux qui le veulent de contacter le département d'informatique 
Écrit par Marie-Philippe Gill, Février 2015
Intrants: MasterPage
Extrants: --%>


<%@ Page Title="Contactez-nous" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
    <!-- GOOGLE MAPS VERS LE CÉGEP DE GRANBY -->
        <div class="row">
            <!-- La MAP -->
            <div class="col-md-8">
                <!-- Embedded Google Map -->
        		<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d1434389.325702777!2d-72.729688!3d45.39841600000002!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4cc9ce4626f8e4af%3A0x33b6b3796aff1235!2sCegep+de+Granby!5e0!3m2!1sfr!2sfr!4v1417025587666" width="100%" height="400" frameborder="0" style="border:0"></iframe>
            </div>
            <!-- Détails pour contacter le cégep -->
            <div class="col-md-4">
                <h3>Détails</h3>
                <p>
                    235 Rue St-Jacques<br />Granby, Qc, J2G 9H7<br />
                </p>
                <p><i class="fa fa-phone"></i> 
                    <abbr title="TÃ©lÃ©phone">P</abbr>: (450) 372-6614</p>
                <p><i class="fa fa-envelope-o"></i> 
                    <abbr title="Email">E</abbr>: <a href="denis@dupaul.ca">denis@dupaul.ca</a>
                </p>
                <p><i class="fa fa-clock-o"></i> 
                    <abbr title="Horaire">H</abbr>: Lundi - Vendredi: 9:00 à  17:00</p>
                <ul class="list-unstyled list-inline list-social-icons">
                    <li>
                        <a href="https://www.facebook.com/CegepGranby"><i class="fa fa-facebook-square fa-2x"></i></a>
                    </li>
                    <li>
                        <a href="https://twitter.com/CegepGranby"><i class="fa fa-linkedin-square fa-2x"></i></a>
                    </li>
                    <li>
                        <a href="https://www.linkedin.com/company/c-gep-granby-haute-yamaska"><i class="fa fa-twitter-square fa-2x"></i></a>
                    </li>
                    <li>
                        <a href="https://www.youtube.com/user/CegepdeGranby"><i class="fa fa-youtube-square fa-2x"></i></a>
                    </li>
                </ul>
            </div>
        </div>
        <!-- FIN DU GOOGLE MAPS -->


     <!-- FORMULAIRE DE CONTACT -->
       
        <div class="row">

            <div class="col-md-8">
                <h3>Écrivez-nous</h3>
                <asp:Label ID="lblMessageHaut" runat="server" Text=""></asp:Label>
                <br />
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="lblNom" runat="server" Text="Nom:"></asp:Label>
                            <asp:TextBox ID="txtNom" runat="server" class="form-control"></asp:TextBox>
                            <p class="help-block"></p>
                        </div>
                    </div>
                    
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="lblCourriel" runat="server" Text="Courriel:"></asp:Label>
                            <asp:TextBox ID="txtCourriel" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="lblMessage" runat="server" Text="Message:"></asp:Label>
                            <asp:TextBox ID="txtMessage" runat="server" class="form-control" TextMode="MultiLine" Height="200px"></asp:TextBox>
                         </div>
                    </div>
                <asp:Button ID="btnEnvoyer" runat="server" Text="Envoyer" OnClick="btnEnvoyer_Click" />
                </div>
            </div>

        </div>
        <!-- /.row -->

</asp:Content>
