	</TR>

<%
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
%>

	<TR VALIGN=TOP>
		<TD BGCOLOR=White><FONT SIZE=-1>
<%
		If tPageSize > 0 Then
			tCurRec = ((Session(strRSName & "_AbsolutePage") - 1) * tPageSize) + tRecordsProcessed
		Else
			tRecordsProcessed = tRecordsProcessed + 1
			tCurRec = tRecordsProcessed
		End If
		Response.Write "<A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & tCurRec & "</A>"
		%>

		</FONT></TD>
