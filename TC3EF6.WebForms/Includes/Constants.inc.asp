<script RUNAT="Server" LANGUAGE="VBScript">

'---- Text Stream Object Enum Values ----
Const ForReading = 1 'Open a file for reading only. No writing to this file can take place.
Const ForWriting = 2 'Open a file for writing. If a file with the same name exists, its previous contents are overwritten.
Const ForAppending = 8

'---- Cmd Object Enum Values ----
Const adCmdText = 1
Const adCmdTable = 2
Const adCmdStoredProc = 4
Const adCmdUnknown = 8

'---- FieldAttributeEnum Values ----
Const adFldUpdatable = &H00000004
Const adFldUnknownUpdatable = &H00000008
Const adFldIsNullable = &H00000020

'---- CursorTypeEnum Values ----
Const adOpenForwardOnly = 0
Const adOpenKeyset = 1
Const adOpenDynamic = 2
Const adOpenStatic = 3

'---- LockTypeEnum Values ----
Const adLockReadOnly = 1		' Read-only you cannot alter the data.
Const adLockPessimistic = 2		' Pessimistic locking, record by record the provider does what is necessary to ensure successful editing of the records, usually by locking records at the data source immediately upon editing.
Const adLockOptimistic = 3		' Optimistic locking, record by record the provider uses optimistic locking, locking records only when you call the Update method.
Const adLockBatchOptimistic = 4	' Optimistic batch updates required for batch update mode as opposed to immediate update mode.
 

'---- DataTypeEnum Values ----
Const adBigInt = 20				' An 8-byte signed integer
Const adBinary = 128			' A binary value
Const adBoolean = 11			' A Boolean value
Const adBSTR = 8				' A null-terminated character string (Unicode)
Const adChar = 129				' A String value
Const adCurrency = 6			' A currency value (8-byte signed integer scaled by 10,000)
Const adDate = 7				' A Date value
Const adDBDate = 133			' A date value (yyyymmdd)
Const adDBTime = 134			' A time value (hhmmss)
Const adDBTimeStamp = 135		' A date-time stamp (yyyymmddhhmmss plus a fraction in billionths)
Const adDecimal = 14			' An exact numeric value with a fixed precision and scale
Const adDouble = 5				' A double-precision floating point value
Const adEmpty = 0				' No value was specified
Const adError = 10				' A 32-bit error code
Const adGUID = 72				' A globally unique identifier (GUID)
Const adIDispatch = 9			' A pointer to an IDispatch interface on an OLE object
Const adInteger = 3				' A 4-byte signed integer
Const adIUnknown = 13			' A pointer to an IUnknown interface on an OLE object
Const adLongVarBinary = 205		' A long binary value (Parameter object only)
Const adLongVarChar = 201		' A long String value (Parameter object only)
Const adLongVarWChar = 203		' A long null-terminated string value (Parameter object only)
Const adNumeric = 131			' An exact numeric value with a fixed precision and scale
Const adSingle = 4				' A single-precision floating point value
Const adSmallInt = 2			' A 2-byte signed integer
Const adTinyInt = 16			' A	1-byte signed integer
Const adUnsignedBigInt = 21		' An 8-byte unsigned integer
Const adUnsignedInt = 19		' A 4-byte unsigned integer
Const adUnsignedSmallInt = 18	' A 2-byte unsigned integer
Const adUnsignedTinyInt = 17	' A 1-byte unsigned integer
Const adUserDefined = 132		' A user-defined variable
Const adVarBinary = 204			' A binary value (Parameter object only)
Const adVarChar = 200			' A String value (Parameter object only)
Const adVariant = 12			' An OLE Automation Variant
Const adVarWChar = 202			' A null-terminated Unicode character string (Parameter object only)
Const adWChar = 130				' A null-terminated Unicode character string

'---- Error Values ----
Const errInvalidPrefix = 20001		'Invalid wildcard prefix
Const errInvalidOperator = 20002	'Invalid filtering operator
Const errInvalidOperatorUse = 20003	'Invalid use of LIKE operator
Const errNotEditable = 20011		'Field not editable
Const errValueRequired = 20012		'Value required

'---- Other Values ----
Const dfMaxSize = 100

</Script>