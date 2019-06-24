<%
If strHomeGIF = "" Then 
	strHomeGIF = Application("strHomeGIF")
	strFooterGIFdim = Application("strFooterGIFdim")
End If
If strFooterURL = "" Then strFooterURL = Application("strFooterURL")
If strFooterTitle = "" Then 
	strFooterTitle = Application("strFooterTitle")
Else
	If Left(strFooterTitle, 12) <> "Back to the " Then strFooterTitle = "Back to the " & strFooterTitle
End If

Select Case strFormMode
	Case "New"
	Case "Filter"
	Case Else
		' Display a message if there are no records to show
		If fEmptyRecordset Then
			Response.Write "<table width=""100%""><tr><td align=""center""><font size=2>&nbsp;&nbsp;No Records Available</font></td></tr></table>"
			If (fNoAllRecordsButton = "" or Not fNoAllRecordsButton) and Session(tHeaderName & "_Filter") <> "" Then 
				PageName = Request.ServerVariables("PATH_INFO")
				If InStr(PageName, "List.asp") or InStr(PageName, "Form.asp") Then 
					PageName = Left(PageName, Len(PageName)-8)
					Response.Write "<FORM ACTION=""" & PageName  & "Action.asp" & """ METHOD=""POST"">"
					Response.Write "	<center><input TYPE=""SUBMIT"" NAME=""DataAction"" VALUE=""All Records""></center>"
					Response.Write "</FORM>"
				End If
			End If
		End If
End Select

Select Case strFormMode
	Case "New"
		If (fNoUpdateButton = "" or Not fNoUpdateButton) Then
			Response.Write "<table width=""100%"">"
			Response.Write "<tr><td align=""center""><font size=2>Note: Making changes to these fields does not modify the record in the database unless you click on the <b>Insert</b> button. "
			Response.Write "In addition, a successful update will <u>always</u> present a <b>Feedback</b> page after the record is inserted.</font></td></tr>"
			Response.Write "</table>"
		End If
	Case "Edit"
		If Not fEmptyRecordset and (fNoUpdateButton = "" or Not fNoUpdateButton) Then
			Response.Write "<table width=""100%"">"
			Response.Write "<tr><td align=""center""><font size=2>Note: Making changes to these fields does not modify the record in the database unless you click on the <b>Update</b> button. "
			Response.Write "In addition, a successful update will <u>always</u> present a <b>Feedback</b> page after the record is updated.</font></td></tr>"
			Response.Write "</table>"
		End If
	Case "Filter"
		Response.Write "<table width=""100%"">"
		Response.Write "<tr><td align=""center""><font size=2>Filter mode supports the use of the following operators: ""<b>=</b>"", ""<b>&lt;</b>"", ""<b>&gt;</b>"", ""<b>&lt;=</b>"", ""<b>&gt;=</b>"", ""<b>&lt;&gt;</b>"", and ""<b>LIKE</b>"". "
		Response.Write "Wildcard characters (""<b>*</b>""&nbsp;or&nbsp;""<b>%</b>"") are supported, but you must enter a value such as <b>LIKE&nbsp;""SubString*""</b>. "
		Response.Write "This will filter out all records that do not have a value beginning with ""SubString"" in this field. Unfortunately, wildcards can <u>only</u> be used at the <u>end</u> of such strings. "
		Response.Write "Note also that such a query will <u>not</u> be case sensitive...</font></td></tr>"
		Response.Write "</table>"
End Select

Response.Write "<table width=""100%""><tr><td>&nbsp;</td></tr><tr><td align=""center"">"
Response.Write "	<a href=""" & strFooterURL & """ target=""_top""><img src=""" & strHomeGIF & """ border=0 " & strFooterGIFdim & " alt=""" & strFooterTitle & """><br>"
Response.Write "	<font size=1><b>" & strFooterTitle & "</b></font></a>"
Response.Write "</td></tr></table>"
%>
