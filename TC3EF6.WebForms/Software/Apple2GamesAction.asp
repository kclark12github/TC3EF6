<%@ LANGUAGE="VBScript" %>
<%
Dim strDFName
Dim strErrorAdditionalInfo
strDBName = "Software"
strDFName = "rsApple2Games"
strTableName = "Apple2Games"
strBasePageName = "Apple2Games"
strPageTitle = "Software Library; Apple ][ Games"
SQLstatement = "Select * From [Software] Where (Platform Like 'Apple%' Or Platform='CP/M') And [Type] Like 'Game%' Order By Title, Version;"
strProtectedFields = """Cataloged"",""DateInventoried"""
strLookupFields = """Platform"",""Publisher"",""Type"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
strFormMode = "FeedBack"
Theme = "Redside"
blnShowUserName = False
TmpNumber = 0
fDebugMode = False
%>

<!-- #include virtual="/Includes/DataFunctions.inc.asp"-->
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
		If Not IsEmpty(Session(strDFName & "_Recordset")) Then
			Session(strDFName & "_Recordset").AddNew
			
			For each x In Session(strDFName & "_Recordset").Fields
				If CanUpdateField(x.Name) Then
					If InStr(strIgnoreFields, QuotedString(x.Name)) = 0 Then
						'	Response.Write "Session(" & strDFName & "_Recordset" & "_" & x.Name & ") is " & Session(strDFName & "_Recordset" & "_" & x.Name) & "<br>" & CHR(13)
						If Session(strDFName & "_Recordset" & "_" & x.Name) <> "" Then
							Session(strDFName & "_Recordset")(x.Name) = Session(strDFName & "_Recordset" & "_" & x.Name)
							Session(strDFName & "_Recordset" & "_" & x.Name) = ""
						Else
							Select Case x.Name
								Case "Cataloged"
									Session(strDFName & "_Recordset")(x.Name) = -1
								Case "DateInventoried"
									Session(strDFName & "_Recordset")(x.Name) = Now()
								Case Else
									If Not InsertField(x.Name) Then Exit For
							End Select
						End If
					End If
				End If
			Next
			Session(strDFName & "_Recordset").Update
			
			If Err.Number <> 0 Then
				TmpNumber = Err.Number
				TmpSource = Err.Source
				TmpDescription = Err.Description
				If Session(strDFName & "_Recordset").EditMode Then Session(strDFName & "_Recordset").CancelUpdate		' Cancel the update before handling the error
				ErrorHandler TmpNumber, TmpSource, TmpDescription, Session(strDFName & "_Recordset").Source, strFooterURL, strFooterTitle
			Else
				If IsEmpty(Session(strDFName & "_AbsolutePage")) Or Session(strDFName & "_AbsolutePage") = 0 Then
					Session(strDFName & "_AbsolutePage") = 1
				End If
				' Requery static cursor so inserted record is visible
				If Session(strDFName & "_Recordset").CursorType = adOpenStatic Then Session(strDFName & "_Recordset").Requery
				Session(strDFName & "_Status") = "Record has been inserted"
			End If
		End If
%>
<!-- #include virtual="/Includes/ActionUpdate.inc.asp"-->
<!-- #include virtual="/Includes/ActionDelete.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateBottom.inc.asp"-->
