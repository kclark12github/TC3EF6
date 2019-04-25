--sp_MigrateDetailSets.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateDetailSets' AND type='P') Drop Procedure sp_MigrateDetailSets
Go
Create Procedure sp_MigrateDetailSets As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'DetailSets';
		Delete From [dbo].[DetailSets];
		INSERT INTO [dbo].[DetailSets] ([OID],
			[Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[Designation],
			[Manufacturer],[Name],[Nation],[Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],[LocationID])
		SELECT [Detail Sets].[ID],
			1,[Detail Sets].[DateCreated],[DateInventoried],[Detail Sets].[DateModified],[DatePurchased],[DateVerified],[Designation],
			[Manufacturer],[Detail Sets].[Name],[Nation],[Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],[Locations].[ID]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Detail Sets] [Detail Sets]
			LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Detail Sets].[Location]=[Locations].[OName]
		ORDER BY [Detail Sets].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Detail Sets];
		Select @Actual=Count(*) From [dbo].[DetailSets];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='DetailSets';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[DetailSets].[ID],'DetailSets',[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[DetailSets] [DetailSets] On [History].[TableName]='Detail Sets' And [DetailSets].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Detail Sets' 
		ORDER BY [History].[ID];
		--Now grab any history for deleted records...
		Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
		If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
		Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
			[History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
		Into #DeletedHistory 
		From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
		Where [History].[TableName]='Detail Sets' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Detail Sets] Where [ID]=[History].[RecordID])
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
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Detail Sets';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='DetailSets';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='DetailSets';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Detail Sets: '+[Detail Sets].[Name]),
			[Detail Sets].[Scale]+' '+[Detail Sets].[Designation]+' '+[Detail Sets].[Name]+' ('+[Detail Sets].[Reference]+')',
			'DetailSets',getdate(),getdate(),Null,Null,[Image],[Detail Sets].[Name],Null,
			[DetailSets].[ID],'DetailSets',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Detail Sets] [Detail Sets]
			INNER JOIN [dbo].[DetailSets] [DetailSets] On [Detail Sets].[ID]=[DetailSets].[OID]
		WHERE [Detail Sets].[Image] is not Null
		ORDER BY [Detail Sets].[ID];
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Detail Sets: '+[Detail Sets].[Name]),
			[Detail Sets].[Scale]+' '+[Detail Sets].[Designation]+' '+[Detail Sets].[Name]+' ('+[Detail Sets].[Reference]+')',
			'DetailSets',getdate(),getdate(),Null,Null,[OtherImage],[Detail Sets].[Name],Null,
			[DetailSets].[ID],'DetailSets',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Detail Sets] [Detail Sets]
			INNER JOIN [dbo].[DetailSets] [DetailSets] On [Detail Sets].[ID]=[DetailSets].[OID]
		WHERE [Detail Sets].[OtherImage] is not Null
		ORDER BY [Detail Sets].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Detail Sets] Where [Image] is not Null;
		Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Detail Sets] Where [OtherImage] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='DetailSets';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Kits';
		Declare @KitID uniqueidentifier, @DetailSetOID int, @DetailSetID uniqueidentifier;
		Declare kitCursor Cursor For
			Select [Kits].[ID] As [Kits.ID],[OKits].[DetailSetID] As [DetailSet.OID],[DetailSets].[ID] As [DetailSet.ID]
			From [dbo].[Kits] 
				Inner Join [GGGSCP1].[TreasureChest].[dbo].[Kits] [OKits] On [OKits].ID=[Kits].[OID]
				Inner Join [dbo].[DetailSets] On [DetailSets].[OID]=[OKits].[DetailSetID];
		Open kitCursor;
		Fetch Next From kitCursor Into @KitID, @DetailSetOID, @DetailSetID;
		While @@FETCH_STATUS = 0
		Begin
			Update [dbo].[Kits] Set [DetailSet_ID]=@DetailSetID Where [Kits].[ID]=@KitID;
			Fetch Next From kitCursor Into @KitID, @DetailSetOID, @DetailSetID;
		End;
		Close kitCursor;
		Deallocate kitCursor;
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Kits] Where [DetailSetID] is not Null;
		Select @Actual=Count(*) From [dbo].[Kits] Where [DetailSet_ID] is not Null;
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
Grant Execute on [dbo].[sp_MigrateDetailSets] to [Public];
