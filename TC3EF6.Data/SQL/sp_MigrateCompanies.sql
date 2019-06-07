--sp_MigrateCompanies.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2018 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_MigrateCompanies' AND type='P') Drop Procedure sp_MigrateCompanies
Go
Create Procedure sp_MigrateCompanies As 
Begin
	Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
	Declare @Actual int, @Expected int, @Message nvarchar(2000);
	Begin Try
		Begin Transaction;
		Print 'Companies...';
		Delete From [dbo].[Companies];
		INSERT INTO [dbo].[Companies] ([OID],
			[Account],[Address],[Code],[DateCreated],[DateModified],[Name],[Phone],[ProductType],[ShortName],[WebSite])
		SELECT [ID],
			[Account],[Address],[Code],[DateCreated],[DateModified],[Name],[Phone],[ProductType],[ShortName],[WebSite]
		FROM [GGGSCP1].[TreasureChest].[dbo].[Companies] ORDER BY [ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Companies];
		Select @Actual=Count(*) From [dbo].[Companies];
		If @Actual <> @Expected Begin 
			Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
			RAISERROR (@Message, 16, 1);
		End;

		Print '   History';
		Delete From [dbo].[History] Where [TableName]='Companies';
		INSERT INTO [dbo].[History] ([OID],
			[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
		SELECT [History].[ID],
			[History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Companies].[ID],'Companies',[History].[Value],[History].[Who]
		FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
			INNER JOIN [dbo].[Companies] [Companies] On [History].[TableName]='Companies' And [Companies].[OID]=[History].[RecordID]
		WHERE [History].[TableName]='Companies' 
		ORDER BY [History].[ID];
		Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Companies';
		Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Companies';
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
Grant Execute on [dbo].[sp_MigrateCompanies] to [Public];
