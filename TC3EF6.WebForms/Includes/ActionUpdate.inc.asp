<%
	Case "Update"
		On Error Resume Next		
%>
<!-- #include virtual="/Includes/ActionTimeOutHandler.inc.asp"-->
<%
		If Not IsEmpty(Session(strRSName & "_Recordset")) Then
			If Session(strRSName & "_Recordset").EOF and Session(strRSName & "_Recordset").BOF Then Response.Redirect strBasePageName & "Form.asp"
			
			For each x In Session(strRSName & "_Recordset").Fields
				If CanUpdateField(x.Name) Then
					If Not UpdateField(x.Name) Then Exit For
				End If
			Next
			
			If Session(strRSName & "_Recordset").EditMode Then Session(strRSName & "_Recordset").Update
			
			If Err.Number <> 0 Then
				TmpNumber = Err.Number
				TmpSource = Err.Source
				TmpDescription = Err.Description
				If Session(strRSName & "_Recordset").EditMode Then Session(strRSName & "_Recordset").CancelUpdate		' Cancel the update before handling the error
				ErrorHandler TmpNumber, TmpSource, TmpDescription, Session(strRSName & "_Recordset").Source, strFooterURL, strFooterTitle
			End If
		End If
%>
