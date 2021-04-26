using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace test.Models
{
    public partial class MovieBookingContext : DbContext
    {
        public MovieBookingContext()
        {
        }

        public MovieBookingContext(DbContextOptions<MovieBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Moviehall> Moviehall { get; set; }
        public virtual DbSet<Moviehallshowtime> Moviehallshowtime { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Promocode> Promocode { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<UserPromocodes> UserPromocodes { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:nazi111191.database.windows.net,1433;Initial Catalog=MovieBooking;Persist Security Info=False;User ID=admin111191;Password=N@zi111191;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moviehall>(entity =>
            {
                entity.ToTable("moviehall");

                entity.Property(e => e.Moviehallid)
                    .HasColumnName("moviehallid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bookedseats).HasColumnName("bookedseats");

                entity.Property(e => e.Mhallname)
                    .IsRequired()
                    .HasColumnName("mhallname")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Priceid).HasColumnName("priceid");

                entity.Property(e => e.Totalseats).HasColumnName("totalseats");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Moviehall)
                    .HasForeignKey(d => d.Priceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__moviehall__price__5AEE82B9");
            });

            modelBuilder.Entity<Moviehallshowtime>(entity =>
            {
                entity.HasKey(e => e.Moviehallshowtime1)
                    .HasName("PK__moviehal__EA9A634AD366A342");

                entity.ToTable("moviehallshowtime");

                entity.Property(e => e.Moviehallshowtime1)
                    .HasColumnName("moviehallshowtime")
                    .ValueGeneratedNever();

                entity.Property(e => e.Moviehallid).HasColumnName("moviehallid");

                entity.Property(e => e.Moviesid).HasColumnName("moviesid");

                entity.Property(e => e.Showtime)
                    .HasColumnName("showtime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Moviehall)
                    .WithMany(p => p.Moviehallshowtime)
                    .HasForeignKey(d => d.Moviehallid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__moviehall__movie__4222D4EF");

                entity.HasOne(d => d.Movies)
                    .WithMany(p => p.Moviehallshowtime)
                    .HasForeignKey(d => d.Moviesid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__moviehall__movie__412EB0B6");
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.ToTable("movies");

                entity.Property(e => e.Moviesid)
                    .HasColumnName("moviesid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasColumnName("mname")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("price");

                entity.Property(e => e.Priceid)
                    .HasColumnName("priceid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Price1).HasColumnName("price");

                entity.Property(e => e.PriceCategory)
                    .HasColumnName("priceCategory")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Promocode>(entity =>
            {
                entity.ToTable("promocode");

                entity.Property(e => e.Promocodeid)
                    .HasColumnName("promocodeid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Description)
                    .HasColumnName("description ")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.MaxCount).HasColumnName("maxCount ");

                entity.Property(e => e.Promocode1)
                    .IsRequired()
                    .HasColumnName("promocode ")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title ")
                    .HasMaxLength(50);

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasColumnName("website")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.Property(e => e.Ticketid)
                    .HasColumnName("ticketid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Moviehallid).HasColumnName("moviehallid");

                entity.Property(e => e.Moviehallshowtime).HasColumnName("moviehallshowtime");

                entity.Property(e => e.Moviesid).HasColumnName("moviesid");

                entity.Property(e => e.Priceid).HasColumnName("priceid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Moviehall)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.Moviehallid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticket__moviehal__47DBAE45");

                entity.HasOne(d => d.MoviehallshowtimeNavigation)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.Moviehallshowtime)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticket__moviehal__4AB81AF0");

                entity.HasOne(d => d.Movies)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.Moviesid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticket__moviesid__46E78A0C");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.Priceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticket__priceid__49C3F6B7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticket__userid__48CFD27E");
            });

            modelBuilder.Entity<UserPromocodes>(entity =>
            {
                entity.ToTable("userPromocodes");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Promocodeid).HasColumnName("promocodeid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__users__CBA1B257B366C647");

                entity.ToTable("users");

                entity.HasIndex(e => e.Uname)
                    .HasName("UQ__users__C7D2484E85557ACD")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasColumnName("passwd")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Payout).HasColumnName("payout");

                entity.Property(e => e.Uname)
                    .IsRequired()
                    .HasColumnName("uname")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
