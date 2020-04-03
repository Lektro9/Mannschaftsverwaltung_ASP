<%@ Page Title="Personenverwaltung" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personenverwaltung.aspx.cs" Inherits="Mannschaftsverwaltung._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Page.Title %></h2>

    <div class="row">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>Fussballspieler</asp:ListItem>
            <asp:ListItem>Handballspieler</asp:ListItem>
            <asp:ListItem>Tennisspieler</asp:ListItem>
            <asp:ListItem>Trainer</asp:ListItem>
            <asp:ListItem>Physiotherapeut</asp:ListItem>
        </asp:RadioButtonList>

    </div>
    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />

    <table class="table">
        <tr>
            <th scope="col">ID</th>
            <th scope="col">Name</th>
            <th scope="col">Vorname</th>
            <th scope="col">Geburtsdatum</th>
            <th scope="col">Sportart</th>
            <th scope="col">Anzahl Spiele</th>
            <th scope="col">Erzielte Tore</th>
            <th scope="col">Gewonnene Spiele</th>
            <th scope="col">Anzahl Jahre</th>
            <th scope="col">Anzahl Vereine</th>
            <th scope="col">Einsatzbereich</th>
            <th scope="col">Edit</th>
            <th scope="col">Del</th>
        </tr>
        <% foreach (var person in this.Verwalter.Personen)
            { %>
        <tr>
            <td>-1</td>
            <td><%= person.Name %></td>
            <td>Vorname</td>
            <td><%= person.Alter %></td>
            <td></td>
            <td><%= person.GetType() %></td>
            <td><%= person is Mannschaftsverwaltung.FussballSpieler ? ((Mannschaftsverwaltung.FussballSpieler)person).GeschosseneTore : 0 %></td>
            <td>@mdo</td>
            <td>@mdo</td>
            <td>@mdo</td>
            <td>@mdo</td>
            <td>@mdo</td>
            <td>@mdo</td>
        </tr>
        <% } %>
    </table>
</asp:Content>
