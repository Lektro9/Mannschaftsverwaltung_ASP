<%@ Page Title="Spiele" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Spiele.aspx.cs" Inherits="Mannschaftsverwaltung.Spiele" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<h2><%: Page.Title %></h2>--%>

    <!-- Mannschaften auswählen -->
<h2 class="text-center mt-4">Aktuelle Ligaspiele</h2>
<div class="container">
  <div class="row rowcustom">

    <div class="col-5">
      <div class="input-group-prepend d-flex justify-content-between">
        <span class="input-group-text">Karasuno High</span>
        <span class="input-group-text">0</span>
      </div>
    </div>

    <div class="col-5">
      <div class="input-group-prepend d-flex justify-content-between">
        <span class="input-group-text">2</span>
        <span class="input-group-text">Nekoma High</span>
      </div>
    </div>
  </div>
  
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
        <select class="custom-select" id="inputGroupSelect01">
          <option selected>Choose...</option>
          <option value="1">Karasuno High</option>
          <option value="2">Nekoma High</option>
          <option value="3">Aobajohsai High</option>
        </select>
      </div>
    </div>

    <div class="col-5 justify-content-end">
      <div class="input-group">
        <select class="custom-select" id="inputGroupSelect02">
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
      <button type="button" class="btn btn-primary">Spielen!</button>
    </div>
  </div>
</div>

</asp:Content>
