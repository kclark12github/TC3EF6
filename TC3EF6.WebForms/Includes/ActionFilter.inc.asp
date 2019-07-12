<%
	Case "Filter"
		On Error Resume Next
		Session(strRSName & "_Filter") = ""
		Session(strRSName & "_FilterDisplay") = ""
		Session(strRSName & "_Recordset").Filter = ""
		Response.Redirect strBasePageName & "Form.asp?FormMode=" & strDataAction
%>
