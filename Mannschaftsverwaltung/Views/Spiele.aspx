<%@ Page Title="Spiele" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Spiele.aspx.cs" Inherits="Mannschaftsverwaltung.Spiele" EnableEventValidation="false" %>

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

    <%--erstellen eines Turnieres--%>
    <% if (this.Verwalter.ActiveUser.Rolle == Mannschaftsverwaltung.Role.ADMIN)
        {%>
    <div class="card mt-4">
        <div class="card-header">
            <h3>Turnier erstellen</h3>
        </div>
        <div class="card-body">
            <div class="form-row">
                <div class="col-md-4">
                    <h3>Mögliche Teams:</h3>
                    <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Width="400px" Height="200px" CssClass="form-control"></asp:ListBox>
                </div>
                <div class="col-7 pt-5">
                    <input type="text" id="TurnierNameEing" class="form-control" placeholder="Name des Turnieres" runat="server">
                    <asp:Button ID="TurnierErst" runat="server" Text="Erstellen" OnClick="TurnierErst_Click" class="btn btn-success mt-5" />
                </div>
            </div>
        </div>
    </div>
    <%}%>

    <!-- Mannschaften auswählen -->
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="ItemBound">
        <ItemTemplate>

            <div class="card mt-4">
                <div class="card-header text-center">
                    <%# Eval("Name") %>
                    <% if (this.Verwalter.ActiveUser.Rolle == Mannschaftsverwaltung.Role.ADMIN)
                        {%>
                    <asp:Button runat="server" type="button" Text="X" class="ml-2 mb-1 close" OnClick="TurEntf_Click" aria-label="Close" name="del_<%# Container.ItemIndex + 1 %>" />
                    <%}%>
                </div>
                <div class="card-body">
                    <div class="container">
                        <div class="row rowcustom">

                            <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="ItemBoundOnRepeater2">
                                <ItemTemplate>
                                    <p runat="server" visible='<%# !isGameEdit(Eval("ID").ToString()) %>'>
                                        <div class="col-5">
                                            <div class="input-group-prepend d-flex justify-content-between">
                                                <span class="input-group-text"><%# getTeamName(Eval("Team1ID").ToString()) %></span>
                                                <span class="input-group-text"><%# Eval("Team1Punkte") %></span>
                                            </div>
                                        </div>

                                        <div class="col-5">
                                            <div class="input-group-prepend d-flex justify-content-between">
                                                <span class="input-group-text"><%# Eval("Team2Punkte") %></span>
                                                <span class="input-group-text"><%# getTeamName(Eval("Team2ID").ToString()) %></span>
                                            </div>
                                        </div>
                                        <% if (this.Verwalter.ActiveUser.Rolle == Mannschaftsverwaltung.Role.ADMIN)
                                            {%>
                                        <asp:Button runat="server" Text="Löschen" OnClick="SpielEntf_Click" class="btn btn-danger" name="del_<%# Container.ItemIndex + 1 %>" />
                                        <asp:Button runat="server" Text="Edit" OnClick="SpielEdit_Click" class="btn btn-warning" name="edit_<%# Container.ItemIndex + 1 %>" />
                                        <%}%>
                                    </p>

                                    <p runat="server" visible='<%# isGameEdit(Eval("ID").ToString()) %>'>
                                        <div class="col-5">
                                            <div class="input-group">
                                                <div class="input-group-prepend">
                                                    <label class="input-group-text" for="inputGroupSelect01">Team 1</label>
                                                </div>
                                                <select class="custom-select" data-width="200px" name="EditSelect1_<%# Container.ItemIndex + 1 %>" id="EditSelect1_<%# Container.ItemIndex + 1 %>">
                                                    <asp:Repeater ID="Repeater5" runat="server">
                                                        <ItemTemplate>
                                                            <option value="<%# Eval("ID") %>"><%# Eval("Name") %></option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>
                                                <input type="number" class="form-control rightalign" name="EditTeam1goals_<%# Container.ItemIndex + 1 %>" id="example1" placeholder="Punkte" value="<%# Eval("Team1Punkte") %>">
                                            </div>
                                        </div>

                                        <div class="col-5 justify-content-end">
                                            <div class="input-group">
                                                <input type="number" class="form-control" name="EditTeam2goals_<%# Container.ItemIndex + 1 %>" id="example1" placeholder="Punkte" value="<%# Eval("Team2Punkte") %>">
                                                <select class="custom-select" name="EditSelect2_<%# Container.ItemIndex + 1 %>" id="EditSelect2_<%# Container.ItemIndex + 1 %>">
                                                    <asp:Repeater ID="Repeater6" runat="server">
                                                        <ItemTemplate>
                                                            <option value="<%# Eval("ID") %>"><%# Eval("Name") %></option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>
                                                <div class="input-group-append">
                                                    <label class="input-group-text" for="inputGroupSelect02">Team 2</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2 d-flex justify-content-center">
                                            <asp:Button runat="server" Text="Accept" OnClick="SpielBearbeitet_Click" class="btn btn-success" />
                                        </div>
                                    </p>


                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                        <% if (this.Verwalter.ActiveUser.Rolle == Mannschaftsverwaltung.Role.ADMIN)
                            {%>
                        <div class="row rowcustom">

                            <div class="col-5">
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <label class="input-group-text" for="inputGroupSelect01">Team 1</label>
                                    </div>
                                    <select class="custom-select" data-width="200px" name="Select1_<%# Container.ItemIndex + 1 %>" id="Select1_<%# Container.ItemIndex + 1 %>">
                                        <asp:Repeater ID="Repeater3" runat="server">
                                            <ItemTemplate>
                                                <option value="<%# Eval("ID") %>"><%# Eval("Name") %></option>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </select>
                                    <input type="number" class="form-control rightalign" name="team1goals_<%# Container.ItemIndex + 1 %>" placeholder="Punkte">
                                </div>
                            </div>

                            <div class="col-5 justify-content-end">
                                <div class="input-group">
                                    <input type="number" class="form-control" name="team2goals_<%# Container.ItemIndex + 1 %>" placeholder="Punkte">
                                    <select class="custom-select" name="Select2_<%# Container.ItemIndex + 1 %>" id="Select2_<%# Container.ItemIndex + 1 %>">
                                        <asp:Repeater ID="Repeater4" runat="server">
                                            <ItemTemplate>
                                                <option value="<%# Eval("ID") %>"><%# Eval("Name") %></option>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </select>
                                    <div class="input-group-append">
                                        <label class="input-group-text" for="inputGroupSelect02">Team 2</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-2 d-flex justify-content-center">
                                <asp:Button runat="server" Text="Erstellen" OnClick="SpielErst_Click" class="btn btn-info" />
                            </div>
                        </div>
                        <%}%>
                    </div>
                </div>
            </div>

        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
