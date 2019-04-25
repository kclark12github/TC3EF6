--sp_MigrateMusic.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateMusic' AND type='P') Drop Procedure sp_MigrateMusic
Go
Create Procedure sp_MigrateMusic As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'Music'
		Delete From [dbo].[Music];
		INSERT INTO [dbo].[Music] ([OID],
			[AlphaSort],[Artist],[Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[MediaFormat],
			[Notes],[Price],[Title],[Type],[Value],[WishList],[Year],[LocationID])
		SELECT [Music].[ID],
			[AlphaSort],[Artist],[Inventoried],[Music].[DateCreated],[DateInventoried],[Music].[DateModified],[DatePurchased],[DateVerified],[Media],
			[Notes],[Price],[Title],[Type],[Value],[WishList],[Year],[Locations].[ID]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Music] [Music]
			LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Music].[Location]=[Locations].[OName]
		ORDER BY [Music].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Music];
		Select @Actual=Count(*) From [dbo].[Music];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='Music';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Music].[ID],[History].[TableName],[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[Music] [Music] On [History].[TableName]='Music' And [Music].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Music' 
		ORDER BY [History].[ID];
		--Now grab any history for deleted records...
		Declare @OID int, @RecordID uniqueidentifier;
		If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
		Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
			[History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
		Into #DeletedHistory 
		From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
		Where [History].[TableName]='Music' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Music] Where [ID]=[History].[RecordID])
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
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Music';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Music';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='Music';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Music: '+[Music].[Title]),[Music].[Artist]+': '+[Music].[Title]+' Cover','Music',getdate(),getdate(),Null,Null,[Image],[Music].[Title],Null,
			[newMusic].[ID],'Music',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Music] [Music]
			INNER JOIN [dbo].[Music] [newMusic] On [Music].[ID]=[newMusic].[OID]
		WHERE [Music].[Image] is not Null
		ORDER BY [Music].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Music] Where [Image] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Music';
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
Grant Execute on [dbo].[sp_MigrateMusic] to [Public];
