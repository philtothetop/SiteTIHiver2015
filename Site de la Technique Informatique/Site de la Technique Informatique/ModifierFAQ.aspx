<%@ Page Title="Modifier la FAQ" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ModifierFAQ.aspx.cs" Inherits="Site_de_la_Technique_Informatique.ModifierFAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <asp:DropDownList ID="ddlQuestionsFAQ" runat="server" CssClass="form-control" SelectMethod="getQuestionsFAQ"></asp:DropDownList>
    </div>
</asp:Content>
