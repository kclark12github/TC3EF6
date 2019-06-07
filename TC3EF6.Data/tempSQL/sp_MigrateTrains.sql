--sp_MigrateTrains.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateTrains' AND type='P') Drop Procedure sp_MigrateTrains
Go
Create Procedure sp_MigrateTrains As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'Trains'
		Delete From [dbo].[Trains];
		INSERT INTO [dbo].[Trains] ([OID],
			[Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[Line],[Manufacturer],[Name],
			[Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],[LocationID])
		SELECT [Trains].[ID],
			1,[Trains].[DateCreated],[DateInventoried],[Trains].[DateModified],[DatePurchased],[DateVerified],[Line],[Manufacturer],[Line],
			[Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],[Locations].[ID]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Trains] [Trains]
			LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Trains].[Location]=[Locations].[OName]
		ORDER BY [Trains].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Trains];
		Select @Actual=Count(*) From [dbo].[Trains];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='Trains';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Trains].[ID],[History].[TableName],[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[Trains] [Trains] On [History].[TableName]='Trains' And [Trains].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Trains' 
		ORDER BY [History].[ID];
		--Now grab any history for deleted records...
		Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
		If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
		Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
			[History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
		Into #DeletedHistory 
		From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
		Where [History].[TableName]='Trains' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Trains] Where [ID]=[History].[RecordID])
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
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Trains';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Trains';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='Trains';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Trains: '+[Trains].[Line]),[Trains].[Line],'Trains',getdate(),getdate(),Null,Null,[Image],[Trains].[Line],Null,
			[newTrains].[ID],'Trains',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Trains] [Trains]
			INNER JOIN [dbo].[Trains] [newTrains] On [Trains].[ID]=[newTrains].[OID]
		WHERE [Trains].[Image] is not Null
		ORDER BY [Trains].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Trains] Where [Image] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Trains';
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
Grant Execute on [dbo].[sp_MigrateTrains] to [Public];
