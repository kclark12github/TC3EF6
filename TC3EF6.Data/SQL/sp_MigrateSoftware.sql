--sp_MigrateSoftware.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateSoftware' AND type='P') Drop Procedure sp_MigrateSoftware
Go
Create Procedure sp_MigrateSoftware As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'Software'
		Delete From [dbo].[Software];
		INSERT INTO [dbo].[Software] ([OID],
			[AlphaSort],[Cataloged],[CDkey],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateReleased],[DateVerified],
			[Developer],[ISBN],[MediaFormat],[Notes],[Platform],[Price],[Publisher],[Title],[Type],[Value],[Version],[WishList],[LocationID])
		SELECT [Software].[ID],
			[AlphaSort],[Cataloged],[CDkey],[Software].[DateCreated],[DateInventoried],[Software].[DateModified],[DatePurchased],[DateReleased],[DateVerified],
			[Developer],[ISBN],[Media],[Notes],[Platform],[Price],[Publisher],[Title],[Type],[Value],[Version],[WishList],[Locations].[ID]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Software] [Software]
			LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Software].[Location]=[Locations].[OName]
		ORDER BY [Software].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Software];
		Select @Actual=Count(*) From [dbo].[Software];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='Software';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Software].[ID],[History].[TableName],[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[Software] [Software] On [History].[TableName]='Software' And [Software].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Software' 
		ORDER BY [History].[ID];
		--Now grab any history for deleted records...
		Declare @OID int, @RecordID uniqueidentifier;
		If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
		Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
			[History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
		Into #DeletedHistory 
		From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
		Where [History].[TableName]='Software' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Software] Where [ID]=[History].[RecordID])
		Order By [History].[RecordID];
		Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
		Open h;
		Fetch Next From h Into @OID;
		While @@FETCH_STATUS = 0
		Begin
			Set @RecordID=NEWID();
			Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
			Fetch Next From h Into @OID;
		End
		Close h;
		Deallocate h;
		INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
		Drop Table #DeletedHistory;
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Software';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Software';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='Software';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Software: '+[Software].[Title]),Null,'Software',getdate(),getdate(),Null,Null,[Image],[Software].[Title],Null,
			[newSoftware].[ID],'Software',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Software] [Software]
			INNER JOIN [dbo].[Software] [newSoftware] On [Software].[ID]=[newSoftware].[OID]
		WHERE [Software].[Image] is not Null
		ORDER BY [Software].[ID];
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Software: '+[Software].[Title]),Null,'Software',getdate(),getdate(),Null,Null,[OtherImage],[Software].[Title],Null,
			[newSoftware].[ID],'Software',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Software] [Software]
			INNER JOIN [dbo].[Software] [newSoftware] On [Software].[ID]=[newSoftware].[OID]
		WHERE [Software].[OtherImage] is not Null
		ORDER BY [Software].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Software] Where [Image] is not Null;
		Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Software] Where [OtherImage] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Software';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;
		Select 'Elapsed: '+Convert(nvarchar(24),CURRENT_TIMESTAMP-@stTime,114);
		Commit;
	End Try
	Begin Catch
		Declare @ErrorMessage nvarchar(4000), @ErrorSeverity int, @ErrorState int;
		Select @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		--Use RAISERROR inside the CATCH block to return error information about the original error that caused execution to jump to the CATCH block.
		Rollback;
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	End Catch;
End;
Grant Execute on [dbo].[sp_MigrateSoftware] to [Public];
