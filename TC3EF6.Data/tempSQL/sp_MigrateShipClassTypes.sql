--sp_MigrateShipClassTypes.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateShipClassTypes' AND type='P') Drop Procedure sp_MigrateShipClassTypes
Go
Create Procedure sp_MigrateShipClassTypes As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'ShipClassTypes/Classifications...';
		--Seed method will have already added most this static data...
		Update [ShipClassTypes] Set [OID]=(Select Top 1 ID From [GGGSCP1].[TreasureChest].[dbo].[Classification] Where [Type]=[TypeCode] And [Classification].[Description]=[ShipClassTypes].[Description]);
		Update [ShipClassTypes] Set [OID]=(Select Top 1 ID From [GGGSCP1].[TreasureChest].[dbo].[Classification] Where [Type] Is Null And [Classification].[Description]='Unassigned') Where [ShipClassTypes].[Description]='Unassigned';
		--INSERT INTO [dbo].[ShipClassTypes] ([OID],
		--	[DateCreated],[DateModified],[Description],[TypeCode])
		--SELECT [ID],
		--	[DateCreated],[DateModified],[Description],[Type]
		--FROM [GGGSCP1].[TreasureChest].[dbo].[Classification] ORDER BY [ID];

		Print '   History';
		Delete From [dbo].[History] Where [History].[TableName]='ShipClassTypes';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[ShipClassificationTypes].[ID],'ShipClassTypes',[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[ShipClassTypes] [ShipClassificationTypes] On [History].[TableName]='Classification' And [ShipClassificationTypes].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Classification' 
		ORDER BY [History].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Classification';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='ShipClassTypes';
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
Grant Execute on [dbo].[sp_MigrateShipClassTypes] to [Public];
