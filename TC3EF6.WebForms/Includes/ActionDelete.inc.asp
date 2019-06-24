<%			
	Case "Delete"
		On Error Resume Next
%>
<!-- #include virtual="/Includes/ActionTimeOutHandler.inc.asp"-->
<%
		If Not IsEmpty(Session(strDFName & "_Recordset")) Then
			If Session(strDFName & "_Recordset").EOF and Session(strDFName & "_Recordset").BOF Then Response.Redirect strBasePageName & "Form.asp"
			
			Session(strDFName & "_Recordset").Delete

			If Err.Number <> 0 Then
				TmpNumber = Err.Number
				TmpSource = Err.Source
				TmpDescription = Err.Description
				If Session(strDFName & "_Recordset").EditMode Then Session(strDFName & "_Recordset").CancelUpdate		' Cancel the update before handling the error
				ErrorHandler TmpNumber, TmpSource, TmpDescription, Session(strDFName & "_Recordset").Source, strFooterURL, strFooterTitle
			Else
				' Requery static cursor so deleted record is removed
				If Session(strDFName & "_Recordset").CursorType = adOpenStatic Then Session(strDFName & "_Recordset").Requery
				
				' Move off deleted rec
				Session(strDFName & "_Recordset").MoveNext
				
				' If at EOF then jump back one and adjust AbsolutePage
				If Session(strDFName & "_Recordset").EOF Then
					Session(strDFName & "_AbsolutePage") = Session(strDFName & "_AbsolutePage") - 1				
					If Session(strDFName & "_Recordset").BOF And Session(strDFName & "_Recordset").EOF Then Session(strDFName & "_Recordset").Requery
				End If
			End If
		End If
%>
