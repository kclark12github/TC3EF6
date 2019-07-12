<%
	Case "Insert"
		On Error Resume Next		
%>
<!-- #include virtual="/Includes/ActionTimeOutHandler.inc.asp"-->
<%
		If Not IsEmpty(Session(strRSName & "_Recordset")) Then
			Session(strRSName & "_Recordset").AddNew
			
			For each x In Session(strRSName & "_Recordset").Fields
				If CanUpdateField(x.Name) Then
					If InStr(strIgnoreFields, QuotedString(x.Name)) = 0 Then
						'	Response.Write "Session(" & strRSName & "_Recordset" & "_" & x.Name & ") is " & Session(strRSName & "_Recordset" & "_" & x.Name) & "<br>" & CHR(13)
						If Session(strRSName & "_Recordset" & "_" & x.Name) <> "" Then
							Session(strRSName & "_Recordset")(x.Name) = Session(strRSName & "_Recordset" & "_" & x.Name)
							Session(strRSName & "_Recordset" & "_" & x.Name) = ""
						Else
							If Not InsertField(x.Name) Then Exit For
						End If
					End If
				End If
			Next
			Session(strRSName & "_Recordset").Update
			
			If Err.Number <> 0 Then
				TmpNumber = Err.Number
				TmpSource = Err.Source
				TmpDescription = Err.Description
				If Session(strRSName & "_Recordset").EditMode Then Session(strRSName & "_Recordset").CancelUpdate		' Cancel the update before handling the error
				ErrorHandler TmpNumber, TmpSource, TmpDescription, Session(strRSName & "_Recordset").Source, strFooterURL, strFooterTitle
			Else
				If IsEmpty(Session(strRSName & "_AbsolutePage")) Or Session(strRSName & "_AbsolutePage") = 0 Then
					Session(strRSName & "_AbsolutePage") = 1
				End If
				' Requery static cursor so inserted record is visible
				If Session(strRSName & "_Recordset").CursorType = adOpenStatic Then Session(strRSName & "_Recordset").Requery
				Session(strRSName & "_Status") = "Record has been inserted"
			End If
		End If
%>
