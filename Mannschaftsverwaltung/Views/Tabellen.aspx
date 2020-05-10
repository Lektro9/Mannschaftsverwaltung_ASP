<%@ Page Title="Tabellen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tabellen.aspx.cs" Inherits="Mannschaftsverwaltung.Tabellen" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="mt-2"><%: Page.Title %></h1>

    <table class="table table-hover">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Name</th>
                <th scope="col">Sportart</th>
                <th scope="col">Gew. Spiele</th>
                <th scope="col">Unentschieden</th>
                <th scope="col">Verl. Spiele</th>
                <th scope="col">Erzielte Tore</th>
                <th scope="col">Gegn. Tore</th>
            </tr>
        </thead>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Eval("ID") %></th>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Sportart") %></td>
                        <td><%# Eval("GewSpiele") %></td>
                        <td><%# Eval("Unentschieden") %></td>
                        <td><%# Eval("VerlSpiele") %></td>
                        <td><%# Eval("ErzielteTore") %></td>
                        <td><%# Eval("GegnerischeTore") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </tbody>
    </table>
</asp:Content>
