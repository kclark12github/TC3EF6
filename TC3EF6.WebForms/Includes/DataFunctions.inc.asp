<%
PageType = Request.ServerVariables("PATH_INFO")
PageType = Left(PageType, Len(PageType)-8)
%>

<!-- #include virtual="/Includes/Constants.inc.asp"-->
<script RUNAT="Server" LANGUAGE="VBScript">

'-------------------------------------------------------------------------------
' Purpose:  Substitutes Empty for Null and trims leading/trailing spaces
' Inputs:   varTemp	- the target value
' Returns:	The processed value
'-------------------------------------------------------------------------------

Function ConvertNull(varTemp)
	If IsNull(varTemp) Then
		ConvertNull = ""
	Else
		ConvertNull = Trim(varTemp)
	End If
End Function

'-------------------------------------------------------------------------------
' Purpose:  Substitutes Null for Empty
' Inputs:   varTemp	- the target value
' Returns:	The processed value
'-------------------------------------------------------------------------------

Function RestoreNull(varTemp)
	If Trim(varTemp) = "" Then
		RestoreNull = Null
	Else
		RestoreNull = varTemp
	End If
End Function

Sub RaiseError(intErrorValue, strFieldName)
	Dim strMsg	
	Select Case intErrorValue
		Case errInvalidPrefix
			strMsg = "Wildcard characters * and % can only be used at the end of the criteria"
		Case errInvalidOperator
			strMsg = "Invalid filtering operators - use <= or >= instead."
		Case errInvalidOperatorUse
			strMsg = "The 'Like' operator can only be used with strings."
		Case errNotEditable
			strMsg = strFieldName & " field is not editable."
		Case errValueRequired
			strMsg = "A value is required for " & strFieldName & "."
	End Select
	Err.Raise intErrorValue, "DataForm", strMsg
End Sub

'-------------------------------------------------------------------------------
' Purpose:  Embeds bracketing quotes around the string
' Inputs:   varTemp	- the target value
' Returns:	The processed value
'-------------------------------------------------------------------------------

Function QuotedString(varTemp)
	If IsNull(varTemp) Then
		QuotedString = Chr(34) & Chr(34)
	Else
		QuotedString = Chr(34) & CStr(varTemp) & Chr(34)
	End If
End Function
Function DebugQuotedString(varTemp)
Response.Write "DEBUG: varTemp is """ & varTemp & """..." & CHR(13)
	If IsNull(varTemp) Then
		DebugQuotedString = Chr(34) & Chr(34)
	Else
		DebugQuotedString = Chr(34) & CStr(varTemp) & Chr(34)
	End If
Response.Write "DEBUG: DebugQuotedString is " & DebugQuotedString & "..." & CHR(13)
End Function

'-------------------------------------------------------------------------------
' Purpose:  Converts to subtype of string - handles Null cases
' Inputs:   varTemp	- the target value
' Returns:	The processed value
'-------------------------------------------------------------------------------

Function ConvertToString(varTemp)
	If IsNull(varTemp) Then
		ConvertToString = Null
	Else
		ConvertToString = CStr(varTemp)
	End If
End Function

'-------------------------------------------------------------------------------
' Purpose:  Handles embedded quotes in string
' Inputs:   varTemp	- the target value
' Returns:	The processed value
'-------------------------------------------------------------------------------

Function SQLQuotes(ByVal varTemp)
	If IsNull(varTemp) Then
		SQLQuotes = varTemp
	Else
		If InStr(varTemp, "'") > 0 Then
			SQLQuotes = Replace(varTemp, "'", "''")
		Else
			SQLQuotes = varTemp
		End If
	End If
    If fDebugMode Then WriteTraceLog(now & ": DEBUG: SQLQuotes: " & SQLQuotes)
End Function
'-------------------------------------------------------------------------------
' Purpose:  Tests to equality while dealing with Null values
' Inputs:   varTemp1	- the first value
'			varTemp2	- the second value
' Returns:	True if equal, False if not
'-------------------------------------------------------------------------------

Function IsEqual(ByVal varTemp1, ByVal varTemp2)
	IsEqual = False
	If IsNull(varTemp1) And IsNull(varTemp2) Then
		IsEqual = True
	Else
		If IsNull(varTemp1) Then Exit Function
		If IsNull(varTemp2) Then Exit Function
	End If
	If varTemp1 = varTemp2 Then IsEqual = True
End Function

'-------------------------------------------------------------------------------
' Purpose:  Tests string to see if it is a URL by looking for protocol
' Inputs:   varTemp	- the target value
' Returns:	True - if is URL, False if not
'-------------------------------------------------------------------------------

Function IsURL(varTemp)
	IsURL = True
	If UCase(Left(Trim(varTemp), 6)) = "HTTP:/" Then Exit Function
	If UCase(Left(Trim(varTemp), 6)) = "FILE:/" Then Exit Function
	If UCase(Left(Trim(varTemp), 8)) = "MAILTO:/" Then Exit Function
	If UCase(Left(Trim(varTemp), 5)) = "FTP:/" Then Exit Function
	If UCase(Left(Trim(varTemp), 8)) = "GOPHER:/" Then Exit Function
	If UCase(Left(Trim(varTemp), 6)) = "NEWS:/" Then Exit Function
	If UCase(Left(Trim(varTemp), 7)) = "HTTPS:/" Then Exit Function
	If UCase(Left(Trim(varTemp), 8)) = "TELNET:/" Then Exit Function
	If UCase(Left(Trim(varTemp), 6)) = "NNTP:/" Then Exit Function
	If Left(Trim(varTemp), 1) = "/" Then Exit Function
	If UCase(Right(Trim(varTemp), 4)) = ".ASP" Then Exit Function
	If UCase(Right(Trim(varTemp), 4)) = ".HTM" Then Exit Function
	If UCase(Right(Trim(varTemp), 5)) = ".HTML" Then Exit Function
	IsURL = False
End Function

'-------------------------------------------------------------------------------
' Purpose:  Tests whether the field in the recordset is required
' Assumes: 	That the recordset containing the field is open
' Inputs:   strFieldName	- the name of the field in the recordset
' Returns:	True if updatable, False if not
'-------------------------------------------------------------------------------

Function IsRequiredField(strFieldName)
	IsRequiredField = False
	If (Session(strDFName & "_Recordset")(strFieldName).Attributes And adFldIsNullable) = 0 Then 
		IsRequiredField = True
	End If
End Function

'-------------------------------------------------------------------------------
' Purpose:  Tests whether the field in the recordset is updatable
' Assumes: 	That the recordset containing the field is open
' Effects:	Sets Err object if field is not updatable
' Inputs:   strFieldName	- the name of the field in the recordset
' Returns:	True if updatable, False if not
'-------------------------------------------------------------------------------

Function CanUpdateField(strFieldName)
	Dim intUpdatable
	intUpdatable = (adFldUpdatable Or adFldUnknownUpdatable)
	CanUpdateField = True
	
	If (Session(strDFName & "_Recordset")(strFieldName).Attributes And intUpdatable) = False Then
		CanUpdateField = False
		Exit Function
	End If
End Function

'-------------------------------------------------------------------------------
' Purpose:  Constructs a name/value pair for a where clause
' Effects:	Sets Err object if the criteria is invalid
' Inputs:   strFieldName	- the name of the field in the recordset
'			strCriteria		- the criteria to use
'			strDelimiter	- the proper delimiter to use
' Returns:	The name/value pair as a string
'-------------------------------------------------------------------------------

Function PrepFilterItem(ByVal strFieldName, ByVal strCriteria, ByVal strDelimiter)
	Dim strOperator
	Dim intEndOfWord
	Dim strWord

	' Char, VarChar, and LongVarChar must be single quote delimited.
	' Dates are pound sign delimited.
	' Numerics should not be delimited.
	' String to Date conversion rules are same as VBA.
	' Only support for ANDing.
	' Support the LIKE operator but only with * or % as suffix.
	
	strCriteria = Trim(SQLQuotes(strCriteria))	'remove leading/trailing spaces
	strOperator = "="				'sets default
	strValue = strCriteria			'sets default

	' Get first word and look for operator
	intEndOfWord = InStr(strCriteria, " ")
	If intEndOfWord Then
		strWord = UCase(Left(strCriteria, intEndOfWord - 1))
		' See if the word is an operator
		Select Case strWord
			Case "=", "<", ">", "<=", ">=",  "<>", "LIKE"
				strOperator = strWord
				strValue = Trim(Mid(strCriteria, intEndOfWord + 1))
			Case "=<", "=>"
				RaiseError errInvalidOperator, strFieldName
		End Select
	Else
		strWord = UCase(Left(strCriteria, 2))
		Select Case strWord
			Case "<=", ">=", "<>"
				strOperator = strWord
				strValue = Trim(Mid(strCriteria, 3))
			Case "=<", "=>"
				RaiseError errInvalidOperator, strFieldName
			Case Else
				strWord = UCase(Left(strCriteria, 1))
				Select Case strWord
					Case "=", "<", ">"
						strOperator = strWord
						strValue = Trim(Mid(strCriteria, 2))
				End Select
		End Select
	End If

	' Make sure LIKE is only used with strings
	If strOperator = "LIKE" and strDelimiter <> "'" Then
		RaiseError errInvalidOperatorUse, strFieldName
	End If		

	' Strip any extraneous delimiters because we add them anyway
	' Single Quote
	If Left(strValue, 1) = Chr(39) Then strValue = Mid(strValue, 2)
	If Right(strValue, 1) = Chr(39) Then strValue = Left(strValue, Len(strValue) - 1)

	' Double Quote - just in case
	If Left(strValue, 1) = Chr(34) Then strValue = Mid(strValue, 2)
	If Right(strValue, 1) = Chr(34) Then strValue = Left(strValue, Len(strValue) - 1)

	' Pound sign - dates
	If Left(strValue, 1) = Chr(35) Then strValue = Mid(strValue, 2)
	If Right(strValue, 1) = Chr(35) Then strValue = Left(strValue, Len(strValue) - 1)
    
	' Check for leading wildcards
	If Left(strValue, 1) = "*" Or Left(strValue, 1) = "%" Then
		RaiseError errInvalidPrefix, strFieldName
	End If
	
	PrepFilterItem = "[" & strFieldName & "]" & " " & strOperator & " " & strDelimiter & strValue & strDelimiter
End Function

'--------------------------------------------------------------------------------------------
' Purpose:  Produces an Error results page
' Inputs:   ErrNumber		- The Err.Number
'			ErrSource		- The Source of the error (Err.Source)
'			ErrDescription	- The Error Description
'			SQLsource		- The errant SQL statement (if any)
'			strFooterURL	- used to direct the SunGard logo link on the bottom of the page
'			strFooterTitle	- used to label the SunGard logo link on the bottom of the page
'--------------------------------------------------------------------------------------------

Sub ErrorHandler(ErrNumber, ErrSource, ErrDescription, SQLsource, strFooterURL, strFooterTitle)
	If Theme = "" Then Theme = Application("Theme")
	If strHomeGIF = "" Then 
		strHomeGIF = Application("strHomeGIF")
		strFooterGIFdim = Application("strFooterGIFdim")
	End If
	If strFooterURL = "" Then strFooterURL = Application("strFooterURL")
	If strFooterTitle = "" Then 
		strFooterTitle = Application("strFooterTitle")
	Else
		If Left(strFooterTitle, 12) <> "Back to the " Then strFooterTitle = "Back to the " & strFooterTitle
	End If

	' Add additional error information to clarify specific errors
	Select Case ErrNumber
		Case -2147467259
			strErrorAdditionalInfo = "  This may be caused by an attempt to update a non-primary table in a view."
		Case Else
			strErrorAdditionalInfo = ""
	End Select

	Response.Write "<html>"
	Response.Write "<head>"
	Response.Write "	<meta NAME=""GENERATOR"" CONTENT=""Microsoft Visual InterDev"">"
	Response.Write "	<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=ISO-8859-1"">"
	Response.Write "	<meta NAME=""keywords"" CONTENT=""Microsoft Data Form, " & strFormTitle & """>"
	Response.Write "	<title>"& strFormTitle & "</title>"
	Response.Write "</head>"
	Response.Write "<basefont FACE=""Arial, Helvetica, sans-serif"">"
	Response.Write "<link REL=""STYLESHEET"" HREF=""/Stylesheets/" & Theme & "/Style2.css"">"
	Response.Write "<body BACKGROUND=""/Images/" & Theme & "/Background/Back2.jpg"" BGCOLOR=""White"" TOPMARGIN=0>"
	Response.Write "<table CELLSPACING=""0"" CELLPADDING=""0"" BORDER=""0"" WIDTH=""100%""><tr><td WIDTH=""20"">&nbsp;</td><td>"
	Response.Write "	<table WIDTH=""100%"" CELLSPACING=""0"" CELLPADDING=""0"" BORDER=""0"">"
	Response.Write "		<tr>"
	Response.Write "			<th NOWRAP ALIGN=""Left"" BGCOLOR=""Silver"" BACKGROUND=""/Images/" & Theme & "/Navigation/Nav1.jpg"">"
	Response.Write "				<font SIZE=""6"">&nbsp;Message:&nbsp;</font>"
	Response.Write "			</th>"
	Response.Write "		</tr>"
	Response.Write "		<tr>"
	Response.Write "			<td BGCOLOR=""#FFFFCC"">"
	Response.Write "			<font SIZE=""3"">"

	Select Case strDataAction
		Case "Insert"
			Response.Write("&nbsp;&nbsp;Unable to insert the record into <b>" & strTableName & "</b>.")
		Case "Update"
			Response.Write("&nbsp;&nbsp;Unable to post the updated record to <b>" & strTableName & "</b>.")
		Case "Delete"
			Response.Write("&nbsp;&nbsp;Unable to delete the record from <b>" & strTableName & "</b>.")
	End Select
	Response.Write "			</font>"
	Response.Write "			</td>"
	Response.Write "		</tr>"
	Response.Write "	</table>"
	Response.Write "	<table WIDTH=""100%"" CELLSPACING=""1"" CELLPADDING=""2"" BORDER=""0"">"
	Response.Write "		<tr>"
	Response.Write "			<td VALIGN=""top"" ALIGN=""Left"" BGCOLOR=""Silver""><font SIZE=""-1""><b>&nbsp;&nbsp;Item</b></font></td>"
	Response.Write "			<td WIDTH=""100%"" ALIGN=""Left"" BGCOLOR=""Silver""><font SIZE=""-1""><b>Description</b></font></td>"
	Response.Write "		</tr>"
	Response.Write "		<tr>"
	Response.Write "			<td VALIGN=""top""><font SIZE=""-1""><b>&nbsp;&nbsp;Source:</b></font></td>"
	Response.Write "			<td BGCOLOR=""White""><font SIZE=""-1"">" & ErrSource & "</td>"
	Response.Write "		</tr>"
	Response.Write "		<tr>"
	Response.Write "			<td VALIGN=""top"" NOWRAP><font SIZE=""-1""><b>&nbsp;&nbsp;Error Number:</b></font></td>"
	Response.Write "			<td BGCOLOR=""White""><font SIZE=""-1"">" & ErrNumber & "</font></td>"
	Response.Write "		</tr>"
	Response.Write "		<tr>"
	Response.Write "			<td VALIGN=""top"" NOWRAP><font SIZE=""-1""><b>&nbsp;&nbsp;SQL Statement:</b></font></td>"
	Response.Write "			<td BGCOLOR=""White""><font SIZE=""-1"">" & SQLsource & "</font></td>"
	Response.Write "		</tr>"
	Response.Write "		<tr>"
	Response.Write "			<td VALIGN=""top""><font SIZE=""-1""><b>&nbsp;&nbsp;Description:</b></font></td>"
	Response.Write "			<td BGCOLOR=""White""><font SIZE=""-1"">" & Server.HTMLEncode(ErrDescription & strErrorAdditionalInfo) & "</font></td>"
	Response.Write "		</tr>"
	Response.Write "		<tr>"
	Response.Write "			<td COLSPAN=""2""><hr></td>"
	Response.Write "		</tr>"
	Response.Write "		<tr>"
	Response.Write "			<td COLSPAN=""2"" align=""center"">"
	Response.Write "				<FORM ACTION=""" & strFormName & """ METHOD=""POST"">"
	Response.Write "					<input TYPE=""Hidden"" NAME=""FormMode"" VALUE=""Edit"">"
	Response.Write "					<input TYPE=""SUBMIT"" VALUE=""Form View"">"
	Response.Write "				</form>"
	Response.Write "			</td>"
	Response.Write "		</tr>"
	Response.Write "		<tr>"
	Response.Write "			<td colspan=2>"
	Response.Write "			<font SIZE=""-1"">"
	Response.Write "				To return to the form view with the previously entered "
	Response.Write "				information intact, use your browsers &quot;back&quot; button"
	Response.Write "			</font>"
	Response.Write "			</td>"
	Response.Write "		</tr>"
	Response.Write "		<tr>"
	Response.Write "			<td colspan=2 align=""center"">"
	Response.Write "				<a href=""" & strFooterURL & """><img src=""" & strHomeGIF & """ border=0 " & strFooterGIFdim & " alt=""" & strFooterTitle & """><br>"
	Response.Write "					<font size=1><b>" & strFooterTitle & "</b></font></a>"
	Response.Write "			</td>"
	Response.Write "		</tr>"
	Response.Write "	</table>"
	Response.Write "</td></tr></table>"
	Response.Write "</body>"
	Response.Write "</html>"

End Sub

'-------------------------------------------------------------------------------
' Purpose:  Handles the display of a field from a recordset depending
'			on its data type, attributes, and the current mode.
' Assumes: 	That the recordset containing the field is open
' Inputs:   strFieldName 	- the name of the field in the recordset
'			avarLookup		- array of lookup values
'-------------------------------------------------------------------------------
 
Function ShowListField(strFieldName, avarLookup, blnPassword)
	Dim intRow
	Dim strPartial
	Dim strBool
	Dim nPos
	strFieldValue = ""
	nPos=Instr(strFieldName,".")

	Do While nPos > 0 
		strFieldName= Mid (strFieldName, nPos+1)
		nPos=Instr(strFieldName,".")
	Loop 
	If Not IsNull(avarLookup) Then

		intIDcolumn = 0
		If UBound(avarLookup, 1) > 0 Then 
			intValueColumn = 1
		Else
			intValueColumn = 0
		End If

		Response.Write "<TD BGCOLOR=White NOWRAP><FONT SIZE=-1>" 
		For intRow = 0 to UBound(avarLookup, 2)
			If ConvertNull(avarLookup(intIDcolumn, intRow)) = ConvertNull(Session(strDFName & "_Recordset")(strFieldName)) Then
				Response.Write Server.HTMLEncode(ConvertNull(avarLookup(intValueColumn, intRow)))
				Exit For
			End If
		Next
		Response.Write "</FONT></TD>"
		Exit Function
	End If
	nType = Session(strDFName & "_Recordset")(strFieldName).Type
	
	Select Case nType
		Case adBoolean, adUnsignedTinyInt				'Boolean
			strBool = ""
			If Session(strDFName & "_Recordset")(strFieldName) <> 0 Then
				strBool = "True"
			Else
				strBool = "False"
			End If
			Response.Write "<TD BGCOLOR=White ><FONT SIZE=-1>" & strBool & "</FONT></TD>"
			
		Case adBinary, adVarBinary, adLongVarBinary		'Binary
			Response.Write "<TD BGCOLOR=White ><FONT SIZE=-1>[Binary]</FONT></TD>"
			
		Case adCurrency									'Currency
			If ConvertNull(strFieldValue) = "" Then 
				Response.Write "<TD BGCOLOR=White ><FONT SIZE=-1>&nbsp;</FONT></TD>"
			Else
				Response.Write "<TD BGCOLOR=White ><FONT SIZE=-1>" & FormatCurrency(Session(strDFName & "_Recordset")(strFieldName)) & "</FONT></TD>"
			End If
			
		Case adLongVarChar, adLongVarWChar				'Memo
			Response.Write "<TD BGCOLOR=White NOWRAP><FONT SIZE=-1>"
			strPartial = Left(Session(strDFName & "_Recordset")(strFieldName), 50)			
			If ConvertNull(strPartial) = "" Then
				Response.Write "&nbsp;"
			Else
				Response.Write HTMLEncode(strPartial)
			End If
			If Session(strDFName & "_Recordset")(strFieldName).ActualSize > 50 Then Response.Write "..."
			Response.Write "</FONT></TD>"
			
		Case Else
			Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1>"
			If ConvertNull(Session(strDFName & "_Recordset")(strFieldName)) = "" Then
				Response.Write "&nbsp;"
			Else
				' Check for special field types
				Select Case UCase(Left(Session(strDFName & "_Recordset")(strFieldName).Name, 4))
					Case "URL_"
						Response.Write "<A HREF=" & QuotedString(Session(strDFName & "_Recordset")(strFieldName)) & ">"
						Response.Write Server.HTMLEncode(ConvertNull(Session(strDFName & "_Recordset")(strFieldName)))
						Response.Write "</A>"
					Case Else
						If IsURL(Session(strDFName & "_Recordset")(strFieldName)) Then
							Response.Write "<A HREF=" & QuotedString(Session(strDFName & "_Recordset")(strFieldName)) & ">"
							Response.Write Server.HTMLEncode(ConvertNull(Session(strDFName & "_Recordset")(strFieldName)))
							Response.Write "</A>"
						Else
							If blnPassword Then
								Response.Write "********"
							Else
								Response.Write Server.HTMLEncode(ConvertNull(Session(strDFName & "_Recordset")(strFieldName)))
							End If
						End If
				End Select
			End If
			Response.Write "</FONT></TD>"
	End Select
End Function

'-------------------------------------------------------------------------------
' Purpose:  Handles the display of a field from a recordset depending
'			on its data type, attributes, and the current mode.
' Assumes: 	That the recordset containing the field is open
'			That strFormMode is initialized
' Inputs:   strFieldName 	- the name of the field in the recordset
'			strLabel		- the label to display
'			blnIdentity		- identity field flag
'			avarLookup		- array of lookup values
'-------------------------------------------------------------------------------
 
Sub ShowFormField(strFieldName, strLabel, blnIdentity, avarLookup, blnPassword, blnProtect)
	Dim blnFieldRequired
	Dim intMaxSize
	Dim intInputSize
	Dim intIDcolumn
	Dim intValueColumn
	Dim strOption1State
	Dim strOption2State
	Dim strFieldValue
	Dim nPos
	Dim intMaxTextDisplay

	intMaxTextDisplay = Session("MaxTextDisplay")

	if fDebugMode Then Response.Write "DEBUG: Inside ShowFormField(""" & strFieldname & """)...<br>" & CHR(13)
	strFieldValue = ""
	nPos = Instr(strFieldName,".")
	Do While nPos > 0 
		strFieldName= Mid (strFieldName, nPos+1)
		nPos=Instr(strFieldName,".")
	Loop 

	' If not in Edit form mode then set value to empty so doesn't display
	strFieldValue = ""
	If strFormMode = "Edit" Then strFieldValue = RTrim(Session(strDFName & "_Recordset")(strFieldName))
	
	' See if the field is required by checking the attributes 
	blnFieldRequired = False
	If (Session(strDFName & "_Recordset")(strFieldName).Attributes And adFldIsNullable) = 0 Then 
		blnFieldRequired = True
	End If
	nType = Session(strDFName & "_Recordset")(strFieldName).Type
	
	' Set values for the MaxLength and Size attributes	
	intMaxSize = dfMaxSize
	intInputSize = Session(strDFName & "_Recordset")(strFieldName).DefinedSize + 2
	If strFormMode <> "Filter" Then intMaxSize = intInputSize - 2
	
	' Write the field label and start the value cell
	Response.Write "	<TR VALIGN=TOP>" & CHR(13)
	Response.Write "		<TD HEIGHT=25 ALIGN=Left NOWRAP><FONT SIZE=-1><B>&nbsp;&nbsp;" & strLabel & "</B></FONT></TD>"	 & CHR(13)
	Response.Write "		<TD WIDTH=100% ><FONT SIZE=-1>"
	
	' If the field is not updatable, then handle it like an Identity column and exit
	If (blnProtect and IsNull(avarLookup)) or Not CanUpdateField(strFieldName) Then
		if fDebugMode Then Response.Write "DEBUG:	Handling field like an Identity...<br>" & CHR(13)

		' Special handling if Binary
		Select Case nType
			Case adBinary, adVarBinary, adLongVarBinary		'Binary
				Response.Write "[Binary]"
			Case Else		
				Select Case strFormMode
					Case "Edit"
						Response.Write "" & ConvertNull(strFieldValue)
						Response.Write "<INPUT TYPE=Hidden NAME=" & QuotedString(strFieldName)
						Response.Write " VALUE=" & QuotedString(strFieldValue) & " >"
					Case "New"
						Response.Write "[AutoNumber]"
						Response.Write "<INPUT TYPE=Hidden NAME=" & QuotedString(strFieldName)
						Response.Write " VALUE=" & QuotedString(strFieldValue) & " >"
					Case "Filter" 
						Response.Write "<INPUT TYPE=Text NAME=" & QuotedString(strFieldName)
						If intInputSize < intMaxTextDisplay Then
							Response.Write " SIZE=" & intInputSize
						Else
							Response.Write " SIZE=" & intMaxTextDisplay
						End If
						Response.Write " MAXLENGTH=" & intMaxSize
						Response.Write " VALUE=" & QuotedString(strFieldValue) & " >"
				End Select
		End Select
		Response.Write "</FONT></TD></TR>" & CHR(13)
		if fDebugMode Then Response.Write "DEBUG:	Exiting ShowFormField()...<br>" & CHR(13)
		Exit Sub
	End If
	
	' Handle lookups using a select and options
	If Not IsNull(avarLookup) Then
		if fDebugMode Then Response.Write "DEBUG: Inside ShowFormField() and avarLookup is Not Null...<br>" & CHR(13)
		If Not blnProtect Then
			Response.Write "			<SELECT NAME=" & QuotedString(strFieldName) & ">" & CHR(13)
			' Add blank entry if not required or in filter mode
			If Not blnFieldRequired Or strFormMode = "Filter" Then
				If (strFormMode = "Filter" Or strFormMode = "New") Then
					Response.Write "				<OPTION SELECTED>"
				Else
					Response.Write "				<OPTION>"
				End If
			End If
		End If
		
		'Response.Write CHR(13) & "<" & "!-- " & CHR(13)
		'Response.Write "UBound(avarLookup, 1) is " & UBound(avarLookup, 1) & CHR(13)
		'Response.Write "UBound(avarLookup, 2) is " & UBound(avarLookup, 2) & CHR(13)
		'Response.Write "avarLookup(0, 1) is " & avarLookup(0, 1) & CHR(13)
		'Response.Write "avarLookup(1, 1) is " & avarLookup(1, 1) & CHR(13)
		'Response.Write " -->" & CHR(13)

		intIDcolumn = 0
		If UBound(avarLookup, 1) > 0 Then 
			intValueColumn = 1
		Else
			intValueColumn = 0
		End If

		' Loop thru the rows in the array
		For intRow = 0 to UBound(avarLookup, 2)
			If blnProtect Then
				If ConvertNull(avarLookup(intIDcolumn, intRow)) = ConvertNull(strFieldValue) Then
					Response.Write ConvertNull(avarLookup(intValueColumn, intRow)) & CHR(13)
					Response.Write "</FONT></TD>" & CHR(13)
					Response.Write "	</TR>" & CHR(13)
					Exit Sub
				End If
			Else
				if fDebugMode Then Response.Write "DEBUG: Inside avarLookup code in ShowFormField()...<br>" & CHR(13)
				Response.Write "				<OPTION VALUE=" & QuotedString(avarLookup(intIDcolumn, intRow))
		        If strFormMode = "Edit" Then
					If ConvertNull(avarLookup(intIDColumn, intRow)) = ConvertNull(strFieldValue) Then
				   		Response.Write " SELECTED"
					End If
				End If
           		Response.Write ">"
				Response.Write ConvertNull(avarLookup(intValueColumn, intRow)) & CHR(13)
			End If
		Next
		If Not blnProtect Then
			Response.Write "			</SELECT>"
			If blnFieldRequired And strFormMode = "New" Then 
				Response.Write "  Required"
			End If
		End If
		Response.Write "</FONT></TD>" & CHR(13)
		Response.Write "	</TR>" & CHR(13)
		Exit Sub
	End If	
	
	' Evaluate data type and handle appropriately
	Select Case nType
		Case adBoolean, adUnsignedTinyInt				'Boolean
			If strFormMode = "Filter" Then				
				strOption1State = " >True"
				strOption2State = " >False"
			Else
				Select Case strFieldValue
					Case "True", "1", "-1"
						strOption1State = " CHECKED>True"
						strOption2State = " >False"
					Case "False", "0"
						strOption1State = " >True"
						strOption2State = " CHECKED>False"
					Case Else
						strOption1State = " >True"
						strOption2State = " >False"
				End Select
			End If			
			Response.Write "<INPUT TYPE=Radio VALUE=1 NAME=" & QuotedString(strFieldName) & strOption1State
			Response.Write "<INPUT TYPE=Radio VALUE=0 NAME=" & QuotedString(strFieldName) & strOption2State
			If strFormMode = "Filter" Then
				Response.Write "<INPUT TYPE=Radio NAME=" & QuotedString(strFieldName) & " CHECKED>Neither"
			End If
			
		Case adBinary, adVarBinary, adLongVarBinary		'Binary
			Response.Write "[Binary]"
			
		Case adLongVarChar, adLongVarWChar				'Memo
			Response.Write "<TEXTAREA NAME=" & QuotedString(strFieldName) & " ROWS=6 COLS=" & intMaxTextDisplay & ">"
			Response.Write Server.HTMLEncode(ConvertNull(strFieldValue))
			Response.Write "</TEXTAREA>"
			
		Case Else
			If (nType <> adVarChar) and (nType <> adVarWChar) and (nType <> adBSTR) and (nType <> adChar) and (nType <> adWChar)  Then
				intInputSize = (intInputSize-2)*3+2
				If strFormMode <> "Filter" Then intMaxSize = intInputSize - 2
			End If
			If blnIdentity Then
				Select Case strFormMode
					Case "Edit"
						Response.Write ConvertNull(strFieldValue)
						Response.Write "<INPUT TYPE=Hidden NAME=" & QuotedString(strFieldName)
						Response.Write " VALUE="
						If nType = adCurrency Then
							If ConvertNull(strFieldValue) = "" Then 
								Response.Write ConvertNull(strFieldValue)
							Else
								Response.Write QuotedString(FormatCurrency(strFieldValue))
							End If
						Else
							Response.Write QuotedString(strFieldValue)
						End If
						Response.Write " >"
					Case "New"
						Response.Write "[AutoNumber]"
						Response.Write "<INPUT TYPE=Hidden NAME=" & QuotedString(strFieldName)
						Response.Write " VALUE="
						If nType = adCurrency Then
							If ConvertNull(strFieldValue) = "" Then 
								Response.Write ConvertNull(strFieldValue)
							Else
								Response.Write QuotedString(FormatCurrency(strFieldValue))
							End If
						Else
							Response.Write QuotedString(strFieldValue)
						End If
						Response.Write " >"
					Case "Filter" 
						Response.Write "<INPUT TYPE=Text NAME=" & QuotedString(strFieldName) & " SIZE=" & tInputSize
						Response.Write " MAXLENGTH=" & tMaxSize 
						Response.Write " VALUE="
						If nType = adCurrency Then
							If ConvertNull(strFieldValue) = "" Then 
								Response.Write ConvertNull(strFieldValue)
							Else
								Response.Write QuotedString(FormatCurrency(strFieldValue))
							End If
						Else
							Response.Write QuotedString(strFieldValue)
						End If
						Response.Write " >"
				End Select
			Else
				' Check for special URL field types
' Commented-out since the text box should now fit on a page...
'				Select Case UCase(Left(Session(strDFName & "_Recordset")(strFieldName).Name, 4))
'					Case "URL_"
'						If strFieldValue <> "" Then
'							Response.Write "<A HREF=" & QuotedString(strFieldValue) & ">"
'							Response.Write "<IMG SRC=""/Images/Buttons/Go.gif"" width=26 height=26 border=0>"
'							Response.Write "</A>&nbsp;&nbsp;"
'						End If
'					Case Else
'						If IsURL(strFieldValue) Then
'							Response.Write "<A HREF=" & QuotedString(strFieldValue) & ">"
'							Response.Write "<IMG SRC=""/Images/Buttons/Go.gif"" width=26 height=26 border=0>"
'							Response.Write "</A>&nbsp;&nbsp;"
'						End If					
'				End Select				
				If intInputSize > 132 and Not IsURL(strFieldValue) Then 
					Response.Write "<TEXTAREA NAME=" & QuotedString(strFieldName) & " ROWS=2 COLS=" & intMaxTextDisplay & ">"
					Response.Write Server.HTMLEncode(ConvertNull(strFieldValue))
					Response.Write "</TEXTAREA>"
				Else
					If blnPassword Then
						Response.Write "<INPUT TYPE=Password NAME=" & QuotedString(strFieldName)
					Else
						Response.Write "<INPUT TYPE=Text NAME=" & QuotedString(strFieldName)
					End If
					If intInputSize < intMaxTextDisplay Then
						Response.Write " SIZE=" & intInputSize
					Else
						Response.Write " SIZE=""" & intMaxTextDisplay & """"
					End If
					Response.Write " MAXLENGTH=" & intMaxSize
					Response.Write " VALUE="
					If nType = adCurrency Then
						If ConvertNull(strFieldValue) = "" Then 
							Response.Write ConvertNull(strFieldValue)
						Else
							Response.Write QuotedString(FormatCurrency(strFieldValue))
						End If
					Else
						Response.Write QuotedString(strFieldValue)
					End If
					Response.Write " >"
				End If

				' Check for special field types
				Select Case UCase(Left(Session(strDFName & "_Recordset")(strFieldName).Name, 4))
					Case "IMG_"
						If strFieldValue <> "" Then
							Response.Write "<BR><BR><IMG SRC=" & QuotedString(strFieldValue) & "><BR>&nbsp;<BR>"
						End If
					Case "URL_"
						If strFieldValue <> "" Then
							Response.Write "&nbsp;&nbsp;<A HREF=" & QuotedString(strFieldValue) & ">"
							Response.Write "<IMG SRC=""/Images/Buttons/Go.gif"" width=26 height=26 border=0>"
							Response.Write "</A>"
						End If
					Case Else
						If IsURL(strFieldValue) Then
							Response.Write "&nbsp;&nbsp;<A HREF=" & QuotedString(strFieldValue) & ">"
							Response.Write "<IMG SRC=""/Images/Buttons/Go.gif"" width=26 height=26 border=0>"
							Response.Write "</A>"
						End If					
				End Select				
			End If
	End Select
   	If blnFieldRequired And strFormMode = "New" Then
		Response.Write "  Required"
	End If
	Response.Write "</FONT></TD>" & CHR(13)
	Response.Write "	</TR>" & CHR(13)
End Sub	

'-------------------------------------------------------------------------------
' Purpose:  Return Expanded Lookup field Value
' Inputs:   LookupIndex 	- the index of the entry in the avarLookup list
'			avarLookup		- array of lookup values
'-------------------------------------------------------------------------------
 
Function GetLookupValue(LookupIndex, avarLookup)
	Dim intRow
	Dim intIDcolumn
	Dim intValueColumn

	GetLookupValue = ""
	If IsNull(avarLookup) Then Exit Function

	intIDcolumn = 0
	If UBound(avarLookup, 1) > 0 Then 
		intValueColumn = 1
	Else
		intValueColumn = 0
	End If

	For intRow = 0 to intUBound
		If ConvertNull(avarLookup(intIDcolumn, intRow)) = ConvertNull(LookupIndex) Then
			GetLookupValue = Server.HTMLEncode(ConvertNull(avarLookup(intValueColumn, intRow)))
			Exit For
		End If
	Next
End Function

'-------------------------------------------------------------------------------
' Purpose:  Return Text Field with HTML tags
' Inputs:   strText 	- the value to encode
'-------------------------------------------------------------------------------
 
Function HTMLEncode(strText)
	Dim intChar
	Dim c

	HTMLEncode = ""
	If ConvertNull(strText) = "" Then Exit Function

	For intChar = 1 to Len(strText)
		c = Mid(strText, intChar, 1)
		Select Case c
			Case CHR(13)
				HTMLEncode = HTMLEncode & "<br>"
			Case Else
				HTMLEncode = HTMLEncode & c
		End Select
	Next
End Function

'-------------------------------------------------------------------------------
' Purpose:  Insert operation - updates a recordset field with a new value 
'			during an insert operation.
' Assumes: 	That the recordset containing the field is open
' Effects:	Sets Err object if field is not set but is required
' Inputs:   strFieldName	- the name of the field in the recordset
' Returns:	True if successful, False if not
'-------------------------------------------------------------------------------

Function InsertField(strFieldName)
	InsertField = True
	If IsEmpty(Request(strFieldName)) Then Exit Function
	Select Case Session(strDFName & "_Recordset")(strFieldName).Type
 		Case adBinary, adVarBinary, adLongVarBinary		'Binary
		Case Else
			If CanUpdateField(strFieldName) Then
				If IsRequiredField(strFieldName) And IsNull(RestoreNull(Request(strFieldName))) Then
					RaiseError errValueRequired, strFieldName
					InsertField = False
					Exit Function
				End If				
				Session(strDFName & "_Recordset")(strFieldName) = RestoreNull(Request(strFieldName))
			End If
	End Select
End Function

'-------------------------------------------------------------------------------
' Purpose:  Update operation - updates a recordset field with a new value 
' Assumes: 	That the recordset containing the field is open
' Effects:	Sets Err object if field is not set but is required
' Inputs:   strFieldName	- the name of the field in the recordset
' Returns:	True if successful, False if not
'-------------------------------------------------------------------------------

Function UpdateField(strFieldName)
	UpdateField = True

	If IsEmpty(Request(strFieldName)) Then Exit Function
	Select Case Session(strDFName & "_Recordset")(strFieldName).Type
 		Case adBinary, adVarBinary, adLongVarBinary		'Binary
		Case Else
			' Only update if the value has changed
			If Not IsEqual(ConvertToString(Session(strDFName & "_Recordset")(strFieldName)), RestoreNull(Request(strFieldName))) Then
				If CanUpdateField(strFieldName) Then						
					If IsRequiredField(strFieldName) And IsNull(RestoreNull(Request(strFieldName))) Then
						RaiseError errValueRequired, strFieldName
						UpdateField = False
						Exit Function
					End If				
					Session(strDFName & "_Recordset")(strFieldName) = RestoreNull(Request(strFieldName))
				Else
					RaiseError errNotEditable, strFieldName
					UpdateField = False
				End If
			End If
	End Select
End Function

'-------------------------------------------------------------------------------
' Purpose:  Criteria handler for a field in the recordset. Determines
'			correct delimiter based on data type
' Effects:	Appends to strWhere and strWhereDisplay variables
' Inputs:   strFieldName	- the name of the field in the recordset
'			avarLookup		- lookup array - null if none
'-------------------------------------------------------------------------------

Sub FilterField(ByVal strFieldName, avarLookup)
	Dim strFieldDelimiter
	Dim strDisplayValue
	Dim strValue
	Dim intRow
	Dim intIDcolumn
	Dim intValueColumn

	strValue = Request(strFieldName)
	strDisplayValue = Request(strFieldName)
	
	' If empty then exit right away
	If Request(strFieldName) = "" Then Exit Sub
	nType = Session(strDFName & "_Recordset")(strFieldName).Type

	' Handle "Neither" radio buttons...
	Select Case nType
		Case adBoolean, adUnsignedTinyInt	'Boolean
			If strValue = "on" Then Exit Sub	'Ignore from appending to Where Clause...
	End Select

    If fDebugMode Then WriteTraceLog(now & ": DEBUG: FilterField: strFieldName: """ & strFieldName & """; strValue: """ & strValue & """")

	' Concatenate the And boolean operator
	If strWhere <> "" Then strWhere = strWhere & " And"
	If strWhereDisplay <> "" Then strWhereDisplay = strWhereDisplay & " And"
	
	' If lookup field, then use lookup value for display
	If Not IsNull(avarLookup) Then
		intIDcolumn = 0
		If UBound(avarLookup, 1) > 0 Then 
			intValueColumn = 1
		Else
			intValueColumn = 0
		End If

        If fDebugMode Then WriteTraceLog(now & ": DEBUG: FilterField: UBound(avarLookup, 2): " & UBound(avarLookup, 2))
		For intRow = 0 to UBound(avarLookup, 2)
		    If Not IsNull(avarLookup(intIDcolumn, intRow)) Then
                If fDebugMode Then WriteTraceLog(now & ": DEBUG: FilterField: avarLookup(" & intRow & "): """ & CStr(avarLookup(intIDcolumn, intRow)) & """")
			    If CStr(avarLookup(intIDcolumn, intRow)) = Request(strFieldName) Then
				    strDisplayValue = avarLookup(intValueColumn, intRow)
				    Exit For
			    End If
			End If
		Next
	End If
	
	' Set delimiter based on data type
	Select Case nType
		Case adBSTR, adChar, adWChar, adVarChar, adVarWChar	'string types
			strFieldDelimiter = "'"
		Case adLongVarChar, adLongVarWChar					'long string types
			strFieldDelimiter = "'"				
		Case adDate, adDBDate, adDBTimeStamp				'date types
			strFieldDelimiter = "#"
		Case Else
			strFieldDelimiter = ""
	End Select
	
    If fDebugMode Then WriteTraceLog(now & ": DEBUG: FilterField: strFieldName: """ & strFieldName & """; strValue: """ & strValue & """")
	
	' Modifies script level variables
	strWhere = strWhere & " " & PrepFilterItem(strFieldName, strValue, strFieldDelimiter)
	strWhereDisplay = strWhereDisplay & " " & PrepFilterItem(strFieldName, strDisplayValue, strFieldDelimiter)
End Sub

'-------------------------------------------------------------------------------
' Purpose:  Display field involved in a database operation for feedback.
' Assumes: 	That the recordset containing the field is open
' Inputs:   strFieldLabel	- the label to be used for the field
'			strFieldName	- the name of the field in the recordset
'-------------------------------------------------------------------------------

Sub FeedbackField(strFieldLabel, strFieldName, avarLookup)
	Dim strBool
	Dim intRow
	Dim intIDcolumn
	Dim intValueColumn
	Dim fDebugMode
	
	fDebugMode = False

	If fDebugMode Then Response.Write "<" & "!-- DEBUG: strFieldLabel: """ & strFieldLabel & """; strFieldName: """ & strFieldName & """; -->" & chr(13)

	Response.Write "<TR VALIGN=TOP>"
   Response.Write "<TD ALIGN=Left><FONT SIZE=-1><B>&nbsp;&nbsp;" & strFieldLabel & "</B></FONT></TD>"
	Response.Write "<TD BGCOLOR=White WIDTH=100% ALIGN=Left><FONT SIZE=-1>"
	
	' Test for lookup
	If Not IsNull(avarLookup) Then
		intIDcolumn = 0
		If UBound(avarLookup, 1) > 0 Then 
			intValueColumn = 1
		Else
			intValueColumn = 0
		End If

		For intRow = 0 to UBound(avarLookup, 2)
			If CStr(avarLookup(intIDcolumn, intRow)) = Request(strFieldName) Then
				Response.Write Server.HTMLEncode(avarLookup(intValueColumn, intRow))
				Exit For
			End If
		Next
		Response.Write "</FONT></TD></TR>" & CHR(13)
		Exit Sub
	End If

	If fDebugMode Then Response.Write "<" & "!-- DEBUG: " & strFieldName & " is not a lookup field... -->" & chr(13)

	' Test for empty
	If Request(strFieldName) = "" Then
		Response.Write "&nbsp;"
		Response.Write "</FONT></TD></TR>" & CHR(13)
		Exit Sub
	End If
	
	If fDebugMode Then Response.Write "<" & "!-- DEBUG: " & strFieldName & " is not empty... -->" & chr(13)

	' Test the data types and display appropriately	
	Select Case Session(strDFName & "_Recordset")(strFieldName).Type
		Case adBoolean, adUnsignedTinyInt				'Boolean
			strBool = ""
			If Request(strFieldName) <> 0 Then
				strBool = "True"
			Else
				strBool = "False"
			End If
			Response.Write strBool
		Case adBinary, adVarBinary, adLongVarBinary		'Binary
			Response.Write "[Binary]"
		Case adLongVarChar, adLongVarWChar				'Memo
			Response.Write HTMLEncode(Request(strFieldName))
		Case adCurrency									'Currency
			If ConvertNull(Request(strFieldName)) = "" Then 
				Response.Write "&nbsp;"
			Else
				Response.Write FormatCurrency(Request(strFieldName))
			End If
		Case Else
			If Not CanUpdateField(strFieldName) Then
				Response.Write "[AutoNumber]"
			Else
				Response.Write Server.HTMLEncode(Request(strFieldName))
			End If
	End Select
	Response.Write "</FONT></TD></TR>" & CHR(13)
End Sub
'-------------------------------------------------------------------------------
Sub WriteLog(strMessage)
	Dim FileSystem
	Dim LogFile
	
	Set FileSystem = Server.CreateObject("Scripting.FileSystemObject")
   Set LogFile = FileSystem.OpenTextFile(Application("ApplicationLogFilename"), ForAppending, TRUE)
   LogFile.WriteLine(now & ": " & strMessage)
   LogFile.Close

   Set LogFile = Nothing
   Set FileSystem = Nothing
End Sub
'-------------------------------------------------------------------------------
Sub WriteTraceLog(strMessage)
	Dim FileSystem
	Dim LogFile
	
	Set FileSystem = Server.CreateObject("Scripting.FileSystemObject")
    Set LogFile = FileSystem.OpenTextFile(Application("TraceLogFilename"), ForAppending, TRUE)
    LogFile.WriteLine(now & ": " & strMessage)
    LogFile.Close

   Set LogFile = Nothing
   Set FileSystem = Nothing
End Sub
'-------------------------------------------------------------------------------
</script>
