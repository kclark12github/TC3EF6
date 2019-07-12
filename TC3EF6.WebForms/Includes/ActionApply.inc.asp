<%
	Case "Apply"
		On Error Resume Next
		
		' Make sure we exit and re-process the form if session has timed out
		If IsEmpty(Session(strRSName & "_Recordset")) Then
			If ListFileExists Then
				Response.Redirect strBasePageName & "List.asp"
			Else
				Response.Redirect strBasePageName & "Form.asp"
			End If
		End If
		
		strWhere = ""
		strWhereDisplay = ""
		For each x In Session(strRSName & "_Recordset").Fields
			If InStr(strLookupFields, QuotedString(x.Name)) > 0 Then
                WriteTraceLog(now & ": DEBUG: ActionApply: x.Name: """ & x.Name & "s""")
				FilterField x.Name, Application(strRSName & "_Lookup_" & x.Name & "s")
			Else
				FilterField x.Name, Null
			End If
		Next
		On Error Goto 0
        
		' Filter the recordset
		If strWhere <> "" Then
			Session(strRSName & "_Filter") = strWhere
			Session(strRSName & "_FilterDisplay") = strWhereDisplay
			Session(strRSName & "_AbsolutePage") = 1
		Else
			Session(strRSName & "_Filter") = ""
			Session(strRSName & "_FilterDisplay") = ""
		End If

		' Jump back to the form
		If ListFileExists Then
			Response.Redirect strBasePageName & "List.asp"
		Else
			Response.Redirect strBasePageName & "Form.asp"
		End If
%>
