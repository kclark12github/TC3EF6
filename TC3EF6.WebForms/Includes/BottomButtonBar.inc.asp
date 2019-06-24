<%
If fDebugMode Then Response.Write "DEBUG: strFormMode is """ & strFormMode & """<br>" & CHR(13)
If strFormMode <> "List" Then
	Response.Write "<table width=""100%""><tr><td align=""center"">" & CHR(13)
	Response.Write "<tr><td></td></tr>" & CHR(13)
	Response.Write "<tr><td align=""center"">" & CHR(13)
	Select Case strFormMode
		Case "Edit"	
			If tPageSize > 0 and (fNoUpdateButton = "" or Not fNoUpdateButton) Then Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE="" Update "">"
			If tPageSize > 0 and (fNoDeleteButton = "" or Not fNoDeleteButton) Then Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE="" Delete "">"
			If (fNoNewButton = "" or Not fNoNewButton) Then Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE=""  New  "">"
			If (fNoFilterButton = "" or Not fNoFilterButton) Then Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE="" Filter "">"
			If (fNoAllRecordsButton = "" or Not fNoAllRecordsButton) and Session(tHeaderName & "_Filter") <> "" Then Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE=""All Records"">"
		Case "Filter"
			Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE="" Apply "">"
			Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE="" Cancel "">"
		Case "New"
			Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE="" Insert "">"
			Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE="" Cancel "">"
		Case "FeedBack"
			If (fNoNewButton = "" or Not fNoNewButton) Then Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE=""  New  "">"
			If (fNoFilterButton = "" or Not fNoFilterButton) Then Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE="" Filter "">"
			If (fNoAllRecordsButton = "" or Not fNoAllRecordsButton) and Session(tHeaderName & "_Filter") <> "" Then Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE=""All Records"">"
	End Select
	
	On Error Resume Next
	ListFileExists = True
	Set fs = CreateObject("Scripting.FileSystemObject")
	Set a = fs.OpenTextFile(Server.MapPath(strBasepageName & "List.asp"), ForReading, FALSE)
	If Err.Number <> 0 Then
		ListFileExists = False
	Else
		a.Close
	End If
	Set fs = Nothing
	Set a = Nothing
	On Error Goto 0

	If ((fNoListButton = "" or Not fNoListButton) and ListFileExists) Then Response.Write "<input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE=""List View"">"
	Response.Write "</td></tr></table>" & CHR(13)
End If
Response.Write "</FORM></P>" & CHR(13)	' This closes the Form continaing the data fields to be processed on the Form page
%>