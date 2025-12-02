using Microsoft.EntityFrameworkCore;
using Catalog.API.Models;

namespace Catalog.API.Infrastructure;

public class ChinookDbContext : DbContext
{
    public ChinookDbContext(DbContextOptions<ChinookDbContext> options) : base(options)
    {
    }

    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<Album> Albums => Set<Album>();
    public DbSet<Track> Tracks => Set<Track>();
    public DbSet<MediaType> MediaTypes => Set<MediaType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(b =>
        {
            b.ToTable("Genres");
            b.HasKey(e => e.GenreId);
            b.Property(e => e.GenreId).HasColumnName("GenreId");
            b.Property(e => e.Name).HasColumnName("Name").IsRequired();
        });

        modelBuilder.Entity<Artist>(b =>
        {
            b.ToTable("Artists");
            b.HasKey(e => e.ArtistId);
            b.Property(e => e.ArtistId).HasColumnName("ArtistId");
            b.Property(e => e.Name).HasColumnName("Name");
        });

        modelBuilder.Entity<Album>(b =>
        {
            b.ToTable("Albums");
            b.HasKey(e => e.AlbumId);
            b.Property(e => e.AlbumId).HasColumnName("AlbumId");
            b.Property(e => e.Title).HasColumnName("Title").IsRequired();
            b.Property(e => e.ArtistId).HasColumnName("ArtistId").IsRequired();
        });

        modelBuilder.Entity<Track>(b =>
        {
            b.ToTable("Tracks");
            b.HasKey(e => e.TrackId);
            b.Property(e => e.TrackId).HasColumnName("TrackId");
            b.Property(e => e.Name).HasColumnName("Name").IsRequired();
            b.Property(e => e.AlbumId).HasColumnName("AlbumId");
            b.Property(e => e.MediaTypeId).HasColumnName("MediaTypeId").IsRequired();
            b.Property(e => e.GenreId).HasColumnName("GenreId");
            b.Property(e => e.Composer).HasColumnName("Composer");
            b.Property(e => e.Milliseconds).HasColumnName("Milliseconds").IsRequired();
            b.Property(e => e.Bytes).HasColumnName("Bytes");
            b.Property(e => e.UnitPrice).HasColumnName("UnitPrice").IsRequired();
        });

        modelBuilder.Entity<MediaType>(b =>
        {
            b.ToTable("MediaTypes");
            b.HasKey(e => e.MediaTypeId);
            b.Property(e => e.MediaTypeId).HasColumnName("MediaTypeId");
            b.Property(e => e.Name).HasColumnName("Name").IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}
