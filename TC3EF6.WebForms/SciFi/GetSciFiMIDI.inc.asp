<script language="VBScript" runat="Server">
  LowerBound = 1
  UpperBound = 16
  Randomize
  x = Int((UpperBound - LowerBound + 1) * Rnd + LowerBound)
</script>

  <% SongURL = GetSongURL(x)%>
  <% Delay = "" %>
  <% AutoStart = "" %>

<script language="VBScript" runat="Server">
function GetSongURL (i)
select case i
   case 1
      MIDI = "/Sounds/MIDI/clardlun.mid"
   case 2
      MIDI = "/Sounds/MIDI/Soundtracks/ds9.mid"
   case 3
      MIDI = "/Sounds/MIDI/Soundtracks/flutsong.mid"
   case 4
      MIDI = "/Sounds/MIDI/Soundtracks/picard.mid"
   case 5
      MIDI = "/Sounds/MIDI/Soundtracks/startrek.mid"
   case 6
      MIDI = "/Sounds/MIDI/Soundtracks/starwars.mid"
   case 7
      MIDI = "/Sounds/MIDI/Soundtracks/sttng.mid"
   case 8
      MIDI = "/Sounds/MIDI/Soundtracks/timewarp.mid"
   case 9
      MIDI = "/Sounds/MIDI/Soundtracks/tubbell1.mid"
   case 10
      MIDI = "/Sounds/MIDI/Soundtracks/voyager.mid"
   case 11
      MIDI = "/Sounds/MIDI/Soundtracks/voyager2.mid"
   case 12
      MIDI = "/Sounds/MIDI/Soundtracks/x_files4.mid"
   case 13
      MIDI = "/Sounds/MIDI/Soundtracks/xfiles.mid"
   case 14
      MIDI = "/Sounds/MIDI/Soundtracks/xfiles1.mid"
   case 15
      MIDI = "/Sounds/MIDI/Soundtracks/zone.mid"
   case 16
      MIDI = "/Sounds/MIDI/Soundtracks/bg_short.mid"
   case else
      MIDI = "/Sounds/MIDI/ClassicRock/Pink Floyd/Shine On You Crazy Diamond.mid"
end select
GetSongURL = MIDI
end function
</script>