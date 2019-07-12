<%
	Case "All Records"
		On Error Resume Next
		Session(strRSName & "_Filter") = ""
		Session(strRSName & "_FilterDisplay") = ""
		Session(strRSName & "_Recordset").Filter = ""
		Session(strRSName & "_AbsolutePage") = 1
		If ListFileExists Then
			Response.Redirect strBasePageName & "List.asp"
		Else
			Response.Redirect strBasePageName & "Form.asp"
		End If
%>
