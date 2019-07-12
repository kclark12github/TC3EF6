<% 
Dim avarManufacturers
If IsEmpty(Application(strRSName & "_Lookup_Manufacturers")) Or strPagingMove = "Requery" Then
	avarManufacturers = Null
	Set adoRS = Session("adoConn").Execute("Select Distinct Manufacturer From [" & strTableName & "] Where Manufacturer Is Not Null Union " & _
        "Select Distinct Manufacturer From Decals Where Manufacturer Is Not Null Union " & _
        "Select Distinct Manufacturer From DetailSets Where Manufacturer Is Not Null Union " & _
        "Select Distinct Manufacturer From FinishingProducts Where Manufacturer Is Not Null Union " & _
        "Select Distinct Manufacturer From Rockets Where Manufacturer Is Not Null Union " & _
        "Select Distinct Manufacturer From Tools Where Manufacturer Is Not Null Union " & _
        "Select Distinct Manufacturer From Trains Where Manufacturer Is Not Null " & _
        "Order By Manufacturer;")
	'On Error Resume Next
	avarManufacturers = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Manufacturers") = avarManufacturers
	Application.Unlock
Else
	avarManufacturers = Application(strRSName & "_Lookup_Manufacturers")
End If
%>

