var Countdown
function popit()
{
	if (!Countdown || Countdown.closed)
	{
		now = new Date();
		Clicked = (now.getHours()*3600)+(now.getMinutes()*60)+(now.getSeconds());
		Countdown = window.open("http://CountDownClock.ksc.nasa.gov/index2.cfm?CT="+Clicked,"Countdown","toolbar=no,location=no,status=no,menubar=no,scrollbars=no,resizable=no,width=201,height=132");
	} else {
		Countdown.focus();
	}
}