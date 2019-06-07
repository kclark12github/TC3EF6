--sp_MigrateShips.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateShips' AND type='P') Drop Procedure sp_MigrateShips
Go
Create Procedure sp_MigrateShips As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'Ships...';
		Delete From [dbo].[Ships];
		INSERT INTO [dbo].[Ships] ([OID],
			[Aircraft],[ASWWeapons],[Beam],[Boilers],[Command],[DateCommissioned],[DateCreated],[DateModified],[Description],[Displacement],
			[Draft],[EW],[FireControl],[Guns],[History],[HomePort],[HullNumber],[InternetURL],[Length],[LocalURL],[Manning],[Missiles],
			[Name],[Notes],[Number],[Propulsion],[Radars],[Sonars],[Speed],[Status],[ZipCode],
			[ShipClass_ID],[ShipClassType_ID])
		SELECT [Ships].[ID],
			[Ships].[Aircraft],[Ships].[ASW Weapons],[Ships].[Beam],[Ships].[Boilers],[Ships].[Command],[Ships].[Commissioned],[Ships].[DateCreated],[Ships].[DateModified],Null,[Ships].[Displacement],
			[Ships].[Draft],[Ships].[EW],[Ships].[Fire Control],[Ships].[Guns],[Ships].[History]+[Ships].[More History],[Ships].[HomePort],[Ships].[HullNumber],[Ships].[URL_Internet],[Ships].[Length],[Ships].[URL_Local],[Ships].[Manning],[Ships].[Missiles],
			[Ships].[Name],[Ships].[Notes],[Ships].[Number],[Ships].[Propulsion],[Ships].[Radars],[Ships].[Sonars],[Ships].[Speed],[Ships].[Status],[Ships].[Zip Code],
			[ShipClass].[ID],[ShipClassTypes].[ID]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Ships]
			INNER JOIN [dbo].[ShipClass] [ShipClass] On [Ships].[ClassID]=[ShipClass].[OID]
			INNER JOIN [dbo].[ShipClassTypes] [ShipClassTypes] On [Ships].[ClassificationID]=[ShipClassTypes].[OID]
		ORDER BY [Ships].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Ships];
		Select @Actual=Count(*) From [dbo].[Ships];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='Ships';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Ships].[ID],'Ships',[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[Ships] [Ships] On [History].[TableName]='Ships' And [Ships].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Ships' 
		ORDER BY [History].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Ships';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Ships';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='Ships';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Ships: '+[Ships].[Name]),Null,'Ships',getdate(),getdate(),Null,Null,[Image],[Ships].[Name],Null,
			[newShips].[ID],'Ships',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Ships] [Ships]
			INNER JOIN [dbo].[Ships] [newShips] On [Ships].[ID]=[newShips].[OID]
		WHERE [Ships].[Image] is not Null
		ORDER BY [Ships].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Ships] Where [Image] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Ships';
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
		Rollback;
		--Use RAISERROR inside the CATCH block to return error information about the original error that caused execution to jump to the CATCH block.
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	End Catch;
End;
Grant Execute on [dbo].[sp_MigrateShips] to [Public];
