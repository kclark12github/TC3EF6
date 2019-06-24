<!-- #include virtual="/Includes/BottomButtonBar.inc.asp"-->
<%
Response.Write "<table width=""100%"">"
If tPageSize > 0 Then
    If Not fHideRule Then Response.Write "<tr><td><HR></td></tr>" & CHR(13)
    If Not fHideNavBar Then
        Response.Write "<tr><td align=""center""><FONT SIZE=2>" & CHR(13)
		If Not fHideNumber Then
			If tPageSize > 1 Then
				Response.Write "<NOBR>Page: <b>" & Session(tHeaderName & "_AbsolutePage") & "</b></NOBR>" & CHR(13)
			Else
				Response.Write "<NOBR>Record: <b>" & Session(tHeaderName & "_AbsolutePage") & "</b></NOBR>" & CHR(13)
			End If
		End If
        Response.Write "</FONT></td></tr>" & CHR(13)
        Response.Write "<tr><td align=""center""><FONT SIZE=2>" & CHR(13)
        Response.Write "<FORM " & "ACTION=""" & Request.ServerVariables("PATH_INFO") & stQueryString & """" & " METHOD=""POST"">"
        Response.Write "<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE=""   &lt;&lt;   "">"
        Response.Write "<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE=""   &lt;    "">"
		If Not fHideRequery Then
			Response.Write "<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE="" Requery "">"
        End If
        Response.Write "<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE=""    &gt;   "">"
        If fSupportsBookmarks Then
			Response.Write "<INPUT TYPE=""Submit"" NAME=""" & tHeaderName & "_PagingMove" & """ VALUE=""   &gt;&gt;   "">"
        End If
		Response.Write CHR(13) & "					<br>"
		If InStr(Request.ServerVariables("PATH_INFO"), "List.asp") Then
			If Not fNoFilterButton Then
				Response.Write "<INPUT TYPE=""Submit"" NAME=""DataAction"" VALUE="" Filter "">"
			End If
			If Not fNoNewButton Then
				Response.Write "<INPUT TYPE=""Submit"" NAME=""DataAction"" VALUE="" New "">"
			End If
		End If
        Response.Write CHR(13) & "</FORM>" & CHR(13)
        Response.Write "</FONT></td></tr>" & CHR(13)
	Else
		Response.Write "<tr><td></td></tr>" & CHR(13)
    End If
End If
Response.Write "</table>" & CHR(13)
%>
