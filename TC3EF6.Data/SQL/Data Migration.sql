--Data Migration.sql
--   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
--   Copyright © 2019 All Rights Reserved.
--*********************************************************************************************************************************
--
--	Modification History:
--	Date:       Developer:		Description:
--	06/06/19	Ken Clark		Added sp_PrepDataMigration;
--	02/01/19	Ken Clark		Created;
--=================================================================================================================================
--[myrdstest.cbbj4y6xmfye.us-east-1.rds.amazonaws.com,1433]
--[(localdb)\MSSQLLocalDB].[TC3EF6]
--=================================================================================================================================
            
Create Procedure sp_DataMigration As 
Begin
    Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
    Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_DataMigration';
    Begin Transaction;
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
		Rollback Transaction;
		exec sp_LogError @Milestone;
		Throw;
    End Catch;
	Insert Into LOG(MileStone,StartTime,FinishTime,Message) Values (@Milestone,@stTime,CURRENT_TIMESTAMP,'Elapsed: '+Convert(nvarchar(24),CURRENT_TIMESTAMP-@stTime,114));
	Commit Transaction;
End;
