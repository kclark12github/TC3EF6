<% 
Dim avarTypes
If IsEmpty(Application(strDFName & "_Lookup_Types")) Or strPagingMove = "Requery" Then
    Set Hobby = Server.CreateObject("ADODB.Connection")
    Hobby.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Hobby.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Hobby.Open Application("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
    'TODO: This should be refined with separate Types for the different Hobby Tables...
	Set rsTypes = Hobby.Execute("Select Distinct Type From Kits Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From Decals Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From DetailSets Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From FinishingProducts Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From Rockets Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From Tools Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From Trains Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From AircraftDesignations Where [Type] Is Not Null Union " & _
        "Order By [Type];")
	avarTypes = Null
	On Error Resume Next
	avarTypes = rsTypes.GetRows()
	Application.Lock
	Application(strDFName & "_Lookup_Types") = avarTypes
	Application.Unlock
Else
	avarTypes = Application(strDFName & "_Lookup_Types")
End If
%>
