<%
	Case "Find"
		if fDebugMode Then Response.Write "DEBUG: Detected <b>Find</b> command...<br>" & Chr(13)
		Session(strRSName & "_PageSize") = 1 'So we don't do standard page conversion
		if fDebugMode Then Response.Write "DEBUG: Bookmark = " & CLng(Request("Bookmark")) & "<br>" & Chr(13)
		Session(strRSName & "_AbsolutePage") = CLng(Request("Bookmark"))
		if fDebugMode Then Response.Write "DEBUG: Invoking " & strBasePageName & "Form.asp...<br>" & Chr(13)
		Response.Redirect strBasePageName & "Form.asp"
%>
