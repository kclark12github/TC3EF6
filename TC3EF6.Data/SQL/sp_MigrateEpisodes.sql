--sp_MigrateEpisodes.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateEpisodes' AND type='P') Drop Procedure sp_MigrateEpisodes
Go
Create Procedure sp_MigrateEpisodes As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'Episodes';
		Delete From [dbo].[Episodes];
		INSERT INTO [dbo].[Episodes] ([OID],
			[Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateReleased],[DateVerified],
			[Distributor],[MediaFormat],[Notes],[Number],[Price],[Series],[Subject],[Title],[Value],[WishList],[StoreBought],[Taped],[WMV],[LocationID])
		SELECT [Episodes].[ID],
			1,[Episodes].[DateCreated],[DateInventoried],[Episodes].[DateModified],[DatePurchased],[ReleaseDate],[DateVerified],
			[Distributor],[Format],[Notes],[Number],[Price],[Series],[Subject],[Title],[Value],[WishList],[StoreBought],[Taped],[WMV],[Locations].[ID]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Episodes] [Episodes]
			LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Episodes].[Location]=[Locations].[OName]
		ORDER BY [Episodes].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Episodes];
		Select @Actual=Count(*) From [dbo].[Episodes];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='Episodes';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Episodes].[ID],[History].[TableName],[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[Episodes] [Episodes] On [History].[TableName]='Episodes' And [Episodes].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Episodes' 
		ORDER BY [History].[ID];
		--Now grab any history for deleted records...
		Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
		If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
		Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
			[History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
		Into #DeletedHistory 
		From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
		Where [History].[TableName]='Episodes' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Episodes] Where [ID]=[History].[RecordID])
		Order By [History].[RecordID];
		Select @OrphanedHistoryCount=Count(*) From [#DeletedHistory];
		Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
		Open h;
		Fetch Next From h Into @OID;
		While @@FETCH_STATUS = 0
		Begin
			Set @RecordID=NEWID();
			Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
			Fetch Next From h Into @OID;
		End;
		Close h;
		Deallocate h;
		INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
		Drop Table #DeletedHistory;
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Episodes';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Episodes';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='Episodes';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Episodes: '+[Episodes].[Title]),[Episodes].[Title],'Episodes',getdate(),getdate(),Null,Null,[Image],[Episodes].[Title],Null,
			[newEpisodes].[ID],'Episodes',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Episodes] [Episodes]
			INNER JOIN [dbo].[Episodes] [newEpisodes] On [Episodes].[ID]=[newEpisodes].[OID]
		WHERE [Episodes].[Image] is not Null
		ORDER BY [Episodes].[ID];
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Episodes: '+[Episodes].[Title]),[Episodes].[Title],'Episodes',getdate(),getdate(),Null,Null,[OtherImage],[Episodes].[Title],Null,
			[newEpisodes].[ID],'Episodes',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Episodes] [Episodes]
			INNER JOIN [dbo].[Episodes] [newEpisodes] On [Episodes].[ID]=[newEpisodes].[OID]
		WHERE [Episodes].[OtherImage] is not Null
		ORDER BY [Episodes].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Episodes] Where [Image] is not Null;
		Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Episodes] Where [OtherImage] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Episodes';
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
Grant Execute on [dbo].[sp_MigrateEpisodes] to [Public];
