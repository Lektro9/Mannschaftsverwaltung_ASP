<%@ Page Title="Tabellen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tabellen.aspx.cs" Inherits="Mannschaftsverwaltung.Tabellen" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="mt-2 mb-5">Tabellen aller Turniere</h1>

    <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="ItemBound">
        <ItemTemplate>
            <table class="table table-hover table-sm">
                <h2><%# Eval("Name") %></h2>
                <thead>
                    <tr>
                        <th scope="col">Verein</th>
                        <th scope="col">Sp</th>
                        <th scope="col">S</th>
                        <th scope="col">U</th>
                        <th scope="col">N</th>
                        <th scope="col">T</th>
                        <th scope="col">GT</th>
                        <th scope="col">TD</th>
                        <th scope="col">Pkte</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                            <tr class="<%# getPlacement(Container.ItemIndex) %>">
                                <th scope="row"><%# Container.ItemIndex + 1 %> <%# Eval("Name") %></th>
                                <td><%# getSpieleAnzahl(Eval("ID").ToString(), ((RepeaterItem)Container.Parent.Parent).ItemIndex) %></td>
                                <td><%# getGewSpiele(Eval("ID").ToString(), ((RepeaterItem)Container.Parent.Parent).ItemIndex) %></td>
                                <td><%# getUnentschieden(Eval("ID").ToString(), ((RepeaterItem)Container.Parent.Parent).ItemIndex) %></td>
                                <td><%# getVerlSpiele(Eval("ID").ToString(), ((RepeaterItem)Container.Parent.Parent).ItemIndex) %></td>
                                <td><%# getAllTore(Eval("ID").ToString(), ((RepeaterItem)Container.Parent.Parent).ItemIndex) %></td>
                                <td><%# getGegenTore(Eval("ID").ToString(), ((RepeaterItem)Container.Parent.Parent).ItemIndex) %></td>
                                <td><%# getTorDifferenz(Eval("ID").ToString(), ((RepeaterItem)Container.Parent.Parent).ItemIndex) %></td>
                                <td><%# getPunkte(Eval("ID").ToString(), ((RepeaterItem)Container.Parent.Parent).ItemIndex) %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </ItemTemplate>
    </asp:Repeater>

    <h2>Gesamtperformance aller Teams</h2>
    <table class="table table-hover table-sm">
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
