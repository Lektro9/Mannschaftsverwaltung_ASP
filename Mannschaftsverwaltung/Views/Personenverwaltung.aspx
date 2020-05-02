<%@ Page Title="Personenverwaltung" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personenverwaltung.aspx.cs" Inherits="Mannschaftsverwaltung._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <svg id="svg" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="0" height="0" viewBox="0, 0, 400,400">
        <defs>
            <g id="gregor">
                <path id="path0" d="M227.418 2.857 C 226.537 4.429,224.726 10.000,223.395 15.238 C 222.064 20.476,217.417 29.048,213.068 34.286 L 205.161 43.810 207.515 29.524 C 208.810 21.667,209.208 15.238,208.401 15.238 C 200.986 15.238,146.744 31.344,141.450 35.117 C 125.820 46.258,110.476 60.711,110.476 64.291 C 110.476 66.398,108.507 69.339,106.100 70.827 C 102.897 72.806,102.429 68.210,104.355 53.689 C 106.783 35.388,106.457 34.132,100.160 37.526 C 84.215 46.120,60.952 82.398,60.952 98.671 C 60.952 113.254,53.644 110.530,49.496 94.401 C 47.191 85.433,44.836 76.416,44.265 74.364 C 41.746 65.312,29.218 93.695,27.013 113.452 L 24.582 135.238 19.860 122.145 C 9.344 92.988,3.232 138.204,13.361 170.218 C 15.599 177.290,14.798 178.219,7.996 176.440 C -2.088 173.803,-2.192 173.128,11.568 199.649 C 23.337 222.332,23.953 229.766,13.333 220.952 C -1.089 208.983,4.587 231.615,20.021 247.619 C 25.072 252.857,34.516 261.166,41.007 266.083 C 53.393 275.466,53.642 276.932,53.713 340.952 C 53.718 345.335,59.447 352.617,67.200 358.095 C 74.613 363.333,86.329 372.339,93.237 378.108 C 109.304 391.526,129.648 400.000,145.793 400.000 C 158.609 400.000,248.437 363.716,250.794 357.588 C 251.492 355.772,256.447 354.286,261.805 354.286 C 282.844 354.286,350.476 306.476,350.476 291.604 C 350.476 289.008,353.068 281.689,356.236 275.339 C 368.272 251.212,377.035 160.858,368.518 148.699 L 362.875 140.642 359.999 149.368 C 357.775 156.115,356.508 152.909,354.415 135.238 C 352.925 122.667,350.601 108.952,349.250 104.762 C 347.898 100.571,348.325 87.714,350.198 76.190 C 353.892 53.463,350.658 45.278,341.114 53.199 C 332.027 60.740,333.445 49.021,343.105 36.741 C 356.292 19.976,329.153 12.389,299.971 24.683 C 294.562 26.962,293.463 25.776,294.256 18.514 C 295.450 7.583,284.630 7.888,264.201 19.362 C 248.109 28.401,243.843 28.534,243.688 20.000 C 243.480 8.560,231.375 -4.195,227.418 2.857 M96.763 182.466 C 91.226 217.093,107.560 235.037,117.708 205.476 L 123.512 188.571 126.020 207.898 C 130.746 244.321,148.571 268.513,148.571 238.505 C 148.571 219.827,152.406 219.473,161.605 237.302 C 170.852 255.225,170.530 259.048,159.775 259.048 C 151.620 259.048,151.348 259.541,154.693 268.260 C 155.965 271.574,161.108 274.286,166.122 274.286 C 172.625 274.286,175.238 276.418,175.238 281.726 C 175.238 308.916,195.194 316.288,206.661 293.333 C 213.129 280.385,213.322 280.296,213.327 290.251 C 213.331 295.890,214.868 301.451,216.744 302.610 C 221.709 305.679,225.128 294.213,222.441 283.507 C 221.065 278.027,221.791 274.286,224.229 274.286 C 226.486 274.286,227.256 271.480,225.940 268.052 C 222.167 258.218,233.476 263.822,239.128 274.587 C 254.876 304.579,238.863 356.660,211.073 365.832 C 204.160 368.113,188.370 374.889,175.983 380.889 C 146.437 395.201,116.343 392.072,104.861 373.494 C 103.407 371.141,95.577 365.024,87.463 359.901 C 65.028 345.739,63.356 340.087,62.297 274.820 C 61.234 209.250,64.758 193.758,84.521 177.129 C 99.190 164.785,99.565 164.949,96.763 182.466 M70.495 236.160 C 69.136 238.358,72.290 240.000,77.870 240.000 C 89.502 240.000,90.645 247.706,80.000 254.354 C 72.151 259.256,69.464 270.476,76.139 270.476 C 78.206 270.476,82.405 276.476,85.469 283.810 C 93.333 302.630,107.955 297.193,111.081 274.286 C 111.805 268.982,114.890 264.762,118.043 264.762 C 121.157 264.762,124.212 262.130,124.831 258.913 C 126.788 248.754,75.885 227.438,70.495 236.160 M277.179 309.150 C 276.194 319.400,274.283 328.892,272.932 330.242 C 267.701 335.473,266.562 327.917,270.171 311.931 C 272.571 301.301,272.611 294.774,270.280 293.960 C 268.266 293.258,267.605 291.087,268.811 289.136 C 274.126 280.537,278.844 291.822,277.179 309.150 M111.238 309.333 C 105.836 314.735,105.119 327.619,110.219 327.619 C 112.174 327.619,114.860 324.190,116.190 320.000 C 117.520 315.810,120.207 312.381,122.161 312.381 C 124.116 312.381,125.714 310.667,125.714 308.571 C 125.714 303.316,116.785 303.786,111.238 309.333 M259.048 333.333 C 259.048 339.541,256.916 342.857,252.926 342.857 C 248.909 342.857,247.599 340.786,249.116 336.831 C 250.388 333.517,251.429 329.231,251.429 327.307 C 251.429 325.384,253.143 323.810,255.238 323.810 C 257.333 323.810,259.048 328.095,259.048 333.333 M138.095 349.495 C 108.832 350.888,99.169 358.125,126.667 358.053 C 149.025 357.995,171.429 353.954,171.429 349.978 C 171.429 348.157,170.143 347.007,168.571 347.424 C 167.000 347.840,153.286 348.772,138.095 349.495 " stroke="none" fill="#000000" fill-rule="evenodd"></path>
            </g>
        </defs>
    </svg>

    <h2 class="mt-2"><%: Page.Title %></h2>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="list-group">
        <asp:ListItem class="list-group-item list-group-item-action" Value="Fussballspieler">Fussballspieler<svg width="90" height="30" viewBox="0, 0, 1200,400"><use id="Layer-1" href="#gregor" /></svg></asp:ListItem>
        <asp:ListItem class="list-group-item list-group-item-action" Value="Handballspieler">Handballspieler</asp:ListItem>
        <asp:ListItem class="list-group-item list-group-item-action" Value="Tennisspieler">Tennisspieler</asp:ListItem>
        <asp:ListItem class="list-group-item list-group-item-action" Value="Trainer">Trainer</asp:ListItem>
        <asp:ListItem class="list-group-item list-group-item-action" Value="Physiotherapeut">Physiotherapeut</asp:ListItem>
    </asp:RadioButtonList>



    <asp:Button ID="Button2" runat="server" Text="auswählen" OnClick="Button2_Click" class="btn btn-success" />


    <div class="row justify-content-center">
        <div class="col-md-6">
            <span class="anchor" id="formUserEdit"></span>
            <hr class="my-5">
            <!-- form user info -->
            <div class="card card-outline-secondary">
                <div class="card-header">
                    <h3 class="mb-0">Personenbezogene Daten</h3>
                </div>
                <div class="card-body">
                    <div class="form-group row">
                        <label class="col-lg-3 col-form-label form-control-label">Name</label>
                        <div class="col-lg-9">
                            <input class="form-control" id="name" type="text" name="name" value="" runat="server" disabled />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-3 col-form-label form-control-label">Vorname</label>
                        <div class="col-lg-9">
                            <input class="form-control" id="vorname" type="text" name="vorname" value="" runat="server" disabled />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-3 col-form-label form-control-label">Geburtstag</label>
                        <div class="col-lg-9">
                            <input class="form-control" id="geburtstag" type="date" name="geburtstag" value="" runat="server" disabled />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-3 col-form-label form-control-label">Position</label>
                        <div class="col-lg-9">
                            <input class="form-control" id="position" type="text" name="position" value="" runat="server" disabled />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-3 col-form-label form-control-label">erzielte Tore</label>
                        <div class="col-lg-9">
                            <input class="form-control" id="geschosseneTore" type="number" name="geschosseneTore" value="" runat="server" disabled />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-3 col-form-label form-control-label">Erfahrung in Jahren</label>
                        <div class="col-lg-9">
                            <input class="form-control" id="anzahlJahre" type="number" name="anzahlJahre" value="" runat="server" disabled />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-3 col-form-label form-control-label">Spiele gewonnen</label>
                        <div class="col-lg-9">
                            <input class="form-control" id="gewonneneSpiele" type="number" name="gewonneneSpiele" value="" runat="server" disabled />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-3 col-form-label form-control-label">Anzahl der Vereine</label>
                        <div class="col-lg-9">
                            <input class="form-control" id="anzahlVereine" type="number" name="anzahlVereine" value="" runat="server" disabled />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-3 col-form-label form-control-label">Anzahl der Spiele</label>
                        <div class="col-lg-9">
                            <input class="form-control" id="anzahlSpiele" type="number" name="anzahlSpiele" value="" runat="server" disabled />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-3 col-form-label form-control-label">Schläger</label>
                        <div class="col-lg-9">
                            <input class="form-control" id="schlaeger" type="text" name="schlaeger" value="" runat="server" disabled />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-3 col-form-label form-control-label">Aufschlaggeschwindigkeit:</label>
                        <div class="col-lg-9">
                            <input class="form-control" id="aufschlagGeschw" type="number" name="aufschlagGeschw" value="" runat="server" disabled />
                        </div>
                    </div>
                </div>
            </div>
            <!-- /form user info -->
        </div>
    </div>


    <asp:Button ID="Button3" runat="server" Text="hinzufügen" OnClick="Button3_Click" Visible="False" CssClass="btn btn-success" />
    <asp:Table ID="Table1" runat="server" class="table">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
            <asp:TableHeaderCell>
                <asp:Button ID="ButtonSortName" runat="server" OnClick="orderByName" Text="Name" CssClass="btn btn-default" />
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>Vorname</asp:TableHeaderCell>
            <asp:TableHeaderCell>
                <asp:Button ID="ButtonSortGeburtstag" runat="server" OnClick="orderByBirthday" Text="Geburtstag" CssClass="btn btn-default" />
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>Sportart</asp:TableHeaderCell>
            <asp:TableHeaderCell>Anzahl Spiele</asp:TableHeaderCell>
            <asp:TableHeaderCell>
                <asp:Button ID="ButtonSortTore" runat="server" OnClick="orderByGoals" Text="Erzielte Tore" CssClass="btn btn-default" />
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>Gewonnene Spiele</asp:TableHeaderCell>
            <asp:TableHeaderCell>Anzahl Jahre</asp:TableHeaderCell>
            <asp:TableHeaderCell>Anzahl Vereine</asp:TableHeaderCell>
            <asp:TableHeaderCell>Einsatzbereich</asp:TableHeaderCell>
            <asp:TableHeaderCell>Edit</asp:TableHeaderCell>
            <asp:TableHeaderCell>Del</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <script type="text/javascript"> 
        $(document).ready(function () {
            $('span').click(function () {
                $('span.list-group-item.active').removeClass("active");
                $(this).addClass("active");
                $(this).children('input').prop("checked", true);
                console.log("hi");
            });
        });
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
