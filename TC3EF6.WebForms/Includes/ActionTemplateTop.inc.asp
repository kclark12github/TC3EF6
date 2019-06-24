<% 
If Not IsEmpty(Request("DataAction")) Then
	strDataAction = Trim(Request("DataAction"))
Else
	Response.Redirect strBasePageName & "Form.asp?FormMode=Edit"
End If

On Error Resume Next
ListFileExists = True
Set fs = CreateObject("Scripting.FileSystemObject")
Set a = fs.OpenTextFile(Server.MapPath(strBasepageName & "List.asp"), ForReading, FALSE)
If Err.Number <> 0 Then
	ListFileExists = False
Else
	a.Close
End If
Set fs = Nothing
Set a = Nothing
On Error Goto 0

'------------------
' Action handler
'------------------

Select Case strDataAction
%>
