<%@ Page Title="Library - Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThemedBooksList.aspx.cs" Inherits="TC3EF6.WebForms.ThemedBooksList" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%
    //bool DebugMode = false;
    string Theme = "Brownside";
    //string DFName = "rsBooks";
    //string SQLstatement = "Select [Books].*,[Locations].[OName] As [Location] From [Books] Inner Join [Locations] On [Books].[LocationID]=[Locations].[ID] Order By [AlphaSort];";
    string TableStyle = "style='width:100%; border-collapse: collapse; border-spacing: 0px;'";
    string TableHeaderStyle = $@"style='background-color:silver;background-image:url(/Images/{Theme}/Navigation/Nav1.jpg);text-align:left;white-space:nowrap;'";
%>
<asp:ScriptManagerProxy runat="server">
    <Services>
        <asp:ServiceReference Path="~/Books/BooksService.svc" />
    </Services>
</asp:ScriptManagerProxy>
  <script type="text/javascript">
      $(document).ready(function () {
          alert("Calling GetData");
          BooksService.GetData(function (json) {
              table = $("#Records");
              header = $("<tr class='table_header'></tr>");
              $.each(Object.keys(json.d.Data[0]), function (iHdr, vHdr) {
                  header.append($("<th>" + vHdr + "</th>"));
              });
              table.append(header);

              $.each(json.d.Data, function (iRow, vRow) {
                  row = $("<tr></tr>");
                  $.each(vRow, function (iCell, vCell) {
                      var alignment = "left";
                      switch (typeof vCell) {
                          case "number":
                              alignment = "right";
                              break;
                          case "string":
                              if (vCell.length > 6 && vCell.substr(0, 6) == "/Date(") {
                                  alignment = "right";
                                  vCell = parseMSDate(vCell);
                                  break;
                              }
                          default:
                              break;
                      }
                      row.append($('<td style="text-align:' + alignment + ';">' + vCell + ' (' + typeof (vCell) + ')</td>'));
                  })
                  table.append(row);
              });
          });
<%--          $.ajax({
              "url": "<%=Request.ServerVariables["PATH_INFO"]%>/GetData",
              "type": "GET",
              "contentType": "application/json",
              "type": "GET",
              "dataType": "JSON",
              "data": function (data) { return data },
              //dataSrc: function (json) {
              //    json.draw = json.d.Draw;
              //    json.recordsTotal = json.d.RecordsTotal;
              //    json.recordsFiltered = json.d.RecordsFiltered;
              //    json.data = json.d.Data;
              //    var return_data = json;
              //    return return_data.data;
              //},
              success: function (json) {
                  table = $("#Records");
                  header = $("<tr class='table_header'></tr>");
                  $.each(Object.keys(json.d.Data[0]), function (iHdr, vHdr) {
                      header.append($("<th>" + vHdr + "</th>"));
                  })
                  table.append(header);

                  $.each(json.d.Data, function (iRow, vRow) {
                      row = $("<tr></tr>");
                      $.each(vRow, function (iCell, vCell) {
                          var alignment = "left";
                          switch (typeof vCell) {
                              case "number":
                                  alignment = "right";
                                  break;
                              case "string":
                                  if (vCell.length > 6 && vCell.substr(0, 6) == "/Date(") {
                                      alignment = "right";
                                      vCell = parseMSDate(vCell);
                                      break;
                                  }
                              default:
                                  break;
                          }
                          row.append($('<td style="text-align:' + alignment + ';">' + vCell + ' (' + typeof (vCell) + ')</td>'));
                      })
                      table.append(row);
                  })
              }
          });--%>
          function isMSDate(s) {
              var dregex = /\/Date\((\d*)\)\//;
              return dregex.test(s);
          };
          function parseMSDate(s) {
              var dregex = /\/Date\((\d*)\)\//;
              return dregex.test(s) ? new Date(parseInt(dregex.exec(s)[1])) : s;
          };
      });
</script>

<%--<%
        Dim strPagingMove
strDBName = "KFC"
strDFName = "rsBooks"
strTableName = "Books"
strBasePageName = "Books"
strPageTitle = "Library; Books"
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
RowsToDisplay = 50
MinRowsForBottomButtons = 10
blnShowUserName = True
%>--%>

<!--BEGIN include virtual="/Includes/ListTemplateTop.inc.asp"-->
<%
//string DataAction = Request["DataAction"];  //Trim
//bool ForceReadData = false;
//string PageName = null;
//if (DataAction != null) {
//    PageName = Request.ServerVariables["PATH_INFO"];
//    PageName = $@"{PageName.Substring(0, PageName.Length - 8)}Action.aspx";
//    switch (DataAction) {
//        case "Filter":
//            Response.Redirect($@"{PageName}?DataAction=Filter");
//            break;
//        case "":
//            Response.Redirect($@"{PageName}?DataAction=New");
//            break;
//        default:
//            break;
//    }
//}
%>
<!--END include virtual="/Includes/ListTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section ------------------------------->

<!-- include virtual="/Books/avarAuthors.inc.asp"-->
<!-- include virtual="/Books/avarSubjects.inc.asp"-->
<!-- include virtual="/Books/avarLocations.inc.asp"-->

<!---------------------------- Heading Section ------------------------------->
<table id="Records" border="0" <%=TableStyle%>>
</table>
<!--BEGIN include virtual="/Includes/ListTemplateBody1.inc.asp"-->
<%--<table id="xxx" border="0" <%=TableStyle%>>
	<tr>
		<th <%=TableHeaderStyle%>>
			<h2>&nbsp;<%=Page.Title%></h2>
		</th>
	</tr>
	<tr>
		<td style="color:#FFFFCC;font-size:smaller;">&nbsp;&nbsp;--%>
<% 
////    if (Session[$@"{DFName}_Filter"] == null || (string)Session[$@"{DFName}_Filter"] == "") 
////        Response.Write($@"Current Filter: None<br/>");
////    else
////        Response.Write($@"Current Filter: {(string)Session[$@"{DFName}_FilterDisplay"]}<br/>");
//bool HideNavBar = false;
//bool HideNumber = false;
//bool HideRequery = false;
//bool HideRule = false;
//string QueryString = string.Empty;
//bool EmptyRecordset = false;
//bool FirstPass = true;
//bool NeedData = false;
//bool NoRecordset = false;
//string BarAlignment = "center";
//string HeaderName = DFName;
//int PageSize = (int)Session["RowsToDisplay"];
//string PagingMove = string.Empty;
//string RangeType = "Table";
//int RecordsProcessed = 0;
//int PrevAbsolutePage = 0;
//int CurPos = 0;
//int NewPos = 0;
//bool SupportsBookmarks = true;
//bool MoveAbsolute = false;

//if (Request[$@"{DFName}_PagingMove"] != null)
//    PagingMove = ((string)Request[$@"{DFName}_PagingMove"]).Trim();
//if (Session[$@"{DFName}_Recordset"] == null)
//    NeedData = true;
//else
//    if (Session[$@"{DFName}_Recordset"] == null) NeedData = true;
//if (!(NeedData && ForceReadData)) NeedData = true;

////TODO: This should be done via AJAX...
////if (NeedData) {
////    LogMessage("ThemedBooksList.aspx", "Reading Books data...");
////    using (var context = new TCContext())
////    {
////    }
////    var context = new TCContext();
////    IQueryable<Book> query = context.Books.AsNoTracking();
////    int totalRecords = query.Count();   // Total record count.
////    // Verification.    
////    if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
////    {   // Apply search    
////        query = query.Where(b => b.AlphaSort.Contains(search)
////                                || b.Title.Contains(search)
////                                || b.Author.Contains(search)
////                                || b.MediaFormat.Contains(search)
////                                || b.ISBN.Contains(search)
////                                || b.Location.Name.Contains(search)
////                            );
////    }
////    query = query.OrderBy(b => b.AlphaSort);
////    // Sorting.    
////    //query = SortByColumnWithOrder(order, orderDir, query);
////    // Filter record count.    
////    int filteredRecords = query.Count();
////    // Apply pagination.    
////    int page = (startRec + pageSize) / pageSize;
////    result.Data = query.Skip(startRec).Take(pageSize).ToList();
////    LogMessage("BooksList.aspx/GetData", $"Read {result.Data.Count:#,##0} (page #{page:#,##0}) of {(filteredRecords == totalRecords ? $"{totalRecords:#,##0}" : $"{filteredRecords:#,##0} filtered ({totalRecords:#,##0} total)")} Books.");
////            // Loading drop down lists.   (??? )
////            result.Draw = Convert.ToInt32(draw);
////            result.RecordsTotal = totalRecords;
////            result.RecordsFiltered = filteredRecords;
////    //Set cmdTemp = Server.CreateObject("ADODB.Command")
////    //Set Session(strDFName &"_Recordset") = Server.CreateObject("ADODB.Recordset")
////    //cmdTemp.CommandText = SQLstatement;
////    if (DebugMode) Response.Write($@"DEBUG: SQL Statement: ""{SQLstatement}""...<br/>\n");

////    //cmdTemp.CommandType = 1
////    //Set cmdTemp.ActiveConnection = Session("KFC")
////    //Session(strDFName & "_Recordset").Open cmdTemp, , 1, 3
////}
%>



<%--<Script type="text/javascript">
    var response = "[{"rank":"9","content":"Alon","UID":"5"},
     {"rank":"6","content":"Tala","UID":"6"}]";

// convert string to JSON
response = $.parseJSON(response);

$(function() {
    $.each(response, function(i, item) {
        var $tr = $('<tr>').append(
            $('<td>').text(item.rank),
            $('<td>').text(item.content),
            $('<td>').text(item.UID)
        ); //.appendTo('#records_table');
        console.log($tr.wrap('<p>').html());
    });
});
</script>--%>








<%-- % Response.Write($@"<FORM ACTION=""" & strBasePageName & "Form.asp"" METHOD=""POST"">" %>
<%


On Error Resume Next
If Session(strDFName & "_Recordset").BOF And Session(strDFName & "_Recordset").EOF Then fEmptyRecordset = True
On Error Goto 0
If Err Then fEmptyRecordset = True
Session(strDFName & "_Recordset").PageSize = tPageSize
fSupportsBookmarks = Session(strDFName & "_Recordset").Supports(8192)

If Not IsEmpty(Session(strDFName & "_Filter")) And Not fEmptyRecordset Then
    On Error Resume Next
    Session(strDFName & "_Recordset").Filter = Session(strDFName & "_Filter")
    If Err Then 
        Session(strDFName & "_Filter") = ""
        Session(strDFName & "_Recordset").Filter = ""
        Session(strDFName & "_FilterDisplay") = ""
		Response.Write($@"Current Filter: <FONT COLOR=Red>Error encountered attempting filter - filter ignored</FONT><BR>"
    Else
		Response.Write($@"Current Filter: " & Session(strDFName & "_FilterDisplay") & "<BR>"
    End If
    If Session(strDFName & "_Recordset").BOF And Session(strDFName & "_Recordset").EOF Then fEmptyRecordset = True
    On Error Goto 0
Else
	Response.Write($@"Current Filter: None<BR>"
End If

If IsEmpty(Session(strDFName & "_PageSize")) Then Session(strDFName & "_PageSize") = tPageSize
If IsEmpty(Session(strDFName & "_AbsolutePage")) Then Session(strDFName & "_AbsolutePage") = 1

If Session(strDFName & "_PageSize") <> tPageSize Then
    tCurRec = ((Session(strDFName & "_AbsolutePage") - 1) * Session(strDFName & "_PageSize")) + 1
    tNewPage = Int(tCurRec / tPageSize)
    If tCurRec Mod tPageSize <> 0 Then
        tNewPage = tNewPage + 1
    End If
    If tNewPage = 0 Then tNewPage = 1
    Session(strDFName & "_PageSize") = tPageSize
    Session(strDFName & "_AbsolutePage") = tNewPage
End If

If fEmptyRecordset Then
    fHideNavBar = True
    fHideRule = True
Else
    tPrevAbsolutePage = Session(strDFName & "_AbsolutePage")
    Select Case tPagingMove
        Case ""
            fMoveAbsolute = True
        Case "Requery"
            Session(strDFName & "_Recordset").Requery
            fMoveAbsolute = True
        Case "<<"
            Session(strDFName & "_AbsolutePage") = 1
        Case "<"
            If Session(strDFName & "_AbsolutePage") > 1 Then
                Session(strDFName & "_AbsolutePage") = Session(strDFName & "_AbsolutePage") - 1
            End If
        Case ">"
            If Not Session(strDFName & "_Recordset").EOF Then
                Session(strDFName & "_AbsolutePage") = Session(strDFName & "_AbsolutePage") + 1
            End If
        Case ">>"
            If fSupportsBookmarks Then
                Session(strDFName & "_AbsolutePage") = Session(strDFName & "_Recordset").PageCount
            End If
    End Select
    Do
		On Error Resume Next
        If fSupportsBookmarks and IsEmpty(Session(strDFName & "_Filter")) Then
            Session(strDFName & "_Recordset").AbsolutePage = Session(strDFName & "_AbsolutePage")
        Else
            If fNeedData Or fMoveAbsolute Or Session(strDFName & "_Recordset").EOF Or Not fSupportsMovePrevious Then
                Session(strDFName & "_Recordset").MoveFirst
                '	Session(strDFName & "_Recordset").Move (Session(strDFName & "_AbsolutePage") - 1) * tPageSize
           		For i = 1 to ((Session(strDFName & "_AbsolutePage") - 1) * tPageSize)
					Session(strDFName & "_Recordset").MoveNext
				Next
            Else
                intCurPos = ((tPrevAbsolutePage - 1) * tPageSize) + tPageSize
                intNewPos = ((Session(strDFName & "_AbsolutePage") - 1) * tPageSize) + 1
                '	Session(strDFName & "_Recordset").Move intNewPos - intCurPos
           		For i = 1 to (intNewPos - intCurPos)
					Session(strDFName & "_Recordset").MoveNext
				Next
            End If
            If Session(strDFName & "_Recordset").BOF Then Session(strDFName & "_Recordset").MoveNext
        End If
        If Not Session(strDFName & "_Recordset").EOF Then Exit Do
        Session(strDFName & "_AbsolutePage") = Session(strDFName & "_AbsolutePage") - 1
    Loop
End If
%>
        </TD>
    </TR>
    </TABLE>
</FORM>
<!--BEGIN include virtual="/Includes/TopNavBar.inc.asp"-->
 BarAlignment = "center";
 if (PageSize > 0) {
	Response.Write($@"        <table style=""width:100%"">\n");
	Response.Write($@"        <tr>\n");
	Response.Write($@"            <td style=""text-align:left;vertical-align:Bottom;font-size:medium;"">\n");
	if (ShowUserName) Response.Write($@"&nbsp;&nbsp;<b>{Session[""FirstName""]} {Session[""LastName""]} {((bool)Session[""Owner""] ? "" (Owner)" : string.Empty)}</b>\n");
	Response.Write($@"            </td>\n");
	
    if (!HideNavBar) {
		Response.Write($@"            <td style=""text-align:right;vertical-align:Bottom;font-size:medium;"">\n");
		if (!HideNumber) {
			if (PageSize > 1)
				Response.Write($@"Page: <b>{Session[{HeaderName & "_AbsolutePage") & "</b>" & Chr(13)
			else
				Response.Write($@"Record: <b>" & Session(tHeaderName & "_AbsolutePage") & "</b>" & Chr(13)
			End If
		End If
		
		Response.Write($@"                </FONT>" & Chr(13)
		Response.Write($@"            </TD>" & Chr(13)
		Response.Write($@"		</tr>" & Chr(13)
		Response.Write($@"		<tr>" & Chr(13)
		Response.Write($@"            <TD colspan=2 align=center>" & Chr(13)
		Response.Write($@"                <P VALIGN=MIDDLE ALIGN=" & tBarAlignment & ">" & Chr(13)

		strURL = Request.ServerVariables("PATH_INFO")
		if fDebugMode Then Response.Write($@"DEBUG: Encoded strURL: """ & strURL & """<br>" & Chr(13)

		' Filter out spaces in long filenames with the %20 escape sequence...
		i = InStr(strURL, " ")
		Do While (i > 0)
			strURL = Mid(strURL, 1, i-1) & "%20" & Mid(strURL, i + 1)
			i = InStr(strURL, " ")
		Loop
		if fDebugMode Then Response.Write($@"DEBUG: Encoded strURL: """ & strURL & """<br>" & Chr(13)

		Response.Write($@"                <FORM ACTION=""" & strURL & stQueryString & """" & " METHOD=""POST"">" & Chr(13)
		Response.Write($@"<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE=""   &lt;&lt;   "">"
		Response.Write($@"<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE=""   &lt;    "">"
		If Not fHideRequery Then
			Response.Write($@"<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE="" Requery "">"
		End If
		Response.Write($@"<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE=""   &gt;    "">"
		If fSupportsBookmarks Then
			Response.Write($@"<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE=""   &gt;&gt;   "">"
		End If
		Response.Write($@"					<br>" & Chr(13)
		If InStr(Request.ServerVariables("PATH_INFO"), "List.asp") Then
			If Not fNoFilterButton Then
				Response.Write($@"<INPUT TYPE=""Submit"" NAME=""DataAction"" VALUE="" Filter "">"
			End If
			If Not fNoNewButton Then
				Response.Write($@"<INPUT TYPE=""Submit"" NAME=""DataAction"" VALUE="" New "">"
			End If
		End If
		Response.Write Chr(13)
		Response.Write($@"                </FORM>" & Chr(13)
		Response.Write($@"                </P>" & Chr(13)
		Response.Write($@"            </TD>" & Chr(13)
    End If
	Response.Write($@"        </TR>" & Chr(13)
	Response.Write($@"        </TABLE>" & Chr(13)
    If Not fHideRule Then Response.Write($@"<HR>" & Chr(13)
End If
<!--END include virtual="/Includes/TopNavBar.inc.asp"-->

<!----------------------------- List Section --------------------------------->

<TABLE CELLSPACING=0 CELLPADDING=0 BORDER=0 WIDTH=100% >
<TR>
<TD WIDTH=20>&nbsp;</TD>
<TD>
<TABLE CELLSPACING=1 CELLPADDING=1 BORDER=0 WIDTH=100% >
	<TR BGCOLOR=SILVER VALIGN=TOP>
		<TD ALIGN=Center><FONT SIZE=-1>&nbsp;#&nbsp;</FONT></TD>
--%>
<!--END include virtual="/Includes/ListTemplateBody1.inc.asp"--
		<TD ALIGN=Left><FONT SIZE=-1><B>Subject</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>AlphaSort</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Location</B></FONT></TD>
<!-- include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		//'	ShowListField "ID", Null, False
		//Response.Write($@"<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strDFName & "_Recordset")("Subject") & "</FONT></a></TD>"
		//Response.Write($@"<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strDFName & "_Recordset")("Alphasort") & "</FONT></a></TD>"
		//Response.Write($@"<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strDFName & "_Recordset")("Location") & "</FONT></a></TD>"
%>
<!-- include virtual="/Includes/ListTemplateBottom.inc.asp"-->
</asp:Content>
<asp:Content ID="FooterContent" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
