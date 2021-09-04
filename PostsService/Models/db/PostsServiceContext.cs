using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PostsService.Models.db
{
    public partial class PostsServiceContext : DbContext
    {
        public PostsServiceContext()
        {
        }

        public PostsServiceContext(DbContextOptions<PostsServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostsComment> PostsComments { get; set; }
        public virtual DbSet<PostsImage> PostsImages { get; set; }
        public virtual DbSet<PostsLike> PostsLikes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-C0DF678\\SQLEXPRESS;Database=PostsService;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Thai_CI_AS");

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(256)
                    .HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("detail");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posts_Users");
            });

            modelBuilder.Entity<PostsComment>(entity =>
            {
                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("detail");

                entity.Property(e => e.PostId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("postId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("userId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostsComments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostsComments_Posts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostsComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostsComments_Users");
            });

            modelBuilder.Entity<PostsImage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("imageName");

                entity.Property(e => e.PostId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("postId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostsImages)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostsImages_Posts");
            });

            modelBuilder.Entity<PostsLike>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("postId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("userId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostsLikes)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostsLikes_Posts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostsLikes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostsLikes_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(256)
                    .HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("imageName");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
