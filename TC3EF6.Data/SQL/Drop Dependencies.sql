IF EXISTS(SELECT name FROM sysobjects WHERE name='NotOnCD' AND type='V') Drop View NotOnCD;
IF EXISTS(SELECT name FROM sysobjects WHERE name='MP3Only' AND type='V') Drop View MP3Only;
IF EXISTS(SELECT name FROM sysobjects WHERE name='LPOnly' AND type='V') Drop View LPOnly;
IF EXISTS(SELECT name FROM sysobjects WHERE name='CSOnly' AND type='V') Drop View CSOnly;
IF EXISTS(SELECT name FROM sysobjects WHERE name='CDOnly' AND type='V') Drop View CDOnly;
IF EXISTS(SELECT name FROM sysobjects WHERE name='Music' AND type='V') Drop View Music;

--SELECT 'IF EXISTS(SELECT name FROM sysobjects WHERE name='''+ name +''' AND type=''P'') Drop Procedure '+ name + ';'  FROM sysobjects WHERE type = 'P';
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateQueries' AND type='P') Drop Procedure sp_MigrateQueries;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateRockets' AND type='P') Drop Procedure sp_MigrateRockets;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateShipClasses' AND type='P') Drop Procedure sp_MigrateShipClasses;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateShipClassTypes' AND type='P') Drop Procedure sp_MigrateShipClassTypes;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateShips' AND type='P') Drop Procedure sp_MigrateShips;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateSoftware' AND type='P') Drop Procedure sp_MigrateSoftware;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateSpecials' AND type='P') Drop Procedure sp_MigrateSpecials;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateTools' AND type='P') Drop Procedure sp_MigrateTools;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateTrains' AND type='P') Drop Procedure sp_MigrateTrains;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateVideoResearch' AND type='P') Drop Procedure sp_MigrateVideoResearch;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_TableSpaceUsed' AND type='P') Drop Procedure sp_TableSpaceUsed;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateAircraftDesignations' AND type='P') Drop Procedure sp_MigrateAircraftDesignations;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateBlueAngelsHistory' AND type='P') Drop Procedure sp_MigrateBlueAngelsHistory;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateBooks' AND type='P') Drop Procedure sp_MigrateBooks;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateCollectables' AND type='P') Drop Procedure sp_MigrateCollectables;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateCompanies' AND type='P') Drop Procedure sp_MigrateCompanies;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateDecals' AND type='P') Drop Procedure sp_MigrateDecals;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateDetailSets' AND type='P') Drop Procedure sp_MigrateDetailSets;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateEpisodes' AND type='P') Drop Procedure sp_MigrateEpisodes;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateFinishingProducts' AND type='P') Drop Procedure sp_MigrateFinishingProducts;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateImages' AND type='P') Drop Procedure sp_MigrateImages;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateKits' AND type='P') Drop Procedure sp_MigrateKits;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateMovies' AND type='P') Drop Procedure sp_MigrateMovies;
IF EXISTS(SELECT name FROM sysobjects WHERE name='sp_MigrateMusic' AND type='P') Drop Procedure sp_MigrateMusic;

--SELECT 'IF EXISTS(SELECT name FROM sysobjects WHERE name='''+ name +''' AND type=''U'') Drop Table '+ name + ';'  FROM sysobjects WHERE type = 'U';
IF EXISTS(SELECT name FROM sysobjects WHERE name='AircraftDesignations' AND type='U') Drop Table AircraftDesignations;
IF EXISTS(SELECT name FROM sysobjects WHERE name='BlueAngelsHistory' AND type='U') Drop Table BlueAngelsHistory;
IF EXISTS(SELECT name FROM sysobjects WHERE name='Companies' AND type='U') Drop Table Companies;
IF EXISTS(SELECT name FROM sysobjects WHERE name='Query' AND type='U') Drop Table Query;

IF EXISTS(SELECT name FROM sysobjects WHERE name='History' AND type='U') Drop Table History;
IF EXISTS(SELECT name FROM sysobjects WHERE name='Images' AND type='U') Drop Table Images;

IF EXISTS(SELECT name FROM sysobjects WHERE name='Books' AND type='U') Drop Table Books;
IF EXISTS(SELECT name FROM sysobjects WHERE name='Collectables' AND type='U') Drop Table Collectables;

IF EXISTS(SELECT name FROM sysobjects WHERE name='Kits' AND type='U') Drop Table Kits;
IF EXISTS(SELECT name FROM sysobjects WHERE name='Decals' AND type='U') Drop Table Decals;
IF EXISTS(SELECT name FROM sysobjects WHERE name='DetailSets' AND type='U') Drop Table DetailSets;
IF EXISTS(SELECT name FROM sysobjects WHERE name='FinishingProducts' AND type='U') Drop Table FinishingProducts;
IF EXISTS(SELECT name FROM sysobjects WHERE name='Rockets' AND type='U') Drop Table Rockets;
IF EXISTS(SELECT name FROM sysobjects WHERE name='Tools' AND type='U') Drop Table Tools;
IF EXISTS(SELECT name FROM sysobjects WHERE name='Trains' AND type='U') Drop Table Trains;

IF EXISTS(SELECT name FROM sysobjects WHERE name='Ships' AND type='U') Drop Table Ships;
IF EXISTS(SELECT name FROM sysobjects WHERE name='ShipClass' AND type='U') Drop Table ShipClass;
IF EXISTS(SELECT name FROM sysobjects WHERE name='ShipClassTypes' AND type='U') Drop Table ShipClassTypes;

IF EXISTS(SELECT name FROM sysobjects WHERE name='Software' AND type='U') Drop Table Software;

IF EXISTS(SELECT name FROM sysobjects WHERE name='Albums' AND type='U') Drop Table Albums;
IF EXISTS(SELECT name FROM sysobjects WHERE name='Artists' AND type='U') Drop Table Artists;
IF EXISTS(SELECT name FROM sysobjects WHERE name='Tracks' AND type='U') Drop Table Tracks;


IF EXISTS(SELECT name FROM sysobjects WHERE name='Episodes' AND type='U') Drop Table Episodes;
IF EXISTS(SELECT name FROM sysobjects WHERE name='Videos' AND type='U') Drop Table Videos;

IF EXISTS(SELECT name FROM sysobjects WHERE name='Locations' AND type='U') Drop Table Locations;

IF EXISTS(SELECT name FROM sysobjects WHERE name='__MigrationHistory' AND type='U') Drop Table __MigrationHistory;