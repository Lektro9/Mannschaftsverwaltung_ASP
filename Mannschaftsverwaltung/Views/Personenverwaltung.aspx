<%@ Page Title="Personenverwaltung" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personenverwaltung.aspx.cs" Inherits="Mannschaftsverwaltung._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Page.Title %></h2>

    <div class="row">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>Fussballspieler</asp:ListItem>
            <asp:ListItem>Handballspieler</asp:ListItem>
            <asp:ListItem>Tennisspieler</asp:ListItem>
        </asp:RadioButtonList>

    </div>
    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
    <p>Current server time: <% =GetTime()%>
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
    </p>



    <script runat="server"> 
        protected String GetTime()
        {
            return DateTime.Now.ToString("t");
        }
    </script>
</asp:Content>
