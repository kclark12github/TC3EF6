<TABLE WIDTH=100% BORDER=0 CELLSPACING=0 CELLPADDING=0>
	<TR>
		<TH NOWRAP ALIGN="Left" BGCOLOR=Silver BACKGROUND="/Images/<%=Theme%>/Navigation/Nav1.jpg">
			<FONT SIZE=6>&nbsp;<%=strPageTitle%></FONT>
		</TH>
    </TR>
	<TR>
		<TD BGCOLOR=#FFFFCC>
			<FONT SIZE=-1>&nbsp;&nbsp;
<%
			If Not IsEmpty(Session(strRSName & "_Status")) And Session(strRSName & "_Status") <>"" Then
				Response.Write Session(strRSName & "_Status")
				Session(strRSName & "_Status") = ""
			Else
				Select Case strFormMode
					Case "Edit"
						If IsEmpty(Session(strRSName & "_Filter")) Then
							Response.Write "Current Filter: None"
						Else
							If Session(strRSName & "_Filter") <> "" Then
								Response.Write "Current Filter: " & Session(strRSName & "_FilterDisplay")
							Else
								Response.Write "Current Filter: None"
							End If
						End If
					Case "Filter"
						Response.Write "Status: Ready for filter criteria"
					Case "New"
						Response.Write "Status: Ready for new record"
				End Select
			End If 
%>
			</FONT>
		</TD>
	</TR></TABLE>

<!----------------------------- Form Section ---------------------------------->

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
tHeaderName = strRSName
tPageSize = 1
tPagingMove = ""
tRangeType = "Form"
tRecordsProcessed = 0
tPrevAbsolutePage = 0
intCurPos = 0
intNewPos = 0
fSupportsBookmarks = True
fMoveAbsolute = False

If Not IsEmpty(Request(strRSName & "_PagingMove")) Then
    tPagingMove = Trim(Request(strRSName & "_PagingMove"))
End If

If IsEmpty(Session(strRSName & "_Recordset")) Then
    fNeedRecordset = True
Else
    If Session(strRSName & "_Recordset") Is Nothing Then
        fNeedRecordset = True
    End If
End If
If Not fNeedRecordset and fForceReadRecordset Then fNeedRecordset = True

If fNeedRecordset Then
    Set cmdTemp = Server.CreateObject("ADODB.Command")
    Set Session(strRSName & "_Recordset") = Server.CreateObject("ADODB.Recordset")
    cmdTemp.CommandText = SQLstatement
    cmdTemp.CommandType = 1
    Set cmdTemp.ActiveConnection = Session("adoConn")
    Session(strRSName & "_Recordset").Open cmdTemp, , 1, 3
End If
On Error Resume Next
If Session(strRSName & "_Recordset").BOF And Session(strRSName & "_Recordset").EOF Then fEmptyRecordset = True
On Error Goto 0
If Err Then fEmptyRecordset = True
Session(strRSName & "_Recordset").PageSize = tPageSize
fSupportsBookmarks = Session(strRSName & "_Recordset").Supports(8192)

If Not IsEmpty(Session(strRSName & "_Filter")) And Not fEmptyRecordset Then
    Session(strRSName & "_Recordset").Filter = Session(strRSName & "_Filter")
    If Session(strRSName & "_Recordset").BOF And Session(strRSName & "_Recordset").EOF Then fEmptyRecordset = True
End If

If IsEmpty(Session(strRSName & "_PageSize")) Then Session(strRSName & "_PageSize") = tPageSize
If IsEmpty(Session(strRSName & "_AbsolutePage")) Then Session(strRSName & "_AbsolutePage") = 1

If Session(strRSName & "_PageSize") <> tPageSize Then
    tCurRec = ((Session(strRSName & "_AbsolutePage") - 1) * Session(strRSName & "_PageSize")) + 1
    tNewPage = Int(tCurRec / tPageSize)
    If tCurRec Mod tPageSize <> 0 Then
        tNewPage = tNewPage + 1
    End If
    If tNewPage = 0 Then tNewPage = 1
    Session(strRSName & "_PageSize") = tPageSize
    Session(strRSName & "_AbsolutePage") = tNewPage
End If

If fEmptyRecordset Then
    fHideNavBar = True
    fHideRule = True
Else
    tPrevAbsolutePage = Session(strRSName & "_AbsolutePage")
    Select Case tPagingMove
        Case ""
            fMoveAbsolute = True
        Case "Requery"
            Session(strRSName & "_Recordset").Requery
            fMoveAbsolute = True
        Case "<<"
            Session(strRSName & "_AbsolutePage") = 1
        Case "<"
            If Session(strRSName & "_AbsolutePage") > 1 Then
                Session(strRSName & "_AbsolutePage") = Session(strRSName & "_AbsolutePage") - 1
            End If
        Case ">"
            If Not Session(strRSName & "_Recordset").EOF Then
                Session(strRSName & "_AbsolutePage") = Session(strRSName & "_AbsolutePage") + 1
            End If
        Case ">>"
            If fSupportsBookmarks Then
                Session(strRSName & "_AbsolutePage") = Session(strRSName & "_Recordset").PageCount
            End If
    End Select
    Do
		On Error Resume Next
        If fSupportsBookmarks and IsEmpty(Session(strRSName & "_Filter")) Then
            Session(strRSName & "_Recordset").AbsolutePage = Session(strRSName & "_AbsolutePage")
        Else
            If fNeedRecordset Or fMoveAbsolute Or Session(strRSName & "_Recordset").EOF Or Not fSupportsMovePrevious Then
                Session(strRSName & "_Recordset").MoveFirst
                '	Session(strRSName & "_Recordset").Move (Session(strRSName & "_AbsolutePage") - 1) * tPageSize
           		For i = 1 to ((Session(strRSName & "_AbsolutePage") - 1) * tPageSize)
					Session(strRSName & "_Recordset").MoveNext
				Next
            Else
                intCurPos = ((tPrevAbsolutePage - 1) * tPageSize) + tPageSize
                intNewPos = ((Session(strRSName & "_AbsolutePage") - 1) * tPageSize) + 1
                '	Session(strRSName & "_Recordset").Move intNewPos - intCurPos
           		For i = 1 to (intNewPos - intCurPos)
					Session(strRSName & "_Recordset").MoveNext
				Next
            End If
            If Session(strRSName & "_Recordset").BOF Then Session(strRSName & "_Recordset").MoveNext
        End If
        If Not Session(strRSName & "_Recordset").EOF Then Exit Do
        Session(strRSName & "_AbsolutePage") = Session(strRSName & "_AbsolutePage") - 1
    Loop
End If
%>

<!-- #include virtual="/Includes/TopNavBar.inc.asp"-->

<% 
Response.Write "<FORM ACTION=""" & strBasePageName & "Action.asp"" METHOD=""POST"">"  & CHR(13)
Do
    If fEmptyRecordset Then Exit Do
    If tRecordsProcessed = tPageSize Then Exit Do
    If Not fFirstPass Then
        Session(strRSName & "_Recordset").MoveNext
    Else
        fFirstPass = False
    End If
    If Session(strRSName & "_Recordset").EOF Then Exit Do
    tRecordsProcessed = tRecordsProcessed + 1

	Response.Write "<P>" & CHR(13)
	Response.Write "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2 BORDER=0>" & CHR(13)
%>