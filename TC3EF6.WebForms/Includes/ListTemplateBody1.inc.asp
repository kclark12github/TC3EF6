<% Response.Write "<FORM ACTION=""" & strBasePageName & "Form.asp"" METHOD=""POST"">" %>
<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=0 BORDER=0>
	<TR>
		<TH NOWRAP BGCOLOR=Silver ALIGN=Left BACKGROUND="/Images/<%=Theme%>/Navigation/Nav1.jpg" >
			<FONT SIZE=6>&nbsp;<%=strPageTitle%></FONT>
		</TH>
	</TR>
	<TR>
		<TD BGCOLOR=#FFFFCC>
			<FONT SIZE=-1>&nbsp;&nbsp;
<% 
'			If IsEmpty(Session(strDFName & "_Filter")) Or Session(strDFName & "_Filter")="" Then
'				Response.Write "Current Filter: None<BR>"
'			Else
'				Response.Write "Current Filter: " & Session(strDFName & "_FilterDisplay") & "<BR>"
'			End If 
%>
<%
fHideNavBar = False
fHideNumber = False
fHideRequery = False
fHideRule = False
stQueryString = ""
fEmptyRecordset = False
fFirstPass = True
fNeedRecordset = False
fNoRecordset = False
tBarAlignment = "Center"
tHeaderName = strDFName
tPageSize = Session("RowsToDisplay")
tPagingMove = ""
tRangeType = "Table"
tRecordsProcessed = 0
tPrevAbsolutePage = 0
intCurPos = 0
intNewPos = 0
fSupportsBookmarks = True
fMoveAbsolute = False

If Not IsEmpty(Request(strDFName & "_PagingMove")) Then
    tPagingMove = Trim(Request(strDFName & "_PagingMove"))
End If

If IsEmpty(Session(strDFName & "_Recordset")) Then
    fNeedRecordset = True
Else
    If Session(strDFName & "_Recordset") Is Nothing Then
        fNeedRecordset = True
    End If
End If
If Not fNeedRecordset and fForceReadRecordset Then fNeedRecordset = True

If fNeedRecordset Then
    Set cmdTemp = Server.CreateObject("ADODB.Command")
    Set Session(strDFName & "_Recordset") = Server.CreateObject("ADODB.Recordset")
    cmdTemp.CommandText = SQLstatement
    If fDebugMode Then Response.Write "DEBUG: SQL Statement: """ & cmdTemp.CommandText & """...<br>" & CHR(13)
	cmdTemp.CommandType = 1
    Set cmdTemp.ActiveConnection = Session("KFC")
    Session(strDFName & "_Recordset").Open cmdTemp, , 1, 3
End If
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
		Response.Write "Current Filter: <FONT COLOR=Red>Error encountered attempting filter - filter ignored</FONT><BR>"
    Else
		Response.Write "Current Filter: " & Session(strDFName & "_FilterDisplay") & "<BR>"
    End If
    If Session(strDFName & "_Recordset").BOF And Session(strDFName & "_Recordset").EOF Then fEmptyRecordset = True
    On Error Goto 0
Else
	Response.Write "Current Filter: None<BR>"
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
            If fNeedRecordset Or fMoveAbsolute Or Session(strDFName & "_Recordset").EOF Or Not fSupportsMovePrevious Then
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
            </FONT>
        </TD>
    </TR></TABLE>
</FORM>
<!-- #include virtual="/Includes/TopNavBar.inc.asp"-->

<!----------------------------- List Section --------------------------------->

<TABLE CELLSPACING=0 CELLPADDING=0 BORDER=0 WIDTH=100% >
<TR>
<TD WIDTH=20>&nbsp;</TD>
<TD>
<TABLE CELLSPACING=1 CELLPADDING=1 BORDER=0 WIDTH=100% >
	<TR BGCOLOR=SILVER VALIGN=TOP>
		<TD ALIGN=Center><FONT SIZE=-1>&nbsp;#&nbsp;</FONT></TD>
