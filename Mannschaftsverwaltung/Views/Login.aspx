<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mannschaftsverwaltung.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/vue/dist/vue.js"></script>
    <script src="https://unpkg.com/vuex"></script>
    <h1 class="mt-2"><%: Page.Title %></h1>
    <!-- form card login -->
    <div class="card rounded shadow shadow-sm">
        <div class="card-header">
            <h3 class="mb-0">Bitte Anmeldedaten eingeben</h3>
        </div>
        <div class="card-body">
            <% if (this.Verwalter.ActiveUser == null)
                { %>
            <div class="form-group">
                <label for="uname1">Username</label>
                <input type="text" class="form-control form-control-lg rounded-0" name="uname1" id="uname1" required="">
                <div class="invalid-feedback">Oops, you missed this one.</div>
            </div>
            <div class="form-group">
                <label>Password</label>
                <input type="password" class="form-control form-control-lg rounded-0" id="pwd1" required="" autocomplete="new-password" name="password">
                <div class="invalid-feedback">Enter your password too!</div>
            </div>
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="login_Click" class="btn btn-success mt-2" />
            <% } %>
            <% else
                { %>
            <p class="text-monospace">Sie sind eingeloggt! Zum Ausloggen den Knopf "Logout" drücken</p>
            <asp:Button ID="ButtonLogOut" runat="server" Text="Logout" OnClick="logout_Click" class="btn btn-warning mt-2" />
            <% } %>
        </div>
        <!--/card-block-->
    </div>
    <!-- /form card login -->
    <h1>Vue Demo #1</h1>
    <div id="vapp">
        <p>Hello World.  [[ timesClicked ]]</p>
        <div v-on:click="timesClicked += 1">Click me</div>
    </div>

    <script type="text/javascript"> 
        const vueApp = new Vue({
            el: '#vapp',
            delimiters: ['[[',']]'],
            data: {
                timesClicked: 0
            },
        });
    </script>

</asp:Content>
