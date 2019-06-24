<%
	Case "New"
		On Error Resume Next
		Session(strDFName & "_Filter") = ""
		Session(strDFName & "_FilterDisplay") = ""
		Session(strDFName & "_Recordset").Filter = ""
		Response.Redirect strBasePageName & "Form.asp?FormMode=" & strDataAction
%>
