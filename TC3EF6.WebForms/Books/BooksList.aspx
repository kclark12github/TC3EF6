<%@ Page Title="Books List (DataTables)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BooksList.aspx.cs" Inherits="TC3EF6.WebForms.Books.BooksList" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<%
    //bool DebugMode = false;
    //string DFName = "rsBooks";
    //string SQLstatement = "Select [Books].*,[Locations].[OName] As [Location] From [Books] Inner Join [Locations] On [Books].[LocationID]=[Locations].[ID] Order By [AlphaSort];";
    string Theme = "brown";
    string TableStyle = @"style=""width:100%;border-collapse:collapse;border-spacing:0px;font-family:Arial;""";
    string HeaderStyle = $@"style=""background-image:url(/Images/{Theme}side/Navigation/Nav1.jpg);""";
    string DetailStyle = $@"style=""color:{Theme};""";   // $@"background-image:url(/Images/{Theme}/Background/BACK2.jpg);";
%>
<style>
    /* Using jquery.dataTables.css with bootstrap4 screws up the padding on pagination 
       links, however not including it removes the selected row behavior. The following
       styles were extracted from jquery.dataTables.css in an effort to restore that
       selection behavior.
    */
    table.dataTable tbody tr.selected {
        background-color: #B0BED9;
    }
    table.dataTable.stripe tbody tr.odd.selected, table.dataTable.display tbody tr.odd.selected {
        background-color: #acbad4;
    }
    table.dataTable.hover tbody tr:hover.selected, table.dataTable.display tbody tr:hover.selected {
        background-color: #000080;
    }
</style>
    <table id="BaseTable" border="0" <%=TableStyle%> title="<%=Page.Title%>">
        <tr><th <%=HeaderStyle%>><%=Page.Title%></th></tr>
        <tr><td>
            <div class="card bg-dark" id="list-panel">
                <div class="card-header">
                    <div class="row align-items-center" style="padding-left:25px;padding-right:25px">
<%--                        <div class="col">
                            <h1 class="card-title list-panel-title"><%= Page.Title %></h1>
                        </div>--%>
                        <div class="col-auto">
                            <button type="button" class="btn btn-secondary btn-sm" data-toggle="modal" data-target="#newModal" id="new-button">
                                <span class="fas fa-plus-square mr-1"></span><span>New</span>
                            </button>
                            <button type="button" class="btn btn-secondary btn-sm" data-toggle="modal" data-target="#filterModal" id="filter-button">
                                <span class="fas fa-filter mx-2"></span><span>Filter</span>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <table id="books-data-table" 
                        class="table table-responsive-xl table-striped table-bordered table-hover compact order-column"
                        style="max-width:none;overflow-x:visible,scroll;background-color:white;color:navy;"></table>
                </div>
            </div>
        </td></tr>
    </table>
    <asp:PlaceHolder runat="server">
        <%: Styles.Render("~/Content/datatables") %>
        <%: Scripts.Render("~/bundles/datatables") %>
    </asp:PlaceHolder>
    <script type="text/javascript">
        var bookListVM;
        $(function () {
            bookListVM = {
                dt: null,
                init: function () {
                    dt = $('#books-data-table').DataTable({
                        "ajax": {
                            "url": "BooksList.aspx/GetData",
                            "contentType": "application/json",
                            "type": "GET",
                            "dataType": "JSON",    
                            "data": function (data) {
                                //data.ID = $("#ID").val();
                                //data.AlphaSort = $("#AlphaSort").val();
                                //data.Title = $("#Title").val();
                                //data.Author = $("#Author").val();
                                //data.Media = $("#Media").val();
                                //data.ISBN = $("#ISBN").val();
                                //data.Location = $("#Location").val();
                                //data.AlphaSort = $("#AlphaSort").val();
                                //data.Title = $("#Title").val();
                                //data.Author = $("#Author").val();
                                //data.MediaFormat = $("#MediaFormat").val();
                                //data.ISBN = $("#ISBN").val();
                                //data.Location = $("#Location.Name").val();
                                //data.DateVerified = parseMSDate($("#DateVerified").val());
                                //data.DatePurchased = parseMSDate($("#DatePurchased").val());
                                return data;
                            },
                            "dataSrc": function (json) {
                                json.draw = json.d.Draw;
                                json.recordsTotal = json.d.RecordsTotal;
                                json.recordsFiltered = json.d.RecordsFiltered;
                                json.data = json.d.Data;
                                var return_data = json;
                                return return_data.data;
                            }
                        },
                        "buttons": ['copy', 'excel', 'pdf', 'colvis'],
                        "colReorder": true,
                        "columnDefs": [
                            { defaultContent: "<i>Null</i>", "targets": "_all" },
                            { visible: false, "targets": [0] }, { visible: true, "targets": "_all" },
                            { className: "text-nowrap", "targets": [2, 3] },
                            { "targets": [4, 6], className: "text-right", render: $.fn.dataTable.render.number(',', '.', 2, '$') },
                            //{ "targets": [5, 7], render: $.fn.dataTable.render.moment('MM/DD/YYYY') }
                            { "targets": [5, 7], className: "text-right", "render": function(value) {
                                    if (value === null) return "";
                                    var pattern = /Date\(([^)]+)\)/;
                                    var results = pattern.exec(value);
                                    var dt = new Date(parseFloat(results[1]));
                                    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();}
                            }
                        ],
                        "columns": [
                            { "title": "GUID-ID", "data": "ID" },
                            { "title": "ID", "data": "OID" },
                            { "title": "AlphaSort", "data": "AlphaSort" },
                            //{ "title": "WishList",          "data": "WishList" },
                            //{ "title": "Title",             "data": "Title" },
                            //{ "title": "Author",            "data": "Author" },
                            //{ "title": "ISBN",              "data": "ISBN" },
                            //{ "title": "Media",             "data": "MediaFormat" },
                            //{ "title": "Cataloged",         "data": "Cataloged" },
                            //{ "title": "Subject",           "data": "Subject" },
                            { "title": "Location", "data": "Location.Name" },
                            //{ "title": "Physical Location", "data": "Location.PhysicalLocation" },
                            //{ "title": "Inventoried",       "data": "DateInventoried" },
                            { "title": "Value", "data": "Value" },
                            { "title": "Verified", "data": "DateVerified" },
                            { "title": "Price", "data": "Price" },
                            { "title": "Purchased", "data": "DatePurchased" },
                       //     { "title": "Miscellaneous",     "data": "Misc" }
                       ],
                        "displayStart": 0, "pageLength": 10,
                        //"dom": 'Blfiprtip',
                        //"dom": '<"top"Blfir>pt<"bottom"ip><"clear">',                        
                        //"searching": true,
                        //"dom": "<'row'<'col-sm-12'tr>>" +
                        //    "<'row'<'col-sm-4'l><'col-sm-8'p>>",
                        "dom": "<'row'<'col'l><'col'i><'col'p>>" +
                            "<'row'<'col'r><'col-sm-12'f>>" +
                            "<'row'<'col't>>" +
                            "<'row'<'col'B><'col'i><'col'p>>",
                        //"fixedHeader": { "footer": true },
                        "lengthMenu": [[10, 25, 50, 100, 1000, -1], [10, 25, 50, 100, 1000, "All"]],
                        //"pagingType": "full_numbers",
                        "processing": true,
                        "responsive": true,
                        //"scrollY": "50vH",
                        "scroller": true,
                        "select": { style: 'single' },
                        "serverSide": true,
                    });
                },
                refresh: function () {
                    dt.ajax.reload();
                },
                //adjustButtonPadding: function () {
                //    $('.paginate_button').css("padding", "0em");
                //}
            }

            $('#btnPerformFilter').on("click", bookListVM.refresh); // Modal Filter button click handler
            bookListVM.init();  // initialize the datatables
            //bookListVM.adjustButtonPadding();   //Override padding style on pagination buttons

            var table = $('#books-data-table').DataTable();
            //$('#books-data-table tbody').on('click', 'tr', function () {
            //    var data = table.row(this).data();
            //    console.log(`You clicked on ID #${data['ID']}; AlphaSort "${data['AlphaSort']}"`);
            //    if ($(this).hasClass('selected')) {
            //        $(this).removeClass('selected');
            //    } else {
            //        table.$('tr.selected').removeClass('selected');
            //        $(this).addClass('selected');
            //    }
            //});
            var table = $('#books-data-table').DataTable();
            $('#books-data-table tbody').on('dblclick', 'tr', function () {
                var data = table.row(this).data();
                //alert(`You clicked on ID #${data['ID']}; AlphaSort "${data['AlphaSort']}"`);
                location.href = `<%= DetailURL %>?ID=${data['ID']}`;
            });
        });
    </script>
</asp:Content>
