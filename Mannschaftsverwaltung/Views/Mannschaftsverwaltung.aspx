<%@ Page Title="Mannschaftsverwaltung" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mannschaftsverwaltung.aspx.cs" Inherits="Mannschaftsverwaltung.Mannschaftsverwaltung" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <% if (this.Verwalter.IsError)
        { %>
    <div aria-live="polite" aria-atomic="true" style="position: relative; min-height: 0px;">
        <div class="toast position-absolute" style="position: absolute; top: 25px; right: 10%; z-index: 1;" data-autohide="false">
            <div class="toast-header">
                <strong class="mr-auto text-danger">Etwas ist schief gelaufen!</strong>
                <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="toast-body">
                <%= this.Verwalter.ErrorMsg %>
            </div>
        </div>
    </div>
    <% } %>


    <h1 class="mt-2"><%: Page.Title %></h1>
    <% if (this.Verwalter.ActiveUser.Rolle == Mannschaftsverwaltung.Role.ADMIN)
        {%>
    <div class="row equal">
        <div class="col-md-4">
            <h3>Sportart:</h3>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem onclick="SimulateClick('MainContent_Button1');">Fussball</asp:ListItem>
                <asp:ListItem onclick="SimulateClick('MainContent_Button1');">Handball</asp:ListItem>
                <asp:ListItem onclick="SimulateClick('MainContent_Button1');">Tennis</asp:ListItem>
                <asp:ListItem onclick="SimulateClick('MainContent_Button1');">Trainer</asp:ListItem>
                <asp:ListItem onclick="SimulateClick('MainContent_Button1');">Physiotherapeut</asp:ListItem>
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
                <asp:Button ID="accept" runat="server" Text="accept" OnClick="acc_Click" class="btn btn-success" SelectionMode="Multiple" disabled />
            </div>
        </div>
    </div>

    <%}%>

    <asp:Button ID="Button1" runat="server" Text="Spieler laden" OnClick="loadPersons" class="btn btn-success center-block mt-2 d-none" />
    <% if (this.Verwalter.ActiveUser.Rolle == Mannschaftsverwaltung.Role.ADMIN)
        {%>
    <asp:Table ID="Table1" runat="server" class="table mt-2">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
                <asp:Button ID="ButtonSortName" runat="server" OnClick="orderByName" Text="Name" CssClass="btn btn-primary" />
            </asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="text-center">Anzahl Spieler</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="text-center">Spieler</asp:TableHeaderCell>
            <asp:TableHeaderCell>Bearbeiten</asp:TableHeaderCell>
            <asp:TableHeaderCell>Personen entf.</asp:TableHeaderCell>
            <asp:TableHeaderCell>Löschen</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <%}%>

    <% if (this.Verwalter.ActiveUser.Rolle == Mannschaftsverwaltung.Role.USER)
        {%>
    <table class="table table-hover">
        <thead>
            <tr>
                <th scope="col">Name</th>
                <th scope="col">Spieler</th>
            </tr>
        </thead>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="ItemBound">
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Eval("Name") %></th>
                        <td>
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <%# Eval("Name") %>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </tbody>
    </table>
    <%}%>
    <asp:Button Text="Download Mannschaften als XML" runat="server" OnClick="download_XML_click" CssClass="btn btn-dark mt-2" />
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
