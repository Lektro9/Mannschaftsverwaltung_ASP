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

        <asp:Button ID="Button2" runat="server" Text="auswählen" OnClick="Button2_Click" />
            
        <label for="vorname">Vorname:</label> 
            <input id="vorname" type="text" name="vorname" value="" runat="server" disabled/>
        <label for="alter">Alter:</label> 
            <input id="alter" type="number" name="alter" value="" runat="server" disabled/>
        <label for="position">Position:</label> 
            <input id="position" type="text" name="alter" value="" runat="server" disabled/>
        <label for="geschosseneTore">Tore:</label> 
            <input id="geschosseneTore" type="number" name="alter" value="" runat="server" disabled/>
        <label for="anzahlJahre">Erfahrung in Jahren:</label> 
            <input id="anzahlJahre" type="number" name="alter" value="" runat="server" disabled/>


        <asp:Button ID="Button1" runat="server" Text="hinzufügen" OnClick="Button3_Click" />
    </div>
    

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
            <td>-1</td> <%--ID--%>
            <td></td> <%--Name--%>
            <td><%= person.Name %></td> <%--Vorname--%>
            <td><%= person.Alter %></td> <%--Geburtsdatum--%>
            <td><%= this.getSportart(person) %></td> <%--Sportart--%>
            <td><%= this.getAnzahlSpiele(person) %></td> <%--Anzahl Spiele--%>
            <td><%= this.getErzielteTore(person) %></td> <%--Erzielte Tore--%>
            <td><%= this.getGewonneneSpiele(person) %></td> <%--Gewonnene Spiele--%>
            <td><%= this.getAnzahlJahre(person) %></td> <%--Anzahl Jahre--%>
            <td><%= this.getAnzahlVereine(person) %></td> <%--Anzahl Vereine--%>
            <td><%= this.getRolle(person) %></td> <%--Einsatzbereich--%>
            <td>
                <button class="btn-info">edit</button>
            </td> <%--Edit--%>
            <td>
                <button class="btn-danger">del</button>
            </td> <%--Del--%>
        </tr>
        <% } %>
    </table>
</asp:Content>
