<%@ Page Title="Mannschaftsverwaltung" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mannschaftsverwaltung.aspx.cs" Inherits="Mannschaftsverwaltung.Mannschaftsverwaltung" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Page.Title %></h2>
    
    <p>Wählen Sie eine Sportart aus:</p>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>Fussball</asp:ListItem>
        <asp:ListItem>Handball</asp:ListItem>
        <asp:ListItem>Tennis</asp:ListItem>
    </asp:RadioButtonList>

    <asp:Button ID="Button1" runat="server" Text="Spieler laden" OnClick="loadPersons" class="btn btn-info" />

    <p>Wählen Sie Spieler aus die der Mannschaft zugehörig sind:</p>
    <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Width="200px"></asp:ListBox>
    <br />
    <asp:Button ID="Button2" runat="server" Text="Mannschaft hinzufügen" OnClick="Button2_Click" class="btn btn-info" SelectionMode="Multiple" disabled />
</asp:Content>
