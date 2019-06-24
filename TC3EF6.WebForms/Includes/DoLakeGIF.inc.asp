<script language="VBScript" runat="Server">
'============================================================================
Function DoLakeGIF()
	Const LowerBound = 1
	Const UpperBound = 19

	GIFnum = Session("LakeGIF")
	if GIFnum = 0 then	' "Surprise Me"...
		Randomize
		GIFnum = Int((UpperBound - LowerBound + 1) * Rnd + LowerBound)
	end if

	Select Case GIFnum
		Case 1
			If Session("DoLake") Then
				GIFfile = "/SciFi/Fantasy%20Art/Michael%20Whelan/Reduced%20Fileteth.gif"
				GIFwidth = "357"
				GIFlength = "800"
			Else
				GIFfile = "/SciFi/Fantasy%20Art/Michael%20Whelan/Filed2.jpg"
				GIFwidth = "467"
				GIFlength = 675
			End If
		Case 2
			If Session("DoLake") Then
				GIFfile = "/SciFi/Fantasy%20Art/DragonSlayer50.gif"
				GIFwidth = "368"
				GIFlength = "800"
			Else
				GIFfile = "/SciFi/Fantasy%20Art/DragonSlayer.gif"
				GIFwidth = "368"
				GIFlength = 497
			End If
		Case 3
			If Session("DoLake") Then
				GIFfile = "/Aircraft/Bomber%20Aircraft/B-1%20Lancer/B-1B%20Painting2.gif"
				GIFwidth = "337"
				GIFlength = "640"
			Else
				GIFfile = "/Aircraft/Bomber%20Aircraft/B-1%20Lancer/B-1B%20Painting.gif"
				GIFwidth = "337"
				GIFlength = 467
			End If
		Case 4
			If Session("DoLake") Then
				GIFfile = "/SciFi/Fantasy%20Art/Boris%20Vallejo/The%20Ice%20Schooner50.gif"
				GIFwidth = "296"
				GIFlength = "640"
			Else
				GIFfile = "/SciFi/Fantasy%20Art/Boris%20Vallejo/The%20Ice%20Schooner.jpg"
				GIFwidth = "296"
				GIFlength = 397
			End If
		Case 5
			If Session("DoLake") Then
				GIFfile = "/SciFi/Fantasy%20Art/Boris%20Vallejo/Wolves50.gif"
				GIFwidth = "300"
				GIFlength = "640"
			Else
				GIFfile = "/SciFi/Fantasy%20Art/Boris%20Vallejo/Wolves.jpg"
				GIFwidth = "300"
				GIFlength = 397
			End If
		Case 6
			GIFfile = "/SciFi/Fantasy%20Art/Darrell%20Sweet/Quest.gif"
			GIFwidth = "298"
			If Session("DoLake") Then
				GIFlength = "640"
			Else
				GIFlength = 397
			End If
		Case 7
			If Session("DoLake") Then
				GIFfile = "/SciFi/Fantasy%20Art/Frank%20Frazetta/The%20Silver%20Warrior75.gif"
				GIFwidth = "321"
				GIFlength = "800"
			Else
				GIFfile = "/SciFi/Fantasy%20Art/Frank%20Frazetta/The%20Silver%20Warrior.jpg"
				GIFwidth = "321"
				GIFlength = 519
			End If
		Case 8
			GIFfile = "/SciFi/Fantasy%20Art/avatar.gif"
			GIFwidth = "293"
			If Session("DoLake") Then
				GIFlength = "580"
			Else
				GIFlength = "300"
			End If
		Case 9
			GIFfile = "/SciFi/Fantasy%20Art/gloam.gif"
			GIFwidth = "276"
			If Session("DoLake") Then
				GIFlength = "640"
			Else
				GIFlength = "375"
			End If
		Case 10
			GIFfile = "/SciFi/Fantasy%20Art/robots.gif"
			GIFwidth = "238"
			If Session("DoLake") Then
				GIFlength = "640"
			Else
				GIFlength = "375"
			End If
		Case 11
			GIFfile = "/SciFi/Fantasy%20Art/elricsin.gif"
			GIFwidth = "225"
			If Session("DoLake") Then
				GIFlength = "640"
			Else
				GIFlength = "412"
			End If
		Case 12
			GIFfile = "/SciFi/Fantasy%20Art/storm.gif"
			GIFwidth = "276"
			If Session("DoLake") Then
				GIFlength = "640"
			Else
				GIFlength = "375"
			End If
		Case 13
			GIFfile = "/SciFi/Fantasy%20Art/king.gif"
			GIFwidth = "264"
			If Session("DoLake") Then
				GIFlength = "640"
			Else
				GIFlength = "375"
			End If
		Case 14
			GIFfile = "/SciFi/Fantasy%20Art/dragban.gif"
			GIFwidth = "232"
			If Session("DoLake") Then
				GIFlength = "640"
			Else
				GIFlength = "375"
			End If
		Case 15
			GIFfile = "/SciFi/Fantasy%20Art/draglord.gif"
			GIFwidth = "231"
			If Session("DoLake") Then
				GIFlength = "640"
			Else
				GIFlength = "375"
			End If
		Case 16
			GIFfile = "/SciFi/Fantasy%20Art/royal.gif"
			GIFwidth = "279"
			If Session("DoLake") Then
				GIFlength = "640"
			Else
				GIFlength = "360"
			End If
		Case 17
			If Session("DoLake") Then
				GIFfile = "/Images/Backgrounds/Tiger.gif"
				GIFwidth = "298"
				GIFlength = "360"
			Else
				GIFfile = "/Images/Backgrounds/Tiger.jpg"
				GIFwidth = "736"
				GIFlength = "488"
			End If
		Case 18
			If Session("DoLake") Then
				GIFfile = "/Images/Backgrounds/Iceberg.gif"
				GIFwidth = "298"
				GIFlength = "260"
			Else
				GIFfile = "/Images/Backgrounds/Iceberg.jpg"
				GIFwidth = "733"
				GIFlength = "495"
			End If
		Case 19
			If Session("DoLake") Then
				GIFfile = "/Images/Backgrounds/carney80.gif"
				GIFwidth = "510"
				GIFlength = "500"
			Else
				GIFfile = "/Images/Backgrounds/carney1.jpg"
				GIFwidth = 512
				GIFlength = 326
			End If
	End Select
	If Session("DoLake") Then
		Response.Write("<applet codebase=""Java/"" code=""Lake"" width=" & GIFwidth & " height=" & GIFlength & ">")
		Response.Write("	<param name=""image"" value=""" & GIFfile & """>")
		Response.Write("	<p>Must use a Java-enabled Browser to display this image.</p>")
		Response.Write("</applet> ")
	Else
		Response.Write("<img src=""" & GIFfile & """ width=" & GIFwidth & " height=" & GIFlength & " border=0>")
	End If
	DoLakeGIF = True
End Function
</script>
