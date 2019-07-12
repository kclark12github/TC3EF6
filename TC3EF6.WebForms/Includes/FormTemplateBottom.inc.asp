<!-- #include virtual="/Includes/FormTemplateBody1.inc.asp"-->
<%
	For each x In Session(strRSName & "_Recordset").Fields
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
	            if fDebugMode Then Response.Write "<" & "!-- DEBUG: Found " & QuotedString(x.Name) & " within strLookupFields (""" & strlookupFields & """)... -->" & CHR(13)
				ShowFormField x.Name, x.Name, fIdentity, Application(strRSName & "_Lookup_" & x.Name & "s"), fPassword, fProtect
			Else
	            if fDebugMode Then Response.Write "<" & "!-- DEBUG: Did not find " & QuotedString(x.Name) & " within strLookupFields (""" & strlookupFields & """)... -->" & CHR(13)
				ShowFormField x.Name, x.Name, fIdentity, Null, fPassword, fProtect
			End If
		End If
	Next
%>
<!-- #include virtual="/Includes/FormTemplateBody2.inc.asp"-->
