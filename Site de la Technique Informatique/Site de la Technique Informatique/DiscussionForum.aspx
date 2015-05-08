<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DiscussionForum.aspx.cs" Inherits="Site_de_la_Technique_Informatique.DiscussionForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <asp:Label ID="lblTitreDiscussion" runat="server" Font-Size="20"></asp:Label>
                </h1>
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
                            <asp:Label ID="message" Text='<%# Eval("texteMessage").ToString()%>' Font-Size="12" runat="server"></asp:Label>
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
                <asp:LinkButton ID="lnkNouveauMessage" Text="Envoyer" runat="server" CssClass="btn btn-default" OnClick="lnkNouveauMessage_Click" />
            </div>
            <hr />
        </div>
    </div>
</asp:Content>
