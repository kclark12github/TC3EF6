<% 
Dim avarScales
If IsEmpty(Application(strDFName & "_Lookup_Scales")) Or strPagingMove = "Requery" Then
    Set Hobby = Server.CreateObject("ADODB.Connection")
    Hobby.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Hobby.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Hobby.Open Application("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsScales = Hobby.Execute("Select Distinct Scale From Kits Where Scale Is Not Null Union " & _
        "Select Distinct Scale From Decals Where Scale Is Not Null Union " & _
        "Select Distinct Scale From DetailSets Where Scale Is Not Null Union " & _
        "Select Distinct Scale From Rockets Where Scale Is Not Null Union " & _
        "Select Distinct Scale From Trains Where Scale Is Not Null " & _
        "Order By ProductCatalog;")
	avarScales = Null
	On Error Resume Next
	avarScales = rsScales.GetRows()
	Application.Lock
	Application(strDFName & "_Lookup_Scales") = avarScales
	Application.Unlock
Else
	avarScales = Application(strDFName & "_Lookup_Scales")
End If
%>
