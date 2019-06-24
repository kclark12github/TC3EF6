<!-- #include virtual="/Includes/FormTemplateBody1.inc.asp"-->
<%
	For each x In Session(strDFName & "_Recordset").Fields
		If InStr(strIgnoreFields, QuotedString(x.Name)) = 0 Then
			fProtect = True
			fIdentity = False
			fPassword = False
			If strFormMode <> "Edit" or ((fNoUpdateButton = "" or Not fNoUpdateButton) and CanUpdateField(x.Name)) Then fProtect = False
			Select Case x.Name
				Case "ID"
					fIdentity = True
				Case "Password"
					fPassword = True
				Case Else
				If InStr(strProtectedFields, QuotedString(x.Name)) <> 0 Then fIdentity = True
			End Select
			If InStr(strLookupFields, QuotedString(x.Name)) > 0 Then
				ShowFormField x.Name, x.Name, fIdentity, Application(strDFName & "_Lookup_" & x.Name & "s"), fPassword, fProtect
			Else
				ShowFormField x.Name, x.Name, fIdentity, Null, fPassword, fProtect
			End If
		End If
	Next
%>
<!-- #include virtual="/Includes/FormTemplateBody2.inc.asp"-->
