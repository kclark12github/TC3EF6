using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC3EF6.Domain.Classes;
using TC3EF6.Domain.Classes.Reference;

namespace TC3EF6.Data.CustomMigrationOperations
{
    public static class CustomSeed
    {
        //  This method will be called after migrating to the latest version.
        //
        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data.
        #region Data
        public static void SeedData(TCContext context)
        {
            Console.WriteLine("Seeding Data...");
            SeedAircraftDesignations(context);
            SeedBlueAngelsHistory(context);
            SeedLocations(context);
            SeedShipClassTypes(context);
        }
        private static void SeedAircraftDesignations(TCContext context)
        {
            Console.WriteLine("\tAircraftDesignations");
            //SELECT 'new AircraftDesignation { ID = Guid.NewGuid(), ' +
            //    'Designation = "' +[Designation] + '", ' +
            //    'Manufacturer = "' +[Manufacturer] + '", ' +
            //    'Name = ' + IsNull('"' +[Name] + '"', 'NULL') + ', ' +
            //    'Nicknames = ' + IsNull('"' +[Nicknames] + '"', 'NULL') + ', ' +
            //    'Notes = ' + IsNull('"' +[Notes] + '"', 'NULL') + ', ' +
            //    'Number = ' + IsNull(Convert(varchar(10),[Number]), 'NULL') + ', ' +
            //    'Version = ' + IsNull('"' +[Version] + '"', 'NULL') + ', ' +
            //    'ServiceDate = new DateTime(' + IsNull(Convert(varchar(4), Year([Service Date])) + ',' + Convert(varchar(2), Month([Service Date]))+',' + Convert(varchar(2), Day([Service Date]))+',' + Convert(varchar(2), DatePart(hh,[Service Date])) + ',' + Convert(varchar(2), DatePart(mi,[Service Date])) + ',' + Convert(varchar(2), DatePart(ss,[Service Date])),'1900,01,01,00,00,00')+'), ' +
            //                            'DateCreated = new DateTime(' + Convert(varchar(4), Year([DateCreated]))+',' + Convert(varchar(2), Month([DateCreated]))+',' + Convert(varchar(2), Day([DateCreated]))+',' + Convert(varchar(2), DatePart(hh,[DateCreated])) + ',' + Convert(varchar(2), DatePart(mi,[DateCreated])) + ',' + Convert(varchar(2), DatePart(ss,[DateCreated])) + '), ' +
            //                                  'DateModified = new DateTime(' + Convert(varchar(4), Year([DateModified]))+',' + Convert(varchar(2), Month([DateModified]))+',' + Convert(varchar(2), Day([DateModified]))+',' + Convert(varchar(2), DatePart(hh,[DateModified])) + ',' + Convert(varchar(2), DatePart(mi,[DateModified])) + ',' + Convert(varchar(2), DatePart(ss,[DateModified])) + ') },'
            //FROM [dbo].[Aircraft Designations];
            context.AircraftDesignations.AddOrUpdate(x => x.Name,
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-1 (AD)", Manufacturer = "Douglas", Name = "Skyraider", Nicknames = "Sandy, SPAD, Able Dog", Notes = null, Number = 1, Version = "", ServiceDate = new DateTime(1946, 11, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-3 (A3D, B-66)", Manufacturer = "Douglas", Name = "Skywarrior (See B-66 Destroyer)", Nicknames = "All Three Dead, Whale, Whistling Shitcan", Notes = null, Number = 3, Version = null, ServiceDate = new DateTime(1954, 12, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-4 (A4D)", Manufacturer = "McDonnell Douglas", Name = "Skyhawk", Nicknames = "The Scooter, Heinemann's Hot Rod, Bantam Bomber, Tinker Toy, Mighty Mite", Notes = null, Number = 4, Version = null, ServiceDate = new DateTime(1956, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-5 (A3J)", Manufacturer = "Rockwell", Name = "Vigilante", Nicknames = null, Notes = null, Number = 5, Version = null, ServiceDate = new DateTime(1960, 1, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "EA-6B", Manufacturer = "Grumman", Name = "Prowler - Electronic Warfare (Intruder)", Nicknames = null, Notes = null, Number = 6, Version = "B", ServiceDate = new DateTime(1968, 5, 25, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "KA-6D", Manufacturer = "Grumman", Name = "Intruder - Tanker Version", Nicknames = null, Notes = null, Number = 6, Version = "D", ServiceDate = new DateTime(1963, 4, 19, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-6 (A2F)", Manufacturer = "Grumman", Name = "Intruder (See KA-6, EA-6B Prowler)", Nicknames = null, Notes = null, Number = 6, Version = null, ServiceDate = new DateTime(1963, 4, 19, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-7D", Manufacturer = "Vought", Name = "Corsair II - U.S.A.F. Version", Nicknames = null, Notes = null, Number = 7, Version = "D", ServiceDate = new DateTime(1966, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-7E", Manufacturer = "Vought", Name = "Corsair II - U.S.N. Version", Nicknames = null, Notes = null, Number = 7, Version = "E", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-10", Manufacturer = "Fairchild/Republic", Name = "Thunderbolt II (Tank Killer)", Nicknames = null, Notes = null, Number = 10, Version = null, ServiceDate = new DateTime(1974, 12, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-11", Manufacturer = "Lockheed", Name = "Blackbird (CIA)", Nicknames = null, Notes = null, Number = 11, Version = null, ServiceDate = new DateTime(1964, 12, 22, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-20", Manufacturer = "Douglas", Name = "Boston (See P-70)", Nicknames = null, Notes = null, Number = 20, Version = null, ServiceDate = new DateTime(1940, 1, 2, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-24", Manufacturer = "Douglas", Name = "Dauntless (Land Based - Army)", Nicknames = null, Notes = null, Number = 24, Version = null, ServiceDate = new DateTime(1940, 6, 4, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-25", Manufacturer = "Curtiss", Name = "Helldiver (Marines)", Nicknames = null, Notes = null, Number = 25, Version = null, ServiceDate = new DateTime(1942, 6, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-26", Manufacturer = "Douglas", Name = "Invader", Nicknames = null, Notes = null, Number = 26, Version = null, ServiceDate = new DateTime(1943, 12, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "A-30", Manufacturer = "Martin", Name = "Baltimore", Nicknames = null, Notes = null, Number = 30, Version = null, ServiceDate = new DateTime(1941, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "SB2C", Manufacturer = "Curtiss (C)", Name = "Helldiver", Nicknames = null, Notes = null, Number = null, Version = "SB2C", ServiceDate = new DateTime(1942, 6, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "SBD", Manufacturer = "Douglas (D)", Name = "Dauntless (See A-24)", Nicknames = null, Notes = null, Number = null, Version = "SBD", ServiceDate = new DateTime(1940, 6, 4, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "AC-047", Manufacturer = "Douglas", Name = "\"Puff the Magic Dragon\" Gunship (See C-47)", Nicknames = null, Notes = null, Number = 47, Version = null, ServiceDate = new DateTime(1938, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "AC-119", Manufacturer = "Fairchild", Name = "Gunship (See C-119 Boxcar)", Nicknames = null, Notes = null, Number = 119, Version = null, ServiceDate = new DateTime(1949, 12, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "AC-130H", Manufacturer = "Lockheed", Name = "Hercules (Night Gunship)", Nicknames = null, Notes = null, Number = 130, Version = "H", ServiceDate = new DateTime(1955, 4, 7, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "AF-1E", Manufacturer = "North American", Name = "Fury (See F-1E, FJ-3, FJ-4 Fury)", Nicknames = null, Notes = null, Number = 1, Version = "E", ServiceDate = new DateTime(1953, 7, 3, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-1", Manufacturer = "Rockwell", Name = null, Nicknames = null, Notes = null, Number = 1, Version = null, ServiceDate = new DateTime(1979, 1, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-10", Manufacturer = "Martin", Name = null, Nicknames = null, Notes = null, Number = 10, Version = null, ServiceDate = new DateTime(1932, 3, 20, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-12", Manufacturer = "Martin", Name = null, Nicknames = null, Notes = null, Number = 12, Version = null, ServiceDate = new DateTime(1932, 3, 20, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-14", Manufacturer = "Martin", Name = null, Nicknames = null, Notes = null, Number = 14, Version = null, ServiceDate = new DateTime(1932, 3, 20, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-17", Manufacturer = "Boeing", Name = "Fortress", Nicknames = null, Notes = null, Number = 17, Version = null, ServiceDate = new DateTime(1939, 6, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-18", Manufacturer = "Douglas", Name = "Bolo/Digby-1", Nicknames = null, Notes = null, Number = 18, Version = null, ServiceDate = new DateTime(1937, 1, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-24", Manufacturer = "Consolidated", Name = "Liberator", Nicknames = null, Notes = null, Number = 24, Version = null, ServiceDate = new DateTime(1941, 6, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-25", Manufacturer = "North American", Name = "Mitchell (See F-10)", Nicknames = null, Notes = null, Number = 25, Version = null, ServiceDate = new DateTime(1940, 8, 19, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-26", Manufacturer = "Douglas", Name = "Invader (after B-26 Marauder was retired)", Nicknames = null, Notes = null, Number = 26, Version = null, ServiceDate = new DateTime(1943, 12, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-26", Manufacturer = "Martin", Name = "Marauder", Nicknames = null, Notes = null, Number = 26, Version = null, ServiceDate = new DateTime(1941, 2, 25, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-29", Manufacturer = "Boeing", Name = "Super Fortress", Nicknames = null, Notes = null, Number = 29, Version = null, ServiceDate = new DateTime(1943, 7, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-36", Manufacturer = "Convair", Name = "Peacemaker", Nicknames = null, Notes = null, Number = 36, Version = null, ServiceDate = new DateTime(1947, 8, 28, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-47", Manufacturer = "Boeing", Name = "Stratojet", Nicknames = null, Notes = null, Number = 47, Version = null, ServiceDate = new DateTime(1950, 6, 25, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-50", Manufacturer = "Boeing", Name = "Superfortress", Nicknames = null, Notes = null, Number = 50, Version = null, ServiceDate = new DateTime(1947, 6, 25, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-52", Manufacturer = "Boeing", Name = "Stratofortress", Nicknames = null, Notes = null, Number = 52, Version = null, ServiceDate = new DateTime(1955, 6, 29, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-57", Manufacturer = "Martin/General Dynamics", Name = "Canberra (See RB-57 Canberra)", Nicknames = null, Notes = null, Number = 57, Version = null, ServiceDate = new DateTime(1953, 7, 20, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "RB-57", Manufacturer = "Martin/General Dynamics", Name = "Canberra - Reconnaissance Version", Nicknames = null, Notes = null, Number = 57, Version = null, ServiceDate = new DateTime(1953, 7, 20, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-58", Manufacturer = "Convair", Name = "Hustler", Nicknames = null, Notes = null, Number = 58, Version = null, ServiceDate = new DateTime(1959, 9, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "B-66", Manufacturer = "Douglas", Name = "Destroyer (See A-3 Skywarrior)", Nicknames = null, Notes = null, Number = 66, Version = null, ServiceDate = new DateTime(1954, 12, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "C-1A", Manufacturer = "Grumman", Name = "Trader (See S-2 Tracker, E-1 Tracer)", Nicknames = null, Notes = null, Number = 1, Version = "A", ServiceDate = new DateTime(1954, 2, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "C-2A", Manufacturer = "Grumman", Name = "Greyhound (See E-2 Hawkeye)", Nicknames = null, Notes = null, Number = 2, Version = "A", ServiceDate = new DateTime(1961, 4, 19, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "C-5A", Manufacturer = "Lockheed", Name = "Galaxy", Nicknames = null, Notes = null, Number = 5, Version = "A", ServiceDate = new DateTime(1969, 12, 17, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "C-47", Manufacturer = "Douglas", Name = "Dakota", Nicknames = null, Notes = null, Number = 47, Version = null, ServiceDate = new DateTime(1938, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "C-74", Manufacturer = "Douglas", Name = "Globemaster", Nicknames = null, Notes = null, Number = 74, Version = null, ServiceDate = new DateTime(1950, 5, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "C-97", Manufacturer = "Boeing", Name = "Stratofreighter/Stratotanker", Nicknames = null, Notes = null, Number = 97, Version = null, ServiceDate = new DateTime(1949, 1, 28, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "C-119", Manufacturer = "Fairchild", Name = "Boxcar (See AC-119 Gunship)", Nicknames = null, Notes = null, Number = 119, Version = null, ServiceDate = new DateTime(1949, 12, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "C-130", Manufacturer = "Lockheed", Name = "Hercules", Nicknames = null, Notes = null, Number = 130, Version = null, ServiceDate = new DateTime(1955, 4, 7, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "KC-130", Manufacturer = "Lockheed", Name = "Hercules - Tanker Version", Nicknames = null, Notes = null, Number = 130, Version = null, ServiceDate = new DateTime(1955, 4, 7, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "WC-130", Manufacturer = "Lockheed", Name = "Hercules - Weather Version", Nicknames = null, Notes = null, Number = 130, Version = null, ServiceDate = new DateTime(1955, 4, 7, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "C-133", Manufacturer = "Douglas", Name = "Cargomaster", Nicknames = null, Notes = null, Number = 133, Version = null, ServiceDate = new DateTime(1957, 8, 29, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "C-135", Manufacturer = "Boeing", Name = "Stratolifter", Nicknames = null, Notes = null, Number = 135, Version = null, ServiceDate = new DateTime(1950, 6, 25, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "C-141", Manufacturer = "Lockheed", Name = "Starlifter", Nicknames = null, Notes = null, Number = 141, Version = null, ServiceDate = new DateTime(1964, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "E-1", Manufacturer = "Grumman", Name = "Tracer (See S-2 Tracker, C-1A Trader)", Nicknames = null, Notes = null, Number = 1, Version = null, ServiceDate = new DateTime(1954, 2, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "E-2", Manufacturer = "Grumman", Name = "Hawkeye", Nicknames = null, Notes = null, Number = 2, Version = null, ServiceDate = new DateTime(1961, 4, 19, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "E-3", Manufacturer = "Boeing", Name = "AWACS", Nicknames = null, Notes = null, Number = 3, Version = null, ServiceDate = new DateTime(1976, 2, 20, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-1E", Manufacturer = "North American", Name = "Fury (See AF-1E, FJ-3, FJ-4 Fury)", Nicknames = null, Notes = null, Number = 1, Version = "E", ServiceDate = new DateTime(1953, 7, 3, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F2A", Manufacturer = "Brewster (A)", Name = "Buffalo", Nicknames = null, Notes = null, Number = 2, Version = "A", ServiceDate = new DateTime(1939, 4, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-2", Manufacturer = "McDonnell", Name = "Banshee", Nicknames = null, Notes = null, Number = 2, Version = null, ServiceDate = new DateTime(1949, 3, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-3", Manufacturer = "McDonnell", Name = "Demon", Nicknames = null, Notes = null, Number = 3, Version = null, ServiceDate = new DateTime(1956, 3, 7, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F4B", Manufacturer = "Boeing (B)", Name = "", Nicknames = null, Notes = null, Number = 4, Version = ".B", ServiceDate = new DateTime(1928, 6, 25, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F4D", Manufacturer = "Douglas (D)", Name = "Skyray", Nicknames = null, Notes = null, Number = 4, Version = ".D", ServiceDate = new DateTime(1956, 4, 16, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F4F", Manufacturer = "Grumman (F)", Name = "Wildcat (British Martlet)", Nicknames = null, Notes = null, Number = 4, Version = ".F", ServiceDate = new DateTime(1940, 2, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F4U", Manufacturer = "Vought (U)", Name = "Corsair", Nicknames = null, Notes = null, Number = 4, Version = ".U", ServiceDate = new DateTime(1942, 7, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-4", Manufacturer = "McDonnell Douglas", Name = "Phantom II", Nicknames = null, Notes = null, Number = 4, Version = "A", ServiceDate = new DateTime(1960, 2, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-4B", Manufacturer = "McDonnell Douglas", Name = "Phantom II - First USN Production Model", Nicknames = null, Notes = null, Number = 4, Version = "B", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-4C", Manufacturer = "McDonnell Douglas", Name = "Phantom II - First USAF Production Model", Nicknames = null, Notes = null, Number = 4, Version = "C", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-4D", Manufacturer = "McDonnell Douglas", Name = "Phantom II - Improved USAF \"C\" Version", Nicknames = null, Notes = null, Number = 4, Version = "D", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-4E", Manufacturer = "McDonnell Douglas", Name = "Phantom II - Improved USAF \"D\" Version", Nicknames = null, Notes = null, Number = 4, Version = "E", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-4G", Manufacturer = "McDonnell Douglas", Name = "Phantom II - Radar Suppression Version", Nicknames = null, Notes = null, Number = 4, Version = "G", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-4J", Manufacturer = "McDonnell Douglas", Name = "Phantom II - Improved USN \"B\" Version", Nicknames = null, Notes = null, Number = 4, Version = "J", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-4K", Manufacturer = "McDonnell Douglas", Name = "Phantom II - British Version FG.1", Nicknames = null, Notes = null, Number = 4, Version = "K", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-4N", Manufacturer = "McDonnell Douglas", Name = "Phantom II - Improved USN \"J\" Version", Nicknames = null, Notes = null, Number = 4, Version = "N", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-4S", Manufacturer = "McDonnell Douglas", Name = "Phantom II - Improved USN \"N\" Version", Nicknames = null, Notes = null, Number = 4, Version = "S", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-5", Manufacturer = "Northrop", Name = "Tiger II", Nicknames = null, Notes = null, Number = 5, Version = null, ServiceDate = new DateTime(1959, 4, 10, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-5", Manufacturer = "Martin", Name = "Marlin", Nicknames = null, Notes = null, Number = 5, Version = null, ServiceDate = new DateTime(1951, 12, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F6F", Manufacturer = "Grumman (F)", Name = "Hellcat", Nicknames = null, Notes = null, Number = 6, Version = ".F", ServiceDate = new DateTime(1942, 10, 4, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F4D", Manufacturer = "Douglas (D)", Name = "Skyray", Nicknames = null, Notes = null, Number = 4, Version = ".F", ServiceDate = new DateTime(1956, 4, 16, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F7F", Manufacturer = "Grumman (F)", Name = "Tigercat", Nicknames = null, Notes = null, Number = 7, Version = ".F", ServiceDate = new DateTime(1944, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F7U", Manufacturer = "Vought (U)", Name = "Cutlass", Nicknames = null, Notes = null, Number = 7, Version = ".U", ServiceDate = new DateTime(1954, 6, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F8F", Manufacturer = "Grumman (F)", Name = "Bearcat", Nicknames = null, Notes = null, Number = 8, Version = ".F", ServiceDate = new DateTime(1944, 11, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-8", Manufacturer = "Vought", Name = "Crusader", Nicknames = null, Notes = null, Number = 8, Version = null, ServiceDate = new DateTime(1957, 3, 25, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F9F-1", Manufacturer = "Grumman (F)", Name = "Panther", Nicknames = null, Notes = null, Number = 9, Version = ".F-1", ServiceDate = new DateTime(1948, 11, 24, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F9F-6", Manufacturer = "Grumman (F)", Name = "Cougar", Nicknames = null, Notes = null, Number = 9, Version = ".F-6", ServiceDate = new DateTime(1951, 12, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-10", Manufacturer = "North American", Name = "Mitchell (Reconnaissance) (See B-25)", Nicknames = null, Notes = null, Number = 10, Version = null, ServiceDate = new DateTime(1940, 8, 19, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-11", Manufacturer = "Grumman", Name = "Tiger", Nicknames = null, Notes = null, Number = 11, Version = null, ServiceDate = new DateTime(1957, 3, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-12", Manufacturer = "Boeing", Name = "", Nicknames = null, Notes = null, Number = 12, Version = null, ServiceDate = new DateTime(1928, 6, 25, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-14", Manufacturer = "Grumman", Name = "Tomcat", Nicknames = null, Notes = null, Number = 14, Version = null, ServiceDate = new DateTime(1972, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-15A", Manufacturer = "McDonnell Douglas", Name = "Eagle", Nicknames = null, Notes = null, Number = 15, Version = "A", ServiceDate = new DateTime(1974, 3, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-15C", Manufacturer = "McDonnell Douglas", Name = "Eagle - Advanced Air Superiority Fighter", Nicknames = null, Notes = null, Number = 15, Version = "C", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-15D", Manufacturer = "McDonnell Douglas", Name = "Eagle - Two Seat Trainer", Nicknames = null, Notes = null, Number = 15, Version = "D", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-15E", Manufacturer = "McDonnell Douglas", Name = "Strike Eagle", Nicknames = null, Notes = null, Number = 15, Version = "E", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-15J", Manufacturer = "McDonnell Douglas", Name = "Eagle - Japanese Self Defense Force", Nicknames = null, Notes = null, Number = 15, Version = "J", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-16A", Manufacturer = "General Dynamics", Name = "Fighting Falcon", Nicknames = null, Notes = null, Number = 16, Version = "A", ServiceDate = new DateTime(1978, 6, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-16B", Manufacturer = "General Dynamics", Name = "Falcon - Two Seat Trainer", Nicknames = null, Notes = null, Number = 16, Version = "B", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-16C", Manufacturer = "General Dynamics", Name = "Falcon - w/LANTIRN Night Nav/Targeting", Nicknames = null, Notes = null, Number = 16, Version = "C", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-16D", Manufacturer = "General Dynamics", Name = "Falcon - Improved \"B\" Trainer", Nicknames = null, Notes = null, Number = 16, Version = "D", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-16N", Manufacturer = "General Dynamics", Name = "Falcon - Top Gun Aggressor Version", Nicknames = null, Notes = null, Number = 16, Version = "N", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-16XL", Manufacturer = "General Dynamics", Name = "Cranked Arrow Falcon", Nicknames = null, Notes = null, Number = 16, Version = "XL", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F/A-18A", Manufacturer = "Northrop/McDonnell Douglas", Name = "Hornet", Nicknames = null, Notes = null, Number = 18, Version = "A", ServiceDate = new DateTime(1980, 1, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "TF-18A", Manufacturer = "McDonnell Douglas", Name = "Hornet - U.S. Navy Two Seat Trainer", Nicknames = null, Notes = null, Number = 18, Version = "A", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F/A-18C", Manufacturer = "Northrop/McDonnell Douglas", Name = "Hornet - Improved \"A\" Version", Nicknames = null, Notes = null, Number = 18, Version = "C", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F/A-18D", Manufacturer = "Northrop/McDonnell Douglas", Name = "Hornet - Two Seat Night Attack Version", Nicknames = null, Notes = null, Number = 18, Version = "D", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "RF-18D", Manufacturer = "Northrop/McDonnell Douglas", Name = "Hornet - Two Seat Reconnaissance Version", Nicknames = null, Notes = null, Number = 18, Version = "D", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-26", Manufacturer = "Boeing", Name = null, Nicknames = null, Notes = null, Number = 26, Version = null, ServiceDate = new DateTime(1934, 1, 10, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-38", Manufacturer = "Lockheed", Name = "Lightning", Nicknames = null, Notes = null, Number = 38, Version = null, ServiceDate = new DateTime(1941, 6, 8, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-39", Manufacturer = "Bell", Name = "Airacobra", Nicknames = null, Notes = null, Number = 39, Version = null, ServiceDate = new DateTime(1939, 8, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-40", Manufacturer = "Curtiss", Name = "Hawk (Warhawk, Tomahawk, etc)", Nicknames = null, Notes = null, Number = 40, Version = null, ServiceDate = new DateTime(1940, 1, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-47", Manufacturer = "Republic", Name = "Thunderbolt", Nicknames = null, Notes = null, Number = 47, Version = null, ServiceDate = new DateTime(1942, 3, 18, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-51", Manufacturer = "North American", Name = "Mustang", Nicknames = null, Notes = null, Number = 51, Version = null, ServiceDate = new DateTime(1942, 12, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-59", Manufacturer = "Bell", Name = "Airacomet", Nicknames = null, Notes = null, Number = 59, Version = null, ServiceDate = new DateTime(1944, 8, 7, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-61", Manufacturer = "Northrop", Name = "Black Widow", Nicknames = null, Notes = null, Number = 61, Version = null, ServiceDate = new DateTime(1944, 5, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-70", Manufacturer = "Douglas", Name = "Havoc (Army Night Fighter) (See A-20)", Nicknames = null, Notes = null, Number = 70, Version = null, ServiceDate = new DateTime(1940, 1, 2, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-80", Manufacturer = "Lockheed", Name = "Shooting Star (See F-80, F-94 Starfire)", Nicknames = null, Notes = null, Number = 80, Version = null, ServiceDate = new DateTime(1944, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-82", Manufacturer = "North American", Name = "Twin Mustang (See P-82)", Nicknames = null, Notes = null, Number = 82, Version = null, ServiceDate = new DateTime(1945, 4, 15, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-82", Manufacturer = "North American", Name = "Twin Mustang (See F-82)", Nicknames = null, Notes = null, Number = 82, Version = null, ServiceDate = new DateTime(1945, 4, 15, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-84F", Manufacturer = "Republic", Name = "Thunderstreak", Nicknames = null, Notes = null, Number = 84, Version = "F", ServiceDate = new DateTime(1947, 5, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "RF-84F", Manufacturer = "Republic", Name = "Thunderflash - Reconnaissance Version", Nicknames = null, Notes = null, Number = 84, Version = "F", ServiceDate = new DateTime(1947, 5, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-84", Manufacturer = "Republic", Name = "Thunderjet", Nicknames = null, Notes = null, Number = 84, Version = null, ServiceDate = new DateTime(1947, 5, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-86", Manufacturer = "North American", Name = "Sabre", Nicknames = null, Notes = null, Number = 86, Version = null, ServiceDate = new DateTime(1948, 12, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-89", Manufacturer = "Northrop", Name = "Scorpion", Nicknames = null, Notes = null, Number = 89, Version = null, ServiceDate = new DateTime(1948, 8, 16, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-94", Manufacturer = "Lockheed", Name = "Starfire (See P-80, F-80 Shooting Star)", Nicknames = null, Notes = null, Number = 94, Version = null, ServiceDate = new DateTime(1944, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-100", Manufacturer = "North American", Name = "Super Sabre", Nicknames = null, Notes = null, Number = 100, Version = null, ServiceDate = new DateTime(1953, 10, 29, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-101", Manufacturer = "McDonnell", Name = "Voodoo", Nicknames = null, Notes = null, Number = 101, Version = null, ServiceDate = new DateTime(1957, 5, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "RF-101", Manufacturer = "McDonnell", Name = "Voodoo  - Reconnaissance Version", Nicknames = null, Notes = null, Number = 101, Version = null, ServiceDate = new DateTime(1957, 5, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-102", Manufacturer = "Convair", Name = "Delta Dagger", Nicknames = null, Notes = null, Number = 102, Version = null, ServiceDate = new DateTime(1955, 11, 8, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-104", Manufacturer = "Lockheed", Name = "Starfighter", Nicknames = null, Notes = null, Number = 104, Version = null, ServiceDate = new DateTime(1956, 2, 17, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-105", Manufacturer = "Republic", Name = "Thunderchief", Nicknames = null, Notes = null, Number = 105, Version = null, ServiceDate = new DateTime(1955, 10, 22, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-106", Manufacturer = "Convair", Name = "Delta Dart", Nicknames = null, Notes = null, Number = 106, Version = null, ServiceDate = new DateTime(1959, 7, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-111A", Manufacturer = "General Dynamics", Name = "Aardvark", Nicknames = null, Notes = null, Number = 111, Version = "A", ServiceDate = new DateTime(1967, 6, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-111B", Manufacturer = "General Dynamics", Name = "U.S. Navy TFX Prototype (Cancelled)", Nicknames = null, Notes = null, Number = 111, Version = "B", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-111C", Manufacturer = "General Dynamics", Name = "Aardvark - \"A\" Version w/longer wing", Nicknames = null, Notes = null, Number = 111, Version = "C", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-111D", Manufacturer = "General Dynamics", Name = "Aardvark - Improved Intakes", Nicknames = null, Notes = null, Number = 111, Version = "D", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-111E", Manufacturer = "General Dynamics", Name = "Aardvark - \"Triple Plow II\" Intakes", Nicknames = null, Notes = null, Number = 111, Version = "E", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "F-111F", Manufacturer = "General Dynamics", Name = "Aardvark - Improved Intakes", Nicknames = null, Notes = null, Number = 111, Version = "F", ServiceDate = new DateTime(1900, 01, 01, 00, 00, 00), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "FB-111A", Manufacturer = "General Dynamics", Name = "Aardvark - Fighter Bomber Version", Nicknames = null, Notes = null, Number = 111, Version = "FB-A", ServiceDate = new DateTime(1967, 6, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "FJ-3", Manufacturer = "North American", Name = "Fury (See F-1E, AF-1E, FJ-4 Fury)", Nicknames = null, Notes = null, Number = null, Version = "J-3", ServiceDate = new DateTime(1953, 7, 3, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "FJ-4", Manufacturer = "North American", Name = "Fury (See AF-1E, F-1E, FJ-3 Fury)", Nicknames = null, Notes = null, Number = null, Version = "J-4", ServiceDate = new DateTime(1954, 10, 28, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "OV-1", Manufacturer = "Grumman", Name = "Mohawk", Nicknames = null, Notes = null, Number = 1, Version = null, ServiceDate = new DateTime(1961, 2, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "OV-10", Manufacturer = "Rockwell", Name = "Bronco", Nicknames = null, Notes = null, Number = 10, Version = null, ServiceDate = new DateTime(1967, 8, 6, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "PB4Y-2", Manufacturer = "Consolidated", Name = "Privateer", Nicknames = null, Notes = null, Number = 4, Version = "Y-2", ServiceDate = new DateTime(1944, 7, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "PBM", Manufacturer = "Martin", Name = "Mariner", Nicknames = null, Notes = null, Number = null, Version = "M", ServiceDate = new DateTime(1940, 9, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "PBY-1", Manufacturer = "Consolidated", Name = "Catalina", Nicknames = null, Notes = null, Number = null, Version = "Y-1", ServiceDate = new DateTime(1936, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "PBY-5", Manufacturer = "Consolidated", Name = "Catalina", Nicknames = null, Notes = null, Number = null, Version = "Y-5", ServiceDate = new DateTime(1936, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "U-2", Manufacturer = "Lockheed", Name = null, Nicknames = null, Notes = null, Number = 2, Version = null, ServiceDate = new DateTime(1956, 4, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "SR-71", Manufacturer = "Lockheed", Name = "Blackbird (USAF)", Nicknames = null, Notes = null, Number = 71, Version = null, ServiceDate = new DateTime(1964, 12, 22, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-2", Manufacturer = "Lockheed", Name = "Neptune", Nicknames = null, Notes = null, Number = 2, Version = null, ServiceDate = new DateTime(1947, 3, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "S-2", Manufacturer = "Grumman", Name = "Tracker (See E-1 Tracer, C-1A Trader)", Nicknames = null, Notes = null, Number = 2, Version = null, ServiceDate = new DateTime(1954, 2, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "P-3", Manufacturer = "Lockheed", Name = "Orion", Nicknames = null, Notes = null, Number = 3, Version = null, ServiceDate = new DateTime(1961, 4, 15, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "S-3", Manufacturer = "Lockheed", Name = "Viking", Nicknames = null, Notes = null, Number = 3, Version = null, ServiceDate = new DateTime(1973, 10, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "KC-135", Manufacturer = "Boeing", Name = "Stratotanker", Nicknames = null, Notes = null, Number = 135, Version = null, ServiceDate = new DateTime(1950, 6, 25, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "TBD-1", Manufacturer = "Douglas (D)", Name = "Devastator", Nicknames = null, Notes = null, Number = null, Version = "D-1", ServiceDate = new DateTime(1937, 6, 25, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "TBF", Manufacturer = "Grumman (F)", Name = "Avenger", Nicknames = null, Notes = null, Number = null, Version = "F", ServiceDate = new DateTime(1942, 1, 30, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "TBM", Manufacturer = "Eastern Motors/GM (M)", Name = "Avenger", Nicknames = null, Notes = null, Number = null, Version = "M", ServiceDate = new DateTime(1942, 1, 30, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new AircraftDesignation { ID = Guid.NewGuid(), Designation = "AD2", Manufacturer = "Douglas", Name = "Skyshark", Nicknames = null, Notes = null, Number = null, Version = null, ServiceDate = new DateTime(1950, 1, 1, 0, 0, 0), DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) });
        }
        private static void SeedBlueAngelsHistory(TCContext context)
        {
            Console.WriteLine("\tBlueAngelsHistory");
            //SELECT 'new BlueAngelsHistory { ID = Guid.NewGuid(), ' +
            //    'ServiceDates = "' +[Dates] + '", ' +
            //    'AircraftType = "' +[Aircraft Type] + '", ' +
            //    'DecalSets = ' + IsNull('"' +[Decal Sets] + '"', 'null') + ', ' +
            //    'Kits = ' + IsNull('"' +[Kits] + '"', 'null') + ', ' +
            //    'Notes = ' + IsNull('"' +[Notes] + '"', 'null') + ', ' +
            //    'DateCreated = new DateTime(' + Convert(varchar(4), Year([DateCreated]))+',' + Convert(varchar(2), Month([DateCreated]))+',' + Convert(varchar(2), Day([DateCreated]))+',' + Convert(varchar(2), DatePart(hh,[DateCreated])) + ',' + Convert(varchar(2), DatePart(mi,[DateCreated])) + ',' + Convert(varchar(2), DatePart(ss,[DateCreated])) + '), ' +
            //          'DateModified = new DateTime(' + Convert(varchar(4), Year([DateModified]))+',' + Convert(varchar(2), Month([DateModified]))+',' + Convert(varchar(2), Day([DateModified]))+',' + Convert(varchar(2), DatePart(hh,[DateModified])) + ',' + Convert(varchar(2), DatePart(mi,[DateModified])) + ',' + Convert(varchar(2), DatePart(ss,[DateModified])) + ') },'
            //FROM [dbo].[Blue Angels History];
            context.BlueAngelsHistories.AddOrUpdate(x => x.AircraftType,
                new BlueAngelsHistory { ID = Guid.NewGuid(), ServiceDates = "1946", AircraftType = "F6F-5 Grumman Hellcat", DecalSets = "72-217", Kits = null, Notes = null, DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new BlueAngelsHistory { ID = Guid.NewGuid(), ServiceDates = "1946-49", AircraftType = "F8F-1 Grumman Bearcat", DecalSets = "72-642", Kits = "Monogram (Germany) MG6789", Notes = null, DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new BlueAngelsHistory { ID = Guid.NewGuid(), ServiceDates = "1949-50", AircraftType = "F9F-2 Grumman Panther", DecalSets = "N/A", Kits = "Hasegawa HA-D11", Notes = null, DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new BlueAngelsHistory { ID = Guid.NewGuid(), ServiceDates = "1952", AircraftType = "F7U-1 Vought Cutlass (Solo Only)", DecalSets = "N/A", Kits = "Testers", Notes = null, DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new BlueAngelsHistory { ID = Guid.NewGuid(), ServiceDates = "1952-54", AircraftType = "F9F-5 Grumman Panther", DecalSets = "N/A", Kits = "matchbox PK-124", Notes = null, DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new BlueAngelsHistory { ID = Guid.NewGuid(), ServiceDates = "1955-57", AircraftType = "F9F-8 Grumman Cougar", DecalSets = "N/A", Kits = "Hasegawa HA-D12", Notes = null, DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new BlueAngelsHistory { ID = Guid.NewGuid(), ServiceDates = "1957-61", AircraftType = "F11F-1 Grumman Tiger", DecalSets = "N/A", Kits = "Hasegawa HA-D16", Notes = null, DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new BlueAngelsHistory { ID = Guid.NewGuid(), ServiceDates = "1969-73", AircraftType = "F-4J McDonnell Douglas Phantom II", DecalSets = "N/A", Kits = "Hasegawa HA-SP51", Notes = null, DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new BlueAngelsHistory { ID = Guid.NewGuid(), ServiceDates = "1974-86", AircraftType = "A-4F McDonnell Douglas Skyhawk", DecalSets = "72-138", Kits = "Fujimi FU-G19", Notes = null, DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) },
                new BlueAngelsHistory { ID = Guid.NewGuid(), ServiceDates = "1987-", AircraftType = "F/A-18A Northrop Hornet", DecalSets = "72-560", Kits = "Hasegawa HA-812", Notes = null, DateCreated = new DateTime(1900, 1, 1, 0, 0, 0), DateModified = new DateTime(1900, 1, 1, 0, 0, 0) });
        }
        private static void SeedLocations(TCContext context)
        {
            Console.WriteLine("\tLocations");
            //Select Distinct 
            // 'new Location { ID = Guid.NewGuid(), ' +
            //    'Name = ' + IsNull('@"' +[tcLocations].[Location] + '"', '""') + ', ' +
            //    'Description = @"", ' +
            //    'PhysicalLocation = @"", ' +
            //    'OName = ' + IsNull('@"' +[tcLocations].[Location] + '"', '""') + ' },'
            //From [GGGSCP1].[TreasureChest].[dbo].[Locations]
            //        [tcLocations]
            //Order By 1;
            context.Locations.AddOrUpdate(x => x.Name,
                new Location { ID = Guid.NewGuid(), Name = "", Description = @"", PhysicalLocation = @"", OName = "" },
                new Location { ID = Guid.NewGuid(), Name = @"?? Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"?? Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"@ Large", Description = @"", PhysicalLocation = @"", OName = @"@ Large" },
                //new Location { ID = Guid.NewGuid(), Name = @"\\Foxtrot\Public\Shared Videos\Music Videos\Styx", Description = @"", PhysicalLocation = @"", OName = @"\\Foxtrot\Public\Shared Videos\Music Videos\Styx" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Action", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Action" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Adventure", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Adventure" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Cartoon-CG", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Cartoon-CG" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Christmas", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Christmas" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Comedy", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Comedy" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Documentary", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Documentary" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Drama", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Drama" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Fantasy", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Fantasy" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Horror", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Horror" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Musical", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Musical" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Mystery", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Mystery" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Science Fiction", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Science Fiction" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Sports", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Sports" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\War", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\War" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Charlie\Public\Shared Movies\Western", Description = @"", PhysicalLocation = @"", OName = @"\\Charlie\Public\Shared Movies\Western" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Delta\Public\Shared TV\Animation", Description = @"", PhysicalLocation = @"", OName = @"\\Delta\Public\Shared TV\Animation" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Delta\Public\Shared TV\Comedy", Description = @"", PhysicalLocation = @"", OName = @"\\Delta\Public\Shared TV\Comedy" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Delta\Public\Shared TV\Drama", Description = @"", PhysicalLocation = @"", OName = @"\\Delta\Public\Shared TV\Drama" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Delta\Public\Shared TV\SciFi", Description = @"", PhysicalLocation = @"", OName = @"\\Delta\Public\Shared TV\SciFi" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Delta\Public\Shared TV\War", Description = @"", PhysicalLocation = @"", OName = @"\\Delta\Public\Shared TV\War" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Delta\Public\Shared TV\Western", Description = @"", PhysicalLocation = @"", OName = @"\\Delta\Public\Shared TV\Western" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Echo\Public\Shared TV\Animation", Description = @"", PhysicalLocation = @"", OName = @"\\Echo\Public\Shared TV\Animation" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Echo\Public\Shared TV\Comedy", Description = @"", PhysicalLocation = @"", OName = @"\\Echo\Public\Shared TV\Comedy" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Echo\Public\Shared TV\Documentary", Description = @"", PhysicalLocation = @"", OName = @"\\Echo\Public\Shared TV\Documentary" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Echo\Public\Shared TV\Documentary\NFL Films", Description = @"", PhysicalLocation = @"", OName = @"\\Echo\Public\Shared TV\Documentary\NFL Films" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Echo\Public\Shared TV\Drama", Description = @"", PhysicalLocation = @"", OName = @"\\Echo\Public\Shared TV\Drama" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Echo\Public\Shared TV\SciFi", Description = @"", PhysicalLocation = @"", OName = @"\\Echo\Public\Shared TV\SciFi" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Echo\Public\Shared TV\War", Description = @"", PhysicalLocation = @"", OName = @"\\Echo\Public\Shared TV\War" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Foxtrot\Public\Shared TV\Horror", Description = @"", PhysicalLocation = @"", OName = @"\\Foxtrot\Public\Shared TV\Horror" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Foxtrot\Public\Shared TV\SciFi", Description = @"", PhysicalLocation = @"", OName = @"\\Foxtrot\Public\Shared TV\SciFi" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Foxtrot\Public\Shared Videos\Exercise", Description = @"", PhysicalLocation = @"", OName = @"\\Foxtrot\Public\Shared Videos\Exercise" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Foxtrot\Public\Shared Videos\Music Videos", Description = @"", PhysicalLocation = @"", OName = @"\\Foxtrot\Public\Shared Videos\Music Videos" },
                new Location { ID = Guid.NewGuid(), Name = @"\\Foxtrot\Public\Shared\Videos\Music Videos", Description = @"", PhysicalLocation = @"", OName = @"\\Foxtrot\Public\Shared\Videos\Music Videos" },
                new Location { ID = Guid.NewGuid(), Name = @"Apple Software Box", Description = @"", PhysicalLocation = @"", OName = @"Apple Software Box" },
                new Location { ID = Guid.NewGuid(), Name = @"Applied", Description = @"", PhysicalLocation = @"", OName = @"Applied" },
                new Location { ID = Guid.NewGuid(), Name = @"Art Books Box #7", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Art Books Box #7 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Attic", Description = @"", PhysicalLocation = @"", OName = @"Attic" },
                new Location { ID = Guid.NewGuid(), Name = @"Aurora USS Enterprise Box", Description = @"", PhysicalLocation = @"Attic", OName = @"Aurora USS Enterprise Box [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Axis&Allies War at Sea - Allies Case", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Axis&Allies War at Sea - Allies Case" },
                new Location { ID = Guid.NewGuid(), Name = @"Axis&Allies War at Sea - Axis Case", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Axis&Allies War at Sea - Axis Case" },
                new Location { ID = Guid.NewGuid(), Name = @"Axis&Allies War at Sea Condition Zebra Case", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Axis&Allies War at Sea Condition Zebra Case" },
                new Location { ID = Guid.NewGuid(), Name = @"Axis&Allies War at Sea Flank Speed Case", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Axis&Allies War at Sea Flank Speed Case" },
                new Location { ID = Guid.NewGuid(), Name = @"Axis&Allies War at Sea Fleet Command Case", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Axis&Allies War at Sea Fleet Command Case" },
                new Location { ID = Guid.NewGuid(), Name = @"Axis&Allies War at Sea Surface Action Case", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Axis&Allies War at Sea Surface Action Case" },
                new Location { ID = Guid.NewGuid(), Name = @"Axis&Allies War at Sea Task Force - Allies Case", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Axis&Allies War at Sea Task Force - Allies Case" },
                new Location { ID = Guid.NewGuid(), Name = @"Axis&Allies War at Sea Task Force - Axis Case", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Axis&Allies War at Sea Task Force - Axis Case" },
                new Location { ID = Guid.NewGuid(), Name = @"Baseball Cards Box #1", Description = @"ESSS", PhysicalLocation = @"Closet", OName = @"Baseball Cards Box #1 (ESSS) [Closet]" },
                new Location { ID = Guid.NewGuid(), Name = @"Basement Toolbox", Description = @"", PhysicalLocation = @"", OName = @"Basement Toolbox" },
                new Location { ID = Guid.NewGuid(), Name = @"Basement Workbench", Description = @"", PhysicalLocation = @"", OName = @"Basement Workbench" },
                new Location { ID = Guid.NewGuid(), Name = @"Basement", Description = @"", PhysicalLocation = @"", OName = @"Basement" },
                new Location { ID = Guid.NewGuid(), Name = @"Battlestar Galactica Raptor Armament Set", Description = @"", PhysicalLocation = @"", OName = @"Battlestar Galactica Raptor Armament Set" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase #1", Description = @"", PhysicalLocation = @"Carol's Room - East Wall (Atop)", OName = @"Bookcase #1 (Atop) [Carol's Room - East Wall]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase #1", Description = @"", PhysicalLocation = @"Carol's Room - East Wall (Second Shelf Shelf)", OName = @"Bookcase #1 (Second Shelf Shelf) [Carol's Room - East Wall]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase #1", Description = @"", PhysicalLocation = @"Carol's Room - East Wall (Third Shelf Shelf)", OName = @"Bookcase #1 (Third Shelf Shelf) [Carol's Room - East Wall]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase #1", Description = @"", PhysicalLocation = @"Carol's Room - East Wall (Top Shelf)", OName = @"Bookcase #1 (Top Shelf) [Carol's Room - East Wall]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase A", Description = @"", PhysicalLocation = @"Ken's Room - West Wall By Door (Bottom Shelf)", OName = @"Bookcase A (Bottom Shelf) [Ken's Room - West Wall By Door]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase A", Description = @"", PhysicalLocation = @"Ken's Room - West Wall By Door (Second Shelf)", OName = @"Bookcase A (Second Shelf) [Ken's Room - West Wall By Door]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase A", Description = @"", PhysicalLocation = @"Ken's Room - West Wall By Door (Third Shelf)", OName = @"Bookcase A (Third Shelf) [Ken's Room - West Wall By Door]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase A", Description = @"", PhysicalLocation = @"Ken's Room - West Wall By Door (Top Shelf)", OName = @"Bookcase A (Top Shelf) [Ken's Room - West Wall By Door]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase B", Description = @"", PhysicalLocation = @"Ken's Room - West Wall Back (Bottom Shelf)", OName = @"Bookcase B (Bottom Shelf) [Ken's Room - West Wall Back]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase B", Description = @"", PhysicalLocation = @"Ken's Room - West Wall Back (Second Shelf)", OName = @"Bookcase B (Second Shelf) [Ken's Room - West Wall Back]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase B", Description = @"", PhysicalLocation = @"Ken's Room - West Wall Back (Third Shelf)", OName = @"Bookcase B (Third Shelf) [Ken's Room - West Wall Back]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase B", Description = @"", PhysicalLocation = @"Ken's Room - West Wall Back (Top Shelf)", OName = @"Bookcase B (Top Shelf) [Ken's Room - West Wall Back]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase C", Description = @"", PhysicalLocation = @"Ken's Room - West Wall By Closet (Bottom Shelf)", OName = @"Bookcase C (Bottom Shelf) [Ken's Room - West Wall By Closet]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase C", Description = @"", PhysicalLocation = @"Ken's Room - West Wall By Closet (Second Shelf)", OName = @"Bookcase C (Second Shelf) [Ken's Room - West Wall By Closet]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase C", Description = @"", PhysicalLocation = @"Ken's Room - West Wall By Closet (Third Shelf)", OName = @"Bookcase C (Third Shelf) [Ken's Room - West Wall By Closet]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase C", Description = @"", PhysicalLocation = @"Ken's Room - West Wall By Closet (Top Shelf)", OName = @"Bookcase C (Top Shelf) [Ken's Room - West Wall By Closet]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase F", Description = @"", PhysicalLocation = @"Ken's Room - Front Wall (Second Shelf)", OName = @"Bookcase F (Second Shelf) [Ken's Room - Front Wall]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookcase F", Description = @"", PhysicalLocation = @"Ken's Room - Front Wall (Top Shelf)", OName = @"Bookcase F (Top Shelf) [Ken's Room - Front Wall]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookshelf", Description = @"", PhysicalLocation = @"Ken's Room - Back Wall (Bottom Shelf)", OName = @"Bookshelf (Bottom Shelf) [Ken's Room - Back Wall]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookshelf", Description = @"", PhysicalLocation = @"Ken's Room - East Wall (Bottom Shelf)", OName = @"Bookshelf (Bottom Shelf) [Ken's Room - East Wall]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookshelf", Description = @"", PhysicalLocation = @"Ken's Room - Back Wall (Top Shelf)", OName = @"Bookshelf (Top Shelf) [Ken's Room - Back Wall]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookshelf", Description = @"", PhysicalLocation = @"Ken's Room - East Wall (Top Shelf)", OName = @"Bookshelf (Top Shelf) [Ken's Room - East Wall]" },
                new Location { ID = Guid.NewGuid(), Name = @"Bookshelf", Description = @"", PhysicalLocation = @"", OName = @"Bookshelf" },
                new Location { ID = Guid.NewGuid(), Name = @"Borrowed", Description = @"", PhysicalLocation = @"", OName = @"Borrowed" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #? Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #? Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #144-1", Description = @"UHS-Old", PhysicalLocation = @"Attic", OName = @"Box #144-1 (UHS-Old) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #144-1 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #144-1 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #144-2", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Box #144-2 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #144-2 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #144-2 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #3 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #3 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #350-1", Description = @"UHL", PhysicalLocation = @"Attic", OName = @"Box #350-1 (UHL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #350-1 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #350-1 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #350-2", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Box #350-2 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #350-2 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #350-2 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #700-1", Description = @"UHM-Old", PhysicalLocation = @"Attic", OName = @"Box #700-1 (UHM-Old) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #700-1 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #700-1 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #700-2", Description = @"UHL", PhysicalLocation = @"Attic", OName = @"Box #700-2 (UHL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #700-2 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #700-2 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #700-2 Ziploc bag\par", Description = @"", PhysicalLocation = @"", OName = @"Box #700-2 Ziploc bag\par" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #700-3", Description = @"UHXL", PhysicalLocation = @"Attic", OName = @"Box #700-3 (UHXL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #700-3 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #700-3 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #700-4", Description = @"Unmarked 15x12x8", PhysicalLocation = @"Attic", OName = @"Box #700-4 (Unmarked 15x12x8) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #700-4 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #700-4 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-01", Description = @"UHM", PhysicalLocation = @"Attic", OName = @"Box #72-01 (UHM) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-02", Description = @"UHM-Old", PhysicalLocation = @"Attic", OName = @"Box #72-02 (UHM-Old) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-03", Description = @"UHM", PhysicalLocation = @"Attic", OName = @"Box #72-03 (UHM) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-04", Description = @"UHM", PhysicalLocation = @"Attic", OName = @"Box #72-04 (UHM) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-05", Description = @"UHM", PhysicalLocation = @"Attic", OName = @"Box #72-05 (UHM) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-06", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Box #72-06 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-07", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Box #72-07 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-08", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Box #72-08 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-09", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Box #72-09 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-1 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-1 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-10", Description = @"UHM", PhysicalLocation = @"Attic", OName = @"Box #72-10 (UHM) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-10 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-10 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-11", Description = @"UHL-Old", PhysicalLocation = @"Attic", OName = @"Box #72-11 (UHL-Old) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-11", Description = @"UHXL-Old", PhysicalLocation = @"Attic", OName = @"Box #72-11 (UHXL-Old) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-11 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-11 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-12", Description = @"UHXL", PhysicalLocation = @"Attic", OName = @"Box #72-12 (UHXL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-12 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-12 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-13", Description = @"UHM-Old", PhysicalLocation = @"Attic", OName = @"Box #72-13 (UHM-Old) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-13 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-13 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-14", Description = @"UHM", PhysicalLocation = @"Attic", OName = @"Box #72-14 (UHM) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-14 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-14 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-2 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-2 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-4 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-4 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-5 Ziploc bag (2nd set, with wheels, left in box)", Description = @"", PhysicalLocation = @"", OName = @"Box #72-5 Ziploc bag (2nd set, with wheels, left in box)" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-5 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-5 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-6 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-6 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-7 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-7 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-8 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-8 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #72-9 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Box #72-9 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #TB-1", Description = @"", PhysicalLocation = @"", OName = @"Box #TB-1" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #TB-2", Description = @"", PhysicalLocation = @"", OName = @"Box #TB-2" },
                new Location { ID = Guid.NewGuid(), Name = @"Box #TB-3", Description = @"", PhysicalLocation = @"", OName = @"Box #TB-3" },
                new Location { ID = Guid.NewGuid(), Name = @"C200809.1", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"C200809.1 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"C200809.2", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"C200809.2 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"C200809.3", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"C200809.3 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"C200810.1", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"C200810.1 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"C200810.2", Description = @"UHS", PhysicalLocation = @"Ken's Room", OName = @"C200810.2 (UHS) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Car Box #1 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"Car Box #1 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Car Collectables Box #01", Description = @"UHM", PhysicalLocation = @"Attic", OName = @"Car Collectables Box #01 (UHM) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Car Models Box #1", Description = @"UHXL", PhysicalLocation = @"Attic", OName = @"Car Models Box #1 (UHXL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Carol's Books HB Fiction", Description = @"", PhysicalLocation = @"", OName = @"Carol's Books HB Fiction" },
                new Location { ID = Guid.NewGuid(), Name = @"Carol's Office", Description = @"", PhysicalLocation = @"", OName = @"Carol's Office" },
                new Location { ID = Guid.NewGuid(), Name = @"Carol's Room", Description = @"", PhysicalLocation = @"", OName = @"Carol's Room" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Box #1", Description = @"UHS", PhysicalLocation = @"Ken's Room", OName = @"CD Box #1 (UHS) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Box #2", Description = @"UHS", PhysicalLocation = @"Ken's Room", OName = @"CD Box #2 (UHS) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Box #3", Description = @"ESS", PhysicalLocation = @"Ken's Room", OName = @"CD Box #3 (ESSS) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Box #4", Description = @"ESS", PhysicalLocation = @"Ken's Room", OName = @"CD Box #4 (ESSS) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Box #5", Description = @"UHS", PhysicalLocation = @"Ken's Room", OName = @"CD Box #5 (UHS) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Box #6", Description = @"33250", PhysicalLocation = @"Basement", OName = @"CD Box #6 (33250) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Box #7", Description = @"33250", PhysicalLocation = @"Basement", OName = @"CD Box #7 (33250) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Box #8", Description = @"33250", PhysicalLocation = @"Basement", OName = @"CD Box #8 (33250) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Rack - Arcade", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"CD Rack - Arcade [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Rack - Flight Sims", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"CD Rack - Flight Sims [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Rack - FPS", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"CD Rack - FPS [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Rack - RPG/Strategy", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"CD Rack - RPG/Strategy [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Rack - Star Trek/Space Sim", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"CD Rack - Star Trek/Space Sim [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Rack - Star Wars", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"CD Rack - Star Wars [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Rack - Strategy (C&C)", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"CD Rack - Strategy (C&C) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Rack - Strategy (Civilization)", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"CD Rack - Strategy (Civilization) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Rack", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"CD Rack [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"CD Rack", Description = @"", PhysicalLocation = @"", OName = @"CD Rack" },
                new Location { ID = Guid.NewGuid(), Name = @"Christmas CDs", Description = @"", PhysicalLocation = @"", OName = @"Christmas CDs" },
                new Location { ID = Guid.NewGuid(), Name = @"Christmas DVDs", Description = @"", PhysicalLocation = @"", OName = @"Christmas DVDs" },
                new Location { ID = Guid.NewGuid(), Name = @"Closet", Description = @"", PhysicalLocation = @"", OName = @"Closet" },
                new Location { ID = Guid.NewGuid(), Name = @"Combat Aircraft 2012-2014", Description = @"", PhysicalLocation = @"Top of Steps", OName = @"Combat Aircraft 2012-2014 [Top of Steps]" },
                new Location { ID = Guid.NewGuid(), Name = @"Combat Aircraft 2015-2018", Description = @"", PhysicalLocation = @"Top of Steps", OName = @"Combat Aircraft 2015-2018 [Top of Steps]" },
                new Location { ID = Guid.NewGuid(), Name = @"Computer Books Box #01", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Computer Books Box #01 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Computer Books Box #02", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Computer Books Box #02 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Computer Books Box #03", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Computer Books Box #03 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"CS20101219.1", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"CS20101219.1 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"CS20101219.2", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"CS20101219.2 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Decals left in bag", Description = @"", PhysicalLocation = @"", OName = @"Decals left in bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Decals left with detail set included in kit", Description = @"", PhysicalLocation = @"", OName = @"Decals left with detail set included in kit" },
                new Location { ID = Guid.NewGuid(), Name = @"Decals salvaged", Description = @"", PhysicalLocation = @"", OName = @"Decals salvaged" },
                new Location { ID = Guid.NewGuid(), Name = @"Desk", Description = @"", PhysicalLocation = @"", OName = @"Desk" },
                new Location { ID = Guid.NewGuid(), Name = @"Destroyed", Description = @"", PhysicalLocation = @"", OName = @"Destroyed" },
                new Location { ID = Guid.NewGuid(), Name = @"Detail Sets Box", Description = @"18x13x11", PhysicalLocation = @"Ken's Room", OName = @"Detail Sets Box (18x13x11) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Die Cast Collectables Box #1", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Die Cast Collectables Box #1 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Digital Download", Description = @"", PhysicalLocation = @"", OName = @"Digital Download" },
                new Location { ID = Guid.NewGuid(), Name = @"Dining Room", Description = @"", PhysicalLocation = @"", OName = @"Dining Room" },
                new Location { ID = Guid.NewGuid(), Name = @"Donated", Description = @"", PhysicalLocation = @"", OName = @"Donated" },
                new Location { ID = Guid.NewGuid(), Name = @"Doorway PB Stack", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Doorway PB Stack [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #02 - Waiting for WMV", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"DVD Box #02 (UHS) [Attic] - Waiting for WMV" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #02", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"DVD Box #02 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #03 - Waiting for WMV", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"DVD Box #03 (UHS) [Attic] - Waiting for WMV" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #03", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"DVD Box #03 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #05", Description = @"#03325", PhysicalLocation = @"Basement", OName = @"DVD Box #05 (#03325) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #06", Description = @"33250", PhysicalLocation = @"Basement", OName = @"DVD Box #06 (33250) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #07", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"DVD Box #07 [UHS Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #08", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"DVD Box #08 [UHS Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #09", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"DVD Box #09 [UHS Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #10", Description = @"33250", PhysicalLocation = @"Basement", OName = @"DVD Box #10 (33250) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #11", Description = @"33250", PhysicalLocation = @"Basement", OName = @"DVD Box #11 (33250) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #12", Description = @"33250", PhysicalLocation = @"Basement", OName = @"DVD Box #12 (33250) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #13", Description = @"33250", PhysicalLocation = @"Basement", OName = @"DVD Box #13 (33250) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #14", Description = @"33250", PhysicalLocation = @"Basement", OName = @"DVD Box #14 (33250) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #15", Description = @"33250", PhysicalLocation = @"Basement", OName = @"DVD Box #15 (33250) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #16", Description = @"33250", PhysicalLocation = @"Attic", OName = @"DVD Box #16 (33250) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #17", Description = @"33250", PhysicalLocation = @"Attic", OName = @"DVD Box #17 (33250) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #18", Description = @"33250", PhysicalLocation = @"Attic", OName = @"DVD Box #18 (33250) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #19", Description = @"33250", PhysicalLocation = @"Attic", OName = @"DVD Box #19 (33250) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #20 - Waiting for WMV", Description = @"33250", PhysicalLocation = @"Ken's Room", OName = @"DVD Box #20 (33250) [Ken's Room] - Waiting for WMV" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #20", Description = @"33250", PhysicalLocation = @"Ken's Room", OName = @"DVD Box #20 (33250) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #21", Description = @"33250", PhysicalLocation = @"Attic", OName = @"DVD Box #21 (33250) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #22", Description = @"33250", PhysicalLocation = @"Attic", OName = @"DVD Box #22 (33250) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #23", Description = @"33250", PhysicalLocation = @"Ken's Room", OName = @"DVD Box #23 (33250) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVD Box #24", Description = @"33250", PhysicalLocation = @"Ken's Room", OName = @"DVD Box #24 (33250) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVDs - General", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"DVDs - General [UHS Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVDs - General Box #1", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"DVDs - General Box #1 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVDs - General Box #2", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"DVDs - General Box #2 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"DVDs - General Box #2", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"DVDs - General Box #2 [UHS Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Entertainment Center Shelf", Description = @"", PhysicalLocation = @"", OName = @"Entertainment Center Shelf" },
                new Location { ID = Guid.NewGuid(), Name = @"Ether", Description = @"", PhysicalLocation = @"", OName = @"Ether" },
                new Location { ID = Guid.NewGuid(), Name = @"Federation Box #1", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Federation Box #1 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Fiction Books Box #2", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Fiction Books Box #2 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Fiction Books Box #3", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Fiction Books Box #3 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Fiction Books Box #6", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Fiction Books Box #6 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Fiction Books Box #8", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Fiction Books Box #8 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"File Entry", Description = @"", PhysicalLocation = @"", OName = @"File Entry" },
                new Location { ID = Guid.NewGuid(), Name = @"Football Cards Box #1", Description = @"ESSS", PhysicalLocation = @"Closet", OName = @"Football Cards Box #1 (ESSS) [Closet]" },
                new Location { ID = Guid.NewGuid(), Name = @"Forbidden Planet Box", Description = @"Unmarked 20x14x7", PhysicalLocation = @"Ken's Room", OName = @"Forbidden Planet Box (Unmarked 20x14x7) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"FreeTime Box #1", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"FreeTime Box #1 (Ken's Room)" },
                new Location { ID = Guid.NewGuid(), Name = @"FreeTime Box #2", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"FreeTime Box #2 (Ken's Room)" },
                new Location { ID = Guid.NewGuid(), Name = @"FreeTime Box #2", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"FreeTime Box #2 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"FreeTime Box #3", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"FreeTime Box #3 (Ken's Room)" },
                new Location { ID = Guid.NewGuid(), Name = @"FreeTime Box #3", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"FreeTime Box #3 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"FreeTime Box #4", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"FreeTime Box #4 (Ken's Room)" },
                new Location { ID = Guid.NewGuid(), Name = @"FreeTime Box #5", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"FreeTime Box #5 (Ken's Room)" },
                new Location { ID = Guid.NewGuid(), Name = @"FreeTime Box #5", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"FreeTime Box #5 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"HALO Box #1", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"HALO Box #1 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"History Books Box #10", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"History Books Box #10 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"History Books From Ken's Desk", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"History Books From Ken's Desk (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Cases #01", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Hot Cases #01 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Cases #02", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Hot Cases #02 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Cases #03", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Hot Cases #03 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Cases #04", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Hot Cases #04 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Cases #05", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Hot Cases #05 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Cases #06", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Hot Cases #06 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Cases #07", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Hot Cases #07 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Cases #08", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Hot Cases #08 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Cases #09", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Hot Cases #09 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels 48 Car Case #01", Description = @"", PhysicalLocation = @"Car Collectables Box #01", OName = @"Hot Wheels 48 Car Case #01 [Car Collectables Box #01]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels 48 Car Case #02", Description = @"", PhysicalLocation = @"Car Collectables Box #01", OName = @"Hot Wheels 48 Car Case #02 [Car Collectables Box #01]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #01", Description = @"", PhysicalLocation = @"", OName = @"Hot Wheels Box #01" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #02", Description = @"Amazon 12x9x6", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #02 (Amazon 12x9x6) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #03", Description = @"ESS", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #03 (ESSS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #04", Description = @"ESS", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #04 (ESSS) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #05", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #05 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #06", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #06 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #07", Description = @"Unmarked 14x12x6", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #07 (Unmarked 14x12x6) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #08", Description = @"B&N 13x11x6", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #08 (B&N 13x11x6) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #09", Description = @"Unmarked 12x9x6", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #09 (Unmarked 12x9x6) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #10", Description = @"Mattel L2593 Case", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #10 (Mattel L2593 Case) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #11", Description = @"Unmarked 16x12.5x6", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #11 (Unmarked 16x12.5x6) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #12", Description = @"Unmarked 13x11x5", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #12 (Unmarked 13x11x5) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #13", Description = @"Mattel L2593 Case", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #13 (Mattel L2593 Case) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #14", Description = @"Unmarked 14x10x6", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #14 (Unmarked 14x10x6) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #15", Description = @"Unmarked 10x8x6", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #15 (Unmarked 10x8x6) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #16", Description = @"Mattel BDT77 Case", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #16 (Mattel BDT77 Case) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #17", Description = @"Mattel X8893 Case", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #17 (Mattel X8893 Case) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #18", Description = @"Unmarked 14x12x6", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #18 (Unmarked 14x12x6) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #19", Description = @"Mattel X8308 Case", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #19 (Mattel X8308 Case) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #20", Description = @"Unmarked 18x10x4", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #20 (Unmarked 18x10x4) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2014A", Description = @"FantasyFlight", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #2014A (FantasyFlight) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2014B", Description = @"Amazon K3", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #2014B (Amazon K3) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2014C", Description = @"Unmarked 16x12.5x6", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #2014C (Unmarked 16x12.5x6) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2014D", Description = @"Unmarked 11x8x6", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #2014D (Unmarked 11x8x6) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2016A", Description = @"Amazon 1AE", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #2016A (Amazon 1AE) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2016B", Description = @"Amazon 1AE", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #2016B (Amazon 1AE) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2016C", Description = @"Amazon 1AE", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #2016C (Amazon 1AE) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2017A", Description = @"Unmarked 14x14x9", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #2017A (Unmarked 14x14x9) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2017B", Description = @"Unmarked 17x13x6", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #2017B (Unmarked 17x13x6) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2017C", Description = @"Unmarked 16x8x7", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #2017C (Unmarked 16x8x7) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2018A", Description = @"Mattel L2593 Case", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #2018A (Mattel L2593 Case) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2018B", Description = @"Amazon 1A5", PhysicalLocation = @"Basement", OName = @"Hot Wheels Box #2018B (Amazon 1A5) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2018C", Description = @"Unmarked 16x12x8", PhysicalLocation = @"Basement", OName = @"Hot Wheels Box #2018C (Unmarked 16x12x8) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #2018D", Description = @"Unmarked 16x8x6", PhysicalLocation = @"Basement", OName = @"Hot Wheels Box #2018D (Unmarked 16x8x6) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #21", Description = @"Unmarked 13x9x5.25", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #21 (Unmarked 13x9x5.25) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #22", Description = @"Mattel L2593 Case", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #22 (Mattel L2593 Case) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #23", Description = @"Unmarked 16x12x8", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #23 (Unmarked 16x12x8) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #24", Description = @"USPS Priority Mail Medium", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #24 (USPS Priority Mail Medium) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #25", Description = @"Unmarked 16x12x12", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #25 (Unmarked 16x12x12) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #26", Description = @"Amazon 1A7", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #26 (Amazon 1A7) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #27", Description = @"B&N.com 14x11x6", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #27 (B&N.com 14x11x6) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #28", Description = @"Unmarked Priority Mail 16x12x4", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #28 (Unmarked Priority Mail 16x12x4) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #29", Description = @"Unmarked 14x14x6.5", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #29 (Unmarked 14x14x6.5) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #30", Description = @"Unmarked 14.5x11x6.5", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #30 (Unmarked 14.5x11x6.5) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #31", Description = @"Unmarked 14x10.5x7", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #31 (Unmarked 14x10.5x7) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #32", Description = @"Unmarked Priority Mail 14x10x6", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #32 (Unmarked Priority Mail 14x10x6) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #33", Description = @"Amazon 1B4", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #33 (Amazon 1B4) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #34", Description = @"Mattel MD28", PhysicalLocation = @"Basement", OName = @"Hot Wheels Box #34 (Mattel MD28) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #Retro 13D", Description = @"Mattel BDT77 Case", PhysicalLocation = @"Attic", OName = @"Hot Wheels Box #Retro 13D (Mattel BDT77 Case) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #Retro13", Description = @"Squadron 18x12x6", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #Retro13 (Squadron 18x12x6) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #Retro13B", Description = @"Mattel X8893", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #Retro13B (Mattel X8893) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Box #Retro13C", Description = @"Mattel X8893", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Box #Retro13C (Mattel X8893) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Pop Culture - Peanuts Box", Description = @"DLB45", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Pop Culture - Peanuts Box (DLB45) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Pop Culture - Star Wars McQuarrie Box", Description = @"DLB45", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Pop Culture - Star Wars McQuarrie Box (DLB45) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Sizzlers Box #01", Description = @"", PhysicalLocation = @"Attic", OName = @"Hot Wheels Sizzlers Box #01 [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Star Wars Carships Box #1", Description = @"Unmarked 14x14x8.5", PhysicalLocation = @"Ken's Room", OName = @"Hot Wheels Star Wars Carships Box #1 (Unmarked 14x14x8.5) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Star Wars Carships Box #2", Description = @"Mattel FBB72 Case", PhysicalLocation = @"Attic", OName = @"Hot Wheels Star Wars Carships Box #2 (Mattel FBB72 Case) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Hot Wheels Star Wars C-Cars Box #1", Description = @"Unmarked 20x20x6.5", PhysicalLocation = @"Attic", OName = @"Hot Wheels Star Wars C-Cars Box #1 (Unmarked 20x20x6.5) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Husky Supplies Organizer #1", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Husky Supplies Organizer #1 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Husky Tools Organizer #1", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Husky Tools Organizer #1 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Included in kit", Description = @"", PhysicalLocation = @"", OName = @"Included in kit" },
                new Location { ID = Guid.NewGuid(), Name = @"Inside E-2C Hawkeye Box (Revell 03945 Kit #2640)", Description = @"", PhysicalLocation = @"", OName = @"Inside E-2C Hawkeye Box (Revell 03945 Kit #2640)" },
                new Location { ID = Guid.NewGuid(), Name = @"Inside Kit Box (Revell 03945 Kit #2640)", Description = @"", PhysicalLocation = @"", OName = @"Inside Kit Box (Revell 03945 Kit #2640)" },
                new Location { ID = Guid.NewGuid(), Name = @"Inside Kit Box (Revell 04882 Kit #2619)", Description = @"", PhysicalLocation = @"", OName = @"Inside Kit Box (Revell 04882 Kit #2619)" },
                new Location { ID = Guid.NewGuid(), Name = @"Inside Kit Box (Trumpeter 05711 Kit #2731)", Description = @"", PhysicalLocation = @"", OName = @"Inside Kit Box (Trumpeter 05711 Kit #2731)" },
                new Location { ID = Guid.NewGuid(), Name = @"Inside Kit Box (Trumpeter 05712 Kit #2732)", Description = @"", PhysicalLocation = @"", OName = @"Inside Kit Box (Trumpeter 05712 Kit #2732)" },
                new Location { ID = Guid.NewGuid(), Name = @"Inside Kit Box", Description = @"", PhysicalLocation = @"", OName = @"Inside Kit Box" },
                new Location { ID = Guid.NewGuid(), Name = @"Installed", Description = @"", PhysicalLocation = @"", OName = @"Installed" },
                new Location { ID = Guid.NewGuid(), Name = @"JVC CH-200 Box Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"JVC CH-200 Box Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"JVC CH-X200 Box", Description = @"", PhysicalLocation = @"Attic", OName = @"JVC CH-X200 Box [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #01", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #01 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #02", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #02 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #03", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #03 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #04", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #04 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #05", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #05 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #06", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #06 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #07", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #07 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #08", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #08 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #09", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #09 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #10", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #10 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #11", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #11 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #12", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #12 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #13", Description = @"", PhysicalLocation = @"Basement", OName = @"Ken's Books Box #13 [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Books Box #14 - Modeling Resources", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Ken's Books Box #14 - Modeling Resources [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Desk", Description = @"", PhysicalLocation = @"", OName = @"Ken's Desk" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's DVDs Box #1", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Ken's DVDs Box #1 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's DVDs Box #2", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Ken's DVDs Box #2 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's DVDs Box #3", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Ken's DVDs Box #3 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's DVDs Box #4", Description = @"", PhysicalLocation = @"Attic", OName = @"Ken's DVDs Box #4 [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Hallmark Ornaments Box", Description = @"UHS", PhysicalLocation = @"Ken's Room", OName = @"Ken's Hallmark Ornaments Box (UHS) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Ken's Room", Description = @"", PhysicalLocation = @"", OName = @"Ken's Room" },
                new Location { ID = Guid.NewGuid(), Name = @"Key Publishing Specials Box", Description = @"", PhysicalLocation = @"Top of Steps", OName = @"Key Publishing Specials Box [Top of Steps]" },
                new Location { ID = Guid.NewGuid(), Name = @"Kindle", Description = @"", PhysicalLocation = @"", OName = @"Kindle" },
                new Location { ID = Guid.NewGuid(), Name = @"Left in bag", Description = @"", PhysicalLocation = @"", OName = @"Left in bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Left in box", Description = @"", PhysicalLocation = @"", OName = @"Left in box" },
                new Location { ID = Guid.NewGuid(), Name = @"Living Room", Description = @"", PhysicalLocation = @"", OName = @"Living Room" },
                new Location { ID = Guid.NewGuid(), Name = @"Lost", Description = @"", PhysicalLocation = @"", OName = @"Lost" },
                new Location { ID = Guid.NewGuid(), Name = @"M&M's Chocolate M-PIRE Box", Description = @"USPS #13 9x7x4", PhysicalLocation = @"Ken's Room", OName = @"M&M's Chocolate M-PIRE Box (USPS #13 9x7x4) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"M&M's Chocolate M-PIRE Box", Description = @"USPS #13 9x7x4", PhysicalLocation = @"", OName = @"M&M's Chocolate M-PIRE Box [USPS #13 9x7x4]" },
                new Location { ID = Guid.NewGuid(), Name = @"Master Bedroom", Description = @"", PhysicalLocation = @"", OName = @"Master Bedroom" },
                new Location { ID = Guid.NewGuid(), Name = @"MH201110.1", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"MH201110.1 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"MH201110.2", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"MH201110.2 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"MH201110.3", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"MH201110.3 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"MH201110.4", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"MH201110.4 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"MH201110.5", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"MH201110.5 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"MH201110.6", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"MH201110.6 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Micro Machines - Titanium  Series Box #01", Description = @"ESS", PhysicalLocation = @"Attic", OName = @"Micro Machines - Titanium  Series Box #01 (ESSS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Micro Machines - Titanium  Series Box #02", Description = @"ESS", PhysicalLocation = @"Attic", OName = @"Micro Machines - Titanium  Series Box #02 (ESSS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Micro Machines - Titanium  Series Box #03", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Micro Machines - Titanium  Series Box #03 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Micro Machines - Titanium  Series Box #04", Description = @"ESS", PhysicalLocation = @"Attic", OName = @"Micro Machines - Titanium  Series Box #04 (ESSS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Micro Machines - Titanium  Series Box #05", Description = @"ESS", PhysicalLocation = @"Attic", OName = @"Micro Machines - Titanium  Series Box #05 (ESSS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Micro Machines - Titanium  Series Box #06", Description = @"ESS", PhysicalLocation = @"Attic", OName = @"Micro Machines - Titanium  Series Box #06 (ESSS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Micro Machines - Titanium  Series Box #06", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Micro Machines - Titanium  Series Box #06 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Micro Machines - Titanium  Series Box #07", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Micro Machines - Titanium  Series Box #07 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Micro Machines - Titanium  Series Box #08", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Micro Machines - Titanium  Series Box #08 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Micro Machines - Titanium  Series Box #09", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Micro Machines - Titanium  Series Box #09 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Micro Machines - Titanium  Series Box #10 (BSG) (SMO)", Description = @"", PhysicalLocation = @"Attic", OName = @"Micro Machines - Titanium  Series Box #10 (BSG) (SMO) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Misc Books Box #01", Description = @"", PhysicalLocation = @"", OName = @"Misc Books Box #01" },
                new Location { ID = Guid.NewGuid(), Name = @"Misc Collectables Box #1", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Misc Collectables Box #1 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Models #1", Description = @"UHM", PhysicalLocation = @"Attic", OName = @"Models #1 (UHM) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Models #2", Description = @"UHM", PhysicalLocation = @"Attic", OName = @"Models #2 (UHM) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Music DVDs Box #1", Description = @"33250", PhysicalLocation = @"Ken's Room", OName = @"Music DVDs Box #1 (33250) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Nappa Valley Crate #1", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Nappa Valley Crate #1 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Nappa Valley Crate #2", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Nappa Valley Crate #2 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Nappa Valley Crate #3", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Nappa Valley Crate #3 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Office", Description = @"", PhysicalLocation = @"", OName = @"Office" },
                new Location { ID = Guid.NewGuid(), Name = @"On Order", Description = @"", PhysicalLocation = @"", OName = @"On Order" },
                new Location { ID = Guid.NewGuid(), Name = @"Part of Compilaton", Description = @"", PhysicalLocation = @"", OName = @"Part of Compilaton" },
                new Location { ID = Guid.NewGuid(), Name = @"PB201110.1", Description = @"UHB", PhysicalLocation = @"Basement", OName = @"PB201110.1 (UHB) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"PB201110.2", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"PB201110.2 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"PB201110.3", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"PB201110.3 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"PB201111.4", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"PB201111.4 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"PC Games Box #1", Description = @"", PhysicalLocation = @"Closet", OName = @"PC Games Box #1 [Closet]" },
                new Location { ID = Guid.NewGuid(), Name = @"PC Games Box #2", Description = @"", PhysicalLocation = @"Closet", OName = @"PC Games Box #2 [Closet]" },
                new Location { ID = Guid.NewGuid(), Name = @"PC Games Box #3", Description = @"", PhysicalLocation = @"Closet", OName = @"PC Games Box #3 [Closet]" },
                new Location { ID = Guid.NewGuid(), Name = @"PC Games Box #4", Description = @"", PhysicalLocation = @"Closet", OName = @"PC Games Box #4 [Closet]" },
                new Location { ID = Guid.NewGuid(), Name = @"PC Games Box #4", Description = @"", PhysicalLocation = @"", OName = @"PC Games Box #4" },
                new Location { ID = Guid.NewGuid(), Name = @"Pre-Ordered", Description = @"", PhysicalLocation = @"", OName = @"Pre-Ordered" },
                new Location { ID = Guid.NewGuid(), Name = @"Prize Box", Description = @"", PhysicalLocation = @"", OName = @"Prize Box" },
                new Location { ID = Guid.NewGuid(), Name = @"Public Music\Books", Description = @"", PhysicalLocation = @"", OName = @"Public Music\Books" },
                new Location { ID = Guid.NewGuid(), Name = @"Public Music\Christmas", Description = @"", PhysicalLocation = @"", OName = @"Public Music\Christmas" },
                new Location { ID = Guid.NewGuid(), Name = @"Public Music\Classical", Description = @"", PhysicalLocation = @"", OName = @"Public Music\Classical" },
                new Location { ID = Guid.NewGuid(), Name = @"Public Music\Comedy", Description = @"", PhysicalLocation = @"", OName = @"Public Music\Comedy" },
                new Location { ID = Guid.NewGuid(), Name = @"Public Music\Country", Description = @"", PhysicalLocation = @"", OName = @"Public Music\Country" },
                new Location { ID = Guid.NewGuid(), Name = @"Public Music\New Age", Description = @"", PhysicalLocation = @"", OName = @"Public Music\New Age" },
                new Location { ID = Guid.NewGuid(), Name = @"Public Music\Pop", Description = @"", PhysicalLocation = @"", OName = @"Public Music\Pop" },
                new Location { ID = Guid.NewGuid(), Name = @"Public Music\Radio Shows", Description = @"", PhysicalLocation = @"", OName = @"Public Music\Radio Shows" },
                new Location { ID = Guid.NewGuid(), Name = @"Public Music\Rock", Description = @"", PhysicalLocation = @"", OName = @"Public Music\Rock" },
                new Location { ID = Guid.NewGuid(), Name = @"Public Music\Soundtrack", Description = @"", PhysicalLocation = @"", OName = @"Public Music\Soundtrack" },
                new Location { ID = Guid.NewGuid(), Name = @"Ready to install", Description = @"", PhysicalLocation = @"", OName = @"Ready to install" },
                new Location { ID = Guid.NewGuid(), Name = @"Scheduled for Donation", Description = @"", PhysicalLocation = @"", OName = @"Scheduled for Donation" },
                new Location { ID = Guid.NewGuid(), Name = @"Science Books Box #14", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Science Books Box #14 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Sci-Fi Books Box #1", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Sci-Fi Books Box #1 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Sci-Fi Books Box #2", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Sci-Fi Books Box #2 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Sci-Fi Books Box #3", Description = @"UHB", PhysicalLocation = @"Basement", OName = @"Sci-Fi Books Box #3 (UHB) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Sci-Fi Books Box #4", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Sci-Fi Books Box #4 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #1", Description = @"UHM", PhysicalLocation = @"Attic", OName = @"SciFi Box #1 (UHM) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #1 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"SciFi Box #1 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #2", Description = @"UHL", PhysicalLocation = @"Attic", OName = @"SciFi Box #2 (UHL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #2 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"SciFi Box #2 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #3", Description = @"UHL", PhysicalLocation = @"Attic", OName = @"SciFi Box #3 (UHL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #3 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"SciFi Box #3 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #4", Description = @"UHXL", PhysicalLocation = @"Attic", OName = @"SciFi Box #4 (UHXL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #4 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"SciFi Box #4 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #5", Description = @"UHXL", PhysicalLocation = @"Attic", OName = @"SciFi Box #5 (UHXL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #5 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"SciFi Box #5 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #6", Description = @"UHXL", PhysicalLocation = @"Attic", OName = @"SciFi Box #6 (UHXL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #6 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"SciFi Box #6 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #7", Description = @"UHXL", PhysicalLocation = @"Attic", OName = @"SciFi Box #7 (UHXL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"SciFi Box #7 Ziploc bag", Description = @"", PhysicalLocation = @"", OName = @"SciFi Box #7 Ziploc bag" },
                new Location { ID = Guid.NewGuid(), Name = @"Sealed in package", Description = @"", PhysicalLocation = @"", OName = @"Sealed in package" },
                new Location { ID = Guid.NewGuid(), Name = @"Sealed with detail set included in kit", Description = @"", PhysicalLocation = @"", OName = @"Sealed with detail set included in kit" },
                new Location { ID = Guid.NewGuid(), Name = @"Spares", Description = @"", PhysicalLocation = @"", OName = @"Spares" },
                new Location { ID = Guid.NewGuid(), Name = @"Sports Books Box #15", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Sports Books Box #15 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Trek Attack Wing Case #01", Description = @"Plano 993179", PhysicalLocation = @"Ken's Room", OName = @"Star Trek Attack Wing Case #01 [Plano 993179]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Trek Attack Wing Case #02", Description = @"Plano 993179", PhysicalLocation = @"Ken's Room", OName = @"Star Trek Attack Wing Case #02 [Plano 993179]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Armada Box", Description = @"Unmarked 18x14x10", PhysicalLocation = @"Ken's Room", OName = @"Star Wars Armada Box (Unmarked 18x14x10) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Collectables Box #2", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Star Wars Collectables Box #2 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Collectables Box #3", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Star Wars Collectables Box #3 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Collectables Box #4", Description = @"UHM", PhysicalLocation = @"Attic", OName = @"Star Wars Collectables Box #4 (UHM) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Collectables Box #5", Description = @"UHM", PhysicalLocation = @"Attic", OName = @"Star Wars Collectables Box #5 (UHM) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Collectables Box #6", Description = @"EE 18x12x12", PhysicalLocation = @"Attic", OName = @"Star Wars Collectables Box #6 (EE 18x12x12) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Collectables Box #7", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Star Wars Collectables Box #7 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Collectables Box #8", Description = @"UHS", PhysicalLocation = @"Attic", OName = @"Star Wars Collectables Box #8 (UHS) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Collectables Box #9", Description = @"UHS", PhysicalLocation = @"Ken's Room", OName = @"Star Wars Collectables Box #9 (UHS) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Collectables Box", Description = @"UHXL", PhysicalLocation = @"Attic", OName = @"Star Wars Collectables Box (UHXL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Sterilite Flip-Top Box", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Star Wars Sterilite Flip-Top Box [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Vehicles Box #1", Description = @"UHXL", PhysicalLocation = @"Attic", OName = @"Star Wars Vehicles Box #1 (UHXL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Vehicles Box #2", Description = @"UHXL", PhysicalLocation = @"Attic", OName = @"Star Wars Vehicles Box #2 (UHXL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars Vehicles Box #3", Description = @"UHXL", PhysicalLocation = @"Attic", OName = @"Star Wars Vehicles Box #3 (UHXL) [Attic]" },
                new Location { ID = Guid.NewGuid(), Name = @"Star Wars X-Wing Box", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Star Wars X-Wing Box [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Starfighter Shipyards Box #1", Description = @"", PhysicalLocation = @"", OName = @"Starfighter Shipyards Box #1" },
                new Location { ID = Guid.NewGuid(), Name = @"Sterilite Flip-Top Box #1", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Sterilite Flip-Top Box #1 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Sterilite Flip-Top Box #2", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Sterilite Flip-Top Box #2 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Sterilite Flip-Top Box #3", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Sterilite Flip-Top Box #3 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Sterilite Flip-Top Box #4", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Sterilite Flip-Top Box #4 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Sterilite Flip-Top Box #5", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Sterilite Flip-Top Box #5 [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Text Books Box #16", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Text Books Box #16 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"TimeLife Books Box #1", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"TimeLife Books Box #1 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"TimeLife Books Box #2", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"TimeLife Books Box #2 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"TimeLife Books Box #3", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"TimeLife Books Box #3 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Tom Clancy Book Box #9", Description = @"UHS", PhysicalLocation = @"Basement", OName = @"Tom Clancy Book Box #9 (UHS) [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Topps 2006 Football #1", Description = @"Football Cards Box #1 (ESSS)", PhysicalLocation = @"Closet", OName = @"Topps 2006 Football #1 [Football Cards Box #1 (ESSS) [Closet]]" },
                new Location { ID = Guid.NewGuid(), Name = @"Topps 2006 Football #2", Description = @"Football Cards Box #1 (ESSS)", PhysicalLocation = @"Closet", OName = @"Topps 2006 Football #2 [Football Cards Box #1 (ESSS) [Closet]]" },
                new Location { ID = Guid.NewGuid(), Name = @"Topps 2006 Football #3", Description = @"Football Cards Box #1 (ESSS)", PhysicalLocation = @"Closet", OName = @"Topps 2006 Football #3 [Football Cards Box #1 (ESSS) [Closet]]" },
                new Location { ID = Guid.NewGuid(), Name = @"Topps 2007 Football Complete Set Box", Description = @"Football Cards Box #1 (ESSS)", PhysicalLocation = @"Closet", OName = @"Topps 2007 Football Complete Set Box [Football Cards Box #1 (ESSS) [Closet]]" },
                new Location { ID = Guid.NewGuid(), Name = @"Topps 2008 Football #1", Description = @"Football Cards Box #1 (ESSS)", PhysicalLocation = @"Closet", OName = @"Topps 2008 Football #1 [Football Cards Box #1 (ESSS) [Closet]]" },
                new Location { ID = Guid.NewGuid(), Name = @"Topps 2008 Football Complete Set Box", Description = @"Football Cards Box #1 (ESSS)", PhysicalLocation = @"Closet", OName = @"Topps 2008 Football Complete Set Box [Football Cards Box #1 (ESSS) [Closet]]" },
                new Location { ID = Guid.NewGuid(), Name = @"Topps Cowboys Box #01", Description = @"Football Cards Box #1 (ESSS)", PhysicalLocation = @"Closet", OName = @"Topps Cowboys Box #01 [Football Cards Box #1 (ESSS) [Closet]]" },
                new Location { ID = Guid.NewGuid(), Name = @"Train Stuff", Description = @"", PhysicalLocation = @"", OName = @"Train Stuff" },
                new Location { ID = Guid.NewGuid(), Name = @"Transition", Description = @"", PhysicalLocation = @"", OName = @"Transition" },
                new Location { ID = Guid.NewGuid(), Name = @"Unboxed", Description = @"", PhysicalLocation = @"Basement", OName = @"Unboxed [Basement]" },
                new Location { ID = Guid.NewGuid(), Name = @"Unboxed", Description = @"", PhysicalLocation = @"Carol's Room", OName = @"Unboxed [Carol's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Unboxed", Description = @"", PhysicalLocation = @"Ken's Room - Near Front Wall", OName = @"Unboxed [Ken's Room - Near Front Wall]" },
                new Location { ID = Guid.NewGuid(), Name = @"Unboxed", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Unboxed [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Unboxed Atop Bookcase A", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Unboxed Atop Bookcase A [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Unboxed Atop Bookcase B", Description = @"", PhysicalLocation = @"Ken's Room", OName = @"Unboxed Atop Bookcase B [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Undecided (Carol)", Description = @"", PhysicalLocation = @"", OName = @"Undecided (Carol)" },
                new Location { ID = Guid.NewGuid(), Name = @"Unknown - Possible Duplicate", Description = @"", PhysicalLocation = @"", OName = @"Unknown - Possible Duplicate" },
                new Location { ID = Guid.NewGuid(), Name = @"Unknown", Description = @"", PhysicalLocation = @"", OName = @"Unknown" },
                new Location { ID = Guid.NewGuid(), Name = @"Unspecified", Description = @"", PhysicalLocation = @"", OName = @"Unspecified" },
                new Location { ID = Guid.NewGuid(), Name = @"Web Access", Description = @"", PhysicalLocation = @"", OName = @"Web Access" },
                new Location { ID = Guid.NewGuid(), Name = @"Wire Rack", Description = @"", PhysicalLocation = @"Ken's Room East Wall (Top Shelf)", OName = @"Wire Rack (Top Shelf) [Ken's Room East Wall]" },
                new Location { ID = Guid.NewGuid(), Name = @"Work Books 20080910.1", Description = @"UHS", PhysicalLocation = @"Ken's Room", OName = @"Work Books 20080910.1 (UHS) [Ken's Room]" },
                new Location { ID = Guid.NewGuid(), Name = @"Workbench", Description = @"", PhysicalLocation = @"", OName = @"Workbench" },

                new Location { ID = Guid.NewGuid(), Name = @"Canceled", Description = @"", PhysicalLocation = @"", OName = @"Canceled" },
                new Location { ID = Guid.NewGuid(), Name = @"EB Games.com", Description = @"", PhysicalLocation = @"", OName = @"EB Games.com" },
                new Location { ID = Guid.NewGuid(), Name = @"Self-Compiled", Description = @"", PhysicalLocation = @"", OName = @"Self-Compiled" },
                new Location { ID = Guid.NewGuid(), Name = @"Topps 2006 Football #1", Description = @"", PhysicalLocation = @"", OName = @"Topps 2006 Football #1" },
                new Location { ID = Guid.NewGuid(), Name = @"Undetermined", Description = @"", PhysicalLocation = @"", OName = @"Undetermined" },
                new Location { ID = Guid.NewGuid(), Name = @"WishList", Description = @"", PhysicalLocation = @"", OName = @"WishList" }
            );
        }
        private static void SeedMusic(TCContext context)
        {
            Console.WriteLine("\tMusic");
            //TODO: For some reason the following indexes are not being created as they should.
            //                .Index(t => new { t.Type, t.Artist, t.Year, t.MediaFormat, t.ID }, unique: true, name: "IX_MusicByType")
            //                .Index(t => new { t.Artist, t.Year, t.MediaFormat, t.ID }, unique: true, name: "IX_MusicByArtist")
            //                .Index(t => new { t.MediaFormat, t.Artist, t.Year, t.ID }, unique: true, name: "IX_MusicByFormat")
            //                .Index(t => new { t.AlphaSort, t.MediaFormat, t.ID }, unique: true, name: "IX_MusicByAlphaSort")

            //INSERT INTO[dbo].[Music](
            //     [Artist],[AlphaSort],[MediaFormat],[Title],[Type],[Year],[Cataloged],[DateInventoried],[DatePurchased],[DateVerified],
            //     [LocationID],[Notes],[Price],[Value],[WishList],[DateCreated],[DateModified],[OID])
            //Select
            //     [Artist],[AlphaSort],[Media] As[MediaFormat],[Title],[Type],[Year],1,[DateInventoried],[DatePurchased],[DateVerified],
            //     [Locations].[ID],[Notes],[Price],[Value],[WishList],[tcMusic].[DateCreated],[tcMusic].[DateModified],[tcMusic].[ID]
            //From [GGGSCP1].[TreasureChest].[dbo].[Music] [tcMusic]
            //     Inner Join[Locations] On[Locations].[OName]=[tcMusic].[Location]
            //Order By [AlphaSort];

            //TODO: 
            //INSERT INTO [dbo].[Images](
            //    [Name],[Image],[FileName],[URL],[Height],[Width],[Category],[AlphaSort],[TableName],[RecordID],
            //    [Thumbnail],[ThumbnailImage],[Caption],[Notes],[DateCreated],[DateModified],[OID])
            //Select
            //    SUBSTRING([tcMusic].[Artist]+' - '+[tcMusic].[Title]+' Cover',1,80) As [Name],
            //    [Image],null,null,0,0,null,[AlphaSort],'Music',[Music].[ID],
            //    0,null,[tcMusic].[Artist]+' - '+[tcMusic].[Title]+' Cover' As [Caption],
            //    null,[tcMusic].[DateCreated],[tcMusic].[DateModified],[tcMusic].[ID]
            //From [GGGSCP1].[TreasureChest].[dbo].[Music] [tcMusic]
            //    Inner Join [Music] On [Music].[OID]=[tcMusic].[ID]
            //Union
            //Select
            //    SUBSTRING([tcMusic].[Artist]+' - '+[tcMusic].[Title]+' Back',1,80) As [Name],
            //    [OtherImage],null,null,0,0,null,[AlphaSort],'Music',[Music].[ID],
            //    0,null,[tcMusic].[Artist]+' - '+[tcMusic].[Title]+' Back' As [Caption],
            //    null,[tcMusic].[DateCreated],[tcMusic].[DateModified],[tcMusic].[ID]
            //From [GGGSCP1].[TreasureChest].[dbo].[Music] [tcMusic]
            //    Inner Join [Music] On [Music].[OID]=[tcMusic].[ID]
            //Order By [tcMusic].[AlphaSort];
        }
        private static void SeedShipClassTypes(TCContext context)
        {
            Console.WriteLine("\tShipClassTypes");
            context.ShipClassTypes.AddOrUpdate(x => x.TypeCode,
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "XXX", Description = "Unassigned" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "ACR", Description = "Heavy Armored Cruiser - Battleship prototype" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "AD", Description = "Destroyer Tenders" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "AE", Description = "Ammunition Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "AG", Description = "Oceanographic Research Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "AGF", Description = "Miscellaneous Command Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "AGSS", Description = "Auxiliary Research Submarines" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "AO", Description = "Oilers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "AOE", Description = "Fast Combat Support Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "AOR", Description = "Replenishment Oilers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "APD", Description = "High Speed Transports" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "ARS", Description = "Salvage Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "AS", Description = "Submarine Tenders" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "ATS", Description = "Salvage and Rescue Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "BB", Description = "Battleships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "CA", Description = "Heavy (Gun) Cruisers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "CAG", Description = "Guided Missile Heavy Cruisers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "CB", Description = "Large Cruisers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "CG", Description = "Guided Missile Cruisers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "CGN", Description = "Guided Missile Cruisers (Nuclear)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "CL", Description = "Light (Gun) Cruisers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "CLC", Description = "Command Cruisers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "CLG", Description = "Light Guided Missile Cruisers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "CV", Description = "Multi-Purpose (Fleet) Aircraft Carriers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "CVE", Description = "Escort Carriers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "CVL", Description = "Light Carriers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "CVN", Description = "Multi-Purpose Aircraft Carriers (Nuclear)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "DD", Description = "Destroyers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "DDG", Description = "Guided Missile Destroyers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "DE", Description = "Destroyer Escorts" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "DL", Description = "Post World War II Frigates" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "DLG", Description = "Guided Missile Frigate (post WWII)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "FF", Description = "Frigates" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "FFG", Description = "Guided Missile Frigates" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "IX", Description = "Unclassified Miscellaneous Units" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "LCC", Description = "Amphibious Command Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "LCS", Description = "Littoral Combat Ship" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "LHA", Description = "Amphibious Assault Ships (general purpose)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "LHD", Description = "Amphibious Assault Ships (multi-purpose)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "LKA", Description = "Amphibious Cargo Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "LPD", Description = "Amphibious Transport docks" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "LPH", Description = "Amphibious Assault Ships (Helicopter)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "LSD", Description = "Dock Landing Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "LST", Description = "Tank Landing Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "MCM", Description = "Mine Countermeasures Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "MCS", Description = "Mine Countermeasures Support Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "MHC", Description = "Minehunters, Coastal" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "MSO", Description = "Ocean Minesweepers" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "PC", Description = "Patrol Craft" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "PG", Description = "Patrol Gunboats" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "PHM", Description = "Patrol Combatants - Missile (Hydrofoil)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "SS", Description = "Submarines" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "SSBN", Description = "Ballistic Missile Submarines (Nuclear)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "SSN", Description = "Submarines (Nuclear)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "SST", Description = "Training Submarines" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "T-AE", Description = "Ammunition Ships (assigned to Military Sealift Command)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "T-AFS", Description = "Combat Store Ships (assigned to Military Sealift Command)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "T-AG", Description = "Oceanographic Research Ships" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "T-AO", Description = "Oilers (assigned to Military Sealift Command)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "T-AOE", Description = "Fast Combat Support Ships (assigned to Military Sealift Command)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "T-ARS", Description = "Salvage Ships (assigned to Military Sealift Command)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "T-AS", Description = "Submarine Tenders (assigned to Military Sealift Command)" },
                new ShipClassType { ID = Guid.NewGuid(), TypeCode = "T-LKA", Description = "Amphibious Cargo Ships (assigned to Military Sealift Command)" });
        }
        #endregion
        #region Programmability
        private static void CreateLogElapsed(TCContext context)
        {
            Console.WriteLine("\tLogElapsed");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_LogElapsed' AND type='P') Drop Procedure sp_LogElapsed;");
            context.Database.ExecuteSqlCommand(@"
            --sp_LogElapsed.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    06/06/19    Ken Clark        Created;
            --=================================================================================================================================
            
                Create Procedure sp_LogElapsed(@Milestone nvarchar(max),@StartTime datetime,@Message nvarchar(max)=null) As
                Begin
                    Declare @FinishTime datetime=CURRENT_TIMESTAMP;
                    If (@Message is null) Set @Message='Elapsed: '+Convert(nvarchar(24),CURRENT_TIMESTAMP-@StartTime,114);
                    Print @Message;
                    Insert Into Log(MileStone,StartTime,FinishTime,Message) Values (@Milestone,@StartTime,@FinishTime,@Message);
                End;");
        }
        private static void CreateLogError(TCContext context)
        {
            Console.WriteLine("\tLogError");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_LogError' AND type='P') Drop Procedure sp_LogError;");
            context.Database.ExecuteSqlCommand(@"
            --sp_LogError.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    06/06/19    Ken Clark        Created;
            --=================================================================================================================================
            
                Create Procedure sp_LogError(@Milestone nvarchar(max)) As
                Begin
                    Declare @Message nvarchar(max), @Number int, @Severity int, @State int, @Line int, @Procedure nvarchar(max);
                    Select @Number=ERROR_NUMBER(),
                        @Message=ERROR_MESSAGE(),
                        @Severity=ERROR_SEVERITY(),
                        @State=ERROR_STATE(),
                        @Line=ERROR_LINE(),
                        @Procedure=ERROR_PROCEDURE();
                    Declare @Error nvarchar(max)=
                        'Error '+Convert(nvarchar(10),@Number)+', '+
                        'Level '+Convert(nvarchar(10),@Severity)+', '+
                        'State '+Convert(nvarchar(10),@State)+', '+
                        'Procedure '+@Procedure+', '+
                        'Line '+Convert(nvarchar(10),@Line)+', '+CHAR(13)+CHAR(10)+
                        @Message;
                    Begin Transaction;
                    exec sp_LogMessage @Milestone, @Error;
                    Commit Transaction;
                End;");
        }
        private static void CreateLogMessage(TCContext context)
        {
            Console.WriteLine("\tLogMessage");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_LogMessage' AND type='P') Drop Procedure sp_LogMessage;");
            context.Database.ExecuteSqlCommand(@"
            --sp_LogMessage.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    06/06/19    Ken Clark        Created;
            --=================================================================================================================================
            
                Create Procedure sp_LogMessage(@Milestone nvarchar(max),@Message nvarchar(max)) As
                Begin
                    Print @Message;
                    Insert Into Log(MileStone,Message) Values (@Milestone,@Message); 
                End;");
        }
        private static void CreateMusicViews(TCContext context)
        {
            Console.WriteLine("\tMusic");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='Music' AND type='V') Drop View Music;");
            context.Database.ExecuteSqlCommand(@"
                    Create View [dbo].[Music] As 
                    Select M.[ID], M.[Artist], M.[Title], M.[Type], M.[Year], M.[Price], M.[AlphaSort], M.[DateInventoried], 
                        M.[WishList], M.[Location],M.[DatePurchased], M.[Value], M.[DateVerified], M.[MediaFormat], M.[Notes], M.[DateCreated], 
                        M.[DateModified], M.[ArtistID],
                        LP.MediaFormat As [LP],CS.MediaFormat As [CS],CD.MediaFormat As [CD],MP3.MediaFormat As [MP3]
                    From Albums M
                        Left Outer Join Albums LP On LP.Type=M.Type And LP.Artist=M.Artist And LP.Year=M.Year And LP.Title=M.Title And LP.MediaFormat='LP' And LP.WishList=0
                        Left Outer Join Albums CS On CS.Type=M.Type And CS.Artist=M.Artist And CS.Year=M.Year And CS.Title=M.Title And CS.MediaFormat='CS' And CS.WishList=0
                        Left Outer Join Albums CD On CD.Type=M.Type And CD.Artist=M.Artist And CD.Year=M.Year And CD.Title=M.Title And CD.MediaFormat='CD' And CD.WishList=0
                        Left Outer Join Albums MP3 On MP3.Type=M.Type And MP3.Artist=M.Artist And MP3.Year=M.Year And MP3.Title=M.Title And MP3.MediaFormat='MP3' And MP3.WishList=0
                    Where M.WishList=0;");

            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='CDOnly' AND type='V') Drop View CDOnly;");
            context.Database.ExecuteSqlCommand(@"Create View [dbo].[CDOnly] As Select * From Music Where LP Is Null And CD Is Not Null And CS Is Null And MP3 Is Null;");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='CSOnly' AND type='V') Drop View CSOnly;");
            context.Database.ExecuteSqlCommand(@"Create View [dbo].[CSOnly] As Select * From Music Where LP Is Null And CD Is Null And CS Is Not Null And MP3 Is Null;");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='LPOnly' AND type='V') Drop View LPOnly;");
            context.Database.ExecuteSqlCommand(@"Create View [dbo].[LPOnly] As Select * From Music Where LP Is Not Null And CD Is Null And CS Is Null And MP3 Is Null;");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='MP3Only' AND type='V') Drop View MP3Only;");
            context.Database.ExecuteSqlCommand(@"Create View [dbo].[MP3Only] As Select * From Music Where LP Is Null And CD Is Null And CS Is Null And MP3 Is Not Null;");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='NotOnCD' AND type='V') Drop View NotOnCD;");
            context.Database.ExecuteSqlCommand(@"Create View [dbo].[NotOnCD] As Select * From Music Where CD Is Null;");
        }
        private static void CreateParsePathFunctions(TCContext context)
        {
            Console.WriteLine("\tSeeding Parse Path Functions...");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='fnGetFileName' And type='FN') Drop Function fnGetFileName");
            context.Database.ExecuteSqlCommand(@"
                CREATE FUNCTION fnGetFileName(@fullpath nvarchar(512)) RETURNS nvarchar(512)
                AS 
                    BEGIN
                    IF(CHARINDEX('\', @fullpath) > 0) --<-- Check to make sure that string has a back slash
                       SELECT @fullpath = RIGHT(@fullpath, CHARINDEX('\', REVERSE(@fullpath)) -1)
                       RETURN @fullpath
                END");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='fnGetFileNameBase' And type='FN') Drop Function fnGetFileNameBase");
            context.Database.ExecuteSqlCommand(@"
                CREATE FUNCTION dbo.fnGetFileNameBase(@fullpath NVARCHAR(512)) RETURNS NVARCHAR(512)    -- Usage SELECT dbo.fnGetFileNameBase('C:\Test\Mark.txt')
                AS
                BEGIN
                    IF(CHARINDEX('.', @fullpath) > 0) --<-- Check to make sure that string has a dot
                       BEGIN
                          SELECT @fullpath = dbo.fnGetFileName(@fullpath)
                              SELECT @fullpath = LEFT(@fullpath, LEN(@fullpath)-CHARINDEX('.', REVERSE(@fullpath)))
                       END
                    RETURN @fullpath
                END");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='fnGetExtension' And type='FN') Drop Function fnGetExtension");
            context.Database.ExecuteSqlCommand(@"
                CREATE FUNCTION dbo.fnGetExtension(@fullpath NVARCHAR(512)) RETURNS NVARCHAR(512)    -- Usage SELECT dbo.fnGetExtension('C:\Test\Mark.txt')
                AS
                BEGIN
                    IF(CHARINDEX('.', @fullpath) > 0) --<-- Check to make sure that string has a dot
                       BEGIN
                          SELECT @fullpath = dbo.fnGetFileName(@fullpath)
                              SELECT @fullpath = RIGHT(@fullpath, CHARINDEX('.', REVERSE(@fullpath)) -1)
                       END
                    RETURN @fullpath
                END");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='fnGetFolder' And type='FN') Drop Function fnGetFolder");
            context.Database.ExecuteSqlCommand(@"
                CREATE FUNCTION fnGetFolder(@fullpath nvarchar(512)) RETURNS nvarchar(512)    -- Usage SELECT dbo.fnGetFolder('C:\Test\Mark.txt')
                AS
                BEGIN
                    IF(CHARINDEX('\', @fullpath) > 0) --<-- Check to make sure that string has a back slash
                       SELECT @fullpath = LEFT(@fullpath, LEN(@fullpath)-CHARINDEX('\', REVERSE(@fullpath)))
                       RETURN @fullpath
                END");
        }
        private static void CreateTableSpaceUsed(TCContext context)
        {
            Console.WriteLine("\tsp_TableSpaceUsed");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_TableSpaceUsed' And type='P') Drop Procedure sp_TableSpaceUsed");
            context.Database.ExecuteSqlCommand(@"
            Create Procedure sp_TableSpaceUsed @Scale varchar(2) = null As 
            Begin
                Set NOCOUNT ON
                If OBJECT_ID('tempdb..#TableList') Is Not Null Drop Table #TableList
                Create Table #TableList
                (ID int IDENTITY,
                [Database] sysname,    
                [Owner] sysname,
                [TableName] sysname,
                [Type] varchar(32),
                [Remarks] varchar(254))
                Insert into #TableList exec sp_tables @table_name='%', @table_owner='dbo', @table_type=""'TABLE'""
                Declare dsTableList Cursor Fast_Forward For Select [TableName] From #TableList
            
                If OBJECT_ID('tempdb..#SpacePerTable') Is Not Null Drop Table #SpacePerTable
                Create Table #SpacePerTable
                (ID int IDENTITY,
                [TableName] sysname,    
                [Rows] sysname,
                [Reserved] sysname,
                [Data] sysname,
                [IndexSize] sysname,
                [Unused]sysname)
                Declare @TableName sysname
                Open dsTableList
                Fetch Next From dsTableList Into @TableName
                While @@FETCH_STATUS=0 Begin
                    Insert Into #SpacePerTable exec sp_spaceused @TableName
                    Fetch Next From dsTableList Into @TableName
                End
                Close dsTableList
                Deallocate dsTableList
            
                --Select * From #SpacePerTable Order By CONVERT(decimal(15,0), REPLACE([Reserved],' KB','')) Desc
                If @Scale is null 
                    Select [TableName] As [Table], 
                    CONVERT(decimal(15,0), [Rows]) As [Rows], 
                    CONVERT(decimal(15,0), REPLACE([Reserved],' KB','')*CONVERT(decimal(15,0),1024.)) As [Reserved Bytes], 
                    CONVERT(decimal(15,0), REPLACE([Data],' KB','')*CONVERT(decimal(15,0),1024.)) As [Data Bytes], 
                    CONVERT(decimal(15,0), REPLACE([IndexSize],' KB','')*CONVERT(decimal(15,0),1024.)) As [IndexSize Bytes], 
                    CONVERT(decimal(15,0), REPLACE([Unused],' KB','')*CONVERT(decimal(15,0),1024.)) As [Unused Bytes]
                    From #SpacePerTable
                    Order By CONVERT(decimal(15,0), REPLACE([Reserved],' KB','')) Desc
                Else If @Scale = 'KB' 
                    Select [TableName] As [Table], 
                    CONVERT(decimal(15,0), [Rows]) As [Rows], 
                    CONVERT(decimal(15,2), REPLACE([Reserved],' KB','')) As [Reserved KB], 
                    CONVERT(decimal(15,2), REPLACE([Data],' KB','')) As [Data KB], 
                    CONVERT(decimal(15,2), REPLACE([IndexSize],' KB','')) As [IndexSize KB], 
                    CONVERT(decimal(15,2), REPLACE([Unused],' KB','')) As [Unused KB]
                    From #SpacePerTable
                    Order By CONVERT(decimal(15,0), REPLACE([Reserved],' KB','')) Desc
                Else If @Scale = 'MB' 
                    Select [TableName] As [Table], 
                    CONVERT(decimal(15,0), [Rows]) As [Rows], 
                    CONVERT(decimal(15,2), REPLACE([Reserved],' KB','')/CONVERT(decimal(15,0),1024.)) As [Reserved MB], 
                    CONVERT(decimal(15,2), REPLACE([Data],' KB','')/CONVERT(decimal(15,0),1024.)) As [Data MB], 
                    CONVERT(decimal(15,2), REPLACE([IndexSize],' KB','')/CONVERT(decimal(15,0),1024.)) As [IndexSize MB], 
                    CONVERT(decimal(15,2), REPLACE([Unused],' KB','')/CONVERT(decimal(15,0),1024.)) As [Unused MB]
                    From #SpacePerTable
                    Order By CONVERT(decimal(15,0), REPLACE([Reserved],' KB','')) Desc
                Else If @Scale = 'GB' 
                    Select [TableName] As [Table], 
                    CONVERT(decimal(15,0), [Rows]) As [Rows], 
                    CONVERT(decimal(15,4), REPLACE([Reserved],' KB','')/CONVERT(decimal(15,0),1048576.)) As [Reserved GB], 
                    CONVERT(decimal(15,4), REPLACE([Data],' KB','')/CONVERT(decimal(15,0),1048576.)) As [Data GB], 
                    CONVERT(decimal(15,4), REPLACE([IndexSize],' KB','')/CONVERT(decimal(15,0),1048576.)) As [IndexSize GB], 
                    CONVERT(decimal(15,4), REPLACE([Unused],' KB','')/CONVERT(decimal(15,0),1048576.)) As [Unused GB]
                    From #SpacePerTable
                    Order By CONVERT(decimal(15,0), REPLACE([Reserved],' KB','')) Desc
            
                RETURN 1
            End;");
        }
        #region Conversion
        private static void CreateDataMigration(TCContext context)
        {
            Console.WriteLine("\tsp_DataMigration");
            CreateLogError(context);
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_DataMigration' And type='P') Drop Procedure sp_DataMigration");
            context.Database.ExecuteSqlCommand(@"
                --Data Migration.sql
                --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
                --   Copyright © 2019 All Rights Reserved.
                --*********************************************************************************************************************************
                --
                --    Modification History:
                --    Date:       Developer:        Description:
                --    06/06/19    Ken Clark        Added sp_PrepDataMigration;
                --    02/01/19    Ken Clark        Created;
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
                    exec sp_LogElapsed @Milestone, @stTime;
                    Commit Transaction;
                End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_DataMigration] to [Public];");
        }
        private static void CreatePrepDataMigration(TCContext context)
        {
            Console.WriteLine("\tsp_PrepDataMigration");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_PrepDataMigration' And type='P') Drop Procedure sp_PrepDataMigration");
            context.Database.ExecuteSqlCommand(@"
            --sp_PrepDataMigration.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    06/06/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_PrepDataMigration As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_PrepDataMigration';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'PrepDataMigration...';

                    exec sp_LogMessage @Milestone, '   Locations (catch-up)';
                    Insert Into [dbo].[Locations] (Name,Description,PhysicalLocation,OName)
                    Select Distinct 
                        Case 
                            When CHARINDEX('[',[tcLocations].[Location],1)>0 Then RTRIM(SUBSTRING([tcLocations].[Location],1,CHARINDEX('[',[tcLocations].[Location],1)-1))
                            When CHARINDEX('(',[tcLocations].[Location],1)>0 Then RTRIM(SUBSTRING([tcLocations].[Location],1,CHARINDEX('(',[tcLocations].[Location],1)-1))
                            Else [tcLocations].[Location]
                        End As Name,
                        Case 
                            When CHARINDEX('(',[tcLocations].[Location],1)>0 Then RTRIM(SUBSTRING([tcLocations].[Location],CHARINDEX('(',[tcLocations].[Location],1)+1,CHARINDEX(')',[tcLocations].[Location],1)-CHARINDEX('(',[tcLocations].[Location],1)-1))
                            Else ''
                        End As Description,
                        Case 
                            When CHARINDEX('[',[tcLocations].[Location],1)>0 Then RTRIM(SUBSTRING([tcLocations].[Location],CHARINDEX('[',[tcLocations].[Location],1)+1,CHARINDEX(']',[tcLocations].[Location],1)-CHARINDEX('[',[tcLocations].[Location],1)-1))
                            Else ''
                        End As PhysicalLocation,
                        [tcLocations].[Location]
                    From [GGGSCP1].[TreasureChest].[dbo].[Locations] [tcLocations]
                        Left Outer Join [dbo].[Locations] [Locations] On [Locations].[OName]=[tcLocations].[Location]
                    Where [Locations].[OName] Is Null
                    Order By 1;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_PrepDataMigration] to [Public];");
        }
        private static void CreateMigrateAircraftDesignations(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateAircraftDesignations");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateAircraftDesignations' And type='P') Drop Procedure sp_MigrateAircraftDesignations;");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateAircraftDesignations.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateAircraftDesignations As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateAircraftDesignations';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'AircraftDesignations...';
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
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
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
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
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
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateAircraftDesignations] to [Public];");
        }
        private static void CreateMigrateBlueAngelsHistory(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateBlueAngelsHistory");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateBlueAngelsHistory' And type='P') Drop Procedure sp_MigrateBlueAngelsHistory");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateBlueAngelsHistory.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateBlueAngelsHistory As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateBlueAngelsHistory';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'BlueAngelsHistory...';
                    Delete From [dbo].[BlueAngelsHistory];
                    INSERT INTO [dbo].[BlueAngelsHistory] ([OID],
                        [ServiceDates],[AircraftType],[Decals],[DecalSets],[Kits],[Notes],[DateCreated],[DateModified])
                    SELECT     [ID],
                        [Dates],[Aircraft Type],[Decal Sets],Null,[Kits],[Notes],[DateCreated],[DateModified]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Blue Angels History] ORDER By [ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Blue Angels History];
                    Select @Actual=Count(*) From [dbo].[BlueAngelsHistory];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
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
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateBlueAngelsHistory] to [Public];");
        }
        private static void CreateMigrateBooks(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateBooks");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateBooks' And type='P') Drop Procedure sp_MigrateBooks");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateBooks.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateBooks As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateBooks';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Books...';
                    Delete From [dbo].[Books];
                    INSERT INTO [dbo].[Books] ([OID],
                        [AlphaSort],[Author],[MediaFormat],[ISBN],[Misc],[Subject],[Title],[Cataloged],[DateInventoried],
                        [DatePurchased],[DateVerified],[Notes],[Price],[Value],[WishList],[DateCreated],[DateModified],[LocationID])
                    SELECT [Books].[ID],
                        [Alphasort],[Author],[Format],[ISBN],[Misc],[Subject],[Title],[Cataloged],[DateInventoried],
                        [DatePurchased],[DateVerified],[Notes],[Price],[Value],[WishList],[Books].[DateCreated],[Books].[DateModified],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Books] [Books]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Books].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Books].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Books];
                    Select @Actual=Count(*) From [dbo].[Books];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='Books';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Books].[ID],[History].[TableName],[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Books] [Books] On [History].[TableName]='Books' And [Books].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Books' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Books' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Books] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];    --618
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End;
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Books';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Books';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    Delete From [dbo].[Images] Where [TableName]='Books';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('BOOKS: '+[Books].[Title]),[Books].[Title]+' (Front Cover)','Books',getdate(),getdate(),Null,Null,[Image],[Books].[Title],Null,
                        [newBooks].[ID],'Books',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Books] [Books]
                        INNER JOIN [dbo].[Books] [newBooks] On [Books].[ID]=[newBooks].[OID]
                    WHERE [Books].[Image] is not Null
                    ORDER BY [Books].[ID];
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('BOOKS: '+[Books].[Title]),[Books].[Title]+' (Back Cover)','Books',getdate(),getdate(),Null,Null,[OtherImage],[Books].[Title],Null,
                        [newBooks].[ID],'Books',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Books] [Books]
                        INNER JOIN [dbo].[Books] [newBooks] On [Books].[ID]=[newBooks].[OID]
                    WHERE [Books].[OtherImage] is not Null
                    ORDER BY [Books].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Books] Where [Image] is not Null;
                    Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Books] Where [OtherImage] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Books';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateBooks] to [Public];");
        }
        private static void CreateMigrateCollectables(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateCollectables");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateCollectables' And type='P') Drop Procedure sp_MigrateCollectables");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateCollectables.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateCollectables As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateCollectables';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Collectables...';
                    Delete From [dbo].[Collectables];
                    INSERT INTO [dbo].[Collectables] ([OID],
                        [Cataloged],[Condition],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],
                        [Manufacturer],[Name],[Notes],[OutOfProduction],[Price],[Reference],[Series],[Type],[Value],[WishList],[LocationID])
                    SELECT [Collectables].[ID],
                        1,[Condition],[Collectables].[DateCreated],[DateInventoried],[Collectables].[DateModified],[DatePurchased],[DateVerified],
                        [Manufacturer],[Collectables].[Name],[Notes],[OutOfProduction],[Price],[Reference],[Series],[Type],[Value],[WishList],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Collectables] [Collectables]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Collectables].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Collectables].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Collectables];
                    Select @Actual=Count(*) From [dbo].[Collectables];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='Collectables';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Collectables].[ID],[History].[TableName],[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Collectables] [Collectables] On [History].[TableName]='Collectables' And [Collectables].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Collectables' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Collectables' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Collectables] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Collectables';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Collectables';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    Delete From [dbo].[Images] Where [TableName]='Collectables';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Collectables: '+[Collectables].[Name]),[Collectables].[Name],'Collectables',getdate(),getdate(),Null,Null,[Image],[Collectables].[Name],Null,
                        [newCollectables].[ID],'Collectables',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Collectables] [Collectables]
                        INNER JOIN [dbo].[Collectables] [newCollectables] On [Collectables].[ID]=[newCollectables].[OID]
                    WHERE [Collectables].[Image] is not Null
                    ORDER BY [Collectables].[ID];
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Collectables: '+[Collectables].[Name]),[Collectables].[Name],'Collectables',getdate(),getdate(),Null,Null,[OtherImage],[Collectables].[Name],Null,
                        [newCollectables].[ID],'Collectables',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Collectables] [Collectables]
                        INNER JOIN [dbo].[Collectables] [newCollectables] On [Collectables].[ID]=[newCollectables].[OID]
                    WHERE [Collectables].[OtherImage] is not Null
                    ORDER BY [Collectables].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Collectables] Where [Image] is not Null;
                    Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Collectables] Where [OtherImage] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Collectables';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateCollectables] to [Public];");
        }
        private static void CreateMigrateCompanies(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateCompanies");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateCompanies' And type='P') Drop Procedure sp_MigrateCompanies");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateCompanies.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateCompanies As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateCompanies';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Companies...';
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
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
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
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateCompanies] to [Public];");
        }
        private static void CreateMigrateDecals(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateDecals");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateDecals' And type='P') Drop Procedure sp_MigrateDecals");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateDecals.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateDecals As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateDecals';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Decals';
                    Delete From [dbo].[Decals];
                    INSERT INTO [dbo].[Decals] ([OID],
                        [Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[Designation],
                        [Manufacturer],[Name],[Nation],[Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],[LocationID])
                    SELECT [Decals].[ID],
                        1,[Decals].[DateCreated],[DateInventoried],[Decals].[DateModified],[DatePurchased],[DateVerified],[Designation],
                        [Manufacturer],[Decals].[Name],[Nation],[Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Decals] [Decals]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Decals].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Decals].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Decals];
                    Select @Actual=Count(*) From [dbo].[Decals];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='Decals';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Decals].[ID],[History].[TableName],[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Decals] [Decals] On [History].[TableName]='Decals' And [Decals].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Decals' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Decals' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Decals] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Select @OrphanedHistoryCount=Count(*) From [#DeletedHistory];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End;
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Decals';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Decals';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    Delete From [dbo].[Images] Where [TableName]='Decals';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Decals: '+[Decals].[Name]),
                        [Decals].[Scale]+' '+[Decals].[Designation]+' '+[Decals].[Name]+' ('+[Decals].[Reference]+')',
                        'Decals',getdate(),getdate(),Null,Null,[Image],[Decals].[Name],Null,
                        [newDecals].[ID],'Decals',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Decals] [Decals]
                        INNER JOIN [dbo].[Decals] [newDecals] On [Decals].[ID]=[newDecals].[OID]
                    WHERE [Decals].[Image] is not Null
                    ORDER BY [Decals].[ID];
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Decals: '+[Decals].[Name]),
                        [Decals].[Scale]+' '+[Decals].[Designation]+' '+[Decals].[Name]+' ('+[Decals].[Reference]+')',
                        'Decals',getdate(),getdate(),Null,Null,[OtherImage],[Decals].[Name],Null,
                        [newDecals].[ID],'Decals',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Decals] [Decals]
                        INNER JOIN [dbo].[Decals] [newDecals] On [Decals].[ID]=[newDecals].[OID]
                    WHERE [Decals].[OtherImage] is not Null
                    ORDER BY [Decals].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Decals] Where [Image] is not Null;
                    Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Decals] Where [OtherImage] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Decals';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Kits';
                    Declare @KitID uniqueidentifier, @DecalOID int, @DecalID uniqueidentifier;
                    Declare kitCursor Cursor For
                        Select [Kits].[ID] As [Kits.ID],[OKits].[DecalID] As [Decal.OID],[Decals].[ID] As [Decal.ID]
                        From [dbo].[Kits] 
                            Inner Join [GGGSCP1].[TreasureChest].[dbo].[Kits] [OKits] On [OKits].ID=[Kits].[OID]
                            Inner Join [dbo].[Decals] On [Decals].[OID]=[OKits].[DecalID];
                    Open kitCursor;
                    Fetch Next From kitCursor Into @KitID, @DecalOID, @DecalID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Update [dbo].[Kits] Set [Decal_ID]=@DecalID Where [Kits].[ID]=@KitID;
                        Fetch Next From kitCursor Into @KitID, @DecalOID, @DecalID;
                    End;
                    Close kitCursor;
                    Deallocate kitCursor;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Kits] Where [DecalID] is not Null;
                    Select @Actual=Count(*) From [dbo].[Kits] Where [Decal_ID] is not Null;
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateDecals] to [Public];");
        }
        private static void CreateMigrateDetailSets(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateDetailSets");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateDetailSets' And type='P') Drop Procedure sp_MigrateDetailSets");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateDetailSets.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateDetailSets As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateDetailSets';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'DetailSets';
                    Delete From [dbo].[DetailSets];
                    INSERT INTO [dbo].[DetailSets] ([OID],
                        [Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[Designation],
                        [Manufacturer],[Name],[Nation],[Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],[LocationID])
                    SELECT [Detail Sets].[ID],
                        1,[Detail Sets].[DateCreated],[DateInventoried],[Detail Sets].[DateModified],[DatePurchased],[DateVerified],[Designation],
                        [Manufacturer],[Detail Sets].[Name],[Nation],[Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Detail Sets] [Detail Sets]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Detail Sets].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Detail Sets].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Detail Sets];
                    Select @Actual=Count(*) From [dbo].[DetailSets];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='DetailSets';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[DetailSets].[ID],'DetailSets',[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[DetailSets] [DetailSets] On [History].[TableName]='Detail Sets' And [DetailSets].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Detail Sets' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],'DetailSets' As [TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Detail Sets' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Detail Sets] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Select @OrphanedHistoryCount=Count(*) From [#DeletedHistory];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End;
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Detail Sets';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='DetailSets';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    Delete From [dbo].[Images] Where [TableName]='DetailSets';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Detail Sets: '+[Detail Sets].[Name]),
                        [Detail Sets].[Scale]+' '+[Detail Sets].[Designation]+' '+[Detail Sets].[Name]+' ('+[Detail Sets].[Reference]+')',
                        'DetailSets',getdate(),getdate(),Null,Null,[Image],[Detail Sets].[Name],Null,
                        [DetailSets].[ID],'DetailSets',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Detail Sets] [Detail Sets]
                        INNER JOIN [dbo].[DetailSets] [DetailSets] On [Detail Sets].[ID]=[DetailSets].[OID]
                    WHERE [Detail Sets].[Image] is not Null
                    ORDER BY [Detail Sets].[ID];
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Detail Sets: '+[Detail Sets].[Name]),
                        [Detail Sets].[Scale]+' '+[Detail Sets].[Designation]+' '+[Detail Sets].[Name]+' ('+[Detail Sets].[Reference]+')',
                        'DetailSets',getdate(),getdate(),Null,Null,[OtherImage],[Detail Sets].[Name],Null,
                        [DetailSets].[ID],'DetailSets',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Detail Sets] [Detail Sets]
                        INNER JOIN [dbo].[DetailSets] [DetailSets] On [Detail Sets].[ID]=[DetailSets].[OID]
                    WHERE [Detail Sets].[OtherImage] is not Null
                    ORDER BY [Detail Sets].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Detail Sets] Where [Image] is not Null;
                    Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Detail Sets] Where [OtherImage] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='DetailSets';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Kits';
                    Declare @KitID uniqueidentifier, @DetailSetOID int, @DetailSetID uniqueidentifier;
                    Declare kitCursor Cursor For
                        Select [Kits].[ID] As [Kits.ID],[OKits].[DetailSetID] As [DetailSet.OID],[DetailSets].[ID] As [DetailSet.ID]
                        From [dbo].[Kits] 
                            Inner Join [GGGSCP1].[TreasureChest].[dbo].[Kits] [OKits] On [OKits].ID=[Kits].[OID]
                            Inner Join [dbo].[DetailSets] On [DetailSets].[OID]=[OKits].[DetailSetID];
                    Open kitCursor;
                    Fetch Next From kitCursor Into @KitID, @DetailSetOID, @DetailSetID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Update [dbo].[Kits] Set [DetailSet_ID]=@DetailSetID Where [Kits].[ID]=@KitID;
                        Fetch Next From kitCursor Into @KitID, @DetailSetOID, @DetailSetID;
                    End;
                    Close kitCursor;
                    Deallocate kitCursor;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Kits] Where [DetailSetID] is not Null;
                    Select @Actual=Count(*) From [dbo].[Kits] Where [DetailSet_ID] is not Null;
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateDetailSets] to [Public];");
        }
        private static void CreateMigrateEpisodes(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateEpisodes");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateEpisodes' And type='P') Drop Procedure sp_MigrateEpisodes");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateEpisodes.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateEpisodes As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateEpisodes';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Episodes';
                    Delete From [dbo].[Episodes];
                    INSERT INTO [dbo].[Episodes] ([OID],
                        [Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateReleased],[DateVerified],
                        [Distributor],[MediaFormat],[Notes],[Number],[Price],[Series],[Subject],[Title],[Value],[WishList],[StoreBought],[Taped],[WMV],[LocationID])
                    SELECT [Episodes].[ID],
                        1,[Episodes].[DateCreated],[DateInventoried],[Episodes].[DateModified],[DatePurchased],[ReleaseDate],[DateVerified],
                        [Distributor],[Format],[Notes],[Number],[Price],[Series],[Subject],[Title],[Value],[WishList],[StoreBought],[Taped],[WMV],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Episodes] [Episodes]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Episodes].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Episodes].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Episodes];
                    Select @Actual=Count(*) From [dbo].[Episodes];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='Episodes';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Episodes].[ID],[History].[TableName],[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Episodes] [Episodes] On [History].[TableName]='Episodes' And [Episodes].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Episodes' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Episodes' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Episodes] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Select @OrphanedHistoryCount=Count(*) From [#DeletedHistory];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End;
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Episodes';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Episodes';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    Delete From [dbo].[Images] Where [TableName]='Episodes';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Episodes: '+[Episodes].[Title]),[Episodes].[Title],'Episodes',getdate(),getdate(),Null,Null,[Image],[Episodes].[Title],Null,
                        [newEpisodes].[ID],'Episodes',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Episodes] [Episodes]
                        INNER JOIN [dbo].[Episodes] [newEpisodes] On [Episodes].[ID]=[newEpisodes].[OID]
                    WHERE [Episodes].[Image] is not Null
                    ORDER BY [Episodes].[ID];
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Episodes: '+[Episodes].[Title]),[Episodes].[Title],'Episodes',getdate(),getdate(),Null,Null,[OtherImage],[Episodes].[Title],Null,
                        [newEpisodes].[ID],'Episodes',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Episodes] [Episodes]
                        INNER JOIN [dbo].[Episodes] [newEpisodes] On [Episodes].[ID]=[newEpisodes].[OID]
                    WHERE [Episodes].[OtherImage] is not Null
                    ORDER BY [Episodes].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Episodes] Where [Image] is not Null;
                    Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Episodes] Where [OtherImage] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Episodes';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateEpisodes] to [Public];");
        }
        private static void CreateMigrateFinishingProducts(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateFinishingProducts");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateFinishingProducts' And type='P') Drop Procedure sp_MigrateFinishingProducts");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateFinishingProducts.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateFinishingProducts As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateFinishingProducts';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'FinishingProducts'
                    Delete From [dbo].[FinishingProducts];
                    INSERT INTO [dbo].[FinishingProducts] ([OID],
                        [Cataloged],[Count],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[Manufacturer],[Name],
                        [Notes],[Price],[ProductCatalog],[Reference],[Type],[Value],[WishList],[LocationID])
                    SELECT [Finishing Products].[ID],
                        1,[Count],[Finishing Products].[DateCreated],[DateInventoried],[Finishing Products].[DateModified],[DatePurchased],[DateVerified],[Manufacturer],[Finishing Products].[Name],
                        [Notes],[Price],[ProductCatalog],[Reference],[Type],[Value],[WishList],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Finishing Products] [Finishing Products]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Finishing Products].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Finishing Products].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Finishing Products];
                    Select @Actual=Count(*) From [dbo].[FinishingProducts];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='Finishing Products';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[FinishingProducts].[ID],'FinishingProducts',[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[FinishingProducts] [FinishingProducts] On [History].[TableName]='Finishing Products' And [FinishingProducts].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Finishing Products' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Finishing Products' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Finishing Products] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Select @OrphanedHistoryCount=Count(*) From [#DeletedHistory];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End;
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],'FinishingProducts',[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Finishing Products';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='FinishingProducts';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    Delete From [dbo].[Images] Where [TableName]='FinishingProducts';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Finishing Products: '+[Finishing Products].[Name]),[Finishing Products].[Name],'FinishingProducts',getdate(),getdate(),Null,Null,[Image],[Finishing Products].[Name],Null,
                        [FinishingProducts].[ID],'FinishingProducts',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Finishing Products] [Finishing Products]
                        INNER JOIN [dbo].[FinishingProducts] [FinishingProducts] On [Finishing Products].[ID]=[FinishingProducts].[OID]
                    WHERE [Finishing Products].[Image] is not Null
                    ORDER BY [Finishing Products].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Finishing Products] Where [Image] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='FinishingProducts';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateFinishingProducts] to [Public];");
        }
        private static void CreateMigrateImages(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateImages");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateImages' And type='P') Drop Procedure sp_MigrateImages");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateImages.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateImages As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateImages';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Images (base - not tied to other records)';
                    Delete From [dbo].[Images] Where [RecordID] is Null And [TableName] is Null;
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT [ID],Upper('IMAGES: '+[Sort]),[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        Null,Null,0,[URL],[Width]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Images] Where [Images].[Image] is not Null
                    ORDER BY [Images].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Images] Where [Images].[Image] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [RecordID] is Null And [TableName] is Null;
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='Images';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Images].[ID],[History].[TableName],[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Images] [Images] On [History].[TableName]='Images' And [Images].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Images' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Images' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Images] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End;
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Images';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Images';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateImages] to [Public];");
        }
        private static void CreateMigrateKits(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateKits");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateKits' And type='P') Drop Procedure sp_MigrateKits");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateKits.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateKits As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateKits';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Kits'
                    Delete From [dbo].[Kits];
                    INSERT INTO [dbo].[Kits] ([OID],
                        [Cataloged],[Condition],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[Decal_ID],
                        [Designation],[DetailSet_ID],[Era],[Manufacturer],[Name],[Nation],[Notes],[OutOfProduction],[Price],[ProductCatalog],
                        [Reference],[Scale],[Service],[Type],[Value],[WishList],[LocationID])
                    SELECT [Kits].[ID],
                        1,[Condition],[Kits].[DateCreated],[DateInventoried],[Kits].[DateModified],[DatePurchased],[DateVerified],Null,
                        [Designation],Null,[Era],[Manufacturer],[Kits].[Name],[Nation],[Notes],[OutOfProduction],[Price],[ProductCatalog],
                        [Reference],[Scale],[Service],[Type],[Value],[WishList],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Kits] [Kits]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Kits].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Kits].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Kits];
                    Select @Actual=Count(*) From [dbo].[Kits];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='Kits';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Kits].[ID],[History].[TableName],[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Kits] [Kits] On [History].[TableName]='Kits' And [Kits].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Kits' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Kits' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Kits] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Select @OrphanedHistoryCount=Count(*) From [#DeletedHistory];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End;
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Kits';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Kits';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    Delete From [dbo].[Images] Where [TableName]='Kits';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Kits: '+[Kits].[Name]),
                        [Kits].[Scale]+' '+[Kits].[Designation]+' '+[Kits].[Name]+' ('+[Kits].[Reference]+')',
                        'Kits',getdate(),getdate(),Null,Null,[Image],[Kits].[Name],Null,
                        [newKits].[ID],'Kits',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Kits] [Kits]
                        INNER JOIN [dbo].[Kits] [newKits] On [Kits].[ID]=[newKits].[OID]
                    WHERE [Kits].[Image] is not Null
                    ORDER BY [Kits].[ID];
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Kits: '+[Kits].[Name]),
                        [Kits].[Scale]+' '+[Kits].[Designation]+' '+[Kits].[Name]+' ('+[Kits].[Reference]+')',
                        'Kits',getdate(),getdate(),Null,Null,[OtherImage],[Kits].[Name],Null,
                        [newKits].[ID],'Kits',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Kits] [Kits]
                        INNER JOIN [dbo].[Kits] [newKits] On [Kits].[ID]=[newKits].[OID]
                    WHERE [Kits].[OtherImage] is not Null
                    ORDER BY [Kits].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Kits] Where [Image] is not Null;
                    Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Kits] Where [OtherImage] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Kits';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateKits] to [Public];");
        }
        private static void CreateMigrateMovies(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateMovies");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateMovies' And type='P') Drop Procedure sp_MigrateMovies");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateMovies.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateMovies As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateMovies';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Videos/Movies'
                    Delete From [dbo].[Images] Where [TableName]='Videos' And [Images].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Movies');
                    Delete From [dbo].[History] Where [TableName]='Videos' And [History].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Movies');
                    Delete From [dbo].[Videos] Where [SourceTable]='Movies';
                    INSERT INTO [dbo].[Videos] ([OID],
                        [AlphaSort],[Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateReleased],[DateVerified],
                        [Distributor],[MediaFormat],[Notes],[Price],[Subject],[Title],[Value],[WishList],[StoreBought],[WMV],[LocationID],[SourceTable])
                    SELECT [Movies].[ID],
                        [Sort],1,[Movies].[DateCreated],[DateInventoried],[Movies].[DateModified],[DatePurchased],[ReleaseDate],[DateVerified],
                        [Distributor],[Format],[Notes],[Price],[Subject],[Title],[Value],[WishList],[StoreBought],[WMV],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID],'Movies'
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Movies] [Movies]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Movies].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Movies].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Movies];
                    Select @Actual=Count(*) From [dbo].[Videos] Where [SourceTable]='Movies';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Videos].[ID],'Videos',[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Videos] [Videos] On [History].[TableName]='Movies' And [Videos].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Movies' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Movies' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Movies] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Select @OrphanedHistoryCount=Count(*) From [#DeletedHistory];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Movies';
                    Select @Actual=@OrphanedHistoryCount+Count(*) From [dbo].[History] Where [TableName]='Videos' And [History].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Movies');
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Videos: '+[Movies].[Title]),[Movies].[Title],'Videos',getdate(),getdate(),Null,Null,[Image],[Movies].[Title],Null,
                        [newVideos].[ID],'Videos',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Movies] [Movies]
                        INNER JOIN [dbo].[Videos] [newVideos] On [Movies].[ID]=[newVideos].[OID]
                    WHERE [Movies].[Image] is not Null
                    ORDER BY [Movies].[ID];
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Videos: '+[Movies].[Title]),[Movies].[Title],'Videos',getdate(),getdate(),Null,Null,[OtherImage],[Movies].[Title],Null,
                        [newVideos].[ID],'Videos',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Movies] [Movies]
                        INNER JOIN [dbo].[Videos] [newVideos] On [Movies].[ID]=[newVideos].[OID]
                    WHERE [Movies].[OtherImage] is not Null
                    ORDER BY [Movies].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Movies] Where [Image] is not Null;
                    Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Movies] Where [OtherImage] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Videos' And [Images].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Movies');
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateMovies] to [Public];");
        }
        private static void CreateMigrateMusic(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateMusic");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateMusic' And type='P') Drop Procedure sp_MigrateMusic");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateMusic.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --  06/02/19    Ken Clark       Enhanced to handle Artists/Tracks & Albums replacement for Music;
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateMusic As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateMusic';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Music'
            
                    exec sp_LogMessage @Milestone, '   Artists'
                    Delete From [dbo].[Artists];
                    INSERT INTO [dbo].[Artists] ([OID],
                        [Name],[AlphaSort],[AKA],[Comments],[DateCreated],[DateModified])
                    SELECT [Artists].[ID],
                        [Name],[AlphaSort],[AKA],NULL,getdate() As [DateCreated],getdate() As [DateModified]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Artists] [Artists]
                    ORDER BY [Artists].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Artists];
                    Select @Actual=Count(*) From [dbo].[Artists];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Albums'
                    Delete From [dbo].[Albums];
                    INSERT INTO [dbo].[Albums] ([OID],
                        [AlphaSort],[Artist],[ArtistID],[Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[MediaFormat],
                        [Notes],[Price],[Title],[Type],[Value],[WishList],[Year],[LocationID])
                    SELECT [Music].[ID],
                        [Music].[AlphaSort],[Artist],[Artists].[ID],[Inventoried],[Music].[DateCreated],[DateInventoried],[Music].[DateModified],[DatePurchased],[DateVerified],[Media],
                        [Notes],[Price],[Title],[Type],[Value],[WishList],[Year],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Music] [Music]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Music].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                        LEFT OUTER JOIN [dbo].[Artists] [Artists] On [Music].[ArtistID]=[Artists].[OID]
                    ORDER BY [Music].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Music];
                    Select @Actual=Count(*) From [dbo].[Albums];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='Music';Delete From [dbo].[History] Where [TableName]='Albums';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Albums].[ID],'Albums',[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Albums] [Albums] On [History].[TableName]='Music' And [Albums].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Music' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],'Albums' As [TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Music' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Music] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Music';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Albums';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    Delete From [dbo].[Images] Where [TableName]='Music';Delete From [dbo].[Images] Where [TableName]='Albums';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Albums: '+[Music].[Title]),[Music].[Artist]+': '+[Music].[Title]+' Cover','Albums',getdate(),getdate(),Null,Null,[Image],[Music].[Title],Null,
                        [newMusic].[ID],'Albums',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Music] [Music]
                        INNER JOIN [dbo].[Albums] [newMusic] On [Music].[ID]=[newMusic].[OID]
                    WHERE [Music].[Image] is not Null
                    ORDER BY [Music].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Music] Where [Image] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Albums';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Tracks';
                    Delete From [dbo].[Tracks];
                    INSERT INTO [dbo].[Tracks] ([OID],[Genre],
                        [AlbumArtist],[AlbumArtistID],
                        [Artist],[ArtistID],
                        [Year],[Album],[AlbumID],
                        [DiscNumber],[TrackNumber],[Title],[Duration],[Composer],[Comment],[Path],[Lyrics],[Publisher],
                        [DateCreated],[DateModified])
                    SELECT [Tracks].[ID],[Genre],
                        [AlbumArtist],[AlbumArtists].[ID] As [AlbumArtistID],
                        [Tracks].[Artist],[Artists].[ID] As [ArtistID],
                        [Tracks].[Year],[Album],[Albums].[ID] As [AlbumID],
                        [Disc],[Track],[Tracks].[Title],[Duration],[Composer],[Comment],[Path],[Lyrics],[Publisher],
                        getdate() As [DateCreated],getdate() As [DateModified]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Tracks] [Tracks]
                        LEFT OUTER JOIN [dbo].[Artists] [Artists] On [Tracks].[Artist]=[Artists].[Name]
                        LEFT OUTER JOIN [dbo].[Artists] [AlbumArtists] On [Tracks].[AlbumArtistID]=[AlbumArtists].[OID]
                        LEFT OUTER JOIN [dbo].[Albums] [Albums] On [Tracks].[AlbumID]=[Albums].[OID]
                    ORDER BY [Tracks].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Tracks];
                    Select @Actual=Count(*) From [dbo].[Tracks];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateMusic] to [Public];");
        }
        private static void CreateMigrateQueries(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateQueries");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateQueries' And type='P') Drop Procedure sp_MigrateQueries");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateQueries.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateQueries As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateQueries';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Query...';
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
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateQueries] to [Public];");
        }
        private static void CreateMigrateRockets(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateRockets");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateRockets' And type='P') Drop Procedure sp_MigrateRockets");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateRockets.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateRockets As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateRockets';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Rockets'
                    Delete From [dbo].[Rockets];
                    INSERT INTO [dbo].[Rockets] ([OID],
                        [Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[Designation],[Manufacturer],
                        [Name],[Nation],[Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],[LocationID])
                    SELECT [Rockets].[ID],
                        1,[Rockets].[DateCreated],[DateInventoried],[Rockets].[DateModified],[DatePurchased],[DateVerified],[Designation],[Manufacturer],
                        [Rockets].[Name],[Nation],[Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Rockets] [Rockets]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Rockets].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Rockets].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Rockets];
                    Select @Actual=Count(*) From [dbo].[Rockets];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='Rockets';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Rockets].[ID],[History].[TableName],[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Rockets] [Rockets] On [History].[TableName]='Rockets' And [Rockets].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Rockets' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Rockets' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Rockets] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Select @OrphanedHistoryCount=Count(*) From [#DeletedHistory];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End;
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Rockets';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Rockets';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    Delete From [dbo].[Images] Where [TableName]='Rockets';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Rockets: '+[Rockets].[Name]),[Rockets].[Name],'Rockets',getdate(),getdate(),Null,Null,[Image],[Rockets].[Name],Null,
                        [newRockets].[ID],'Rockets',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Rockets] [Rockets]
                        INNER JOIN [dbo].[Rockets] [newRockets] On [Rockets].[ID]=[newRockets].[OID]
                    WHERE [Rockets].[Image] is not Null
                    ORDER BY [Rockets].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Rockets] Where [Image] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Rockets';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateRockets] to [Public];");
        }
        private static void CreateMigrateShipClasses(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateShipClasses");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateShipClasses' And type='P') Drop Procedure sp_MigrateShipClasses");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateShipClasses.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateShipClasses As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateShipClasses';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'ShipClass/Class...';
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
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
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
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
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
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateShipClasses] to [Public];");
        }
        private static void CreateMigrateShipClassTypes(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateShipClassTypes");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateShipClassTypes' And type='P') Drop Procedure sp_MigrateShipClassTypes");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateShipClassTypes.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateShipClassTypes As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateShipClassTypes';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'ShipClassTypes/Classifications...';
                    --Seed method will have already added most this static data...
                    Update [ShipClassTypes] Set [OID]=(Select Top 1 ID From [GGGSCP1].[TreasureChest].[dbo].[Classification] Where [Type]=[TypeCode] And [Classification].[Description]=[ShipClassTypes].[Description]);
                    Update [ShipClassTypes] Set [OID]=(Select Top 1 ID From [GGGSCP1].[TreasureChest].[dbo].[Classification] Where [Type] Is Null And [Classification].[Description]='Unassigned') Where [ShipClassTypes].[Description]='Unassigned';
                    --INSERT INTO [dbo].[ShipClassTypes] ([OID],
                    --    [DateCreated],[DateModified],[Description],[TypeCode])
                    --SELECT [ID],
                    --    [DateCreated],[DateModified],[Description],[Type]
                    --FROM [GGGSCP1].[TreasureChest].[dbo].[Classification] ORDER BY [ID];
            
                    exec sp_LogMessage @Milestone, '   History';
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
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateShipClassTypes] to [Public];");
        }
        private static void CreateMigrateShips(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateShips");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateShips' And type='P') Drop Procedure sp_MigrateShips");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateShips.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateShips As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateShips';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Ships...';
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
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
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
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
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
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateShips] to [Public];");
        }
        private static void CreateMigrateSoftware(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateSoftware");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateSoftware' And type='P') Drop Procedure sp_MigrateSoftware");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateSoftware.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateSoftware As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateSoftware';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Software'
                    Delete From [dbo].[Software];
                    INSERT INTO [dbo].[Software] ([OID],
                        [AlphaSort],[Cataloged],[CDkey],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateReleased],[DateVerified],
                        [Developer],[ISBN],[MediaFormat],[Notes],[Platform],[Price],[Publisher],[Title],[Type],[Value],[Version],[WishList],[LocationID])
                    SELECT [Software].[ID],
                        [AlphaSort],[Cataloged],[CDkey],[Software].[DateCreated],[DateInventoried],[Software].[DateModified],[DatePurchased],[DateReleased],[DateVerified],
                        [Developer],[ISBN],[Media],[Notes],[Platform],[Price],[Publisher],[Title],[Type],[Value],[Version],[WishList],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Software] [Software]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Software].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Software].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Software];
                    Select @Actual=Count(*) From [dbo].[Software];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='Software';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Software].[ID],[History].[TableName],[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Software] [Software] On [History].[TableName]='Software' And [Software].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Software' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Software' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Software] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Software';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Software';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    Delete From [dbo].[Images] Where [TableName]='Software';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Software: '+[Software].[Title]),Null,'Software',getdate(),getdate(),Null,Null,[Image],[Software].[Title],Null,
                        [newSoftware].[ID],'Software',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Software] [Software]
                        INNER JOIN [dbo].[Software] [newSoftware] On [Software].[ID]=[newSoftware].[OID]
                    WHERE [Software].[Image] is not Null
                    ORDER BY [Software].[ID];
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Software: '+[Software].[Title]),Null,'Software',getdate(),getdate(),Null,Null,[OtherImage],[Software].[Title],Null,
                        [newSoftware].[ID],'Software',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Software] [Software]
                        INNER JOIN [dbo].[Software] [newSoftware] On [Software].[ID]=[newSoftware].[OID]
                    WHERE [Software].[OtherImage] is not Null
                    ORDER BY [Software].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Software] Where [Image] is not Null;
                    Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Software] Where [OtherImage] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Software';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateSoftware] to [Public];");
        }
        private static void CreateMigrateSpecials(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateSpecials");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateSpecials' And type='P') Drop Procedure sp_MigrateSpecials");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateSpecials.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateSpecials As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateSpecials';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Videos/Specials'
                    Delete From [dbo].[Images] Where [TableName]='Videos' And [Images].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Specials');
                    Delete From [dbo].[History] Where [TableName]='Videos' And [History].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Specials');
                    Delete From [dbo].[Videos] Where [SourceTable]='Specials';
                    INSERT INTO [dbo].[Videos] ([OID],
                        [AlphaSort],[Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateReleased],[DateVerified],
                        [Distributor],[MediaFormat],[Notes],[Price],[Subject],[Title],[Value],[WishList],[StoreBought],[WMV],[LocationID],[SourceTable])
                    SELECT [Specials].[ID],
                        [Sort],1,[Specials].[DateCreated],[DateInventoried],[Specials].[DateModified],[DatePurchased],[ReleaseDate],[DateVerified],
                        [Distributor],[Format],[Notes],[Price],[Subject],[Title],[Value],[WishList],[StoreBought],[WMV],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID],'Specials'
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Specials] [Specials]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Specials].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Specials].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Specials];
                    Select @Actual=Count(*) From [dbo].[Videos] Where [SourceTable]='Specials';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Videos].[ID],'Videos',[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Videos] [Videos] On [History].[TableName]='Specials' And [Videos].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Specials' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Specials' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Specials] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Select @OrphanedHistoryCount=Count(*) From [#DeletedHistory];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End;
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Specials';
                    Select @Actual=@OrphanedHistoryCount+Count(*) From [dbo].[History] Where [TableName]='Videos' And [History].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Specials');
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Videos: '+[Specials].[Title]),[Specials].[Title],'Videos',getdate(),getdate(),Null,Null,[Image],[Specials].[Title],Null,
                        [newSpecials].[ID],'Videos',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Specials] [Specials]
                        INNER JOIN [dbo].[Videos] [newSpecials] On [Specials].[ID]=[newSpecials].[OID]
                    WHERE [Specials].[Image] is not Null
                    ORDER BY [Specials].[ID];
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Videos: '+[Specials].[Title]),[Specials].[Title],'Videos',getdate(),getdate(),Null,Null,[OtherImage],[Specials].[Title],Null,
                        [newSpecials].[ID],'Videos',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Specials] [Specials]
                        INNER JOIN [dbo].[Videos] [newSpecials] On [Specials].[ID]=[newSpecials].[OID]
                    WHERE [Specials].[OtherImage] is not Null
                    ORDER BY [Specials].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Specials] Where [Image] is not Null;
                    Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Specials] Where [OtherImage] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Videos' And [Images].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Specials');
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateSpecials] to [Public];");
        }
        private static void CreateMigrateTools(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateTools");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateTools' And type='P') Drop Procedure sp_MigrateTools");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateTools.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateTools As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateTools';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Tools'
                    Delete From [dbo].[Tools];
                    INSERT INTO [dbo].[Tools] ([OID],
                        [Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[Manufacturer],[Name],
                        [Notes],[Price],[ProductCatalog],[Reference],[Value],[WishList],[LocationID])
                    SELECT [Tools].[ID],
                        1,[Tools].[DateCreated],[DateInventoried],[Tools].[DateModified],[DatePurchased],[DateVerified],[Manufacturer],[Tools].[Name],
                        [Notes],[Price],[ProductCatalog],[Reference],[Value],[WishList],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Tools] [Tools]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Tools].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Tools].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Tools];
                    Select @Actual=Count(*) From [dbo].[Tools];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='Tools';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Tools].[ID],[History].[TableName],[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Tools] [Tools] On [History].[TableName]='Tools' And [Tools].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Tools' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Tools' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Tools] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Select @OrphanedHistoryCount=Count(*) From [#DeletedHistory];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End;
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Tools';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Tools';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    Delete From [dbo].[Images] Where [TableName]='Tools';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Tools: '+[Tools].[Name]),[Tools].[Name],'Tools',getdate(),getdate(),Null,Null,[Image],[Tools].[Name],Null,
                        [newTools].[ID],'Tools',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Tools] [Tools]
                        INNER JOIN [dbo].[Tools] [newTools] On [Tools].[ID]=[newTools].[OID]
                    WHERE [Tools].[Image] is not Null
                    ORDER BY [Tools].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Tools] Where [Image] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Tools';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateTools] to [Public];");
        }
        private static void CreateMigrateTrains(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateTrains");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateTrains' And type='P') Drop Procedure sp_MigrateTrains");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateTrains.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateTrains As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateTrains';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Trains'
                    Delete From [dbo].[Trains];
                    INSERT INTO [dbo].[Trains] ([OID],
                        [Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateVerified],[Line],[Manufacturer],[Name],
                        [Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],[LocationID])
                    SELECT [Trains].[ID],
                        1,[Trains].[DateCreated],[DateInventoried],[Trains].[DateModified],[DatePurchased],[DateVerified],[Line],[Manufacturer],[Line],
                        [Notes],[Price],[ProductCatalog],[Reference],[Scale],[Type],[Value],[WishList],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Trains] [Trains]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Trains].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Trains].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Trains];
                    Select @Actual=Count(*) From [dbo].[Trains];
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    Delete From [dbo].[History] Where [TableName]='Trains';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Trains].[ID],[History].[TableName],[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [dbo].[Trains] [Trains] On [History].[TableName]='Trains' And [Trains].[OID]=[History].[RecordID]
                    WHERE [History].[TableName]='Trains' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Trains' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Trains] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Select @OrphanedHistoryCount=Count(*) From [#DeletedHistory];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End;
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Trains';
                    Select @Actual=Count(*) From [dbo].[History] Where [TableName]='Trains';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    Delete From [dbo].[Images] Where [TableName]='Trains';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Trains: '+[Trains].[Line]),[Trains].[Line],'Trains',getdate(),getdate(),Null,Null,[Image],[Trains].[Line],Null,
                        [newTrains].[ID],'Trains',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Trains] [Trains]
                        INNER JOIN [dbo].[Trains] [newTrains] On [Trains].[ID]=[newTrains].[OID]
                    WHERE [Trains].[Image] is not Null
                    ORDER BY [Trains].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Trains] Where [Image] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Trains';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateTrains] to [Public];");
        }
        private static void CreateMigrateVideoResearch(TCContext context)
        {
            Console.WriteLine("\tsp_MigrateVideoResearch");
            context.Database.ExecuteSqlCommand(@"If Exists(Select name From sysobjects Where name='sp_MigrateVideoResearch' And type='P') Drop Procedure sp_MigrateVideoResearch");
            context.Database.ExecuteSqlCommand(@"
            --sp_MigrateVideoResearch.sql
            --   SQL Server TreasureChest Database Converion to the EntityFramweork Version...
            --   Copyright © 2019 All Rights Reserved.
            --*********************************************************************************************************************************
            --
            --    Modification History:
            --    Date:       Developer:        Description:
            --    02/01/19    Ken Clark        Created;
            --=================================================================================================================================
            
            Create Procedure sp_MigrateVideoResearch As 
            Begin
                Declare @stTime DateTime; Set @stTime=CURRENT_TIMESTAMP;
                Declare @Actual int, @Expected int, @Message nvarchar(2000), @Milestone nvarchar(256)='sp_MigrateVideoResearch';
                Begin Transaction;
                Begin Try
                    exec sp_LogMessage @Milestone, 'Videos/Video Research'
                    Delete From [dbo].[Images] Where [TableName]='Videos' And [Images].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Video Research');
                    Delete From [dbo].[History] Where [TableName]='Videos' And [History].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Video Research');
                    Delete From [dbo].[Videos] Where [SourceTable]='Video Research';
                    INSERT INTO [dbo].[Videos] ([OID],
                        [AlphaSort],[Cataloged],[DateCreated],[DateInventoried],[DateModified],[DatePurchased],[DateReleased],[DateVerified],
                        [Distributor],[MediaFormat],[Notes],[Price],[Subject],[Title],[Value],[WishList],[StoreBought],[WMV],[LocationID],[SourceTable])
                    SELECT [Video Research].[ID],
                        [AlphaSort],1,[Video Research].[DateCreated],[DateInventoried],[Video Research].[DateModified],[DatePurchased],[ReleaseDate],[DateVerified],
                        [Distributor],[Format],[Notes],[Price],[Subject],[Title],[Value],[WishList],0,[WMV],
                        Case 
                            When [Locations].[ID] Is Null Then
                                Case 
                                    When [WishList]=1 Then [WishListLocation].[ID]
                                    Else [UnknownLocation].[ID]
                                End
                            Else [UnknownLocation].[ID]
                        End As [LocationID],'Video Research'
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Video Research] [Video Research]
                        LEFT OUTER JOIN [dbo].[Locations] [Locations] On [Video Research].[Location]=[Locations].[OName]
                        INNER JOIN [dbo].[Locations] [WishListLocation] On [WishListLocation].[Name]='WishList'
                        INNER JOIN [dbo].[Locations] [UnknownLocation] On [UnknownLocation].[Name]='Unknown'
                    ORDER BY [Video Research].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Video Research];
                    Select @Actual=Count(*) From [dbo].[Videos] Where [SourceTable]='Video Research';
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   History';
                    INSERT INTO [dbo].[History] ([OID],
                        [Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [History].[ID],
                        [History].[Column],[History].[DateChanged],getdate(),getdate(),[History].[OriginalValue],[Videos].[ID],'Videos',[History].[Value],[History].[Who]
                    FROM [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                        INNER JOIN [GGGSCP1].[TreasureChest].[dbo].[Video Research] [Video Research] On [History].[TableName]='Video Research' And [History].[RecordID]=[Video Research].[ID]
                        INNER JOIN [dbo].[Videos] [Videos] On [Video Research].[ID]=[Videos].[OID]
                            And [History].[RecordID]=[Video Research].[ID]
                    WHERE [History].[TableName]='Video Research' 
                    ORDER BY [History].[ID];
                    --Now grab any history for deleted records...
                    Declare @OrphanedHistoryCount int, @OID int, @RecordID uniqueidentifier;
                    If OBJECT_ID('tempdb..#DeletedHistory') Is Not Null Drop Table #DeletedHistory
                    Select [History].[ID],[History].[Column],[History].[DateChanged],getdate() As [DateCreated],getdate() As [DateModified],[History].[OriginalValue],
                        [History].[RecordID] As [OID],[History].[TableName],[History].[Value],[History].[Who],NEWID() As [RecordID]
                    Into #DeletedHistory 
                    From [GGGSCP1].[TreasureChest].[dbo].[History] [History]
                    Where [History].[TableName]='Video Research' And Not Exists(Select * From [GGGSCP1].[TreasureChest].[dbo].[Video Research] Where [ID]=[History].[RecordID])
                    Order By [History].[RecordID];
                    Select @OrphanedHistoryCount=Count(*) From [#DeletedHistory];
                    Declare h cursor for Select Distinct [OID] From [#DeletedHistory] Order By [OID];
                    Open h;
                    Fetch Next From h Into @OID;
                    While @@FETCH_STATUS = 0
                    Begin
                        Set @RecordID=NEWID();
                        Update [#DeletedHistory] Set [RecordID]=@RecordID Where [OID]=@OID;
                        Fetch Next From h Into @OID;
                    End;
                    Close h;
                    Deallocate h;
                    INSERT INTO [dbo].[History] ([OID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who])
                    SELECT [ID],[Column],[DateChanged],[DateCreated],[DateModified],[OriginalValue],[RecordID],[TableName],[Value],[Who] FROM [#DeletedHistory] ORDER BY [ID];
                    Drop Table #DeletedHistory;
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[History] Where [TableName]='Video Research';
                    Select @Actual=@OrphanedHistoryCount+Count(*) From [dbo].[History] Where [TableName]='Videos' And [History].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Video Research');
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
            
                    exec sp_LogMessage @Milestone, '   Images';
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Videos: '+[Video Research].[Title]),[Video Research].[Title],'Videos',getdate(),getdate(),Null,Null,[Image],[Video Research].[Title],Null,
                        [newVideo Research].[ID],'Videos',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Video Research] [Video Research]
                        INNER JOIN [dbo].[Videos] [newVideo Research] On [Video Research].[ID]=[newVideo Research].[OID]
                    WHERE [Video Research].[Image] is not Null
                    ORDER BY [Video Research].[ID];
                    INSERT INTO [dbo].[Images] ([OID],
                        [AlphaSort],[Caption],[Category],[DateCreated],[DateModified],[FileName],[Height],[Image],[Name],[Notes],
                        [RecordID],[TableName],[Thumbnail],[URL],[Width])
                    SELECT Null,Upper('Videos: '+[Video Research].[Title]),[Video Research].[Title],'Videos',getdate(),getdate(),Null,Null,[OtherImage],[Video Research].[Title],Null,
                        [newVideo Research].[ID],'Videos',0,Null,Null
                    FROM [GGGSCP1].[TreasureChest].[dbo].[Video Research] [Video Research]
                        INNER JOIN [dbo].[Videos] [newVideo Research] On [Video Research].[ID]=[newVideo Research].[OID]
                    WHERE [Video Research].[OtherImage] is not Null
                    ORDER BY [Video Research].[ID];
                    Select @Expected=Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Video Research] Where [Image] is not Null;
                    Select @Expected=@Expected+Count(*) From [GGGSCP1].[TreasureChest].[dbo].[Video Research] Where [OtherImage] is not Null;
                    Select @Actual=Count(*) From [dbo].[Images] Where [TableName]='Videos' And [Images].[RecordID] In (Select ID From [dbo].[Videos] Where [SourceTable]='Video Research');
                    If @Actual <> @Expected Begin 
                        Set @Message='Actual ('+Convert(nvarchar(10),@Actual)+') count does not match expected ('+Convert(nvarchar(10),@Expected)+') - Difference of '+Convert(nvarchar(10),@Actual-@Expected);
                        Throw 50000, @Message, 1;
                    End;
                End Try
                Begin Catch
                    Rollback Transaction;
                    exec sp_LogError @Milestone;
                    Throw;
                End Catch;
                exec sp_LogElapsed @Milestone, @stTime;
                Commit Transaction;
            End;");
            context.Database.ExecuteSqlCommand(@"Grant Execute on [dbo].[sp_MigrateVideoResearch] to [Public];");
        }
        #endregion
        private static void CreateSQLFunctions(TCContext context)
        {
            Console.WriteLine("Creating Functions...");
            CreateParsePathFunctions(context);
        }
        private static void CreateSQLStoredProcedures(TCContext context)
        {
            Console.WriteLine("Creating Stored Procedures...");
            CreateLogElapsed(context);
            CreateLogError(context);
            CreateLogMessage(context);
            CreatePrepDataMigration(context);
            CreateMigrateAircraftDesignations(context);
            CreateMigrateBlueAngelsHistory(context);
            CreateMigrateBooks(context);
            CreateMigrateCollectables(context);
            CreateMigrateCompanies(context);
            CreateMigrateDecals(context);
            CreateMigrateDetailSets(context);
            CreateMigrateEpisodes(context);
            CreateMigrateFinishingProducts(context);
            CreateMigrateImages(context);
            CreateMigrateKits(context);
            CreateMigrateMovies(context);
            CreateMigrateMusic(context);
            CreateMigrateQueries(context);
            CreateMigrateRockets(context);
            CreateMigrateShipClasses(context);
            CreateMigrateShipClassTypes(context);
            CreateMigrateShips(context);
            CreateMigrateSoftware(context);
            CreateMigrateSpecials(context);
            CreateMigrateTools(context);
            CreateMigrateTrains(context);
            CreateMigrateVideoResearch(context);
            CreateTableSpaceUsed(context);
            CreateDataMigration(context);
        }
        private static void CreateSQLViews(TCContext context)
        {
            Console.WriteLine("Creating Views...");
            CreateMusicViews(context);
        }
        #endregion
        public static void Seed(TCContext context)
        {
            CreateSQLFunctions(context);
            //CreateSQLViews(context);
            CreateSQLStoredProcedures(context);
            SeedData(context);
        }
    }
}
