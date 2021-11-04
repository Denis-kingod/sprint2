using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai_Rental_webAPI.Domains;

#nullable disable

namespace Senai_Rental_webAPI.Contexts
{
    public partial class HROADSContext : DbContext
    {
        public HROADSContext()
        {
        }

        public HROADSContext(DbContextOptions<HROADSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<HabClass> HabClasses { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<TipoHabilidade> TipoHabilidades { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0113C1\\SQLEXPRESS; initial catalog=HROADS; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClasses)
                    .HasName("PK__Classes__570106720F72D9DC");

                entity.HasIndex(e => e.NomeClasse, "UQ__Classes__F1ED8102B9788C01")
                    .IsUnique();

                entity.Property(e => e.IdClasses)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idClasses");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.Property(e => e.NomeClasse)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeClasse");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__Classes__idHabil__3D5E1FD2");
            });

            modelBuilder.Entity<HabClass>(entity =>
            {
                entity.HasKey(e => e.IdHabClasses)
                    .HasName("PK__HabClass__2D0E77F9BF502AC5");

                entity.Property(e => e.IdHabClasses)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idHabClasses");

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClassesNavigation)
                    .WithMany(p => p.HabClasses)
                    .HasForeignKey(d => d.IdClasses)
                    .HasConstraintName("FK__HabClasse__idCla__412EB0B6");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.HabClasses)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__HabClasse__idHab__403A8C7D");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__655F7528D2DE1914");

                entity.HasIndex(e => e.NomeHabilidade, "UQ__Habilida__08EF5E0CF8F2F3E4")
                    .IsUnique();

                entity.Property(e => e.IdHabilidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idHabilidade");

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("idTipoHabilidade");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeHabilidade");

                entity.HasOne(d => d.IdTipoHabilidadeNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHabilidade)
                    .HasConstraintName("FK__Habilidad__idTip__398D8EEE");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__E175C72E640FA9CE");

                entity.ToTable("Personagem");

                entity.Property(e => e.IdPersonagem)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idPersonagem");

                entity.Property(e => e.DataAtt)
                    .HasColumnType("date")
                    .HasColumnName("dataAtt");

                entity.Property(e => e.DataCriada)
                    .HasColumnType("date")
                    .HasColumnName("dataCriada");

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.ManaMax).HasColumnName("manaMax");

                entity.Property(e => e.NomePersonagem)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomePersonagem");

                entity.Property(e => e.VidaMax).HasColumnName("vidaMax");

                entity.HasOne(d => d.IdClassesNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasses)
                    .HasConstraintName("FK__Personage__idCla__440B1D61");
            });

            modelBuilder.Entity<TipoHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabilidade)
                    .HasName("PK__TipoHabi__B197B832EE481BA5");

                entity.ToTable("TipoHabilidade");

                entity.Property(e => e.IdTipoHabilidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoHabilidade");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFFCD919FC9");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6789E2E6E");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeJogador)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeJogador");

                entity.Property(e => e.Senha)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__idTipoU__48CFD27E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
