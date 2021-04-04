<%@ LANGUAGE="VBScript" %>
<%
Dim strRSName
Dim strErrorAdditionalInfo
strRSName = "rsBooks"
strTableName = "Books"
strBasePageName = "Books"
strPageTitle = "Library; Books"
SQLstatement = "Select Books.*,Locations.Name As Location From Books Inner Join Locations On Books.LocationID=Locations.ID Order By AlphaSort;"
strProtectedFields = """Cataloged"",""Inventoried"""
strLookupFields = """Author"",""Subject"",""MediaFormat"",""Location"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
strFormMode = "FeedBack"
Theme = "Brownside"
blnShowUserName = False
TmpNumber = 0
fDebugMode = True	'Application("fDebugMode")
%>

<!-- #include virtual="/Includes/DataFunctions.inc.asp"-->
<!-- #include virtual="/Books/avarAuthors.inc.asp"-->
<!-- #include virtual="/Books/avarSubjects.inc.asp"-->
<!-- #include virtual="/Books/avarMediaFormat.inc.asp"-->
<!-- #include virtual="/Books/avarLocations.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateTop.inc.asp"-->
<!-- #include virtual="/Includes/ActionList.inc.asp"-->
<!-- #include virtual="/Includes/ActionCancel.inc.asp"-->
<!-- #include virtual="/Includes/ActionFilter.inc.asp"-->
<!-- #include virtual="/Includes/ActionNew.inc.asp"-->
<!-- #include virtual="/Includes/ActionFind.inc.asp"-->
<!-- #include virtual="/Includes/ActionAllRecords.inc.asp"-->
<!-- #include virtual="/Includes/ActionApply.inc.asp"-->
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
							Select Case x.Name
								Case "Cataloged"
									Session(strRSName & "_Recordset")(x.Name) = -1
								Case "Inventoried"
									Session(strRSName & "_Recordset")(x.Name) = Now()
								Case Else
									If Not InsertField(x.Name) Then Exit For
							End Select
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
<!-- #include virtual="/Includes/ActionUpdate.inc.asp"-->
<!-- #include virtual="/Includes/ActionDelete.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateBottom.inc.asp"-->
