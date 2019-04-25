--sp_MigrateDecals.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateDecals' AND type='P') Drop Procedure sp_MigrateDecals
Go
Create Procedure sp_MigrateDecals As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'Decals';
		Delete From [dbo].[Decals];
		INSERT INTO [dbo].[Decals] ([OID],
			[Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[Designation],
			[Manufacturer],[Name],[Nation],[Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],[LocationID])
		SELECT [Decals].[ID],
			1,[Decals].[DateCreated],[DateInventoried],[Decals].[DateModified],[DatePurchased],[DateVerified],[Designation],
			[Manufacturer],[Decals].[Name],[Nation],[Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],[Locations].[ID]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Decals] [Decals]
			LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Decals].[Location]=[Locations].[OName]
		ORDER BY [Decals].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Decals];
		Select @Actual=Count(*) From [dbo].[Decals];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='Decals';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Decals].[ID],[History].[TableName],[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[Decals] [Decals] On [History].[TableName]='Decals' And [Decals].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Decals' 
		ORDER BY [History].[ID];
		--Now grab any history for deleted records...
		Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
		If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
		Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
			[History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
		Into #DeletedHistory 
		From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
		Where [History].[TableName]='Decals' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Decals] Where [ID]=[History].[RecordID])
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
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Decals';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Decals';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='Decals';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Decals: '+[Decals].[Name]),
			[Decals].[Scale]+' '+[Decals].[Designation]+' '+[Decals].[Name]+' ('+[Decals].[Reference]+')',
			'Decals',getdate(),getdate(),Null,Null,[Image],[Decals].[Name],Null,
			[newDecals].[ID],'Decals',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Decals] [Decals]
			INNER JOIN [dbo].[Decals] [newDecals] On [Decals].[ID]=[newDecals].[OID]
		WHERE [Decals].[Image] is not Null
		ORDER BY [Decals].[ID];
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Decals: '+[Decals].[Name]),
			[Decals].[Scale]+' '+[Decals].[Designation]+' '+[Decals].[Name]+' ('+[Decals].[Reference]+')',
			'Decals',getdate(),getdate(),Null,Null,[OtherImage],[Decals].[Name],Null,
			[newDecals].[ID],'Decals',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Decals] [Decals]
			INNER JOIN [dbo].[Decals] [newDecals] On [Decals].[ID]=[newDecals].[OID]
		WHERE [Decals].[OtherImage] is not Null
		ORDER BY [Decals].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Decals] Where [Image] is not Null;
		Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Decals] Where [OtherImage] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Decals';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Kits';
		Declare @KitID uniqueidentifier, @DecalOID int, @DecalID uniqueidentifier;
		Declare kitCursor Cursor For
			Select [Kits].[ID] As [Kits.ID],[OKits].[DecalID] As [Decal.OID],[Decals].[ID] As [Decal.ID]
			From [dbo].[Kits] 
				Inner Join [GGGSCP1].[TreasureChest].[dbo].[Kits] [OKits] On [OKits].ID=[Kits].[OID]
				Inner Join [dbo].[Decals] On [Decals].[OID]=[OKits].[DecalID];
		Open kitCursor;
		Fetch Next From kitCursor Into @KitID, @DecalOID, @DecalID;
		While @@FETCH_STATUS = 0
		Begin
			Update [dbo].[Kits] Set [Decal_ID]=@DecalID Where [Kits].[ID]=@KitID;
			Fetch Next From kitCursor Into @KitID, @DecalOID, @DecalID;
		End;
		Close kitCursor;
		Deallocate kitCursor;
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Kits] Where [DecalID] is not Null;
		Select @Actual=Count(*) From [dbo].[Kits] Where [Decal_ID] is not Null;
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
Grant Execute on [dbo].[sp_MigrateDecals] to [Public];
