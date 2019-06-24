<%
	Case "Update"
		On Error Resume Next		
%>
<!-- #include virtual="/Includes/ActionTimeOutHandler.inc.asp"-->
<%
		If Not IsEmpty(Session(strDFName & "_Recordset")) Then
			If Session(strDFName & "_Recordset").EOF and Session(strDFName & "_Recordset").BOF Then Response.Redirect strBasePageName & "Form.asp"
			
			For each x In Session(strDFName & "_Recordset").Fields
				If CanUpdateField(x.Name) Then
					If Not UpdateField(x.Name) Then Exit For
				End If
			Next
			
			If Session(strDFName & "_Recordset").EditMode Then Session(strDFName & "_Recordset").Update
			
			If Err.Number <> 0 Then
				TmpNumber = Err.Number
				TmpSource = Err.Source
				TmpDescription = Err.Description
				If Session(strDFName & "_Recordset").EditMode Then Session(strDFName & "_Recordset").CancelUpdate		' Cancel the update before handling the error
				ErrorHandler TmpNumber, TmpSource, TmpDescription, Session(strDFName & "_Recordset").Source, strFooterURL, strFooterTitle
			End If
		End If
%>
