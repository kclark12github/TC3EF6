<%@ LANGUAGE="vbscript" %>
<%
' If the visitor had a cookie with the E-Mail address in it, Global.asa would
' have retrieved his Visitor ID from the database, and populated all the 
' fields we maintain on file. So, the "VisitorOnFile" session variable 
' indicates whether or not Global.asa found this information. If it didn't,
' the visitor is prompted for this information using a HTML form, submitted
' back to this same page for processing...

fDebugMode = False

if fDebugMode then Response.Write "DEBUG: VisitorOnFile is " & Session("VisitorOnFile") & "<br>"

if Not Session("VisitorOnFile") Then
	Const adOpenForwardOnly=0 
	Const adOpenKeyset=1
	Const adOpenDynamic=2
	Const adOpenStatic=3
	Const adLockReadOnly=1
	Const adLockPessimistic=2
	Const adLockOptimistic=3
	Const adLockBatchOptimistic=4
	Const adCmdText=1
	Const adCmdTable=2
	Const adCmdStoredProc=4
	Const adCmdUnknown=8
 
	Const ForReading = 1 'Open a file for reading only. No writing to this file can take place.
  	Const ForWriting = 2 'Open a file for writing. If a file with the same name exists, its previous contents are overwritten.
	Const ForAppending = 8
	On Error Resume Next

	ValidateUser = False

	fEmptyRecordSet = False

	if (Not IsEmpty(Request.QueryString("FromForm"))) then
		Session("E-Mail") = Request.Form("EMail")
		
		Set cmdTemp = Server.CreateObject("ADODB.Command")
		Set rsVisitor = Server.CreateObject("ADODB.Recordset")
		cmdTemp.CommandText = "SELECT ""ID"", ""E-Mail"",""FirstName"",""LastName"",""Address"",""Phone"",""Visits"",""DateLastVisit"" FROM ""Visitors"" where (""E-Mail"" like '" & Session("E-Mail") & "')"
		cmdTemp.CommandType = adCmdText
		Set cmdTemp.ActiveConnection = Session("adoConn")
		rsVisitor.Open cmdTemp, , adOpenKeyset, adLockOptimistic
		if fDebugMode then Response.Write "DEBUG: Opened Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "; SQL: " & rsVisitor.Source & "<br>"

		If Err.Number <> 0 Then 
			Set FileOutObject = Server.CreateObject("Scripting.FileSystemObject")
			Set Out = FileOutObject.OpenTextFile(Session("LogFilename"), ForAppending, TRUE)
			sOutMsg = "Error Reading Visitor; Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "; SQL: " & rsVisitor.Source
			if fDebugMode then Response.Write "DEBUG: " & sOutMsg & "<br>"
			Out.WriteLine(now & " - " & sOutMsg)
			Out.Close
			Set FileOutObject = Nothing
			Err.Clear

			fEmptyRecordset = True
		End If
		If rsVisitor.BOF And rsVisitor.EOF Then fEmptyRecordset = True

   		If Not fEmptyRecordSet Then
	   		Session("VisitorID") = rsVisitor("ID")
			Session("E-Mail") = rsVisitor("E-Mail")
			Session("FirstName") = rsVisitor("FirstName")
     		Session("LastName") = rsVisitor("LastName")
			Session("Address") = rsVisitor("Address")
			Session("Phone") = rsVisitor("Phone")
			Session("DateLastVisit") = rsVisitor("DateLastVisit")
			Session("Visits") = rsVisitor("Visits")
			if fDebugMode then 
				Response.Write "DEBUG: VisitorID=&quot;" & Session("VisitorID") & "&quot;<br>"
				Response.Write "DEBUG: E-Mail=&quot;" & Session("E-Mail") & "&quot;<br>"
				Response.Write "DEBUG: FirstName=&quot;" & Session("FirstName") & "&quot;<br>"
				Response.Write "DEBUG: LastName=&quot;" & Session("LastName") & "&quot;<br>"
				Response.Write "DEBUG: Address=&quot;" & Session("Address") & "&quot;<br>"
				Response.Write "DEBUG: Phone=&quot;" & Session("Phone") & "&quot;<br>"
				Response.Write "DEBUG: DateLastVisit=&quot;" & Session("DateLastVisit") & "&quot;<br>"
				Response.Write "DEBUG: Visits=&quot;" & Session("Visits") & "&quot;<br>"
			end if

        	' Refresh Cookie
			Response.Cookies("Data")("E-Mail") = Session("E-Mail")
			Response.Cookies("Data").expires = DateAdd("d", 90, Now())

			rsVisitor.Fields("DateLastVisit") = Session("DateLastVisit")
			rsVisitor.Fields("Visits") = Session("Visits") + 1

			rsVisitor.Update
			if fDebugMode then Response.Write "DEBUG: Updated Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "<br>"

			If Err.Number <> 0 Then
				Set FileOutObject = Server.CreateObject("Scripting.FileSystemObject")
				Set Out = FileOutObject.OpenTextFile(Session("LogFilename"), ForAppending, TRUE)
				sOutMsg = "Error Updating Visitor; Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "; SQL: " & rsVisitor.Source
				if fDebugMode then Response.Write "DEBUG: " & sOutMsg & "<br>"
				Out.WriteLine(now & " - " & sOutMsg)
				Out.Close
				Set FileOutObject = Nothing
				Err.Clear
			Else
				Session("VisitorOnFile") = True
			End If
			rsVisitor.Close
			if fDebugMode then Response.Write "DEBUG: Closed Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "<br>"
		Else
			rsVisitor.Close
			if fDebugMode then Response.Write "DEBUG: Closed Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "<br>"
			
			' Add the Form's information into the Visitor table...

			rsVisitor.Open "Visitors", Session("adoConn"), adOpenKeyset, adLockBatchOptimistic
			if fDebugMode then Response.Write "DEBUG: Open Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "<br>"
			rsVisitor.AddNew
			if fDebugMode then Response.Write "DEBUG: AddNew Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "<br>"

			rsVisitor.Fields("E-Mail") = Request.Form("EMail")
			rsVisitor.Fields("FirstName") = Request.Form("FirstName")
     		rsVisitor.Fields("LastName") = Request.Form("LastName")
			rsVisitor.Fields("Address") = Request.Form("Address")
			rsVisitor.Fields("Phone") = Request.Form("Phone")
			rsVisitor.Fields("DateLastVisit") = Session("DateLastVisit")
			rsVisitor.Fields("Visits") = 1

			rsVisitor.UpdateBatch
			if fDebugMode then Response.Write "DEBUG: UpdateBatch Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "<br>"

			If Err.Number <> 0 Then
				Set FileOutObject = Server.CreateObject("Scripting.FileSystemObject")
				Set Out = FileOutObject.OpenTextFile(Session("LogFilename"), ForAppending, TRUE)
				sOutMsg = "Error Adding Visitor; Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "; SQL: " & rsVisitor.Source
				if fDebugMode then Response.Write "DEBUG: " & sOutMsg & "<br>"
				Out.WriteLine(now & " - " & sOutMsg)
				Out.Close
				Set FileOutObject = Nothing
				Err.Clear
			Else
				rsVisitor.Close
				if fDebugMode then Response.Write "DEBUG: Closed Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "<br>"

				' Get the Visitor.ID into a session variable for later use...

				rsVisitor.Open cmdTemp, , adOpenKeyset, adLockOptimistic
				if fDebugMode then Response.Write "DEBUG: Opened Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "; SQL: " & rsVisitor.Source & "<br>"

		   		Session("VisitorID") = rsVisitor("ID")
				Session("E-Mail") = rsVisitor("E-Mail")
				Session("FirstName") = rsVisitor("FirstName")
     			Session("LastName") = rsVisitor("LastName")
				Session("Address") = rsVisitor("Address")
				Session("Phone") = rsVisitor("Phone")
				Session("DateLastVisit") = rsVisitor("DateLastVisit")

        		' Refresh Cookie
				Response.Cookies("Data")("E-Mail") = Session("E-Mail")
				Response.Cookies("Data").expires = DateAdd("d", 90, Now())

				Session("VisitorOnFile") = True
			End If
			rsVisitor.Close
			if fDebugMode then Response.Write "DEBUG: Closed Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "<br>"
		End If

		' Cleanup...
		Set rsVisitor = Nothing
	End If
	On Error Goto 0
End If

' If Session("VisitorOnFile") is still False, then the above script could not
' Add the user to the database... so try again...

if Not Session("VisitorOnFile") Then
	if fDebugMode then Response.Write "DEBUG: Creating HTML...<br>"
%>
<html>

<head>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	<meta name="GENERATOR" content="Microsoft FrontPage (Visual InterDev Edition) 2.0">
	<title>Download</title>
</head>
<basefont face="Verdana, Arial, Helvetica">

<body bgcolor="White">

<SCRIPT LANGUAGE="VBSCRIPT">
<!--
Sub ValidateInput()
	Valid = True
	if (len(document.Register.FirstName.value) = 0) then
		alert("Please enter your First Name!")
		Valid = False
	end if
	if (len(document.Register.LastName.value) = 0) then
		alert("Please enter your Last Name!")
		Valid = False
	end if
	if (len(document.Register.EMail.value) = 0) then
		alert("Please enter your E-Mail address!")
		Valid = False
	end if

	if Valid then
		document.Register.submit()
	end if
end sub
-->
</SCRIPT>
	<center>
		<p><img src="../Images/Logos/nDuPont.gif" border="0"></p>
		<p><font size="7"><strong>Welcome</strong></font></p>
		<p>to the</p>
		<p><font size="7"><strong>Download Area</strong></font> </p>
	</center>

	<p>Please Complete the following information to register...</p>
<center>
	<form action="Default.asp?FromForm=true" name="Register" method="POST">
		<table>
			<tr>
				<td valign="top" align="right"><font size=+2 color="#FF0000">*</font> <font face="Verdana, Arial, Helvetica">First Name:</font></td>
            <td valign="top"><font face="Verdana, Arial, Helvetica"><input type="text" size="40" name="FirstName" tabindex="1"> </font></td>
        </tr>
			<tr>
				<td valign="top" align="right"><font size=+2 color="#FF0000">*</font> <font face="Verdana, Arial, Helvetica">Last Name:</font></td>
            <td valign="top"><font face="Verdana, Arial, Helvetica"><input type="text" size="40" name="LastName" tabindex="2"> </font></td>
        </tr>
        <tr>
            <td valign="top" align="right"><font size=+2 color="#FF0000">*</font> <font face="Verdana, Arial, Helvetica">E-Mail Address:</font></td>
            <td valign="top"><font face="Verdana, Arial, Helvetica"><input type="text" size="40" name="EMail" tabindex="3"></font></font></td>
        </tr>
        <tr>
            <td valign="top" align="right"><font face="Verdana, Arial, Helvetica">Address:</font></td>
            <td valign="top"><font face="Verdana, Arial, Helvetica"><textarea rows=2 cols=40 name="Address" tabindex="4"></textarea></font></td>
        </tr>
        <tr>
            <td valign="top" align="right"><font face="Verdana, Arial, Helvetica">Phone:</font></td>
            <td valign="top"><font face="Verdana, Arial, Helvetica"><input type="text" size="40" name="Phone" tabindex="5"></font></td>
        </tr>
        <tr>
            <td valign="top" align="right"><font face="Verdana, Arial, Helvetica">Purpose:</font></td>
            <td valign="top"><font face="Verdana, Arial, Helvetica"><textarea rows=4 cols=40 name="Purpose" tabindex="6"></textarea></font></td>
        </tr>
		</table>
		<p>
		<font size=+2 color="#FF0000">*</font> denotes a required field
		<p>
		<p><font size="3"><input type="button" name="B1" value="   Next   " tabindex="7" OnClick="ValidateInput()"></font></p>
	</form>
</center>

<hr>

<p><font size="2"><i>If you have problems with this page, contact the <a href="mailto:clarkfd@esvax-mail.es.dupont.com"><b>WebMaster</b></a> for further assistance.</i></font></p>
<FORM NAME="HiddenForm">
    <INPUT TYPE="HIDDEN" NAME="HiddenInput" VALUE>
</FORM>
</body>
</html>

<%
Else
%>
<html>

<head>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	<meta name="GENERATOR" content="Microsoft FrontPage (Visual InterDev Edition) 2.0">
	<title>Download</title>
</head>
<basefont face="Verdana, Arial, Helvetica">

<body bgcolor="White">
<SCRIPT LANGUAGE="VBSCRIPT">
<!--
Sub DownloadPackage()
	Const adOpenKeyset=1
	Const adLockBatchOptimistic=4
	Success = True

	select case document.Download.Package.value
<%
	Set RS = Session("adoConn").Execute("SELECT ""ID"",""Name"",""URL"" FROM ""Packages"" Order By ""Name""")
%>
<% Do While Not RS.EOF %>
		case <%= RS("ID")%>
			PackageURL = "<%=RS("URL")%>"
			PackageID = <%=RS("ID")%>
<%		RS.MoveNext 
	Loop
%>
		case else
			alert("Please select the material you wish to download!")
			Exit Sub
	end select

	Set rsAddRec = CreateObject("ADODB.Recordset")
	rsAddRec.Open "Requests", Session("adoConn"), adOpenKeyset, adLockBatchOptimistic
	rsAddRec.AddNew

	rsAddRec.Fields("VisitorID") = <%= Session("VisitorID")%>
	rsAddRec.Fields("DateRequested") = now()
	rsAddRec.Fields("PackageID") = PackageID
	On Error Resume Next
	Err.Clear
	
	rsAddRec.UpdateBatch
	If Err.Number <> 0 Then
		alert("Error Updating Visitor; Error: " & Err.Number & " " & Err.Description & " " & Err.Source)
		Err.Clear
		Success = False
	End If
	rsAddRec.Close
	If Err.Number <> 0 Then
		alert("Error Updating Visitor; Error: " & Err.Number & " " & Err.Description & " " & Err.Source)
		Err.Clear
		Success = False
	End If
	
	Set rsAddRec=Nothing
    Set FSO = Nothing

	if Success then
		top.location.href = PackageURL
	end if
End Sub
-->
</SCRIPT>

	<center>
		<p><img src="../Images/Logos/nDuPont.gif" border="0"></p>
	</center>
	<p><font size="7"><strong>Download Area</strong></font></p>

	<p>Select Material to download...</p>
<center>
	<form name="Download" method="POST">
		<select name="Package" size="1" tabindex="6">
			<option value=0></option>
<% RS.MoveFirst
	Do While Not RS.EOF %>
			<option value=<%=RS("ID")%>><%=RS("Name")%></option>
<%		RS.MoveNext
	Loop
	RS.Close
	Set RS = Nothing
%>
            </select>
		<p><font size="3"><input type="button" name="B1" value="Download" tabindex="7" OnClick="DownloadPackage()"></font></p>
	</form>
</center>

<hr>

<p><font size="2"><i><%=Session("FirstName")%>, if you have problems with this page, contact the <a href="mailto:clarkfd@esvax-mail.es.dupont.com"><b>WebMaster</b></a> for further assistance.</i></font></p>
<FORM NAME="HiddenForm">
    <INPUT TYPE="HIDDEN" NAME="HiddenInput" VALUE>
</FORM>
</body>
</html>
<%
End If
%>
