<%@ LANGUAGE="VBScript" %>
<!-- #include virtual="/Includes/Constants.inc.asp" -->
<%
Response.Expires = 0
fDebugMode = False

On Error Resume Next

ValidateUser = False
fEmptyRecordSet = False

if fDebugMode then Response.Write "DEBUG: Debugging...<br>"
if fDebugMode then Response.Write "DEBUG: Request.QueryString(""FromForm""): " & Request.QueryString("FromForm") & "<br>"

if (Not IsEmpty(Request.QueryString("FromForm"))) then
	Session("E-Mail") = Request.Form("EMail")
			
	Set cmdTemp = Server.CreateObject("ADODB.Command")
	Set rsVisitor = Server.CreateObject("ADODB.Recordset")
	cmdTemp.CommandText = "Select * From [Visitors] Where (Email Like '" & Session("E-Mail") & "')"
	cmdTemp.CommandType = adCmdText
	Set cmdTemp.ActiveConnection = Session("KFC")
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
		rsVisitor.Fields("Email") = Request.Form("EMail")
		Session("E-Mail") = Request.Form("EMail")
		Select case Session("E-Mail")
		   Case "kclark@sss.sungard.com", "kclark12@earthlink.net", "kfc12@comcast.net"
		      Session("Owner") = True
		   Case Else
		      Session("Owner") = False
		End Select
		rsVisitor.Fields("FirstName") = Request.Form("FirstName")
		Session("FirstName") = Request.Form("FirstName")
		Session("LastName") = Request.Form("LastName")
		rsVisitor.Fields("LastName") = Request.Form("LastName")
		if Request.Form("Music") = "on" then
			rsVisitor.Fields("Music") = True
			Session("Music") = True
		else
			rsVisitor.Fields("Music") = False
			Session("Music") = False
		end if
		if Request.Form("AutoStart") = "on" then
			rsVisitor.Fields("AutoStart") = True
			Session("AutoStart") = True
		else
			rsVisitor.Fields("AutoStart") = False
			Session("AutoStart") = False
		end if
	   if Request.Form("Detached") = "on" then
			rsVisitor.Fields("Detached") = True
			Session("Detached") = True
		else
			rsVisitor.Fields("Detached") = False
			Session("Detached") = False
		end if
		if Request.Form("DoLake") = "on" then
			rsVisitor.Fields("DoLake") = True
			Session("DoLake") = True
		else
			rsVisitor.Fields("DoLake") = False
			Session("DoLake") = False
		end if
	   rsVisitor.Fields("ButtonColor") = Request.Form("ButtonColor")
	   Session("ButtonColor") = Request.Form("ButtonColor")
	   Session("LakeGIF") = Request.Form("LakeGIF")
	   rsVisitor.Fields("LakeGIF") = Request.Form("LakeGIF")

      if fDebugMode then 
			Response.Write "DEBUG: VisitorID=&quot;" & Session("VisitorID") & "&quot;<br>"
			Response.Write "DEBUG: E-Mail=&quot;" & Session("E-Mail") & "&quot;<br>"
			Response.Write "DEBUG: FirstName=&quot;" & Session("FirstName") & "&quot;<br>"
			Response.Write "DEBUG: LastName=&quot;" & Session("LastName") & "&quot;<br>"
			'Response.Write "DEBUG: Address=&quot;" & Session("Address") & "&quot;<br>"
			'Response.Write "DEBUG: Phone=&quot;" & Session("Phone") & "&quot;<br>"
			Response.Write "DEBUG: DateLastVisit=&quot;" & Session("DateLastVisit") & "&quot;<br>"
			Response.Write "DEBUG: Visits=&quot;" & Session("Visits") & "&quot;<br>"
			Response.Write "DEBUG: Music=&quot;" & Session("Music") & "&quot;<br>"
			Response.Write "DEBUG: AutoStart=&quot;" & Session("AutoStart") & "&quot;<br>"
			Response.Write "DEBUG: Detached=&quot;" & Session("Detached") & "&quot;<br>"
			Response.Write "DEBUG: DoLake=&quot;" & Session("DoLake") & "&quot;<br>"
			Response.Write "DEBUG: ButtonColor=&quot;" & Session("ButtonColor") & "&quot;<br>"
			Response.Write "DEBUG: LakeGIF=&quot;" & Session("LakeGIF") & "&&quot;<br>"
		end if

     	' Refresh Cookie
		Response.Cookies("Data")("E-Mail") = Session("E-Mail")
		Response.Cookies("Data").expires = DateAdd("d", 90, Now())

		'rsVisitor.Fields("DateLastVisit") = Session("DateLastVisit")
		'rsVisitor.Fields("Visits") = Session("Visits") + 1

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

		rsVisitor.Open "Visitors", KFC, adOpenKeyset, adLockBatchOptimistic
		if fDebugMode then Response.Write "DEBUG: Open Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "<br>"
		rsVisitor.AddNew
		if fDebugMode then Response.Write "DEBUG: AddNew Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "<br>"

		rsVisitor.Fields("Email") = Request.Form("EMail")
		rsVisitor.Fields("FirstName") = Request.Form("FirstName")
     	rsVisitor.Fields("LastName") = Request.Form("LastName")
		'	   rsVisitor.Fields("Address") = Request.Form("Address")
		'	   rsVisitor.Fields("Phone") = Request.Form("Phone")
		rsVisitor.Fields("DateLastVisit") = Session("DateLastVisit")
		if Request.Form("Music") = "on" then
			rsVisitor.Fields("Music") = True
		else
			rsVisitor.Fields("Music") = False
		end if
		if Request.Form("AutoStart") = "on" then
			rsVisitor.Fields("AutoStart") = True
		else
			rsVisitor.Fields("AutoStart") = False
		end if
		if Request.Form("Detached") = "on" then
			rsVisitor.Fields("Detached") = True
		else
			rsVisitor.Fields("Detached") = False
		end if
		if Request.Form("DoLake") = "on" then
			rsVisitor.Fields("DoLake") = True
		else
			rsVisitor.Fields("DoLake") = False
		end if
		rsVisitor.Fields("ButtonColor") = Request.Form("ButtonColor")
		rsVisitor.Fields("LakeGIF") = Request.Form("LakeGIF")
		rsVisitor.Fields("Visits") = 1

		rsVisitor.UpdateBatch
		if fDebugMode then Response.Write "DEBUG: UpdateBatch Record Set rsVisitor;  Error: " & Err.Number & " " & Err.Description & " " & Err.Source & "<br>"

		if Err.Number <> 0 Then
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
			Session("E-Mail") = rsVisitor("Email")
			Select case Session("E-Mail")
			   Case "kclark@sss.sungard.com", "kclark12@earthlink.net"
			      Session("Owner") = True
			   Case Else
			      Session("Owner") = False
			End Select
			Session("FirstName") = rsVisitor("FirstName")
     		Session("LastName") = rsVisitor("LastName")
'			Session("Address") = rsVisitor("Address")
'			Session("Phone") = rsVisitor("Phone")
			Session("DateLastVisit") = rsVisitor("DateLastVisit")
			Session("Music") = rsVisitor("Music")
			Session("AutoStart") = rsVisitor("AutoStart")
			Session("Detached") = rsVisitor("Detached")
			Session("DoLake") = rsVisitor("DoLake")
			Session("ButtonColor") = rsVisitor("ButtonColor")
			Session("LakeGIF") = rsVisitor("LakeGIF")

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
	KFC.Close
	Set KFC = Nothing

	if Not fDebugMode then Response.Redirect "/Admin/Confirm.asp"
End If
On Error Goto 0

if fDebugMode then Response.Write "DEBUG: Creating HTML...<br>"
%>
<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML//EN">
<html>

<head>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	<meta name="GENERATOR" content="Microsoft FrontPage (Visual InterDev Edition) 2.0">
	<title>Ken's WebSite Registration</title>
</head>
<basefont face="Verdana, Arial, Helvetica">
<body BACKGROUND="/Images/Backgrounds/white2.jpg" bgcolor="#FFFFFF">
    <!-- Defining JavaScript version of VBScript below so the form will work properly... -->
<script>
function validateInput() {
    alert("Validating Input!");
  //var x = document.forms["Register"]["FirstName"].value;
  if (document.forms["Register"]["FirstName"].value == "") {
    alert("Please enter your First Name!");
    return false;
  }
  if (document.forms["Register"]["LastName"].value == "") {
    alert("Please enter your Last Name!");
    return false;
  }
  if (document.forms["Register"]["EMail"].value == "") {
    alert("Please enter your E-Mail Address!");
    return false;
  }
    if (document.forms["Register"]["Music"].value <> "on") {
	    if (document..forms["Register"]["AutoStart"].value = "on") {
		    alert("AutoStart only applies to playing MIDI files, please check the Play Music box!");
		    return false;
	    }
	    if (document..forms["Register"]["Detached"].value = "on") {
		    alert("Play Detached only applies to playing MIDI files, please check the Play Music box!");
		    return false;
	    }
    }
    return true;
}</script>
<script language="VBSCRIPT">
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

	if (document.Register.Music.value <> "on") then
		if (document.Register.AutoStart.value = "on") then
			alert("AutoStart only applies to playing MIDI files, please check the Play Music box!")
			Valid = False
		end if
		if (document.Register.Detached.value = "on") then
			alert("Play Detached only applies to playing MIDI files, please check the Play Music box!")
			Valid = False
		end if
	end if

	if Valid then
		document.Register.submit()
	end if
end sub
-->
</script>

<font size="5" face="Verdana, Arial, Helvetica"><strong>Preferences</strong></font>
<hr>

<p><font size=+1 face="Verdana, Arial, Helvetica"><i>
<%
if (Len(Session("FirstName")) > 0) then
	if (Session("Owner")) then
%>Hey <b>Boss</b>,<%
	else
%>Hey <b><%=Session("FirstName")%></b>,<%
	end if
else 
%>Hey,<%
end if
%>
Thanks for Stopping By...!</font></i></p>

<p><font size=-1 face="Verdana, Arial, Helvetica">To keep
your preferences from being confused with those of other folks,
please be sure to complete the fields marked with </font><font
color="#FF0000" size=-1 face="Verdana, Arial, Helvetica">*</font><font
size=-1 face="Verdana, Arial, Helvetica">...</font></p>

<form action="<%=Application("AdminPage")%>?FromForm=true" method="POST" name="Register">
	<div align="center"><center>
	<hr>
	<p align="left"><b>Identification:</b></p>
	<table border="0">
		<tr>
			<td align="right" valign="top"><font color="#FF0000"
            size="5" face="Verdana, Arial, Helvetica">*</font><font
            face="Verdana, Arial, Helvetica"> First Name:</font></td>
            <td valign="top"><font
            face="Verdana, Arial, Helvetica"><input type="text"
            size="40" name="FirstName" value="<%=Session("FirstName")%>" required tabindex="1"> </font></td>
		</tr>
        <tr>
            <td align="right" valign="top"><font color="#FF0000"
            size="5" face="Verdana, Arial, Helvetica">*</font><font
            face="Verdana, Arial, Helvetica"> Last Name:</font></td>
            <td valign="top"><font
            face="Verdana, Arial, Helvetica"><input type="text"
            size="40" name="LastName" value="<%=Session("LastName")%>" tabindex="2" required> </font></td>
        </tr>
        <tr>
            <td align="right" valign="top"><font color="#FF0000"
            size="5" face="Verdana, Arial, Helvetica">*</font><font
            face="Verdana, Arial, Helvetica"> E-Mail Address:</font></td>
            <td valign="top"><font
            face="Verdana, Arial, Helvetica"><input type="text"
            size="40" name="EMail" value="<%=Session("E-Mail")%>" tabindex="3" required></font></td>
        </tr>
	</table>
	<hr>
	<p align="left"><b>Site Admin:</b></p>
	<ul align=left>
		<li><font face="Verdana, Arial, Helvetica"><a href="/Admin/LinksList.asp" target="Body"><b>Index Hyperlink DataBase...</b></a></font></li>
		<li><font face="Verdana, Arial, Helvetica"><a href="/Admin/VisitorList.asp" target="Body"><b>Visitor DataBase...</b></a></font></li>
		<li><font face="Verdana, Arial, Helvetica"><a href="/Admin/UserAccessInfoList.asp" target="Body"><b>User Access Information...</b></a></font></li>
	</ul>
	<hr>
	<p align="left"><b>MIDI Files:</b></p>
	<table border="0">
		<tr>
			<td align="right" valign="top"><font
            face="Verdana, Arial, Helvetica">Play MIDI Files:</font></td>
            <td valign="top"><input type="checkbox" name="Music" 
				<% if Session("Music") then %>
					checked
				<% end if%>
				tabindex="4"></td>
		</tr>
        <tr>
            <td align="right" valign="top"><font
            face="Verdana, Arial, Helvetica">AutoStart:</font></td>
            <td valign="top"><input type="checkbox" name="AutoStart" 
				<% if Session("AutoStart") then %>
					checked
				<% end if%>
				tabindex="5"></td>
        </tr>
        <tr>
            <td align="right" valign="top"><font
            face="Verdana, Arial, Helvetica">Play Detached:</font></td>
            <td valign="top"><input type="checkbox" name="Detached" 
				<% if Session("Detached") then %>
					checked
				<% end if%>
				tabindex="5"></td>
        </tr>
	</table>
	<hr>
	<p align="left"><b>Welcome Page Preferences:</b></p>
	<table border="0">
		<tr>
			<td align="right" valign="top"><font
            face="Verdana, Arial, Helvetica">Button Color:</font></td>
            <td valign="top"><select name="ButtonColor" size="1" tabindex="6">
                <option 
				<% if Session("ButtonColor") = "Gold" or IsEmpty(Session("ButtonColor")) then %>
					selected
				<% end if%>
					 >Gold</option>
                <option
				<% if Session("ButtonColor") = "Blue" then %>
					selected
				<% end if%>
					 >Blue</option>
                <option
				<% if Session("ButtonColor") = "Red" then %>
					selected
				<% end if%>
					 >Red</option>
                <option
				<% if Session("ButtonColor") = "Green" then %>
					selected
				<% end if%>
					 >Green</option>
                <option
				<% if Session("ButtonColor") = "Purple" then %>
					selected
				<% end if%>
					 >Purple</option>
                <option
				<% if Session("ButtonColor") = "Surprise Me!" then %>
					selected
				<% end if%>
					 >Surprise Me!</option>
            </select></td>
		</tr>
		<tr>
			<td align="right" valign="top"><font face="Verdana, Arial, Helvetica">Lake Applet:</font></td>
			<td valign="top"><input type="checkbox" name="DoLake" <% if Session("DoLake") then %>checked<% end if%>></td>
		</tr>
        <tr>
            <td align="right" valign="top"><font
            face="Verdana, Arial, Helvetica">Welcome Image:</font></td>
        </tr>
        <tr>
            <td valign="top" colspan=2><div align="center"><center><table border="0" width="100%">
                <tr>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/Michael%20Whelan/Reduced%20Fileteth.gif" width=90 height=110></td>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/DragonSlayer50.gif" width=74 height=100></td>
                    <td align="center"><img src="/Aircraft/Bomber%20Aircraft/B-1%20Lancer/B-1B%20Painting2.gif" width=100 height=100></td>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/Boris%20Vallejo/The%20Ice%20Schooner50.gif" width=75 height=100></td>
					 </tr>
                <tr>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 1 or IsEmpty(Session("LakeGIF")) then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="1"></td>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 2 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="2"></td>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 3 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="3"></td>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 4 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="4"></td>
					 </tr>
                <tr>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/Boris%20Vallejo/Wolves50.gif" width=75 height=99></td>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/Darrell%20Sweet/Quest.gif" width=76 height=100></td>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/Frank%20Frazetta/The%20Silver%20Warrior75.gif" width=62 height=100></td>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/avatar.gif" width=97 height=100></td>
					 </tr>
                <tr>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 5 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="5"></td>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 6 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="6"></td>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 7 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="7"></td>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 8 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="8"></td>
					 </tr>
                <tr>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/gloam.gif" width=73 height=100></td>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/robots.gif" width=63 height=100></td>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/elricsin.gif" width=54 height=100></td>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/storm.gif" width=73 height=100></td>
					 </tr>
                <tr>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 9 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="9"></td>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 10 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="10"></td>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 11 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="11"></td>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 12 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="12"></td>
					 </tr>
                <tr>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/king.gif" width=70 height=100></td>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/dragban.gif" width=61 height=100></td>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/draglord.gif" width=61 height=100></td>
                    <td align="center"><img src="/SciFi/Fantasy%20Art/royal.gif" width=77 height=100></td>
					 </tr>
                <tr>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 13 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="13"></td>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 14 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="14"></td>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 15 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="15"></td>
                    <td align="center"><input type="radio" 
				<% if Session("LakeGIF") = 16 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="16"></td>
                </tr>
                <tr>
                    <td align="center" colspan=2><img src="/Images/Backgrounds/Tiger.gif" width=153 height=100></td>
                    <td align="center" colspan=2><img src="/Images/Backgrounds/Iceberg.gif" width=219 height=100></td>
					 </tr>
					 <tr>
                    <td align="center" colspan=2><input type="radio" 
				<% if Session("LakeGIF") = 17 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="17"></td>
                    <td align="center" colspan=2><input type="radio" 
				<% if Session("LakeGIF") = 18 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="18"></td>
					 </tr>
                <tr>
                    <td align="center" colspan=4><img src="/Images/Backgrounds/carney80.gif" width=196 height=100></td>
					 </tr>
					 <tr>
                    <td align="center" colspan=4><input type="radio" 
				<% if Session("LakeGIF") = 19 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="19"></td>
					 </tr>
					 <tr>
						<td align="center" colspan=4>
							<font size="5" face="Verdana, Arial, Helvetica"><b>Surprise Me!</b></font>
						</td>
                </tr>
					 <tr>
                    <td align="center" colspan=4><input type="radio" 
				<% if Session("LakeGIF") = 0 then %>
						  checked 
				<% end if%>
						  name="LakeGIF" value="0"></td>
					 </tr>
            </table>
            </center></div></td>
		</tr>
	</table>
	</center></div>
    <p align="center"><font size="3">
<!--        <input type="button" name="B1" value="Submit" onclick="ValidateInput()"">-->
        <input type="submit" name="B1" value="Submit" onsubmit="return ValidateInput()"> <!-- JavaScript -->
    </font></p>
</form>

<hr>

<p><font size="2"><i>
<% if Session("FirstName") <> "" then %>
<b><%=Session("FirstName")%></b>, if
<% else %>
If,
<% end if%>
you have problems with this page, contact
the </i></font><a href="mailto:<%=Session("WebMasterEmail")%>"><font
size="2"><b><i>WebMaster</i></b></font></a><font size="2"><i> for
further assistance.</i></font></p>

<form name="HiddenForm">
    <input type="hidden" name="HiddenInput">
</form>
</body>
</html>
