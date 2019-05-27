using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ElectionWeb
{
    public partial class electionContext : DbContext
    {
        public electionContext()
        {
        }

        public electionContext(DbContextOptions<electionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Bulletin> Bulletin { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ControlCoupon> ControlCoupon { get; set; }
        public virtual DbSet<Election> Election { get; set; }
        public virtual DbSet<Nation> Nation { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<Voter> Voter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=election;Username=postgres;Password=ahorban17");
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RegionId)
                    .HasColumnName("region_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StreetId)
                    .HasColumnName("street_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_city_id_fk");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("address_region_id_fk");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.StreetId)
                    .HasConstraintName("address_street_id_fk");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Admin)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("admin_person_id_fkey");
            });

            modelBuilder.Entity<Bulletin>(entity =>
            {
                entity.ToTable("bulletin");

                entity.HasIndex(e => e.Id)
                    .HasName("bulletin_id_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CandidateId)
                    .HasColumnName("candidate_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ElectionId)
                    .HasColumnName("election_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Bulletin)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bulletin_candidate_id_fkey");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Bulletin)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bulletin_city_id_fkey");

                entity.HasOne(d => d.Election)
                    .WithMany(p => p.Bulletin)
                    .HasForeignKey(d => d.ElectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bulletin_election_id_fkey");
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("candidate");

                entity.HasIndex(e => e.Id)
                    .HasName("candidate_id_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ElectionId)
                    .HasColumnName("election_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PreelectionProgram)
                    .IsRequired()
                    .HasColumnName("preelection_program")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Election)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.ElectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("candidate_election_id_fkey");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("candidate_person_id_fkey");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City1)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("character varying(50)");
            });

            modelBuilder.Entity<ControlCoupon>(entity =>
            {
                entity.ToTable("control_coupon");

                entity.HasIndex(e => e.Id)
                    .HasName("control_coupon_id_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ElectionId)
                    .HasColumnName("election_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.VoterId)
                    .HasColumnName("voter_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ControlCoupon)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("control_coupon_city_id_fkey");

                entity.HasOne(d => d.Election)
                    .WithMany(p => p.ControlCoupon)
                    .HasForeignKey(d => d.ElectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("control_coupon_election_id_fkey");

                entity.HasOne(d => d.Voter)
                    .WithMany(p => p.ControlCoupon)
                    .HasForeignKey(d => d.VoterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("control_coupon_voter_id_fkey");
            });

            modelBuilder.Entity<Election>(entity =>
            {
                entity.ToTable("election");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.NationId)
                    .HasColumnName("nation_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PeriodId)
                    .HasColumnName("period_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Tour)
                    .HasColumnName("tour")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Nation)
                    .WithMany(p => p.Election)
                    .HasForeignKey(d => d.NationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("election_nation_id_fkey");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.Election)
                    .HasForeignKey(d => d.PeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("election_period_id_fkey");
            });

            modelBuilder.Entity<Nation>(entity =>
            {
                entity.ToTable("nation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasColumnType("character varying(50)");
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.ToTable("period");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatetimeEnd).HasColumnName("datetime_end");

                entity.Property(e => e.DatetimeStart).HasColumnName("datetime_start");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying(30)");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasColumnType("character varying(30)");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("person_address_id_fkey");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("person_country_id_fkey");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Region1)
                    .IsRequired()
                    .HasColumnName("region")
                    .HasColumnType("character varying(50)");
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.ToTable("street");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Street1)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasColumnType("character varying(50)");
            });

            modelBuilder.Entity<Voter>(entity =>
            {
                entity.ToTable("voter");

                entity.HasIndex(e => e.Id)
                    .HasName("voter_id_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ElectionId)
                    .HasColumnName("election_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Election)
                    .WithMany(p => p.Voter)
                    .HasForeignKey(d => d.ElectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("voter_election_id_fkey");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Voter)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("voter_person_id_fkey");
            });
        }
    }
}
