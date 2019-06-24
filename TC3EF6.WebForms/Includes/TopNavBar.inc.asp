<%
tBarAlignment = "Center"
If tPageSize > 0 Then
	Response.Write "        <TABLE WIDTH=""100%"">" & Chr(13)
	Response.Write "        <TR>" & Chr(13)
	Response.Write "            <TD VALIGN=""Bottom"" ALIGN=Left>" & Chr(13)
	Response.Write "                <FONT SIZE=2>" & Chr(13)
	
	If blnShowUserName Then
		Response.Write "&nbsp;&nbsp;<b>" & Session("FirstName") & " " & Session("LastName") & "</b>"
		If Session("Owner") Then 
			Response.Write " (Owner)"
		End If
	End If
	Response.Write Chr(13)
	Response.Write "                </FONT>" & Chr(13)
	Response.Write "            </TD>" & Chr(13)
	
    If Not fHideNavBar Then
		Response.Write "            <TD VALIGN=""Bottom"" ALIGN=Right>" & Chr(13)
		Response.Write "                <FONT SIZE=2>" & Chr(13)
		If Not fHideNumber Then
			If tPageSize > 1 Then
				Response.Write "Page: <b>" & Session(tHeaderName & "_AbsolutePage") & "</b>" & Chr(13)
			Else
				Response.Write "Record: <b>" & Session(tHeaderName & "_AbsolutePage") & "</b>" & Chr(13)
			End If
		End If
		
		Response.Write "                </FONT>" & Chr(13)
		Response.Write "            </TD>" & Chr(13)
		Response.Write "		</tr>" & Chr(13)
		Response.Write "		<tr>" & Chr(13)
		Response.Write "            <TD colspan=2 align=center>" & Chr(13)
		Response.Write "                <P VALIGN=MIDDLE ALIGN=" & tBarAlignment & ">" & Chr(13)

		strURL = Request.ServerVariables("PATH_INFO")
		if fDebugMode Then Response.Write "DEBUG: Encoded strURL: """ & strURL & """<br>" & Chr(13)

		' Filter out spaces in long filenames with the %20 escape sequence...
		i = InStr(strURL, " ")
		Do While (i > 0)
			strURL = Mid(strURL, 1, i-1) & "%20" & Mid(strURL, i + 1)
			i = InStr(strURL, " ")
		Loop
		if fDebugMode Then Response.Write "DEBUG: Encoded strURL: """ & strURL & """<br>" & Chr(13)

		Response.Write "                <FORM ACTION=""" & strURL & stQueryString & """" & " METHOD=""POST"">" & Chr(13)
		Response.Write "<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE=""   &lt;&lt;   "">"
		Response.Write "<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE=""   &lt;    "">"
		If Not fHideRequery Then
			Response.Write "<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE="" Requery "">"
		End If
		Response.Write "<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE=""   &gt;    "">"
		If fSupportsBookmarks Then
			Response.Write "<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE=""   &gt;&gt;   "">"
		End If
		Response.Write "					<br>" & Chr(13)
		If InStr(Request.ServerVariables("PATH_INFO"), "List.asp") Then
			If Not fNoFilterButton Then
				Response.Write "<INPUT TYPE=""Submit"" NAME=""DataAction"" VALUE="" Filter "">"
			End If
			If Not fNoNewButton Then
				Response.Write "<INPUT TYPE=""Submit"" NAME=""DataAction"" VALUE="" New "">"
			End If
		End If
		Response.Write Chr(13)
		Response.Write "                </FORM>" & Chr(13)
		Response.Write "                </P>" & Chr(13)
		Response.Write "            </TD>" & Chr(13)
    End If
	Response.Write "        </TR>" & Chr(13)
	Response.Write "        </TABLE>" & Chr(13)
    If Not fHideRule Then Response.Write "<HR>" & Chr(13)
End If
%>

