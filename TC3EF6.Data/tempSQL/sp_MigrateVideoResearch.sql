--sp_MigrateVideoResearch.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateVideoResearch' AND type='P') Drop Procedure sp_MigrateVideoResearch
Go
Create Procedure sp_MigrateVideoResearch As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'Videos/Video Research'
		Delete From [dbo].[Images] Where [TableName]='Videos' And [Images].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Video Research');
		Delete From [dbo].[History] Where [TableName]='Videos' And [History].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Video Research');
		Delete From [dbo].[Videos] Where [SourceTable]='Video Research';
		INSERT INTO [dbo].[Videos] ([OID],
			[AlphaSort],[Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateReleased],[DateVerified],
			[Distributor],[MediaFormat],[Notes],[Price],[Subject],[Title],[Value],[WishList],[StoreBought],[WMV],[LocationID],[SourceTable])
		SELECT [Video Research].[ID],
			[AlphaSort],1,[Video Research].[DateCreated],[DateInventoried],[Video Research].[DateModified],[DatePurchased],[ReleaseDate],[DateVerified],
			[Distributor],[Format],[Notes],[Price],[Subject],[Title],[Value],[WishList],0,[WMV],[Locations].[ID],'Video Research'
		FROM [GGGSCP1].[TreasureChest].[dbo].[Video Research] [Video Research]
			LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Video Research].[Location]=[Locations].[OName]
		ORDER BY [Video Research].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Video Research];
		Select @Actual=Count(*) From [dbo].[Videos] Where [SourceTable]='Video Research';
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
			INNER JOIN [GGGSCP1].[TreasureChest].[dbo].[Video Research] [Video Research] On [History].[TableName]='Video Research' And [History].[RecordID]=[Video Research].[ID]
			INNER JOIN [dbo].[Videos] [Videos] On [Video Research].[ID]=[Videos].[OID]
				And [History].[RecordID]=[Video Research].[ID]
		WHERE [History].[TableName]='Video Research' 
		ORDER BY [History].[ID];
		--Now grab any history for deleted records...
		Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
		If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
		Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
			[History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
		Into #DeletedHistory 
		From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
		Where [History].[TableName]='Video Research' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Video Research] Where [ID]=[History].[RecordID])
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
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Video Research';
		Select @Actual=@OrphanedHistoryCount+Count(*) From [dbo].[History] Where [TableName]='Videos' And [History].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Video Research');
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Videos: '+[Video Research].[Title]),[Video Research].[Title],'Videos',getdate(),getdate(),Null,Null,[Image],[Video Research].[Title],Null,
			[newVideo Research].[ID],'Videos',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Video Research] [Video Research]
			INNER JOIN [dbo].[Videos] [newVideo Research] On [Video Research].[ID]=[newVideo Research].[OID]
		WHERE [Video Research].[Image] is not Null
		ORDER BY [Video Research].[ID];
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Videos: '+[Video Research].[Title]),[Video Research].[Title],'Videos',getdate(),getdate(),Null,Null,[OtherImage],[Video Research].[Title],Null,
			[newVideo Research].[ID],'Videos',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Video Research] [Video Research]
			INNER JOIN [dbo].[Videos] [newVideo Research] On [Video Research].[ID]=[newVideo Research].[OID]
		WHERE [Video Research].[OtherImage] is not Null
		ORDER BY [Video Research].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Video Research] Where [Image] is not Null;
		Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Video Research] Where [OtherImage] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Videos' And [Images].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Video Research');
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
Grant Execute on [dbo].[sp_MigrateVideoResearch] to [Public];
