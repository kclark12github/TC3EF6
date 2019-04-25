--sp_MigrateMovies.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateMovies' AND type='P') Drop Procedure sp_MigrateMovies
Go
Create Procedure sp_MigrateMovies As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'Videos/Movies'
		Delete From [dbo].[Images] Where [TableName]='Videos' And [Images].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Movies');
		Delete From [dbo].[History] Where [TableName]='Videos' And [History].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Movies');
		Delete From [dbo].[Videos] Where [SourceTable]='Movies';
		INSERT INTO [dbo].[Videos] ([OID],
			[AlphaSort],[Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateReleased],[DateVerified],
			[Distributor],[MediaFormat],[Notes],[Price],[Subject],[Title],[Value],[WishList],[StoreBought],[WMV],[LocationID],[SourceTable])
		SELECT [Movies].[ID],
			[Sort],1,[Movies].[DateCreated],[DateInventoried],[Movies].[DateModified],[DatePurchased],[ReleaseDate],[DateVerified],
			[Distributor],[Format],[Notes],[Price],[Subject],[Title],[Value],[WishList],[StoreBought],[WMV],[Locations].[ID],'Movies'
		FROM [GGGSCP1].[TreasureChest].[dbo].[Movies] [Movies]
			LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Movies].[Location]=[Locations].[OName]
		ORDER BY [Movies].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Movies];
		Select @Actual=Count(*) From [dbo].[Videos] Where [SourceTable]='Movies';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Videos].[ID],'Videos',[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[Videos] [Videos] On [History].[TableName]='Movies' And [Videos].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Movies' 
		ORDER BY [History].[ID];
		--Now grab any history for deleted records...
		Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
		If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
		Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
			[History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
		Into #DeletedHistory 
		From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
		Where [History].[TableName]='Movies' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Movies] Where [ID]=[History].[RecordID])
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
		End
		Close h;
		Deallocate h;
		INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
		Drop Table #DeletedHistory;
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Movies';
		Select @Actual=@OrphanedHistoryCount+Count(*) From [dbo].[History] Where [TableName]='Videos' And [History].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Movies');
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Videos: '+[Movies].[Title]),[Movies].[Title],'Videos',getdate(),getdate(),Null,Null,[Image],[Movies].[Title],Null,
			[newVideos].[ID],'Videos',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Movies] [Movies]
			INNER JOIN [dbo].[Videos] [newVideos] On [Movies].[ID]=[newVideos].[OID]
		WHERE [Movies].[Image] is not Null
		ORDER BY [Movies].[ID];
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Videos: '+[Movies].[Title]),[Movies].[Title],'Videos',getdate(),getdate(),Null,Null,[OtherImage],[Movies].[Title],Null,
			[newVideos].[ID],'Videos',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Movies] [Movies]
			INNER JOIN [dbo].[Videos] [newVideos] On [Movies].[ID]=[newVideos].[OID]
		WHERE [Movies].[OtherImage] is not Null
		ORDER BY [Movies].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Movies] Where [Image] is not Null;
		Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Movies] Where [OtherImage] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Videos' And [Images].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Movies');
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
Grant Execute on [dbo].[sp_MigrateMovies] to [Public];
