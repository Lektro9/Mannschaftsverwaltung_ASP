<%@ Page Title="Mannschaftsverwaltung" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mannschaftsverwaltung.aspx.cs" Inherits="Mannschaftsverwaltung.Mannschaftsverwaltung" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Page.Title %></h2>
    <div class="row equal">
        <div class="col-md-4">
            <h3>Sportart:</h3>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem onclick="SimulateClick('MainContent_Button1');">Fussball</asp:ListItem>
                <asp:ListItem onclick="SimulateClick('MainContent_Button1');">Handball</asp:ListItem>
                <asp:ListItem onclick="SimulateClick('MainContent_Button1');">Tennis</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-md-4">
            <h3>Mögliche Spieler:</h3>
            <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Width="400px" Height="200px" CssClass="form-control"></asp:ListBox>
        </div>
        <div class="col-md-4 center-align flexcontainer">
            <h3>Name:</h3>
                <div>
                    <asp:TextBox ID="mannschaftsName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="Button2" runat="server" Text="Mannschaft erstellen" OnClick="createManschaft" class="btn btn-success" SelectionMode="Multiple" disabled />
                </div>
        </div>
    </div>

    <asp:Button ID="Button1" runat="server" Text="Spieler laden" OnClick="loadPersons" class="btn btn-success center-block mt-2 d-none" />

    <asp:Table ID="Table1" runat="server" class="table mt-2">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
                <asp:Button ID="ButtonSortName" runat="server" OnClick="orderByName" Text="Name" CssClass="btn btn-default" />
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>Gewonnene Spiele</asp:TableHeaderCell>
            <asp:TableHeaderCell>Unentschieden</asp:TableHeaderCell>
            <asp:TableHeaderCell>Verlorene Spiele</asp:TableHeaderCell>
            <asp:TableHeaderCell>Erzielte Tore</asp:TableHeaderCell>
            <asp:TableHeaderCell>Gegnerische Tore</asp:TableHeaderCell>
            <asp:TableHeaderCell>Anzahl Spieler</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <script type="text/javascript">
        function SimulateClick(buttonId) {
            var button = document.getElementById(buttonId);
            if (button) {
                if (button.click) {
                    button.click();
                }
                else if (button.onclick) {
                    button.onclick();
                }
                else {
                    alert("DEBUG: button '" + buttonId + "' is not clickable");
                }
            } else {
                alert("DEBUG: button with ID '" + buttonId + "' does not exist");
            }
        }
    </script>
</asp:Content>
