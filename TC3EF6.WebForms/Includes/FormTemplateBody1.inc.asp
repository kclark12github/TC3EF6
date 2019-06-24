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
			If Not IsEmpty(Session(strDFName & "_Status")) And Session(strDFName & "_Status") <>"" Then
				Response.Write Session(strDFName & "_Status")
				Session(strDFName & "_Status") = ""
			Else
				Select Case strFormMode
					Case "Edit"
						If IsEmpty(Session(strDFName & "_Filter")) Then
							Response.Write "Current Filter: None"
						Else
							If Session(strDFName & "_Filter") <> "" Then
								Response.Write "Current Filter: " & Session(strDFName & "_FilterDisplay")
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
tHeaderName = strDFName
tPageSize = 1
tPagingMove = ""
tRangeType = "Form"
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
    Session(strDFName & "_Recordset").Filter = Session(strDFName & "_Filter")
    If Session(strDFName & "_Recordset").BOF And Session(strDFName & "_Recordset").EOF Then fEmptyRecordset = True
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

<!-- #include virtual="/Includes/TopNavBar.inc.asp"-->

<% 
Response.Write "<FORM ACTION=""" & strBasePageName & "Action.asp"" METHOD=""POST"">"  & CHR(13)
Do
    If fEmptyRecordset Then Exit Do
    If tRecordsProcessed = tPageSize Then Exit Do
    If Not fFirstPass Then
        Session(strDFName & "_Recordset").MoveNext
    Else
        fFirstPass = False
    End If
    If Session(strDFName & "_Recordset").EOF Then Exit Do
    tRecordsProcessed = tRecordsProcessed + 1

	Response.Write "<P>" & CHR(13)
	Response.Write "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2 BORDER=0>" & CHR(13)
%>