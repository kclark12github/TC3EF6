--sp_MigrateBlueAngelsHistory.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateBlueAngelsHistory' AND type='P') Drop Procedure sp_MigrateBlueAngelsHistory
Go
Create Procedure sp_MigrateBlueAngelsHistory As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'BlueAngelsHistory...';
		Delete From [dbo].[BlueAngelsHistory];
		INSERT INTO [dbo].[BlueAngelsHistory] ([OID],
			[ServiceDates],[AircraftType],[Decals],[DecalSets],[Kits],[Notes],[DateCreated],[DateModified])
		SELECT 	[ID],
			[Dates],[Aircraft Type],[Decal Sets],Null,[Kits],[Notes],[DateCreated],[DateModified]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Blue Angels History] ORDER By [ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Blue Angels History];
		Select @Actual=Count(*) From [dbo].[BlueAngelsHistory];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   Images';
		Delete From [dbo].[Images] Where [TableName]='BlueAngelsHistory';
		INSERT INTO [dbo].[Images] ([OID],
			[AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
			[RecordID],[TableName],[Thumbnail],[URL],[Width])
		SELECT Null,Upper('Blue Angels History: '+[Blue Angels History].[Aircraft Type]),Null,'BlueAngelsHistory',getdate(),getdate(),Null,Null,[Image],[Blue Angels History].[Aircraft Type],Null,
			[BlueAngelsHistory].[ID],'BlueAngelsHistory',0,Null,Null
		FROM [GGGSCP1].[TreasureChest].[dbo].[Blue Angels History] [Blue Angels History]
			INNER JOIN [dbo].[BlueAngelsHistory] [BlueAngelsHistory] On [Blue Angels History].[ID]=[BlueAngelsHistory].[OID]
		WHERE [Blue Angels History].[Image] is not Null
		ORDER BY [Blue Angels History].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Blue Angels History] Where [Image] is not Null;
		Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='BlueAngelsHistory';
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
Grant Execute on [dbo].[sp_MigrateBlueAngelsHistory] to [Public];
