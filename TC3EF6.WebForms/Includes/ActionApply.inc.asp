<%
	Case "Apply"
		On Error Resume Next
		
		' Make sure we exit and re-process the form if session has timed out
		If IsEmpty(Session(strDFName & "_Recordset")) Then
			If ListFileExists Then
				Response.Redirect strBasePageName & "List.asp"
			Else
				Response.Redirect strBasePageName & "Form.asp"
			End If
		End If
		
		strWhere = ""
		strWhereDisplay = ""
		For each x In Session(strDFName & "_Recordset").Fields
			If InStr(strLookupFields, QuotedString(x.Name)) > 0 Then
                WriteTraceLog(now & ": DEBUG: ActionApply: x.Name: """ & x.Name & "s""")
				FilterField x.Name, Application(strDFName & "_Lookup_" & x.Name & "s")
			Else
				FilterField x.Name, Null
			End If
		Next
		On Error Goto 0
        
		' Filter the recordset
		If strWhere <> "" Then
			Session(strDFName & "_Filter") = strWhere
			Session(strDFName & "_FilterDisplay") = strWhereDisplay
			Session(strDFName & "_AbsolutePage") = 1
		Else
			Session(strDFName & "_Filter") = ""
			Session(strDFName & "_FilterDisplay") = ""
		End If

		' Jump back to the form
		If ListFileExists Then
			Response.Redirect strBasePageName & "List.asp"
		Else
			Response.Redirect strBasePageName & "Form.asp"
		End If
%>
