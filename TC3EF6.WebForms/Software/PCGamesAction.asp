<%@ LANGUAGE="VBScript" %>
<%
strTableName = "Software"
strRSName = "rsPCGames"
strBasePageName = "PCGames"
strPageTitle = "Software Library; PC Games"
SQLstatement = "Select * From [Software] Where (Platform Like 'Win%' Or Platform Like 'MS-DOS') And [Type] Like 'Game%' Order By Title, Version;"
strProtectedFields = """Cataloged"",""DateInventoried"""
strLookupFields = """MediaFormat"",""Location"",""Platform"",""Publisher"",""Type"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
strFormMode = "FeedBack"
Theme = "Blueside"
blnShowUserName = False
TmpNumber = 0
fDebugMode = False
%>

<!-- #include virtual="/Includes/DataFunctions.inc.asp"-->
<!-- #include virtual="/Software/avarLocations.inc.asp"-->
<!-- #include virtual="/Software/avarMediaFormat.inc.asp"-->
<!-- #include virtual="/Software/avarPlatforms.inc.asp"-->
<!-- #include virtual="/Software/avarPublishers.inc.asp"-->
<!-- #include virtual="/Software/avarTypes.inc.asp"-->
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
								Case "DateInventoried"
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
