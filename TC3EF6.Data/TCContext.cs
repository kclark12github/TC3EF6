using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Annotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC3EF6.Domain.Annotations;
using TC3EF6.Domain.Classes;
using TC3EF6.Domain.Classes.Reference;
using TC3EF6.Domain.Classes.Stash;
using TC3EF6.Domain.Interfaces;

namespace TC3EF6.Data
{
    public interface IDbContext : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        DbEntityEntry Entry(object entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();

        DbSet<Log> Log { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Collectable> Collectables { get; set; }
        #region Hobby
        DbSet<Kit> Kits { get; set; }
        DbSet<Decal> Decals { get; set; }
        DbSet<DetailSet> DetailSets { get; set; }
        DbSet<FinishingProduct> FinishingProducts { get; set; }

        DbSet<Tool> Tools { get; set; }
        //DbSet<VideoResearch> VideoResearch { get; set; }

        DbSet<Rocket> Rockets { get; set; }
        DbSet<Train> Trains { get; set; }

        DbSet<Company> Companies { get; set; }

        DbSet<AircraftDesignation> AircraftDesignations { get; set; }
        DbSet<BlueAngelsHistory> BlueAngelsHistories { get; set; }
        #endregion
        #region Music
        DbSet<Album> Albums { get; set; }
        DbSet<Artist> Artists { get; set; }
        DbSet<Track> Tracks { get; set; }
        #endregion
        DbSet<Software> Software { get; set; }
        #region US Navy
        DbSet<ShipClass> ShipClasses { get; set; }
        DbSet<ShipClassType> ShipClassTypes { get; set; }
        DbSet<Ship> Ships { get; set; }
        #endregion
        #region Video Library
        DbSet<Episode> Episodes { get; set; }
        DbSet<Video> Videos { get; set; }
        #endregion
        #region Miscellaneous
        DbSet<History> Histories { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Query> Queries { get; set; }
        #endregion
    }
    public class TCContext : DbContext, IDbContext
    {
        public TCContext() : base("name=TC3EF6Context") //Represents ConnectionString name...
        {
            Database.SetInitializer<TCContext>(null);
            //UserName = this.Database.ExecuteSqlCommand("SELECT SUSER_NAME()", );
        }
        public TCContext(string connectionString) : base(connectionString) //Represents ConnectionString name...
        {
            Database.SetInitializer<TCContext>(null);
            //UserName = this.Database.ExecuteSqlCommand("SELECT SUSER_NAME()", );
        }
        public static TCContext Create()
        {
            return new TCContext();
        }

        IQueryable<T> IDbContext.Query<T>()
        {
            return Set<T>();
        }
        void IDbContext.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }
        void IDbContext.Update<T>(T entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
        void IDbContext.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Collectable> Collectables { get; set; }
        #region Hobby
        public virtual DbSet<Kit> Kits { get; set; }
        public virtual DbSet<Decal> Decals { get; set; }
        public virtual DbSet<DetailSet> DetailSets { get; set; }
        public virtual DbSet<FinishingProduct> FinishingProducts { get; set; }

        public virtual DbSet<Tool> Tools { get; set; }
        //public virtual DbSet<VideoResearch> VideoResearch { get; set; }

        public virtual DbSet<Rocket> Rockets { get; set; }
        public virtual DbSet<Train> Trains { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<AircraftDesignation> AircraftDesignations { get; set; }
        public virtual DbSet<BlueAngelsHistory> BlueAngelsHistories { get; set; }
        #endregion
        #region Music
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        #endregion
        public virtual DbSet<Software> Software { get; set; }
        #region US Navy
        public virtual DbSet<ShipClass> ShipClasses { get; set; }
        public virtual DbSet<ShipClassType> ShipClassTypes { get; set; }
        public virtual DbSet<Ship> Ships { get; set; }
        #endregion
        #region Video Library
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        #endregion
        #region Miscellaneous
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Query> Queries { get; set; }
        #endregion
        private void ConfigureAlternateIndexes(DbModelBuilder modelBuilder)
        {
            #region Books
            modelBuilder.Entity<Book>().Property(p => p.ID)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_BooksByAlphaSort", 2) { IsUnique = true},
                    new IndexAttribute("IX_BooksByAuthor", 2) { IsUnique = true},
                    new IndexAttribute("IX_BooksByFormat", 3) { IsUnique = true},
                    new IndexAttribute("IX_BooksByISBN", 2) { IsUnique = true},
                    new IndexAttribute("IX_BooksBySubject", 2) { IsUnique = true},
                    new IndexAttribute("IX_BooksByTitle", 2) { IsUnique = true}
                }));
            modelBuilder.Entity<Book>().Property(p => p.AlphaSort)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_BooksByAlphaSort", 1),
                    new IndexAttribute("IX_BooksByFormat", 2)
                }));
            modelBuilder.Entity<Book>().Property(p => p.Author)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_BooksByAuthor", 1)
                }));
            modelBuilder.Entity<Book>().Property(p => p.MediaFormat)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_BooksByFormat", 1)
                }));
            modelBuilder.Entity<Book>().Property(p => p.ISBN)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_BooksByISBN", 1)
                }));
            modelBuilder.Entity<Book>().Property(p => p.Subject)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_BooksBySubject", 1)
                }));
            modelBuilder.Entity<Book>().Property(p => p.Title)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_BooksByTitle", 1)
                }));
            //TODO: EFCore...
            //modelBuilder.Entity<Book>().HasIndex(i => new { i.AlphaSort, i.ID }).IsUnique().HasName("IX_BooksByAlphaSort");
            //modelBuilder.Entity<Book>().HasIndex(i => new { i.Author, i.ID }).IsUnique().HasName("IX_BooksByAuthor");
            //modelBuilder.Entity<Book>().HasIndex(i => new { i.MediaFormat, i.AlphaSort, i.ID }).IsUnique().HasName("IX_BooksByFormat");
            //modelBuilder.Entity<Book>().HasIndex(i => new { i.ISBN, i.ID }).IsUnique().HasName("IX_BooksByISBN");
            //modelBuilder.Entity<Book>().HasIndex(i => new { i.Subject, i.ID }).IsUnique().HasName("IX_BooksBySubject");
            //modelBuilder.Entity<Book>().HasIndex(i => new { i.Title, i.ID }).IsUnique().HasName("IX_BooksByTitle");
            #endregion
            #region Collectables
            modelBuilder.Entity<Collectable>().Property(p => p.ID)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_CollectablesByName", 5) { IsUnique = true},
                    new IndexAttribute("IX_CollectablesBySeries", 4) { IsUnique = true},
                    new IndexAttribute("IX_CollectablesByType", 4) { IsUnique = true}
                }));
            modelBuilder.Entity<Collectable>().Property(p => p.Name)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_CollectablesByName", 1)
                }));
            modelBuilder.Entity<Collectable>().Property(p => p.Series)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_CollectablesByName", 2),
                    new IndexAttribute("IX_CollectablesBySeries", 1),
                    new IndexAttribute("IX_CollectablesByType", 2)
                }));
            modelBuilder.Entity<Collectable>().Property(p => p.Type)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_CollectablesByName", 3),
                    new IndexAttribute("IX_CollectablesBySeries", 2),
                    new IndexAttribute("IX_CollectablesByType", 1)
                }));
            modelBuilder.Entity<Collectable>().Property(p => p.Reference)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_CollectablesByName", 4),
                    new IndexAttribute("IX_CollectablesBySeries", 3),
                    new IndexAttribute("IX_CollectablesByType", 3)
                }));
            //TODO: EFCore...
            //modelBuilder.Entity<Collectable>().HasIndex(i => new { i.Name, i.Series, i.Type, i.Reference, i.ID }).IsUnique().HasName("IX_CollectablesByName");
            //modelBuilder.Entity<Collectable>().HasIndex(i => new { i.Series, i.Type, i.Reference, i.ID }).IsUnique().HasName("IX_CollectablesBySeries");
            //modelBuilder.Entity<Collectable>().HasIndex(i => new { i.Type, i.Series, i.Reference, i.ID }).IsUnique().HasName("IX_CollectablesByType");
            #endregion
            #region Hobby
                #region Kits
                modelBuilder.Entity<Kit>().Property(p => p.ID)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_KitsByDesignation", 4) { IsUnique = true},
                        new IndexAttribute("IX_KitsByManufacturer", 2) { IsUnique = true},
                        new IndexAttribute("IX_KitsByName", 3) { IsUnique = true},
                        new IndexAttribute("IX_KitsByNationServiceEra", 4) { IsUnique = true},
                        new IndexAttribute("IX_KitsByScale", 4) { IsUnique = true},
                        new IndexAttribute("IX_KitsByType", 3) { IsUnique = true}
                    }));
                modelBuilder.Entity<Kit>().Property(p => p.Type)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_KitsByDesignation", 1),
                        new IndexAttribute("IX_KitsByScale", 2),
                        new IndexAttribute("IX_KitsByType", 1)
                    }));
                modelBuilder.Entity<Kit>().Property(p => p.Designation)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_KitsByDesignation", 2)
                    }));
                modelBuilder.Entity<Kit>().Property(p => p.Scale)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_KitsByDesignation", 3),
                        new IndexAttribute("IX_KitsByName", 2),
                        new IndexAttribute("IX_KitsByScale", 1),
                        new IndexAttribute("IX_KitsByType", 2)
                    }));
                modelBuilder.Entity<Kit>().Property(p => p.Manufacturer)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_KitsByManufacturer", 1),
                        new IndexAttribute("IX_KitsByScale", 3)
                    }));
                modelBuilder.Entity<Kit>().Property(p => p.Name)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_KitsByName", 1)
                    }));
                modelBuilder.Entity<Kit>().Property(p => p.Nation)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_KitsByNationServiceEra", 1)
                    }));
                modelBuilder.Entity<Kit>().Property(p => p.Service)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_KitsByNationServiceEra", 2)
                    }));
                modelBuilder.Entity<Kit>().Property(p => p.Era)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_KitsByNationServiceEra", 3)
                    }));
                //TODO: EFCore...
                //modelBuilder.Entity<Kit>().HasIndex(i => new { i.Type, i.Designation, i.Scale, i.ID }).IsUnique().HasName("IX_KitsByDesignation");
                //modelBuilder.Entity<Kit>().HasIndex(i => new { i.Manufacturer, i.ID }).IsUnique().HasName("IX_KitsByManufacturer");
                //modelBuilder.Entity<Kit>().HasIndex(i => new { i.Name, i.Scale, i.ID }).IsUnique().HasName("IX_KitsByName");
                //modelBuilder.Entity<Kit>().HasIndex(i => new { i.Nation, i.Service, i.Era, i.ID }).IsUnique().HasName("IX_KitsByNationServiceEra");
                //modelBuilder.Entity<Kit>().HasIndex(i => new { i.Scale, i.Type, i.Manufacturer, i.ID }).IsUnique().HasName("IX_KitsByScale");
                //modelBuilder.Entity<Kit>().HasIndex(i => new { i.Type, i.Scale, i.ID }).IsUnique().HasName("IX_KitsByType");
                #endregion
                #region Decals
                modelBuilder.Entity<Decal>().Property(p => p.ID)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_DecalsByDesignation", 4) { IsUnique = true},
                        new IndexAttribute("IX_DecalsByManufacturer", 2) { IsUnique = true},
                        new IndexAttribute("IX_DecalsByName", 3) { IsUnique = true},
                        new IndexAttribute("IX_DecalsByScale", 4) { IsUnique = true},
                        new IndexAttribute("IX_DecalsByType", 3) { IsUnique = true}
                    }));
                modelBuilder.Entity<Decal>().Property(p => p.Type)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_DecalsByDesignation", 1),
                        new IndexAttribute("IX_DecalsByScale", 2),
                        new IndexAttribute("IX_DecalsByType", 1)
                    }));
                modelBuilder.Entity<Decal>().Property(p => p.Designation)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_DecalsByDesignation", 2)
                    }));
                modelBuilder.Entity<Decal>().Property(p => p.Scale)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_DecalsByDesignation", 3),
                        new IndexAttribute("IX_DecalsByName", 2),
                        new IndexAttribute("IX_DecalsByScale", 1),
                        new IndexAttribute("IX_DecalsByType", 2)
                    }));
                modelBuilder.Entity<Decal>().Property(p => p.Manufacturer)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_DecalsByManufacturer", 1),
                        new IndexAttribute("IX_DecalsByScale", 3)
                    }));
                modelBuilder.Entity<Decal>().Property(p => p.Name)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_DecalsByName", 1)
                    }));
                //TODO: EFCore...
                //modelBuilder.Entity<Decal>().HasIndex(i => new { i.Type, i.Designation, i.Scale, i.ID }).IsUnique().HasName("IX_DecalsByDesignation");
                //modelBuilder.Entity<Decal>().HasIndex(i => new { i.Manufacturer, i.ID }).IsUnique().HasName("IX_DecalsByManufacturer");
                //modelBuilder.Entity<Decal>().HasIndex(i => new { i.Name, i.Scale, i.ID }).IsUnique().HasName("IX_DecalsByName");
                //modelBuilder.Entity<Decal>().HasIndex(i => new { i.Scale, i.Type, i.Manufacturer, i.ID }).IsUnique().HasName("IX_DecalsByScale");
                //modelBuilder.Entity<Decal>().HasIndex(i => new { i.Type, i.Scale, i.ID }).IsUnique().HasName("IX_DecalsByType");
                #endregion
                #region DetailSets
                modelBuilder.Entity<DetailSet>().Property(p => p.ID)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_DetailSetsByDesignation", 4) { IsUnique = true},
                        new IndexAttribute("IX_DetailSetsByManufacturer", 2) { IsUnique = true},
                        new IndexAttribute("IX_DetailSetsByName", 3) { IsUnique = true},
                        new IndexAttribute("IX_DetailSetsByScale", 4) { IsUnique = true},
                        new IndexAttribute("IX_DetailSetsByType", 3) { IsUnique = true}
                    }));
                modelBuilder.Entity<DetailSet>().Property(p => p.Type)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_DetailSetsByDesignation", 1),
                        new IndexAttribute("IX_DetailSetsByScale", 2),
                        new IndexAttribute("IX_DetailSetsByType", 1)
                    }));
                modelBuilder.Entity<DetailSet>().Property(p => p.Designation)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_DetailSetsByDesignation", 2)
                    }));
                modelBuilder.Entity<DetailSet>().Property(p => p.Scale)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_DetailSetsByDesignation", 3),
                        new IndexAttribute("IX_DetailSetsByName", 2),
                        new IndexAttribute("IX_DetailSetsByScale",1 ),
                        new IndexAttribute("IX_DetailSetsByType", 2)
                    }));
                modelBuilder.Entity<DetailSet>().Property(p => p.Manufacturer)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_DetailSetsByManufacturer", 1),
                        new IndexAttribute("IX_DetailSetsByScale", 3)
                    }));
                modelBuilder.Entity<DetailSet>().Property(p => p.Name)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_DetailSetsByName", 1)
                    }));
                //TODO: EFCore...
                //modelBuilder.Entity<DetailSet>().HasIndex(i => new { i.Type, i.Designation, i.Scale, i.ID }).IsUnique().HasName("IX_DetailSetsByDesignation");
                //modelBuilder.Entity<DetailSet>().HasIndex(i => new { i.Manufacturer, i.ID }).IsUnique().HasName("IX_DetailSetsByManufacturer");
                //modelBuilder.Entity<DetailSet>().HasIndex(i => new { i.Name, i.Scale, i.ID }).IsUnique().HasName("IX_DetailSetsByName");
                //modelBuilder.Entity<DetailSet>().HasIndex(i => new { i.Scale, i.Type, i.Manufacturer, i.ID }).IsUnique().HasName("IX_DetailSetsByScale");
                //modelBuilder.Entity<DetailSet>().HasIndex(i => new { i.Type, i.Scale, i.ID }).IsUnique().HasName("IX_DetailSetsByType");
                #endregion
                #region AircraftDesignations
                modelBuilder.Entity<AircraftDesignation>().Property(p => p.ID)
                        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                        new IndexAnnotation(new[]
                        {
                            new IndexAttribute("IX_AircraftDesignationsByDesignation", 2) { IsUnique = true}
                        }));
                    modelBuilder.Entity<AircraftDesignation>().Property(p => p.Designation)
                        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                        new IndexAnnotation(new[]
                        {
                            new IndexAttribute("IX_AircraftDesignationsByDesignation", 1)
                        }));
            //TODO: EFCore...
            //modelBuilder.Entity<AircraftDesignation>().HasIndex(i => new { i.Designation, i.ID }).IsUnique().HasName("IX_AircraftDesignationsByDesignation");
            #endregion
            #endregion
            #region Music
            #region Albums
            modelBuilder.Entity<Album>().Property(p => p.AlphaSort)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_AlbumsByAlphaSort", 1)
                }));
            modelBuilder.Entity<Album>().Property(p => p.Artist)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_AlbumsByArtist", 1),
                    new IndexAttribute("IX_AlbumsByFormat", 2),
                    new IndexAttribute("IX_AlbumsByType", 2)
                }));
            modelBuilder.Entity<Album>().Property(p => p.Year)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_AlbumsByArtist", 2),
                    new IndexAttribute("IX_AlbumsByFormat", 3),
                    new IndexAttribute("IX_AlbumsByType", 3)
                }));
            modelBuilder.Entity<Album>().Property(p => p.MediaFormat)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_AlbumsByFormat", 1),
                    new IndexAttribute("IX_AlbumsByAlphaSort", 2),
                    new IndexAttribute("IX_AlbumsByArtist", 3),
                    new IndexAttribute("IX_AlbumsByType", 4)
                }));
            modelBuilder.Entity<Album>().Property(p => p.ID)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_AlbumsByAlphaSort", 3) { IsUnique = true},
                    new IndexAttribute("IX_AlbumsByArtist", 4) { IsUnique = true},
                    new IndexAttribute("IX_AlbumsByFormat", 4) { IsUnique = true},
                    new IndexAttribute("IX_AlbumsByType", 5) { IsUnique = true}
                }));
            modelBuilder.Entity<Album>().Property(p => p.Type)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_AlbumsByType", 1)
                }));
            //TODO: EFCore...
            //modelBuilder.Entity<Album>().HasIndex(i => new { i.AlphaSort, i.MediaFormat, i.ID }).IsUnique().HasName("IX_AlbumsByAlphaSort");
            //modelBuilder.Entity<Album>().HasIndex(i => new { i.Artist, i.Year, i.MediaFormat, i.ID }).IsUnique().HasName("IX_AlbumsByArtist");
            //modelBuilder.Entity<Album>().HasIndex(i => new { i.MediaFormat, i.Artist, i.Year, i.ID }).IsUnique().HasName("IX_AlbumsByFormat");
            //modelBuilder.Entity<Album>().HasIndex(i => new { i.Type, i.Artist, i.Year, i.MediaFormat, i.ID }).IsUnique().HasName("IX_AlbumsByType");
            #endregion
            #region Artists
            modelBuilder.Entity<Artist>().Property(p => p.AlphaSort)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                        new IndexAttribute("IX_ArtistsByAlphaSort", 1) { IsUnique = true}
                }));
            modelBuilder.Entity<Artist>().Property(p => p.ID)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                        new IndexAttribute("IX_ArtistsByAlphaSort", 2) { IsUnique = true}
                }));
            //TODO: EFCore...
            //modelBuilder.Entity<Artist>().HasIndex(i => new { i.AlphaSort, i.ID }).IsUnique().HasName("IX_ArtistsByAlphaSort");
            #endregion
            #region Tracks
            modelBuilder.Entity<Track>().Property(p => p.AlbumID)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                        new IndexAttribute("IX_TracksByAlbum", 1) { IsUnique = true}
                }));
            modelBuilder.Entity<Track>().Property(p => p.ArtistID)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                        new IndexAttribute("IX_TracksByArtist", 1) { IsUnique = true}
                }));
            modelBuilder.Entity<Track>().Property(p => p.Year)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                        new IndexAttribute("IX_TracksByAlbum", 2) { IsUnique = true},
                        new IndexAttribute("IX_TracksByArtist", 2) { IsUnique = true}
                }));
            modelBuilder.Entity<Track>().Property(p => p.DiscNumber)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                        new IndexAttribute("IX_TracksByAlbum", 3) { IsUnique = true},
                        new IndexAttribute("IX_TracksByArtist", 3) { IsUnique = true}
                }));
            modelBuilder.Entity<Track>().Property(p => p.TrackNumber)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                        new IndexAttribute("IX_TracksByAlbum", 4) { IsUnique = true},
                        new IndexAttribute("IX_TracksByArtist", 4) { IsUnique = true}
                }));
            modelBuilder.Entity<Track>().Property(p => p.Title)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                        new IndexAttribute("IX_TracksByAlbum", 5) { IsUnique = true},
                        new IndexAttribute("IX_TracksByArtist", 5) { IsUnique = true}
                }));
            modelBuilder.Entity<Track>().Property(p => p.ID)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                        new IndexAttribute("IX_TracksByAlbum", 6) { IsUnique = true},
                        new IndexAttribute("IX_TracksByArtist", 6) { IsUnique = true}
                }));
            //TODO: EFCore...
            //modelBuilder.Entity<Track>().HasIndex(i => new { i.AlbumID, i.Year, i.DiscNumber, i.TrackNumber, i.Title, i.ID }).IsUnique().HasName("IX_TracksByAlbum");
            //modelBuilder.Entity<Track>().HasIndex(i => new { i.AlbumArtistID, i.Year, i.DiscNumber, i.TrackNumber, i.Title, i.ID }).IsUnique().HasName("IX_TracksByArtist");
            #endregion
            #endregion
            #region Software
            modelBuilder.Entity<Software>().Property(p => p.ID)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_SoftwareByAlphaSort", 2) { IsUnique = true},
                    new IndexAttribute("IX_SoftwareByPlatform", 3) { IsUnique = true},
                    new IndexAttribute("IX_SoftwareByType", 3) { IsUnique = true}
                }));
            modelBuilder.Entity<Software>().Property(p => p.AlphaSort)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_SoftwareByAlphaSort", 1),
                    new IndexAttribute("IX_SoftwareByPlatform", 2),
                    new IndexAttribute("IX_SoftwareByType", 2)
                }));
            modelBuilder.Entity<Software>().Property(p => p.Platform)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_SoftwareByPlatform", 1)
                }));
            modelBuilder.Entity<Software>().Property(p => p.Type)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_SoftwareByType", 1)
                }));
            //TODO: EFCore...
            //modelBuilder.Entity<Software>().HasIndex(i => new { i.AlphaSort, i.ID }).IsUnique().HasName("IX_SoftwareByAlphaSort");
            //modelBuilder.Entity<Software>().HasIndex(i => new { i.Platform, i.AlphaSort, i.ID }).IsUnique().HasName("IX_SoftwareByPlatform");
            //modelBuilder.Entity<Software>().HasIndex(i => new { i.Type, i.AlphaSort, i.ID }).IsUnique().HasName("IX_SoftwareByType");
            #endregion
            #region US Navy
                #region Ships
                modelBuilder.Entity<Ship>().Property(p => p.ID)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_ShipsByHullNumber", 2) { IsUnique = true},
                        new IndexAttribute("IX_ShipsByName", 2) { IsUnique = true}
                    }));
                modelBuilder.Entity<Ship>().Property(p => p.HullNumber)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_ShipsByHullNumber", 1)
                    }));
                modelBuilder.Entity<Ship>().Property(p => p.Name)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_ShipsByName", 1)
                    }));
                //TODO: EFCore...
                //modelBuilder.Entity<Ship>().HasIndex(i => new { i.HullNumber, i.ID }).IsUnique().HasName("IX_ShipsByHullNumber");
                //modelBuilder.Entity<Ship>().HasIndex(i => new { i.Name, i.ID }).IsUnique().HasName("IX_ShipsByName");
                #endregion
                #region ShipClasses
                modelBuilder.Entity<ShipClass>().Property(p => p.ID)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_ShipClassesByType", 2) { IsUnique = true},
                        new IndexAttribute("IX_ShipClassesByName", 2) { IsUnique = true}
                    }));
                //modelBuilder.Entity<ShipClass>().Property(p => p.ShipClassType)
                //    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                //    new IndexAnnotation(new[]
                //    {
                //        new IndexAttribute("IX_ShipClassesByType", 1)
                //    }));
                modelBuilder.Entity<ShipClass>().Property(p => p.Name)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_ShipClassesByName", 1)
                    }));
                //TODO: EFCore...
                ////modelBuilder.Entity<ShipClass>().HasIndex(i => new { i.ShipClassType, i.ID }).IsUnique().HasName("IX_ShipClassesByType");
                //modelBuilder.Entity<ShipClass>().HasIndex(i => new { i.Name, i.ID }).IsUnique().HasName("IX_ShipClassesByName");
                #endregion
                #region ShipClassTypes
                modelBuilder.Entity<ShipClassType>().Property(p => p.ID)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_ShipClassTypesByType", 2) { IsUnique = true}
                    }));
                modelBuilder.Entity<ShipClassType>().Property(p => p.TypeCode)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_ShipClassTypesByType", 1)
                    }));
                //TODO: EFCore...
                //modelBuilder.Entity<ShipClassType>().HasIndex(i => new { i.TypeCode, i.ID }).IsUnique().HasName("IX_ShipClassTypesByType");
                #endregion
            #endregion
            #region Video Library
                #region Episodes
                modelBuilder.Entity<Episode>().Property(p => p.ID)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_EpisodesByFormat", 4) { IsUnique = true},
                        new IndexAttribute("IX_EpisodesBySeries", 3) { IsUnique = true},
                        new IndexAttribute("IX_EpisodesBySubject", 2) { IsUnique = true}
                    }));
                modelBuilder.Entity<Episode>().Property(p => p.MediaFormat)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_EpisodesByFormat", 1)
                    }));
                modelBuilder.Entity<Episode>().Property(p => p.Series)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_EpisodesByFormat", 2),
                        new IndexAttribute("IX_EpisodesBySeries", 1)
                    }));
                modelBuilder.Entity<Episode>().Property(p => p.Number)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_EpisodesByFormat", 3),
                        new IndexAttribute("IX_EpisodesBySeries", 2)
                    }));
                modelBuilder.Entity<Episode>().Property(p => p.Subject)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_EpisodesBySubject", 1)
                    }));
                //TODO: EFCore...
                //modelBuilder.Entity<Episode>().HasIndex(i => new { i.MediaFormat, i.Series, i.Number, i.ID }).IsUnique().HasName("IX_EpisodesByFormat");
                //modelBuilder.Entity<Episode>().HasIndex(i => new { i.Series, i.Number, i.ID }).IsUnique().HasName("IX_EpisodesBySeries");
                //modelBuilder.Entity<Episode>().HasIndex(i => new { i.Subject, i.ID }).IsUnique().HasName("IX_EpisodesBySubject");
                #endregion
                #region Movies
                modelBuilder.Entity<Video>().Property(p => p.ID)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_VideosByFormat", 3) { IsUnique = true},
                        new IndexAttribute("IX_VideosBySort", 3) { IsUnique = true},
                        new IndexAttribute("IX_VideosBySubject", 3) { IsUnique = true},
                        new IndexAttribute("IX_VideosByTitle", 3) { IsUnique = true}
                    }));
                modelBuilder.Entity<Video>().Property(p => p.MediaFormat)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_VideosByFormat", 1),
                        new IndexAttribute("IX_VideosBySort", 2),
                        new IndexAttribute("IX_VideosByTitle", 2)
                    }));
                modelBuilder.Entity<Video>().Property(p => p.AlphaSort)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_VideosByFormat", 2),
                        new IndexAttribute("IX_VideosBySort", 1)
                    }));
                modelBuilder.Entity<Video>().Property(p => p.Subject)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_VideoBySubject", 1)
                    }));
                modelBuilder.Entity<Video>().Property(p => p.Title)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_VideosByTitle", 1)
                    }));
                //TODO: EFCore...
                //modelBuilder.Entity<Video>().HasIndex(i => new { i.MediaFormat, i.AlphaSort, i.ID }).IsUnique().HasName("IX_VideosByFormat");
                //modelBuilder.Entity<Video>().HasIndex(i => new { i.AlphaSort, i.MediaFormat, i.ID }).IsUnique().HasName("IX_VideosBySort");
                //modelBuilder.Entity<Video>().HasIndex(i => new { i.Subject, i.Title, i.ID }).IsUnique().HasName("IX_VideosBySubject");
                //modelBuilder.Entity<Video>().HasIndex(i => new { i.Title, i.MediaFormat, i.ID }).IsUnique().HasName("IX_VideosByTitle");
                #endregion
            #endregion
            #region Miscellaneous
            #region FileLists
            //modelBuilder.Entity<FileList>().HasIndex(i => new { i.Path }).IsUnique().HasName("IX_FileListByPath");
            #endregion
            #region MenuEntries
            //modelBuilder.Entity<MenuEntries>().HasIndex(i => new { i.ButtonLabel, i.ParentID, i.Label, i.ID }).IsUnique().HasName("IX_MenuEntriesByButton");
            //modelBuilder.Entity<MenuEntries>().HasIndex(i => new { i.ParentID, i.ButtonLabel, i.Label, i.ID }).IsUnique().HasName("IX_MenuEntriesByParentID");
            #endregion
            #endregion
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            CustomConventions.Add(modelBuilder);
            ConfigureAlternateIndexes(modelBuilder);
            //Define <ImageDetail>'s primary key to be the TableName/RecordID composite...

            //TODO:          modelBuilder.Entity<Video_Research>().Property(e => e.Format).IsUnicode(false);
            //TODO:          modelBuilder.Entity<Query>().Property(e => e.Name).IsUnicode(false);
            //TODO:          modelBuilder.Entity<Query>().Property(e => e.Description).IsUnicode(false);
            //TODO:          modelBuilder.Entity<Query>().Property(e => e.Query1).IsUnicode(false);


            base.OnModelCreating(modelBuilder);
        }
        public void SaveHistory(System.Data.Entity.Infrastructure.DbEntityEntry<IDataEntity> entry)
        {
            Guid ID = ((IDataEntity)entry.Entity).ID;
            string tableName = entry.Entity.GetType().Name;
            tableName = tableName == "Image" ? "Images" : TypeToTableName(entry.Entity.GetType().Name);
            DateTime dateChanged = DateTime.Now;
            EntityState entityState = entry.State;
            foreach (var propName in entry.CurrentValues.PropertyNames.Where(p => p.Trim() != "RowID"))
            {
                var original = entry.State == EntityState.Added ? "Record Added" : entry.OriginalValues[propName]?.ToString();
                var current = entry.State == EntityState.Deleted ? "Record Deleted" : entry.CurrentValues[propName]?.ToString();
                History history = null;
                switch (entry.State)
                {
                    case EntityState.Added:
                        history = new History
                        {
                            TableName = tableName,
                            RecordID = ID,
                            Column = propName,
                            OriginalValue = original,
                            Value = current,
                            DateCreated = dateChanged,
                            DateModified = dateChanged,
                            DateChanged = dateChanged,
                            Who = "System"
                        };
                        Debug.WriteLine("Record Added: {0}.ID #{1}: {2} {3}", tableName, ID, propName, current == null ? "Null" : $"\"{current}\"");
                        break;
                    case EntityState.Deleted:
                        history = new History
                        {
                            TableName = tableName,
                            RecordID = ID,
                            Column = propName,
                            OriginalValue = original,
                            Value = current,
                            DateCreated = dateChanged,
                            DateModified = dateChanged,
                            DateChanged = dateChanged,
                            Who = "System"
                        };
                        Debug.WriteLine("Record Deleted: {0}.ID #{1}: {2} {3}", tableName, ID, propName, original == null ? "Null" : $"\"{original}\"");
                        break;
                    case EntityState.Modified:
                        if (original != current)
                        {
                            Debug.WriteLine("{0}.ID #{1}: {2} changed from {3} to {4}", tableName, ID, propName, original == null ? "Null" : $"\"{original}\"", current == null ? "Null" : $"\"{current}\"");
                            history = new History
                            {
                                TableName = tableName,
                                RecordID = ID,
                                Column = propName,
                                OriginalValue = original,
                                Value = current,
                                DateCreated = dateChanged,
                                DateModified = dateChanged,
                                DateChanged = dateChanged,
                                Who = "System"
                            };
                        }
                        break;
                    default:
                        break;
                }
                if (history != null)
                    Histories.Add(history);
            }
        }
        public override int SaveChanges()
        {
            //Use the context's tracking information to add any History transactions...
            DateTime timestamp = DateTime.Now;
            foreach (var entry in this.ChangeTracker.Entries<IDataEntity>()
                    .Where(e => e.State != EntityState.Unchanged && e.State != EntityState.Detached))
            {
                entry.Entity.DateModified = timestamp;
                if (entry.Entity.DateCreated == DateTime.MinValue)
                    entry.Entity.DateCreated = timestamp;
                SaveHistory(entry);
            }
            return base.SaveChanges();  //Execute the real SaveChanges()...
        }
        public string TypeToTableName(string TableName)
        {
            switch (TableName)
            {
                case "AircraftDesignation":
                case "Album":
                case "Artist":
                case "Book":
                case "Collectable":
                case "Decal":
                case "DetailSet":
                case "Episode":
                case "FinishingProduct":
                case "Image":
                case "Kit":
                case "Location":
                case "Movie":
                case "Rocket":
                case "Ship":
                case "ShipClassificationType":
                case "Special":
                case "Tool":
                case "Track":
                case "Train":
                    TableName += "s";
                    break;
                case "__MigrationHistory":
                case "BlueAngelsHistory":
                case "History":
                case "Log":
                case "Query":
                case "ShipClass":
                case "Software":
                    break;
                case "Companies":
                    TableName = "Company";
                    break;
                default:
                    break;
            }
            return TableName;
        }
    }
}
