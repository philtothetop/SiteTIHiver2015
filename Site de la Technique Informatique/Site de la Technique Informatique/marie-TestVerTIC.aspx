<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="marie-TestVerTIC.aspx.cs" Inherits="Site_de_la_Technique_Informatique.marie_TestVerTIC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!DOCTYPE HTML>
<html>
<head>
    <style type="text/css">
        html, body {
             height: 100%;
             margin: 0pt;
        }
        .Frame {
             display: table;
             height: 100%;
             width: 100%;
        }
        .Row {
             display: table-row;
             height: 1px;
        }
        .Row.Expand {
             height: auto;
        }
    </style>
</head>
<body class="Frame">
    <header class="Row"><h1>Catchy header</h1></header>

    <!-- these two line differ from the previous example -->
    <section class="Row"><h2>Awesome content</h2></section> 
    <footer class="Row Expand"><h3>Sticky footer</h3></footer>

</body>
</html>
</asp:Content>
