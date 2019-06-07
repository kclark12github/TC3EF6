--sp_MigrateFinishingProducts.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateFinishingProducts' AND type='P') Drop Procedure sp_MigrateFinishingProducts
Go
Create Procedure sp_MigrateFinishingProducts As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'FinishingProducts'
		Delete From [dbo].[FinishingProducts];
		INSERT INTO [dbo].[FinishingProducts] ([OID],
			[Cataloged],[Count],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[Manufacturer],[Name],
			[Notes],[Price],[ProductCatalog],[Reference],[Type],[Value],[WishList],[LocationID])
		SELECT [Finishing Products].[ID],
			1,[Count],[Finishing Products].[DateCreated],[DateInventoried],[Finishing Products].[DateModified],[DatePurchased],[DateVerified],[Manufacturer],[Finishing Products].[Name],
			[Notes],[Price],[ProductCatalog],[Reference],[Type],[Value],[WishList],[Locations].[ID]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Finishing Products] [Finishing Products]
			LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Finishing Products].[Location]=[Locations].[OName]
		ORDER BY [Finishing Products].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Finishing Products];
		Select @Actual=Count(*) From [dbo].[FinishingProducts];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='Finishing Products';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[FinishingProducts].[ID],'FinishingProducts',[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[FinishingProducts] [FinishingProducts] On [History].[TableName]='Finishing Products' And [FinishingProducts].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Finishing Products' 
		ORDER BY [History].[ID];
		--Now grab any history for deleted records...
		Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
		If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
		Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
			[History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
		Into #DeletedHistory 
		From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
		Where [History].[TableName]='Finishing Products' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Finishing Products] Where [ID]=[History].[RecordID])
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
		SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],'FinishingProducts',[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
		Drop Table #DeletedHistory;
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Finishing Products';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='FinishingProducts';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='FinishingProducts';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Finishing Products: '+[Finishing Products].[Name]),[Finishing Products].[Name],'FinishingProducts',getdate(),getdate(),Null,Null,[Image],[Finishing Products].[Name],Null,
			[FinishingProducts].[ID],'FinishingProducts',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Finishing Products] [Finishing Products]
			INNER JOIN [dbo].[FinishingProducts] [FinishingProducts] On [Finishing Products].[ID]=[FinishingProducts].[OID]
		WHERE [Finishing Products].[Image] is not Null
		ORDER BY [Finishing Products].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Finishing Products] Where [Image] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='FinishingProducts';
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
Grant Execute on [dbo].[sp_MigrateFinishingProducts] to [Public];
