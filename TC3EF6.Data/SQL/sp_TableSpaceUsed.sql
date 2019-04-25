IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_TableSpaceUsed' AND type='P') Drop Procedure sp_TableSpaceUsed
Go
Create Procedure sp_TableSpaceUsed @Scale varchar(2) = null As 
Begin
    Set NOCOUNT ON
    If OBJECT_ID('tempdb..#TableList') Is Not Null Drop Table #TableList
    Create Table #TableList
	(ID int IDENTITY,
	[Database] sysname,	
	[Owner] sysname,
	[TableName] sysname,
	[Type] varchar(32),
	[Remarks] varchar(254))
    Insert into #TableList exec sp_tables @table_name='%', @table_owner='dbo', @table_type="'TABLE'"
    Declare dsTableList Cursor Fast_Forward For Select [TableName] From #TableList

    If OBJECT_ID('tempdb..#SpacePerTable') Is Not Null Drop Table #SpacePerTable
    Create Table #SpacePerTable
	(ID int IDENTITY,
	[TableName] sysname,	
	[Rows] sysname,
	[Reserved] sysname,
	[Data] sysname,
	[IndexSize] sysname,
	[Unused]sysname)
    Declare @TableName sysname
    Open dsTableList
    Fetch Next From dsTableList Into @TableName
    While @@FETCH_STATUS=0 Begin
        Insert Into #SpacePerTable exec sp_spaceused @TableName
        Fetch Next From dsTableList Into @TableName
    End
    Close dsTableList
    Deallocate dsTableList

    --Select * From #SpacePerTable Order By CONVERT(decimal(15,0), REPLACE([Reserved],' KB','')) Desc
    If @Scale is null 
	    Select [TableName] As [Table], 
		CONVERT(decimal(15,0), [Rows]) As [Rows], 
		CONVERT(decimal(15,0), REPLACE([Reserved],' KB','')*CONVERT(decimal(15,0),1024.)) As [Reserved Bytes], 
		CONVERT(decimal(15,0), REPLACE([Data],' KB','')*CONVERT(decimal(15,0),1024.)) As [Data Bytes], 
		CONVERT(decimal(15,0), REPLACE([IndexSize],' KB','')*CONVERT(decimal(15,0),1024.)) As [IndexSize Bytes], 
		CONVERT(decimal(15,0), REPLACE([Unused],' KB','')*CONVERT(decimal(15,0),1024.)) As [Unused Bytes]
	    From #SpacePerTable
	    Order By CONVERT(decimal(15,0), REPLACE([Reserved],' KB','')) Desc
    Else If @Scale = 'KB' 
	    Select [TableName] As [Table], 
		CONVERT(decimal(15,0), [Rows]) As [Rows], 
		CONVERT(decimal(15,2), REPLACE([Reserved],' KB','')) As [Reserved KB], 
		CONVERT(decimal(15,2), REPLACE([Data],' KB','')) As [Data KB], 
		CONVERT(decimal(15,2), REPLACE([IndexSize],' KB','')) As [IndexSize KB], 
		CONVERT(decimal(15,2), REPLACE([Unused],' KB','')) As [Unused KB]
	    From #SpacePerTable
	    Order By CONVERT(decimal(15,0), REPLACE([Reserved],' KB','')) Desc
    Else If @Scale = 'MB' 
	    Select [TableName] As [Table], 
		CONVERT(decimal(15,0), [Rows]) As [Rows], 
		CONVERT(decimal(15,2), REPLACE([Reserved],' KB','')/CONVERT(decimal(15,0),1024.)) As [Reserved MB], 
		CONVERT(decimal(15,2), REPLACE([Data],' KB','')/CONVERT(decimal(15,0),1024.)) As [Data MB], 
		CONVERT(decimal(15,2), REPLACE([IndexSize],' KB','')/CONVERT(decimal(15,0),1024.)) As [IndexSize MB], 
		CONVERT(decimal(15,2), REPLACE([Unused],' KB','')/CONVERT(decimal(15,0),1024.)) As [Unused MB]
	    From #SpacePerTable
	    Order By CONVERT(decimal(15,0), REPLACE([Reserved],' KB','')) Desc
    Else If @Scale = 'GB' 
	    Select [TableName] As [Table], 
		CONVERT(decimal(15,0), [Rows]) As [Rows], 
		CONVERT(decimal(15,4), REPLACE([Reserved],' KB','')/CONVERT(decimal(15,0),1048576.)) As [Reserved GB], 
		CONVERT(decimal(15,4), REPLACE([Data],' KB','')/CONVERT(decimal(15,0),1048576.)) As [Data GB], 
		CONVERT(decimal(15,4), REPLACE([IndexSize],' KB','')/CONVERT(decimal(15,0),1048576.)) As [IndexSize GB], 
		CONVERT(decimal(15,4), REPLACE([Unused],' KB','')/CONVERT(decimal(15,0),1048576.)) As [Unused GB]
	    From #SpacePerTable
	    Order By CONVERT(decimal(15,0), REPLACE([Reserved],' KB','')) Desc

    RETURN 1
End
Go
