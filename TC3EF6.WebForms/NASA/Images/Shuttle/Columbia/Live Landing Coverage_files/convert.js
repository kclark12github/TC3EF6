//var Measure = "";
//var Unit = "";
function convertit(M,U)
{
	var Measure = M;
	var Unit = U;
	//var Page = "http://www.ksc.nasa.gov/convert/convertit2.html";
	var Page = "http://www.ksc.nasa.gov/convert/convertit2.html?M="+Measure+"&U="+Unit;
	var Converted = window.open(Page,"Conversion","toolbar=no,location=no,status=no,menubar=no,scrollbars=no,resizable=no,width=400,height=70");
	Converted.focus();
}