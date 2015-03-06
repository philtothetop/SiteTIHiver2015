<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Admin_Evenement.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Admin_Evenement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .outer {
    width: 100%;
    position: relative;
}
    .outer .inner {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
}
    </style>
    <div class="row">
    <section id="echeancier" class="echeancier-section">
                <div class="row" style="width:1100px;margin-left:15px;">
                    <div class="row" style="width:1100px;">
                    <h2>Évènements</h2>

                </div>           
                <asp:ListView ID="lviewEcheancier" runat="server" ItemType="Site_de_la_Technique_Informatique.Model.DateEvenementVerTIC" SelectMethod="lvEcheancier_GetData">
                    <LayoutTemplate>
                        <div class="row" style="background-color:#eee;border-bottom:1px solid black; border-radius:3px;width:1100px;">
                            <div class="col-lg-6" style=" border-right:1px solid black;">
                                <h4>Événement</h4>
                            </div>
                            <div id="topDate" class="col-lg-3">
                                <h4>Date</h4>
                            </div>
                            
                    </div>
                            <div>
                         <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                            </div>
                    </LayoutTemplate>
                     <ItemTemplate>
                        <div  class="row " style="min-height:50px; height:auto; position:relative;width:1100px;border-bottom:1px solid black; ">
                             <div class="col-lg-6" style="min-height:50px; border-right:1px solid black; margin:auto;">
                                <asp:Label ID="lblDescEvent" runat="server" Text='<%#BindItem.evenement %>' style="word-wrap:break-word;"   />
                              </div>

                            <div class="col-lg-3" style="min-height:50px;position:inherit;">
                                   <asp:Label ID="lblDateEvent" runat="server" Text='<%#BindItem.dateDescription %>'  />
                                </div>            
                        
                               <div class="col-lg-3" style="min-height:50px;">
                              <asp:Button ID="btnModifier" runat="server" Text="Modifier"/>
                              <asp:Button ID="btnValider" runat="server" Text="Valider" Visible="false" />
                              <asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" style="margin-left:20px;" />
                                </div>
                            </div>
                        </ItemTemplate>
                   
                    </asp:ListView>
                    </div>
            </section>
        </div>
</asp:Content>
