--Data Migration.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2019 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	06/06/19	Ken Clark		sp_PrepDataMigration;
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
--[myrdstest.cbbj4y6xmfye.us-east-1.rds.amazonaws.com,1433]
--[(localdb)\MSSQLLocalDB].[TC3EF6]
--=================================================================================================================================
Begin Try
	Set NoCount On;
	exec sp_PrepDataMigration;

	exec sp_MigrateImages;
	exec sp_MigrateAircraftDesignations;
	exec sp_MigrateBlueAngelsHistory;
	exec sp_MigrateCompanies;
	exec sp_MigrateQueries;

	exec sp_MigrateBooks;
	exec sp_MigrateMusic;
	exec sp_MigrateSoftware;

	exec sp_MigrateCollectables;

	exec sp_MigrateKits;
	exec sp_MigrateDecals;
	exec sp_MigrateDetailSets;
	exec sp_MigrateFinishingProducts;
	exec sp_MigrateRockets;
	exec sp_MigrateTools;
	exec sp_MigrateTrains;

	exec sp_MigrateShipClassTypes;
	exec sp_MigrateShipClasses;
	exec sp_MigrateShips;

	exec sp_MigrateMovies;
	exec sp_MigrateSpecials;
	exec sp_MigrateVideoResearch;
	exec sp_MigrateEpisodes;

	exec sp_TableSpaceUsed;
End Try
Begin Catch
	Declare @ErrorMessage nvarchar(4000), @ErrorSeverity int, @ErrorState int;
	Select @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
	Rollback;
	--Use RAISERROR inside the CATCH block to return error information about the original error that caused execution to jump to the CATCH block.
	RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
End Catch;
Go
