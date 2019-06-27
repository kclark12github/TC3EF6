<% 
Dim avarConditions
If IsEmpty(Application(strDFName & "_Lookup_Conditions")) Or strPagingMove = "Requery" Then
    Set Hobby = Server.CreateObject("ADODB.Connection")
    Hobby.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Hobby.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Hobby.Open Application("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsConditions = Hobby.Execute("Select Distinct Condition From Kits Where Condition Is Not Null Order By Condition;")
	avarConditions = Null
	On Error Resume Next
	avarConditions = rsConditions.GetRows()
	Application.Lock
	Application(strDFName & "_Lookup_Conditions") = avarConditions
	Application.Unlock
Else
	avarConditions = Application(strDFName & "_Lookup_Conditions")
End If
%>

