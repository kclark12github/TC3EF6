--sp_MigrateShipClasses.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateShipClasses' AND type='P') Drop Procedure sp_MigrateShipClasses
Go
Create Procedure sp_MigrateShipClasses As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'ShipClass/Class...';
		Delete From [dbo].[ShipClass];
		INSERT INTO [dbo].[ShipClass] ([OID],
			[Aircraft],[ASWWeapons],[Beam],[Boilers],[DateCreated],[DateModified],[Description],[Displacement],[Draft],[EW],[FireControl],
			[Guns],[Length],[Manning],[Missiles],[Name],[Notes],[Propulsion],[Radars],[Sonars],[Speed],[Year],[ShipClassType_ID])
		SELECT [Class].[ID],
			[Class].[Aircraft],[Class].[ASW Weapons],[Class].[Beam],[Class].[Boilers],[Class].[DateCreated],[Class].[DateModified],[Class].[Description],[Class].[Displacement],[Class].[Draft],[Class].[EW],[Class].[Fire Control],
			[Class].[Guns],[Class].[Length],[Class].[Manning],[Class].[Missiles],[Class].[Name],[Class].[Notes],[Class].[Propulsion],[Class].[Radars],[Class].[Sonars],[Class].[Speed],[Class].[Year],[ShipClassTypes].[ID]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Class] [Class]
			INNER JOIN [dbo].[ShipClassTypes] [ShipClassTypes] On [Class].[ClassificationID]=[ShipClassTypes].[OID]
		ORDER BY [Class].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Class];
		Select @Actual=Count(*) From [dbo].[ShipClass];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [History].[TableName]='ShipClass';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[ShipClass].[ID],'ShipClass',[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[ShipClass] [ShipClass] On [History].[TableName]='Class' And [ShipClass].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Class' 
		ORDER BY [History].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Class';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='ShipClass';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='ShipClass';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Ship Class: '+[Class].[Name]),Null,'ShipClass',getdate(),getdate(),Null,Null,[Image],[Class].[Name],Null,
			[ShipClass].[ID],'ShipClass',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Class] [Class]
			INNER JOIN [dbo].[ShipClass] [ShipClass] On [Class].[ID]=[ShipClass].[OID]
		WHERE [Class].[Image] is not Null
		ORDER BY [Class].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Class] Where [Image] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='ShipClass';
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
Grant Execute on [dbo].[sp_MigrateShipClasses] to [Public];
