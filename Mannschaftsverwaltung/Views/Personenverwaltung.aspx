<%@ Page Title="Personenverwaltung" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personenverwaltung.aspx.cs" Inherits="Mannschaftsverwaltung._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Page.Title %></h2>

        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>Fussballspieler</asp:ListItem>
            <asp:ListItem>Handballspieler</asp:ListItem>
            <asp:ListItem>Tennisspieler</asp:ListItem>
            <asp:ListItem>Trainer</asp:ListItem>
            <asp:ListItem>Physiotherapeut</asp:ListItem>
        </asp:RadioButtonList>

        <asp:Button ID="Button2" runat="server" Text="auswählen" OnClick="Button2_Click" />

        <div class="container">
            
            <label class="control-label col-sm-2" for="name">Name:</label>
            <div class="col-sm-10">
                <input class="col-sm-10 form-group" id="name" type="text" name="name" value="" runat="server" disabled />
            </div>

            <label class="control-label col-sm-2" for="vorname">Vorname:</label>
            <div class="col-sm-10">
                <input class="col-sm-10 form-group" id="vorname" type="text" name="vorname" value="" runat="server" disabled />
            </div>

            <label class="control-label col-sm-2" for="alter">Alter:</label>
            <div class="col-sm-10">
                <input class="col-sm-10 form-group" id="alter" type="number" name="alter" value="" runat="server" disabled />
            </div>
            
            <label class="control-label col-sm-2" for="position">Position:</label>
            <div class="col-sm-10">
                <input class="col-sm-10 form-group" id="position" type="text" name="position" value="" runat="server" disabled />
            </div>

            <label class="control-label col-sm-2" for="geschosseneTore">Tore:</label>
            <div class="col-sm-10">
                <input class="col-sm-10 form-group" id="geschosseneTore" type="number" name="geschosseneTore" value="" runat="server" disabled />
            </div>

            <label class="control-label col-sm-2" for="anzahlJahre">Erfahrung in Jahren:</label>
            <div class="col-sm-10">
                <input class="col-sm-10 form-group" id="anzahlJahre" type="number" name="anzahlJahre" value="" runat="server" disabled />
            </div>

            <label class="control-label col-sm-2" for="gewonneneSpiele">Erfahrung in Jahren:</label>
            <div class="col-sm-10">
                <input class="col-sm-10 form-group" id="gewonneneSpiele" type="number" name="gewonneneSpiele" value="" runat="server" disabled />
            </div>

            <label class="control-label col-sm-2" for="anzahlVereine">Anzahl der Vereine:</label>
            <div class="col-sm-10">
                <input class="col-sm-10 form-group" id="anzahlVereine" type="number" name="anzahlVereine" value="" runat="server" disabled />
            </div>

            <label class="control-label col-sm-2" for="anzahlSpiele">Anzahl Spiele:</label>
            <div class="col-sm-10">
                <input class="col-sm-10 form-group" id="anzahlSpiele" type="number" name="anzahlSpiele" value="" runat="server" disabled />
            </div>

            <label class="control-label col-sm-2" for="schlaeger">Schläger:</label>
            <div class="col-sm-10">
                <input class="col-sm-10 form-group" id="schlaeger" type="text" name="schlaeger" value="" runat="server" disabled />
            </div>

            <label class="control-label col-sm-2" for="aufschlagGeschw">Aufschlaggeschw:</label>
            <div class="col-sm-10">
                <input class="col-sm-10 form-group" id="aufschlagGeschw" type="number" name="aufschlagGeschw" value="" runat="server" disabled />
            </div>

        </div>

        <asp:Button ID="Button3" runat="server" Text="hinzufügen" OnClick="Button3_Click" Visible="False" />

    <asp:Table ID="Table1" runat="server" class="table">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Vorname</asp:TableHeaderCell>
            <asp:TableHeaderCell>Geburtsdatum</asp:TableHeaderCell>
            <asp:TableHeaderCell>Sportart</asp:TableHeaderCell>
            <asp:TableHeaderCell>Anzahl Spiele</asp:TableHeaderCell>
            <asp:TableHeaderCell>Erzielte Tore</asp:TableHeaderCell>
            <asp:TableHeaderCell>Gewonnene Spiele</asp:TableHeaderCell>
            <asp:TableHeaderCell>Anzahl Jahre</asp:TableHeaderCell>
            <asp:TableHeaderCell>Anzahl Vereine</asp:TableHeaderCell>
            <asp:TableHeaderCell>Einsatzbereich</asp:TableHeaderCell>
            <asp:TableHeaderCell>Edit</asp:TableHeaderCell>
            <asp:TableHeaderCell>Del</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    

</asp:Content>