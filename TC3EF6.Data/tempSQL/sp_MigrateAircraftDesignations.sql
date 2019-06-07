--sp_MigrateAircraftDesignations.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateAircraftDesignations' AND type='P') Drop Procedure sp_MigrateAircraftDesignations
Go
Create Procedure sp_MigrateAircraftDesignations As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'AircraftDesignations...';
		Delete From [dbo].[AircraftDesignations];
		INSERT INTO [dbo].[AircraftDesignations] ([OID],
			[Designation],[Manufacturer],[Name],[Nicknames],[Notes],[Number],[ServiceDate],[Type],[Version],[DateCreated],[DateModified])
		SELECT [ID],
			[Designation],[Manufacturer],[Name],[Nicknames],[Notes],[Number],[Service Date],[Type],[Version],[DateCreated],[DateModified]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Aircraft Designations] ORDER By [ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Aircraft Designations];
		Select @Actual=Count(*) From [dbo].[AircraftDesignations];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='AircraftDesignations';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[AircraftDesignations].[ID],'AircraftDesignations',[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[AircraftDesignations] [AircraftDesignations] On [History].[TableName]='Aircraft Designations' And [AircraftDesignations].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Aircraft Designations' 
		ORDER BY [History].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Aircraft Designations';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='AircraftDesignations';
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='AircraftDesignations';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Aircraft Designations: '+[Aircraft Designations].[Name]),Null,'AircraftDesignations',getdate(),getdate(),Null,Null,[Image],[Aircraft Designations].[Name],Null,
			[AircraftDesignations].[ID],'AircraftDesignations',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Aircraft Designations] [Aircraft Designations]
			INNER JOIN [dbo].[AircraftDesignations] [AircraftDesignations] On [Aircraft Designations].[ID]=[AircraftDesignations].[OID]
		WHERE [Aircraft Designations].[Image] is not Null
		ORDER BY [Aircraft Designations].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Aircraft Designations] Where [Image] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='AircraftDesignations';
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
Grant Execute on [dbo].[sp_MigrateAircraftDesignations] to [Public];
