--sp_MigrateKits.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateKits' AND type='P') Drop Procedure sp_MigrateKits
Go
Create Procedure sp_MigrateKits As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'Kits'
		Delete From [dbo].[Kits];
		INSERT INTO [dbo].[Kits] ([OID],
			[Cataloged],[Condition],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[Decal_ID],
			[Designation],[DetailSet_ID],[Era],[Manufacturer],[Name],[Nation],[Notes],[OutOfProduction],[Price],[ProductCatalog],
			[Reference],[Scale],[Service],[Type],[Value],[WishList],[LocationID])
		SELECT [Kits].[ID],
			1,[Condition],[Kits].[DateCreated],[DateInventoried],[Kits].[DateModified],[DatePurchased],[DateVerified],Null,
			[Designation],Null,[Era],[Manufacturer],[Kits].[Name],[Nation],[Notes],[OutOfProduction],[Price],[ProductCatalog],
			[Reference],[Scale],[Service],[Type],[Value],[WishList],[Locations].[ID]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Kits] [Kits]
			LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Kits].[Location]=[Locations].[OName]
		ORDER BY [Kits].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Kits];
		Select @Actual=Count(*) From [dbo].[Kits];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='Kits';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Kits].[ID],[History].[TableName],[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[Kits] [Kits] On [History].[TableName]='Kits' And [Kits].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Kits' 
		ORDER BY [History].[ID];
		--Now grab any history for deleted records...
		Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
		If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
		Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
			[History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
		Into #DeletedHistory 
		From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
		Where [History].[TableName]='Kits' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Kits] Where [ID]=[History].[RecordID])
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
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Kits';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Kits';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='Kits';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Kits: '+[Kits].[Name]),
			[Kits].[Scale]+' '+[Kits].[Designation]+' '+[Kits].[Name]+' ('+[Kits].[Reference]+')',
			'Kits',getdate(),getdate(),Null,Null,[Image],[Kits].[Name],Null,
			[newKits].[ID],'Kits',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Kits] [Kits]
			INNER JOIN [dbo].[Kits] [newKits] On [Kits].[ID]=[newKits].[OID]
		WHERE [Kits].[Image] is not Null
		ORDER BY [Kits].[ID];
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Kits: '+[Kits].[Name]),
			[Kits].[Scale]+' '+[Kits].[Designation]+' '+[Kits].[Name]+' ('+[Kits].[Reference]+')',
			'Kits',getdate(),getdate(),Null,Null,[OtherImage],[Kits].[Name],Null,
			[newKits].[ID],'Kits',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Kits] [Kits]
			INNER JOIN [dbo].[Kits] [newKits] On [Kits].[ID]=[newKits].[OID]
		WHERE [Kits].[OtherImage] is not Null
		ORDER BY [Kits].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Kits] Where [Image] is not Null;
		Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Kits] Where [OtherImage] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Kits';
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
Grant Execute on [dbo].[sp_MigrateKits] to [Public];
