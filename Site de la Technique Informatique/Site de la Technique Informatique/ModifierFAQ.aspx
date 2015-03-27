<%@ Page Title="Modifier la FAQ" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ModifierFAQ.aspx.cs" Inherits="Site_de_la_Technique_Informatique.ModifierFAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <asp:DropDownList ID="ddlQuestionsFAQ" runat="server" CssClass="form-control" SelectMethod="getQuestionsFAQ"></asp:DropDownList>

        <asp:ListView ID="lviewModifFAQ" runat="server"
            SelectMethod="getQuestionsFAQ">
            <LayoutTemplate>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="row">
                    <asp:Label ID="lblQuestion" runat="server" Text="Question:"></asp:Label>
                    <asp:TextBox ID="txtQuestion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:Label ID="lblReponse" runat="server" Text="Réponse:"></asp:Label>
                    <asp:TextBox ID="txtReponse" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
