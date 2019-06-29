using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TC3EF6.Data;
using TC3EF6.Domain.Classes;

namespace TC3EF6.WebForms
{
    public class ImageData
    {
        public string Path { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
    public class BasePage : Page
    {
        protected List<ImageData> Images { get; private set; }
        public bool Owner { get => !string.IsNullOrEmpty(Context.User.Identity.Name) && (Context.User.Identity.Name == (string)Application["Owner"]); }
        protected Visitor Visitor { get => (Visitor)Session["Visitor"]; }
        protected BasePage() : base()
        {
            Images = new List<ImageData>();
            Images.Add(new ImageData { Path = "", Width = 0, Height = 0 });  // "Surprise Me!"
            Images.Add(new ImageData { Path = "/SciFi/Fantasy Art/Michael%20Whelan/Reduced%20Fileteth.gif", Width = 180, Height = 220 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/DragonSlayer50.gif", Width = 148, Height = 200 });
            Images.Add(new ImageData { Path = "/Aircraft/Bomber%20Aircraft/B-1%20Lancer/B-1B%20Painting2.gif", Width = 200, Height = 200 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/Boris%20Vallejo/The%20Ice%20Schooner50.gif", Width = 150, Height = 200 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/Boris%20Vallejo/Wolves50.gif", Width = 150, Height = 198 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/Darrell%20Sweet/Quest.gif", Width = 152, Height = 200 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/Frank%20Frazetta/The%20Silver%20Warrior75.gif", Width = 124, Height = 200 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/avatar.gif", Width = 194, Height = 200 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/gloam.gif", Width = 146, Height = 200 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/robots.gif", Width = 126, Height = 200 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/elricsin.gif", Width = 108, Height = 200 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/storm.gif", Width = 146, Height = 200 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/king.gif", Width = 140, Height = 200 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/dragban.gif", Width = 122, Height = 200 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/draglord.gif", Width = 122, Height = 200 });
            Images.Add(new ImageData { Path = "/SciFi/Fantasy%20Art/royal.gif", Width = 154, Height = 200 });
            Images.Add(new ImageData { Path = "/Images/Backgrounds/Tiger.gif", Width = 153, Height = 100 });
            Images.Add(new ImageData { Path = "/Images/Backgrounds/Iceberg.gif", Width = 219, Height = 100 });
            Images.Add(new ImageData { Path = "/Images/Backgrounds/carney80.gif", Width = 196, Height = 100 });
        }
        protected void LogMessage(string Message)
        {
            using (var context = new TCContext())
            {
                context.LogMessage((string)Application["AppName"], Message);
            }
        }
        protected static void LogMessage(string Milestone, string Message)
        {
            using (var context = new TCContext())
            {
                context.LogMessage(Milestone, Message);
            }
        }
        //private DateTime? PageLastModified
        //{
        //    get
        //    {
        //        string path = Server.MapPath(Request.Url.AbsolutePath);
        //        if (!File.Exists(path)) path = $"{path}.aspx";
        //        if (!File.Exists(path)) return null;
        //        return new System.IO.FileInfo(path).LastWriteTime;
        //    }
        //}
        //protected virtual string GetPageLastModified()
        //{
        //    DateTime? plm = this.PageLastModified;
        //    if (plm == null) return $"Cannot determine Last Modified Date for {Server.MapPath(Request.Url.AbsolutePath)}";
        //    return $"{plm:dddd MMMM d, yyyy @ hh:mm tt}";
        //}
        #region DataFunctions (ASP)
        public bool DebugMode { get; set; }
        #region Constants
        //---- Text Stream Object Enum Values ----
        public const int ForReading = 1; //Open a file for reading only. No writing to this file can take place.
        public const int ForWriting = 2; //Open a file for writing. If a file with the same name exists, its previous contents are overwritten.
        public const int ForAppending = 8;

        //---- Cmd Object Enum Values ----
        public const int adCmdText = 1;
        public const int adCmdTable = 2;
        public const int adCmdStoredProc = 4;
        public const int adCmdUnknown = 8;

        //---- FieldAttributeEnum Values ----
        //public const int adFldUpdatable = &H00000004;
        //public const int adFldUnknownUpdatable = &H00000008;
        //public const int adFldIsNullable = &H00000020;

        //---- CursorTypeEnum Values ----
        public const int adOpenForwardOnly = 0;
        public const int adOpenKeyset = 1;
        public const int adOpenDynamic = 2;
        public const int adOpenStatic = 3;

        //---- LockTypeEnum Values ----
        public const int adLockReadOnly = 1;		// Read-only you cannot alter the data.
        public const int adLockPessimistic = 2;		// Pessimistic locking, record by record the provider does what is necessary to ensure successful editing of the records, usually by locking records at the data source immediately upon editing.
        public const int adLockOptimistic = 3;		// Optimistic locking, record by record the provider uses optimistic locking, locking records only when you call the Update method.
        public const int adLockBatchOptimistic = 4;	// Optimistic batch updates required for batch update mode as opposed to immediate update mode.

        //---- DataTypeEnum Values ----
        public const int adBigInt = 20;				// An 8-byte signed integer
        public const int adBinary = 128;			// A binary value
        public const int adBoolean = 11;			// A Boolean value
        public const int adBSTR = 8;				// A null-terminated character string (Unicode)
        public const int adChar = 129;				// A String value
        public const int adCurrency = 6;			// A currency value (8-byte signed integer scaled by 10,000)
        public const int adDate = 7;				// A Date value
        public const int adDBDate = 133;			// A date value (yyyymmdd)
        public const int adDBTime = 134;			// A time value (hhmmss)
        public const int adDBTimeStamp = 135;		// A date-time stamp (yyyymmddhhmmss plus a fraction in billionths)
        public const int adDecimal = 14;			// An exact numeric value with a fixed precision and scale
        public const int adDouble = 5;				// A double-precision floating point value
        public const int adEmpty = 0;				// No value was specified
        public const int adError = 10;				// A 32-bit error code
        public const int adGUID = 72;				// A globally unique identifier (GUID)
        public const int adIDispatch = 9;			// A pointer to an IDispatch interface on an OLE object
        public const int adInteger = 3;				// A 4-byte signed integer
        public const int adIUnknown = 13;			// A pointer to an IUnknown interface on an OLE object
        public const int adLongVarBinary = 205;		// A long binary value (Parameter object only)
        public const int adLongVarChar = 201;		// A long String value (Parameter object only)
        public const int adLongVarWChar = 203;		// A long null-terminated string value (Parameter object only)
        public const int adNumeric = 131;			// An exact numeric value with a fixed precision and scale
        public const int adSingle = 4;				// A single-precision floating point value
        public const int adSmallInt = 2;			// A 2-byte signed integer
        public const int adTinyInt = 16;			// A	1-byte signed integer
        public const int adUnsignedBigInt = 21;		// An 8-byte unsigned integer
        public const int adUnsignedInt = 19;		// A 4-byte unsigned integer
        public const int adUnsignedSmallInt = 18;	// A 2-byte unsigned integer
        public const int adUnsignedTinyInt = 17;	// A 1-byte unsigned integer
        public const int adUserDefined = 132;		// A user-defined variable
        public const int adVarBinary = 204;			// A binary value (Parameter object only)
        public const int adVarChar = 200;			// A String value (Parameter object only)
        public const int adVariant = 12;			// An OLE Automation Variant
        public const int adVarWChar = 202;			// A null-terminated Unicode character string (Parameter object only)
        public const int adWChar = 130;				// A null-terminated Unicode character string

        //---- Error Values ----
        public const int errInvalidPrefix = 20001;		//Invalid wildcard prefix
        public const int errInvalidOperator = 20002;	//Invalid filtering operator
        public const int errInvalidOperatorUse = 20003;	//Invalid use of LIKE operator
        public const int errNotEditable = 20011;		//Field not editable
        public const int errValueRequired = 20012;		//Value required

        //---- Other Values ----
        public const int dfMaxSize = 100;
        #endregion
        //-------------------------------------------------------------------------------
        // Purpose:  Substitutes Empty for Null and trims leading/trailing spaces
        // Inputs:   varTemp	- the target value
        // Returns:	The processed value
        //-------------------------------------------------------------------------------
        public string ConvertNull(string varTemp)
        {
            if (varTemp == null)
                return string.Empty;
            else
                return varTemp.Trim();
        }

        //-------------------------------------------------------------------------------
        // Purpose:  Substitutes Null for Empty
        // Inputs:   varTemp	- the target value
        // Returns:	The processed value
        //-------------------------------------------------------------------------------
        public string RestoreNull(string varTemp)
        {
            if (varTemp == string.Empty)
                return null;
            else
                return varTemp;
        }

        public void RaiseError(int intErrorValue, string strFieldName)
        {
            string strMsg = string.Empty;
            switch (intErrorValue)
            {
                case errInvalidPrefix:
                    strMsg = "Wildcard characters * and % can only be used at the end of the criteria";
                    break;
                case errInvalidOperator:
                    strMsg = "Invalid filtering operators - use <= or >= instead.";
                    break;
                case errInvalidOperatorUse:
                    strMsg = "The 'Like' operator can only be used with strings.";
                    break;
                case errNotEditable:
                    strMsg = $"{strFieldName} field is not editable.";
                    break;
                case errValueRequired:
                    strMsg = $"A value is required for {strFieldName}.";
                    break;
                default:
                    strMsg = $"Unexpected error (#{intErrorValue}) encountered while processing {strFieldName}.";
                    break;
            }
            throw new ApplicationException(strMsg);
        }

        //-------------------------------------------------------------------------------
        // Purpose:  Embeds bracketing quotes around the string
        // Inputs:   varTemp	- the target value
        // Returns:	The processed value
        //-------------------------------------------------------------------------------
        public string QuotedString(string varTemp)
        {
            if (varTemp == null)
                return @"""""";
            else
                return @"""{varTemp}""";
        }

        //-------------------------------------------------------------------------------
        // Purpose:  Converts to subtype of string - handles Null cases
        // Inputs:   varTemp	- the target value
        // Returns:	The processed value
        //-------------------------------------------------------------------------------
        public string ConvertToString(object varTemp)
        {
            if (varTemp == null)
                return null;
            else
                return (string)varTemp;
        }

        //-------------------------------------------------------------------------------
        // Purpose:  Handles embedded quotes in string
        // Inputs:   varTemp	- the target value
        // Returns:	The processed value
        //-------------------------------------------------------------------------------
        public string SQLQuotes(string varTemp)
        {
            string retVal = varTemp;
            if (retVal == null)
                if (DebugMode) LogMessage($"DEBUG: SQLQuotes: null");
                else
                {
                    retVal = varTemp.Replace("'", "''");
                    if (DebugMode) LogMessage($"DEBUG: SQLQuotes: {retVal}");
                }
            return retVal;
        }

        //-------------------------------------------------------------------------------
        // Purpose:  Tests to equality while dealing with Null values
        // Inputs:   varTemp1	- the first value
        //			 varTemp2	- the second value
        // Returns:	True if equal, False if not
        //-------------------------------------------------------------------------------
        public bool IsEqual(string varTemp1, string varTemp2)
        {
            if (varTemp1 == null && varTemp2 == null) return true;
            if (varTemp1 == null || varTemp2 == null) return false;
            if (varTemp1 == varTemp2) return true;

            return false;
        }

        //-------------------------------------------------------------------------------
        // Purpose:  Tests string to see if it is a URL by looking for protocol
        // Inputs:   varTemp	- the target value
        // Returns:	True - if is URL, False if not
        //-------------------------------------------------------------------------------
        public bool IsURL(string varTemp)
        {
            if (varTemp == null) return false;
            string testURL = varTemp.ToLower();
            if (testURL.StartsWith("http:/")) return true;
            if (testURL.StartsWith("file:/")) return true;
            if (testURL.StartsWith("mailto:/")) return true;
            if (testURL.StartsWith("ftp:/")) return true;
            if (testURL.StartsWith("gopher:/")) return true;
            if (testURL.StartsWith("news:/")) return true;
            if (testURL.StartsWith("https:/")) return true;
            if (testURL.StartsWith("telnet:/")) return true;
            if (testURL.StartsWith("nntp:/")) return true;
            if (testURL.EndsWith("/")) return true;
            if (testURL.EndsWith(".asp")) return true;
            if (testURL.EndsWith(".aspx")) return true;
            if (testURL.EndsWith(".htm")) return true;
            if (testURL.EndsWith(".html")) return true;
            return false;
        }

        //-------------------------------------------------------------------------------
        // Purpose:  Tests whether the field in the recordset is required
        // Assumes: 	That the recordset containing the field is open
        // Inputs:   strFieldName	- the name of the field in the recordset
        // Returns:	True if updatable, False if not
        //-------------------------------------------------------------------------------
        //Function IsRequiredField(strFieldName)
        //    IsRequiredField = False
        //    If(Session(strDFName & "_Recordset")(strFieldName).Attributes And adFldIsNullable) = 0 Then
        //       IsRequiredField = True
        //    End If
        //End Function

        //-------------------------------------------------------------------------------
        // Purpose:  Tests whether the field in the recordset is updatable
        // Assumes: 	That the recordset containing the field is open
        // Effects:	Sets Err object if field is not updatable
        // Inputs:   strFieldName	- the name of the field in the recordset
        // Returns:	True if updatable, False if not
        //-------------------------------------------------------------------------------
        //Function CanUpdateField(strFieldName)
        //    Dim intUpdatable
        //    intUpdatable = (adFldUpdatable Or adFldUnknownUpdatable)
        //    CanUpdateField = True
        //    If(Session(strDFName & "_Recordset")(strFieldName).Attributes And intUpdatable) = False Then
        //        CanUpdateField = False
        //        Exit Function
        //    End If
        //End Function

        //-------------------------------------------------------------------------------
        // Purpose:  Constructs a name/value pair for a where clause
        // Effects:	Sets Err object if the criteria is invalid
        // Inputs:   strFieldName	- the name of the field in the recordset
        //			strCriteria		- the criteria to use
        //			strDelimiter	- the proper delimiter to use
        // Returns:	The name/value pair as a string
        //-------------------------------------------------------------------------------
        public string PrepFilterItem(string strFieldName, string strCriteria, string strDelimiter)
        {
            string strValue = string.Empty;
            string strOperator = string.Empty;
            int intEndOfWord = 0;
            string strWord = string.Empty;
            // Char, VarChar, and LongVarChar must be single quote delimited.
            // Dates are pound sign delimited.
            // Numerics should not be delimited.
            // String to Date conversion rules are same as VBA.
            // Only support for ANDing.
            // Support the LIKE operator but only with * or % as suffix.

            strCriteria = SQLQuotes(strCriteria).Trim();  //remove leading/trailing spaces
            strOperator = "=";              //sets default
            strValue = strCriteria;          //sets default

            // Get first word and look for operator
            intEndOfWord = strCriteria.IndexOf(" ");
            if (intEndOfWord >= 0)
            {
                strWord = strCriteria.Substring(0, intEndOfWord - 1).ToUpper();
                // See if the word is an operator
                switch (strWord)
                {
                    case "=":
                    case "<":
                    case ">":
                    case "<=":
                    case ">=":
                    case "<>":
                    case "LIKE":
                        strOperator = strWord;
                        strValue = strCriteria.Substring(intEndOfWord + 1).Trim();
                        break;
                    case "=<":
                    case "=>":
                        RaiseError(errInvalidOperator, strFieldName);
                        break;
                }
            }
            else
            {
                strWord = strCriteria.Substring(0, 2).ToUpper();
                switch (strWord)
                {
                    case "<=":
                    case ">=":
                    case "<>":
                        strOperator = strWord;
                        strValue = strCriteria.Substring(3).Trim();
                        break;
                    case "=<":
                    case "=>":
                        RaiseError(errInvalidOperator, strFieldName);
                        break;
                    default:
                        strWord = strCriteria.Substring(0, 1).ToUpper();
                        switch (strWord)
                        {
                            case "=":
                            case "<":
                            case ">":
                                strOperator = strWord;
                                strValue = strCriteria.Substring(1).Trim();
                                break;
                        }
                        break;
                }
            }
            // Make sure LIKE is only used with strings
            if (strOperator == "LIKE" && strDelimiter != "'") RaiseError(errInvalidOperatorUse, strFieldName);

            // Strip any extraneous delimiters because we add them anyway Single Quote
            if (strValue.StartsWith("'")) strValue = strValue.Substring(1);
            if (strValue.EndsWith("'")) strValue = strValue.Substring(0, strValue.Length -1);
            // Double Quote - just in case
            if (strValue.StartsWith(@"""")) strValue = strValue.Substring(1);
            if (strValue.EndsWith(@"""")) strValue = strValue.Substring(0, strValue.Length - 1);
            // Pound sign - dates
            if (strValue.StartsWith(@"#")) strValue = strValue.Substring(1);
            if (strValue.EndsWith(@"#")) strValue = strValue.Substring(0, strValue.Length - 1);

            // Check for leading wildcards
            if (strValue.StartsWith(@"*") || strValue.StartsWith(@"%")) RaiseError(errInvalidPrefix, strFieldName);
            return $"[{strFieldName}] {strOperator} {strDelimiter}{strValue}{strDelimiter}";
        }

//        //--------------------------------------------------------------------------------------------
//        // Purpose:  Produces an Error results page
//        // Inputs:   ErrNumber		- The Err.Number
//        //			ErrSource		- The Source of the error (Err.Source)
//        //			ErrDescription	- The Error Description
//        //			SQLsource		- The errant SQL statement (if any)
//        //			strFooterURL	- used to direct the SunGard logo link on the bottom of the page
//        //			strFooterTitle	- used to label the SunGard logo link on the bottom of the page
//        //--------------------------------------------------------------------------------------------
//Sub ErrorHandler(ErrNumber, ErrSource, ErrDescription, SQLsource, strFooterURL, strFooterTitle)

//    If Theme = "" Then Theme = Application("Theme")

//    If strHomeGIF = "" Then
//        strHomeGIF = Application("strHomeGIF")

//        strFooterGIFdim = Application("strFooterGIFdim")

//    End If

//    If strFooterURL = "" Then strFooterURL = Application("strFooterURL")

//    If strFooterTitle = "" Then
//        strFooterTitle = Application("strFooterTitle")

//    Else
//        If Left(strFooterTitle, 12) <> "Back to the " Then strFooterTitle = "Back to the " & strFooterTitle

//    End If

//	// Add additional error information to clarify specific errors

//    Select Case ErrNumber

//        Case -2147467259
//			strErrorAdditionalInfo = "  This may be caused by an attempt to update a non-primary table in a view."
//		Case Else

//            strErrorAdditionalInfo = ""
//	End Select


//    Response.Write "<html>"
//	Response.Write "<head>"
//	Response.Write "	<meta NAME=""GENERATOR"" CONTENT=""Microsoft Visual InterDev"">"
//	Response.Write "	<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=ISO-8859-1"">"
//	Response.Write "	<meta NAME=""keywords"" CONTENT=""Microsoft Data Form, " & strFormTitle & """>"
//	Response.Write "	<title>"& strFormTitle & "</title>"
//	Response.Write "</head>"
//	Response.Write "<basefont FACE=""Arial, Helvetica, sans-serif"">"
//	Response.Write "<link REL=""STYLESHEET"" HREF=""/Stylesheets/" & Theme & "/Style2.css"">"
//	Response.Write "<body BACKGROUND=""/Images/" & Theme & "/Background/Back2.jpg"" BGCOLOR=""White"" TOPMARGIN=0>"
//	Response.Write "<table CELLSPACING=""0"" CELLPADDING=""0"" BORDER=""0"" WIDTH=""100%""><tr><td WIDTH=""20"">&nbsp;</td><td>"
//	Response.Write "	<table WIDTH=""100%"" CELLSPACING=""0"" CELLPADDING=""0"" BORDER=""0"">"
//	Response.Write "		<tr>"
//	Response.Write "			<th NOWRAP ALIGN=""Left"" BGCOLOR=""Silver"" BACKGROUND=""/Images/" & Theme & "/Navigation/Nav1.jpg"">"
//	Response.Write "				<font SIZE=""6"">&nbsp;Message:&nbsp;</font>"
//	Response.Write "			</th>"
//	Response.Write "		</tr>"
//	Response.Write "		<tr>"
//	Response.Write "			<td BGCOLOR=""#FFFFCC"">"
//	Response.Write "			<font SIZE=""3"">"

//	Select Case strDataAction
//        Case "Insert"

//            Response.Write("&nbsp;&nbsp;Unable to insert the record into <b>" & strTableName & "</b>.")
//		Case "Update"
//			Response.Write("&nbsp;&nbsp;Unable to post the updated record to <b>" & strTableName & "</b>.")
//		Case "Delete"
//			Response.Write("&nbsp;&nbsp;Unable to delete the record from <b>" & strTableName & "</b>.")
//	End Select

//    Response.Write "			</font>"
//	Response.Write "			</td>"
//	Response.Write "		</tr>"
//	Response.Write "	</table>"
//	Response.Write "	<table WIDTH=""100%"" CELLSPACING=""1"" CELLPADDING=""2"" BORDER=""0"">"
//	Response.Write "		<tr>"
//	Response.Write "			<td VALIGN=""top"" ALIGN=""Left"" BGCOLOR=""Silver""><font SIZE=""-1""><b>&nbsp;&nbsp;Item</b></font></td>"
//	Response.Write "			<td WIDTH=""100%"" ALIGN=""Left"" BGCOLOR=""Silver""><font SIZE=""-1""><b>Description</b></font></td>"
//	Response.Write "		</tr>"
//	Response.Write "		<tr>"
//	Response.Write "			<td VALIGN=""top""><font SIZE=""-1""><b>&nbsp;&nbsp;Source:</b></font></td>"
//	Response.Write "			<td BGCOLOR=""White""><font SIZE=""-1"">" & ErrSource & "</td>"
//	Response.Write "		</tr>"
//	Response.Write "		<tr>"
//	Response.Write "			<td VALIGN=""top"" NOWRAP><font SIZE=""-1""><b>&nbsp;&nbsp;Error Number:</b></font></td>"
//	Response.Write "			<td BGCOLOR=""White""><font SIZE=""-1"">" & ErrNumber & "</font></td>"
//	Response.Write "		</tr>"
//	Response.Write "		<tr>"
//	Response.Write "			<td VALIGN=""top"" NOWRAP><font SIZE=""-1""><b>&nbsp;&nbsp;SQL Statement:</b></font></td>"
//	Response.Write "			<td BGCOLOR=""White""><font SIZE=""-1"">" & SQLsource & "</font></td>"
//	Response.Write "		</tr>"
//	Response.Write "		<tr>"
//	Response.Write "			<td VALIGN=""top""><font SIZE=""-1""><b>&nbsp;&nbsp;Description:</b></font></td>"
//	Response.Write "			<td BGCOLOR=""White""><font SIZE=""-1"">" & Server.HTMLEncode(ErrDescription & strErrorAdditionalInfo) & "</font></td>"
//	Response.Write "		</tr>"
//	Response.Write "		<tr>"
//	Response.Write "			<td COLSPAN=""2""><hr></td>"
//	Response.Write "		</tr>"
//	Response.Write "		<tr>"
//	Response.Write "			<td COLSPAN=""2"" align=""center"">"
//	Response.Write "				<FORM ACTION=""" & strFormName & """ METHOD=""POST"">"
//	Response.Write "					<input TYPE=""Hidden"" NAME=""FormMode"" VALUE=""Edit"">"
//	Response.Write "					<input TYPE=""SUBMIT"" VALUE=""Form View"">"
//	Response.Write "				</form>"
//	Response.Write "			</td>"
//	Response.Write "		</tr>"
//	Response.Write "		<tr>"
//	Response.Write "			<td colspan=2>"
//	Response.Write "			<font SIZE=""-1"">"
//	Response.Write "				To return to the form view with the previously entered "
//	Response.Write "				information intact, use your browsers &quot;back&quot; button"
//	Response.Write "			</font>"
//	Response.Write "			</td>"
//	Response.Write "		</tr>"
//	Response.Write "		<tr>"
//	Response.Write "			<td colspan=2 align=""center"">"
//	Response.Write "				<a href=""" & strFooterURL & """><img src=""" & strHomeGIF & """ border=0 " & strFooterGIFdim & " alt=""" & strFooterTitle & """><br>"
//	Response.Write "					<font size=1><b>" & strFooterTitle & "</b></font></a>"
//	Response.Write "			</td>"
//	Response.Write "		</tr>"
//	Response.Write "	</table>"
//	Response.Write "</td></tr></table>"
//	Response.Write "</body>"
//	Response.Write "</html>"

//End Sub

////-------------------------------------------------------------------------------
//// Purpose:  Handles the display of a field from a recordset depending
////			on its data type, attributes, and the current mode.
//// Assumes: 	That the recordset containing the field is open
//// Inputs:   strFieldName 	- the name of the field in the recordset
////			avarLookup		- array of lookup values
////-------------------------------------------------------------------------------


//Function ShowListField(strFieldName, avarLookup, blnPassword)

//    Dim intRow

//    Dim strPartial

//    Dim strBool

//    Dim nPos

//    strFieldValue = ""
//	nPos=Instr(strFieldName,".")


//    Do While nPos > 0 
//		strFieldName= Mid(strFieldName, nPos+1)

//        nPos=Instr(strFieldName,".")

//    Loop
//    If Not IsNull(avarLookup) Then

//        intIDcolumn = 0

//        If UBound(avarLookup, 1) > 0 Then
//            intValueColumn = 1

//        Else
//            intValueColumn = 0

//        End If


//        Response.Write "<TD BGCOLOR=White NOWRAP><FONT SIZE=-1>" 
//		For intRow = 0 to UBound(avarLookup, 2)

//            If ConvertNull(avarLookup(intIDcolumn, intRow)) = ConvertNull(Session(strDFName & "_Recordset")(strFieldName)) Then
//                Response.Write Server.HTMLEncode(ConvertNull(avarLookup(intValueColumn, intRow)))
//				Exit For

//            End If

//        Next
//        Response.Write "</FONT></TD>"
//		Exit Function

//    End If

//    nType = Session(strDFName & "_Recordset")(strFieldName).Type


//    Select Case nType
//        Case adBoolean, adUnsignedTinyInt               //Boolean

//            strBool = ""

//            If Session(strDFName & "_Recordset")(strFieldName) <> 0 Then
//                strBool = "True"

//            Else
//                strBool = "False"

//            End If

//            Response.Write "<TD BGCOLOR=White ><FONT SIZE=-1>" & strBool & "</FONT></TD>"
			
//		Case adBinary, adVarBinary, adLongVarBinary		//Binary

//            Response.Write "<TD BGCOLOR=White ><FONT SIZE=-1>[Binary]</FONT></TD>"
			
//		Case adCurrency									//Currency

//            If ConvertNull(strFieldValue) = "" Then
//                Response.Write "<TD BGCOLOR=White ><FONT SIZE=-1>&nbsp;</FONT></TD>"
//			Else
//                Response.Write "<TD BGCOLOR=White ><FONT SIZE=-1>" & FormatCurrency(Session(strDFName & "_Recordset")(strFieldName)) & "</FONT></TD>"
//			End If


//        Case adLongVarChar, adLongVarWChar				//Memo

//            Response.Write "<TD BGCOLOR=White NOWRAP><FONT SIZE=-1>"
//			strPartial = Left(Session(strDFName & "_Recordset")(strFieldName), 50)			
//			If ConvertNull(strPartial) = "" Then
//                Response.Write "&nbsp;"
//			Else
//                Response.Write HTMLEncode(strPartial)
//            End If
//            If Session(strDFName & "_Recordset")(strFieldName).ActualSize > 50 Then Response.Write "..."
//			Response.Write "</FONT></TD>"


//        Case Else

//            Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1>"

//            If ConvertNull(Session(strDFName & "_Recordset")(strFieldName)) = "" Then
//                Response.Write "&nbsp;"
//			Else
//				// Check for special field types

//                Select Case UCase(Left(Session(strDFName & "_Recordset")(strFieldName).Name, 4))
//					Case "URL_"
//						Response.Write "<A HREF=" & QuotedString(Session(strDFName & "_Recordset")(strFieldName)) & ">"
//						Response.Write Server.HTMLEncode(ConvertNull(Session(strDFName & "_Recordset")(strFieldName)))
//						Response.Write "</A>"
//					Case Else

//                        If IsURL(Session(strDFName & "_Recordset")(strFieldName)) Then
//                            Response.Write "<A HREF=" & QuotedString(Session(strDFName & "_Recordset")(strFieldName)) & ">"
//							Response.Write Server.HTMLEncode(ConvertNull(Session(strDFName & "_Recordset")(strFieldName)))
//							Response.Write "</A>"
//						Else
//                            If blnPassword Then

//                                Response.Write "********"
//							Else
//                                Response.Write Server.HTMLEncode(ConvertNull(Session(strDFName & "_Recordset")(strFieldName)))
//							End If

//                        End If

//                End Select

//            End If

//            Response.Write "</FONT></TD>"
//	End Select
//End Function

//        //-------------------------------------------------------------------------------
//        // Purpose:  Handles the display of a field from a recordset depending
//        //			on its data type, attributes, and the current mode.
//        // Assumes: 	That the recordset containing the field is open
//        //			That strFormMode is initialized
//        // Inputs:   strFieldName 	- the name of the field in the recordset
//        //			strLabel		- the label to display
//        //			blnIdentity		- identity field flag
//        //			avarLookup		- array of lookup values
//        //-------------------------------------------------------------------------------


//Sub ShowFormField(strFieldName, strLabel, blnIdentity, avarLookup, blnPassword, blnProtect)

//    Dim blnFieldRequired

//    Dim intMaxSize

//    Dim intInputSize

//    Dim intIDcolumn

//    Dim intValueColumn

//    Dim strOption1State

//    Dim strOption2State

//    Dim strFieldValue

//    Dim nPos

//    Dim intMaxTextDisplay


//    intMaxTextDisplay = Session("MaxTextDisplay")

//	if fDebugMode Then Response.Write "DEBUG: Inside ShowFormField(""" & strFieldname & """)...<br>" & CHR(13)

//    strFieldValue = ""
//	nPos = Instr(strFieldName,".")

//    Do While nPos > 0 
//		strFieldName= Mid(strFieldName, nPos+1)

//        nPos=Instr(strFieldName,".")

//    Loop 

//	// If not in Edit form mode then set value to empty so doesn't display

//    strFieldValue = ""
//	If strFormMode = "Edit" Then strFieldValue = RTrim(Session(strDFName & "_Recordset")(strFieldName))

//            // See if the field is required by checking the attributes 

//    blnFieldRequired = False
//    If(Session(strDFName & "_Recordset")(strFieldName).Attributes And adFldIsNullable) = 0 Then
//       blnFieldRequired = True

//    End If

//    nType = Session(strDFName & "_Recordset")(strFieldName).Type
	
//	// Set values for the MaxLength and Size attributes	
//	intMaxSize = dfMaxSize
//    intInputSize = Session(strDFName & "_Recordset")(strFieldName).DefinedSize + 2

//    If strFormMode<> "Filter" Then intMaxSize = intInputSize - 2
	
//	// Write the field label and start the value cell

//    Response.Write "	<TR VALIGN=TOP>" & CHR(13)

//    Response.Write "		<TD HEIGHT=25 ALIGN=Left NOWRAP><FONT SIZE=-1><B>&nbsp;&nbsp;" & strLabel & "</B></FONT></TD>"	 & CHR(13)

//    Response.Write "		<TD WIDTH=100% ><FONT SIZE=-1>"
	
//	// If the field is not updatable, then handle it like an Identity column and exit
//	If(blnProtect and IsNull(avarLookup)) or Not CanUpdateField(strFieldName) Then
//		if fDebugMode Then Response.Write "DEBUG:	Handling field like an Identity...<br>" & CHR(13)

//		// Special handling if Binary
//		Select Case nType
//            Case adBinary, adVarBinary, adLongVarBinary		//Binary
//				Response.Write "[Binary]"
//			Case Else

//                Select Case strFormMode
//                    Case "Edit"

//                        Response.Write "" & ConvertNull(strFieldValue)

//                        Response.Write "<INPUT TYPE=Hidden NAME=" & QuotedString(strFieldName)

//                        Response.Write " VALUE=" & QuotedString(strFieldValue) & " >"
//					Case "New"
//						Response.Write "[AutoNumber]"
//						Response.Write "<INPUT TYPE=Hidden NAME=" & QuotedString(strFieldName)

//                        Response.Write " VALUE=" & QuotedString(strFieldValue) & " >"
//					Case "Filter" 
//						Response.Write "<INPUT TYPE=Text NAME=" & QuotedString(strFieldName)

//                        If intInputSize<intMaxTextDisplay Then
//                            Response.Write " SIZE=" & intInputSize
//                        Else

//                            Response.Write " SIZE=" & intMaxTextDisplay
//                        End If
//                        Response.Write " MAXLENGTH=" & intMaxSize
//                        Response.Write " VALUE=" & QuotedString(strFieldValue) & " >"

//                End Select

//        End Select

//        Response.Write "</FONT></TD></TR>" & CHR(13)
//		if fDebugMode Then Response.Write "DEBUG:	Exiting ShowFormField()...<br>" & CHR(13)

//        Exit Sub

//    End If
	
//	// Handle lookups using a select and options

//    If Not IsNull(avarLookup) Then
//		if fDebugMode Then Response.Write "DEBUG: Inside ShowFormField() and avarLookup is Not Null...<br>" & CHR(13)

//        If Not blnProtect Then

//            Response.Write "			<SELECT NAME=" & QuotedString(strFieldName) & ">" & CHR(13)
//			// Add blank entry if not required or in filter mode
//			If Not blnFieldRequired Or strFormMode = "Filter" Then
//                If(strFormMode = "Filter" Or strFormMode = "New") Then
//                   Response.Write "				<OPTION SELECTED>"
//				Else
//                   Response.Write "				<OPTION>"

//               End If

//           End If

//       End If
		
//		//Response.Write CHR(13) & "<" & "!-- " & CHR(13)
//		//Response.Write "UBound(avarLookup, 1) is " & UBound(avarLookup, 1) & CHR(13)
//		//Response.Write "UBound(avarLookup, 2) is " & UBound(avarLookup, 2) & CHR(13)
//		//Response.Write "avarLookup(0, 1) is " & avarLookup(0, 1) & CHR(13)
//		//Response.Write "avarLookup(1, 1) is " & avarLookup(1, 1) & CHR(13)
//		//Response.Write " -->" & CHR(13)


//       intIDcolumn = 0

//       If UBound(avarLookup, 1) > 0 Then
//           intValueColumn = 1

//        Else
//            intValueColumn = 0

//        End If

//		// Loop thru the rows in the array

//        For intRow = 0 to UBound(avarLookup, 2)

//            If blnProtect Then
//                If ConvertNull(avarLookup(intIDcolumn, intRow)) = ConvertNull(strFieldValue) Then
//                    Response.Write ConvertNull(avarLookup(intValueColumn, intRow)) & CHR(13)

//                    Response.Write "</FONT></TD>" & CHR(13)

//                    Response.Write "	</TR>" & CHR(13)

//                    Exit Sub

//                End If

//            Else
//				if fDebugMode Then Response.Write "DEBUG: Inside avarLookup code in ShowFormField()...<br>" & CHR(13)

//                Response.Write "				<OPTION VALUE=" & QuotedString(avarLookup(intIDcolumn, intRow))

//                If strFormMode = "Edit" Then
//                    If ConvertNull(avarLookup(intIDColumn, intRow)) = ConvertNull(strFieldValue) Then
//                           Response.Write " SELECTED"
//					End If

//                End If

//                   Response.Write ">"

//                Response.Write ConvertNull(avarLookup(intValueColumn, intRow)) & CHR(13)

//            End If

//        Next
//        If Not blnProtect Then
//            Response.Write "			</SELECT>"
//			If blnFieldRequired And strFormMode = "New" Then
//                Response.Write "  Required"

//            End If

//        End If

//        Response.Write "</FONT></TD>" & CHR(13)

//        Response.Write "	</TR>" & CHR(13)

//        Exit Sub

//    End If	
	
//	// Evaluate data type and handle appropriately

//    Select Case nType
//        Case adBoolean, adUnsignedTinyInt				//Boolean
//			If strFormMode = "Filter" Then
//                strOption1State = " >True"

//                strOption2State = " >False"
//			Else
//                Select Case strFieldValue

//                    Case "True", "1", "-1"
//						strOption1State = " CHECKED>True"
//						strOption2State = " >False"
//					Case "False", "0"
//						strOption1State = " >True"
//						strOption2State = " CHECKED>False"
//					Case Else

//                        strOption1State = " >True"
//						strOption2State = " >False"
//				End Select

//            End If

//            Response.Write "<INPUT TYPE=Radio VALUE=1 NAME=" & QuotedString(strFieldName) & strOption1State
//            Response.Write "<INPUT TYPE=Radio VALUE=0 NAME=" & QuotedString(strFieldName) & strOption2State
//            If strFormMode = "Filter" Then
//                Response.Write "<INPUT TYPE=Radio NAME=" & QuotedString(strFieldName) & " CHECKED>Neither"

//            End If


//        Case adBinary, adVarBinary, adLongVarBinary     //Binary

//            Response.Write "[Binary]"


//        Case adLongVarChar, adLongVarWChar              //Memo

//            Response.Write "<TEXTAREA NAME=" & QuotedString(strFieldName) & " ROWS=6 COLS=" & intMaxTextDisplay & ">"

//            Response.Write Server.HTMLEncode(ConvertNull(strFieldValue))

//            Response.Write "</TEXTAREA>"
			
//		Case Else

//            If(nType<> adVarChar) and(nType<> adVarWChar) and(nType<> adBSTR) and(nType<> adChar) and(nType<> adWChar)  Then
//      intInputSize = (intInputSize - 2) * 3 + 2

//                If strFormMode<> "Filter" Then intMaxSize = intInputSize - 2

//            End If

//            If blnIdentity Then
//                Select Case strFormMode

//                    Case "Edit"

//                        Response.Write ConvertNull(strFieldValue)
//                        Response.Write "<INPUT TYPE=Hidden NAME=" & QuotedString(strFieldName)
//                        Response.Write " VALUE="

//                        If nType = adCurrency Then
//                            If ConvertNull(strFieldValue) = "" Then
//                                Response.Write ConvertNull(strFieldValue)
//                            Else

//                                Response.Write QuotedString(FormatCurrency(strFieldValue))

//                            End If

//                        Else
//                            Response.Write QuotedString(strFieldValue)
//                        End If
//                        Response.Write " >"

//                    Case "New"

//                        Response.Write "[AutoNumber]"

//                        Response.Write "<INPUT TYPE=Hidden NAME=" & QuotedString(strFieldName)
//                        Response.Write " VALUE="

//                        If nType = adCurrency Then
//                            If ConvertNull(strFieldValue) = "" Then
//                                Response.Write ConvertNull(strFieldValue)
//                            Else

//                                Response.Write QuotedString(FormatCurrency(strFieldValue))

//                            End If

//                        Else
//                            Response.Write QuotedString(strFieldValue)
//                        End If
//                        Response.Write " >"

//                    Case "Filter" 

//                        Response.Write "<INPUT TYPE=Text NAME=" & QuotedString(strFieldName) & " SIZE=" & tInputSize
//                        Response.Write " MAXLENGTH=" & tMaxSize
//                        Response.Write " VALUE="

//                        If nType = adCurrency Then
//                            If ConvertNull(strFieldValue) = "" Then
//                                Response.Write ConvertNull(strFieldValue)
//                            Else

//                                Response.Write QuotedString(FormatCurrency(strFieldValue))

//                            End If

//                        Else
//                            Response.Write QuotedString(strFieldValue)
//                        End If
//                        Response.Write " >"

//                End Select

//            Else
//				// Check for special URL field types
//// Commented-out since the text box should now fit on a page...
////				Select Case UCase(Left(Session(strDFName & "_Recordset")(strFieldName).Name, 4))
////					Case "URL_"
////						If strFieldValue <> "" Then
////							Response.Write "<A HREF=" & QuotedString(strFieldValue) & ">"
////							Response.Write "<IMG SRC=""/Images/Buttons/Go.gif"" width=26 height=26 border=0>"
////							Response.Write "</A>&nbsp;&nbsp;"
////						End If
////					Case Else
////						If IsURL(strFieldValue) Then
////							Response.Write "<A HREF=" & QuotedString(strFieldValue) & ">"
////							Response.Write "<IMG SRC=""/Images/Buttons/Go.gif"" width=26 height=26 border=0>"
////							Response.Write "</A>&nbsp;&nbsp;"
////						End If					
////				End Select				

//                If intInputSize > 132 and Not IsURL(strFieldValue) Then

//                    Response.Write "<TEXTAREA NAME=" & QuotedString(strFieldName) & " ROWS=2 COLS=" & intMaxTextDisplay & ">"

//                    Response.Write Server.HTMLEncode(ConvertNull(strFieldValue))

//                    Response.Write "</TEXTAREA>"
//				Else
//                    If blnPassword Then

//                        Response.Write "<INPUT TYPE=Password NAME=" & QuotedString(strFieldName)

//                    Else
//                        Response.Write "<INPUT TYPE=Text NAME=" & QuotedString(strFieldName)
//                    End If
//                    If intInputSize<intMaxTextDisplay Then

//                        Response.Write " SIZE=" & intInputSize

//                    Else

//                        Response.Write " SIZE=""" & intMaxTextDisplay & """"

//                    End If

//                    Response.Write " MAXLENGTH=" & intMaxSize

//                    Response.Write " VALUE="

//                    If nType = adCurrency Then

//                        If ConvertNull(strFieldValue) = "" Then
//                            Response.Write ConvertNull(strFieldValue)
//                        Else

//                            Response.Write QuotedString(FormatCurrency(strFieldValue))

//                        End If

//                    Else
//                        Response.Write QuotedString(strFieldValue)
//                    End If
//                    Response.Write " >"

//                End If

//				// Check for special field types

//                Select Case UCase(Left(Session(strDFName & "_Recordset")(strFieldName).Name, 4))
//					Case "IMG_"
//						If strFieldValue<> "" Then
//                            Response.Write "<BR><BR><IMG SRC=" & QuotedString(strFieldValue) & "><BR>&nbsp;<BR>"

//                        End If

//                    Case "URL_"

//                        If strFieldValue <> "" Then
//                            Response.Write "&nbsp;&nbsp;<A HREF=" & QuotedString(strFieldValue) & ">"

//                            Response.Write "<IMG SRC=""/Images/Buttons/Go.gif"" width=26 height=26 border=0>"

//                            Response.Write "</A>"

//                        End If

//                    Case Else

//                        If IsURL(strFieldValue) Then

//                            Response.Write "&nbsp;&nbsp;<A HREF=" & QuotedString(strFieldValue) & ">"

//                            Response.Write "<IMG SRC=""/Images/Buttons/Go.gif"" width=26 height=26 border=0>"

//                            Response.Write "</A>"

//                        End If

//                End Select

//            End If

//    End Select

//       If blnFieldRequired And strFormMode = "New" Then
//        Response.Write "  Required"

//    End If

//    Response.Write "</FONT></TD>" & CHR(13)

//    Response.Write "	</TR>" & CHR(13)
//End Sub	

////-------------------------------------------------------------------------------
//// Purpose:  Return Expanded Lookup field Value
//// Inputs:   LookupIndex 	- the index of the entry in the avarLookup list
////			avarLookup		- array of lookup values
////-------------------------------------------------------------------------------


//Function GetLookupValue(LookupIndex, avarLookup)

//    Dim intRow

//    Dim intIDcolumn

//    Dim intValueColumn


//    GetLookupValue = ""
//	If IsNull(avarLookup) Then Exit Function

//    intIDcolumn = 0

//    If UBound(avarLookup, 1) > 0 Then
//        intValueColumn = 1

//    Else
//        intValueColumn = 0

//    End If


//    For intRow = 0 to intUBound

//        If ConvertNull(avarLookup(intIDcolumn, intRow)) = ConvertNull(LookupIndex) Then
//            GetLookupValue = Server.HTMLEncode(ConvertNull(avarLookup(intValueColumn, intRow)))

//            Exit For

//        End If

//    Next
//End Function

////-------------------------------------------------------------------------------
//// Purpose:  Return Text Field with HTML tags
//// Inputs:   strText 	- the value to encode
////-------------------------------------------------------------------------------
 
//Function HTMLEncode(strText)

//    Dim intChar

//    Dim c


//    HTMLEncode = ""
//	If ConvertNull(strText) = "" Then Exit Function

//    For intChar = 1 to Len(strText)

//        c = Mid(strText, intChar, 1)

//        Select Case c
//            Case CHR(13)

//                HTMLEncode = HTMLEncode & "<br>"
//			Case Else

//                HTMLEncode = HTMLEncode & c
//        End Select
//    Next
//End Function

////-------------------------------------------------------------------------------
//// Purpose:  Insert operation - updates a recordset field with a new value 
////			during an insert operation.
//// Assumes: 	That the recordset containing the field is open
//// Effects:	Sets Err object if field is not set but is required
//// Inputs:   strFieldName	- the name of the field in the recordset
//// Returns:	True if successful, False if not
////-------------------------------------------------------------------------------

//Function InsertField(strFieldName)

//    InsertField = True
//    If IsEmpty(Request(strFieldName)) Then Exit Function
//    Select Case Session(strDFName & "_Recordset")(strFieldName).Type
//         Case adBinary, adVarBinary, adLongVarBinary		//Binary
//		Case Else

//            If CanUpdateField(strFieldName) Then
//                If IsRequiredField(strFieldName) And IsNull(RestoreNull(Request(strFieldName))) Then
//                    RaiseError errValueRequired, strFieldName
//                    InsertField = False

//                    Exit Function

//                End If

//                Session(strDFName & "_Recordset")(strFieldName) = RestoreNull(Request(strFieldName))

//            End If

//    End Select
//End Function

//        //-------------------------------------------------------------------------------
//        // Purpose:  Update operation - updates a recordset field with a new value 
//        // Assumes: 	That the recordset containing the field is open
//        // Effects:	Sets Err object if field is not set but is required
//        // Inputs:   strFieldName	- the name of the field in the recordset
//        // Returns:	True if successful, False if not
//        //-------------------------------------------------------------------------------

//Function UpdateField(strFieldName)

//    UpdateField = True

//    If IsEmpty(Request(strFieldName)) Then Exit Function
//    Select Case Session(strDFName & "_Recordset")(strFieldName).Type
//         Case adBinary, adVarBinary, adLongVarBinary		//Binary
//		Case Else
//			// Only update if the value has changed

//            If Not IsEqual(ConvertToString(Session(strDFName & "_Recordset")(strFieldName)), RestoreNull(Request(strFieldName))) Then
//                If CanUpdateField(strFieldName) Then
//                    If IsRequiredField(strFieldName) And IsNull(RestoreNull(Request(strFieldName))) Then
//                        RaiseError errValueRequired, strFieldName
//                        UpdateField = False

//                        Exit Function

//                    End If

//                    Session(strDFName & "_Recordset")(strFieldName) = RestoreNull(Request(strFieldName))

//                Else
//                    RaiseError errNotEditable, strFieldName
//                    UpdateField = False

//                End If

//            End If

//    End Select
//End Function

//        //-------------------------------------------------------------------------------
//        // Purpose:  Criteria handler for a field in the recordset. Determines
//        //			correct delimiter based on data type
//        // Effects:	Appends to strWhere and strWhereDisplay variables
//        // Inputs:   strFieldName	- the name of the field in the recordset
//        //			avarLookup		- lookup array - null if none
//        //-------------------------------------------------------------------------------

//Sub FilterField(ByVal strFieldName, avarLookup)

//    Dim strFieldDelimiter

//    Dim strDisplayValue

//    Dim strValue

//    Dim intRow

//    Dim intIDcolumn

//    Dim intValueColumn


//    strValue = Request(strFieldName)

//    strDisplayValue = Request(strFieldName)
	
//	// If empty then exit right away
//	If Request(strFieldName) = "" Then Exit Sub
//    nType = Session(strDFName & "_Recordset")(strFieldName).Type

//	// Handle "Neither" radio buttons...

//    Select Case nType
//        Case adBoolean, adUnsignedTinyInt	//Boolean
//			If strValue = "on" Then Exit Sub	//Ignore from appending to Where Clause...
//	End Select

//    If fDebugMode Then WriteTraceLog(now & ": DEBUG: FilterField: strFieldName: """ & strFieldName & """; strValue: """ & strValue & """")

//	// Concatenate the And boolean operator
//	If strWhere<> "" Then strWhere = strWhere & " And"

//    If strWhereDisplay <> "" Then strWhereDisplay = strWhereDisplay & " And"
	
//	// If lookup field, then use lookup value for display

//    If Not IsNull(avarLookup) Then

//        intIDcolumn = 0

//        If UBound(avarLookup, 1) > 0 Then
//            intValueColumn = 1

//        Else
//            intValueColumn = 0

//        End If

//        If fDebugMode Then WriteTraceLog(now & ": DEBUG: FilterField: UBound(avarLookup, 2): " & UBound(avarLookup, 2))
//		For intRow = 0 to UBound(avarLookup, 2)

//            If Not IsNull(avarLookup(intIDcolumn, intRow)) Then
//                If fDebugMode Then WriteTraceLog(now & ": DEBUG: FilterField: avarLookup(" & intRow & "): """ & CStr(avarLookup(intIDcolumn, intRow)) & """")
//			    If CStr(avarLookup(intIDcolumn, intRow)) = Request(strFieldName) Then
//                    strDisplayValue = avarLookup(intValueColumn, intRow)

//                    Exit For

//                End If

//            End If

//        Next
//    End If
	
//	// Set delimiter based on data type
//	Select Case nType
//        Case adBSTR, adChar, adWChar, adVarChar, adVarWChar	//string types
//			strFieldDelimiter = "'"
//		Case adLongVarChar, adLongVarWChar					//long string types

//            strFieldDelimiter = "'"				
//		Case adDate, adDBDate, adDBTimeStamp				//date types

//            strFieldDelimiter = "#"
//		Case Else

//            strFieldDelimiter = ""
//	End Select


//    If fDebugMode Then WriteTraceLog(now & ": DEBUG: FilterField: strFieldName: """ & strFieldName & """; strValue: """ & strValue & """")
	
//	' Modifies script level variables
//	strWhere = strWhere & " " & PrepFilterItem(strFieldName, strValue, strFieldDelimiter)

//    strWhereDisplay = strWhereDisplay & " " & PrepFilterItem(strFieldName, strDisplayValue, strFieldDelimiter)
//End Sub

//        //-------------------------------------------------------------------------------
//        // Purpose:  Display field involved in a database operation for feedback.
//        // Assumes: 	That the recordset containing the field is open
//        // Inputs:   strFieldLabel	- the label to be used for the field
//        //			strFieldName	- the name of the field in the recordset
//        //-------------------------------------------------------------------------------
//Sub FeedbackField(strFieldLabel, strFieldName, avarLookup)

//    Dim strBool

//    Dim intRow

//    Dim intIDcolumn

//    Dim intValueColumn

//    Dim fDebugMode


//    fDebugMode = False

//    If fDebugMode Then Response.Write "<" & "!-- DEBUG: strFieldLabel: """ & strFieldLabel & """; strFieldName: """ & strFieldName & """; -->" & chr(13)


//    Response.Write "<TR VALIGN=TOP>"
//   Response.Write "<TD ALIGN=Left><FONT SIZE=-1><B>&nbsp;&nbsp;" & strFieldLabel & "</B></FONT></TD>"
//	Response.Write "<TD BGCOLOR=White WIDTH=100% ALIGN=Left><FONT SIZE=-1>"
	
//	// Test for lookup
//	If Not IsNull(avarLookup) Then
//        intIDcolumn = 0

//        If UBound(avarLookup, 1) > 0 Then
//            intValueColumn = 1

//        Else
//            intValueColumn = 0

//        End If


//        For intRow = 0 to UBound(avarLookup, 2)

//            If CStr(avarLookup(intIDcolumn, intRow)) = Request(strFieldName) Then
//                Response.Write Server.HTMLEncode(avarLookup(intValueColumn, intRow))

//                Exit For

//            End If

//        Next
//        Response.Write "</FONT></TD></TR>" & CHR(13)

//        Exit Sub

//    End If


//    If fDebugMode Then Response.Write "<" & "!-- DEBUG: " & strFieldName & " is not a lookup field... -->" & chr(13)

//	// Test for empty
//	If Request(strFieldName) = "" Then
//        Response.Write "&nbsp;"
//		Response.Write "</FONT></TD></TR>" & CHR(13)

//        Exit Sub

//    End If


//    If fDebugMode Then Response.Write "<" & "!-- DEBUG: " & strFieldName & " is not empty... -->" & chr(13)

//	// Test the data types and display appropriately	
//	Select Case Session(strDFName & "_Recordset")(strFieldName).Type
//        Case adBoolean, adUnsignedTinyInt				//Boolean
//			strBool = ""
//			If Request(strFieldName) <> 0 Then
//                strBool = "True"

//            Else
//                strBool = "False"

//            End If

//            Response.Write strBool

//        Case adBinary, adVarBinary, adLongVarBinary		//Binary

//            Response.Write "[Binary]"
//		Case adLongVarChar, adLongVarWChar				//Memo

//            Response.Write HTMLEncode(Request(strFieldName))

//        Case adCurrency									//Currency

//            If ConvertNull(Request(strFieldName)) = "" Then
//                Response.Write "&nbsp;"
//			Else
//                Response.Write FormatCurrency(Request(strFieldName))

//            End If

//        Case Else

//            If Not CanUpdateField(strFieldName) Then
//                Response.Write "[AutoNumber]"
//			Else
//                Response.Write Server.HTMLEncode(Request(strFieldName))

//            End If

//    End Select

//    Response.Write "</FONT></TD></TR>" & CHR(13)
//End Sub
////-------------------------------------------------------------------------------
        #endregion
    }
}