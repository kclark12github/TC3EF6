--sp_MigrateMusic.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--  06/02/19    Ken Clark       Enhanced to handle Artists/Tracks & Albums replacement for Music;
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

		Print '   Artists'
		Delete From [dbo].[Artists];
		INSERT INTO [dbo].[Artists] ([OID],
			[Name],[AlphaSort],[AKA],[Comments],[DateCreated],[DateModified])
		SELECT [Artists].[ID],
			[Name],[AlphaSort],[AKA],NULL,getdate() As [DateCreated],getdate() As [DateModified]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Artists] [Artists]
		ORDER BY [Artists].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Artists];
		Select @Actual=Count(*) From [dbo].[Artists];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Albums'
		Delete From [dbo].[Music];Delete From [dbo].[Albums];
		INSERT INTO [dbo].[Albums] ([OID],
			[AlphaSort],[Artist],[ArtistID],[Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[MediaFormat],
			[Notes],[Price],[Title],[Type],[Value],[WishList],[Year],[LocationID])
		SELECT [Music].[ID],
			[AlphaSort],[Artist],[Artists].[ID],[Inventoried],[Music].[DateCreated],[DateInventoried],[Music].[DateModified],[DatePurchased],[DateVerified],[Media],
			[Notes],[Price],[Title],[Type],[Value],[WishList],[Year],[Locations].[ID]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Music] [Music]
			LEFT OUTER JOIN [dbo].[Artists] [Artists] On [Music].[ArtistID]=[Artists].[OID]
		ORDER BY [Music].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Music];
		Select @Actual=Count(*) From [dbo].[Albums];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='Music';Delete From [dbo].[History] Where [TableName]='Albums';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Music].[ID],'Albums',[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[Music] [Music] On [History].[TableName]='Music' And [Music].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Music' 
		ORDER BY [History].[ID];
		--Now grab any history for deleted records...
		Declare @OID int, @RecordID uniqueidentifier;
		If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
		Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
			[History].[RecordID] As [OID],'Albums',[History].[Value],[History].[Who],NEWID() As [RecordID]
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
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Albums';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='Music';Delete From [dbo].[Images] Where [TableName]='Albums';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Albums: '+[Music].[Title]),[Music].[Artist]+': '+[Music].[Title]+' Cover','Albums',getdate(),getdate(),Null,Null,[Image],[Music].[Title],Null,
			[newMusic].[ID],'Albums',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Music] [Music]
			INNER JOIN [dbo].[Music] [newMusic] On [Music].[ID]=[newMusic].[OID]
		WHERE [Music].[Image] is not Null
		ORDER BY [Music].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Music] Where [Image] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Albums';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Tracks';
		Delete From [dbo].[Tracks];
		INSERT INTO [dbo].[Tracks] ([OID],
	        [Genre],[AlbumArtist],[AlbumArtistID],[Artist],[ArtistID],[Year],[Album],[AlbumID],
            [DiscNumber],[TrackNumber],[Title],[Duration],[Composer],[Comment],[Path],[Lyrics],[Publisher],
            [DateCreated],[DateModified])
        SELECT [ID],
            [Genre],[AlbumArtist],[AlbumsArtists].[ID],[Artist],[Artists].[ID],[Year],[Album],[Albums].[ID],
            [Disc],[Track],[Title],[Duration],[Composer],[Comment],[Path],[Lyrics],[Publisher],
            getdate() As [DateCreated],getdate() As [DateModified]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Tracks] [Tracks]
			LEFT OUTER JOIN [dbo].[Artists] [Artists] On [Tracks].[ArtistID]=[Artists].[OID]
			LEFT OUTER JOIN [dbo].[Artists] [AlbumArtists] On [Tracks].[AlbumArtistID]=[AlbumArtists].[OID]
			LEFT OUTER JOIN [dbo].[Albums] [Albums] On [Tracks].[AlbumID]=[Albums].[OID]
		ORDER BY [Tracks].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Tracks];
		Select @Actual=Count(*) From [dbo].[Tracks];
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
