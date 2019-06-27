<script language="VBScript" runat="Server">
  LowerBound = 1
  UpperBound = 5
  Randomize
  j = Int((UpperBound - LowerBound + 1) * Rnd + LowerBound)
</script>

	<% MovieURL = GetMovieURL(j)%>
	<% MovieDim = GetMovieDim(j)%>

<script language="VBScript" runat="Server">
function GetMovieURL (i)
	select case i
		case 1
			Movie = "SciFi%20Channel/spacestation2.mov"
		case 2
			Movie = "SciFi%20Channel/clock.mov"
		case 3
			Movie = "SciFi%20Channel/vacantny.mov"
		case 4
			Movie = "SciFi%20Channel/spacewheel.mov"
		case else
			Movie = "X-Files/Xtitle.mov"	
	end select
	GetMovieURL = Movie
	'GetMovieURL = "X-Files/Xtitle.mov"
End Function

Function GetMovieDim(i)
	select case i
		case 5
			MovieDim = "width=""320"" height=""240"""
		case else
			MovieDim = "width=""160"" height=""120"""	
	end select
	GetMovieDim = MovieDim
End Function
</script>