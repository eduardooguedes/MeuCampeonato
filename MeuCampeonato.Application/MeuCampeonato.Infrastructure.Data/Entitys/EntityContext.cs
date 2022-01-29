using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MeuCampeonato.Infrastructure.Data.Entitys
{
    public partial class EntityContext : DbContext
    {
        public EntityContext()
        {
        }

        public EntityContext(DbContextOptions<EntityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campeonato> Campeonatos { get; set; } = null!;
        public virtual DbSet<CampeonatoTime> CampeonatoTimes { get; set; } = null!;
        public virtual DbSet<Fase> Fases { get; set; } = null!;
        public virtual DbSet<JogosFase> JogosFases { get; set; } = null!;
        public virtual DbSet<Time> Times { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-5745ABV\\FLEETEXPRESS;User ID=dbfleet;Password=sa_fleet.com;Initial Catalog=MEU_CAMPEONATO");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campeonato>(entity =>
            {
                entity.ToTable("CAMPEONATO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DataHoraFim)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_HORA_FIM");

                entity.Property(e => e.DataHoraInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_HORA_INICIO");

                entity.Property(e => e.Situacao)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SITUACAO");
            });

            modelBuilder.Entity<CampeonatoTime>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CAMPEONATO_TIME");

                entity.Property(e => e.Colocacao).HasColumnName("COLOCACAO");

                entity.Property(e => e.DataHoraInscricao)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_HORA_INSCRICAO");

                entity.Property(e => e.IdCampeonato).HasColumnName("ID_CAMPEONATO");

                entity.Property(e => e.IdTime).HasColumnName("ID_TIME");

                entity.Property(e => e.JogosGanhos).HasColumnName("JOGOS_GANHOS");

                entity.Property(e => e.JogosPerdidos).HasColumnName("JOGOS_PERDIDOS");

                entity.Property(e => e.Pontuacao).HasColumnName("PONTUACAO");

                entity.HasOne(d => d.IdCampeonatoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCampeonato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAMPEONATO_TIME");

                entity.HasOne(d => d.IdTimeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTime)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIME_CAMPEONATO");
            });

            modelBuilder.Entity<Fase>(entity =>
            {
                entity.ToTable("FASE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DataHoraFim)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_HORA_FIM");

                entity.Property(e => e.DataHoraInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_HORA_INICIO");

                entity.Property(e => e.IdCampeonato).HasColumnName("ID_CAMPEONATO");

                entity.Property(e => e.Nome)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.QtdeJogos).HasColumnName("QTDE_JOGOS");

                entity.HasOne(d => d.IdCampeonatoNavigation)
                    .WithMany(p => p.Fases)
                    .HasForeignKey(d => d.IdCampeonato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAMPEONATO_FASE");
            });

            modelBuilder.Entity<JogosFase>(entity =>
            {
                entity.ToTable("JOGOS_FASE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.GolsTime1).HasColumnName("GOLS_TIME_1");

                entity.Property(e => e.GolsTime2).HasColumnName("GOLS_TIME_2");

                entity.Property(e => e.IdFase).HasColumnName("ID_FASE");

                entity.Property(e => e.IdTime1).HasColumnName("ID_TIME_1");

                entity.Property(e => e.IdTime2).HasColumnName("ID_TIME_2");

                entity.HasOne(d => d.IdFaseNavigation)
                    .WithMany(p => p.JogosFases)
                    .HasForeignKey(d => d.IdFase)
                    .HasConstraintName("FK_FASE_JOGOS");
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.ToTable("TIME");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.GolsFeitos).HasColumnName("GOLS_FEITOS");

                entity.Property(e => e.GolsTomados).HasColumnName("GOLS_TOMADOS");

                entity.Property(e => e.JogosGanhos).HasColumnName("JOGOS_GANHOS");

                entity.Property(e => e.JogosPerdidos).HasColumnName("JOGOS_PERDIDOS");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
