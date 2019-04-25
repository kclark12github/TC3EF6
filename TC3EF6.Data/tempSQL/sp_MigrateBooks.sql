--sp_MigrateBooks.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateBooks' AND type='P') Drop Procedure sp_MigrateBooks
Go
Create Procedure sp_MigrateBooks As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'Books...';
		Delete From [dbo].[Books];
		INSERT INTO [dbo].[Books] ([OID],
			[AlphaSort],[Author],[MediaFormat],[ISBN],[Misc],[Subject],[Title],[Cataloged],[DateInventoried],
			[DatePurchased],[DateVerified],[Notes],[Price],[Value],[WishList],[DateCreated],[DateModified],[LocationID])
		SELECT [Books].[ID],
			[Alphasort],[Author],[Format],[ISBN],[Misc],[Subject],[Title],[Cataloged],[DateInventoried],
			[DatePurchased],[DateVerified],[Notes],[Price],[Value],[WishList],[Books].[DateCreated],[Books].[DateModified],[Locations].[ID]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Books] [Books]
			LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Books].[Location]=[Locations].[OName]
		ORDER BY [Books].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Books];
		Select @Actual=Count(*) From [dbo].[Books];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='Books';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Books].[ID],[History].[TableName],[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[Books] [Books] On [History].[TableName]='Books' And [Books].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Books' 
		ORDER BY [History].[ID];
		--Now grab any history for deleted records...
		Declare @OID int, @RecordID uniqueidentifier;
		If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
		Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
			[History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
		Into #DeletedHistory 
		From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
		Where [History].[TableName]='Books' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Books] Where [ID]=[History].[RecordID])
		Order By [History].[RecordID];	--618
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
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Books';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Books';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='Books';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('BOOKS: '+[Books].[Title]),[Books].[Title]+' (Front Cover)','Books',getdate(),getdate(),Null,Null,[Image],[Books].[Title],Null,
			[newBooks].[ID],'Books',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Books] [Books]
			INNER JOIN [dbo].[Books] [newBooks] On [Books].[ID]=[newBooks].[OID]
		WHERE [Books].[Image] is not Null
		ORDER BY [Books].[ID];
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('BOOKS: '+[Books].[Title]),[Books].[Title]+' (Back Cover)','Books',getdate(),getdate(),Null,Null,[OtherImage],[Books].[Title],Null,
			[newBooks].[ID],'Books',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Books] [Books]
			INNER JOIN [dbo].[Books] [newBooks] On [Books].[ID]=[newBooks].[OID]
		WHERE [Books].[OtherImage] is not Null
		ORDER BY [Books].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Books] Where [Image] is not Null;
		Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Books] Where [OtherImage] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Books';
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
Grant Execute on [dbo].[sp_MigrateBooks] to [Public];
