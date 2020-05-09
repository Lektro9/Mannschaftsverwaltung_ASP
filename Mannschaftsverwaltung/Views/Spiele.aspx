<%@ Page Title="Spiele" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Spiele.aspx.cs" Inherits="Mannschaftsverwaltung.Spiele" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<h2><%: Page.Title %></h2>--%>

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
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>

            <div class="card mt-4">
                <div class="card-header">
                    <%# Eval("Name") %>
                </div>
                <div class="card-body">
                    <div class="container">
                        <div class="row rowcustom">

                            <div class="col-5">
                                <div class="input-group-prepend d-flex justify-content-between">
                                    <span class="input-group-text">Aobajohsai High</span>
                                    <span class="input-group-text">2</span>
                                </div>
                            </div>

                            <div class="col-5">
                                <div class="input-group-prepend d-flex justify-content-between">
                                    <span class="input-group-text">1</span>
                                    <span class="input-group-text">Shiratorizawa Academy</span>
                                </div>
                            </div>
                        </div>

                        <div class="row rowcustom">

                            <div class="col-5">
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <label class="input-group-text" for="inputGroupSelect01">Team 1</label>
                                    </div>
                                    <select class="custom-select" id="Select1" runat="server">
                                        <option selected>Choose...</option>
                                        <option value="1">Karasuno High</option>
                                        <option value="2">Nekoma High</option>
                                        <option value="3">Aobajohsai High</option>
                                    </select>
                                </div>
                            </div>

                            <div class="col-5 justify-content-end">
                                <div class="input-group">
                                    <select class="custom-select" id="Select2" runat="server">
                                        <option selected>Choose...</option>
                                        <option value="1">Karasuno High</option>
                                        <option value="2">Nekoma High</option>
                                        <option value="3">Aobajohsai High</option>
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
