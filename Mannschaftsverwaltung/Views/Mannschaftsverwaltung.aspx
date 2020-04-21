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

    <h3>Wählen Sie Spieler aus, die der Mannschaft zugehörig sind:</h3>
    <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Width="200px" CssClass="form-control" ></asp:ListBox>
    <br />
    <h3>Bitte füllen Sie folgende Informationen aus:</h3>
    <div class="row">
        <h4 class="col-md-2">Name</h4>
        <div class="input-group col-md-10">
            <asp:TextBox ID="mannschaftsName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <h4 class="col-md-2">Gewonnene Spiele</h4>
        <div class="input-group col-md-10">
            <asp:TextBox ID="gewSpiele" runat="server" CssClass="form-control" type="number"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <h4 class="col-md-2">Unentschieden gespielte Spiele</h4>
        <div class="input-group col-md-10">
            <asp:TextBox ID="unentschieden" runat="server" CssClass="form-control" type="number"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <h4 class="col-md-2">Verlorene Spiele</h4>
        <div class="input-group col-md-10">
            <asp:TextBox ID="verlSpiele" runat="server" CssClass="form-control" type="number"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <h4 class="col-md-2">Erzielte Tore</h4>
        <div class="input-group col-md-10">
            <asp:TextBox ID="erzielteTore" runat="server" CssClass="form-control" type="number"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <h4 class="col-md-2">Gegnerische Tore</h4>
        <div class="input-group col-md-10">
            <asp:TextBox ID="gegnerischeTore" runat="server" CssClass="form-control" type="number"></asp:TextBox>
        </div>
    </div>


    <asp:Button ID="Button2" runat="server" Text="Mannschaft hinzufügen" OnClick="createManschaft" class="btn btn-info" SelectionMode="Multiple" disabled />

    <hr>

    <asp:Table ID="Table1" runat="server" class="table">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Gewonnene Spiele</asp:TableHeaderCell>
            <asp:TableHeaderCell>Unentschieden</asp:TableHeaderCell>
            <asp:TableHeaderCell>Verlorene Spiele</asp:TableHeaderCell>
            <asp:TableHeaderCell>Erzielte Tore</asp:TableHeaderCell>
            <asp:TableHeaderCell>Gegnerische Tore</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
