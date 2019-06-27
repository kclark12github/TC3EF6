<% 
Dim avarServices
If IsEmpty(Application(strDFName & "_Lookup_Services")) Or strPagingMove = "Requery" Then
    Set Hobby = Server.CreateObject("ADODB.Connection")
    Hobby.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Hobby.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Hobby.Open Application("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsServices = Hobby.Execute("Select Distinct Service From Kits Where Service Is Not Null Order By Service;")
	avarServices = Null
	On Error Resume Next
	avarServices = rsServices.GetRows()
	Application.Lock
	Application(strDFName & "_Lookup_Services") = avarServices
	Application.Unlock
Else
	avarServices = Application(strDFName & "_Lookup_Services")
End If
%>
