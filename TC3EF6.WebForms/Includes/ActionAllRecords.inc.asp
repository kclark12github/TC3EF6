<%
	Case "All Records"
		On Error Resume Next
		Session(strDFName & "_Filter") = ""
		Session(strDFName & "_FilterDisplay") = ""
		Session(strDFName & "_Recordset").Filter = ""
		Session(strDFName & "_AbsolutePage") = 1
		If ListFileExists Then
			Response.Redirect strBasePageName & "List.asp"
		Else
			Response.Redirect strBasePageName & "Form.asp"
		End If
%>
