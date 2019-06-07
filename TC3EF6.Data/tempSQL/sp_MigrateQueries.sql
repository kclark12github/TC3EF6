--sp_MigrateQueries.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateQueries' AND type='P') Drop Procedure sp_MigrateQueries
Go
Create Procedure sp_MigrateQueries As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'Query...';
		Delete From [dbo].[Query];
		INSERT INTO [dbo].[Query] ([OID],
			[Access],[DateCreated],[DateModified],[Description],[Name],[QueryText])
		SELECT ROW_NUMBER() OVER (Order by Name) AS ID,
			[Access],[DateCreated],[DateModified],[Description],[Name],[Query]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Query] ORDER BY [ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Query];
		Select @Actual=Count(*) From [dbo].[Query];
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
Grant Execute on [dbo].[sp_MigrateQueries] to [Public];
