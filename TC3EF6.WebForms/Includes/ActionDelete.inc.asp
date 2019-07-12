<%			
	Case "Delete"
		On Error Resume Next
%>
<!-- #include virtual="/Includes/ActionTimeOutHandler.inc.asp"-->
<%
		If Not IsEmpty(Session(strRSName & "_Recordset")) Then
			If Session(strRSName & "_Recordset").EOF and Session(strRSName & "_Recordset").BOF Then Response.Redirect strBasePageName & "Form.asp"
			
			Session(strRSName & "_Recordset").Delete

			If Err.Number <> 0 Then
				TmpNumber = Err.Number
				TmpSource = Err.Source
				TmpDescription = Err.Description
				If Session(strRSName & "_Recordset").EditMode Then Session(strRSName & "_Recordset").CancelUpdate		' Cancel the update before handling the error
				ErrorHandler TmpNumber, TmpSource, TmpDescription, Session(strRSName & "_Recordset").Source, strFooterURL, strFooterTitle
			Else
				' Requery static cursor so deleted record is removed
				If Session(strRSName & "_Recordset").CursorType = adOpenStatic Then Session(strRSName & "_Recordset").Requery
				
				' Move off deleted rec
				Session(strRSName & "_Recordset").MoveNext
				
				' If at EOF then jump back one and adjust AbsolutePage
				If Session(strRSName & "_Recordset").EOF Then
					Session(strRSName & "_AbsolutePage") = Session(strRSName & "_AbsolutePage") - 1				
					If Session(strRSName & "_Recordset").BOF And Session(strRSName & "_Recordset").EOF Then Session(strRSName & "_Recordset").Requery
				End If
			End If
		End If
%>
