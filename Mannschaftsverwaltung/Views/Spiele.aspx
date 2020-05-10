<%@ Page Title="Spiele" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Spiele.aspx.cs" Inherits="Mannschaftsverwaltung.Spiele" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="mt-2"><%: Page.Title %></h1>

    <%--erstellen eines Turnieres--%>

    <div class="card mt-4">
        <div class="card-header">
            <h3>Turnier erstellen</h3>
        </div>
        <div class="card-body">
            <div class="form-row">
                <div class="col-7">
                    <input type="text" id="TurnierNameEing" class="form-control" placeholder="Name des Turnieres" runat="server">
                </div>
                <div class="col">
                    <asp:Button ID="TurnierErst" runat="server" Text="Erstellen" OnClick="TurnierErst_Click" class="btn btn-success mt-2" />
                </div>
            </div>
        </div>
    </div>


    <!-- Mannschaften auswählen -->
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="ItemBound">
        <ItemTemplate>

            <div class="card mt-4">
                <div class="card-header text-center">
                    <%# Eval("Name") %>
                </div>
                <div class="card-body">
                    <div class="container">
                        <div class="row rowcustom">

                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
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
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
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
                                    <input type="number" class="form-control rightalign" name="team1goals_<%# Container.ItemIndex + 1 %>" id="example1">
                                </div>
                            </div>

                            <div class="col-5 justify-content-end">
                                <div class="input-group">
                                    <input type="number" class="form-control" name="team2goals_<%# Container.ItemIndex + 1 %>" id="example1">
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
                    </div>
                </div>
            </div>

        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
