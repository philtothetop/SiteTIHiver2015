<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Admin_Vertic.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_Vertic" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content1"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:MultiView ID="mvAdmin_Vertic" runat="server" ActiveViewIndex="0">
            <asp:View runat="server" ID="viewDefault">
    <div class="row">
        <div class="col-lg-9">
              <asp:Label ID="lblConfirmation" runat="server" ></asp:Label>
            <section id="portable">
                <div class="row">
                    <h2>Portable</h2>
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtCaractPortatif" runat="server" Text="" TextMode="MultiLine" Style="max-height: 150px; min-height: 150px; max-width: 599px; min-width: 500px;">

                          </asp:TextBox>
                            </div>
                            <div class="col-lg-4">
                            </div>

                        </div>

                        <br />
                        <br />
                        <b>AUTRES:</b>
                        <br />


                        <asp:TextBox ID="txtAutres" runat="server" Text="" TextMode="MultiLine" Style="max-height: 150px; min-height: 150px; max-width: 599px; min-width: 500px;">

                          </asp:TextBox>
                    </div>
                </div>
            </section>
            <section id="logiciel">
                <div class="row">
                    <h2>Logiciel</h2>
                    <div class="col-lg-12">
                        <h4>LOGICIELS AVEC LICENCES</h4>
                        <asp:TextBox ID="txtLogicielLicenses" runat="server" Text="" TextMode="MultiLine" Style="max-height: 150px; min-height: 150px; max-width: 350px; min-width: 350px;">

                          </asp:TextBox>
                        <br />
                        <br />
                        <h4>LOGICIELS LIBRES (gratuits)</h4>
                        <asp:TextBox ID="txtLogicielLibres" Style="max-height: 150px; min-height: 150px; max-width: 350px; min-width: 350px;" runat="server" Text="" TextMode="MultiLine">

                          </asp:TextBox>
                    </div>
                </div>
            </section>
            <asp:Button ID="btnSauvegarder" runat="server" Text="Sauvegarder" OnClick="btnSauvegarder_Click" />

        </div>
    </div>
                </asp:View>
           <asp:View runat="server" ID="viewFin">
                <div style="text-align: left">
                    <h4>Sauvegarde réussie</h4>
                    <asp:LinkButton ID="lnkRetour" Text="Ok" runat="server" CssClass="btn btn-default" OnClick="lnkRetour_Click"/>
                </div>
            </asp:View>
                </asp:MultiView>
</asp:Content>
