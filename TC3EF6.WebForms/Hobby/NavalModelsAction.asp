<%@ LANGUAGE="VBScript" %>
<%
Dim strDFName
Dim strErrorAdditionalInfo
strDBName = "KFC"
strDFName = "rsShipKits"
strTableName = "Kits"
strBasePageName = "NavalModels"
strPageTitle = "Naval Models"
SQLstatement = "SELECT * FROM [Kits] WHERE Type like 'SHIP%' order by Scale, Designation, Name"
strProtectedFields = """DateInventoried"""
strLookupFields = """Condition"",""Catalog"",""Era"",""Location"",""Manufacturer"",""Nation"",""Scale"",""Service"",""Type"""
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
<!-- #include virtual="/Hobby/avarcatalogs.inc.asp"-->
<!-- #include virtual="/Hobby/avarconditions.inc.asp"-->
<!-- #include virtual="/Hobby/avareras.inc.asp"-->
<!-- #include virtual="/Hobby/avarlocations.inc.asp"-->
<!-- #include virtual="/Hobby/avarmanufacturers.inc.asp"-->
<!-- #include virtual="/Hobby/avarnations.inc.asp"-->
<!-- #include virtual="/Hobby/avarscales.inc.asp"-->
<!-- #include virtual="/Hobby/avarservices.inc.asp"-->
<!-- #include virtual="/Hobby/avartypes.inc.asp"-->
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
