using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Contexts
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set;}
    
        public DbSet<Media> Medias { get;set; }
        public DbSet<TypeMedia> TypeMedias{get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(x =>
            {
                x.Property(y => y.Id)
                    .HasColumnName("Id")
                    .UseMySqlIdentityColumn();

            });
        
            builder.Entity<Media>(x =>
            {
                x.Property(y => y.Id)
                    .HasColumnName("Id")
                    .UseMySqlIdentityColumn();

                x.Property(y => y.DescriptionMedia)
                    .HasColumnName("Description")
                    .HasMaxLength(256);

                x.HasOne(y => y.Category)
                .WithMany(y => y.Medias)
                .HasConstraintName("fk_Media_Category");

                x.HasOne(y => y.TypeMedia)
                .WithMany(y => y.Medias)
                .HasConstraintName("fk_Media_Type");
            });
            builder.Entity<TypeMedia>(x =>
               {
                x.Property(y => y.Id)
                    .HasColumnName("Id")
                    .UseMySqlIdentityColumn();

            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost; port=3306; database=db_WhatToSee; user=*user*; password=*password*; Persist Security Info=False;", ServerVersion.AutoDetect("server=localhost; port=3306; database=db_WhatToSee; user=root; password=123456; Persist Security Info=False;"));
            }
        }
    }
}